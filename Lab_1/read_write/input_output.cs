using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.IO;
using System.Text.RegularExpressions;

namespace read_write
{
    public class input_output
    {
        public void inputStud(Student[] arr) 
        {
            string str = "";
            foreach (Student item in arr)
            {
                str += $"{item.GetType()} {item.firstName}{item.lastName}\n{{First Name: {item.firstName},\nLast Name: {item.lastName},\nStudent ID: {item.StudentID},\nCourse: {item.CourseN},\nBirth date: {item.birthDate},\nEmployment form: {item.employment_form}}}\n"; 
            }
            string fullPath = "C:/Users/mykva/Desktop/C#_Labs/Students.txt";
            File.WriteAllText(fullPath,str);
        }
        public void outputStud(ref Student[] arr) 
        {
            string[] str = File.ReadAllLines("C:/Users/mykva/Desktop/C#_Labs/Students.txt");
            for (int i = 0; i < str.Length; i+=7)
            {
                arr = arr.Append(new Student(findValue(str[i+1]), findValue(str[i + 2]), findValue(str[i + 5]), Int32.Parse(findValue(str[i + 4])), Int32.Parse(findValue(str[i + 3])))).ToArray();
            }
        }
        public void inputBake(Baker[] arr)
        {
            string str = "";
            foreach (Baker item in arr)
            {
                str += $"{item.GetType()} {item.firstName}{item.lastName}\n{{First Name: {item.firstName},\nLast Name: {item.lastName},\nBirth date: {item.birthDate},\nEmployment form: {item.employment_form}}}\n";
            }
            string fullPath = "C:/Users/mykva/Desktop/C#_Labs/Bakers.txt";
            File.WriteAllText(fullPath, str);
        }
        public void outputBake(ref Baker[] arr)
        {
            string[] str = File.ReadAllLines("C:/Users/mykva/Desktop/C#_Labs/Bakers.txt");
            for (int i = 0; i < str.Length; i += 5)
            {
                arr = arr.Append(new Baker(findValue(str[i + 1]), findValue(str[i + 2]), findValue(str[i + 3]))).ToArray();
            }
        }
        public void inputEntrep(Entrepreneur[] arr)
        {
            string str = "";
            foreach (Entrepreneur item in arr)
            {
                str += $"{item.GetType()} {item.firstName}{item.lastName}\n{{First Name: {item.firstName},\nLast Name: {item.lastName},\nBirth date: {item.birthDate},\nEmployment form: {item.employment_form}}}\n";
            }
            string fullPath = "C:/Users/mykva/Desktop/C#_Labs/Entrepreneurs.txt";
            File.WriteAllText(fullPath, str);
        }
        public void outputEntrep(ref Entrepreneur[] arr)
        {
            string[] str = File.ReadAllLines("C:/Users/mykva/Desktop/C#_Labs/Entrepreneurs.txt");
            for (int i = 0; i < str.Length; i += 5)
            {
                arr = arr.Append(new Entrepreneur(findValue(str[i + 1]), findValue(str[i + 2]), findValue(str[i + 3]))).ToArray();
            }
        }
        protected string findValue(string str) {
            string pattern = @": (.*?),";
            foreach (Match match in Regex.Matches(str, pattern))
            {
                if (match.Success && match.Groups.Count > 0)
                {
                    return match.Groups[1].Value;
            
                }
            }
            return "EROR";
        }
        public void setup(ref Student[] studarr,ref Baker[] bakearr,ref Entrepreneur[] entreparr)
        {
            input_output output = new input_output();
            string curFile = @"C:/Users/mykva/Desktop/C#_Labs/Students.txt";
            if (!(File.Exists(curFile)))
            {
                output.inputStud(new Student[] { });
                outputStud(ref studarr);
            }
            else
            {
                outputStud(ref studarr);
            }
            curFile = @"C:/Users/mykva/Desktop/C#_Labs/Bakers.txt";
            if (!(File.Exists(curFile)))
            {
                output.inputBake(new Baker[] { });
                outputBake(ref bakearr);
            }
            else 
            {
                outputBake(ref bakearr);
            }
            curFile = @"C:/Users/mykva/Desktop/C#_Labs/Entrepreneurs.txt";
            if (!(File.Exists(curFile)))
            {
                output.inputEntrep(new Entrepreneur[] { });
                outputEntrep(ref entreparr);
            }
            else 
            {
                outputEntrep(ref entreparr);
            }
        }
        public void endwork(ref Student[] studarr, ref Baker[] bakearr, ref Entrepreneur[] entreparr) {
            inputStud(studarr);
            inputBake(bakearr);
            inputEntrep(entreparr);
        }
    }
}
