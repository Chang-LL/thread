using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyThread
{
    interface IBookCollection
    {
        void Clear();
        void Add(Book n);
        Book GetBook(string ISBN);
        bool IsSynchronized { get; }
        object SyncRoot { get; }
    }
    public class Book
    {
        public string Name;
        public string ISBN;
        public string Author;
        public string Publisher;
    }
    class BookLib : IBookCollection
    {
        internal Hashtable bk = new Hashtable(10);
        public virtual bool IsSynchronized => false;

        public virtual object SyncRoot => this;

        public virtual void Add(Book n)
        {
            Console.WriteLine("Adding Book for ThreadId:" +
                Thread.CurrentThread.GetHashCode());
            Thread.Sleep(2000);
            bk.Add(n.ISBN, n);
        }

        public virtual void Clear()
        {
            bk.Clear();
        }

        public virtual Book GetBook(string ISBN)
        {
            Console.WriteLine("Getting Book for ThreadId:" +
                Thread.CurrentThread.GetHashCode());
            return (Book)bk[ISBN];
        }
        public BookLib Synchronized()
        {
            return Synchronized(this);
        }

        public static BookLib Synchronized(BookLib bookLib)
        {
            if(bookLib==null)
            {
                throw new ArgumentException("bookLib");
            }
            if(bookLib.GetType()==typeof(SyncBookLib))
            {
                throw new InvalidOperationException(
                    "BookLib reference is already synchronized");
            }
            return new SyncBookLib(bookLib);
        }
        public static IBookCollection Synchronized(IBookCollection acc)
        {
            if (acc == null)
            {
                throw new ArgumentException("acc");
            }
            if (acc.GetType() == typeof(SyncBookLib))
            {
                throw new InvalidOperationException(
                    "BookLib reference is already synchronized");
            }
            return new SyncBookLib(acc);
        }
    }
    sealed class SyncBookLib : BookLib
    {
        private object syncRoot;
        private object booklib;
        internal SyncBookLib(IBookCollection acc)
        {
            booklib = acc;
            syncRoot = acc.SyncRoot;
        }
        public override void Clear()
        {
            lock (syncRoot)
            {
                base.Clear();
            }

        }
        public override void Add(Book n)
        {
            lock (syncRoot)
            {
                base.Add(n);
            }
        }
        public override Book GetBook(string ISBN)
        {
            lock (syncRoot)
            {
                return (Book)bk[ISBN];
            }
        }
        public override bool IsSynchronized => true;
        public override object SyncRoot => syncRoot;
    }
    class Test
    {
        private static BookLib acc;
        private static int n = 0;
        static void Run()
        {
            for (int i = 0; i < 2; i++)
            {
                Book bk = new Book
                {
                    Author = "Tejaswi Redkar",
                    Name = "A" + i,
                    Publisher = "Wrox",
                    ISBN = (n++).ToString()
                };
                acc.Add(bk);
            }
        }
        static void Main0()
        {
            acc = new BookLib();
            if(Console.ReadLine().Length>0)
            {
                acc = acc.Synchronized();
                //or BookLib.Synchroized(acc)

            }
            Thread[] threads =
            {
                new Thread(new ThreadStart(Run)),
                new Thread(new ThreadStart(Run)),
                new Thread(new ThreadStart(Run)),
            };
            foreach (var t in threads)
            {
                t.Start();
            }
            foreach (var t in threads)
            {
                t.Join();
            }
            for (int i = 0; i < n; i++)
            {
                Book bk = acc.GetBook(i.ToString());
                if(bk!=null)
                {
                    Console.WriteLine("Book: " + bk.Name);
                    Console.WriteLine("ISBN: " + bk.ISBN);
                    Console.WriteLine("Publisher: " + bk.Publisher);
                    Console.WriteLine("Auther: " + bk.Author);
                }
            }
            Console.WriteLine("Total Number of books added " + n);
        }

    }
}
