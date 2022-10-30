using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using System.Collections;
using Entites.BinTree;

namespace Menu
{
    public class DemonstrationServ
    {
        public void Demonstrate_Collection()
        {
            var trapezes = new List<Trapeze>();

            trapezes.Add(new Trapeze(10,6,4,2,2,"Orange","Green"));//Adding elements
            trapezes.Add(new Trapeze(18,6,10,2,2,"Orange"));
            trapezes.Add(new Trapeze(8, 6, 4, 2, 2)); 
            trapezes.Add(new Trapeze(7, 6, 4, 2, 2, "Purple", "Red"));

           
            ShowCollectionWithCaption(trapezes, ConsoleColor.Red);
            Console.WriteLine("==================================");

            trapezes.RemoveAt(0);//Removing elements

            ShowCollectionWithCaption(trapezes, ConsoleColor.Yellow);
            Console.WriteLine("==================================");

            trapezes[0] = new Trapeze(10, 6, 10, 2, 2, "Red", "Red");//Reassigning

            ShowCollectionWithCaption(trapezes, ConsoleColor.Green);
            Console.WriteLine("==================================");

            ShowCollectionWithCaption(trapezes.FindAll(y => y.height == 10), ConsoleColor.Cyan);//Looking for the special elements
            Console.WriteLine("==================================");

            void ShowCollectionWithCaption(List<Trapeze> trapez, ConsoleColor color)
            {
                int i = 0;
                foreach (var item in trapez)//Iterating over the sequence
                {
                    Console.WriteLine();
                    Console.ForegroundColor = color;
                    Console.WriteLine("Trapeze number " + i.ToString() + ':');
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.WriteLine(item.info());
                    i++;
                }
            }
        }
        public void Demonstrate_ArrayList()
        {
            var trapezes = new ArrayList(5);//non-generic
            var trapezes_to_look = new ArrayList(5);


            trapezes.Add(new Trapeze(10, 6, 4, 2, 2, "Orange", "Green"));//Adding elements
            trapezes.Add(new Trapeze(18, 6, 10, 2, 2, "Orange"));
            trapezes.Add(new Trapeze(8, 6, 4, 2, 2));
            trapezes.Add(new Trapeze(7, 6, 4, 2, 2, "Purple", "Green"));
            Console.WriteLine("==================================");

            ShowCollectionWithCaption(trapezes, ConsoleColor.Red);
            Console.WriteLine("==================================");

            trapezes.RemoveAt(0);//Removing elements

            ShowCollectionWithCaption(trapezes, ConsoleColor.Yellow);
            Console.WriteLine("==================================");

            trapezes[0] = new Trapeze(10, 6, 10, 2, 2, "Red", "Red");//Reassigning

            ShowCollectionWithCaption(trapezes, ConsoleColor.Green);
            Console.WriteLine("==================================");

            foreach (Trapeze item in trapezes)//Looking for the special elements
            {
                if (item.outline_color == "Green")
                {
                    trapezes_to_look.Add(item);
                }
            }

            ShowCollectionWithCaption(trapezes_to_look, ConsoleColor.DarkBlue);
            Console.WriteLine("==================================");

            void ShowCollectionWithCaption(ArrayList trapez, ConsoleColor color)
            {
                int i = 0;
                foreach (Trapeze item in trapez)//Iterating over the sequence
                {
                    Console.WriteLine();
                    Console.ForegroundColor = color;
                    Console.WriteLine("Trapeze number " + i.ToString() + ':');
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.WriteLine(item.info());
                    i++;
                }
            }
        }
        public void Demonstrate_Array() {
            Trapeze[] trapezes = new Trapeze[4];

            trapezes[0] = new Trapeze(10, 6, 4, 2, 2, "Orange", "Green");//Adding elements
            trapezes[1] = new Trapeze(18, 6, 10, 2, 2, "Orange");
            trapezes[2] = new Trapeze(10, 6, 4, 2, 2);
            trapezes[3] = new Trapeze(7, 6, 4, 2, 2, "Purple", "Green");
            Console.WriteLine("==================================");

            ShowCollectionWithCaption(trapezes, ConsoleColor.Red);
            Console.WriteLine("==================================");

            trapezes = trapezes.Where(e => e.length_of_dow_base != 10).ToArray();//Removing elements and Looking for the special elements

            ShowCollectionWithCaption(trapezes, ConsoleColor.Magenta);
            Console.WriteLine("==================================");

            trapezes[1] = new Trapeze(10, 6, 10, 2, 2, "Red", "Red");//Reassigning

            ShowCollectionWithCaption(trapezes, ConsoleColor.Green);
            Console.WriteLine("==================================");

            void ShowCollectionWithCaption(Trapeze[] trapez, ConsoleColor color)
            {
                int i = 0;
                foreach (Trapeze item in trapez)//Iterating over the sequence
                {
                    Console.WriteLine();
                    Console.ForegroundColor = color;
                    Console.WriteLine("Trapeze number " + i.ToString() + ':');
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.WriteLine(item.info());
                    i++;
                }
            }
        }
        public void Demonstarate_BinaryTree()
        {
            var BT = new Tree<Trapeze>();
            BT.Insert(new Trapeze(10, 6, 4, 2, 2, "Orange", "Green"));
            BT.Insert(new Trapeze(18, 6, 10, 2, 2, "Pomarange"));
            BT.Insert(new Trapeze(7, 6, 4, 2, 2, "Orange", "Green"));
            BT.Insert(new Trapeze(6, 6, 4, 2, 2, "Green", "Green"));
            BT.Insert(new Trapeze(11, 6, 4, 2, 2, "Purple", "Green"));
            BT.Insert(new Trapeze(19, 6, 4, 2, 2, "Fall", "Green"));
            BT.Insert(new Trapeze(8, 6, 4, 2, 2, "Purp", "Green"));
            

            Console.WriteLine("==================================");
            BT.DisplayTree();
            Console.WriteLine("==================================");
            BT.draw_tree();
            Console.WriteLine("==================================");
            foreach (var item in BT)
            {
                Console.WriteLine("length_of_dow_base: "+ item.length_of_dow_base.ToString() + " fill_color: " + item.fill_color);
            }
        }
    }
}
