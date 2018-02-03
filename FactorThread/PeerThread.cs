using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FactorThread
{
    public class PeerThread
    {
        private int factorial;
        public ArrayList CalculateFactors(int number)
        {
            if (number < 3)
                return null;
            else
            {
                ArrayList factors = new ArrayList
                {
                    "1"
                };
                for (int current = 2; current <= number - 1; current++)
                {
                    if ((int)(Math.Floor((double)number / current) * current) == number)
                        factors.Add(current.ToString());
                }
                factors.Add(number.ToString());
                return factors;

            }
        }
        public ArrayList CalculateFactors()
        {
            for (int count = 1; count <=30; count++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                if (factorial > 0)
                    break;
                else if (count == 30 && factorial == 0)
                    return null;
            }
            ArrayList arrayList = CalculateFactors(factorial);
            return arrayList;
        }
        public long CalculateFactorial(int number)
        {
            factorial = 0;
            if (number < 0)
                return -1;
            if (number == 0)
                return 1;
            else
            {
                
                for (int current = 1; current <= number; current++)
                {
                    factorial *= current;

                }
                return factorial;
            }
        }
    }
}
