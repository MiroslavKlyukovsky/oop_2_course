using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Courier : Human
    {
        public Courier(String firstName, String lastName) : base("courier", firstName, lastName)
        {
           
        }
        public string deliver()
        {
            return $"My name is {firstName} and I'm delivering!";
        }
    }
}
