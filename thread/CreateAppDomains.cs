using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyThread
{
    class CreateAppDomains
    {
        public static void CommonCallBack()
        {
            AppDomain domain;
            domain = AppDomain.CurrentDomain;
            Console.WriteLine("The value'" + domain.GetData("DomainKey")
                + "'was found in " + domain.FriendlyName.ToString()
                +"running on theard id:"+
                AppDomain.GetCurrentThreadId().ToString());
        }
        public static void Main0()
        {
            AppDomain domainA;
            domainA = AppDomain.CreateDomain("MyDomainA");
            string stringA = "DomainA Value";
            domainA.SetData("DomainKey", stringA);

            CommonCallBack();
            CrossAppDomainDelegate delegateA =
                new CrossAppDomainDelegate(CommonCallBack);
            domainA.DoCallBack(CommonCallBack);
        }
    }
}
