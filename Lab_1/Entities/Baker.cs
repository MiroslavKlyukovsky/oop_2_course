using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Baker : Human
    {
        public Baker(String firstName, String lastName, String birthDate) : base("baker", firstName, lastName, birthDate, "employee")
        {

        }
        public string Bake()
        {
            return "I`m baking!";
        }
    }
}
