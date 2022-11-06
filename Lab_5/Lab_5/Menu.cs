using System;
using BLL;

namespace PL
{
    class Menu
    {
        public void MainMenu()
        {
            EntityService_stud server = new EntityService_stud();
            string str = "";
            while (str != "S")
            {
                Console.WriteLine("Menu:\n Take data: T*\n Give data: G*\n Where * is a number(1 - XML, 2 - Bin, 3 - JSON, 4 - Custom)\n" +
                    " End work: S\n Add student: A\n Remove student: R\n Find students with the feature: F\n Info about student: I\n" +
                    " To get all students avalaible: E\n To get to know which student can enroll in the sport team: K\n Want to make people do some work?: W");
                str = Console.ReadLine();
                switch (str[0])
                {
                    case 'T':
                        server.take_data(Int32.Parse(str[1].ToString()));
                        break;
                    case 'G':
                        server.give_data(Int32.Parse(str[1].ToString()));
                        break;
                    case 'A':
                        Console.WriteLine("Please write student data in form like this:\n First_Name Last_name Course_number Student_id Hobby_id level_in_hobby\n Miroslav Kliukovskiy 2 1000 7 5");
                        string[] help = Console.ReadLine().Split(' ');
                        server.add_student(help[0], help[1], Int32.Parse(help[2]), Int32.Parse(help[3]), Int32.Parse(help[4]), Int32.Parse(help[5]));
                        break;
                    case 'R':
                        Console.WriteLine("PLese give the ID of the student to be removed: ");
                        Console.WriteLine(server.remove_student(Int32.Parse(Console.ReadLine())));
                        break;
                    case 'F':
                        Console.WriteLine(server.course_2_sport());
                        break;
                    case 'I':
                        Console.WriteLine("PLese give the ID of the student to get info of: ");
                        Console.WriteLine(server.about_stud(Int32.Parse(Console.ReadLine())));
                        break;
                    case 'S':
                        break;
                    case 'E':
                        Console.WriteLine(server.get_all());
                        break;
                    case 'K':
                        Console.WriteLine("PLese give the sport ID of the student to get the enrollment status of: ");
                        Console.WriteLine(server.enroll_team(Int32.Parse(Console.ReadLine())));
                        break;
                    case 'W':
                        Console.WriteLine("Please enter number ( 1-fireman 2-courier ): ");
                        Console.WriteLine(server.guitar_comming(Int32.Parse(Console.ReadLine())));
                        break;
                    default:
                        Console.WriteLine("Please try again:");
                        break;
                }
            }
        }
    }
}
