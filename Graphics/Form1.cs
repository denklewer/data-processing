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


            chartHarm.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartHarm.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartHarm.ChartAreas[0].AxisX.Crossing = 0;
            chartHarm.ChartAreas[0].AxisY.Crossing = 0;

            chartHarm.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chartHarm.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chartHarm.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chartHarm.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chartHarm.ChartAreas[0].CursorX.AutoScroll = true;
            chartHarm.ChartAreas[0].CursorY.AutoScroll = true;
            chartHarm.MouseWheel += chData_MouseWheel;



            chartPolyHarm.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartPolyHarm.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartPolyHarm.ChartAreas[0].AxisX.Crossing = 0;
            chartPolyHarm.ChartAreas[0].AxisY.Crossing = 0;

            chartPolyHarm.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chartPolyHarm.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chartPolyHarm.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chartPolyHarm.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chartPolyHarm.ChartAreas[0].CursorX.AutoScroll = true;
            chartPolyHarm.ChartAreas[0].CursorY.AutoScroll = true;
            chartPolyHarm.MouseWheel += chData_MouseWheel;


            chartSpikes.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartSpikes.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartSpikes.ChartAreas[0].AxisX.Crossing = 0;
            chartSpikes.ChartAreas[0].AxisY.Crossing = 0;

            chartSpikes.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chartSpikes.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chartSpikes.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chartSpikes.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chartSpikes.ChartAreas[0].CursorX.AutoScroll = true;
            chartSpikes.ChartAreas[0].CursorY.AutoScroll = true;
            chartSpikes.MouseWheel += chData_MouseWheel;


            chartFurie.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartFurie.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartFurie.ChartAreas[0].AxisX.Crossing = 0;
            chartFurie.ChartAreas[0].AxisY.Crossing = 0;

            chartFurie.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chartFurie.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chartFurie.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chartFurie.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chartFurie.ChartAreas[0].CursorX.AutoScroll = true;
            chartFurie.ChartAreas[0].CursorY.AutoScroll = true;
            chartFurie.MouseWheel += chData_MouseWheel;



            chartHeartBeat.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartHeartBeat.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartHeartBeat.ChartAreas[0].AxisX.Crossing = 0;
            chartHeartBeat.ChartAreas[0].AxisY.Crossing = 0;

            chartHeartBeat.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chartHeartBeat.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chartHeartBeat.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chartHeartBeat.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chartHeartBeat.ChartAreas[0].CursorX.AutoScroll = true;
            chartHeartBeat.ChartAreas[0].CursorY.AutoScroll = true;
            chartHeartBeat.MouseWheel += chData_MouseWheel;



            chartTrendFurie.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartTrendFurie.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartTrendFurie.ChartAreas[0].AxisX.Crossing = 0;
            chartTrendFurie.ChartAreas[0].AxisY.Crossing = 0;

            chartTrendFurie.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chartTrendFurie.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chartTrendFurie.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chartTrendFurie.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chartTrendFurie.ChartAreas[0].CursorX.AutoScroll = true;
            chartTrendFurie.ChartAreas[0].CursorY.AutoScroll = true;
            chartTrendFurie.MouseWheel += chData_MouseWheel;






        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }



        private void Draw1(double[] x, Chart chart) {
            double a = Double.Parse(tbA.Text);
            double b = Double.Parse(tbB.Text);
            chart.Series.Clear();

            Series series = chart.Series.Add(FUNCTION_NAME);
       

            series.ChartType = SeriesChartType.Line;
           
          
            for (int i = 0; i < x.Length; i++)
            {
                if (!Double.IsInfinity(Functions.LinearFunction(x[i], a, b)) && !Double.IsNaN(Functions.LinearFunction(x[i], a, b)))
                series.Points.AddXY(x[i], Functions.LinearFunction(x[i], a, b));
                
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
                if (!Double.IsInfinity(Functions.Quadratic(x[i], a, b,c)) && !Double.IsNaN(Functions.Quadratic(x[i], a, b,c)))
                    series.Points.AddXY(x[i], Functions.Quadratic(x[i], a, b,c));
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
                if (!Double.IsInfinity(Functions.ExpFunction(x[i], a, b)) && !Double.IsNaN(Functions.ExpFunction(x[i], a, b)))
                    series.Points.AddXY(x[i], Functions.ExpFunction(x[i], a, b));
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
                if (!Double.IsInfinity(Functions.LogFunction(x[i], a, b)) && !Double.IsNaN(Functions.LogFunction(x[i], a, b)))
                    series.Points.AddXY(x[i], Functions.LogFunction(x[i], a, b));
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
                if (!Double.IsInfinity(Functions.RandomFunction(x[i])) && !Double.IsNaN(Functions.RandomFunction(x[i])))
                    series.Points.AddXY(x[i], Functions.RandomFunction(x[i]));
         
            }
        }

        private void Draw(double[] x, Chart chart, Func<double,double> fun)
        {
            /*double a = Double.Parse(tbA3.Text);
            double b = Double.Parse(tbB3.Text);*/

            chart.Series.Clear();
            Series series = chart.Series.Add(FUNCTION_NAME);
            series.ChartType = SeriesChartType.Spline;
            double funValue = 0;
            for (int i = 0; i < x.Length; i++)
            {
                funValue = fun(x[i]);
                if (!Double.IsInfinity(funValue) && !Double.IsNaN(funValue))
                    series.Points.AddXY(x[i], funValue);
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
                if (!Double.IsInfinity(Functions.CustomRandomFunction(x[i])) && !Double.IsNaN(Functions.CustomRandomFunction(x[i])))
                    series.Points.AddXY(x[i], Functions.CustomRandomFunction(x[i]));

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
                if (!Double.IsInfinity(Functions.CombinedFunction(x[i])) && !Double.IsNaN(Functions.CombinedFunction(x[i])))
                    series.Points.AddXY(x[i], Functions.CombinedFunction(x[i]));

            }
        }

        private void DrawHarm(double[] x, Chart chart)
        {
            double a = Double.Parse(tbA7.Text);
            double b = Double.Parse(tbB7.Text);
            chart.Series.Clear();
            Series series = chart.Series.Add("f(x)");
            series.ChartType = SeriesChartType.Spline;
            for (int i = 0; i < x.Length; i++)
            {
                if (!Double.IsInfinity(Functions.HarmonicFunction(x[i],a,b)) && !Double.IsNaN(Functions.HarmonicFunction(x[i],a,b)))
                    series.Points.AddXY(x[i], Functions.HarmonicFunction(x[i], a, b));
            }

        }

        private void DrawHeartBeat(double xDelta, int xCount, double hDelta, int hCount, Chart chart)
        {
            double f0 = Double.Parse(tbA12.Text);
            double alpha = Double.Parse(tbB12.Text);
            double spikes = Double.Parse(tbSpikes12.Text);
            chart.Series.Clear();
            Series series = chart.Series.Add("f(x)");
            series.ChartType = SeriesChartType.Spline;


            double[] h = new double[hCount];
            double[] x = new double[xCount];
            Func<double, double> hFun = (t => Math.Sin(2 * Math.PI * f0 *t ) * Math.Exp(-alpha * t));
            double dt = hDelta;
            for (int i = 0; i < h.Length; i++)
            {
                h[i] = hFun(i * dt);
            }   

            for (int i = (int)(x.Length / spikes); i < x.Length; i = i+(int)(x.Length/spikes)) {
                x[i] = 110 + rnd.Next(0, 20);
            }
            double[] res = Transformations.ConvolutionFunction(h, x);

            for (int i = 0; i < res.Length; i++)
            {
                if (!Double.IsInfinity(res[i]) && !Double.IsNaN(res[i]))
                    series.Points.AddXY(i, res[i]+1);
            }



        }



        private void DrawPolyHarmonic(double[] x, Chart chart)
        {
            double[] a = new double[3];
            double[] b = new double[3];

             a[0] = Double.Parse(tbA8_0.Text);
             b[0] = Double.Parse(tbB8_0.Text);
             a[1] = Double.Parse(tbA8_1.Text);
             b[1] = Double.Parse(tbB8_1.Text);
             a[2] = Double.Parse(tbA8_2.Text);
             b[2] = Double.Parse(tbB8_2.Text);

            chart.Series.Clear();
            Series series = chart.Series.Add("f(x)");
            series.ChartType = SeriesChartType.Spline;

            for (int i = 0; i < x.Length; i++)
            {
                if (!Double.IsInfinity(Functions.PolyHarmonicFunction(x[i], a, b)) && !Double.IsNaN(Functions.PolyHarmonicFunction(x[i], a, b)))
                    series.Points.AddXY(x[i], Functions.PolyHarmonicFunction(x[i], a, b));
            }
        }

        private void DrawSpikes(double[] x, Chart chart)
        {
            double m = Double.Parse(tbM9.Text);
            double sigma = Double.Parse(tbSigma9.Text);
            double[] y = new double[x.Length];

            chart.Series.Clear();
            Series series = chart.Series.Add("f(x)");
            series.ChartType = SeriesChartType.Line;
            for (int i = 0; i < y.Length; i++)
            {
                y[i] = Functions.HarmonicFunction(x[i], 100, 57);
            }
            y = Transformations.SpikesFunction(y, m, sigma);
            for (int i = 0; i < x.Length; i++)
            {
                if (!Double.IsInfinity(y[i]) && !Double.IsNaN(y[i]))    
                    series.Points.AddXY(x[i], y[i]);
            }
        }

        private void DrawShift(double[] x, Chart chart)
        {
            double m = Double.Parse(tbM11.Text);
            double sigma = Double.Parse(tbSigma11.Text);
            double shift = Double.Parse(tbShift.Text);
            double[] y = new double[x.Length];

            chart.Series.Clear();
            Series series = chart.Series.Add("f(x)");
            series.ChartType = SeriesChartType.Line;
            for (int i = 0; i < y.Length; i++)
            {
                y[i] = Functions.HarmonicFunction(x[i], 100, 57);
            }
            y = Transformations.ShiftFunction( y, shift);
            for (int i = 0; i < x.Length; i++)
            {
                if (!Double.IsInfinity(y[i]) && !Double.IsNaN(y[i]))
                    series.Points.AddXY(x[i], y[i]);
            }
        }


        private void DrawFurie(double[] x, Chart chart)
        {
           // double a = Double.Parse(tbA10.Text);
          //  double b = Double.Parse(tbB10.Text);
            double[] y = new double[x.Length];

            chart.Series.Clear();
            Series series = chart.Series.Add("f(x)");
            series.ChartType = SeriesChartType.Spline;

            double[] a = new double[3];
            double[] b = new double[3];

            a[0] = 100;
            b[0] = 57;
            a[1] =30;
            b[1] = 45;
            a[2] = 20;
            b[2] = 34;

            for (int i = 0; i < y.Length; i++)
            {
                y[i] = Functions.PolyHarmonicFunction(x[i], a, b);
            }
            y = Transformations.FurieFunction(y);

            double deltaT = x[1] - x[0];

            double Fgr = 1 / (2 * deltaT);

            double deltaF = Fgr / (x.Length / 2);
            double left = 0;
          
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = left + i * deltaF;

            }
            for (int i = 0; i < x.Length/2; i++)
            {
                if (!Double.IsInfinity(y[i]) && !Double.IsNaN(y[i]))
                    series.Points.AddXY(x[i], y[i]);
               
            }
          
        }

        private void DrawTrendFurie(double[] x, Chart chart)
        {
             double a = Double.Parse(tbA13.Text);
              double b = Double.Parse(tbB13.Text);
            double shift = Double.Parse(tbShift13.Text);
            double[] y = new double[x.Length];

            chart.Series.Clear();
            Series series = chart.Series.Add("Trend");
            series.ChartType = SeriesChartType.Spline;

           // double[] a = new double[3];
           // double[] b = new double[3];

      
           

            for (int i = 0; i < y.Length; i++)
            {
                y[i] = Functions.LinearFunction(x[i], a, b);
            }
            y = Transformations.FurieFunction(y);

            double deltaT = x[1] - x[0];

            double Fgr = 1 / (2 * deltaT);

            double deltaF = Fgr / (x.Length / 2);
            double left = 0;

            for (int i = 0; i < x.Length; i++)
            {
                x[i] = left + i * deltaF;

            }
            for (int i = 0; i < x.Length / 2; i++)
            {
                if (!Double.IsInfinity(y[i]) && !Double.IsNaN(y[i]))
                    series.Points.AddXY(x[i], y[i]);

            }

         
           
            Series series2 = chart.Series.Add("Shift harm");
            series2.ChartType = SeriesChartType.Spline;

            series2.Color = Color.Red;


            for (int i = 0; i < y.Length; i++)
            {
                y[i] = Functions.HarmonicFunction(x[i], 100, 67)+ shift ;
            }
          //  y = Functions.ShiftFunction(y, 0);
            y = Transformations.FurieFunction(y);


            for (int i = 0; i < x.Length / 2; i++)
            {
                if (!Double.IsInfinity(y[i]) && !Double.IsNaN(y[i]))
                    series2.Points.AddXY(x[i], y[i] );

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
            catch (Exception) {
                
      
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
            catch (Exception)
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
            catch (Exception)
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
            catch (Exception)
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
            catch (Exception)
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
            catch (Exception)
            {
            }

            for (int i = 0; i < count; i++)
            {
                x[i] = left + i * step;
            }
            Draw7(x, chartCombined);

        }

        private void bt7_Click(object sender, EventArgs e)
        {
                double[] x = new double[1000];
                double left = 0;
                double right = 100;
                double step = 0.001;
                int count = N;

                try
                {
                    double tmp = 0;
                    tmp = Double.Parse(tbLeft7.Text);
                    left = tmp;
                    tmp = Double.Parse(tbRight7.Text);
                    right = tmp;
                    tmp = Double.Parse(tbStep7.Text);
                    step = tmp;
                    count = (int)((right - left) / step);
                    x = new double[count];
                }
                catch (Exception)
                {
                }

                for (int i = 0; i < count; i++)
                {
                    x[i] = left + i * step;
                }
                DrawHarm(x, chartHarm);

                // SplineChartExample(chart1);

            
    
        }

        private void bt8_Click(object sender, EventArgs e)
        {
            double[] x = new double[1000];
            double left = 0;
            double right = 100;
            double step = 0.001;
            int count = N;

            try
            {
                double tmp = 0;
                tmp = Double.Parse(tbLeft8.Text);
                left = tmp;
                tmp = Double.Parse(tbRight8.Text);
                right = tmp;
                tmp = Double.Parse(tbStep8.Text);
                step = tmp;
                count = (int)((right - left) / step);
                x = new double[count];
            }
            catch (Exception)
            {
            }

            for (int i = 0; i < count; i++)
            {
                x[i] = left + i * step;
            }
            DrawPolyHarmonic(x, chartPolyHarm);

        }

        private void bt9_Click(object sender, EventArgs e)
        {
            double[] x = new double[1000];
            double left = 0;
            double right = 100;
            double step = 0.001;
            int count = N;

            try
            {
                double tmp = 0;
                tmp = Double.Parse(tbLeft9.Text);
                left = tmp;
                tmp = Double.Parse(tbRight9.Text);
                right = tmp;
                tmp = Double.Parse(tbStep9.Text);
                step = tmp;
                count = (int)((right - left) / step);
                x = new double[count];
            }
            catch (Exception)
            {
            }

            for (int i = 0; i < count; i++)
            {
                x[i] = left + i * step;
            }
            DrawSpikes(x, chartSpikes);

        }

        private void bt10_Click(object sender, EventArgs e)
        {
            double[] x = new double[1000];
            double left = 0;
            double right = 100;
            double step = 0.001;
            int count = N;

            try
            {
                double tmp = 0;
                tmp = Double.Parse(tbLeft10.Text);
                left = tmp;
                tmp = Double.Parse(tbRight10.Text);
                right = tmp;
                tmp = Double.Parse(tbStep10.Text);
                step = tmp;
                count = (int)((right - left) / step);
                x = new double[count];
            }
            catch (Exception)
            {
            }

            for (int i = 0; i < count; i++)
            {
                x[i] = left + i * step;
            }
            DrawFurie(x, chartFurie);

        }

        private void tbStep10_TextChanged(object sender, EventArgs e)
        {

        }

        private void bt11_Click(object sender, EventArgs e)
        {
            double[] x = new double[1000];
            double left = 0;
            double right = 100;
            double step = 0.001;
            int count = N;

            try
            {
                double tmp = 0;
                tmp = Double.Parse(tbLeft11.Text);
                left = tmp;
                tmp = Double.Parse(tbRight11.Text);
                right = tmp;
                tmp = Double.Parse(tbStep11.Text);
                step = tmp;
                count = (int)((right - left) / step);
                x = new double[count];
            }
            catch (Exception)
            {
            }

            for (int i = 0; i < count; i++)
            {
                x[i] = left + i * step;
            }
            DrawShift(x, chartShift);
        }

        private void bt12_Click(object sender, EventArgs e)
        {
           
            double leftHB = 0;
            double rightHB= 200;
            double stepHB = 1;
            int countHB = N;

            double left = 0;
            double right = 100;
            double step = 0.001;
            int count = N;
            try
            {
                double tmp = 0;
                tmp = Double.Parse(tbLeftHB.Text);
                leftHB = tmp;
                tmp = Double.Parse(tbRightHB.Text);
                rightHB = tmp;
                tmp = Double.Parse(tbStepHB.Text);
                stepHB = tmp;
                countHB = (int)((rightHB - leftHB) / stepHB);
               
                tmp = Double.Parse(tbLeft12.Text);
                left = tmp;
                tmp = Double.Parse(tbRight12.Text);
                right = tmp;
                tmp = Double.Parse(tbStep12.Text);
                step = tmp;
                count = (int)((right - left) / step);
       
           
           
            }
            catch (Exception)
            {
            }
            double hDelta = stepHB;
            int hCount = countHB;
            double xDelta = step;
            int xCount = count;







            DrawHeartBeat(xDelta,xCount,hDelta, hCount, chartHeartBeat);

        }

        private void bt13_Click(object sender, EventArgs e)
        {
     
                double[] x = new double[1000];
                double left = 0;
                double right = 100;
                double step = 0.001;
                int count = N;

                try
                {
                    double tmp = 0;
                    tmp = Double.Parse(tbLeft13.Text);
                    left = tmp;
                    tmp = Double.Parse(tbRight13.Text);
                    right = tmp;
                    tmp = Double.Parse(tbStep13.Text);
                    step = tmp;
                    count = (int)((right - left) / step);
                    x = new double[count];
                }
                catch (Exception)
                {
                }

                for (int i = 0; i < count; i++)
                {
                    x[i] = left + i * step;
                }
                DrawTrendFurie(x, chartTrendFurie);

            
        }

        private void DrawFurieButton(Chart chart) {
            // double a = Double.Parse(tbA10.Text);
            //  double b = Double.Parse(tbB10.Text);
            Series series = chart.Series.FindByName(FUNCTION_NAME);

                double[] y = series.Points.Select(item => item.YValues[0]).ToArray();

                double[] x = series.Points.Select(item => item.XValue).ToArray();

            chart.Series.Clear();
             series = chart.Series.Add(FUNCTION_NAME);
            series.ChartType = SeriesChartType.Spline;


            y = Transformations.FurieFunction(y);

            double deltaT = x[1] - x[0];

            double Fgr = 1 / (2 * deltaT);

            double deltaF = Fgr / (x.Length / 2);
            double left = 0;

            for (int i = 0; i < x.Length; i++)
            {
                x[i] = left + i * deltaF;

            }
            for (int i = 0; i < x.Length / 2; i++)
            {
                if (!Double.IsInfinity(y[i]) && !Double.IsNaN(y[i]))
                    series.Points.AddXY(x[i], y[i]);

            }

        }

        private void btFurie1_Click(object sender, EventArgs e)
        {
            DrawFurieButton(chart1);
        }

        private void btFurie2_Click(object sender, EventArgs e)
        {
            DrawFurieButton(chart2);
        }

        private void btFurie3_Click(object sender, EventArgs e)
        {
            DrawFurieButton(chart3);
        }

        private void btFurie4_Click(object sender, EventArgs e)
        {

            DrawFurieButton(chart4);
        }

        private void btFurie5_Click(object sender, EventArgs e)
        {

            DrawFurieButton(chart5);
        }

        private void btFurie6_Click(object sender, EventArgs e)
        {

            DrawFurieButton(chartCombined);
        }

        private void btFurie7_Click(object sender, EventArgs e)
        {

            DrawFurieButton(chartHarm);
        }

        private void btFurie8_Click(object sender, EventArgs e)
        {

            DrawFurieButton(chartPolyHarm);
        }

        private void btFurie9_Click(object sender, EventArgs e)
        {

            DrawFurieButton(chartSpikes);
        }

        private void btFurie11_Click(object sender, EventArgs e)
        {

            DrawFurieButton(chartShift);
        }

        private void btFurie10_Click(object sender, EventArgs e)
        {

            DrawFurieButton(chartFurie);
        }

        private void btFurie12_Click(object sender, EventArgs e)
        {

            DrawFurieButton(chartHeartBeat);
        }
    }
}
