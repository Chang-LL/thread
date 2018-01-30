using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyThread
{
    class MyAppDomain
    {
        public AppDomain Domain;
        public int ThreadId;
        public void SetDomainData(string vName,string vValue)
        {
            Domain.SetData(vName, (object)vValue);
            ThreadId = AppDomain.GetCurrentThreadId();
        }
        public string GetDomainData(string name)
        {
            return (string)Domain.GetData(name);
        }

        static void Main0(string[] args)
        {
            string DataName = "MyData";
            string DataValue = "Some Data to be stored";
            Console.WriteLine("retrieving current domain");
            MyAppDomain Obj = new MyAppDomain();
            Obj.Domain = AppDomain.CurrentDomain;
            Console.WriteLine("Setting domain data");
            Obj.SetDomainData(DataName, DataValue);
            Console.WriteLine("Getting domain data");
            Console.WriteLine("The Data found for key'" + DataName
                + "'is'" + Obj.GetDomainData(DataName)
                + "'running on thread id:" + Obj.ThreadId);
        }
    }
}
