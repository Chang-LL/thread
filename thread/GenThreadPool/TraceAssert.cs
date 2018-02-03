using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyThread.GenThreadPool
{
    class TraceAssert
    {
        private static void DBThread()
        {
            //Create a connection object
            SqlConnection dbConn = new SqlConnection
                ("server=.;database=pubs;uid=sa;pwd=");
            //Create a command object to execute a SQL statement
            SqlCommand dbComm = new SqlCommand("SELECT * FROM " + "autores", dbConn);
            SqlDataReader dr = null;
            Trace.WriteLine(DateTime.Now + " - Executing SQL statemen");
            try
            {
                dbConn.Open();
                //Assert the connection opened
                Trace.Assert(dbConn.State == System.Data.ConnectionState.Open,
                    "Error", "Connection failed...");
                //execute the Sql statement
                dr = dbComm.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                //Assert the statement executed OK
                Trace.Assert(dr != null, "Error", "The SqldataReader is null");
                while(dr.Read())
                {
                    //reading records
                }
            }
            catch (Exception)
            {
                //Log the error to the Trace application
                Trace.Fail("An error occured in database access");
            }                            
            finally
            {
                if ( (dr != null)&&(dr.IsClosed == false))
                    dr.Close();
            }
        }
        [STAThread]
        static void Main0()
        {
            Thread t = new Thread(new ThreadStart(DBThread));
            t.Start();
        }
        static void Main00()
        {
            //Create a trace listener for the event log
            EventLogTraceListener eltl = new EventLogTraceListener("TraceLog");
            //Add the event log trace listener to the collection

            Trace.Listeners.Add(eltl);
            //Remove the default listener
            //Trace.Listeners.Add(eltl);
            //Write output to the event log
            Trace.WriteLine("Entered in Main()");
        }
        static void Main000()
        {
            //Remove the default listener
            Trace.Listeners.RemoveAt(0);
            //Add a console listener
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            //Write a trace message
            Trace.WriteLine("Enter in Main()");
        }
    }
}
