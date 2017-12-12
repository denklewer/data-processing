namespace Graphics
{
    partial class MainWindow
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.panelTransformParams = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btStatistics = new System.Windows.Forms.Button();
            this.btDraw = new System.Windows.Forms.Button();
            this.btTransform = new System.Windows.Forms.Button();
            this.panelFunctionParams = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.btAddArea = new System.Windows.Forms.Button();
            this.cbArea = new System.Windows.Forms.ComboBox();
            this.btDeleteArea = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTransform = new System.Windows.Forms.ComboBox();
            this.lbTransform = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFunction = new System.Windows.Forms.ComboBox();
            this.lbLeft = new System.Windows.Forms.Label();
            this.lbRight = new System.Windows.Forms.Label();
            this.lbStep = new System.Windows.Forms.Label();
            this.tbStep = new System.Windows.Forms.TextBox();
            this.tbRight = new System.Windows.Forms.TextBox();
            this.tbLeft = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btWrite = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.BorderlineColor = System.Drawing.Color.Black;
            this.chart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.AxisX.LabelStyle.IsStaggered = true;
            chartArea2.AxisX.MinorGrid.Enabled = true;
            chartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gray;
            chartArea2.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.AxisX.MinorTickMark.Enabled = true;
            chartArea2.AxisY.MinorGrid.Enabled = true;
            chartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.Gray;
            chartArea2.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.AxisY.MinorTickMark.Enabled = true;
            chartArea2.Name = "1";
            this.chart.ChartAreas.Add(chartArea2);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            series2.ChartArea = "1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "1";
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(735, 678);
            this.chart.TabIndex = 8;
            this.chart.Text = "y=ax+b";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title2.Name = "Title1";
            title2.Text = "Graphics";
            this.chart.Titles.Add(title2);
            this.chart.MouseEnter += new System.EventHandler(this.chart_MouseEnter);
            this.chart.MouseLeave += new System.EventHandler(this.chart1_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btWrite);
            this.panel1.Controls.Add(this.tbFile);
            this.panel1.Controls.Add(this.btnFile);
            this.panel1.Controls.Add(this.panelTransformParams);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panelFunctionParams);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btAddArea);
            this.panel1.Controls.Add(this.cbArea);
            this.panel1.Controls.Add(this.btDeleteArea);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbTransform);
            this.panel1.Controls.Add(this.lbTransform);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbFunction);
            this.panel1.Controls.Add(this.lbLeft);
            this.panel1.Controls.Add(this.lbRight);
            this.panel1.Controls.Add(this.lbStep);
            this.panel1.Controls.Add(this.tbStep);
            this.panel1.Controls.Add(this.tbRight);
            this.panel1.Controls.Add(this.tbLeft);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(735, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 678);
            this.panel1.TabIndex = 9;
            // 
            // tbFile
            // 
            this.tbFile.Location = new System.Drawing.Point(165, 36);
            this.tbFile.Name = "tbFile";
            this.tbFile.Size = new System.Drawing.Size(138, 22);
            this.tbFile.TabIndex = 34;
            this.tbFile.Text = "D:\\php.dat";
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(165, 64);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(138, 31);
            this.btnFile.TabIndex = 33;
            this.btnFile.Text = "Open File";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // panelTransformParams
            // 
            this.panelTransformParams.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panelTransformParams.AutoScroll = true;
            this.panelTransformParams.Location = new System.Drawing.Point(0, 469);
            this.panelTransformParams.Name = "panelTransformParams";
            this.panelTransformParams.Size = new System.Drawing.Size(315, 102);
            this.panelTransformParams.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btStatistics);
            this.panel2.Controls.Add(this.btDraw);
            this.panel2.Controls.Add(this.btTransform);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 574);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(315, 104);
            this.panel2.TabIndex = 10;
            // 
            // btStatistics
            // 
            this.btStatistics.Location = new System.Drawing.Point(12, 3);
            this.btStatistics.Name = "btStatistics";
            this.btStatistics.Size = new System.Drawing.Size(291, 48);
            this.btStatistics.TabIndex = 13;
            this.btStatistics.Text = "Statistic";
            this.btStatistics.UseVisualStyleBackColor = true;
            this.btStatistics.Click += new System.EventHandler(this.btStatistics_Click);
            // 
            // btDraw
            // 
            this.btDraw.Location = new System.Drawing.Point(12, 57);
            this.btDraw.Name = "btDraw";
            this.btDraw.Size = new System.Drawing.Size(112, 42);
            this.btDraw.TabIndex = 3;
            this.btDraw.Text = "Draw";
            this.btDraw.UseVisualStyleBackColor = true;
            this.btDraw.Click += new System.EventHandler(this.btDraw_Click);
            // 
            // btTransform
            // 
            this.btTransform.Location = new System.Drawing.Point(191, 57);
            this.btTransform.Name = "btTransform";
            this.btTransform.Size = new System.Drawing.Size(112, 42);
            this.btTransform.TabIndex = 19;
            this.btTransform.Text = "Transform";
            this.btTransform.UseVisualStyleBackColor = true;
            this.btTransform.Click += new System.EventHandler(this.btTransform_Click);
            // 
            // panelFunctionParams
            // 
            this.panelFunctionParams.AutoScroll = true;
            this.panelFunctionParams.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelFunctionParams.Location = new System.Drawing.Point(12, 200);
            this.panelFunctionParams.Name = "panelFunctionParams";
            this.panelFunctionParams.Size = new System.Drawing.Size(291, 206);
            this.panelFunctionParams.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(56, 439);
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
            this.btAddArea.TabIndex = 25;
            this.btAddArea.Text = "Add";
            this.btAddArea.UseVisualStyleBackColor = true;
            this.btAddArea.Click += new System.EventHandler(this.btAddArea_Click);
            // 
            // cbArea
            // 
            this.cbArea.FormattingEnabled = true;
            this.cbArea.Items.AddRange(new object[] {
            "1"});
            this.cbArea.Location = new System.Drawing.Point(97, 145);
            this.cbArea.Name = "cbArea";
            this.cbArea.Size = new System.Drawing.Size(75, 24);
            this.cbArea.TabIndex = 24;
            this.cbArea.Text = "1";
            // 
            // btDeleteArea
            // 
            this.btDeleteArea.Location = new System.Drawing.Point(246, 137);
            this.btDeleteArea.Name = "btDeleteArea";
            this.btDeleteArea.Size = new System.Drawing.Size(57, 42);
            this.btDeleteArea.TabIndex = 23;
            this.btDeleteArea.Text = "Delete";
            this.btDeleteArea.UseVisualStyleBackColor = true;
            this.btDeleteArea.Click += new System.EventHandler(this.btDeleteArea_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "Chart Area:";
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
            "Fourier",
            "Spikes(F(x),M,Sigma)",
            "Shift(F(x),shift)",
            "RandomSpikes(x,spikes)",
            "ConvolutionWithHeartBeat(x,f0,alpha,hLeft,hRight,hStep)",
            "AddRandom",
            "AntiShift",
            "AntiSpike",
            "AntiRandom",
            "AntiTrend",
            "LPW",
            "HPF",
            "BPF",
            "BSF",
            "Multiply",
            "Cut(left_cut, right_cut)",
            "ConvolutionWithLpf(x,fcut,m,dt)",
            "ConvolutionWithHpf(x,fcut,m,dt)",
            "ConvolutionWithBpf(x,fcut1,fcut2,m,dt)",
            "ConvolutionWithBsf(x,fcut1,fcut2,m,dt)"});
            this.cbTransform.Location = new System.Drawing.Point(97, 412);
            this.cbTransform.Name = "cbTransform";
            this.cbTransform.Size = new System.Drawing.Size(209, 24);
            this.cbTransform.TabIndex = 18;
            this.cbTransform.SelectedIndexChanged += new System.EventHandler(this.cbTransform_SelectedIndexChanged);
            // 
            // lbTransform
            // 
            this.lbTransform.AutoSize = true;
            this.lbTransform.Location = new System.Drawing.Point(9, 415);
            this.lbTransform.Name = "lbTransform";
            this.lbTransform.Size = new System.Drawing.Size(77, 17);
            this.lbTransform.TabIndex = 17;
            this.lbTransform.Text = "Transform:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Function:";
            // 
            // cbFunction
            // 
            this.cbFunction.FormattingEnabled = true;
            this.cbFunction.Items.AddRange(new object[] {
            "ax+b",
            "ax^2+bx+c",
            "b*exp(-ax)",
            "RandomNative",
            "CustomRandom",
            "Combined",
            "Harmonic(A,f)",
            "PolyHarmonic (A1-3,f1-3)",
            "HeartBeat",
            "Random(a,b)"});
            this.cbFunction.Location = new System.Drawing.Point(97, 107);
            this.cbFunction.Name = "cbFunction";
            this.cbFunction.Size = new System.Drawing.Size(206, 24);
            this.cbFunction.TabIndex = 15;
            this.cbFunction.Tag = "";
            this.cbFunction.SelectedIndexChanged += new System.EventHandler(this.cbFunction_SelectedIndexChanged);
            // 
            // lbLeft
            // 
            this.lbLeft.AutoSize = true;
            this.lbLeft.Location = new System.Drawing.Point(18, 15);
            this.lbLeft.Name = "lbLeft";
            this.lbLeft.Size = new System.Drawing.Size(36, 17);
            this.lbLeft.TabIndex = 12;
            this.lbLeft.Text = "Left:";
            // 
            // lbRight
            // 
            this.lbRight.AutoSize = true;
            this.lbRight.Location = new System.Drawing.Point(12, 43);
            this.lbRight.Name = "lbRight";
            this.lbRight.Size = new System.Drawing.Size(45, 17);
            this.lbRight.TabIndex = 11;
            this.lbRight.Text = "Right:";
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
            this.tbStep.TabIndex = 9;
            this.tbStep.Text = "1";
            // 
            // tbRight
            // 
            this.tbRight.Location = new System.Drawing.Point(59, 40);
            this.tbRight.Name = "tbRight";
            this.tbRight.Size = new System.Drawing.Size(100, 22);
            this.tbRight.TabIndex = 8;
            this.tbRight.Text = "10";
            // 
            // tbLeft
            // 
            this.tbLeft.Location = new System.Drawing.Point(59, 12);
            this.tbLeft.Name = "tbLeft";
            this.tbLeft.Size = new System.Drawing.Size(100, 22);
            this.tbLeft.TabIndex = 7;
            this.tbLeft.Text = "-10";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btWrite
            // 
            this.btWrite.Enabled = false;
            this.btWrite.Location = new System.Drawing.Point(165, 3);
            this.btWrite.Name = "btWrite";
            this.btWrite.Size = new System.Drawing.Size(138, 31);
            this.btWrite.TabIndex = 35;
            this.btWrite.Text = "Write Wav";
            this.btWrite.UseVisualStyleBackColor = true;
            this.btWrite.Click += new System.EventHandler(this.btWrite_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 678);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.panel1);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btStatistics;
        private System.Windows.Forms.Label lbLeft;
        private System.Windows.Forms.Label lbRight;
        private System.Windows.Forms.Label lbStep;
        private System.Windows.Forms.TextBox tbStep;
        private System.Windows.Forms.TextBox tbRight;
        private System.Windows.Forms.TextBox tbLeft;
        private System.Windows.Forms.Button btDraw;
        private System.Windows.Forms.Button btTransform;
        private System.Windows.Forms.ComboBox cbTransform;
        private System.Windows.Forms.Label lbTransform;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFunction;
        private System.Windows.Forms.Button btDeleteArea;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btAddArea;
        private System.Windows.Forms.ComboBox cbArea;
        private System.Windows.Forms.Panel panelTransformParams;
        private System.Windows.Forms.Panel panelFunctionParams;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btWrite;
    }
}