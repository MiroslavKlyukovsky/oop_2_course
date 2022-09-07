using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using read_write;
using System.Text.RegularExpressions;


namespace oop_lab1
{
    class ConsoleMenu
    {
        //Three arrays are exported from .txt files and returned back after work.
        //Object of class input_output is used for it.
        input_output helper = new input_output();
        Student[] stud_array = new Student[] { };
        Baker[] bake_array = new Baker[] { };
        Entrepreneur[] entrep_array = new Entrepreneur[] { };
        public void server() {
            string str = " ";
            helper.setup(ref stud_array,ref bake_array,ref entrep_array);
            while (str != "Stop")
            {
                Console.WriteLine("Menu:\nSee all students: ShowStudents\nSee all bakers: ShowBakers" +
                    "\nShow all entrepreneurs: ShowEntrepreneurs\nAdd student: AddStudent" +
                    "\nRemove student: RemoveStudent\nEdit Student: EditStudent" +
                    "\nFind student: FindStudent\nAdd baker: AddBaker" +
                    "\nRemove baker: RemoveBaker\nAdd entrepreneur: AddEntrepreneur" +
                    "\nRemove entrepreneur: AddEntrepreneur\nFind students with the feature: StudentsWithFeature\nEnd work: Stop");
                str = Console.ReadLine();
                switch (str)
                {
                    case "ShowStudents":
                        showStudents();
                        break;
                    case "ShowBakers":
                        showBakers();
                        break;
                    case "ShowEntrepreneurs":
                        showEntrepreneurs();
                        break;
                    case "AddStudent":
                        addStudent();
                        break;
                    case "RemoveStudent":
                        removeStudent();
                        break;
                    case "AddBaker":
                        addBaker();
                        break;
                    case "RemoveBaker":
                        removeBaker();
                        break;
                    case "AddEntrepreneur":
                        addEntrepreneur();
                        break;
                    case "RemoveEntrepreneur":
                        removeEntrepreneur();
                        break;
                    case "EditStudent":
                        editStudent();
                        break;
                    case "FindStudent":
                        findStudent();
                        break;
                    case "StudentsWithFeature":
                        calculateStudentsWithFeature();
                        break;
                    case "Stop":
                        break;
                    default:
                        Console.WriteLine("Please try again:");
                        break;
                }
            }
            helper.endwork(ref stud_array, ref bake_array, ref entrep_array);
        }
        public void showStudents()
        {
            Student[] arr = stud_array;
            Console.WriteLine("-----------------------");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Student Number: {i+1}");
                Console.WriteLine("-----------------------");
                Console.WriteLine($"First Name: {arr[i].firstName}");
                Console.WriteLine($"Last Name: {arr[i].lastName}");
                Console.WriteLine($"Birth Date: {arr[i].birthDate}");
                Console.WriteLine($"Type of occupation: {arr[i].tp_of_occup}");
                Console.WriteLine($"Course Number: {arr[i].CourseN}");
                Console.WriteLine($"Student ID: {arr[i].StudentID}");
                Console.WriteLine($"Employment Form: {arr[i].employment_form}");
                Console.WriteLine("-----------------------");
            }
            Console.WriteLine("-----------------------");
        }
        public void showBakers()
        {
            Baker[] arr = bake_array;
            Console.WriteLine("-----------------------");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Baker Number: {i + 1}");
                Console.WriteLine("-----------------------");
                Console.WriteLine($"First Name: {arr[i].firstName}");
                Console.WriteLine($"Last Name: {arr[i].lastName}");
                Console.WriteLine($"Birth Date: {arr[i].birthDate}");
                Console.WriteLine($"Type of occupation: {arr[i].tp_of_occup}");
                Console.WriteLine($"Employment Form: {arr[i].employment_form}");
                Console.WriteLine("-----------------------");
            }
            Console.WriteLine("-----------------------");
        }
        public void showEntrepreneurs()
        {
            Entrepreneur[] arr = entrep_array;
            Console.WriteLine("-----------------------");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Entrepreneur Number: {i + 1}");
                Console.WriteLine("-----------------------");
                Console.WriteLine($"First Name: {arr[i].firstName}");
                Console.WriteLine($"Last Name: {arr[i].lastName}");
                Console.WriteLine($"Birth Date: {arr[i].birthDate}");
                Console.WriteLine($"Type of occupation: {arr[i].tp_of_occup}");
                Console.WriteLine($"Employment Form: {arr[i].employment_form}");
                Console.WriteLine("-----------------------");
            }
            Console.WriteLine("-----------------------");
        }
        public void addStudent() {
            Console.WriteLine("His first name:");
            string firstname = Console.ReadLine();

            Console.WriteLine("His last name:");
            string lastname = Console.ReadLine();
            
            Console.WriteLine("His birth date (xx.xx.xxxx):");
            string birthdate = Console.ReadLine();

            Console.WriteLine("His course number:");
            int courseN = Int32.Parse(Console.ReadLine());

            Console.WriteLine("His ID (xxxxxx):");
            int id = Int32.Parse(Console.ReadLine());

            stud_array = stud_array.Append(new Student(firstname,lastname,birthdate,courseN,id)).ToArray();
        }
        public void removeStudent() {
            Console.WriteLine("Write ID of student to be removed: ");
            int id = Int32.Parse(Console.ReadLine());
            foreach (var item in stud_array)
            {
                if (item.StudentID == id)
                {
                    stud_array = stud_array.Where(val => val != item).ToArray();
                }
            }
        }
        public void editStudent() {
            Console.WriteLine("Write ID of student to be edited: ");
            int id = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < stud_array.Length; i++)
            {
                if (stud_array[i].StudentID == id)
                {
                    Console.WriteLine("If you don`t want to change field: press Enter.");
                    Console.WriteLine("His first name:");
                    string firstname = Console.ReadLine();
                    if (firstname == "") {
                        firstname = stud_array[i].firstName;
                        Console.WriteLine("Remained.");
                    }

                    Console.WriteLine("His last name:");
                    string lastname = Console.ReadLine();
                    if (lastname == "")
                    {
                        Console.WriteLine("Remained.");
                        lastname = stud_array[i].lastName;
                    }

                    Console.WriteLine("His birth date (xx.xx.xxxx):");
                    string birthdate = Console.ReadLine();
                    if (birthdate == "")
                    {
                        birthdate = stud_array[i].birthDate;
                        Console.WriteLine("Remained.");
                    }

                    Console.WriteLine("His course number:");
                    int courseN;
                    string str = Console.ReadLine();
                    if (str == "")
                    {
                        courseN = stud_array[i].CourseN;
                        Console.WriteLine("Remained.");
                    }
                    else    
                    {
                        courseN = Int32.Parse(str);
                    }

                    Console.WriteLine("His ID (xxxxxx):");
                    int ID;
                    str = Console.ReadLine();
                    if (str == "")
                    {
                        ID = stud_array[i].StudentID;
                        Console.WriteLine("Remained.");
                    }
                    else
                    {
                        ID = Int32.Parse(str);
                    }

                    stud_array[i] = new Student(firstname, lastname, birthdate, courseN, id);
                    return;
                }
            }
        }
        public void findStudent()
        {
            Console.WriteLine("Write ID of student to be found: ");
            int id = Int32.Parse(Console.ReadLine());
            foreach (var item in stud_array)
            {
                if (item.StudentID == id)
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine($"First Name: {item.firstName}");
                    Console.WriteLine($"Last Name: {item.lastName}");
                    Console.WriteLine($"Birth Date: {item.birthDate}");
                    Console.WriteLine($"Type of occupation: {item.tp_of_occup}");
                    Console.WriteLine($"Course Number: {item.CourseN}");
                    Console.WriteLine($"Student ID: {item.StudentID}");
                    Console.WriteLine($"Employment Form: {item.employment_form}");
                    Console.WriteLine("-----------------------");
                }
            }
        }
        public void addBaker()
        {
            Console.WriteLine("His first name:");
            string firstname = Console.ReadLine();

            Console.WriteLine("His last name:");
            string lastname = Console.ReadLine();

            Console.WriteLine("His birth date (xx.xx.xxxx):");
            string birthdate = Console.ReadLine();

            bake_array = bake_array.Append(new Baker(firstname, lastname, birthdate)).ToArray();
        }
        public void removeBaker() {
            Console.WriteLine("Write first name of baker to be removed: ");
            string firstname = Console.ReadLine();

            Console.WriteLine("Write last name of baker to be removed: ");
            string lastname = Console.ReadLine();

            foreach (var item in bake_array)
            {
                if (item.firstName == firstname && item.lastName == lastname)
                {
                    bake_array = bake_array.Where(val => val != item).ToArray();
                }
            }
        }
        public void addEntrepreneur()
        {
            Console.WriteLine("His first name:");
            string firstname = Console.ReadLine();

            Console.WriteLine("His last name:");
            string lastname = Console.ReadLine();

            Console.WriteLine("His birth date (xx.xx.xxxx):");
            string birthdate = Console.ReadLine();

            entrep_array = entrep_array.Append(new Entrepreneur(firstname, lastname, birthdate)).ToArray();
        }
        public void removeEntrepreneur()
        {
            Console.WriteLine("Write first name of entrepreneur to be removed: ");
            string firstname = Console.ReadLine();

            Console.WriteLine("Write last name of entrepreneur to be removed: ");
            string lastname = Console.ReadLine();

            foreach (var item in entrep_array)
            {
                if (item.firstName == firstname && item.lastName == lastname)
                {
                    entrep_array = entrep_array.Where(val => val != item).ToArray();
                }
            }
        }
        public void calculateStudentsWithFeature() {
            string strRegex = @"^[0-9]{2}\.0[3-5]{1}\.[0-9]{4}$";
            Regex re = new Regex(strRegex);
            int counter = 0;
            foreach (var item in stud_array)
            {
                if (re.IsMatch(item.birthDate) && item.CourseN == 4)
                {
                    counter++;
                }
            }
            Console.WriteLine($"There`re {counter} students which were born in spring and on 4 course now.");
        }
    }
}
