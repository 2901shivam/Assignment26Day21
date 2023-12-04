using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment26Day21
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Employee employee = new Employee()
            {
                Id = 1,
                FirstName = "Rohan",
                LastName = "Kumar",
                Salary = 35000.00,

            };
            IFormatter formatter = new BinaryFormatter();

                       Stream stream = new FileStream(@"C:\Users\shiva\OneDrive\Desktop\mphasis-b2\ExampleNew.txt", FileMode.Create, FileAccess.Write);
                       formatter.Serialize(stream,employee);
                       stream.Close();

                       stream = new FileStream(@"C:\Users\shiva\OneDrive\Desktop\mphasis-b2\ExampleNew.txt", FileMode.Open,FileAccess.Read);
                       Employee objnew = (Employee)formatter.Deserialize(stream);
                       Console.WriteLine("Binary Serialization");
                       Console.WriteLine(objnew.Id);
                       Console.WriteLine(objnew.FirstName);
                       Console.WriteLine(objnew.LastName);
                       Console.WriteLine(objnew.Salary);
                      stream.Close();
            // Console.ReadKey();


            Employee employee2 = new Employee { Id = 2, FirstName = "Ravi", LastName = "Teja", Salary = 45000.00 };

            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            using (TextWriter write = new StreamWriter("employee2.xml"))
            {
                serializer.Serialize(write, employee2);
            }

            using (TextReader reader=new StreamReader("employee2.xml"))
            {
                Employee deserializedPerson = (Employee)serializer.Deserialize(reader);
                Console.WriteLine("Xml");
                Console.WriteLine(deserializedPerson.Id);
                Console.WriteLine(deserializedPerson.FirstName);
                Console.WriteLine(deserializedPerson.LastName);
                Console.WriteLine(deserializedPerson.Salary);
            }

            Console.ReadKey();


        }
    }
}
