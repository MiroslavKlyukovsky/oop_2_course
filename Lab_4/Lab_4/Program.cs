using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTasks;

namespace Lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //First task
            Console.WriteLine("First Task: \n");

            FirstTask Ftask = new FirstTask();
            Console.WriteLine(Ftask.CheckA("asdv"));
            Console.WriteLine(Ftask.CheckL(".....@@[]!"));
            Console.WriteLine(Ftask.CheckA(".....@@[]!"));
            Console.WriteLine(Ftask.CheckL("asdv"));

            //Second task
            Console.WriteLine("\nSecond Task: \n");

            MyQueue mq = new MyQueue();
            
            mq.Push('a');
            mq.Push('b');
            mq.Push('c');

            Console.WriteLine(mq.Pop());
            Console.WriteLine(mq.Pop());
            Console.WriteLine(mq.Pop());

            Console.WriteLine(mq.Count);

            mq.Push('a');
            mq.Push('b');
            mq.Push('c');

            mq.Clear();
            
            Console.ReadKey();
        }
    }
}
