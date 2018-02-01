using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SearchThread
{
    public partial class ThreadSearchForm : Form
    {
        public ThreadSearchForm()
        {
            InitializeComponent();
        }
        string search;
        int fileCount;
        public void Search()
        {
            search = textBox1.Text;
            listBox1.Items.Clear();
            fileCount = 0;
            SearchDirectory(@"E:\zm");
        }

        private void SearchDirectory(string path)
        {
            //Search the directory
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] f = di.GetFiles(search);
            listBox1.BeginUpdate();
            foreach (var item in f)
            {
                listBox1.Items.Add(item.FullName);
            }
            listBox1.EndUpdate();
            //search its sub directories
            DirectoryInfo[] d = di.GetDirectories();
            foreach (var item in d)
            {
                SearchDirectory(item.FullName);
            }
        }

        private void ButtonSthread_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void ButtonMthread_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(Search));
            t.Start();
        }
    }
}
