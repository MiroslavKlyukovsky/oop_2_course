using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Linq;
using DAL.Entities;
using System.Xml.Linq;

namespace DAL
{
    public class EntityContext<T>
    {
        public string name_of_file = "DEFAULT";
        public EntityContext()
        {
            if (typeof(T) == typeof(Flat))
            {
                name_of_file = "flats";
            }
            if (typeof(T) == typeof(Сlient))
            {
                name_of_file = "clients";
            }
        }
        public void Write(List<T> entities)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "//" + name_of_file + ".xml";

            if (entities.Count == 0)
            {
                File.Delete(path);//This was done because of bug: Trying to seri. empty list to file where is not empty list.
            }

            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<T>));

            using (FileStream fs = new FileStream(path.ToString(), FileMode.OpenOrCreate))
            {
                writer.Serialize(fs, entities);
            }
        }
        public List<T> Read()
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<T>));

            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "//" + name_of_file + ".xml";
            
            if (!File.Exists(path))
            {
                //new XDocument(/*new XElement("root", new XElement("someNode", "someValue"))*/).Save(name_of_file + ".xml");
                List<T> output = new List<T>();
                return output;
            }

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                return (List<T>)reader.Deserialize(fs);
            }
        }
    
    }
}
