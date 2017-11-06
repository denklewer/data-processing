using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics
{
    class Transformations
    {
        static Random rnd = new Random(59);
        public static double[] FurieFunction(double[] y)
        {
            int n = y.Length;
            double[] res = new double[n];
            for (int i = 0; i < n; i++)
            {

                double Rei = 0;
                for (int k = 0; k < n; k++)
                {
                    Rei += y[k] * Math.Cos((Math.PI * 2 * i * k) / n);
                }
                double Imi = 0;
                for (int k = 0; k < n; k++)
                {
                    Imi += y[k] * Math.Sin((Math.PI * 2 * i * k) / n);
                }
                Rei = Rei / n;
                Imi = Imi / n;

                res[i] = Math.Sqrt(Math.Pow(Rei, 2) + Math.Pow(Imi, 2));
            }
            return res;
        }

        public static double[] FurieXTransform(double[] x)
        {
            double[] newX = new double[x.Length / 2];
            double deltaT = x[1] - x[0];

            double Fgr = 1 / (2 * deltaT);

            double deltaF = Fgr / (x.Length / 2);
            double left = 0;

            for (int i = 0; i < newX.Length; i++)
            {
                newX[i] = left + i * deltaF;

            }
            return newX;
        }


        public static double[] ConvolutionFunction(double[] h, double[] y)
        {
            int n = y.Length;
            int m = h.Length;
            double[] res = new double[n + m];
            for (int k = 0; k < res.Length; k++)
            {
                double yk = 0;
                for (int l = 0; l < m; l++)
                {
                    if ((k - l < 0) || (k - l >= n))
                    {

                    }
                    else
                    {
                        yk = yk + y[k - l] * h[l];
                    }

                }
                res[k] = yk;

            }
            return res;
        }


        public static double[] RandomSpikes(double[] x, int spikes, double sigma)
        {

            /* Func<double, double> hFun = (t => Math.Sin(2 * Math.PI * f0 * t) * Math.Exp(-alpha * t));
             double dt = hDelta;
             for (int i = 0; i < h.Length; i++)
             {
                 h[i] = hFun(i * dt);
             }*/

            int deltaX = x.Length / (spikes+2);

            for (int i = 0; i < spikes; i++)
            {
                x[deltaX + i*deltaX] = sigma + rnd.Next(0, 20);
            }    
           // double[] res = Transformations.ConvolutionFunction(h, newX);
            return x;
        }
        public static double[] ConvolutionWithHeartBeat(double[] x, double f0, double alpha, double hLeft,double hRight, double hStep, double dt) {
            int hCount = (int)((hRight - hLeft) / hStep);
            double[] h = new double[hCount];

            double hDelta = x[1] - x[0];
            Func<double, double> hFun = (t => Math.Sin(2 * Math.PI * f0 * t) * Math.Exp(-alpha * t));
            
            for (int i = 0; i < h.Length; i++)
            {
                h[i] = hFun(i * dt);
            }
            double[] res = Transformations.ConvolutionFunction(h, x);
            return res;
        }


        public static double[] SpikesFunction( double[] y, double m, double sigma)
        {
            double maxA = y.Max() - y.Min();
            for (int i = 0; i < m; i++)
            {
                int index = rnd.Next(0, y.Length - 1);
                int sign = rnd.Next(0, 2);
                int n = y.Length;

                double aSmin = maxA * 10 * sigma;
                double aSmax = (maxA + 1) * 10 * sigma;

                double aS = aSmin + rnd.NextDouble() * (aSmax - aSmin);

                if (sign == 0)
                {
                    y[index] -= aS;
                }
                else
                {
                    y[index] += aS;
                }
            }
            return y;

        }
        public static double[] ShiftFunction(double[] y, double sigma)
        {
            for (int i = 0; i < y.Length; i++)
            {
                y[i] += sigma;
            }
            return y;

        }


    }
}
