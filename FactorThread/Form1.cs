#define PeerThread
//#define MainWorker
//TODO Pipeline
//#define Pipeline
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FactorThread
{
    public partial class FrmCalculate : Form
    {
        public delegate void UpdateValue(string val);
        private MainWorker threadMethods;
        private PeerThread peerThreadMethods;
        public FrmCalculate()
        {
            InitializeComponent();
            threadMethods = new MainWorker();
            peerThreadMethods = new PeerThread();
        }
        private void DisplayValue(string val)
        {
            listView1.Items.Add(val);
        }
        private void FactorsThread()
        {
            ArrayList val = threadMethods.CalculateFactors(200);
            StringBuilder sb = new StringBuilder();
            for (int count = 0; count <= val.Count - 1; count++)
            {
                sb.Append((string)val[count]);
                if (count < val.Count - 1)
                    sb.Append(",");
            }
            UpdateValue updVal = new UpdateValue(DisplayValue);
            string[] Args = { sb.ToString() };
            Invoke(updVal, Args);
        }
        private void NewFactorsThread()
        {
            ArrayList val = peerThreadMethods.CalculateFactors();
            //calculateFactorial.Join();
            StringBuilder sb = new StringBuilder();
            for (int count = 0; count <= val.Count - 1; count++)
            {
                sb.Append((string)val[count]);
                if (count < val.Count - 1)
                    sb.Append(",");
            }
            UpdateValue updVal = new UpdateValue(DisplayValue);
            string[] Args = { sb.ToString() };
            Invoke(updVal, Args);
        }
#if MainWorker
        private void ButtonFactors_Click(object sender, EventArgs e)
        {
            Thread c = new Thread(new ThreadStart(FactorsThread));
            c.Start();
        }
#endif
#if PeerThread
        private void ButtonFactors_Click(object sender, EventArgs e)
        {
            Thread calculateFactors = new Thread(new ThreadStart(
                FactorsThread));
            Thread calculateFactorial = new Thread(new ThreadStart(
               NewFactorsThread));
            calculateFactors.Start();
            calculateFactorial.Start();
        }      
#endif
    }
}
