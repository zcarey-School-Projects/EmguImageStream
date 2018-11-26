using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace EmguImageStream{
	public class ImageStream : IDisposable {

		private static readonly object streamLock = new object();
		private static readonly object listenerLock = new object();

		private static OpenFileDialog openDialog;
		private static SaveFileDialog saveDialog;

		static ImageStream() {
			openDialog = new OpenFileDialog();
			openDialog.RestoreDirectory = true;
			openDialog.Filter = "Media Files (Image, Video)|*.bmp;*.emf;*.exif;*.gif;*.ico;*.jpeg;*.jpg;*.png;*.tiff;*.mkv;*.flv;*.f4v;*.ogv;*.ogg;*.gifv;*.mng;*.avi;*.mov;*.wmv;*.rm;*.rmvb;*.asf;*.amv;*.mp4;*.m4p;*.m4v;*.m4v;*.svi|All (*.*)|*.*";

			saveDialog = new SaveFileDialog();
			saveDialog.RestoreDirectory = true;
			saveDialog.AddExtension = true;
			saveDialog.Filter = "BMP (*.bmp)|*.bmp|EMF (*.emf)|*.emf|EXIF (*.exif)|*.exif|GIF (*.gif)|*.gif|Icon(*.ico)|*.ico|JPEG (*.jpeg)|*.jpeg|PNG (*.png)|*.png|TIFF (*.tiff)|*.tiff|WMF (*.wmf)|*.wmf|All (*.*)|*.*";
			saveDialog.FilterIndex = 6;
		}

		private VideoCapture capture;
		private Mat imageBuffer;
		private Stopwatch timer = new Stopwatch();
		private InputStreamListener listener;
		private FPSCounter fpsCounter = new FPSCounter();

		public int Width { get { lock (streamLock) { if (capture == null) return 0; else return capture.Width; } } }
		public int Height { get { lock (streamLock) { if (capture == null) return 0; else return capture.Height; } } }
		public bool IsOpened { get { lock (streamLock) { if (capture == null) return false; else return capture.IsOpened; } } }
		public float TargetFPS { get; private set; } = 0f;
		public float FPS { get; private set; } = 0f;

		private bool flipHorizontal = false;
		public bool FlipHorizontal {
			get {
				return flipHorizontal;
			}

			set {
				lock (streamLock) {
					flipHorizontal = value;
					if (capture != null) capture.FlipHorizontal = flipHorizontal;
				}
			}
		}

		private bool flipVertical = false;
		public bool FlipVertical {
			get {
				return flipVertical;
			}

			set {
				lock (streamLock) {
					flipVertical = value;
					if (capture != null) capture.FlipVertical = flipVertical;
				}
			}
		}


		//TODO add capture type (camera, video, image)

		public ImageStream(InputStreamListener streamListener) {
			this.listener = streamListener;
		}
		
		~ImageStream() {
			Dispose();
		}

		public void Dispose() {
			lock (streamLock) {
				if (capture != null) capture.Dispose();
				capture = null;
				//We do NOT want to dispose imageBuffer, in the case the image is being used elsewhere!
				imageBuffer = null;
				fpsCounter.Reset();
			}
		}

		private void onNewImage(object sender, EventArgs e) {
			lock (listenerLock) {
				Mat tempBuffer = null;
				timer.Restart();
				FPS = fpsCounter.Tick();
				lock (streamLock) {
					if (capture == null || !capture.IsOpened /*|| capture.Ptr == IntPtr.Zero*/) return;
					capture.Retrieve(imageBuffer); //Documentation says gray image, but actually retrieves a colored image. //TODO nullptr checks
					TargetFPS = (float)capture.GetCaptureProperty(CapProp.Fps);
					tempBuffer = imageBuffer;
				}

				if (tempBuffer != null) listener.onNewImage(tempBuffer); //Use temp buffer so imageBuffer can be modified without cause for threading concern.
				int msDelay = (int)(1000.0 / TargetFPS);
				long timerMS = timer.ElapsedMilliseconds;
				msDelay = ((timerMS <= int.MaxValue) ? (msDelay - (int)timerMS) : 0);

				if(msDelay > 0) Thread.Sleep(msDelay);
				
			}
		}

		public void Play() {
			lock (streamLock) {
				if (capture != null && capture.IsOpened) capture.Start();
			}

		}

		public void Pause() {
			lock (streamLock) {
				capture.Stop();
			}
		}

		public void Stop() {
			lock (streamLock) {
				Dispose();
				lock (listenerLock) { //Ensures that event is fired only after image grabbed by capture is finished sending.
					listener.onStreamEnded();
				}
			}
		}

		public void SelectCamera() {
			lock (streamLock) {
				Stop();
				capture = new VideoCapture();
				setupCapture();
			}
		}

		public void SelectCamera(int index) {
			lock (streamLock) {
				Stop();
				capture = new VideoCapture(index);
				setupCapture();
			}
		}

		public bool LoadFile(string file) {
			if (file == null) return false;
			lock (streamLock) {
				if (!File.Exists(file)) return false; //Wait until here to check if file exists, in case we had to wait for the lock to be released.
				Stop();
				capture = new VideoCapture(file);
				setupCapture();
				return true;
			}
		}

		public bool LoadLocalFile(string filepath) {
			return LoadFile(System.IO.Directory.GetCurrentDirectory() + "\\" + filepath); //NOTE: '\\' translates to '\' in a string, because it is a special character.
		}

		public bool PromptUserLoadFile() {
			if (openDialog.ShowDialog() == DialogResult.OK) {
				return LoadFile(openDialog.FileName);
			} else {
				return false;
			}
		}

		private void setupCapture() {
			capture.ImageGrabbed += onNewImage;
			capture.FlipHorizontal = flipHorizontal;
			capture.FlipVertical = flipVertical;
			imageBuffer = new Mat();
		}

		private Mat captureScreenshot() {
			Mat screenshot = new Mat();
			lock (streamLock) {
				if (imageBuffer == null) return null;
				imageBuffer.CopyTo(screenshot);
			}
			if (screenshot.IsEmpty) return null;
			return screenshot;
		}

		public bool SaveScreenshot(string file) {
			if (file == null) return false;
			Mat screenshot = captureScreenshot();
			if (screenshot == null) return false;
			screenshot.Save(file);
			return true;
		}

		public bool SaveLocalScreenshot(string filepath) {
			return SaveScreenshot(System.IO.Directory.GetCurrentDirectory() + "\\" + filepath); //NOTE: '\\' translates to '\' in a string, because it is a special character.
		}

		public bool PromptUserSaveScreenshot() {
			Mat screenshot = captureScreenshot();
			if (screenshot == null) return false;

			if(saveDialog.ShowDialog() == DialogResult.OK) {
				screenshot.Save(saveDialog.FileName);
				return true;
			} else {
				return false;
			}
		}

	}

	public interface InputStreamListener {
		void onNewImage(Mat image); //Fired when a new image is grabbed from the stream.
		void onStreamEnded(); //Fired when the running stream is stopped and disposed. Must select a new stream for play() to work.
	}
}
