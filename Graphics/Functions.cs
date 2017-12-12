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


        public static double RandomFunction(double x, double low, double high)
        {

            double d;

            d =low + rnd.NextDouble() * (high - low);

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
        public static double HeartBeatFunction(double x, double f0, double alpha)
        {

            return Math.Sin(2 * Math.PI * f0 * x) * Math.Pow(Math.E,-alpha*x);
        }





    }
}
