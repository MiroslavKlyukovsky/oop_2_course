using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace DAL
{
    [Serializable]
    public class Student : Human
    {
        public int courseN { set; get; }   
        public int studentID { set; get; }
        public string hobby { set; get; }
        public int hobby_id { set; get; }
        public Student()
        {
                
        }
        public Student(String firstName, String lastName, int courseN, int studentID, string Hobby, int Hobby_id) : base("student", firstName, lastName)
        {
            this.courseN = courseN;
            this.studentID = studentID;
            hobby = Hobby;
            hobby_id = Hobby_id;
        }
        public string Study()
        {
            return "I`m studying!";
        }
        public override string ToString()
        {
            return $"First name: {firstName}\nLast name: {lastName}\nStudent ID: {studentID}\nStudent course: {courseN}\nStudent hobby: {hobby}\nStudent hobby id: {hobby_id}";
        }
    }
}
