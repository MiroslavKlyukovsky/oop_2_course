using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    [Serializable]
    public class Student : Human
    {
        public int courseN { set; get; }
        public int studentID { set; get; }
        public string hobby { set; get; }
        public int hobby_id { set; get; }
        public int level_in_sport { set; get; }
        public Student()
        {

        }
        public Student(String firstName, String lastName, int courseN, int studentID, int Hobby_id, int level_in_sport) : base("student", firstName, lastName)
        {
            this.courseN = courseN;
            this.studentID = studentID;
            hobby = "sport";
            hobby_id = Hobby_id;
            this.level_in_sport = level_in_sport;
        }
        public string Study()
        {
            return "I`m studying!";
        }
        public override string ToString()
        {
            return $"First name: {firstName}\nLast name: {lastName}\nStudent ID: {studentID}\nStudent course: {courseN}\nStudent hobby: {hobby}\nStudent hobby id: {hobby_id}\nLevel in sport: {level_in_sport}";
        }
    }
}
