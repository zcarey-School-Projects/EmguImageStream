﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;

namespace EmguImageStream {
	public partial class Form1 : Form, ImageStreamListener {

		private ImageStream stream;

		public Form1() {
			InitializeComponent();
			stream = new ImageStream(this);
		}

		private void Form1_Load(object sender, EventArgs e) {
			
		}

		public void ImageStream_onNewImage(Mat image) {
			DisplayBox.Image = image.Bitmap;
			StatusTargetFPS.Text = "Target FPS: " + stream.TargetFPS.ToString("N2");
			StatusFPS.Text = "FPS: " + stream.FPS.ToString("N2");
		}

		public void ImageStream_onStreamEnded() {
			DisplayBox.Image = null; 
		}

		private void Play_Click(object sender, EventArgs e) {
			stream.Play();
		}

		private void Pause_Click(object sender, EventArgs e) {
			stream.Pause();
		}

		private void Stop_Click(object sender, EventArgs e) {
			stream.Stop();
		}

		private void Cam0_Click(object sender, EventArgs e) {
			stream.SelectCamera(0);
			stream.Play();
		}

		private void Cam1_Click(object sender, EventArgs e) {
			stream.SelectCamera(1);
			stream.Play();
		}

		private void LoadFromFile_Click(object sender, EventArgs e) {
			stream.PromptUserLoadFile();
			stream.Play();
		}

		private void Screenshot_Click(object sender, EventArgs e) {
			stream.PromptUserSaveScreenshot();
		}

		private void FlipVert_CheckedChanged(object sender, EventArgs e) {
			stream.FlipVertical = FlipVert.Checked;
		}

		private void FlipHoriz_CheckedChanged(object sender, EventArgs e) {
			stream.FlipHorizontal = FlipHoriz.Checked;
		}

		private void Quicksave_Click(object sender, EventArgs e) {
			stream.SaveLocalScreenshot("Quicksave.jpg");
		}

		private void Quickload_Click(object sender, EventArgs e) {
			stream.LoadLocalFile("Quicksave.jpg");
			stream.Play();
		}
	}
}
