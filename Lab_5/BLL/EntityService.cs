using System;
using System.Collections.Generic;
using DAL;
using DAL.Entities;

namespace BLL
{
    public class EntityService_stud
    {
        private Student[] students;
        public bool take_data(int ser_type)
        {
            EntityContext<Student> cont = new EntityContext<Student>();
            switch (ser_type)
            {
                case 1:
                    students = cont.ReadXML();
                    return true;
                case 2:
                    students = cont.ReadBin();
                    return true;
                case 3:
                    students = cont.ReadJSON(); ;
                    return true;
                case 4:
                    students = cont.ReadCustom();
                    return true;
                default:
                    return false;
            }
        }
        public bool give_data(int deser_type)
        {
            EntityContext<Student> cont = new EntityContext<Student>();
            switch (deser_type)
            {
                case 1:
                    cont.WriteXML(students);
                    return true;
                case 2:
                    cont.WriteBin(students); ;
                    return true;
                case 3:
                    cont.WriteJSON(students);
                    return true;
                case 4:
                    cont.WriteCustom(students);
                    return true;
                default:
                    return false;
            }
        }
        public bool add_student(String firstName, String lastName, int courseN, int studentID, int Hobby_id, int level_in_sport)
        {
            if (students != null)
            {
                var tmp = new Student[students.Length + 1];
                int i = 0;
                for (; i < students.Length; i++)
                {
                    tmp[i] = students[i];
                }
                tmp[i] = new Student(firstName, lastName, courseN, studentID, Hobby_id, level_in_sport);
                students = tmp;
                return true;
            }
            else
            {
                var tmp = new Student[1];
                tmp[0] = new Student(firstName, lastName, courseN, studentID, Hobby_id, level_in_sport);
                students = tmp;
                return true;
            }
        }
        public string remove_student(int stud_id)
        {
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
                if (students[0].studentID == stud_id)
                {
                    students = null;
                    return $"Student with ID {stud_id} was successfully removed.";
                }
                return $"There are no students with ID {stud_id}";
            }
            return "There are no students at all!";
        }
        public int course_2_sport()
        {
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
        public string about_stud(int stud_id)
        {
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
        public string get_all()
        {
            string output = "";
            if (students == null) { return "There are no students!"; }
            foreach (var item in students)
            {
                output += item.ToString() + '\n';
            }
            return output;
        }
        public string enroll_team(int sport_id)
        {
            int i = 1;
            List<Student> LisTrass = new List<Student>();
            foreach (var item in students)
            {
                LisTrass.Add(item);
            }
            LisTrass.Sort((x, y) => x.level_in_sport.CompareTo(y.level_in_sport));
            foreach (var item in LisTrass)
            {

                if (item.hobby_id == sport_id)
                {
                    if ((students.Length * 0.9) <= i)
                    {
                        return $"Student with sport ID: {sport_id} can enroll in the sport team!";
                    }
                    else
                    {
                        return $"Student with sport ID: {sport_id} can't enroll in the sport team!";
                    }
                }
                i++;
            }
            return $"Student with sport ID: {sport_id} doesn't even exist!";
        }
        public string guitar_comming(int which) {
            switch (which)
            {
                case 1:
                    Fireman man = new Fireman("Viktor", "Tyshila");
                    Random rnd = new Random();
                    if (rnd.Next() % 2 == 0)
                    {
                        return $"Fireman {man.firstName} {man.lastName} has arrived in time. {man.play_the_guitar()}. {man.fire_extinguishing()}";
                    }
                    return $"Fireman {man.firstName} {man.lastName} hasn't arrived in time. {man.fire_extinguishing()}";
                case 2:
                    Courier man1 = new Courier("Viktor", "Dostavko");
                    Random rnd1 = new Random();
                    if (rnd1.Next() % 2 == 0)
                    {
                        return $"Courier {man1.firstName} {man1.lastName} has arrived in time. {man1.play_the_guitar()}. {man1.deliver()}";
                    }
                    return $"Courier {man1.firstName} {man1.lastName} hasn't arrived in time. {man1.deliver()}";
                default:
                    break;
            }
            return "Wrong number!";
        }
    }
}