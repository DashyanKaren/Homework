using System;
using System.Threading;

namespace MyDeadLock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(F1);
            Thread thread2 = new Thread(F2);
            thread1.Start();
            thread2.Start();
        }
        static AutoResetEvent are =new AutoResetEvent(false);
        static AutoResetEvent are1 =new AutoResetEvent(false);
        static object obj1=new object();
        static object obj2=new object();
        static void F1()
        {
            lock (obj1)
            {
                   are.WaitOne();
                   are1.Set();
                lock(obj2) 
                {
                  
                }
            }
        }
        static void F2()
        {
            are1.WaitOne();
            lock (obj2)
            {
                    are.Set();
                lock (obj1)
                {
                }
            }
        }    

    }
}
