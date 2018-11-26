namespace EmguImageStream {
	partial class Form1 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.DisplayBox = new System.Windows.Forms.PictureBox();
			this.Cam0 = new System.Windows.Forms.Button();
			this.Cam1 = new System.Windows.Forms.Button();
			this.LoadFromFile = new System.Windows.Forms.Button();
			this.Screenshot = new System.Windows.Forms.Button();
			this.Stop = new System.Windows.Forms.Button();
			this.Pause = new System.Windows.Forms.Button();
			this.Play = new System.Windows.Forms.Button();
			this.FlipVert = new System.Windows.Forms.CheckBox();
			this.FlipHoriz = new System.Windows.Forms.CheckBox();
			this.Quicksave = new System.Windows.Forms.Button();
			this.Quickload = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.StatusTargetFPS = new System.Windows.Forms.ToolStripStatusLabel();
			this.StatusFPS = new System.Windows.Forms.ToolStripStatusLabel();
			((System.ComponentModel.ISupportInitialize)(this.DisplayBox)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// DisplayBox
			// 
			this.DisplayBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DisplayBox.Location = new System.Drawing.Point(12, 12);
			this.DisplayBox.Name = "DisplayBox";
			this.DisplayBox.Size = new System.Drawing.Size(776, 300);
			this.DisplayBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.DisplayBox.TabIndex = 0;
			this.DisplayBox.TabStop = false;
			// 
			// Cam0
			// 
			this.Cam0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Cam0.Location = new System.Drawing.Point(12, 362);
			this.Cam0.Name = "Cam0";
			this.Cam0.Size = new System.Drawing.Size(93, 23);
			this.Cam0.TabIndex = 1;
			this.Cam0.Text = "Camera 0";
			this.Cam0.UseVisualStyleBackColor = true;
			this.Cam0.Click += new System.EventHandler(this.Cam0_Click);
			// 
			// Cam1
			// 
			this.Cam1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Cam1.Location = new System.Drawing.Point(111, 362);
			this.Cam1.Name = "Cam1";
			this.Cam1.Size = new System.Drawing.Size(93, 23);
			this.Cam1.TabIndex = 2;
			this.Cam1.Text = "Camera 1";
			this.Cam1.UseVisualStyleBackColor = true;
			this.Cam1.Click += new System.EventHandler(this.Cam1_Click);
			// 
			// LoadFromFile
			// 
			this.LoadFromFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LoadFromFile.Location = new System.Drawing.Point(210, 362);
			this.LoadFromFile.Name = "LoadFromFile";
			this.LoadFromFile.Size = new System.Drawing.Size(93, 23);
			this.LoadFromFile.TabIndex = 3;
			this.LoadFromFile.Text = "Load";
			this.LoadFromFile.UseVisualStyleBackColor = true;
			this.LoadFromFile.Click += new System.EventHandler(this.LoadFromFile_Click);
			// 
			// Screenshot
			// 
			this.Screenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Screenshot.Location = new System.Drawing.Point(309, 362);
			this.Screenshot.Name = "Screenshot";
			this.Screenshot.Size = new System.Drawing.Size(93, 23);
			this.Screenshot.TabIndex = 4;
			this.Screenshot.Text = "Screenshot";
			this.Screenshot.UseVisualStyleBackColor = true;
			this.Screenshot.Click += new System.EventHandler(this.Screenshot_Click);
			// 
			// Stop
			// 
			this.Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Stop.Location = new System.Drawing.Point(696, 362);
			this.Stop.Name = "Stop";
			this.Stop.Size = new System.Drawing.Size(93, 23);
			this.Stop.TabIndex = 5;
			this.Stop.Text = "Stop";
			this.Stop.UseVisualStyleBackColor = true;
			this.Stop.Click += new System.EventHandler(this.Stop_Click);
			// 
			// Pause
			// 
			this.Pause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Pause.Location = new System.Drawing.Point(597, 362);
			this.Pause.Name = "Pause";
			this.Pause.Size = new System.Drawing.Size(93, 23);
			this.Pause.TabIndex = 6;
			this.Pause.Text = "Pause";
			this.Pause.UseVisualStyleBackColor = true;
			this.Pause.Click += new System.EventHandler(this.Pause_Click);
			// 
			// Play
			// 
			this.Play.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Play.Location = new System.Drawing.Point(498, 362);
			this.Play.Name = "Play";
			this.Play.Size = new System.Drawing.Size(93, 23);
			this.Play.TabIndex = 7;
			this.Play.Text = "Play";
			this.Play.UseVisualStyleBackColor = true;
			this.Play.Click += new System.EventHandler(this.Play_Click);
			// 
			// FlipVert
			// 
			this.FlipVert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.FlipVert.AutoSize = true;
			this.FlipVert.Location = new System.Drawing.Point(12, 335);
			this.FlipVert.Name = "FlipVert";
			this.FlipVert.Size = new System.Drawing.Size(103, 21);
			this.FlipVert.TabIndex = 8;
			this.FlipVert.Text = "Flip Vertical";
			this.FlipVert.UseVisualStyleBackColor = true;
			this.FlipVert.CheckedChanged += new System.EventHandler(this.FlipVert_CheckedChanged);
			// 
			// FlipHoriz
			// 
			this.FlipHoriz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.FlipHoriz.AutoSize = true;
			this.FlipHoriz.Location = new System.Drawing.Point(210, 335);
			this.FlipHoriz.Name = "FlipHoriz";
			this.FlipHoriz.Size = new System.Drawing.Size(120, 21);
			this.FlipHoriz.TabIndex = 9;
			this.FlipHoriz.Text = "Flip Horizontal";
			this.FlipHoriz.UseVisualStyleBackColor = true;
			this.FlipHoriz.CheckedChanged += new System.EventHandler(this.FlipHoriz_CheckedChanged);
			// 
			// Quicksave
			// 
			this.Quicksave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Quicksave.Location = new System.Drawing.Point(12, 391);
			this.Quicksave.Name = "Quicksave";
			this.Quicksave.Size = new System.Drawing.Size(93, 23);
			this.Quicksave.TabIndex = 10;
			this.Quicksave.Text = "Quicksave";
			this.Quicksave.UseVisualStyleBackColor = true;
			this.Quicksave.Click += new System.EventHandler(this.Quicksave_Click);
			// 
			// Quickload
			// 
			this.Quickload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Quickload.Location = new System.Drawing.Point(111, 391);
			this.Quickload.Name = "Quickload";
			this.Quickload.Size = new System.Drawing.Size(93, 23);
			this.Quickload.TabIndex = 11;
			this.Quickload.Text = "Quickload";
			this.Quickload.UseVisualStyleBackColor = true;
			this.Quickload.Click += new System.EventHandler(this.Quickload_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusTargetFPS,
            this.StatusFPS});
			this.statusStrip1.Location = new System.Drawing.Point(0, 414);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(800, 25);
			this.statusStrip1.TabIndex = 12;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// StatusTargetFPS
			// 
			this.StatusTargetFPS.Name = "StatusTargetFPS";
			this.StatusTargetFPS.Size = new System.Drawing.Size(84, 20);
			this.StatusTargetFPS.Text = "Target FPS: ";
			// 
			// StatusFPS
			// 
			this.StatusFPS.Margin = new System.Windows.Forms.Padding(100, 3, 0, 2);
			this.StatusFPS.Name = "StatusFPS";
			this.StatusFPS.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StatusFPS.Size = new System.Drawing.Size(39, 20);
			this.StatusFPS.Text = "FPS: ";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 439);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.Quickload);
			this.Controls.Add(this.Quicksave);
			this.Controls.Add(this.FlipHoriz);
			this.Controls.Add(this.FlipVert);
			this.Controls.Add(this.Play);
			this.Controls.Add(this.Pause);
			this.Controls.Add(this.Stop);
			this.Controls.Add(this.Screenshot);
			this.Controls.Add(this.LoadFromFile);
			this.Controls.Add(this.Cam1);
			this.Controls.Add(this.Cam0);
			this.Controls.Add(this.DisplayBox);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.DisplayBox)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox DisplayBox;
		private System.Windows.Forms.Button Cam0;
		private System.Windows.Forms.Button Cam1;
		private System.Windows.Forms.Button LoadFromFile;
		private System.Windows.Forms.Button Screenshot;
		private System.Windows.Forms.Button Stop;
		private System.Windows.Forms.Button Pause;
		private System.Windows.Forms.Button Play;
		private System.Windows.Forms.CheckBox FlipVert;
		private System.Windows.Forms.CheckBox FlipHoriz;
		private System.Windows.Forms.Button Quicksave;
		private System.Windows.Forms.Button Quickload;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel StatusTargetFPS;
		private System.Windows.Forms.ToolStripStatusLabel StatusFPS;
	}
}

