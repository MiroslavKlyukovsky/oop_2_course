using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Entities
{
    public class Human
    {   
        public string tp_of_occup { get; }
        public string employment_form { get; }
        public string firstName { get; }
        public string lastName { get; }
        public string birthDate { get; }
        public Human(string tp_of_ocup, string firstName, string lastName, string birthDate, string employment_form)
        {
                this.tp_of_occup = tp_of_ocup;
                this.firstName = firstName;
                this.lastName = lastName;
                this.employment_form = employment_form;
                if (isValidDate(birthDate))
                {
                    this.birthDate = birthDate;
                }
                else
                {
                    this.birthDate = "00.00.0000";
                }
        }
        public string parachute()
        {
                return $"My name is {firstName}. I`m {tp_of_occup}, {employment_form} and I`m parachuting!!!";
        }
        private bool isValidDate(string date)
        {
                string strRegex = @"^[0-9]{2}\.[0-1]{1}[0-9]{1}\.[0-9]{4}$";
                Regex re = new Regex(strRegex);
                return re.IsMatch(date);
        }
        
    }
}
