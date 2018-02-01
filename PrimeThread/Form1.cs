using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeThread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //private thread variable
        private Thread primeNumberThread;
        public delegate void UpdateData(string returnVal);
        public void UpdateUI(string val)
        {
            listViewPrime.Items.Add(val);
        }
        private void ButtonStart_Click(object sender, EventArgs e)
        {
            //Let's create a new thread
            primeNumberThread = new Thread(
                new ThreadStart(GeneratePrimeNumbers));
            //let's give a name for the thread
            primeNumberThread.Name = "Prime Numbers Example";
            primeNumberThread.Priority = ThreadPriority.BelowNormal;
            //Enable the Pause Button
            buttonPause.Enabled = true;
            //disable the start button
            buttonStart.Enabled = false;
            primeNumberThread.Start();
        }

        private void GeneratePrimeNumbers()
        {
            long lngCounter;
            long lngNumber;
            long lngDivideByCounter;
            bool blnIsPrime;
            long[] PrimeArray = new long[255];
            string[] args = new string[] { "2" };
            UpdateData UIdel = new UpdateData(UpdateUI);
            //initialize variables
            lngNumber = 3;
            lngCounter = 2;
            PrimeArray[1] = 2;
            Invoke(UIdel, args);
            //listViewPrime.Items.Add(2.ToString());
            while (lngCounter < 256)
            {
                blnIsPrime = true;
                for (lngDivideByCounter = 1; PrimeArray[lngDivideByCounter]
                    * PrimeArray[lngDivideByCounter] <= lngNumber;
                    lngDivideByCounter++)
                {
                    if (lngNumber % PrimeArray[lngDivideByCounter] == 0)
                    {
                        //this is not a prime number
                        blnIsPrime = false;
                        break;
                    }
                }
                //if this is a prime number then display it
                if (blnIsPrime)
                {
                    PrimeArray[lngCounter] = lngNumber;
                    //increase prime found count;
                    lngCounter++;
                    args[0] = lngNumber.ToString();
                    Invoke(UIdel, args);
                    //listViewPrime.Items.Add(lngNumber.ToString());
                    //put the thread to sleep 100 milliseconds
                    //this will simulate the time lag and we'll get time
                    //to pause and resume the thread
                    Thread.Sleep(100);
                }
                //increment number by 2;
                lngNumber += 2;
            }
            //once the thread is finished execution enable the start
            //and disable the pause button
            buttonStart.Enabled = true;
            buttonPause.Enabled = true;
        }

        private void ButtonPause_Click(object sender, EventArgs e)
        {
            try
            {

                //if current state of thread is running
                //then pause the thread
                //???
                if (!(primeNumberThread.ThreadState== ThreadState.Running))
                {

                    //pause the thread
                    primeNumberThread.Suspend();
                    //disable the pause button
                    buttonPause.Enabled = false;
                    //enable the resume button
                    buttonResume.Enabled = true;
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception",
                    MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }

        }

        private void buttonResume_Click(object sender, EventArgs e)
        {
            if (primeNumberThread.ThreadState == ThreadState.Suspended
                || primeNumberThread.ThreadState == ThreadState.SuspendRequested)
            {
                try
                {
                    //resume the thread
                    primeNumberThread.Resume();
                    buttonResume.Enabled = false;
                    buttonPause.Enabled = true;
                }
                catch (ThreadStateException ex)
                {
                    MessageBox.Show(ex.ToString(), "Exception",
                        MessageBoxButtons.OK, MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            //enable the start button and disable all others
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
            buttonPause.Enabled = false;
            buttonResume.Enabled = false;
            //destroy the thread
            if (primeNumberThread.ThreadState == ThreadState.Suspended
                || primeNumberThread.ThreadState == ThreadState.SuspendRequested)
                primeNumberThread.Resume();
            primeNumberThread.Abort();
        }
    }
}
