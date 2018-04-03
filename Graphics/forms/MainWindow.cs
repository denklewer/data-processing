using Graphics.util;
using NAudio.Wave;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Graphics
{
    public partial class MainWindow : Form
    {
        
        private Func<Double[], Double> fun = new Func<double[], double>(x => 10);
        private Func<Double[], Double[], Double[]> transformX = new Func<double[], double[], double[]>((x, y) => x);
        private Func<Double[], Double[], Double[]> transformY = new Func<double[], double[], double[]>((x, y) => x);
        private int N = 1000;
        private int seriesCount = 1;
        private String functionName = "x=10";



        private static int startCut;
        private static int endCut;
        private static double hLength;
        private static double dT;
   

        public MainWindow()
        {
            InitializeComponent();


            chart.MouseWheel += chData_MouseWheel;
        }

        public MainWindow(double[] data) {
            InitializeComponent();

            chart.MouseWheel += chData_MouseWheel;
            validateSetings();



            Control.ControlCollection controls = panelFunctionParams.Controls;
            double[] args = new double[controls.Count / 2 + 1];
            int i = controls.Count / 2;
            foreach (Control item in controls)
            {
                if (item.GetType() == (typeof(TextBox)))
                {
                    args[i] = Double.Parse(item.Text);
                    i--;
                }


            }
            string chartAreaNum = cbArea.Text;
            chart.Series.Remove(chart.Series.FindByName(chartAreaNum));

            Series series = chart.Series.Add(chartAreaNum);
            functionName = chartAreaNum;
            if (chart.ChartAreas.FindByName(chartAreaNum) == null)
            {
                chart.ChartAreas.Add(chartAreaNum);
                cbArea.Items.Add(chartAreaNum);
                validateSetings();

            }
            series.ChartArea = chartAreaNum;
            series.ChartType = SeriesChartType.Line;
            double funValue = 0;

            for (int j = 0; j < data.Length; j++)
            {

                funValue = data[j];
                if (!Double.IsInfinity(funValue) && !Double.IsNaN(funValue))
                    series.Points.AddXY(j, funValue);
            }

            validateSetings();

        }

        public MainWindow(double[] data1, double[] data2)
        {
            InitializeComponent();
            double[] result = new double[data1.Length];
            for (int ind = 0; ind < result.Length; ind++)
            {
                result[ind] = Transformations.Crosscorrelation(data1, data2, ind);
            }


            chart.MouseWheel += chData_MouseWheel;
            validateSetings();



            Control.ControlCollection controls = panelFunctionParams.Controls;
            double[] args = new double[controls.Count / 2 + 1];
            int i = controls.Count / 2;
            foreach (Control item in controls)
            {
                if (item.GetType() == (typeof(TextBox)))
                {
                    args[i] = Double.Parse(item.Text);
                    i--;
                }


            }
            string chartAreaNum = cbArea.Text;
            chart.Series.Remove(chart.Series.FindByName(chartAreaNum));

            Series series = chart.Series.Add(chartAreaNum);
            functionName = chartAreaNum;
            if (chart.ChartAreas.FindByName(chartAreaNum) == null)
            {
                chart.ChartAreas.Add(chartAreaNum);
                cbArea.Items.Add(chartAreaNum);
                validateSetings();

            }
            series.ChartArea = chartAreaNum;
            series.ChartType = SeriesChartType.Line;
            double funValue = 0;

            for (int j = 0; j < result.Length; j++)
            {

                funValue = result[j];
                if (!Double.IsInfinity(funValue) && !Double.IsNaN(funValue))
                    series.Points.AddXY(j, funValue);
            }

            validateSetings();

        }

        public void validateSetings() {
            foreach (ChartArea item in chart.ChartAreas)
            {
                item.AxisX.MajorGrid.Enabled = false;
                item.AxisY.MajorGrid.Enabled = false;
                item.AxisX.Crossing = 0;
                item.AxisY.Crossing = 0;

                item.CursorX.IsUserSelectionEnabled = true;
                item.CursorY.IsUserSelectionEnabled = true;
                item.AxisX.ScaleView.Zoomable = true;
                item.AxisY.ScaleView.Zoomable = true;
                item.CursorX.AutoScroll = true;
                item.CursorY.AutoScroll = true;


                item.AxisX.MinorGrid.Enabled = true;
                item.AxisY.MinorGrid.Enabled = true;
                item.AxisX.MinorGrid.LineColor = Color.Gray;
                item.AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dot;
                item.AxisY.MinorGrid.LineColor = Color.Gray;
                item.AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dot;
                
                
               



            }

        }

        private void chData_MouseWheel(object sender, MouseEventArgs e)
        {
            Chart chart1 = (Chart)sender;
            if (ModifierKeys == Keys.Control)
            {
                try
                {
                    if (e.Delta < 0)
                    {
                        chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                        chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset();
                    }
                    if (e.Delta > 0)
                    {
                        double xMin = chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                        double xMax = chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                        double yMin = chart1.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                        double yMax = chart1.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

                        double posXStart = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                        double posXFinish = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
                        double posYStart = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
                        double posYFinish = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

                        Math.Round(posXStart);
                        Math.Round(posXFinish);
                        Math.Round(posYFinish);
                        Math.Round(posYStart);
                        if (posXFinish - posXStart > 0.001 && posYFinish - posYStart > 0.001)
                        {
                            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
                            chart1.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish);
                        }



                    }
                }
                catch (OverflowException) { }
            }
        }



        private void chart_MouseEnter(object sender, EventArgs e)
        {
            if (chart.Focused) chart.Parent.Focus();
        }

        private void chart1_MouseLeave(object sender, EventArgs e)
        {
            if (!chart.Focused) chart.Focus();
        }

        private void btDraw_Click(object sender, EventArgs e)
        {
            double[] x = new double[1000];
            double left = 0;
            double right = 1000;
            double step = 1;
            int count = N;
            try
            {
                double tmp = 0;
                tmp = Double.Parse(tbLeft.Text);
                left = tmp;
                tmp = Double.Parse(tbRight.Text);
                right = tmp;
                tmp = Double.Parse(tbStep.Text);
                step = tmp;
                count = (int)((right - left) / step);
                x = new double[count];
            }
            catch (Exception)
            {
                MessageBox.Show("Parse error");
            }

            for (int i = 0; i < count; i++)
            {
                x[i] = left + i * step;
            }
            DrawFun(x);
        }

        private void DrawFun(double[] x)
        {
            Control.ControlCollection controls = panelFunctionParams.Controls;
            double[] args = new double[controls.Count / 2 + 1];
            int i = controls.Count / 2;
            foreach (Control item in controls)
            {
                if (item.GetType() == (typeof(TextBox)))
                {
                    args[i] = Double.Parse(item.Text);
                    i--;
                }


            }
            string chartAreaNum = cbArea.Text;
            chart.Series.Remove(chart.Series.FindByName(chartAreaNum));

            Series series = chart.Series.Add(chartAreaNum);
            functionName = chartAreaNum;
            if (chart.ChartAreas.FindByName(chartAreaNum) == null) {
                chart.ChartAreas.Add(chartAreaNum);
                cbArea.Items.Add(chartAreaNum);
                validateSetings();

            }
            series.ChartArea = chartAreaNum;
            series.ChartType = SeriesChartType.Line;
            double funValue = 0;

            for (int j = 0; j < x.Length; j++)
            {
                args[0] = x[j];
                funValue = fun(args);
                if (!Double.IsInfinity(funValue) && !Double.IsNaN(funValue))
                    series.Points.AddXY(x[j], funValue);
            }
        }

        private double[] TransformFunX(double[] x)
        {
            Control.ControlCollection controls = panelTransformParams.Controls;
            double[] args = new double[controls.Count / 2];
            int i = controls.Count / 2 - 1;
            foreach (Control item in controls)
            {
                if (item.GetType() == (typeof(TextBox)))
                {
                    args[i] = Double.Parse(item.Text);
                    i--;
                }
            }

            //double[] funValue = new double[x.Length];

            double[] funValue = transformX(x, args);
            return funValue;

        }

        private double[] TransformFunY(double[] x)
        {
            Control.ControlCollection controls = panelTransformParams.Controls;
            double[] args = new double[controls.Count / 2];
            int i = controls.Count / 2 - 1;
            foreach (Control item in controls)
            {
                if (item.GetType() == (typeof(TextBox)))
                {
                    args[i] = Double.Parse(item.Text);
                    i--;
                }
            }
            //  double[] funValue = new double[x.Length];
            double[] funValue = transformY(x, args);
            return funValue;

        }
















        private void cbFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFunction.Text)
            {
                case "ax+b":
                    {
                        fun = new Func<Double[], Double>(x => Functions.LinearFunction(x[0], x[1], x[2]));
                        addParameters(panelFunctionParams, new string[] { "A", "B" });
                        break;
                    }
                case "ax^2+bx+c":
                    {
                        fun = new Func<Double[], Double>(x => Functions.Quadratic(x[0], x[1], x[2], x[3]));
                        addParameters(panelFunctionParams, new string[] { "A", "B", "C" });
                        break;
                    }
                case "b*exp(-ax)":
                    {
                        fun = new Func<Double[], Double>(x => Functions.ExpFunction(x[0], x[1], x[2]));
                        addParameters(panelFunctionParams, new string[] { "A", "B" });
                        break;
                    }
                case "RandomNative":
                    {
                        fun = new Func<Double[], Double>(x => Functions.RandomFunction(x[0]));
                        addParameters(panelFunctionParams, new string[] { });
                        break;
                    }
                case "CustomRandom":
                    {
                        fun = new Func<Double[], Double>(x => Functions.CustomRandomFunction(x[0]));
                        addParameters(panelFunctionParams, new string[] { });
                        break;
                    }
                case "Combined":
                    {
                        fun = new Func<Double[], Double>(x => Functions.CombinedFunction(x[0]));
                        addParameters(panelFunctionParams, new string[] { });
                        break;
                    }
                case "HeartBeat":
                    {
                        fun = new Func<Double[], Double>(x => Functions.HeartBeatFunction(x[0], x[1], x[2]));
                        addParameters(panelFunctionParams, new string[] { "f0", "alpha" });
                        break;
                    }
                case "PolyHarmonic (A1-3,f1-3)":
                    {
                        fun = new Func<Double[], Double>(x => Functions.PolyHarmonicFunction(x[0],
                                                                                             new double[] { x[1], x[3], x[5] },
                                                                                             new double[] { x[2], x[4], x[6] }));
                        addParameters(panelFunctionParams, new string[] { "A1", "f1", "A2", "f2", "A3", "f3" });
                        break;
                    }
                case "Harmonic(A,f)":
                    {
                        fun = new Func<Double[], Double>(x => Functions.HarmonicFunction(x[0], x[1], x[2]));
                        addParameters(panelFunctionParams, new string[] { "A", "f" });
                        break;
                    }
                case "Random(a,b)":
                    {
                        fun = new Func<Double[], Double>(x => Functions.RandomFunction(x[0], x[1], x[2]));
                        addParameters(panelFunctionParams, new string[] { "Low", "High" });
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }

        private void addParameters(Panel panel, String[] parameters)
        {
            panel.Controls.Clear();
            Label label;
            TextBox textBox;
            String[] reversedParamenters = parameters.Reverse().ToArray();

            foreach (string item in reversedParamenters)
            {

                label = new Label();
                label.Text = item + ": ";
                textBox = new TextBox();

                panel.Controls.Add(textBox);
                panel.Controls.Add(label);

                /*label.Anchor = AnchorStyles.Top;
                textBox.Anchor = AnchorStyles.Top;*/
                label.Dock = DockStyle.Top;
                textBox.Dock = DockStyle.Top;

            }
            panel.AutoScroll = true;

        }

        private void btTransform_Click(object sender, EventArgs e)
        {

            Series series = chart.Series.FindByName(cbArea.Text);

            double[] y = series.Points.Select(item => item.YValues[0]).ToArray();

            double[] x = series.Points.Select(item => item.XValue).ToArray();

            string chartAreaNum = cbArea.Text;
            chart.Series.Remove(chart.Series.FindByName(chartAreaNum));
            

            series = chart.Series.Add(chartAreaNum);
            functionName = chartAreaNum;
            series.ChartArea = chartAreaNum;
        
            series.ChartType = SeriesChartType.Line;
           // Parallel.Invoke(() => { x = TransformFunX(x); y = TransformFunX(y); });

             x = TransformFunX(x);

             y = TransformFunY(y);
            series.Points.Clear();
            for (int i = 0; i < x.Length; i++)
            {
                if (!Double.IsInfinity(y[i]) && !Double.IsNaN(y[i]))
                    series.Points.AddXY(x[i], y[i]);
               


            }
            // chart.ChartAreas[chartAreaNum].RecalculateAxesScale();
          /*  chart.ChartAreas[chartAreaNum].AxisX.MinorGrid.Enabled = false;
            chart.ChartAreas[chartAreaNum].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[chartAreaNum].AxisY.MinorGrid.Enabled = false;
            chart.ChartAreas[chartAreaNum].AxisY.MajorGrid.Enabled = false;*/
           // chart.ChartAreas[chartAreaNum].AxisX.Crossing = 0;

        }

        private void cbTransform_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cbTransform.Text)
            {

                case "Fourier":
                    {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => Transformations.FurieXTransform(y));
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.FurieFunction(y));
                        addParameters(panelTransformParams, new string[] { });
                        break;
                    }
                case "ForwardFurie":
                    {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.ForwardFurie(y).Select(x => x.Imaginary + x.Real).ToArray());
                        addParameters(panelTransformParams, new string[] { });
                        break;
                    }

                case "ReverseFurie":
                    {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.ReverseFurie(y).Select(x => x.Imaginary + x.Real).ToArray());
                        addParameters(panelTransformParams, new string[] { });
                        break;
                    }



                case "CombFilter":
                    {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => y);

                        transformY = new Func<Double[], Double[], Double[]>((y, args) => {

                            double [] res = Transformations.CombFilter(y, args[0],(int) args[1]);
                            return res;
                        } );
                        addParameters(panelTransformParams, new string[] { "g","M"});
                        break;
                    }
                case "Spikes(F(x),M,Sigma)":
                    {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.SpikesFunction(y, args[0], args[1]));
                        addParameters(panelTransformParams, new string[] { "M", "sigma" });
                        break;
                    }
                case "Shift(F(x),shift)":
                    {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.ShiftFunction(y, args[0]));
                        addParameters(panelTransformParams, new string[] { "shift" });
                        break;
                    }
                case "RandomSpikes(x,spikes)":
                    {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.RandomSpikes(y, (int)args[0], args[1]));
                        double tmp = 0;

                        addParameters(panelTransformParams, new string[] {"spikes", "sigma"});
                        break;
                    }
                case "ConvolutionWithHeartBeat(x,f0,alpha,hLeft,hRight,hStep)":
                    {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.ConvolutionWithHeartBeat(y, args[0], args[1], args[2], args[3], args[4],Double.Parse(tbStep.Text)));
                        double tmp = 0;

                        addParameters(panelTransformParams, new string[] { "f0", "alpha", "hLeft", "hRight", "hStep" });
                        break;
                    }
                case "ConvolutionWithPlot":
                    {

                        transformX = new Func<Double[], Double[], Double[]>((y, args) => {
 

                            Series series = chart.Series.FindByName(args[0].ToString());
                            int m = series.Points.Select(item => item.YValues[0]).ToArray().Length;
                            

                            return y.ToArray();
                        });
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => {
                            Series series = chart.Series.FindByName(args[0].ToString());
                            double[] h = series.Points.Select(item => item.YValues[0]).ToArray();
                            double[] res = Transformations.ConvolutionWithPlot(h, y);
                            
                            return Transformations.Normalize(res);
                        });
                        addParameters(panelTransformParams, new string[] { "Plot number"});
                        break;
                    }
                case "Shroeder":
                    {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => {return y.ToArray();});
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => {
                            double g = 0.9;
                            double[] cg = new double[4];
                            int[] cd = new int[4];
                            double ag = 0.9;
                            int[] ad = new int[2];
                            double k = 0.2;
                            Random r = new Random();

                            for (int i = 0; i < cg.Length; i++)
                            {
                                cg[i] = 0.7;
                            }
                            for (int i = 0; i < cd.Length; i++)
                            {
                                cd[i]=(int)( 0.05* r.Next(0,y.Length)+1);
                            }
                            for (int i = 0; i < ad.Length; i++)
                            {
                                ad[i] = (int)(0.05 * r.Next(0, y.Length) + 1);
                            }


                            return Transformations.ShroederFilter(y,cg,cd,ag,ad,k);
                        });
                        addParameters(panelTransformParams, new string[] {});

                        break;
                    }

                case "ConvolutionWithLpf(x,fcut,m,dt)":
                    {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => y.Take(y.Length).ToArray());
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => {
                            int m =(int) args[1];
                            return Transformations.ConwolutionWithLpf(y, args[0], m, dT)
                              .Skip(m).Take(y.Length).ToArray();       
                            });
                        double tmp = 0;

                        addParameters(panelTransformParams, new string[] { "fcut", "m"});
                        break;
                    }
                case "ConvolutionWithHpf(x,fcut,m,dt)":
                    {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => y.Take(y.Length).ToArray());
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.ConwolutionWithHpf(y, args[0], args[1], dT).Skip((int)args[1]).Take(y.Length).ToArray());
                        double tmp = 0;

                        addParameters(panelTransformParams, new string[] { "fcut", "m" });
                        break;
                    }
                case "ConvolutionWithBpf(x,fcut1,fcut2,m,dt)":
                    {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => y.Take(y.Length).ToArray());
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.ConwolutionWithBpf(y, args[0], args[1], args[2],dT)
                                                                                                        .Skip((int)args[2])
                                                                                                        .Take(y.Length)
                                                                                                        .ToArray());
                        double tmp = 0;

                        addParameters(panelTransformParams, new string[] { "fcut1","fcut2", "m" });

                        break;
                    }
                case "ConvolutionWithBsf(x,fcut1,fcut2,m,dt)":
                    {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => y.Take(y.Length).ToArray());
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.ConwolutionWithBsf(y, args[0], args[1], args[2], dT)
                                                                                                        .Skip((int)args[2])
                                                                                                        .Take(y.Length)
                                                                                                        .ToArray());
                        double tmp = 0;

                        addParameters(panelTransformParams, new string[] { "fcut1", "fcut2", "m" });

                        break;
                    }
                case "AddRandom":
                    {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => {
                            for (int i = 0; i < args[1]; i++)
                            {
                                y = Transformations.AddRandom(y, args[0]);
                            }
                           
                            return y;
                        });
                        double tmp = 0;

                        addParameters(panelTransformParams, new string[] { "A","M"});
                        break;
                    }
                case "AntiRandom":
                    {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => y);
                        double left = Double.Parse(tbLeft.Text);
                        double right = Double.Parse(tbRight.Text);
                        double step = Double.Parse(tbStep.Text);
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.AntiRandomFunction(left,right,step,y,args[0],args[1],args[2]));
                        addParameters(panelTransformParams, new string[] {"A", "F","CanalsCount"});
                        break;
                    }
                case "AntiShift": {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => y);       
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.AntiShifFunction(y));
                        addParameters(panelTransformParams, new string[] { });
                        break;
                    }
                case "AntiSpike":
                    {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.AntiSpikeFunction(y));
                        addParameters(panelTransformParams, new string[] { });
                        break;
                    }
                case "AntiTrend": {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => {
                            
                          double [] newY=  Transformations.AvgSlidingWindow(y, (int)args[0]);             
                            return y;
                        });
                        double tmp = 0;

                        addParameters(panelTransformParams, new string[] { "width" });
                        break;
                    }
                case "LPW":
                    {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => Transformations.LpfX((int)args[1]));
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.Lpf(args[0],(int)args[1],args[2]));
                        addParameters(panelTransformParams, new string[] { "fcut" , "m", "dt"});
                        MessageBox.Show("Преобразование фурье умножьте на 2*m+1");
                        break;
                    }
                case "HPF":
                    {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => Transformations.LpfX((int)args[1]));
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.Hpf(args[0], (int)args[1], args[2]));
                        addParameters(panelTransformParams, new string[] { "fcut", "m", "dt" });
                        MessageBox.Show("Преобразование фурье умножьте на 2*m+1");
                        break;
                    }
                case "BPF":
                    {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => Transformations.LpfX((int)args[2]));
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.Bpf(args[0],args[1], (int)args[2], args[3]));
                        addParameters(panelTransformParams, new string[] { "fcut1", "fcut2", "m", "dt" });
                        MessageBox.Show("Преобразование фурье умножьте на 2*m+1");
                        break;
                    }
                case "BSF":
                    {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => Transformations.LpfX((int)args[2]));
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.Bsf(args[0], args[1], (int)args[2], args[3]));
                        addParameters(panelTransformParams, new string[] { "fcut1", "fcut2", "m", "dt" });
                        MessageBox.Show("Преобразование фурье умножьте на 2*m+1");
                        break;
                    }
                case "CombFilter(x,g,M)":
                    {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.CombFilter(y,args[0], (int)args[1]));
                        addParameters(panelTransformParams, new string[] { "g", "M"});
                        break;
                    }

                case "UniversalCombFilter(BL,FB,FF,M)":
                    {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.UniversalCombFilter(y,args[0], args[1],args[2],(int)args[3]));
                        addParameters(panelTransformParams, new string[] { "BL", "FB", "FF", "M" });
                        break;
                    }

                    
                case "Multiply":
                    {
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => y);
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => Transformations.Multiply(y, args[0]));
                        addParameters(panelTransformParams, new string[] {  "2*m+1" });
                  
                        break;
                    }
                case "Cut(left_cut, right_cut)":
                    {

                  
                        transformX = new Func<Double[], Double[], Double[]>((y, args) => {
                            int start = 0;
                            int end = y.Length;
                            double leftBorder = args[0];
                            double rightBorder = args[1];

                            Series series = chart.Series.FindByName(cbArea.Text);
                            for (int i = 0; i < y.Length; i++)
                            {
                                if (y[i] > leftBorder)
                                {
                                    start = i;
                                    break;
                                }

                            }
                            for (int i = y.Length-1; i > 0; i--)
                            {
                                if (y[i] < rightBorder)
                                {
                                    end = i;
                                    break;
                                }
                            }
                            startCut = start;
                            endCut = end;
                            return Transformations.CutX(y, start, end); });
                        transformY = new Func<Double[], Double[], Double[]>((y, args) => {
                            return Transformations.CutY(y, startCut, endCut);                                                   
                            });
                        addParameters(panelTransformParams, new string[] { "left_cut","right_cut" });

                        break;

                    }


                default:
                    {
                        break;
                    }

            }
        }

        private void btAddArea_Click(object sender, EventArgs e)
        {
            string chartAreaNum = cbArea.Text;
            if (chart.ChartAreas.FindByName(chartAreaNum) == null)
            {
                chart.ChartAreas.Add(chartAreaNum);
            }
            cbArea.Items.Add(chartAreaNum);
            validateSetings();
        }

        private void btDeleteArea_Click(object sender, EventArgs e)
        {
            string chartAreaNum = cbArea.Text;
            if (chart.Series.FindByName(chartAreaNum) != null)
            {
                chart.Series.Remove(chart.Series.FindByName(chartAreaNum));
            }
            if (chart.ChartAreas.FindByName(chartAreaNum) != null)
            {
                chart.ChartAreas.Remove(chart.ChartAreas.FindByName(chartAreaNum));
                cbArea.Items.Remove(chartAreaNum);
            }

        }

        private void btStatistics_Click(object sender, EventArgs e)
        {
            StatisticsForm statisticsForm = new StatisticsForm(chart, functionName);
            statisticsForm.Show();
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        public static WaveFormat waveFormat;

        private void btnFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            tbFile.Text = filename;

            MessageBox.Show("Файл открыт");
             String[]  arr = filename.Split('.');

            double[] y=new double[100];

            double[] x;
            switch (arr.Last()) {
                case "dat": {
                        y = readHex(filename);
                        x = new double[y.Length];
                        for (int i = 0; i < x.Length; i++)
                        {
                            x[i] = i;
                        }
                        dT = 1.0 / 1000;
                        break; 
                    }
                case "wav": {
                        
                        y = readWav(filename, out int rate, out waveFormat);
                        x = new double[y.Length];
                        dT = 1.0 / rate;
                        double dt = 1.0 / rate;
                        for (int i = 0; i < x.Length; i++)
                        {
                            x[i] = i*dt;
                        }
                        btWrite.Enabled = true;


                        break;
                    }
                default: {
                        MessageBox.Show("Неверный формат файла");
                        return;                     
                    }
            }

  
            Series series = chart.Series.FindByName(cbArea.Text);
         
          
            string chartAreaNum = cbArea.Text;
            chart.Series.Remove(chart.Series.FindByName(chartAreaNum));


            series = chart.Series.Add(chartAreaNum);
            functionName = chartAreaNum;
            series.ChartArea = chartAreaNum;

            series.ChartType = SeriesChartType.Line;

            series.Points.Clear();
            for (int i = 0; i < x.Length; i++)
            {
                if (!Double.IsInfinity(y[i]) && !Double.IsNaN(y[i]))
                    series.Points.AddXY(x[i], y[i]);



            } 






        }

        static double[] readHex(string filename) {
            BinaryReader reader = new BinaryReader(new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None));
            reader.BaseStream.Position = 0x0;     // The offset you are reading the data from
            double[] data = new double[1000];
            for (int i = 0; i < 1000; i++)
            {
                data[i] = reader.ReadSingle();
            }       
            reader.Close();

            return data;

        }


        static double[] readWav(string filename, out int rate, out WaveFormat format)
        {
            WaveFileReader reader = new WaveFileReader(filename);
            format = reader.WaveFormat;
            float[] buffer;
            double[] data = new double[reader.SampleCount];
            int  counter = 0;
            rate =reader.WaveFormat.SampleRate;
 
            while ((buffer = reader.ReadNextSampleFrame()) != null)
            {
                for (int i = 0; i < buffer.Length; i++)
                {
                    data[counter++] = buffer[i];

                }
            }
            reader.Close();
            return data;

        }

        public static void writeWav(string path, WaveFormat format, float[] samples)
        {
            using (WaveFileWriter writer = new WaveFileWriter(path, format))
            {
                writer.WriteSamples(samples, 0, samples.Length);
                writer.Flush();
            }
        }

        private void btWrite_Click(object sender, EventArgs e)
        {
            Series series = chart.Series.FindByName(cbArea.Text);

            double[] y = series.Points.Select(item => item.YValues[0]).ToArray();
            float[] data = new float[y.Length];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] =(float) y[i];

            }
            writeWav(tbFile.Text, waveFormat, data);





        }

        private void tbFile_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
