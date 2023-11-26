using System.Collections.Concurrent;

namespace IsPrimeByParallel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ParallelCompute(100));
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