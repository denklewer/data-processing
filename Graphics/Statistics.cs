using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Graphics
{
   public class Statistics
    {
        Chart chart;
        public Statistics(Chart chart)
        {
            this.chart = chart;
        }

        public double ExpectedValue(string functionName) {
            Series series = chart.Series.FindByName(functionName);
            return ExpectedValue(series.Points);
        
        }

        public double ExpectedValue(DataPointCollection arr) {
            double sum = 0;
            foreach (var point in arr)
            {

                sum += point.YValues[0];

            }
            return sum / arr.Count;
        }

        public double ExpectedValue(IEnumerable<DataPoint> arr)
        {
            double sum = 0;
            foreach (var point in arr)
            {

                sum += point.YValues[0];

            }
            return sum / arr.Count();
        }



        public double MeanSquare(string functionName) {
            Series series = chart.Series.FindByName(functionName);
            return MeanSquare(series.Points);
        }

        public double MeanSquare(DataPointCollection arr) {
            double sum = 0;
            foreach (var point in arr)
            {

                sum += Math.Pow(point.YValues[0], 2);

            }
            return sum / arr.Count;
        }
        public double MeanSquare(IEnumerable<DataPoint> arr)
        {
            double sum = 0;
            foreach (var point in arr)
            {

                sum += Math.Pow(point.YValues[0], 2);

            }
            return sum / arr.Count();
        }
        public double MeanSquareError(string functionName) {
            return Math.Sqrt(MeanSquare(functionName));
        }

        public double MeanSquareError(DataPointCollection arr)
        {
            return Math.Sqrt(MeanSquare(arr));
        }

        public double MeanSquareError(IEnumerable<DataPoint> arr)
        {
            return Math.Sqrt(MeanSquare(arr));
        }

        public double Variance(string functionName) { 
            Series series = chart.Series.FindByName(functionName);
            return Variance(series.Points);   
        }

        public double Variance(DataPointCollection arr)
        {
            double Mx = ExpectedValue(arr);
            double sum = 0;
            foreach (var point in arr)
            {

                sum += Math.Pow((point.YValues[0] - Mx), 2);

            }
            return sum / arr.Count;
        }

        public double Variance(IEnumerable<DataPoint> arr)
        {
            double Mx = ExpectedValue(arr);
            double sum = 0;
            foreach (var point in arr)
            {

                sum += Math.Pow((point.YValues[0] - Mx), 2);

            }
            return sum / arr.Count();
        }
        public double StandartDeviation(string functionName) {
            return Math.Sqrt(Variance(functionName));
        }
        public double StandartDeviation(DataPointCollection arr)
        {
            return Math.Sqrt(Variance(arr));
        }

        public double StandartDeviation(IEnumerable<DataPoint> arr)
        {
            return Math.Sqrt(Variance(arr));
        }
        public double CentralMoment(string functionName, int k) {
            double Mx = ExpectedValue(functionName);
            Series series = chart.Series.FindByName(functionName);
            double sum = 0;
            foreach (var point in series.Points)
            {

                sum += Math.Pow((point.YValues[0] - Mx), k);

            }
            return sum / series.Points.Count;
        }
        /// <summary>
        /// Коэффициент ассиметрии
        /// </summary>
        /// <param name="functionName"> Имя функции в объекте chart</param>
        /// <returns> Коэффициент ассиметрии</returns>
        public double Skewness(string functionName) {
            return CentralMoment(functionName, 3) / (Math.Pow(StandartDeviation(functionName), 3));

        }
        /// <summary>
        /// Коэффициент эксцесса
        /// </summary>
        /// <param name="functionName"> Имя функции в объекте chart</param>
        /// <returns> Коэффициент эксцесса</returns>
        public double Kurtosis(string functionName)
        {
            return CentralMoment(functionName, 4) / (Math.Pow(StandartDeviation(functionName), 4));
        }

        public double[] Density(string functionName, int M) {
            Series series = chart.Series.FindByName(functionName);
            double lMin = series.Points.Min(x=>x.YValues[0]);
            double lMax = series.Points.Max(x => x.YValues[0]);
            double divisor = (lMax - lMin) / M;
            double[] ans = new double[M];
            foreach (var point in series.Points)
            {
                try
                {
                    ans[(int)Math.Floor((point.YValues[0] - lMin) / divisor)] += 1;
                }
                catch (Exception ex) {
                    ans[ans.Length - 1] += 1;
                }
            }
            for (int i = 0; i < ans.Length; i++)
            {
                ans[i] /= series.Points.Count;
            }
            return ans;
        }

        public double Crosscorrelation(DataPointCollection arr1, DataPointCollection arr2, int lag) {
            if (arr1.Count != arr2.Count) {
                throw new Exception("Lengths of function arrays are different");
            }
            double avg1 = ExpectedValue(arr1);
            double avg2 = ExpectedValue(arr2);
            double variance = Variance(arr1);
            double sum = 0;

            for (int i = 0; i < arr2.Count-lag; i++)
            {
                sum += (arr1[i].YValues[0] - avg1) * (arr2[i + lag].YValues[0] - avg2);
            }
            return sum / ((arr1.Count - lag)*variance);

        }
        public double Autocorrelation(string functionName, int lag) {
            Series series = chart.Series.FindByName(functionName);
            return Crosscorrelation(series.Points, series.Points, lag);
        }
        public Boolean isStatic(string functionName) {
            Series series = chart.Series.FindByName(functionName);
            DataPointCollection points = series.Points;
            int shag = points.Count / 10;
            double[] means = new double[10];
            double[] meansquares = new double[10];
            double[] deviations = new double[10];
            for (int i = 0; i < 10; i++) 
            {
                means[i] = ExpectedValue(points.Skip(shag * i).Take(shag));
                meansquares[i] = MeanSquare(points.Skip(shag * i).Take(shag));
                deviations[i] = StandartDeviation(points.Skip(shag * i).Take(shag));
            }
            for (int i = 0; i < means.Length; i++)
            {
                for (int j = 0; j < means.Length; j++)
                {
                    if (means[i] / means[j] < 0.9) {
                        return false;
                    }
                    if (meansquares[i] / meansquares[j] < 0.9)
                    {
                        return false;
                    }
                    if (deviations[i] / deviations[j] < 0.9)
                    {
                        return false;
                    }

                }
            }
            return true;        
        }



















    }
}
