using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    [Serializable]
    public class Human
    {
        public string tp_of_occup { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public Human()
        {

        }
        public Human(string tp_of_ocup, string firstName, string lastName)
        {
            this.tp_of_occup = tp_of_ocup;
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public string play_the_guitar()
        {
            return $"My name is {firstName}. I`m {tp_of_occup}. Watch me playing the guitar!";
        }
    }
}
