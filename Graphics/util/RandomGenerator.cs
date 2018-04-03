using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics.util
{
   public  class RandomGenerator
    {
        Stopwatch timer = new Stopwatch();
        List<int> list = new List<int>();
   

        public RandomGenerator()
        {
            timer.Start();
        }

        public double GenerateDouble() {
            DateTime dt = new DateTime();
             dt = DateTime.Now;


            String str = timer.ElapsedTicks.ToString();
          
            str = str.Substring(str.Length - 2);
         

            double funValue = Math.Sin(Double.Parse(str));

            dt = new DateTime();
            dt = DateTime.Now;
            str = dt.Ticks.ToString();
           str= str.Substring(str.Length - 1);
            double number = double.Parse(str) + 1;
           // funValue = (Math.PI / 2 - funValue) / (Math.PI / 2);

            str = funValue.ToString();
            if (str.Length > 5)
            {
                str = number.ToString() + str.Substring(2, 4);
            }
            funValue= Math.Abs(Math.Sin(Double.Parse(str)))-0.5;
            //rez.Add(funValue);

       
    
            return funValue;
        
           

        }
    }
}
