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
            this.accumulatorCircleLbl = new System.Windows.Forms.Label();
            this.threshCircle1Lbl = new System.Windows.Forms.Label();
            this.accumulatorCircleNumeric = new System.Windows.Forms.NumericUpDown();
            this.threshCircle1Numeric = new System.Windows.Forms.NumericUpDown();
            this.circlesBtn = new System.Windows.Forms.Button();
            this.apertureLbl = new System.Windows.Forms.Label();
            this.threshCanny2Lbl = new System.Windows.Forms.Label();
            this.threshCanny1Lbl = new System.Windows.Forms.Label();
            this.apertureNumeric = new System.Windows.Forms.NumericUpDown();
            this.threshCanny2Numeric = new System.Windows.Forms.NumericUpDown();
            this.threshCanny1Numeric = new System.Windows.Forms.NumericUpDown();
            this.cannyBtn = new System.Windows.Forms.Button();
            this.guassianKernelLbl = new System.Windows.Forms.Label();
            this.guassianKernelNumeric = new System.Windows.Forms.NumericUpDown();
            this.gaussianBtn = new System.Windows.Forms.Button();
            this.graScaleBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.resolutionCricleNumeric = new System.Windows.Forms.NumericUpDown();
            this.minDistCircleNumeric = new System.Windows.Forms.NumericUpDown();
            this.minRadCircleNumeic = new System.Windows.Forms.NumericUpDown();
            this.resolutionCricleLbl = new System.Windows.Forms.Label();
            this.minDistCircleLbl = new System.Windows.Forms.Label();
            this.maxRadCirclNumeric = new System.Windows.Forms.NumericUpDown();
            this.minRadCircleLbl = new System.Windows.Forms.Label();
            this.maxRadCircleLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accumulatorCircleNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threshCircle1Numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.apertureNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threshCanny2Numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threshCanny1Numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guassianKernelNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionCricleNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minDistCircleNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minRadCircleNumeic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRadCirclNumeric)).BeginInit();
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
            this.panel1.Controls.Add(this.maxRadCircleLbl);
            this.panel1.Controls.Add(this.minRadCircleLbl);
            this.panel1.Controls.Add(this.maxRadCirclNumeric);
            this.panel1.Controls.Add(this.minDistCircleLbl);
            this.panel1.Controls.Add(this.resolutionCricleLbl);
            this.panel1.Controls.Add(this.minRadCircleNumeic);
            this.panel1.Controls.Add(this.minDistCircleNumeric);
            this.panel1.Controls.Add(this.resolutionCricleNumeric);
            this.panel1.Controls.Add(this.accumulatorCircleLbl);
            this.panel1.Controls.Add(this.threshCircle1Lbl);
            this.panel1.Controls.Add(this.accumulatorCircleNumeric);
            this.panel1.Controls.Add(this.threshCircle1Numeric);
            this.panel1.Controls.Add(this.circlesBtn);
            this.panel1.Controls.Add(this.apertureLbl);
            this.panel1.Controls.Add(this.threshCanny2Lbl);
            this.panel1.Controls.Add(this.threshCanny1Lbl);
            this.panel1.Controls.Add(this.apertureNumeric);
            this.panel1.Controls.Add(this.threshCanny2Numeric);
            this.panel1.Controls.Add(this.threshCanny1Numeric);
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
            // accumulatorCircleLbl
            // 
            this.accumulatorCircleLbl.AutoSize = true;
            this.accumulatorCircleLbl.Location = new System.Drawing.Point(514, 193);
            this.accumulatorCircleLbl.Name = "accumulatorCircleLbl";
            this.accumulatorCircleLbl.Size = new System.Drawing.Size(66, 13);
            this.accumulatorCircleLbl.TabIndex = 17;
            this.accumulatorCircleLbl.Text = "Accumulator";
            // 
            // threshCircle1Lbl
            // 
            this.threshCircle1Lbl.AutoSize = true;
            this.threshCircle1Lbl.Location = new System.Drawing.Point(434, 193);
            this.threshCircle1Lbl.Name = "threshCircle1Lbl";
            this.threshCircle1Lbl.Size = new System.Drawing.Size(74, 13);
            this.threshCircle1Lbl.TabIndex = 16;
            this.threshCircle1Lbl.Text = "ThresholdMax";
            // 
            // accumulatorCircleNumeric
            // 
            this.accumulatorCircleNumeric.DecimalPlaces = 2;
            this.accumulatorCircleNumeric.Location = new System.Drawing.Point(517, 220);
            this.accumulatorCircleNumeric.Name = "accumulatorCircleNumeric";
            this.accumulatorCircleNumeric.Size = new System.Drawing.Size(63, 20);
            this.accumulatorCircleNumeric.TabIndex = 15;
            // 
            // threshCircle1Numeric
            // 
            this.threshCircle1Numeric.DecimalPlaces = 2;
            this.threshCircle1Numeric.Location = new System.Drawing.Point(437, 220);
            this.threshCircle1Numeric.Name = "threshCircle1Numeric";
            this.threshCircle1Numeric.Size = new System.Drawing.Size(54, 20);
            this.threshCircle1Numeric.TabIndex = 14;
            // 
            // circlesBtn
            // 
            this.circlesBtn.Location = new System.Drawing.Point(699, 271);
            this.circlesBtn.Name = "circlesBtn";
            this.circlesBtn.Size = new System.Drawing.Size(104, 23);
            this.circlesBtn.TabIndex = 13;
            this.circlesBtn.Text = "FindCircles";
            this.circlesBtn.UseVisualStyleBackColor = true;
            this.circlesBtn.Click += new System.EventHandler(this.circlesBtn_Click);
            // 
            // apertureLbl
            // 
            this.apertureLbl.AutoSize = true;
            this.apertureLbl.Location = new System.Drawing.Point(565, 110);
            this.apertureLbl.Name = "apertureLbl";
            this.apertureLbl.Size = new System.Drawing.Size(50, 13);
            this.apertureLbl.TabIndex = 12;
            this.apertureLbl.Text = "Aperture ";
            // 
            // threshCanny2Lbl
            // 
            this.threshCanny2Lbl.AutoSize = true;
            this.threshCanny2Lbl.Location = new System.Drawing.Point(490, 110);
            this.threshCanny2Lbl.Name = "threshCanny2Lbl";
            this.threshCanny2Lbl.Size = new System.Drawing.Size(60, 13);
            this.threshCanny2Lbl.TabIndex = 11;
            this.threshCanny2Lbl.Text = "Threshold2";
            // 
            // threshCanny1Lbl
            // 
            this.threshCanny1Lbl.AutoSize = true;
            this.threshCanny1Lbl.Location = new System.Drawing.Point(422, 110);
            this.threshCanny1Lbl.Name = "threshCanny1Lbl";
            this.threshCanny1Lbl.Size = new System.Drawing.Size(60, 13);
            this.threshCanny1Lbl.TabIndex = 10;
            this.threshCanny1Lbl.Text = "Threshold1";
            // 
            // apertureNumeric
            // 
            this.apertureNumeric.Location = new System.Drawing.Point(568, 137);
            this.apertureNumeric.Name = "apertureNumeric";
            this.apertureNumeric.Size = new System.Drawing.Size(47, 20);
            this.apertureNumeric.TabIndex = 9;
            // 
            // threshCanny2Numeric
            // 
            this.threshCanny2Numeric.DecimalPlaces = 2;
            this.threshCanny2Numeric.Location = new System.Drawing.Point(493, 137);
            this.threshCanny2Numeric.Name = "threshCanny2Numeric";
            this.threshCanny2Numeric.Size = new System.Drawing.Size(57, 20);
            this.threshCanny2Numeric.TabIndex = 8;
            this.threshCanny2Numeric.ValueChanged += new System.EventHandler(this.threshCanny2Numeric_ValueChanged);
            // 
            // threshCanny1Numeric
            // 
            this.threshCanny1Numeric.DecimalPlaces = 2;
            this.threshCanny1Numeric.Location = new System.Drawing.Point(437, 137);
            this.threshCanny1Numeric.Name = "threshCanny1Numeric";
            this.threshCanny1Numeric.Size = new System.Drawing.Size(43, 20);
            this.threshCanny1Numeric.TabIndex = 7;
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
            // resolutionCricleNumeric
            // 
            this.resolutionCricleNumeric.DecimalPlaces = 2;
            this.resolutionCricleNumeric.Location = new System.Drawing.Point(606, 220);
            this.resolutionCricleNumeric.Name = "resolutionCricleNumeric";
            this.resolutionCricleNumeric.Size = new System.Drawing.Size(54, 20);
            this.resolutionCricleNumeric.TabIndex = 18;
            // 
            // minDistCircleNumeric
            // 
            this.minDistCircleNumeric.DecimalPlaces = 2;
            this.minDistCircleNumeric.Location = new System.Drawing.Point(678, 220);
            this.minDistCircleNumeric.Name = "minDistCircleNumeric";
            this.minDistCircleNumeric.Size = new System.Drawing.Size(55, 20);
            this.minDistCircleNumeric.TabIndex = 19;
            // 
            // minRadCircleNumeic
            // 
            this.minRadCircleNumeic.Location = new System.Drawing.Point(437, 272);
            this.minRadCircleNumeic.Name = "minRadCircleNumeic";
            this.minRadCircleNumeic.Size = new System.Drawing.Size(54, 20);
            this.minRadCircleNumeic.TabIndex = 20;
            // 
            // resolutionCricleLbl
            // 
            this.resolutionCricleLbl.AutoSize = true;
            this.resolutionCricleLbl.Location = new System.Drawing.Point(603, 193);
            this.resolutionCricleLbl.Name = "resolutionCricleLbl";
            this.resolutionCricleLbl.Size = new System.Drawing.Size(57, 13);
            this.resolutionCricleLbl.TabIndex = 21;
            this.resolutionCricleLbl.Text = "Resolution";
            // 
            // minDistCircleLbl
            // 
            this.minDistCircleLbl.AutoSize = true;
            this.minDistCircleLbl.Location = new System.Drawing.Point(674, 193);
            this.minDistCircleLbl.Name = "minDistCircleLbl";
            this.minDistCircleLbl.Size = new System.Drawing.Size(59, 13);
            this.minDistCircleLbl.TabIndex = 22;
            this.minDistCircleLbl.Text = "MinDistans";
            // 
            // maxRadCirclNumeric
            // 
            this.maxRadCirclNumeric.Location = new System.Drawing.Point(517, 271);
            this.maxRadCirclNumeric.Name = "maxRadCirclNumeric";
            this.maxRadCirclNumeric.Size = new System.Drawing.Size(45, 20);
            this.maxRadCirclNumeric.TabIndex = 23;
            // 
            // minRadCircleLbl
            // 
            this.minRadCircleLbl.AutoSize = true;
            this.minRadCircleLbl.Location = new System.Drawing.Point(437, 253);
            this.minRadCircleLbl.Name = "minRadCircleLbl";
            this.minRadCircleLbl.Size = new System.Drawing.Size(31, 13);
            this.minRadCircleLbl.TabIndex = 24;
            this.minRadCircleLbl.Text = "minR";
            // 
            // maxRadCircleLbl
            // 
            this.maxRadCircleLbl.AutoSize = true;
            this.maxRadCircleLbl.Location = new System.Drawing.Point(517, 252);
            this.maxRadCircleLbl.Name = "maxRadCircleLbl";
            this.maxRadCircleLbl.Size = new System.Drawing.Size(34, 13);
            this.maxRadCircleLbl.TabIndex = 25;
            this.maxRadCircleLbl.Text = "maxR";
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
            ((System.ComponentModel.ISupportInitialize)(this.accumulatorCircleNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threshCircle1Numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.apertureNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threshCanny2Numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threshCanny1Numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guassianKernelNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionCricleNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minDistCircleNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minRadCircleNumeic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRadCirclNumeric)).EndInit();
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
        private System.Windows.Forms.Label threshCanny2Lbl;
        private System.Windows.Forms.Label threshCanny1Lbl;
        private System.Windows.Forms.NumericUpDown apertureNumeric;
        private System.Windows.Forms.NumericUpDown threshCanny2Numeric;
        private System.Windows.Forms.NumericUpDown threshCanny1Numeric;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button circlesBtn;
        private System.Windows.Forms.Label accumulatorCircleLbl;
        private System.Windows.Forms.Label threshCircle1Lbl;
        private System.Windows.Forms.NumericUpDown accumulatorCircleNumeric;
        private System.Windows.Forms.NumericUpDown threshCircle1Numeric;
        private System.Windows.Forms.NumericUpDown minRadCircleNumeic;
        private System.Windows.Forms.NumericUpDown minDistCircleNumeric;
        private System.Windows.Forms.NumericUpDown resolutionCricleNumeric;
        private System.Windows.Forms.Label resolutionCricleLbl;
        private System.Windows.Forms.Label minDistCircleLbl;
        private System.Windows.Forms.Label maxRadCircleLbl;
        private System.Windows.Forms.Label minRadCircleLbl;
        private System.Windows.Forms.NumericUpDown maxRadCirclNumeric;
    }
}

