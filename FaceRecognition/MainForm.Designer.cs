
namespace FaceRecognition
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imgCamUser = new Emgu.CV.UI.ImageBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.imageBox3 = new Emgu.CV.UI.ImageBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromPictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromWebcamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recognizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromPictureToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fromVideoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fromWebcamToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fromMultiPicturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.imgCamUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imgCamUser
            // 
            this.imgCamUser.Location = new System.Drawing.Point(12, 27);
            this.imgCamUser.Name = "imgCamUser";
            this.imgCamUser.Size = new System.Drawing.Size(400, 240);
            this.imgCamUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCamUser.TabIndex = 2;
            this.imgCamUser.TabStop = false;
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(12, 273);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(75, 23);
            this.btnCapture.TabIndex = 3;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(9, 299);
            this.lblUsername.MaximumSize = new System.Drawing.Size(70, 70);
            this.lblUsername.MinimumSize = new System.Drawing.Size(50, 50);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(50, 50);
            this.lblUsername.TabIndex = 4;
            // 
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(93, 273);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(100, 100);
            this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox1.TabIndex = 5;
            this.imageBox1.TabStop = false;
            // 
            // imageBox2
            // 
            this.imageBox2.Location = new System.Drawing.Point(199, 273);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(100, 100);
            this.imageBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox2.TabIndex = 6;
            this.imageBox2.TabStop = false;
            // 
            // imageBox3
            // 
            this.imageBox3.Location = new System.Drawing.Point(305, 273);
            this.imageBox3.Name = "imageBox3";
            this.imageBox3.Size = new System.Drawing.Size(100, 100);
            this.imageBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox3.TabIndex = 7;
            this.imageBox3.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.trainToolStripMenuItem,
            this.recognizeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(424, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // trainToolStripMenuItem
            // 
            this.trainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromPictureToolStripMenuItem,
            this.fromVideoToolStripMenuItem,
            this.fromWebcamToolStripMenuItem,
            this.toolStripSeparator1,
            this.fromMultiPicturesToolStripMenuItem});
            this.trainToolStripMenuItem.Name = "trainToolStripMenuItem";
            this.trainToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.trainToolStripMenuItem.Text = "&Train";
            // 
            // fromPictureToolStripMenuItem
            // 
            this.fromPictureToolStripMenuItem.Name = "fromPictureToolStripMenuItem";
            this.fromPictureToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fromPictureToolStripMenuItem.Text = "From &Picture";
            this.fromPictureToolStripMenuItem.Click += new System.EventHandler(this.fromPictureToolStripMenuItem_Click);
            // 
            // fromVideoToolStripMenuItem
            // 
            this.fromVideoToolStripMenuItem.Name = "fromVideoToolStripMenuItem";
            this.fromVideoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fromVideoToolStripMenuItem.Text = "From &Video";
            // 
            // fromWebcamToolStripMenuItem
            // 
            this.fromWebcamToolStripMenuItem.Name = "fromWebcamToolStripMenuItem";
            this.fromWebcamToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fromWebcamToolStripMenuItem.Text = "From &Webcam";
            // 
            // recognizeToolStripMenuItem
            // 
            this.recognizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromPictureToolStripMenuItem1,
            this.fromVideoToolStripMenuItem1,
            this.fromWebcamToolStripMenuItem1});
            this.recognizeToolStripMenuItem.Name = "recognizeToolStripMenuItem";
            this.recognizeToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.recognizeToolStripMenuItem.Text = "&Recognize";
            // 
            // fromPictureToolStripMenuItem1
            // 
            this.fromPictureToolStripMenuItem1.Name = "fromPictureToolStripMenuItem1";
            this.fromPictureToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.fromPictureToolStripMenuItem1.Text = "From &Picture";
            this.fromPictureToolStripMenuItem1.Click += new System.EventHandler(this.fromPictureToolStripMenuItem1_Click);
            // 
            // fromVideoToolStripMenuItem1
            // 
            this.fromVideoToolStripMenuItem1.Name = "fromVideoToolStripMenuItem1";
            this.fromVideoToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.fromVideoToolStripMenuItem1.Text = "From &Video";
            // 
            // fromWebcamToolStripMenuItem1
            // 
            this.fromWebcamToolStripMenuItem1.Name = "fromWebcamToolStripMenuItem1";
            this.fromWebcamToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.fromWebcamToolStripMenuItem1.Text = "From &Webcam";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // fromMultiPicturesToolStripMenuItem
            // 
            this.fromMultiPicturesToolStripMenuItem.Name = "fromMultiPicturesToolStripMenuItem";
            this.fromMultiPicturesToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.fromMultiPicturesToolStripMenuItem.Text = "From Multi Pictures";
            this.fromMultiPicturesToolStripMenuItem.Click += new System.EventHandler(this.fromMultiPicturesToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 388);
            this.Controls.Add(this.imageBox3);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.imgCamUser);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgCamUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private Emgu.CV.UI.ImageBox imgCamUser;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Label lblUsername;
        private Emgu.CV.UI.ImageBox imageBox1;
        private Emgu.CV.UI.ImageBox imageBox2;
        private Emgu.CV.UI.ImageBox imageBox3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromPictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromWebcamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recognizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromPictureToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fromVideoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fromWebcamToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem fromMultiPicturesToolStripMenuItem;
    }
}

