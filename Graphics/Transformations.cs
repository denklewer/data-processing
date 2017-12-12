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
            Parallel.For(0, n, i =>
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
            });

            return res;
        }

        public static double[] FurieXTransform(double[] x)
        {
            double[] newX = new double[x.Length / 2];
            double deltaT = x[1] - x[0];

            double Fgr = 1 / (2 * deltaT);

            double deltaF = Fgr / (x.Length / 2);
            double left = 0;


            /*  for (int i = 0; i < newX.Length; i++)
              {
                  newX[i] = left + i * deltaF;

              }*/

            Parallel.For(0, newX.Length, i =>
            {
                newX[i] = left + i * deltaF;

            }); // Parallel.For




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

            int deltaX = x.Length / (spikes + 2);

            for (int i = 0; i < spikes; i++)
            {
                x[deltaX + i * deltaX] = sigma + rnd.Next(0, 20);
            }
            // double[] res = Transformations.ConvolutionFunction(h, newX);
            return x;
        }
        public static double[] ConvolutionWithHeartBeat(double[] x, double f0, double alpha, double hLeft, double hRight, double hStep, double dt) {
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


        public static double[] SpikesFunction(double[] y, double m, double sigma)
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
        public static double[] AntiShifFunction(double[] y)
        {
            double mean = Statistics.ExpectedValue(y);
            for (int i = 0; i < y.Length; i++)
            {
                y[i] -= mean;
            }
            return y;

        }
        public static double[] AntiSpikeFunction(double[] y)
        {
            double mean = Statistics.ExpectedValue(y);
            double sigma = Statistics.StandartDeviation(y);
            for (int i = 0; i < y.Length; i++)
            {
                if (Math.Abs(y[i]) > (mean + 2 * sigma))
                {
                    if (i > 0 && i < y.Length - 1)
                    {
                        y[i] = (y[i + 1] - y[i - 1]) / 2;
                    }
                    else
                    {
                        y[i] = mean;
                    }
                }


            }
            return y;

        }

        public static double[] AntiRandomFunction(double left, double right, double step, double[] y, double A, double F, double CanalsCount) {
            double[] target = new double[y.Length];
            double x = left;
            for (int i = 0; i < y.Length; i++)
            {

                target[i] = Functions.HarmonicFunction(x, A, F);
                x += step;
            }

            for (int j = 0; j < y.Length; j++)
            {
                double value = y[j];


                for (int i = 0; i < CanalsCount - 1; i++)
                {
                    y[j] += target[j] + Functions.RandomFunction(0, -A * 10, A * 10);

                }

                y[j] = y[j] / CanalsCount;
            }
            return y;
        }

        public static double[] AddRandom(double[] y, double a) {
            for (int i = 0; i < y.Length; i++)
            {
                y[i] = y[i] + Functions.RandomFunction(0, -a, a);

            }
            return y;



        }

        public static double[] Multiply(double[] y, double m)
        {
            for (int i = 0; i < y.Length; i++)
            {
                y[i] = y[i] * m;

            }
            return y;



        }
        public static double[] CutX(double[] x, int start, int end) {
  

            return x.Skip(start).Take(end-start).ToArray();


        }
        public static double[] CutY(double[] y, int start, int end) {
            return y.Skip(start).Take(end - start).ToArray();


        }



        // TODO: проверить
        public static double[] AvgSlidingWindow(double[] y, int width)
        {
            for (int i = 0; i < y.Length-width; i++)
            {
                y[i] =y[i] - Statistics.ExpectedValue(y.Skip(i).Take(width).ToArray());

            }
            for (int i = y.Length - width; i < y.Length; i++)
            {
                y[i] = y[i] - Statistics.ExpectedValue(y.Skip(i).Take(y.Length-i).ToArray());
            }
            return y;

        }



        public static double[] Lpf( double fcut, int m, double dt )
        {
            double[] lpw = new double[m + 1];
            double[] d = { 0.35577019, 0.2436983, 0.07211497, 0.00630165 };
            //прямоугольная часть
            double arg = 2 * fcut * dt;
            lpw[0] = arg;
            arg *= Math.PI;
            for (int i = 1; i <= m; i++)
            {
                lpw[i] = Math.Sin(arg * i) / (Math.PI * i);
            }
            //трапеция
            lpw[m] /= 2;
            //окно
            double sumg = lpw[0];
         
            for (int i = 1; i <= m; i++)
            {
                double sum = d[0];
                arg = (Math.PI * i) / m;

                for (int k = 1; k <= 3; k++)
                {
                    sum += 2 * d[k] * Math.Cos(arg * k);
                }
                lpw[i] *= sum;
                sumg += 2 * lpw[i];

            }
            //сглаживание(нормировка)
            for (int i = 0; i <= m; i++)
            {
                lpw[i] = lpw[i] / sumg;
            }
            double[] reverse = lpw.Reverse().ToArray();
            double[] result = new double[2 * m + 1];
            for (int i = 0; i < m; i++)
            {
                result[i] = reverse[i];
            }
            for (int i=0; i<=m; i++)
            {
                result[m + i] = lpw[i];
            }
            return result;
        }
        //низкочастотный фильтр
        public static double[] LpfX(int m) {
            double[] x = new double[2 * m + 1];
            for (int i = 0; i < 2*m+1; i++)
            {
                x[i] = i;
            }
            return x;
        }


        //высокочастотный фильтр
        public static double[] Hpf(double fcut, int m, double dt)
        {
           double[] lpw =  Lpf(fcut, m, dt);
            for (int k = 0; k < lpw.Length; k++) {
                lpw[k] *= -1;
            }
            lpw[m] = 1 + lpw[m];
            return lpw;
        }
        //инжекторный фильтр (подавить полосу)
        public static double[] Bpf(double fcut1, double fcut2, int m, double dt)
        {
            double[] lpw1 = Lpf(fcut1, m, dt);
            double[] lpw2 = Lpf(fcut2, m, dt);
            for (int k = 0; k < lpw1.Length; k++)
            {
                lpw1[k] = lpw2[k] - lpw1[k];
            }
        
            return lpw1;
        }
       
        //полосовой фильтр(подавить кроме полосы)
        public static double[] Bsf(double fcut1, double fcut2, int m, double dt)
        {
            double[] lpw1 = Lpf(fcut1, m, dt);
            double[] lpw2 = Lpf(fcut2, m, dt);
            for (int k = 0; k < lpw1.Length; k++)
            {
                lpw1[k] = lpw1[k] - lpw2[k];
            }
            lpw1[m] += 1;
            return lpw1;
        }


        public static double[] ConwolutionWithLpf(double[] x, double fcut, double m, double dt)
        {
 
            double[] h = Transformations.Lpf(fcut, (int)m, dt);

            double[] res = Transformations.ConvolutionFunction(h, x);
            return res;
        }


        public static double[] ConwolutionWithHpf(double[] x, double fcut, double m, double dt)
        {

            double[] h = Transformations.Hpf(fcut, (int)m, dt);

            double[] res = Transformations.ConvolutionFunction(h, x);
            return res;
        }


        public static double[] ConwolutionWithBpf(double[] x, double fcut1,double fcut2, double m, double dt)
        {

            double[] h = Transformations.Bpf(fcut1,fcut2, (int)m, dt);

            double[] res = Transformations.ConvolutionFunction(h, x);
            return res;
        }

        public static double[] ConwolutionWithBsf(double[] x, double fcut1, double fcut2, double m, double dt)
        {

            double[] h = Transformations.Bsf(fcut1, fcut2, (int)m, dt);

            double[] res = Transformations.ConvolutionFunction(h, x);
            return res;
        }













    }
}
