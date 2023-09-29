using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var x = from g in list where g > 1 select g;
            //foreach (var item in x)
            //{
            //    Console.WriteLine( $"Item {item}");
            //}
            var agg = list.MyAggregate((sum, val) => sum + val);
            //var t1= list.Aggregate(,);

            var myall = list.MyAll(e => e > 0);
            //var a = list.All(e => e > 4);

            var myanny=list.MyAny(e => e > 10);
           var myaverage= list.Average(Func(List<>));
            foreach (var item in list)
            {
                Console.WriteLine($"Item {item}");
            }
            Console.WriteLine();

            Console.WriteLine($"All is {myall}");
             Console.WriteLine($"Any is {myanny}");
          //  Console.WriteLine($"asEnumerable-{}");

        }
    }
}
