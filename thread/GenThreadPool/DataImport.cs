using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace MyThread.GenThreadPool
{
    class DataImport
    {
        public static BooleanSwitch bs;
        [STAThread]
        static void Main()
        {
            Trace.Listeners.RemoveAt(0);
            bs = new BooleanSwitch("DISwitch", "DataImport switch");
            Trace.Listeners.Add(new TextWriterTraceListener(
                new FileStream(@"F:\D.log", FileMode.OpenOrCreate)));
            //Create a fileSystem Watcher object used to monitor
            //the specified directory
            FileSystemWatcher fsw = new FileSystemWatcher
            {
                //extension to monitor for
                Path = @"F:\temp",
                Filter = "*.xml",
                //No need to go into subdirs
                IncludeSubdirectories = false,
            };
            //Add the handler to manage the raised event
            //when a new file is created
            fsw.Created += new FileSystemEventHandler(OnFileChanged);
            //Enable the object to raise the event
            fsw.EnableRaisingEvents = true;

            try
            {
                //Call the waitforchanged method in an infinite loop
                //When the event is raised the OnfileCreated will be contacted
                WaitForChangedResult res;
                while (true)
                {
                    res = fsw.WaitForChanged(WatcherChangeTypes.Created);
                    Trace.WriteLineIf(bs.Enabled, DateTime.Now
                        + " - Found: " + res.Name + " file");
                }

            }
            catch (Exception e)
            {
                Trace.WriteLineIf(bs.Enabled, DateTime.Now +
                    " - An exception occured while waiting for file:");
                Trace.Indent();
                Trace.WriteLineIf(bs.Enabled, DateTime.Now + " - "
                    + e.ToString());
                Trace.Unindent();
                
            }
            finally
            {
                fsw.EnableRaisingEvents = false;
                Trace.WriteLineIf(bs.Enabled, DateTime.Now +
                    " - Directory monitoring stopped");
                Trace.Close();
            }

        }

        private static void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            try
            {
                //Create a new object from the ImportData 
                //class to process the incoming file
                ImportData id = new ImportData
                {
                    strFileName = e.FullPath
                };

                Thread t = new Thread(new ThreadStart(id.Import))
                {
                    Name = "DataImportThread"
                };
                t.Start();
            }
            catch (Exception)
            {
                Trace.WriteLineIf(bs.Enabled, DateTime.Now +
                    " - An exception occurred while queuing file: ");
                Trace.Indent();
                Trace.WriteLineIf(bs.Enabled, DateTime.Now + " - " + e.ToString());
                Trace.Unindent();                
            }
            finally
            {
                Trace.Flush();
            }
        }
    }

    public class ImportData
    {
        //Path and filename of the retrieved file
        public string strFileName = null;

        public void Import()
        {
            //Create a connection object
            SqlConnection dbConn = new SqlConnection(
                "server=.;database=pubs;uid=sa;pwd=");
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM authors", dbConn);
            DataSet ds = new DataSet();
            SqlCommandBuilder sa = new SqlCommandBuilder(da);
            try
            {
                Trace.WriteLineIf(DataImport.bs.Enabled, DateTime.Now + " - Filling the DataSet");
                da.Fill(ds);
                //Read the xml file filling another dataset
                DataSet dsMerge = new DataSet();

                Trace.WriteLineIf(DataImport.bs.Enabled, DateTime.Now +
                    " - Reading XML file");
                dsMerge.ReadXml(strFileName, XmlReadMode.InferSchema);
                Trace.WriteLineIf(DataImport.bs.Enabled, DateTime.Now +
                    " - DataSet filled with data");
                //Update the database tracing the total time needed to conclude the operation

                DateTime time = DateTime.Now;
                Trace.WriteLineIf(DataImport.bs.Enabled, time
                    + " - Updating database");
                da.Update(dsMerge);
            }
            catch(SqlException sex)
            {
                Trace.WriteLineIf(DataImport.bs.Enabled, DateTime.Now +
                    " - A SQL exception occured during file processing: ");
                Trace.Indent();
                Trace.WriteLineIf(DataImport.bs.Enabled, DateTime.Now +
                    " - " + sex.ToString());
                Trace.Unindent();
            }
            catch(Exception ex)
            {
                Trace.WriteLineIf(DataImport.bs.Enabled, DateTime.Now +
                   " - A general exception occured during file processing: ");
                Trace.Indent();
                Trace.WriteLineIf(DataImport.bs.Enabled, DateTime.Now +
                    " - " + ex.ToString());
                Trace.Unindent();
            }
            finally
            {
                Trace.Flush();
            }
        }
    }
}
