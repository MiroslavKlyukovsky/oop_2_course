using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTasks
{
    public class MyQueue
    {
        public Component Component = new Component();

        private char[] items;
        private int count = 0;
        const int n = 10;
        public MyQueue()
        {
            items = new char[n];
        }
        public MyQueue(int length)
        {
            items = new char[length];
        }
        public bool IsEmpty //Чи є елменти в черзі
        {
            get { return count == 0; }
        }
        public int Count //Кількість елементів
        {
            get { return count; }
        }
        public bool Push(char item)
        {
            // += подписываемся на событие
            // Generator.Overflowed += Show;
            // если стек заполнен, выбрасываем исключение
            if (count == items.Length)
            {
                return false;
                //Generator.CheckStack(items.Length, count);
            }
            else
            {
                items[count++] = item;
                return true;
            }
            // -= отписываемся от события
            //Generator.Overflowed -= Show;
        }
        public char Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Черга пуста");

            char ritem = items[0];
            
            char[] tmp = new char[count-1];

            for (int i = 0; i < tmp.Length; i++)
            {
                tmp[i] = items[i + 1];
            }
            items = tmp;
            count--;
            return ritem;
        }
        public bool Clear() {
            Component.Cleared += SayThatClear;
            int it = count;
            for (int i = 0; i < it; i++)
            {
                Pop();
            }
            Component.QueueInfo(count);
            Component.Cleared -= SayThatClear;
            return true;
        }
        private static void SayThatClear(object sender, ClassArgument e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
