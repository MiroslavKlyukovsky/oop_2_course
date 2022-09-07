using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Entities
{
    public class Student : Human
    {
        protected int courseN;
        public int CourseN
        {
            get { return courseN; }
            set
            {
                if (value > courseN)
                {
                    courseN = value;
                }
            }
        }
        protected int studentID;
        public int StudentID
        {
            get { return studentID; }
            set
            {
                if (isValidID(value))
                {
                    studentID = value;
                }
            }
        }
        private bool isValidID(int id)
        {
            string strRegex = @"^[0-9]{6}$";
            Regex re = new Regex(strRegex);
            return re.IsMatch(id.ToString());
        }
        public Student(String firstName, String lastName, String birthDate, int courseN, int studentID) : base("student", firstName, lastName, birthDate, "part-time employee")
        {
            this.CourseN = courseN;
            this.StudentID = studentID;
        }
        public string Study()
        {
            return "I`m studying!";
        }
    }
}
