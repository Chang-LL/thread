using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyThread
{
    class CarThread
    {
        public void StartTheEngine()
        {
            Console.WriteLine("Starting the engine!");
            //Declare three new threads
            Thread batt = new Thread(new ThreadStart(CheckTheBattery));
            Thread fuel = new Thread(new ThreadStart(CheckForFuel));
            Thread eng = new Thread(new ThreadStart(CheckTheEngine));
            batt.Start();
            fuel.Start();
            eng.Start();
            string bat;
            for (int i = 0; i < 1000000; i++)
            {
                bat = i.ToString();
            }
            Console.WriteLine("Engine is ready!");
        }

        private void CheckTheEngine()
        {
            Console.WriteLine("Checking the engine!");
            string batt;
            for (int i = 0; i < 1000000; i++)
            {
                batt = i.ToString();
            }
            Console.WriteLine("Finished checking the engine!");
        }

        private void CheckForFuel()
        {
            Console.WriteLine("Checking the Fuel!");
            string batt;
            for (int i = 0; i < 1000000; i++)
            {
                batt = i.ToString();
            }
            Console.WriteLine("Fuel is available!");
        }

        private void CheckTheBattery()
        {
            Console.WriteLine("Checking the Battery!");
            string batt;
            for (int i = 0; i < 1000000; i++)
            {
                batt = i.ToString();
            }
            Console.WriteLine("Finished checking the Battery!");
        }
        public static void Main0()
        {
            Console.WriteLine("Entering void Main!");
            int j;
            CarThread carThread = new CarThread();
            Thread worker = new Thread(new ThreadStart(carThread.StartTheEngine));
            worker.Start();        
            string batt;
            for (int i = 0; i < 1000000; i++)
            {
                batt = i.ToString();
            }
            Console.WriteLine("Exiting void Main!");
            Console.ReadLine();
        }
    }
}
