using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using System;
using DAL.Entities;

namespace DAL
{
    public class EntityContext<T> where T : Human
    {
        public void WriteXML(T[] entities)
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(T[]));

            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "//Students.xml";

            using (FileStream fs = new FileStream(path.ToString(), FileMode.OpenOrCreate))
            {
                writer.Serialize(fs, entities);
            }
        }
        public T[] ReadXML()
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(T[]));

            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "//Students.xml";

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                return (T[])reader.Deserialize(fs);
            }
        }
        public void WriteBin(T[] entities)
        {
            if (entities == null)
            {
                BinaryFormatter formatte = new BinaryFormatter();

                using (FileStream fs = new FileStream(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "//Students.dat", FileMode.OpenOrCreate))
                {

                }
                return;
            }
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "//Students.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, entities);
            }
        }
        public T[] ReadBin()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "//Students.dat", FileMode.Open))
            {
                if (fs.Length != 0)
                {
                    return (T[])formatter.Deserialize(fs);
                }
                return null;
            }
        }
        public void WriteJSON(T[] entities)
        {
            string fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "//Students.json";
            string jsonString = JsonSerializer.Serialize(entities);
            File.WriteAllText(fileName, jsonString);
        }
        public T[] ReadJSON()
        {
            string fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "//Students.json";
            string jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<T[]>(jsonString);
        }
        public void WriteCustom(Student[] entities)
        {
            if (entities == null)
            {
                string fullPat = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "//Students.txt";
                File.WriteAllText(fullPat, "");
                return;
            }
            string str = "";
            foreach (Student item in entities)
            {
                str += $"{item.GetType()} {item.firstName}{item.lastName}\n{{First Name: {item.firstName},\nLast Name: {item.lastName},\nStudent ID: {item.studentID},\nCourse: {item.courseN},\nHobby: {item.hobby},\nHobby ID: {item.hobby_id},\nLevel in sport: {item.level_in_sport},}}\n";
            }
            string fullPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "//Students.txt";
            File.WriteAllText(fullPath, str);
        }
        public Student[] ReadCustom()
        {
            Student[] students = null;
            string[] str = File.ReadAllLines(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "//Students.txt");

            for (int i = 0; i < str.Length; i += 8)
            {
                //j for copying, i for iterating
                if (students != null)
                {
                    var tmp = new Student[students.Length + 1];

                    int j = 0;
                    for (; j < students.Length; j++)
                    {
                        tmp[j] = students[j];
                    }

                    tmp[j] = new Student(findValue(str[i + 1]), findValue(str[i + 2]), Int32.Parse(findValue(str[i + 4])), Int32.Parse(findValue(str[i + 3])), Int32.Parse(findValue(str[i + 6])), Int32.Parse(findValue(str[i + 7])));
                    students = tmp;
                }
                else
                {
                    students = new Student[1];
                    students[0] = new Student(findValue(str[i + 1]), findValue(str[i + 2]), Int32.Parse(findValue(str[i + 4])), Int32.Parse(findValue(str[i + 3])), Int32.Parse(findValue(str[i + 6])), Int32.Parse(findValue(str[i + 7])));
                }
            }
            return students;
        }
        protected string findValue(string str)
        {
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
    }
}
