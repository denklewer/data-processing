﻿using System;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Graphics.util
{
    public class Transformations
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



        public static Complex[] ReverseFurie(double[] y)
        {

            int n = y.Length;
            Complex[] res = new Complex[n];
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

                Complex result = new Complex(Rei, Imi);


                res[i] = result;
            });

            return res;
        }

        public static Complex[] ForwardFurie(double[] y)
        {
            int n = y.Length;
            Complex[] res = new Complex[n];
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

                Complex result = new Complex(Rei, Imi);

                res[i] = result;

            });

            return res;
        }

        public static Complex[][] Forward2DFurie(double[][] y)
        {
            int n1 = y.Length;
            Complex[][] res = new Complex[n1][];
            int n = y[0].Length;
            for (int j = 0; j < y.Length; j++)
            {
                res[j] = new Complex[n];

                Parallel.For(0, n, i =>
                {

                    double Rei = 0;
                    for (int k = 0; k < n; k++)
                    {
                        Rei += y[j][k] * Math.Cos((Math.PI * 2 * i * k) / n);
                    }
                    double Imi = 0;
                    for (int k = 0; k < n; k++)
                    {
                        Imi += y[j][k] * Math.Sin((Math.PI * 2 * i * k) / n);
                    }

                    Complex result = new Complex(Rei, Imi);


                    res[j][i] = result;
                });

            }


            return res;
        }


        public static Complex[][] Reversed2DFurie(double[][] y)
        {
            int n1 = y.Length;
            Complex[][] res = new Complex[n1][];
            int n = y[0].Length;
            for (int j = 0; j < y.Length; j++)
            {

                Parallel.For(0, n, i =>
                {

                    double Rei = 0;
                    for (int k = 0; k < n; k++)
                    {
                        Rei += y[j][k] * Math.Cos((Math.PI * 2 * i * k) / n);
                    }
                    double Imi = 0;
                    for (int k = 0; k < n; k++)
                    {
                        Imi += y[j][k] * Math.Sin((Math.PI * 2 * i * k) / n);
                    }
                    Rei = Rei / n;
                    Imi = Imi / n;

                    Complex result = new Complex(Rei, Imi);

                    res[j][i] = result;

                });

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
        public static double[] ConvolutionWithHeartBeat(double[] x, double f0, double alpha, double hLeft, double hRight, double hStep, double dt)
        {
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

        public static double[] AntiRandomFunction(double left, double right, double step, double[] y, double A, double F, double CanalsCount)
        {
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

        public static double[] AddRandom(double[] y, double a)
        {
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
        public static double[] CutX(double[] x, int start, int end)
        {


            return x.Skip(start).Take(end - start).ToArray();


        }
        public static double[] CutY(double[] y, int start, int end)
        {
            return y.Skip(start).Take(end - start).ToArray();


        }



        // TODO: проверить
        public static double[] AvgSlidingWindow(double[] y, int width)
        {
            for (int i = 0; i < y.Length - width; i++)
            {
                y[i] = y[i] - Statistics.ExpectedValue(y.Skip(i).Take(width).ToArray());

            }
            for (int i = y.Length - width; i < y.Length; i++)
            {
                y[i] = y[i] - Statistics.ExpectedValue(y.Skip(i).Take(y.Length - i).ToArray());
            }
            return y;

        }



        public static double[] Lpf(double fcut, int m, double dt)
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
            for (int i = 0; i <= m; i++)
            {
                result[m + i] = lpw[i];
            }
            return result;
        }
        //низкочастотный фильтр
        public static double[] LpfX(int m)
        {
            double[] x = new double[2 * m + 1];
            for (int i = 0; i < 2 * m + 1; i++)
            {
                x[i] = i;
            }
            return x;
        }


        //высокочастотный фильтр
        public static double[] Hpf(double fcut, int m, double dt)
        {
            double[] lpw = Lpf(fcut, m, dt);
            for (int k = 0; k < lpw.Length; k++)
            {
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


        //гребенчатый фильтр
        public static double[] CombFilter(double[] x, double g, int M)
        {
            double[] y = new double[x.Length];
            /*for (int i = 0; i < y.Length; i++)
            {
                y[i] = (1+g*Math.Pow(i,(-M)))*x[i];
            }*/
            for (int i = 0; i < M; i++)
            {
                y[i] = x[i];
            }
            for (int i = M; i < x.Length; i++)
            {
                y[i] = x[i] - g * y[i - M];

            }

            return y;
        }



        /// <summary>
        /// 
        ///универсальный  фильтр позволяет  реализовать гребенчатый фильтр, фазовый фильтр, delay фильр
        ///        
        /// Представляет собой фазовый фильтр с оператором  задержки на M сэмплов. и дополнительным множителем FF.
        /// FIR Comb - гребенчатый, в котором задержанный сигнал добавляется к входному с каким-то коэфициентом FF.
        /// IIR Comb - входной сигнал циркулирует в задерживаемой строке, которая потом снова складывается с входным сигналом.
        /// перед каждым сложением - уменьшение c коэф FB (циклично)
        /// 
        /// Allpass - BL - a , FB -a FF 1.
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="BL">blend 1 если гребенчатый , FB(a) если Allpass</param>
        /// <param name="FF">feedforward g  если FIR, 0 если IIR, 1 если allpass или delay</param>
        /// <param name="FB">feedbackward g если  IIR  -a если allpass, иначе 0</param>
        /// <param name="M">задержка</param>
        /// <returns></returns>
        public static double[] UniversalCombFilter(double[] x, double BL, double FB, double FF, int M)
        {
            /*BL = 0.5;
            FB = -0.5;
            FF = 1;
            M = 10;*/

            double[] y = new double[x.Length];
            /*for (int i = 0; i < y.Length; i++)
            {
                y[i] = (1+g*Math.Pow(i,(-M)))*x[i];
            }*/
            double xh;
            Queue<double> delayLine = new Queue<double>();

            for (int i = 0; i < M; i++)
            {

                delayLine.Enqueue(0.0);
            }
            for (int i = 0; i < x.Length; i++)
            {
                xh = x[i] + FB * delayLine.Peek();
                y[i] = FF * delayLine.Peek() + BL * xh;
                delayLine.Dequeue();
                delayLine.Enqueue(xh);
            }
            return y;
        }



        /// <summary>
        /// Фильтр шрёдера
        /// </summary>
        /// <param name="x">входной сигнал</param>
        /// <param name="cg">массив потерь для гребенчатых фильтров</param>
        /// <param name="cd">массив задержек для гребенчатых сильтров</param>
        /// <param name="ag">массив потерь для фазовых фильтров</param>
        /// <param name="ad">массив задержек для фазовых фильров</param>
        /// <param name="k">ослабление для оригинального вектора</param>
        /// <returns></returns>
        public static double[] ShroederFilter(double[] x, double[] cg, int[] cd, double ag, int[] ad, double k)
        {
            double[][] cbres = new double[cg.Length][];
            for (int i = 0; i < cg.Length; i++)
            {
                cbres[i] = Transformations.UniversalCombFilter(x, 1, cg[i], 0, cd[i]);
            }
            double[] combres = new double[cbres[0].Length];
            for (int i = 0; i < combres.Length; i++)
            {
                for (int j = 0; j < cbres.Length; j++)
                {
                    combres[i] += cbres[j][i];
                }
            }
            double[] res = combres;
            for (int i = 0; i < ad.Length; i++)
            {
                res = Transformations.UniversalCombFilter(res, ag, -ag, 1, ad[0]);
            }
            for (int i = 0; i < x.Length; i++)
            {
                res[i] += k * x[i];
            }

            return Transformations.Normalize(res);
        }




        public static double[] ConwolutionWithLpf(double[] x, double fcut, double m, double dt)
        {

            double[] h = Transformations.Lpf(fcut, (int)m, dt);

            double[] res = Transformations.ConvolutionFunction(h, x);
            return res;
        }

        public static double[] ConvolutionWithPlot(double[] x, double[] h)
        {
            /*
                        alglib.complex[] f;
                        alglib.complex[] hc;
                        double[] x2;
                        alglib.complex[] res;
                        alglib.fftr1d(x, out f);
                        alglib.fftr1d(h, out hc);



                        alglib.convc1d(f, f.Length, hc, hc.Length, out res);



                        alglib.fftr1dinv(res, out x2);
                        x2 = x2.Take(x.Length).ToArray();
                        double max = 0;

                        if (Math.Abs(x2.Max()) > Math.Abs(x2.Min())) {
                            max = Math.Abs(x2.Max());
                        }
                        else {
                            max = Math.Abs(x2.Min());
                        }


                       for (int i = 0; i < x2.Length; i++)
                       {
                           x2[i] = x2[i] / max;

                       }

                        // double[] res = Transformations.ConvolutionFunction(h, x);
                        return x2;*/

            return ConvolutionFunction(h, x);
        }

        public static double[] Normalize(double[] x)
        {
            double min = x.Min();
            double max = x.Max();
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = (x[i] / (max - min));
            }

            return x;
        }



        public static double[] ConwolutionWithHpf(double[] x, double fcut, double m, double dt)
        {

            double[] h = Transformations.Hpf(fcut, (int)m, dt);

            double[] res = Transformations.ConvolutionFunction(h, x);
            return res;
        }


        public static double[] ConwolutionWithBpf(double[] x, double fcut1, double fcut2, double m, double dt)
        {

            double[] h = Transformations.Bpf(fcut1, fcut2, (int)m, dt);

            double[] res = Transformations.ConvolutionFunction(h, x);
            return res;
        }

        public static double[] ConwolutionWithBsf(double[] x, double fcut1, double fcut2, double m, double dt)
        {

            double[] h = Transformations.Bsf(fcut1, fcut2, (int)m, dt);

            double[] res = Transformations.ConvolutionFunction(h, x);
            return res;
        }



        public static double[][] ZoomKnearest(double[][] x, double k)
        {
            int width = x.Length;
            int height = x[0].Length;

            int newWidth = (int)(x.Length * k);
            int newHeight = (int)(x[0].Length * k);

            double[][] result = new double[newWidth][];


            for (int i = 0; i < newWidth; i++)
            {
                result[i] = new double[newHeight];
                for (int j = 0; j < newHeight; j++)
                {
                    int srcX = (int)(i / k);
                    int srcY = (int)(j / k);
                    srcX = Math.Min(srcX, width - 1);
                    srcY = Math.Min(srcY, height - 1);
                    result[i][j] = x[srcX][srcY];
                }

            }
            return result;



        }


        public static double[][] ZoomInterpilation(double[][] x, double k)
        {
            int width = x.Length;
            int height = x[0].Length;

            int newWidth = (int)(x.Length * k);
            int newHeight = (int)(x[0].Length * k);

            double[][] result = new double[newWidth][];

            double u;
            double tmp;
            double t;
            int w, h;
            double d1, d2, d3, d4;
            double p1, p2, p3, p4;


            for (int i = 0; i < newWidth; i++)
            {
                result[i] = new double[newHeight];

                tmp = (double)i / (newWidth - 1) * (width - 1);

                w = (int)(tmp);

                if (w < 0)
                {
                    w = 0;
                }
                else
                {
                    if (w >= width - 1) w = width - 2;
                }

                t = tmp - w;

                for (int j = 0; j < newHeight; j++)
                {
                    tmp = (double)j / (newHeight - 1) * (height - 1);
                    h = (int)tmp;
                    if (h < 0)
                    {
                        h = 0;
                    }
                    else
                    {
                        if (h >= height - 1) h = height - 2;
                    }
                    u = tmp - h;

                    d1 = (1 - t) * (1 - u);
                    d2 = t * (1 - u);
                    d3 = t * u;
                    d4 = (1 - t) * u;


                    p1 = x[w][h];

                    p2 = x[w + 1][h];

                    p3 = x[w + 1][h + 1];

                    p4 = x[w][h + 1];


                    result[i][j] = p1 * d1 + p2 * d2 + p3 * d3 + p4 * d4;
                }

            }
            return result;



        }

        public static double[][] Negative(double[][] x, double Lmax)
        {
            int width = x.Length;
            int height = x[0].Length;


            // double[][] result = new double[width][];


            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {

                    x[i][j] = Lmax - 1 - x[i][j];
                }

            }
            return x;



        }

        public static double[][] GammaCorrection(double[][] x, double C, double gamma)
        {
            int width = x.Length;
            int height = x[0].Length;


            // double[][] result = new double[width][];


            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {

                    x[i][j] = C * Math.Pow(x[i][j], gamma);
                }

            }
            return x;
        }


        public static double[][] Logarithmic(double[][] x, double C)
        {
            int width = x.Length;
            int height = x[0].Length;


            // double[][] result = new double[width][];


            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {

                    x[i][j] = C * Math.Log10(x[i][j] + 1);
                }
            }
            return x;
        }




        static double[] readHex(string filename)
        {





            BinaryReader reader = new BinaryReader(new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None));
            reader.BaseStream.Position = 0x0;     // The offset you are reading the data from
            string[] splitted = filename.Split('\\');

            Regex regex = new Regex(@"\d+");
            Match match = regex.Match(splitted.Last());
            double[] data = new double[1000];
            if (match.Success)
            {
                int len = int.Parse(match.Value);
                data = new double[len];
                for (int i = 0; i < len; i++)
                {
                    data[i] = reader.ReadSingle();
                }
                reader.Close();
            }
            return data;

        }

        static string curFileName;
        public static double[][] readHex2D(string filename, int width, int height)
        {
            curFileName = filename;
            BinaryReader reader = new BinaryReader(new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None));
            reader.BaseStream.Position = 0x0;     // The offset you are reading the data from
            double[][] data = new double[width][];
            /*for (int i = 0; i < height; i++)
            {
                data[i] = new double[width];
            }*/


            for (int i = 0; i < width; i++)
            {
                data[i] = new double[height];
                for (int j = 0; j < height; j++)
                {
                    //data[i] = new double[height];

                    data[i][j] = reader.ReadSingle();

                }

            }

            reader.Close();

            return data;

        }

        public static double[][] recovery(double[][] f, string Hfilename)
        {
            //  f = readHex2D(filename, f.Length, f[0].Length);

            double[] h = readHex(Hfilename);
            double[] complementedH = new double[f[0].Length];


            Array.Copy(h, complementedH, h.Length);
            for (int i = h.Length; i < complementedH.Length; i++)
            {
                complementedH[i] = 0;
            }

            Complex[] H = ForwardFurie(complementedH);

            f = f.Select(row => ForwardFurie(row).Select((x, index) => x / H[index])
                                                 .Select(x => x.Imaginary + x.Real)
                                                 .ToArray())
                 .Select(row => ReverseFurie(row).Select(x => x.Real + x.Imaginary)
                                                 .ToArray())
                 .ToArray();

            return f;
        }

        public static double[][] Rotate(double[][] f)
        {
            //  f = readHex2D(filename, f.Length, f[0].Length);
            double[][] result = new double[f[0].Length][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new double[f.Length];
            }

            for (int i = 0; i < f.Length; i++)
            {

                for (int j = 0; j < f[i].Length; j++)
                {

                    result[j][i] = f[i][j];

                }
            }
            return result;
        }

        public static double[] Derivative(double[] f)
        {
            double[] result = new double[f.Length];
            for (int i = 0; i < result.Length - 1; i++)
            {
                result[i] = f[i + 1] - f[i];

            }

            return result;
        }


        public static double[][] RemoveGrid(double[][] f, double freq1, double freq2, double m)
        {
            //  f = readHex2D(filename, f.Length, f[0].Length);
            double[][] result = new double[f.Length][];
            double[] tmp;



            for (int i = 0; i < f.Length; i++)
            {
                tmp = Derivative(f[i]);
                //  double dT = 1.0 / f[i].Length;
                tmp = Transformations.ConwolutionWithBsf(f[i], freq1, freq2, m, 1).Skip((int)m).Take(f[i].Length).ToArray();
                result[i] = tmp;


            }
            return result;
        }

        public static double[] CheckGrid(double[] f)
        {
            double[] result = Derivative(f);


            for (int i = 0; i < f.Length; i++)
            {
                result[i] = Autocorrelation(f, i);
            }

            // result = Transformations.ForwardFurie(result).Select(x => x.Imaginary + x.Real).ToArray();

            new MainWindow(result).Show();

            return result;
        }



        public static double[][] CheckGridWithCross(double[][] f, int row1, int row2)
        {

            // result = Transformations.ForwardFurie(result).Select(x => x.Imaginary + x.Real).ToArray();

            new MainWindow(Derivative(f[row1]), Derivative(f[row2])).Show();

            return f;
        }

        public static double[][] ThresholdFun(double[][] f, double min_threshold, double max_threshold, int depth = 8)
        {

            //double[] mass = f.SelectMany(x => x).ToArray();



            for (int i = 0; i < f.Length; i++)
            {
                for (int j = 0; j < f[i].Length; j++)
                {

                    int value = (int)f[i][j];
                    if (value < min_threshold)
                    {
                        value = 0;
                        f[i][j] = value;
                    }
                    else if (value >= max_threshold)
                    {
                        value = (1 << depth) - 1;
                        f[i][j] = value;
                    }
                }
            }
            return f;

        }

        /// <summary>
        /// Calculates threshold function in the sliding window with length  f.Length / count
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static double[][] ThresholdFunDynamic(double[][] f, int count, int depth = 8)
        {
            int strideX = f.Length / count;
            int strideY = f[0].Length / count;
            double[][] result = new double[f.Length][];
            for (int i = 0; i < f.Length; i++)
            {
                result[i] = new double[f[i].Length];
                for (int j = 0; j < f[i].Length; j++)
                {
                    int maxMi = strideX / 2;
                    int maxMj = strideY / 2;

                    //New fast version. values appeared from the commented code bellow ( aguments of skip and take when calculating submatrixes
                    int startiF = i - maxMi;
                    int endiF = startiF + (i >= maxMi ? strideX : i + maxMi + 1);
                    int startjF = j - maxMj;
                    int endjF = startjF + (j >= maxMj ? strideY : j + maxMj + 1);

                    int startiM = i < maxMi ? maxMi - i : 0;
                    int endiM = startiM + i + maxMi >= f.Length ? f.Length - i + 1 : strideX;
                    int startjM = j < maxMj ? maxMj - j : 0;
                    int endjM = startjM + j + maxMj >= f[i].Length ? f[i].Length - j + 1 : strideY;
                    startiF = EnsureValueIsPositive(startiF);
                    startjF = EnsureValueIsPositive(startjF);
                    startjM = EnsureValueIsPositive(startjM);
                    startiM = EnsureValueIsPositive(startiM);
                    //!!!!!!!!!!!!!!!!!!! Warning do not remove!!!!!!!!!!!!!!!!!!!!!!!
                    //!!!! Previous versioin of code : for demonstation of variable values above!!!!!!
                    /*  double[][] range = f.Skip(i - maxMi)
                     *                      .Take(i >= maxMi ? mask.Length : i + maxMi + 1)
                     *                      .Select(x => x.Skip(j - maxMj)
                     *                                    .Take(j >= maxMj ? mask[0].Length : j + maxMj + 1)
                     *                                    .ToArray())
                     *                                    .ToArray();
                     *                                    
                     *  double[][] maskRange = mask.Skip(i < maxMi ? maxMi - i : 0)                     
                     *                             .Take(i + maxMi >= f.Length ? f.Length - i + 1 : mask.Length)
                     *                             .Select(x => x.Skip(j < maxMj ? maxMj - j : 0)
                     *                                           .Take(j + maxMj >= f[i].Length ? f[i].Length - j + 1 : mask[0].Length)
                     *                                           .ToArray())
                     *                             .ToArray();*
                     *  for (int mi = 0; mi < maskRange.Length; mi++)
                     *  {
                     *      for (int mj = 0; mj < maskRange[mi].Length; mj++)
                     *      {
                     *          sum += range[mi][mj] * maskRange[mi][mj];
                     *      }
                     *  }
                     */
                    //!!!!!!!!!!!!!!!!!!! end of demo code!!!!!!!!!!!!!!!!!!!!!!!

                    double dynamicMax = f[i][j];
                    double dynamicMin = f[i][j];
                    int ind1 = 0;
                    int ind2 = 0;


                    for (int mi = startiM; mi < endiM; mi++)
                    {
                        for (int mj = startjM; mj < endjM; mj++)
                        {
                            if (f[startiF + ind1][startjF + ind2] < dynamicMin)
                            {
                                dynamicMin = f[startiF + ind1][startjF + ind2];
                            }

                            if (f[startiF + ind1][startjF + ind2] > dynamicMax)
                            {
                                dynamicMax = f[startiF + ind1][startjF + ind2];
                            }

                            ind2++;
                        }
                        ind2 = 0;
                        ind1++;
                    }

                    if (f[i][j] > (dynamicMax - dynamicMin) / 2)
                    {

                        result[i][j] = dynamicMax; ;
                    }
                    else
                    {
                        result[i][j] = dynamicMin;

                    }

                }
            }
            return result;
        }


        public static double[][] Minus(double[][] arr1, double[][] arr2)
        {
            double[][] result = new double[arr1.Length][];

            for (int i = 0; i < arr1.Length; i++)
            {
                result[i] = new double[arr1[i].Length];
                for (int j = 0; j < arr1[i].Length; j++)
                {
                    int x = (int)arr1[i][j] - (int)arr2[i][j];
                    if (x < 0)
                    {
                        x = 0;

                    }
                    result[i][j] = x;
                }


            }


            return result;

        }


        public static double[][] Plus(double[][] arr1, double[][] arr2)
        {
            double[][] result = new double[arr1.Length][];

            for (int i = 0; i < arr1.Length; i++)
            {
                result[i] = new double[arr1[i].Length];
                for (int j = 0; j < arr1[i].Length; j++)
                {
                    int x = (int)arr1[i][j] + (int)arr2[i][j];
                    if (x > 255)
                    {
                        x = 255;

                    }
                    result[i][j] = x;
                }


            }


            return result;

        }


        public static double[][] MultiColorPlus(double[][] arr1, double[][] arr2)
        {
            double[][] result = new double[arr1.Length][];

            for (int i = 0; i < arr1.Length; i++)
            {
                result[i] = new double[arr1[i].Length];
                for (int j = 0; j < arr1[i].Length; j++)
                {
                    int x = (int)arr1[i][j] + (int)arr2[i][j];
                    if (arr1[i][j] < 0) {
                        x = (int)arr1[i][j];
                    }
                    if (arr2[i][j] < 0)
                    {
                        x = (int)arr2[i][j];
                    }

                    if (x > 255)
                    {
                        x = 255;

                    }
                    result[i][j] = x;
                }


            }


            return result;

        }





        public static double[][] LPF(double[][] f, double fcut, double m)
        {
            double[][] result = new double[f.Length][];

            for (int i = 0; i < f.Length; i++)
            {
                result[i] = new double[f[i].Length];

                result[i] = Transformations.ConwolutionWithLpf(f[i], fcut, m, 1).Skip((int)m).Take(f[i].Length).ToArray();


            }

            return result;

        }
        public static double[][] HPF(double[][] f, double fcut, double m)
        {
            double[][] result = new double[f.Length][];

            for (int i = 0; i < f.Length; i++)
            {
                result[i] = new double[f[i].Length];
                result[i] = Transformations.ConwolutionWithHpf(f[i], fcut, m, 1).Skip((int)m).Take(f[i].Length).ToArray();
                result[i] = result[i].Select(x => x < 0 ? 0 : x).ToArray();


            }




            return result;

        }

        public static double Maximum(double[][] f)
        {
            double max = int.MinValue;
            double tmp;

            for (int i = 0; i < f.Length; i++)
            {
                tmp = f[i].Max();
                if (tmp > max)
                {
                    max = tmp;
                }


            }
            return max;


        }
        public static double Minimum(double[][] f)
        {
            double max = int.MaxValue;
            double tmp;

            for (int i = 0; i < f.Length; i++)
            {
                tmp = f[i].Min();
                if (tmp < max)
                {
                    max = tmp;
                }


            }
            return max;


        }
        public static double[][] ConturLPF(double[][] f, double thresshold, double fcut, double m)
        {


            double[][] thresholded = ThresholdFun(f, thresshold, 255);
            double[][] minused = Minus(LPF(thresholded, fcut, m), thresholded);
            return ThresholdFun(minused, 128, 255);



        }



        public static double Crosscorrelation(double[] arr1, double[] arr2, int lag)
        {
            if (arr1.Length != arr2.Length)
            {
                throw new Exception("Lengths of function arrays are different");
            }
            double avg1 = Statistics.ExpectedValue(arr1);
            double avg2 = Statistics.ExpectedValue(arr2);
            double variance = Statistics.Variance(arr1);
            double sum = 0;

            for (int i = 0; i < arr2.Length - lag; i++)
            {
                sum += (arr1[i] - avg1) * (arr2[i + lag] - avg2);
            }
            return sum / ((arr1.Length - lag) * variance);

        }
        public static double Autocorrelation(double[] arr, int lag)
        {

            return Crosscorrelation(arr, arr, lag);
        }










        public static double[][] RecoveryWithNoize(double[][] f, string Hfilename, double regularization)
        {
            //  f = readHex2D(filename, f.Length, f[0].Length);

            double[] h = readHex(Hfilename);
            double[] complementedH = new double[f[0].Length];




            Array.Copy(h, complementedH, h.Length);
            for (int i = h.Length; i < complementedH.Length; i++)
            {
                complementedH[i] = 0;
            }



            Complex[] H = ForwardFurie(complementedH);


            f = f.Select(row => ForwardFurie(row).Select((x, index) =>
            {
                Complex rez = x * Complex.Conjugate(H[index]) / (Math.Pow(Complex.Abs(H[index]), 2) + Math.Pow(regularization, 2));
                return rez;
            })
                                                 .Select(x => x.Imaginary + x.Real)
                                                 .ToArray())
                 .Select(row => ReverseFurie(row).Select(x => x.Real + x.Imaginary)
                                                 .ToArray())
                 .ToArray();

            return f;
        }
        public static int EnsureValueIsPositive(int val)
        {
            if (val < 0)
            {
                return 0;
            }
            return val;
        }

        /// <summary>
        ///  Applies mask to picture by summing each element of mask size range with coefficients from mask.
        /// </summary>
        /// <param name="f"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public static double[][] ApplyMask(double[][] f, double[][] mask)
        {
            double[][] result = new double[f.Length][];
            for (int i = 0; i < f.Length; i++)
            {
                result[i] = new double[f[i].Length];
                for (int j = 0; j < f[i].Length; j++)
                {
                    int maxMi = (int)mask.Length / 2;
                    int maxMj = (int)mask[0].Length / 2;

                    //New fast version. values appeared from the commented code bellow ( aguments of skip and take when calculating submatrixes
                    int startiF = i - maxMi;
                    int endiF = startiF + (i >= maxMi ? mask.Length : i + maxMi + 1);
                    int startjF = j - maxMj;
                    int endjF = startjF + (j >= maxMj ? mask[0].Length : j + maxMj + 1);

                    int startiM = i < maxMi ? maxMi - i : 0;
                    int endiM = startiM + i + maxMi >= f.Length ? f.Length - i + 1 : mask.Length;
                    int startjM = j < maxMj ? maxMj - j : 0;
                    int endjM = startjM + j + maxMj >= f[i].Length ? f[i].Length - j + 1 : mask[0].Length;
                    startiF = EnsureValueIsPositive(startiF);
                    startjF = EnsureValueIsPositive(startjF);
                    startjM = EnsureValueIsPositive(startjM);
                    startiM = EnsureValueIsPositive(startiM);
                    //!!!!!!!!!!!!!!!!!!! Warning do not remove!!!!!!!!!!!!!!!!!!!!!!!
                    //!!!! Previous versioin of code : for demonstation of variable values above!!!!!!
                    /*  double[][] range = f.Skip(i - maxMi)
                     *                      .Take(i >= maxMi ? mask.Length : i + maxMi + 1)
                     *                      .Select(x => x.Skip(j - maxMj)
                     *                                    .Take(j >= maxMj ? mask[0].Length : j + maxMj + 1)
                     *                                    .ToArray())
                     *                                    .ToArray();
                     *                                    
                     *  double[][] maskRange = mask.Skip(i < maxMi ? maxMi - i : 0)                     
                     *                             .Take(i + maxMi >= f.Length ? f.Length - i + 1 : mask.Length)
                     *                             .Select(x => x.Skip(j < maxMj ? maxMj - j : 0)
                     *                                           .Take(j + maxMj >= f[i].Length ? f[i].Length - j + 1 : mask[0].Length)
                     *                                           .ToArray())
                     *                             .ToArray();*
                     *  for (int mi = 0; mi < maskRange.Length; mi++)
                     *  {
                     *      for (int mj = 0; mj < maskRange[mi].Length; mj++)
                     *      {
                     *          sum += range[mi][mj] * maskRange[mi][mj];
                     *      }
                     *  }
                     */
                    //!!!!!!!!!!!!!!!!!!! end of demo code!!!!!!!!!!!!!!!!!!!!!!!

                    double sum = 0;

                    int ind1 = 0;
                    int ind2 = 0;

                    for (int mi = startiM; mi < endiM; mi++)
                    {
                        for (int mj = startjM; mj < endjM; mj++)
                        {
                            sum += f[startiF + ind1][startjF + ind2] * mask[mi][mj];
                            ind2++;
                        }
                        ind2 = 0;
                        ind1++;
                    }
                    result[i][j] = sum;
                }
            }
            return result;
        }




        public static double[][] AvgFilter(double[][] f, int maskWidth)
        {

            double[][] result = new double[f.Length][];
            for (int i = 0; i < f.Length; i++)
            {
                result[i] = new double[f[i].Length];
                //++
                for (int j = 0; j < f[i].Length; j++)
                {
                    int maxMi = (int)maskWidth / 2;
                    int maxMj = (int)maskWidth / 2;
                    double[][] range = f.Skip(i - maxMi).Take(i >= maxMi ? maskWidth : i + maxMi + 1)
                        .Select(x => x.Skip(j - maxMj).Take(j >= maxMj ? maskWidth : j + maxMj + 1).ToArray())
                        .ToArray();

                    double avg = range.SelectMany(x => x).Average();

                    result[i][j] = avg;

                }

            }
            return result;
        }

        public static double[][] MedianFilter(double[][] f, int maskWidth)
        {

            double[][] result = new double[f.Length][];
            for (int i = 0; i < f.Length; i++)
            {
                result[i] = new double[f[i].Length];
                //++
                for (int j = 0; j < f[i].Length; j++)
                {
                    int maxMi = (int)maskWidth / 2;
                    int maxMj = (int)maskWidth / 2;
                    double[][] range = f.Skip(i - maxMi).Take(i >= maxMi ? maskWidth : i + maxMi + 1)
                        .Select(x => x.Skip(j - maxMj).Take(j >= maxMj ? maskWidth : j + maxMj + 1).ToArray())
                        .ToArray();

                    double[] values = range.SelectMany(x => x).OrderBy(x => x).ToArray();
                    result[i][j] = values[values.Length / 2];

                }

            }
            return result;
        }

        public static double[][] Gradient(double[][] f)
        {

            double[][] horMask = new double[3][] { new double[3] { -1, -2, -1 }, new double[3] { 0, 0, 0 }, new double[3] { 1, 2, 1 } };
            double[][] vertMask = new double[3][] { new double[3] { -1, 0, 1 }, new double[3] { -2, 0, 2 }, new double[3] { -1, 0, 1 } };
            double[][] diagMask = new double[3][] { new double[3] { 0, 1, 1 }, new double[3] { -1, 0, 1 }, new double[3] { -1, -1, 0 } };
            double[][] diagMaskReversed = new double[3][] { new double[3] { 1, 1, 0 }, new double[3] { 1, 0, -1 }, new double[3] { 0, -1, -1 } };

            double[][] Horizontal = ApplyMask(f, horMask);
            double[][] Vertical = ApplyMask(f, vertMask);
            double[][] Diagonal = ApplyMask(f, diagMask);
            double[][] DiagonalRev = ApplyMask(f, diagMaskReversed);




            double tmp;
            for (int i = 0; i < f.Length; i++)
            {
                for (int j = 0; j < f[i].Length; j++)
                {
                    tmp = Horizontal[i][j] + Vertical[i][j] + Diagonal[i][j] + DiagonalRev[i][j];
                    if (tmp < 0)
                    {
                        tmp = 0;
                    }

                    f[i][j] = tmp;

                }

            }
            return f;

        }

        public static double[][] Laplassian(double[][] f)
        {

            double[][] horMask = new double[3][] { new double[3] { -1, -1, -1 }, new double[3] { -1, 8, -1 }, new double[3] { -1, -1, -1 } };

            double[][] Horizontal = ApplyMask(f, horMask);

            double tmp;
            for (int i = 0; i < f.Length; i++)
            {
                for (int j = 0; j < f[i].Length; j++)
                {
                    tmp = Horizontal[i][j];
                    if (tmp < 0)
                    {
                        tmp = 0;
                    }

                    f[i][j] = tmp;

                }

            }
            return f;

        }



        public static double[][] ApplyMaskErosion(double[][] f, int maskWidth, double threshold)
        {
            double[][] result = new double[f.Length][];
            int maxMi = (int)maskWidth / 2;
            int maxMj = (int)maskWidth / 2;
            for (int i = 0; i < f.Length; i++)
            {
                result[i] = new double[f[i].Length];
                //++
                for (int j = 0; j < f[i].Length; j++)
                {
                    double value = f[i][j];
                    if (i >= maxMi && i < f.Length - maxMi && j >= maxMj && j < f[i].Length - maxMj)
                    {
                        double[][] range = f.Skip(i - maxMi).Take(maskWidth)
                            .Select(x => x.Skip(j - maxMj).Take(maskWidth).ToArray())
                            .ToArray();
                        bool needToDelete = false;


                        for (int mi = 0; mi < range.Length; mi++)
                        {
                            for (int mj = 0; mj < range[mi].Length; mj++)
                            {
                                if (range[mi][mj] < threshold)
                                {
                                    needToDelete = true;

                                }
                            }
                        }

                        if (needToDelete)
                        {
                            double min = Minimum(range);

                            value = min;
                        }
                    }
                    result[i][j] = value;
                }
            }
            return result;
        }

        public static double[][] ApplyMaskDilatation(double[][] f, int maskWidth, double threshold)
        {
            double[][] result = new double[f.Length][];
            int maxMi = (int)maskWidth / 2;
            int maxMj = (int)maskWidth / 2;
            for (int i = 0; i < f.Length; i++)
            {
                result[i] = new double[f[i].Length];
                //++
                for (int j = 0; j < f[i].Length; j++)
                {
                    double value = f[i][j];
                    if (i >= maxMi && i < f.Length - maxMi && j >= maxMj && j < f[i].Length - maxMj)
                    {
                        double[][] range = f.Skip(i - maxMi).Take(maskWidth)
                            .Select(x => x.Skip(j - maxMj).Take(maskWidth).ToArray())
                            .ToArray();




                        bool needToAdd = false;


                        for (int mi = 0; mi < range.Length; mi++)
                        {
                            for (int mj = 0; mj < range[mi].Length; mj++)
                            {
                                if (range[mi][mj] > threshold)
                                {
                                    needToAdd = true;
                                }
                            }
                        }

                        if (needToAdd)
                        {
                            double max = Maximum(range);

                            value = max;
                        }
                    }
                    result[i][j] = value;
                }
            }
            return result;
        }







        public static double[][] ApplyRandNoize(double[][] f, double power)
        {
            Random rnd = new Random(f.Length);
            double[][] result = new double[f.Length][];
            double rndValue;

            int min = (int)Minimum(f);


            int max = (int)Maximum(f);

            if (max - min < 128)
            {
                min = 0;
                max = 255;
            }

            for (int i = 0; i < f.Length; i++)
            {
                result[i] = new double[f[i].Length];
                for (int j = 0; j < f[i].Length; j++)
                {
                    rndValue = rnd.NextDouble();


                    if (rndValue < power)
                    {
                        int rndVal = rnd.Next(-30, 31);
                        //TODO: Min and MAX?
                        result[i][j] = f[i][j] + rndVal > 255 ? 255 : ((f[i][j] < 0) ? 0 : rndVal + f[i][j]);
                    }
                    else
                    {
                        result[i][j] = f[i][j];
                    }

                }

            }
            return result;

        }

        public static double[][] ApplyNoizeSaltAndPepper(double[][] f, double power)
        {
            Random rnd = new Random(f.Length);
            double[][] result = new double[f.Length][];
            double rndValue;
            for (int i = 0; i < f.Length; i++)
            {
                result[i] = new double[f[i].Length];
                for (int j = 0; j < f[i].Length; j++)
                {

                    rndValue = rnd.NextDouble();


                    if (rndValue < power)
                    {
                        //TODO: Min and MAX?   
                        result[i][j] = Math.Round(rnd.NextDouble()) * 255;
                    }
                    else
                    {
                        result[i][j] = f[i][j];
                    }

                }

            }
            return result;

        }

        public static double[][] ApplyMaskedFunction(double[][] f, int maskWidth, Func<double[][], double> fromRangeFunction)
        {
            double[][] result = new double[f.Length][];
            for (int i = 0; i < f.Length; i++)
            {
                result[i] = new double[f[i].Length];
                //++
                for (int j = 0; j < f[i].Length; j++)
                {
                    int maxMi = (int)maskWidth / 2;
                    int maxMj = (int)maskWidth / 2;
                    double[][] range = f.Skip(i - maxMi).Take(i >= maxMi ? maskWidth : i + maxMi + 1)
                        .Select(x => x.Skip(j - maxMj).Take(j >= maxMj ? maskWidth : j + maxMj + 1).ToArray())
                        .ToArray();

                    result[i][j] = fromRangeFunction.Invoke(range);

                }

            }
            return result;

        }


        public static double MinimumExcept777(double[][] f)
        {
            double max = int.MaxValue;
            double tmp;

            for (int i = 0; i < f.Length; i++)
            {
                tmp = f[i].Where(x => x != -777).Min();
                if (tmp != -777 && tmp < max)
                {
                    max = tmp;
                }


            }
            return max;


        }

        public static Boolean hasNeighbourInThisList(Tuple<double, double> point, List<Tuple<double, double>> list)
        {
            foreach (Tuple<double, double> item in list)
            {
                if (Math.Abs(point.Item1 - item.Item1) <= 1 && Math.Abs(point.Item2 - item.Item2) <= 1)
                {
                    return true;
                }
            }
            return false;

        }


        public static Boolean areNeighbours(List<Tuple<double, double>> list1, List<Tuple<double, double>> list2)
        {
            foreach (Tuple<double, double> itemList1 in list1)
            {
                if (hasNeighbourInThisList(itemList1, list2))
                {
                    return true;
                }
            }
            return false;

        }
        public static int getIndex(SortedSet<int>[] sets, int value)
        {
            for (int i = 0; i < sets.Length; i++)
            {
                if (sets[i] != null)
                    if (sets[i].Contains(value))
                    {
                        return i;
                    }

            }

            return -1;

        }




        const int TRESHOLD = 114;
        /// <summary>
        /// Looks for objects wich are componnets of connectivity and has diameter  stoneSize
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static double[][] FindAreas(double[][] f, int stoneSize)
        {
            

            int counter = 0;
            int strideX = stoneSize;
            int strideY = stoneSize;
            double[][] result = new double[f.Length][];

            for (int i = 0; i < f.Length; i++)
            {
                result[i] = new double[f[i].Length];
            }

            for (int i = 0; i < f.Length; i++)
            {
              

                for (int j = 0; j < f[i].Length; j++)
                {
                    
                    int maxMi = strideX / 2;
                    int maxMj = strideY / 2;

                    //New fast version. values appeared from the commented code bellow ( aguments of skip and take when calculating submatrixes
                    int startiF = i - maxMi;
                    int endiF = startiF + (i >= maxMi ? strideX : i + maxMi + 1);
                    int startjF = j - maxMj;
                    int endjF = startjF + (j >= maxMj ? strideY : j + maxMj + 1);

                    int startiM = i < maxMi ? maxMi - i : 0;
                    int endiM = startiM + i + maxMi >= f.Length ? f.Length - i + 1 : strideX;
                    int startjM = j < maxMj ? maxMj - j : 0;
                    int endjM = startjM + j + maxMj >= f[i].Length ? f[i].Length - j + 1 : strideY;
                    startiF = EnsureValueIsPositive(startiF);
                    startjF = EnsureValueIsPositive(startjF);
                    startjM = EnsureValueIsPositive(startjM);
                    startiM = EnsureValueIsPositive(startiM);
                    //!!!!!!!!!!!!!!!!!!! Warning do not remove!!!!!!!!!!!!!!!!!!!!!!!
                    //!!!! Previous versioin of code : for demonstation of variable values above!!!!!!
                    /*  double[][] range = f.Skip(i - maxMi)
                     *                      .Take(i >= maxMi ? mask.Length : i + maxMi + 1)
                     *                      .Select(x => x.Skip(j - maxMj)
                     *                                    .Take(j >= maxMj ? mask[0].Length : j + maxMj + 1)
                     *                                    .ToArray())
                     *                                    .ToArray();
                     *                                    
                     *  double[][] maskRange = mask.Skip(i < maxMi ? maxMi - i : 0)                     
                     *                             .Take(i + maxMi >= f.Length ? f.Length - i + 1 : mask.Length)
                     *                             .Select(x => x.Skip(j < maxMj ? maxMj - j : 0)
                     *                                           .Take(j + maxMj >= f[i].Length ? f[i].Length - j + 1 : mask[0].Length)
                     *                                           .ToArray())
                     *                             .ToArray();*
                     *  for (int mi = 0; mi < maskRange.Length; mi++)
                     *  {
                     *      for (int mj = 0; mj < maskRange[mi].Length; mj++)
                     *      {
                     *          sum += range[mi][mj] * maskRange[mi][mj];
                     *      }
                     *  }
                     */
                    //!!!!!!!!!!!!!!!!!!! end of demo code!!!!!!!!!!!!!!!!!!!!!!!


                    int ind1 = 0;
                    int ind2 = 0;


                    Boolean needToProcess = true;


                    if (endjF >= f[0].Length)
                    {
                        needToProcess = false;
                        break;
                    }

                    if (endiF >= f.Length)
                    {
                        needToProcess = false;
                        break;
                    }

                    if (needToProcess)
                    {

                        for (int mi = startiM; mi < endiM; mi++)
                        {
                            for (int mj = startjM; mj < endjM; mj++)
                            {
                                int outIndI = startiF + ind1;
                                int outIndJ = startjF + ind2;


                                if (f[outIndI][outIndJ] > TRESHOLD)
                                {


                                    var component = findComponent(f,new HashSet<Tuple<int, int>>(), outIndI, outIndJ, startiF, startjF, startiF + stoneSize, startjF + stoneSize);
                                    if (component.Count > stoneSize) {
                                        if ( EnsureSeparated(f, component))
                                        {
                                            if (EnsureDistanceIsTarget(component, stoneSize) == stoneSize)
                                            {
                                                counter++;

                                                foreach (var item in component)
                                                {
                                                    result[item.Item1][item.Item2] = -f[item.Item1][item.Item2];
                                                    f[item.Item1][item.Item2] = 0;
                                                    
                                                }
                                            }
                                        }
                                    }
                                }

                                ind2++;
                            }
                            ind2 = 0;
                            ind1++;
                        }


                    }


                }
            }
            MessageBox.Show("There are " + counter + " stones! ");
            return result;
        }

   
        public static HashSet<Tuple<int, int>> findComponent(double[][] f, 
                                                             HashSet<Tuple<int, int>> tuples,  
                                                             int x, int y, int startI, 
                                                             int startJ, int stopI, int stopJ)
        {
            if (f[x][y] > TRESHOLD)
            {
                var targetTuple1 = new Tuple<int, int>(x, y);
                if (!tuples.Contains(targetTuple1))
                {
                    tuples.Add(targetTuple1);

                    if (x > startI && x> 0)
                    {
                       findComponent(f,tuples, x - 1, y, startI, startJ, stopI, stopJ);
                    }
                    if (x < stopI - 1 && y < f.Length-1)
                    {
                        findComponent(f,tuples, x + 1, y, startI, startJ, stopI, stopJ);
                    }
                    if (y > startJ && y>0)
                    {
                        findComponent(f,tuples, x, y - 1, startI, startJ, stopI, stopJ);
                    }
                    if (x < stopJ - 1 && y< f[0].Length-1)
                    {
                        findComponent(f,tuples, x, y + 1, startI, startJ, stopI, stopJ);
                    }
                }
            }
            return tuples;
        }

        public static Boolean EnsureSeparated(double[][] f, HashSet<Tuple<int, int>> tuples) {
            Boolean isSeparated = true;
            foreach (var point in tuples)
            {
                int curX = point.Item1;
                int curY = point.Item2;

                int targetX = curX;
                int targetY = curY;

                if (curX > 0)
                {
                    targetX = curX - 1;
                    Tuple<int, int> left = new Tuple<int, int>(targetX, targetY);
                    if (!tuples.Contains(left))
                    {
                        if (f[targetX][targetY] > TRESHOLD)
                        {
                             return false;
                        }
                    }
                }
                if (curX < f.Length - 1)
                {
                    targetX = curX + 1;
                    Tuple<int, int> right = new Tuple<int, int>(targetX, targetY);
                    if (!tuples.Contains(right))
                    {
                        if (f[targetX][targetY] > TRESHOLD)
                        {
                            return false;
                        }
                    }
                }
                targetX = curX;
                if (curY > 0)
                {
                    targetY = curY - 1;
                    Tuple<int, int> upper = new Tuple<int, int>(targetX, targetY);
                    if (!tuples.Contains(upper))
                    {
                        if (f[targetX][targetY] > TRESHOLD)
                        {
                            return false;
                        }
                    }
                }
                if (curY < f[0].Length - 1)
                {
                    targetY = curY + 1;
                    Tuple<int, int> bottom = new Tuple<int, int>(targetX, targetY);
                    if (!tuples.Contains(bottom))
                    {
                        if (f[targetX][targetY] > TRESHOLD)
                        {
                            return false;
                        }
                    }
                }
            }
            return isSeparated;
        }

        public static int EnsureDistanceIsTarget(HashSet<Tuple<int, int>> component, int distance)
        {
            int tmp;
            int maxDist= 0;
            int boundUp = (distance + 1) * (distance + 1);
            int boundDown = (distance - 1) * (distance - 1);

            foreach (var item1 in component)
            {
                foreach (var item2 in component)
                {
                    tmp = (item1.Item1 - item2.Item1) * (item1.Item1 - item2.Item1) + (item1.Item2 - item2.Item2) * (item1.Item2 - item2.Item2);
                    if (tmp > maxDist) {
                        maxDist = tmp;
                    }

                    if ( maxDist > boundUp)
                    {
                        return 0;
                    }


                    }

            }

            //Console.WriteLine("distance was " + tmp);
            if (maxDist > boundDown && maxDist < boundUp)
            {
                return distance;
            }
            return 0;
        }










    }
}
