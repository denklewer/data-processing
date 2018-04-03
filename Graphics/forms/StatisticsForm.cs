using Graphics.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Graphics
{
    public partial class StatisticsForm : Form
    {
        public Chart chart;
        RandomGenerator customGenerator = new RandomGenerator();     


        public StatisticsForm(Chart chart, string functionName)
        {
            InitializeComponent();
            this.chart = chart;
            
            Series series = chart.Series.FindByName(functionName);

            lbMean.Text = Statistics.ExpectedValue(series.Points).ToString();
            lbMeanSquare.Text = Statistics.MeanSquare(series.Points).ToString();
            lbMeanSquareError.Text = Statistics.MeanSquareError(series.Points).ToString();
            lbVariance.Text = Statistics.Variance(series.Points).ToString();
            lbStandartDeviation.Text = Statistics.StandartDeviation(series.Points).ToString();
            lbCentralMoment3.Text = Statistics.CentralMoment(series.Points, 3).ToString();
            lbCentralMoment4.Text = Statistics.CentralMoment(series.Points, 4).ToString();
            Chart randomChart = new Chart();
            DrawRandomChart(randomChart, functionName);
            DrawAutocorrelationChart(chartAutoCorrelation, functionName, series.Points.Count);
            DrawCrossCorrelationChart(chartCrossCorelation, randomChart, functionName, series.Points.Count);

            lbSkewness.Text = Statistics.Skewness(series.Points).ToString();
            lbKurtosis.Text = Statistics.Kurtosis(series.Points).ToString();


            double[] y = Statistics.Density(series.Points, 30);
            DrawDensity(y, functionName);

            lbIsStatic.Text = Statistics.isStatic(series.Points).ToString();
         

        }

        public void DrawDensity(double[] y,string functionName)
        {                                                                                       
            chartDensity.Series.Clear();
            Series series = chartDensity.Series.Add(functionName);
            series.ChartType = SeriesChartType.Column;


            for (int i = 0; i < y.Length; i++)
            {
                series.Points.AddY(y[i]);

            }

        }


        public void DrawRandomChart(Chart RandChart, string functionName) {
            double[] x = chart.Series.FindByName(functionName).Points.Select(item => item.XValue).ToArray<double>();
            double left = x.Min();
            double right = x.Max();
            double step = x[1]-x[0];
            int count = x.Length;

        

            for (int i = 0; i < count; i++)
            {
                x[i] = left + i * step;
            }
            Draw6(x, RandChart, functionName);

        }



        public void DrawAutocorrelationChart(Chart AutoChart, string functionName, int N)
        {
            int[] x = new int[N];
            
        
      
            for (int i = 0; i < N; i++)
            {
                x[i] = i ;
            }
            DrawAutoCorrelation(x, AutoChart, chart.Series.FindByName(functionName).Points, functionName);

        }


        public void DrawCrossCorrelationChart(Chart CrossChart,Chart RandChart, string functionName, int N)
        {
            int[] x = new int[N - 1];



            for (int i = 0; i < N - 1; i++)
            {
                x[i] = i + 1;
            }
            DrawCrossCorrelation(x, CrossChart, chart.Series.FindByName(functionName).Points,
                                         RandChart.Series.FindByName(functionName).Points, functionName);

        }
        private double Fun6(double x)
        {

            double d = customGenerator.GenerateDouble();
            // d = 0.5 - rnd.NextDouble();

            return d;
        }



        private void Draw6(double[] x, Chart chart, string functionName)
        {
            /*double a = Double.Parse(tbA3.Text);
            double b = Double.Parse(tbB3.Text);*/

            chart.Series.Clear();
            Series series = chart.Series.Add(functionName);
            series.ChartType = SeriesChartType.Spline;
            double[] y = new double[x.Length];


            for (int i = 0; i < x.Length; i++)
            {
                if (!Double.IsInfinity(Fun6(x[i])) && !Double.IsNaN(Fun6(x[i])))
                    series.Points.AddXY(x[i], Fun6(x[i]));

            }
        }

        private void DrawAutoCorrelation(int[] x, Chart chart, DataPointCollection arr, string functionName)
        {
            /*double a = Double.Parse(tbA3.Text);
            double b = Double.Parse(tbB3.Text);*/
            chart.Series.Clear();
            Series series = chart.Series.Add(functionName);
            series.ChartType = SeriesChartType.Spline;
            double[] y = new double[x.Length];


            for (int i = 0; i < x.Length; i++)
            {
                    series.Points.AddXY(x[i], Statistics.Autocorrelation(arr,x[i]));
            }
        }

        private void DrawCrossCorrelation(int[] x, Chart chart, DataPointCollection arr1, DataPointCollection arr2, string functionName)
        {
            /*double a = Double.Parse(tbA3.Text);
            double b = Double.Parse(tbB3.Text);*/

            chart.Series.Clear();
            Series series = chart.Series.Add(functionName);
            series.ChartType = SeriesChartType.Spline;
            double[] y = new double[x.Length];


            for (int i = 0; i < x.Length; i++)
            {
                series.Points.AddXY(x[i], Statistics.Crosscorrelation(arr1,arr2, x[i]));
            }
        }


        public StatisticsForm()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbCentralMoment_Click(object sender, EventArgs e)
        {

        }

        private void lbMeanSquare_Click(object sender, EventArgs e)
        {

        }

        private void chartAutoCorrelation_Click(object sender, EventArgs e)
        {

        }
    }
}
