namespace Graphics.forms
{
    partial class Histogram
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartHist = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDensity = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartHist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDensity)).BeginInit();
            this.SuspendLayout();
            // 
            // chartHist
            // 
            chartArea1.Name = "ChartArea1";
            this.chartHist.ChartAreas.Add(chartArea1);
            this.chartHist.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.chartHist.Legends.Add(legend1);
            this.chartHist.Location = new System.Drawing.Point(0, 0);
            this.chartHist.Name = "chartHist";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartHist.Series.Add(series1);
            this.chartHist.Size = new System.Drawing.Size(836, 370);
            this.chartHist.TabIndex = 1;
            this.chartHist.Text = "Histogramm";
            title1.Name = "Title1";
            title1.Text = "Histogram";
            this.chartHist.Titles.Add(title1);
            // 
            // chartDensity
            // 
            chartArea2.Name = "ChartArea1";
            this.chartDensity.ChartAreas.Add(chartArea2);
            this.chartDensity.Dock = System.Windows.Forms.DockStyle.Top;
            legend2.Name = "Legend1";
            this.chartDensity.Legends.Add(legend2);
            this.chartDensity.Location = new System.Drawing.Point(0, 370);
            this.chartDensity.Name = "chartDensity";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartDensity.Series.Add(series2);
            this.chartDensity.Size = new System.Drawing.Size(836, 657);
            this.chartDensity.TabIndex = 1;
            this.chartDensity.Text = "Histogramm";
            title2.Name = "Title1";
            title2.Text = "Density";
            this.chartDensity.Titles.Add(title2);
            // 
            // Histogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(857, 433);
            this.Controls.Add(this.chartDensity);
            this.Controls.Add(this.chartHist);
            this.Name = "Histogram";
            this.Text = "Histogram";
            this.Load += new System.EventHandler(this.Histogram_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartHist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDensity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartHist;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDensity;
    }
}