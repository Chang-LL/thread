using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyThread
{
    class ThreadPoolState
    {
        public void Task1(object stateObj)
        {
            ObjState stobj;
            stobj = (ObjState)stateObj;

            Console.WriteLine("Input Argument 1 in task 1:" + stobj.inarg1);
            Console.WriteLine("Input Argument 2 in task 1:" + stobj.inarg2);
            stobj.outval = "From Task1 " + stobj.inarg1 + " " + stobj.inarg2;
        }
        public void Task2(object stateObj)
        {
            ObjState stobj;
            stobj = (ObjState)stateObj;

            Console.WriteLine("Input Argument 1 in task 2:" + stobj.inarg1);
            Console.WriteLine("Input Argument 2 in task 2:" + stobj.inarg2);
            stobj.outval = "From Task2 " + stobj.inarg1 + " " + stobj.inarg2;
        }
        static void Main0()
        {
            ObjState obj1 = new ObjState()
            {
                inarg1 = "String Param1 of task 1",
                inarg2 = "String Param2 of task 1"
            };
            ObjState obj2 = new ObjState()
            {
                inarg1 = "String Param1 of task 2",
                inarg2 = "String Param2 of task 2"
            };
            ThreadPoolState tps = new ThreadPoolState();
            ThreadPool.QueueUserWorkItem(new WaitCallback(tps.Task1), obj1);
            ThreadPool.QueueUserWorkItem(new WaitCallback(tps.Task2), obj2);
            Console.Read();
        }
    }

    public class ObjState
    {
        protected internal string inarg1;
        protected internal string inarg2;
        protected internal string outval;
    }
}
