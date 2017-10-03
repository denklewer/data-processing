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
    public partial class Form1 : Form
    {
        const string FUNCTION_NAME = "f(x)";
        const int N = 1000;
        Random rnd = new Random(59);
        RandomGenerator customGenerator = new RandomGenerator();

      
  
        public Form1()
        {
            InitializeComponent();

            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.Crossing = 0;
            chart1.ChartAreas[0].AxisY.Crossing = 0;

            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].CursorX.AutoScroll = true;
            chart1.ChartAreas[0].CursorY.AutoScroll = true;
            chart1.MouseWheel += chData_MouseWheel;

            chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisX.Crossing = 0;
            chart2.ChartAreas[0].AxisY.Crossing = 0;

            chart2.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart2.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart2.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart2.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart2.ChartAreas[0].CursorX.AutoScroll = true;
            chart2.ChartAreas[0].CursorY.AutoScroll = true;
            chart2.MouseWheel += chData_MouseWheel;

            chart3.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart3.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart3.ChartAreas[0].AxisX.Crossing = 0;
            chart3.ChartAreas[0].AxisY.Crossing = 0;

            chart3.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart3.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart3.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart3.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart3.ChartAreas[0].CursorX.AutoScroll = true;
            chart3.ChartAreas[0].CursorY.AutoScroll = true;
            chart3.MouseWheel += chData_MouseWheel;

            chart4.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart4.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart4.ChartAreas[0].AxisX.Crossing = 0;
            chart4.ChartAreas[0].AxisY.Crossing = 0;

            chart4.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart4.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart4.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart4.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart4.ChartAreas[0].CursorX.AutoScroll = true;
            chart4.ChartAreas[0].CursorY.AutoScroll = true;
            chart4.MouseWheel += chData_MouseWheel;


            chart5.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart5.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart5.ChartAreas[0].AxisX.Crossing = 0;
            chart5.ChartAreas[0].AxisY.Crossing = 0;

            chart5.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart5.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart5.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart5.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart5.ChartAreas[0].CursorX.AutoScroll = true;
            chart5.ChartAreas[0].CursorY.AutoScroll = true;
            chart5.MouseWheel += chData_MouseWheel;

            chartCombined.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartCombined.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartCombined.ChartAreas[0].AxisX.Crossing = 0;
            chartCombined.ChartAreas[0].AxisY.Crossing = 0;

            chartCombined.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chartCombined.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chartCombined.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chartCombined.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chartCombined.ChartAreas[0].CursorX.AutoScroll = true;
            chartCombined.ChartAreas[0].CursorY.AutoScroll = true;
            chartCombined.MouseWheel += chData_MouseWheel;





        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }


        private double Fun1(double x, double a , double b) {
             return (a * x + b);
           // return 5;
        }


        private double Fun2(double x, double a, double b, double c)
        {
            return (a * Math.Pow(x,2) + b * x + c);
        }
        private double Fun3(double x, double a, double b)
        {
            return b* Math.Exp(-a*x);
        }

        private double Fun4(double x, double a, double b)
        {
            return b * Math.Log(a*x);
        }
        /// <summary>
        ///  Случайная функция
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private double Fun6(double x) {
         
            double d =  customGenerator.GenerateDouble();
           // d = 0.5 - rnd.NextDouble();
        
            return d;
        }

        private double Fun5(double x)
        {

            double d;
             d = 0.5 - rnd.NextDouble();

            return d;
        }



        private double Fun7Combined(double x) {
            if (x < 0)
            {
                return (2 * x);
            }
            else if (x <= 1)
            {
                return (Math.Pow(x, 2));
            }
            else {
                return Math.Log(x) + 1;
            }

            

        }
        private void Draw1(double[] x, Chart chart) {
            double a = Double.Parse(tbA.Text);
            double b = Double.Parse(tbB.Text);
            chart.Series.Clear();


            Series series = chart.Series.Add(FUNCTION_NAME);
       

            series.ChartType = SeriesChartType.Line;
           
          
            for (int i = 0; i < x.Length; i++)
            {
                if (!Double.IsInfinity(Fun1(x[i], a, b)) && !Double.IsNaN(Fun1(x[i], a, b)))
                series.Points.AddXY(x[i], Fun1(x[i], a, b));
                
            }

     

        }


        private void Draw2(double[] x, Chart chart)
        {
            double a = Double.Parse(tbA2.Text);
            double b = Double.Parse(tbB2.Text);
            double c = Double.Parse(tbC2.Text);
            chart.Series.Clear();
            Series series = chart.Series.Add(FUNCTION_NAME);
            series.ChartType = SeriesChartType.Spline;

            for (int i = 0; i < x.Length; i++)
            {
                if (!Double.IsInfinity(Fun2(x[i], a, b,c)) && !Double.IsNaN(Fun2(x[i], a, b,c)))
                    series.Points.AddXY(x[i], Fun2(x[i], a, b,c));
            }
        }
        private void Draw3(double[] x, Chart chart)
        {
            double a = Double.Parse(tbA3.Text);
            double b = Double.Parse(tbB3.Text);
       
            chart.Series.Clear();
            Series series = chart.Series.Add(FUNCTION_NAME);
            series.ChartType = SeriesChartType.Spline;

            for (int i = 0; i < x.Length; i++)
            {
                if (!Double.IsInfinity(Fun3(x[i], a, b)) && !Double.IsNaN(Fun3(x[i], a, b)))
                    series.Points.AddXY(x[i], Fun3(x[i], a, b));
            }
        }
        private void Draw4(double[] x, Chart chart)
        {
            double a = Double.Parse(tbA3.Text);
            double b = Double.Parse(tbB3.Text);

            chart.Series.Clear();
            Series series = chart.Series.Add("f(x)");
            series.ChartType = SeriesChartType.Spline;

            for (int i = 0; i < x.Length; i++)
            {
                if (!Double.IsInfinity(Fun4(x[i], a, b)) && !Double.IsNaN(Fun4(x[i], a, b)))
                    series.Points.AddXY(x[i], Fun4(x[i], a, b));
            }
        }


        private void Draw5(double[] x, Chart chart)
        {
            /*double a = Double.Parse(tbA3.Text);
            double b = Double.Parse(tbB3.Text);*/

            chart.Series.Clear();
            Series series = chart.Series.Add(FUNCTION_NAME);
            series.ChartType = SeriesChartType.Spline;
   
            for (int i = 0; i < x.Length; i++)
            {
                if (!Double.IsInfinity(Fun5(x[i])) && !Double.IsNaN(Fun5(x[i])))
                    series.Points.AddXY(x[i], Fun5(x[i]));
         
            }
        }

        private void Draw(double[] x, Chart chart, Func<double,double> fun)
        {
            /*double a = Double.Parse(tbA3.Text);
            double b = Double.Parse(tbB3.Text);*/

            chart.Series.Clear();
            Series series = chart.Series.Add(FUNCTION_NAME);
            series.ChartType = SeriesChartType.Spline;

            for (int i = 0; i < x.Length; i++)
            {
                series.Points.AddXY(x[i], fun(x[i]));

            }
        }


        private void Draw6(double[] x, Chart chart)
        {
            /*double a = Double.Parse(tbA3.Text);
            double b = Double.Parse(tbB3.Text);*/

            chart.Series.Clear();
            Series series = chart.Series.Add(FUNCTION_NAME);
            series.ChartType = SeriesChartType.Spline;
            double[] y = new double[x.Length];
 

            for (int i = 0; i < x.Length; i++)
            {
                if (!Double.IsInfinity(Fun6(x[i])) && !Double.IsNaN(Fun6(x[i])))
                    series.Points.AddXY(x[i], Fun6(x[i]));

            }
        }


        private void Draw7(double[] x, Chart chart)
        {
            /*double a = Double.Parse(tbA3.Text);
            double b = Double.Parse(tbB3.Text);*/

            chart.Series.Clear();
            Series series = chart.Series.Add(FUNCTION_NAME);
            series.ChartType = SeriesChartType.Line;
            double[] y = new double[x.Length];


            for (int i = 0; i < x.Length; i++)
            {
                if (!Double.IsInfinity(Fun7Combined(x[i])) && !Double.IsNaN(Fun7Combined(x[i])))
                    series.Points.AddXY(x[i], Fun7Combined(x[i]));

            }
        }

        private void chData_MouseWheel(object sender, MouseEventArgs e)
        {
            Chart chart = (Chart)sender;


            if (ModifierKeys == Keys.Control)
            {
                try
                {

                    if (e.Delta < 0)
                    {
                        chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                        chart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
                    }

                    if (e.Delta > 0)
                    {
                        double xMin = chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                        double xMax = chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                        double yMin = chart.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                        double yMax = chart.ChartAreas[0].AxisY.ScaleView.ViewMaximum;
                     
                        double posXStart = chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                        double posXFinish = chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
                        double posYStart = chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
                        double posYFinish = chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

                        Math.Round(posXStart);
                        Math.Round(posXFinish);
                        Math.Round(posYFinish);
                        Math.Round(posYStart);
                        if (posXFinish - posXStart > 0.001 && posYFinish-posYStart > 0.001) {
                            chart.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
                            chart.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish);
                        }

                 
                        
                    }
                }
                catch (OverflowException) { }
            }
            
        }




        private void bt1_Click(object sender, EventArgs e)
        {


            double[] x = new double[1000];
            double left = 0;
            double right = 1000;
            double step = 1;
            int count = N;

            try
            {
                double tmp = 0;
                tmp = Double.Parse(tbLeft1.Text);
                left = tmp;
                tmp = Double.Parse(tbRight1.Text);
                right = tmp;
                tmp = Double.Parse(tbStep1.Text);
                step = tmp;
                count = (int)((right - left) / step);
                x = new double[count];
            }
            catch (Exception ex) {
            }

            for (int i = 0; i < count; i++)
            {
                x[i] = left + i*step;
            }
            Draw1(x, chart1);
            

            // SplineChartExample(chart1);

        }

        private void chart1_MouseEnter(object sender, EventArgs e)
        {
            if (chart1.Focused) chart1.Parent.Focus();
        }

        private void chart1_MouseLeave(object sender, EventArgs e)
        {
            if (!chart1.Focused) chart1.Focus();
        }

        private void bt2_Click(object sender, EventArgs e)
        {
   

            double[] x = new double[1000];
            double left = 0;
            double right = 1000;
            double step = 1;
            int count = N;

            try
            {
                double tmp = 0;
                tmp = Double.Parse(tbLeft2.Text);
                left = tmp;
                tmp = Double.Parse(tbRight2.Text);
                right = tmp;
                tmp = Double.Parse(tbStep2.Text);
                step = tmp;
                count = (int)((right - left) / step);
                x = new double[count];
            }
            catch (Exception ex)
            {
            }

            for (int i = 0; i < count; i++)
            {
                x[i] = left + i * step;
            }
            Draw2(x, chart2);

            // SplineChartExample(chart1);

        }

   

        private void tbLeft2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bt3_Click(object sender, EventArgs e)
        {

            double[] x = new double[1000];
            double left = 0;
            double right = 1000;
            double step = 1;
            int count = N;

            try
            {
                double tmp = 0;
                tmp = Double.Parse(tbLeft3.Text);
                left = tmp;
                tmp = Double.Parse(tbRight3.Text);
                right = tmp;
                tmp = Double.Parse(tbStep3.Text);
                step = tmp;
                count = (int)((right - left) / step);
                x = new double[count];
            }
            catch (Exception ex)
            {
            }

            for (int i = 0; i < count; i++)
            {
                x[i] = left + i * step;
            }
            Draw3(x, chart3);

            // SplineChartExample(chart1);

        }

        private void bt4_Click(object sender, EventArgs e)
        {

            double[] x = new double[1000];
            double left = 0;
            double right = 1000;
            double step = 1;
            int count = N;

            try
            {
                double tmp = 0;
                tmp = Double.Parse(tbLeft4.Text);
                left = tmp;
                tmp = Double.Parse(tbRight4.Text);
                right = tmp;
                tmp = Double.Parse(tbStep4.Text);
                step = tmp;
                count = (int)((right - left) / step);
                x = new double[count];
            }
            catch (Exception ex)
            {
            }

            for (int i = 0; i < count; i++)
            {
                x[i] = left + i * step;
            }
            Draw5(x, chart4);

            // SplineChartExample(chart1);

        }

        private void bt5_Click(object sender, EventArgs e)
        {
            double[] x = new double[1000];
            double left = 0;
            double right = 1000;
            double step = 1;
            int count = N;

            try
            {
                double tmp = 0;
                tmp = Double.Parse(tbLeft5.Text);
                left = tmp;
                tmp = Double.Parse(tbRight5.Text);
                right = tmp;
                tmp = Double.Parse(tbStep5.Text);
                step = tmp;
                count = (int)((right - left) / step);
                x = new double[count];
            }
            catch (Exception ex)
            {
            }

            for (int i = 0; i < count; i++)
            {
                x[i] = left + i * step;
            }
            Draw6(x, chart5);

            // SplineChartExample(chart1);

        }

        private void btStatistic_Click(object sender, EventArgs e)
        {
            StatisticsForm statisticsForm = new StatisticsForm(chart1, FUNCTION_NAME);
            statisticsForm.Show();
        }

        private void btStatistic2_Click(object sender, EventArgs e)
        {
            StatisticsForm statisticsForm = new StatisticsForm(chart2, FUNCTION_NAME);
            statisticsForm.Show();
        }

        private void btStatistic5_Click(object sender, EventArgs e)
        {

            StatisticsForm statisticsForm = new StatisticsForm(chart5, FUNCTION_NAME);
            statisticsForm.Show();
        }

        private void btStatistic4_Click(object sender, EventArgs e)
        {

            StatisticsForm statisticsForm = new StatisticsForm(chart4, FUNCTION_NAME);
            statisticsForm.Show();
        }

        private void btStatistic3_Click(object sender, EventArgs e)
        {

            StatisticsForm statisticsForm = new StatisticsForm(chart3, FUNCTION_NAME);
            statisticsForm.Show();
        }

        private void tbLeft3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btStatistic6_Click(object sender, EventArgs e)
        {
            StatisticsForm statisticsForm = new StatisticsForm(chartCombined, FUNCTION_NAME);
            statisticsForm.Show();

        }

        private void bt6_Click(object sender, EventArgs e)
        {

            double[] x = new double[1000];
            double left = 0;
            double right = 1000;
            double step = 1;
            int count = N;

            try
            {
                double tmp = 0;
                tmp = Double.Parse(tbLeft6.Text);
                left = tmp;
                tmp = Double.Parse(tbRight6.Text);
                right = tmp;
                tmp = Double.Parse(tbStep6.Text);
                step = tmp;
                count = (int)((right - left) / step);
                x = new double[count];
            }
            catch (Exception ex)
            {
            }

            for (int i = 0; i < count; i++)
            {
                x[i] = left + i * step;
            }
            Draw7(x, chartCombined);

        }
    }
}
