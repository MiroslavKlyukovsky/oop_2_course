using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Fireman : Human
    {
        public Fireman()
        {

        }
        public Fireman(String firstName, String lastName) : base("fireman", firstName, lastName)
        {

        }
        public string fire_extinguishing()
        {
            return $"My name is {firstName} and I'm extinguishing fire!";
        }
    }
}
