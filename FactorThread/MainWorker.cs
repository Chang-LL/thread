using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorThread
{
    public class MainWorker
    {
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
                for (int current = 2; current <=number-1; current++)
                {
                    if ((int)(Math.Floor((double)number / current) * current) == number)
                        factors.Add(current.ToString());
                }
                factors.Add(number.ToString());
                return factors;

            }
        }
        public long CalculateFactorial(int number)
        {
            if (number < 0)
                return -1;
            if (number == 0)
                return 1;
            else
            {
                long returnvalue = 1;
                for (int current = 1; current < number; current++)
                {
                    returnvalue *= current;
                    
                }
                return returnvalue;
            }
        }
    }
}
