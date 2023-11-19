using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using static ProcPriority.Program;

namespace ProcPriority
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            GetCalculation getCalculation = new GetCalculation();
            Thread thread1 = new Thread(() => getCalculation.MultiplyAndDivide(5,10,10));
            Thread thread2 = new Thread(() => getCalculation.MultiplyAndDivide(5,10,10));
            List<Descriptor> values = new List<Descriptor>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            thread1.Start();
            stopwatch.Stop();
            stopwatch.Restart();
            stopwatch.Start();
            thread2.Start();
            stopwatch.Stop();

            foreach (var process in Process.GetProcesses())
            {
                foreach (ProcessThread  thread in process.Threads)
                {
                    values.Add(new Descriptor()
                    {
                        ProcessName = process.ProcessName,
                        ThreadId = thread.Id,
                        Prority =thread.CurrentPriority,
                        Time=stopwatch.ElapsedMilliseconds,
                    });
                    ;
                }
            }
            foreach (var item in values)
            {
                Console.WriteLine(item);

            }
            Console.WriteLine(  "////////////////////////////////");
            var sorted =values.GroupBy(e => e.Prority)
                .Select(e => new { Prority = e.Key, Count = e.Sum(e => e.Prority), Time =e.Sum(e=>e.Time) })
                .OrderBy(e => e.Time);
            foreach (var item in sorted)
            {
                Console.WriteLine($"Priority - {item.Prority}, Count - {item.Count}, Time - {item.Time} ");
            }

        }
    }
}
