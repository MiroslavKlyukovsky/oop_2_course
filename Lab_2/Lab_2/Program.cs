using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menu;
namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var Demon = new DemonstrationServ();

            Demon.Demonstrate_Collection();
            Demon.Demonstrate_ArrayList();
            Demon.Demonstrate_Array();
            Demon.Demonstarate_BinaryTree();

            Console.ReadLine();
        }
    }
}
