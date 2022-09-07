using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using read_write;

namespace oop_lab1
{
    
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleMenu Menu = new ConsoleMenu();
            Menu.server();
        }
    }
}
