//#define TRACE
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BarrierSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(0, 2_000_00000);
            Stopwatch sw = new Stopwatch();

            sw.Start();
            NonParallelCompute(numbers);
            sw.Stop();
            Console.WriteLine("Non Parallel {0}", sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            ParallelCompute(numbers);
            sw.Stop();
            Console.WriteLine("Parallel {0}", sw.ElapsedMilliseconds);
        }

        public static void NonParallelCompute(IEnumerable<int> numbers)
        {
            ConcurrentBag<int> ints = new ConcurrentBag<int>();
            foreach (int i in numbers)
            {
                if (IsOdd(i))
                {
                    ints.Add(i);
                }

            };
        }
        public static void ParallelCompute(IEnumerable<int> numbers)
        {
            ConcurrentBag<int> ints = new ConcurrentBag<int>();
            Parallel.ForEach(numbers, (e =>
            {

                if (IsOdd(e))
                {
                    ints.Add(e);
                }

            }));
        }


        public static bool IsOdd(int number)
        {
            return number % 2 != 0;
        }

    }
}