using System;
using System.Text;
using System.Threading;


namespace MyCountDownEvent
{
    internal class Program
    {
        static string[] words1 = new string[] { "brown", "jumps", "the", "fox", "quick" };
        static string[] words2 = new string[] { "dog", "lazy", "the", "over" };
        static string solution = "the quick brown fox jumps over the lazy dog.";
        static int count = 2;
        static int count1 = 0;
        static CountdownEvent cde = new CountdownEvent(2);
        static bool success = false;
        static void Main(string[] args)
        {
                    
            Thread t1 = new Thread(() => Solve(words1));
            t1.Start();
            Thread t2 = new Thread(() => Solve(words2));
            t2.Start();
            cde.Wait(   );
            Thread thread = new Thread(() => Check());
            thread.Start();
           // cde.Dispose();

        }
       
        static void Solve1(string[] wordArray)
        {
          
            cde.Signal();
        }
        static object lockobj = new object();

        static void Solve(string[] wordArray, CountdownEvent solve)
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
                    count1++;
                }
                
                    cde.Signal();
                    solve.Wait();
                    
            }
            
        }
        static void Check() 
        {
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
            Console.Write("Current phase: {0}");
            if (String.CompareOrdinal(solution, sb.ToString()) == 0)
            {
                success = true;
                Console.WriteLine("\r\nThe solution was found in {0} attempts"  , count1);
            }
        }


    }
}