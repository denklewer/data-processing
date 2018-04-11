namespace ImageProcessing
{
    partial class ImageProcessor
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbFile = new System.Windows.Forms.TextBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btAuxFile = new System.Windows.Forms.Button();
            this.tbAuxFile = new System.Windows.Forms.TextBox();
            this.btWrite = new System.Windows.Forms.Button();
            this.panelTransformParams = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btHist = new System.Windows.Forms.Button();
            this.btStatistics = new System.Windows.Forms.Button();
            this.btDraw = new System.Windows.Forms.Button();
            this.btTransform = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.btAddArea = new System.Windows.Forms.Button();
            this.cbArea = new System.Windows.Forms.ComboBox();
            this.btDeleteArea = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTransform = new System.Windows.Forms.ComboBox();
            this.lbTransform = new System.Windows.Forms.Label();
            this.lbLeft = new System.Windows.Forms.Label();
            this.lbRight = new System.Windows.Forms.Label();
            this.lbStep = new System.Windows.Forms.Label();
            this.tbStep = new System.Windows.Forms.TextBox();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tableLayOut = new System.Windows.Forms.TableLayoutPanel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tableLayOut.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbFile
            // 
            this.tbFile.Location = new System.Drawing.Point(165, 38);
            this.tbFile.Name = "tbFile";
            this.tbFile.Size = new System.Drawing.Size(138, 22);
            this.tbFile.TabIndex = 36;
            this.tbFile.Text = "D:\\php.dat";
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(165, 64);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(138, 31);
            this.btnFile.TabIndex = 35;
            this.btnFile.Text = "Open File";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(349, 583);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btAuxFile);
            this.panel1.Controls.Add(this.tbAuxFile);
            this.panel1.Controls.Add(this.btWrite);
            this.panel1.Controls.Add(this.btnFile);
            this.panel1.Controls.Add(this.tbFile);
            this.panel1.Controls.Add(this.panelTransformParams);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btAddArea);
            this.panel1.Controls.Add(this.cbArea);
            this.panel1.Controls.Add(this.btDeleteArea);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbTransform);
            this.panel1.Controls.Add(this.lbTransform);
            this.panel1.Controls.Add(this.lbLeft);
            this.panel1.Controls.Add(this.lbRight);
            this.panel1.Controls.Add(this.lbStep);
            this.panel1.Controls.Add(this.tbStep);
            this.panel1.Controls.Add(this.tbHeight);
            this.panel1.Controls.Add(this.tbWidth);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(710, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 589);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 39;
            this.label1.Text = "AuxFile:";
            // 
            // btAuxFile
            // 
            this.btAuxFile.Location = new System.Drawing.Point(221, 100);
            this.btAuxFile.Name = "btAuxFile";
            this.btAuxFile.Size = new System.Drawing.Size(82, 31);
            this.btAuxFile.TabIndex = 38;
            this.btAuxFile.Text = "Open File";
            this.btAuxFile.UseVisualStyleBackColor = true;
            this.btAuxFile.Click += new System.EventHandler(this.btAuxFile_Click);
            // 
            // tbAuxFile
            // 
            this.tbAuxFile.Location = new System.Drawing.Point(77, 104);
            this.tbAuxFile.Name = "tbAuxFile";
            this.tbAuxFile.Size = new System.Drawing.Size(138, 22);
            this.tbAuxFile.TabIndex = 37;
            this.tbAuxFile.Text = "D:\\php.dat";
            // 
            // btWrite
            // 
            this.btWrite.Location = new System.Drawing.Point(165, 3);
            this.btWrite.Name = "btWrite";
            this.btWrite.Size = new System.Drawing.Size(138, 31);
            this.btWrite.TabIndex = 35;
            this.btWrite.Text = "WriteImage";
            this.btWrite.UseVisualStyleBackColor = true;
            this.btWrite.Click += new System.EventHandler(this.btWrite_Click);
            // 
            // panelTransformParams
            // 
            this.panelTransformParams.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panelTransformParams.AutoScroll = true;
            this.panelTransformParams.Location = new System.Drawing.Point(7, 432);
            this.panelTransformParams.Name = "panelTransformParams";
            this.panelTransformParams.Size = new System.Drawing.Size(296, 47);
            this.panelTransformParams.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btHist);
            this.panel2.Controls.Add(this.btStatistics);
            this.panel2.Controls.Add(this.btDraw);
            this.panel2.Controls.Add(this.btTransform);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 485);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(308, 104);
            this.panel2.TabIndex = 10;
            // 
            // btHist
            // 
            this.btHist.Location = new System.Drawing.Point(191, 0);
            this.btHist.Name = "btHist";
            this.btHist.Size = new System.Drawing.Size(112, 48);
            this.btHist.TabIndex = 12;
            this.btHist.Text = "Histogram";
            this.btHist.UseVisualStyleBackColor = true;
            this.btHist.Click += new System.EventHandler(this.btHist_Click);
            // 
            // btStatistics
            // 
            this.btStatistics.Location = new System.Drawing.Point(12, 3);
            this.btStatistics.Name = "btStatistics";
            this.btStatistics.Size = new System.Drawing.Size(112, 48);
            this.btStatistics.TabIndex = 11;
            this.btStatistics.Text = "Pivot";
            this.btStatistics.UseVisualStyleBackColor = true;
            this.btStatistics.Click += new System.EventHandler(this.btStatistics_Click);
            // 
            // btDraw
            // 
            this.btDraw.Location = new System.Drawing.Point(12, 57);
            this.btDraw.Name = "btDraw";
            this.btDraw.Size = new System.Drawing.Size(112, 42);
            this.btDraw.TabIndex = 13;
            this.btDraw.Text = "Draw";
            this.btDraw.UseVisualStyleBackColor = true;
            this.btDraw.Click += new System.EventHandler(this.btDraw_Click);
            // 
            // btTransform
            // 
            this.btTransform.Location = new System.Drawing.Point(191, 57);
            this.btTransform.Name = "btTransform";
            this.btTransform.Size = new System.Drawing.Size(112, 42);
            this.btTransform.TabIndex = 14;
            this.btTransform.Text = "Transform";
            this.btTransform.UseVisualStyleBackColor = true;
            this.btTransform.Click += new System.EventHandler(this.btTransform_Click_1);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(12, 200);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(291, 173);
            this.panel3.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(78, 412);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(184, 17);
            this.label9.TabIndex = 32;
            this.label9.Text = "Transformation parameters:";
            // 
            // btAddArea
            // 
            this.btAddArea.Location = new System.Drawing.Point(183, 137);
            this.btAddArea.Name = "btAddArea";
            this.btAddArea.Size = new System.Drawing.Size(57, 42);
            this.btAddArea.TabIndex = 6;
            this.btAddArea.Text = "Add";
            this.btAddArea.UseVisualStyleBackColor = true;
            this.btAddArea.Click += new System.EventHandler(this.btAddArea_Click);
            // 
            // cbArea
            // 
            this.cbArea.FormattingEnabled = true;
            this.cbArea.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cbArea.Location = new System.Drawing.Point(97, 145);
            this.cbArea.Name = "cbArea";
            this.cbArea.Size = new System.Drawing.Size(75, 24);
            this.cbArea.TabIndex = 5;
            this.cbArea.Text = "0";
            this.cbArea.SelectedIndexChanged += new System.EventHandler(this.cbArea_SelectedIndexChanged);
            // 
            // btDeleteArea
            // 
            this.btDeleteArea.Location = new System.Drawing.Point(246, 137);
            this.btDeleteArea.Name = "btDeleteArea";
            this.btDeleteArea.Size = new System.Drawing.Size(57, 42);
            this.btDeleteArea.TabIndex = 7;
            this.btDeleteArea.Text = "Delete";
            this.btDeleteArea.UseVisualStyleBackColor = true;
            this.btDeleteArea.Click += new System.EventHandler(this.btDeleteArea_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "picture:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(78, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Function parameters:";
            // 
            // cbTransform
            // 
            this.cbTransform.FormattingEnabled = true;
            this.cbTransform.Items.AddRange(new object[] {
            "ForwardFurie",
            "ReverseFurie",
            "Zoom",
            "ZoomInterpolation",
            "Negative",
            "Gamma-correction",
            "Logarithmic",
            "Piecewise-linear",
            "Equalization",
            "Reduction",
            "Recovery",
            "Recovery with noize",
            "Rotate",
            "CheckGrid",
            "CheckGridWithCrossCorrelation",
            "Gradient",
            "ConturLPF",
            "RemoveGrid",
            "Threshold",
            "LPF_Whole",
            "HPF_Whole",
            "Minus",
            "Laplassian"});
            this.cbTransform.Location = new System.Drawing.Point(97, 382);
            this.cbTransform.Name = "cbTransform";
            this.cbTransform.Size = new System.Drawing.Size(209, 24);
            this.cbTransform.TabIndex = 9;
            this.cbTransform.SelectedIndexChanged += new System.EventHandler(this.cbTransform_SelectedIndexChanged);
            // 
            // lbTransform
            // 
            this.lbTransform.AutoSize = true;
            this.lbTransform.Location = new System.Drawing.Point(9, 385);
            this.lbTransform.Name = "lbTransform";
            this.lbTransform.Size = new System.Drawing.Size(77, 17);
            this.lbTransform.TabIndex = 17;
            this.lbTransform.Text = "Transform:";
            // 
            // lbLeft
            // 
            this.lbLeft.AutoSize = true;
            this.lbLeft.Location = new System.Drawing.Point(9, 12);
            this.lbLeft.Name = "lbLeft";
            this.lbLeft.Size = new System.Drawing.Size(48, 17);
            this.lbLeft.TabIndex = 12;
            this.lbLeft.Text = "Width:";
            // 
            // lbRight
            // 
            this.lbRight.AutoSize = true;
            this.lbRight.Location = new System.Drawing.Point(4, 45);
            this.lbRight.Name = "lbRight";
            this.lbRight.Size = new System.Drawing.Size(53, 17);
            this.lbRight.TabIndex = 11;
            this.lbRight.Text = "Height:";
            // 
            // lbStep
            // 
            this.lbStep.AutoSize = true;
            this.lbStep.Location = new System.Drawing.Point(13, 71);
            this.lbStep.Name = "lbStep";
            this.lbStep.Size = new System.Drawing.Size(41, 17);
            this.lbStep.TabIndex = 10;
            this.lbStep.Text = "Step:";
            // 
            // tbStep
            // 
            this.tbStep.Location = new System.Drawing.Point(59, 68);
            this.tbStep.Name = "tbStep";
            this.tbStep.Size = new System.Drawing.Size(100, 22);
            this.tbStep.TabIndex = 3;
            this.tbStep.Text = "1";
            // 
            // tbHeight
            // 
            this.tbHeight.Location = new System.Drawing.Point(59, 40);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(100, 22);
            this.tbHeight.TabIndex = 2;
            this.tbHeight.Text = "10";
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(59, 12);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(100, 22);
            this.tbWidth.TabIndex = 1;
            this.tbWidth.Text = "-10";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(358, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(349, 583);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 38;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // tableLayOut
            // 
            this.tableLayOut.AutoScroll = true;
            this.tableLayOut.ColumnCount = 2;
            this.tableLayOut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayOut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayOut.Controls.Add(this.pictureBox2, 1, 0);
            this.tableLayOut.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayOut.Location = new System.Drawing.Point(0, 0);
            this.tableLayOut.Name = "tableLayOut";
            this.tableLayOut.RowCount = 1;
            this.tableLayOut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayOut.Size = new System.Drawing.Size(710, 589);
            this.tableLayOut.TabIndex = 39;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // ImageProcessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1018, 589);
            this.Controls.Add(this.tableLayOut);
            this.Controls.Add(this.panel1);
            this.Name = "ImageProcessor";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tableLayOut.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btWrite;
        private System.Windows.Forms.Panel panelTransformParams;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btStatistics;
        private System.Windows.Forms.Button btDraw;
        private System.Windows.Forms.Button btTransform;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btAddArea;
        private System.Windows.Forms.ComboBox cbArea;
        private System.Windows.Forms.Button btDeleteArea;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTransform;
        private System.Windows.Forms.Label lbTransform;
        private System.Windows.Forms.Label lbLeft;
        private System.Windows.Forms.Label lbRight;
        private System.Windows.Forms.Label lbStep;
        private System.Windows.Forms.TextBox tbStep;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.Button btHist;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayOut;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btAuxFile;
        private System.Windows.Forms.TextBox tbAuxFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}

