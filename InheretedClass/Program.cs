using System;

namespace InheretedClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person(22, "Armen");
            Worker worker = new Worker(23, "Sargis", 300);
            worker.GetOlder();
            worker.GetOlder();
            Console.WriteLine(  worker.ToString());
        }
    }
}
