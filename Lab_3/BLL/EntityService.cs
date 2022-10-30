using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class EntityService_stud
    {
        private Student[] students;
        public void take_data(int ser_type) {
            EntityContext<Student> cont = new EntityContext<Student>();
            switch (ser_type)
            {
                case 1:
                    students = cont.ReadXML();
                    break;
                case 2:
                    students = cont.ReadBin();
                    break;
                case 3:
                    students = cont.ReadJSON(); ;
                    break;
                case 4:
                    students = cont.ReadCustom();
                    break;
                default:
                    break;
            }
        }
        public void give_data(int deser_type) { 
            EntityContext<Student> cont = new EntityContext<Student>();
            switch (deser_type)
            {
                case 1:
                    cont.WriteXML(students);
                    break;
                case 2:
                    cont.WriteBin(students); ;
                    break;
                case 3:
                    cont.WriteJSON(students);
                    break;
                case 4:
                    cont.WriteCustom(students);
                    break;
                default:
                    break;
            }
        }
        public void add_student(String firstName, String lastName, int courseN, int studentID, string Hobby, int Hobby_id) {
            if (students != null)
            {
                var tmp = new Student[students.Length + 1];
                int i = 0;
                for (; i < students.Length; i++)
                {
                    tmp[i] = students[i];
                }
                tmp[i] = new Student(firstName, lastName, courseN, studentID, Hobby, Hobby_id);
                students = tmp;
            }
            else
            {
                var tmp = new Student[1];
                tmp[0] = new Student(firstName, lastName, courseN, studentID, Hobby, Hobby_id);
                students = tmp;

            }
        }
        public string remove_student(int stud_id) {
            if (students != null && students.Length > 1)
            {
                bool flag = false;
                foreach (var item in students)
                {
                    if (item.studentID == stud_id) { flag = true; }
                }

                if (flag)
                {
                    var tmp = new Student[students.Length - 1];
                    int i = 0;
                    foreach (var item in students)
                    {
                        if (item.studentID != stud_id) { tmp[i] = item; i++; }
                    }
                    students = tmp;
                    return $"Student with ID {stud_id} was successfully removed.";
                }
                return $"There are no students with ID {stud_id}";
            }
            if (students != null && students.Length == 1)
            {
                if (students[0].studentID == stud_id) {
                    students = null;
                    return $"Student with ID {stud_id} was successfully removed.";
                }
                return $"There are no students with ID {stud_id}";
            }
            return "There are no students at all!";
        }
        public int course_2_sport() {
            if (students == null) { return 0; }
            int count = 0;
            foreach (var student in students)
            {
                if (student != null && student.courseN == 2 && student.hobby == "sport")
                {
                    count++;
                }
            }
            return count;
        }
        public string about_stud(int stud_id) {
            if (students == null) { return "There are no students at all!"; }
            foreach (var item in students)
            {
                if (item.studentID == stud_id)
                {
                    return item.ToString();
                }
            }
            return "There are no student with this ID.";
        }
        public string get_all() {
            string output = "";
            if (students == null) {return "There are no students!";}
            foreach (var item in students)
            {
                output += item.ToString()+'\n';
            }
            return output;
        }
    }
}
