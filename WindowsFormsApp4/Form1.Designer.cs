namespace WindowsFormsApp4
{
    partial class Form1
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
            this.panAndZoomPictureBox2 = new Emgu.CV.UI.PanAndZoomPictureBox();
            this.panAndZoomPictureBox1 = new Emgu.CV.UI.PanAndZoomPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.panAndZoomPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panAndZoomPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panAndZoomPictureBox2
            // 
            this.panAndZoomPictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panAndZoomPictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panAndZoomPictureBox2.Location = new System.Drawing.Point(852, 0);
            this.panAndZoomPictureBox2.Name = "panAndZoomPictureBox2";
            this.panAndZoomPictureBox2.Size = new System.Drawing.Size(888, 676);
            this.panAndZoomPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.panAndZoomPictureBox2.TabIndex = 2;
            this.panAndZoomPictureBox2.TabStop = false;
            // 
            // panAndZoomPictureBox1
            // 
            this.panAndZoomPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panAndZoomPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.panAndZoomPictureBox1.Name = "panAndZoomPictureBox1";
            this.panAndZoomPictureBox1.Size = new System.Drawing.Size(852, 676);
            this.panAndZoomPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.panAndZoomPictureBox1.TabIndex = 3;
            this.panAndZoomPictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1740, 676);
            this.Controls.Add(this.panAndZoomPictureBox1);
            this.Controls.Add(this.panAndZoomPictureBox2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.panAndZoomPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panAndZoomPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Emgu.CV.UI.PanAndZoomPictureBox panAndZoomPictureBox2;
        private Emgu.CV.UI.PanAndZoomPictureBox panAndZoomPictureBox1;
    }
}

