using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee obj = new Employee()
            {
                ID = 5,
                FirstName = "ramesh",
                LastName = "Kumar",
                Salary = 75000.29

            };
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"C:\Users\User\OneDrive\Desktop\Assigment\Assignment Day21\Assignment26\Assignment26.txt", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, obj);
            stream.Close();

            stream = new FileStream(@"C:\Users\User\OneDrive\Desktop\Assigment\Assignment Day21\Assignment26\Assignment26.txt", FileMode.Open, FileAccess.Read);
            Employee empdata = (Employee)formatter.Deserialize(stream);
            Console.WriteLine("ID:" + empdata.ID);
            Console.WriteLine("first Name :" + empdata.FirstName);
            Console.WriteLine("Last Name :" + empdata.LastName);
            Console.WriteLine("Salary :" + empdata.Salary);

            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            using (TextWriter writer = new StreamWriter("employee.xml"))
            {
                serializer.Serialize(writer, obj);
            }
            // deserialize the object from xml
            using (TextReader reader = new StreamReader("employee.xml"))
            {
                Employee deserializedemployee = (Employee)serializer.Deserialize(reader);
                Console.WriteLine($"ID: {deserializedemployee.ID} , firstname: {deserializedemployee.FirstName}, LastName: {deserializedemployee.LastName}, Salary: {deserializedemployee.Salary} ");
            }
            Console.ReadKey();
        }
    }
}