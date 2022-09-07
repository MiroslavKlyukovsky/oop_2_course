using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Entrepreneur : Human
    {
        public Entrepreneur(String firstName, String lastName, String birthDate) : base("entrepreneur", firstName, lastName, birthDate, "self-employee")
        {

        }
        public string DoBusiness()
        {
            return "I`m doing business!";
        }
    }
}
