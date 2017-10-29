using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics
{
    class Functions
    {
       static RandomGenerator customGenerator = new RandomGenerator();
       static Random rnd = new Random(59);

        public static double LinearFunction(double x, double a, double b)
        {
            return (a * x + b);
            // return 5;
        }

        public static double Quadratic(double x, double a, double b, double c)
        {
            return (a * Math.Pow(x, 2) + b * x + c);
        }

        public static double ExpFunction(double x, double a, double b)
        {
            return b * Math.Exp(-a * x);
        }

        public static double LogFunction(double x, double a, double b)
        {
            return b * Math.Log(a * x);
        }

        public static double CustomRandomFunction(double x)
        {

            double d = customGenerator.GenerateDouble();
            // d = 0.5 - rnd.NextDouble();

            return d;
        }

        public static double RandomFunction(double x)
        {

            double d;
            d = 0.5 - rnd.NextDouble();

            return d;
        }

        public static double CombinedFunction(double x)
        {
            if (x < 0)
            {
                return (2 * x);
            }
            else if (x <= 1)
            {
                return (Math.Pow(x, 2));
            }
            else
            {
                return Math.Log(x) + 1;
            }
        }

        public static double HarmonicFunction(double x, double a, double f0)
        {
            return a * Math.Sin(2 * Math.PI * f0 * x);
        }

        public static double PolyHarmonicFunction(double x, double[] a, double[] f0)
        {
            double result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                result += HarmonicFunction(x, a[i], f0[i]);

            }
            return result;
        }

        public static double[] SpikesFunction(double m, double[] y, double sigma)
        {
            for (int i = 0; i < m; i++)
            {
                int index = rnd.Next(0, y.Length - 1);
                int sign = rnd.Next(0, 2);
                int n = y.Length;
                double aSmin = n * 10 * sigma;
                double aSmax = (n + 1) * 10 * sigma;

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
                    Rei += y[k] * Math.Sin((Math.PI * 2 * i * k) / n);
                }
                Rei = Rei / n;
                Imi = Imi / n;
                res[i] = Math.Sqrt(Math.Pow(Rei, 2) + Math.Pow(Imi, 2));
            }
            return res;
        }

        public static double HeartBeatFunction(double x, double f0, double alpha)
        {

            return Math.Sin(2 * Math.PI * f0 * x) * Math.Pow(Math.E,-alpha*x);
        }
        public static double[] ConvolutionFunction(double[] h, double [] y  )
        {
            int n = y.Length;
            int m = h.Length;
            double[] res = new double[n+m];
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


    }
}
