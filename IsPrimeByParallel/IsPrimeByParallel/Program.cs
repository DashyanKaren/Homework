using System.Collections.Concurrent;
using System.Diagnostics;

namespace IsPrimeByParallel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var p=ParallelCompute(1000);
            stopwatch.Stop();
            Console.WriteLine(  $"{stopwatch.ElapsedMilliseconds} Parallel  {p}");
            stopwatch.Reset();
            stopwatch.Start();
            var np=NonParallelCompute(1000);
            stopwatch.Stop();
            Console.WriteLine($"{stopwatch.ElapsedMilliseconds} nonParallel {np}");

        }
        static int NonParallelCompute(int x)
        {
            int sum = 0;
            for (int i = 0; i < x; i++)
            {
                if (IsPrime(i))
                {
                    sum += i;
                }
            }
            return sum;
        }
        static int ParallelCompute(int x)
        {
            int sum = 0;

            Parallel.For(0, x, i =>
            {
                if (IsPrime(i))
                {
                    sum += i;
                }
            });
            return sum;
           

           
        }
        static bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            if (number == 2)
                return true;

            if (number % 2 == 0)
                return false;

            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}