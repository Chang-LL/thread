using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyThread.GenThreadPool
{
    class TraceSwitchExample
    {
        private static TraceSwitch ts;
        private static void DBThread()
        {
            //trace an info message
            Trace.WriteLineIf(ts.TraceInfo, DateTime.Now +
                " - Entered in DBThread()");
            //Create a connection object
            SqlConnection dbConn = new SqlConnection(
                "server=.;database=pubs;uid=sa;pwd=");
            SqlCommand dbComm = new SqlCommand(
                "SELECT * FROM authors", dbConn);
            SqlDataReader dr = null;
            try
            {
                Trace.WriteLineIf(ts.TraceInfo, DateTime.Now+" - Executing SQL statement");
                dr = dbComm.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while(dr.Read())
                {

                }
            }
            catch(Exception ex)
            {
                Trace.WriteLineIf(ts.TraceError, DateTime.Now +
                    " - Error: " + ex.Message);
            }

            finally
            {
                if (dr != null && dr.IsClosed == false)
                    dr.Close();
            }
        }
        [STAThread]
        static void Main()
        {
            ts = new TraceSwitch("MySwitch", "Four different trace levels");
            //Create a file listener
            FileStream fs = new FileStream(
               @"F:\D.log", FileMode.OpenOrCreate);
            Trace.Listeners.Add(new TextWriterTraceListener(fs));
            //write the line only when the switch is on
            Trace.WriteLineIf(ts.TraceInfo, DateTime.Now + " - Entered Main()");

            Thread t = new Thread(new ThreadStart(DBThread));
            t.Start();
            Console.Read();
            Trace.Close();
        }
    }
}
