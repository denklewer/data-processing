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

namespace Graphics.forms
{
    public partial class Histogram : Form
    {
        public Histogram( double[][] data, int levels)
        {
    
            InitializeComponent();
            // chartHist.ChartAreas.Clear();
            //  chartDensity.ChartAreas.Clear();
            chartHist.ChartAreas[0].Name = "hist";
            chartDensity.ChartAreas[0].Name = "density";
            //chartHist.ChartAreas.Add("hist");
          //  chartDensity.ChartAreas.Add("density");
            chartDensity.ChartAreas.Add("reversed");     
            chartDensity.ChartAreas.Add("equalization");

            chartHist.Series.Clear();
            chartDensity.Series.Clear();

            Draw(chartHist,"hist",Hist(data, levels), SeriesChartType.Column);
            Draw(chartDensity, "density", Density(Hist(data, levels)), SeriesChartType.Line);
            // Draw(chartReversed, "reversed",Reversed(Density( Hist(data, levels))));
      



            Draw(chartDensity, "equalization", Equalization(Hist(data, levels),levels), SeriesChartType.Column);
            Draw(chartDensity, "reversed", Reversed(Density(Hist(data, levels)), levels), SeriesChartType.Column);
        }


        public void Draw(Chart chart, string functionName, double[] data, SeriesChartType chartType )
        {

            Series series = chart.Series.Add(functionName);
            series.ChartType = chartType ;
            series.ChartArea = functionName;

            for (int i = 0; i < data.Length; i++)
            {
                series.Points.AddY(data[i]);

            }


        }

        public static double[] Hist(double[][] y,int  levels)
        {
  
            double[] ans = new double[levels];
            for (int i = 0; i < y.Length; i++)
            {
                for (int j = 0; j < y[i].Length; j++)
                {

                
                    try
                    {
                        ans[(int)y[i][j]] += 1;
                    }
                    catch (Exception)
                    {
                        ans[ans.Length - 1] += 1;
                    }
                }


                //double lMin = arr.Min(x => x.YValues[0]);
                //double lMax = arr.Max(x => x.YValues[0]);
                //double divisor = (lMax - lMin) / M;



            }

            return ans;
        }

        public static double[] Density(double[] y) {

            double[] ans = new double[y.Length];
            double N = y.Sum();

            for (int i = 0; i < ans.Length; i++)
            {
                ans[i] = (double)y.Take(i+1).Sum()/N;
            }

            return ans;

        }

        public static double[] Reversed(double[] y,int levels)
        {

           // double[] ans = Equalization(y, levels);
            double[] normX = new double[y.Length];
            for (int i = 0; i < y.Length; i++)
            {
                normX[i] = (double)i / 255;
            }
            
            double[] ans = new double[y.Length];


            
           for (int i = 0; i < y.Length; i++)
            {
                ans[(int)(y[i] * 255)] = normX[i];
            }

            for (int i = 0; i < ans.Length; i++) {
                if (ans[i] == 0) {
                    ans[i] = y[i];
                }
            }


            


            return ans;

        }

        public static double[][] HistReduction(double[][] data,int levels) {
            double[] hist = Hist(data, levels);
            double[] density = Density(hist);
            double[] reversed = Reversed(density,levels);

            for (int j = 0; j < data.Length; j++)
            {
                for (int i = 0; i < data[0].Length; i++)
                {
                    for (int h = 0; h < reversed.Length; h++)
                    {
                        if (density[(int)data[j][i]]<reversed[h]) {
                            data[j][i] = h;
                            break;
                        }
                    }
                    
                }
            }
            return data;

        }


        public static double[] Equalization(double[] y, int levels)
        {

            double[] ans = new double[y.Length];
            double N = y.Sum();

            for (int i = 0; i < ans.Length; i++)
            {
                ans[i] = (int)((double)y.Take(i + 1).Sum() / N * (levels -1));
            }

            return ans;

        }

        public static double[][] HistEquilization(double[][] data,int levels) {
            double[] hist =  Hist(data,levels);
            double[] eq = Equalization(hist, levels);

            for (int j = 0; j< data.Length; j++)
            {
                for (int i = 0; i < data[0].Length; i++)
                {
                   data[j][i] =(int) eq[(int)data[j][i]];
                }
            }

            return data;

        }



        private void Histogram_Load(object sender, EventArgs e)
        {

        }
    }
}
