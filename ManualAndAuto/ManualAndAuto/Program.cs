using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace ManualAndAuto
{
    internal class Program
    {
        public static AutoResetEvent are = new AutoResetEvent(false);

        public static Dictionary<int, int> x = new Dictionary<int, int>();

        static void Main(string[] args)
        {


            for (int i = 0; i < 20; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(add));
            }

            //for (int i = 0; i < 20; i++)
            //{
            //    Addto();
            //}
            Console.ReadLine();
        }

        private static void add(object state)
        {
            are.Set();
            var y = Thread.CurrentThread.ManagedThreadId;
            Random random = new Random();

            are.WaitOne();
            x.Add(y, y);
        }

        //public static  void Addto()
        //{
        //      int y = AppDomain.GetCurrentThreadId();

        //    Random random = new Random();
        //    x.Add(y,random.Next(y,y));
        //}
    }
}
