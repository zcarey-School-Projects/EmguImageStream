using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace EmguImageStream{
	public class ImageStream : IDisposable {

		private static readonly object streamLock = new object();

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
		private InputStreamListener temp;

		public int Width { get { lock (streamLock) { if (capture == null) return 0; else return capture.Width; } } }
		public int Height { get { lock (streamLock) { if (capture == null) return 0; else return capture.Height; } } }
		public bool IsOpened { get { lock (streamLock) { if (capture == null) return false; else return capture.IsOpened; } } }

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


		//TODO add capute type (camera, video, image)

		//Uses default camera
		public ImageStream(InputStreamListener temp) {
			this.temp = temp;
		}
		/*
		public ImageStream(InputStreamListener temp, string file) {
			this.temp = temp;
			if (file == null) capture = new VideoCapture();
			else capture = new VideoCapture(file);
			capture.ImageGrabbed += onNewImage;
			//if (capture.IsOpened) Console.WriteLine("FPS: " + capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps));
			capture.Start();

		}
		*/
		~ImageStream() {
			Dispose();
		}

		public void Dispose() {
			lock (streamLock) {
				if (capture != null) capture.Dispose();
				capture = null;
				if (imageBuffer != null) imageBuffer.Dispose();
				imageBuffer = null;
			}
		}

		private void onNewImage(object sender, EventArgs e) {
			double targetFramerate = 15;
			Mat tempBuffer = null;
			lock (streamLock) {
				if (capture == null || !capture.IsOpened /*|| capture.Ptr == IntPtr.Zero*/) return;
				capture.Retrieve(imageBuffer); //Documentation says gray image, but actually retrieves a colored image. //TODO nullptr checks
				targetFramerate = capture.GetCaptureProperty(CapProp.Fps);
				tempBuffer = imageBuffer;
			}

			if (tempBuffer != null) temp.onNewImage(tempBuffer); //Use temp buffer so imageBuffer can be modified without cause for threading concern.
			Thread.Sleep((int)(1000.0 / targetFramerate)); 
			//TODO use timer.
			/*long ms = timer.ElapsedMilliseconds;
				if (ms < int.MaxValue) {
					int waitTime = (1000 / 15) - (int)ms;
					if (waitTime > 0) Thread.Sleep(waitTime);
				}*/
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
				temp.onStreamEnded();
			}
		}

		public void SelectCamera() {
			lock (streamLock) {
				Stop();
				capture = new VideoCapture();
				capture.ImageGrabbed += onNewImage;
				capture.FlipHorizontal = flipHorizontal;
				capture.FlipVertical = flipVertical;
				imageBuffer = new Mat();
			}
		}

		public void SelectCamera(int index) {
			lock (streamLock) {
				Stop();
				capture = new VideoCapture(index);
				capture.ImageGrabbed += onNewImage;
				capture.FlipHorizontal = flipHorizontal;
				capture.FlipVertical = flipVertical;
				imageBuffer = new Mat();
			}
		}

		public void SelectFile(string file) {
			lock (streamLock) {
				if (file == null) return;
				Stop();
				capture = new VideoCapture(file);
				capture.ImageGrabbed += onNewImage;
				capture.FlipHorizontal = flipHorizontal;
				capture.FlipVertical = flipVertical;
				imageBuffer = new Mat();
			}
		}

		public static string PromptUserLoadFile() {
			if (openDialog.ShowDialog() == DialogResult.OK) {
				return openDialog.FileName;
			} else {
				return null;
			}
		}

	}

	public interface InputStreamListener {
		void onNewImage(Mat image); //Fired when a new image is grabbed from the stream.
		void onStreamEnded(); //Fired when the running stream is stopped and disposed. Must select a new stream for play() to work.
	}
}
