namespace TrafficSignRecognition
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
            this.loadImageBtn = new System.Windows.Forms.Button();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.apertureLbl = new System.Windows.Forms.Label();
            this.thresh2Lbl = new System.Windows.Forms.Label();
            this.thresh1Lbl = new System.Windows.Forms.Label();
            this.apertureNumeric = new System.Windows.Forms.NumericUpDown();
            this.thresh2Numeric = new System.Windows.Forms.NumericUpDown();
            this.thresh1Numeric = new System.Windows.Forms.NumericUpDown();
            this.cannyBtn = new System.Windows.Forms.Button();
            this.guassianKernelLbl = new System.Windows.Forms.Label();
            this.guassianKernelNumeric = new System.Windows.Forms.NumericUpDown();
            this.gaussianBtn = new System.Windows.Forms.Button();
            this.graScaleBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.apertureNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresh2Numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresh1Numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guassianKernelNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // loadImageBtn
            // 
            this.loadImageBtn.Location = new System.Drawing.Point(643, 545);
            this.loadImageBtn.Name = "loadImageBtn";
            this.loadImageBtn.Size = new System.Drawing.Size(209, 36);
            this.loadImageBtn.TabIndex = 0;
            this.loadImageBtn.Text = "Open image";
            this.loadImageBtn.UseVisualStyleBackColor = true;
            this.loadImageBtn.Click += new System.EventHandler(this.loadImageBtn_Click);
            // 
            // imageBox
            // 
            this.imageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox.Location = new System.Drawing.Point(19, 15);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(397, 344);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox.TabIndex = 1;
            this.imageBox.TabStop = false;
            this.imageBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.imageBox.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.imageBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove_1);
            this.imageBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            this.imageBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseWheel);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.apertureLbl);
            this.panel1.Controls.Add(this.thresh2Lbl);
            this.panel1.Controls.Add(this.thresh1Lbl);
            this.panel1.Controls.Add(this.apertureNumeric);
            this.panel1.Controls.Add(this.thresh2Numeric);
            this.panel1.Controls.Add(this.thresh1Numeric);
            this.panel1.Controls.Add(this.cannyBtn);
            this.panel1.Controls.Add(this.guassianKernelLbl);
            this.panel1.Controls.Add(this.guassianKernelNumeric);
            this.panel1.Controls.Add(this.gaussianBtn);
            this.panel1.Controls.Add(this.graScaleBtn);
            this.panel1.Controls.Add(this.imageBox);
            this.panel1.Location = new System.Drawing.Point(33, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(819, 507);
            this.panel1.TabIndex = 2;
            // 
            // apertureLbl
            // 
            this.apertureLbl.AutoSize = true;
            this.apertureLbl.Location = new System.Drawing.Point(608, 110);
            this.apertureLbl.Name = "apertureLbl";
            this.apertureLbl.Size = new System.Drawing.Size(50, 13);
            this.apertureLbl.TabIndex = 12;
            this.apertureLbl.Text = "Aperture ";
            // 
            // thresh2Lbl
            // 
            this.thresh2Lbl.AutoSize = true;
            this.thresh2Lbl.Location = new System.Drawing.Point(516, 110);
            this.thresh2Lbl.Name = "thresh2Lbl";
            this.thresh2Lbl.Size = new System.Drawing.Size(60, 13);
            this.thresh2Lbl.TabIndex = 11;
            this.thresh2Lbl.Text = "Threshold2";
            // 
            // thresh1Lbl
            // 
            this.thresh1Lbl.AutoSize = true;
            this.thresh1Lbl.Location = new System.Drawing.Point(439, 110);
            this.thresh1Lbl.Name = "thresh1Lbl";
            this.thresh1Lbl.Size = new System.Drawing.Size(60, 13);
            this.thresh1Lbl.TabIndex = 10;
            this.thresh1Lbl.Text = "Threshold1";
            // 
            // apertureNumeric
            // 
            this.apertureNumeric.Location = new System.Drawing.Point(610, 137);
            this.apertureNumeric.Name = "apertureNumeric";
            this.apertureNumeric.Size = new System.Drawing.Size(61, 20);
            this.apertureNumeric.TabIndex = 9;
            // 
            // thresh2Numeric
            // 
            this.thresh2Numeric.DecimalPlaces = 2;
            this.thresh2Numeric.Location = new System.Drawing.Point(519, 137);
            this.thresh2Numeric.Name = "thresh2Numeric";
            this.thresh2Numeric.Size = new System.Drawing.Size(72, 20);
            this.thresh2Numeric.TabIndex = 8;
            // 
            // thresh1Numeric
            // 
            this.thresh1Numeric.DecimalPlaces = 2;
            this.thresh1Numeric.Location = new System.Drawing.Point(437, 137);
            this.thresh1Numeric.Name = "thresh1Numeric";
            this.thresh1Numeric.Size = new System.Drawing.Size(62, 20);
            this.thresh1Numeric.TabIndex = 7;
            // 
            // cannyBtn
            // 
            this.cannyBtn.Location = new System.Drawing.Point(699, 137);
            this.cannyBtn.Name = "cannyBtn";
            this.cannyBtn.Size = new System.Drawing.Size(104, 23);
            this.cannyBtn.TabIndex = 6;
            this.cannyBtn.Text = "Canny";
            this.cannyBtn.UseVisualStyleBackColor = true;
            this.cannyBtn.Click += new System.EventHandler(this.cannyBtn_Click);
            // 
            // guassianKernelLbl
            // 
            this.guassianKernelLbl.AutoSize = true;
            this.guassianKernelLbl.Location = new System.Drawing.Point(551, 62);
            this.guassianKernelLbl.Name = "guassianKernelLbl";
            this.guassianKernelLbl.Size = new System.Drawing.Size(40, 13);
            this.guassianKernelLbl.TabIndex = 5;
            this.guassianKernelLbl.Text = "Kernel:";
            // 
            // guassianKernelNumeric
            // 
            this.guassianKernelNumeric.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.guassianKernelNumeric.Location = new System.Drawing.Point(610, 60);
            this.guassianKernelNumeric.Name = "guassianKernelNumeric";
            this.guassianKernelNumeric.Size = new System.Drawing.Size(48, 20);
            this.guassianKernelNumeric.TabIndex = 4;
            // 
            // gaussianBtn
            // 
            this.gaussianBtn.Location = new System.Drawing.Point(699, 57);
            this.gaussianBtn.Name = "gaussianBtn";
            this.gaussianBtn.Size = new System.Drawing.Size(104, 23);
            this.gaussianBtn.TabIndex = 3;
            this.gaussianBtn.Text = "Gaussian Filter";
            this.gaussianBtn.UseVisualStyleBackColor = true;
            this.gaussianBtn.Click += new System.EventHandler(this.gaussianBtn_Click);
            // 
            // graScaleBtn
            // 
            this.graScaleBtn.Location = new System.Drawing.Point(699, 15);
            this.graScaleBtn.Name = "graScaleBtn";
            this.graScaleBtn.Size = new System.Drawing.Size(104, 23);
            this.graScaleBtn.TabIndex = 2;
            this.graScaleBtn.Text = "Gray Scale";
            this.graScaleBtn.UseVisualStyleBackColor = true;
            this.graScaleBtn.Click += new System.EventHandler(this.graScaleBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(508, 552);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(75, 23);
            this.resetBtn.TabIndex = 3;
            this.resetBtn.Text = "Reset Image";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 593);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.loadImageBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.apertureNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresh2Numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresh1Numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guassianKernelNumeric)).EndInit();
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.Button loadImageBtn;
        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button graScaleBtn;
        private System.Windows.Forms.Button gaussianBtn;
        private System.Windows.Forms.Label guassianKernelLbl;
        private System.Windows.Forms.NumericUpDown guassianKernelNumeric;
        private System.Windows.Forms.Button cannyBtn;
        private System.Windows.Forms.Label apertureLbl;
        private System.Windows.Forms.Label thresh2Lbl;
        private System.Windows.Forms.Label thresh1Lbl;
        private System.Windows.Forms.NumericUpDown apertureNumeric;
        private System.Windows.Forms.NumericUpDown thresh2Numeric;
        private System.Windows.Forms.NumericUpDown thresh1Numeric;
        private System.Windows.Forms.Button resetBtn;
    }
}

