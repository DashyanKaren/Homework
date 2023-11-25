using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BarrierSimple
{
    class Program
    {
        static string[] words1 = new string[] { "brown", "jumps", "the", "fox", "quick" };
        static string[] words2 = new string[] { "dog", "lazy", "the", "over" };
        static string solution = "the quick brown fox jumps over the lazy dog.";

        static bool success = false;
        static AutoResetEvent solve1 = new AutoResetEvent(false);
        static AutoResetEvent solve2 = new AutoResetEvent(false);
        static AutoResetEvent check1 = new AutoResetEvent(false);
        static AutoResetEvent check2 = new AutoResetEvent(false);



        // Use Knuth-Fisher-Yates shuffle to randomly reorder each array.
        // For simplicity, we require that both wordArrays be solved in the same phase.
        // Success of right or left side only is not stored and does not count.
        static void Solve(string[] wordArray, AutoResetEvent solve, AutoResetEvent check)
        {
            while (success == false)
            {
                Random random = new Random();
                for (int i = wordArray.Length - 1; i > 0; i--)
                {
                    int swapIndex = random.Next(i + 1);
                    string temp = wordArray[i];
                    wordArray[i] = wordArray[swapIndex];
                    wordArray[swapIndex] = temp;
                }
                check.Set();
                solve.WaitOne();
            }
        }
        static void Check()
        {
            int counter = 0;
            while (!success)
            {
                check1.WaitOne();
                check2.WaitOne();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < words1.Length; i++)
                {
                    sb.Append(words1[i]);
                    sb.Append(" ");
                }
                for (int i = 0; i < words2.Length; i++)
                {
                    sb.Append(words2[i]);

                    if (i < words2.Length - 1)
                        sb.Append(" ");
                }
                sb.Append(".");
#if TRACE
                System.Diagnostics.Trace.WriteLine(sb.ToString());
#endif
                Console.CursorLeft = 0;
                Console.Write("Current phase: {0}", counter++);
                if (String.CompareOrdinal(solution, sb.ToString()) == 0)
                {
                    success = true;
                    Console.WriteLine("\r\nThe solution was found in {0} attempts", counter);
                }
                solve1.Set();
                solve2.Set();

            }
        }

        static void Main(string[] args)
        {

            Thread t1 = new Thread(() => Solve(words1, solve1, check1));
            Thread t2 = new Thread(() => Solve(words2, solve2, check2));
            t1.Start();
            t2.Start();

            Check();
            // Keep the console window open.
            Console.ReadLine();
            PrintArray(words1);
            PrintArray(words2);
        }
        static void PrintArray(string[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item);
                Console.Write(" ");
            }
        }

    }
}