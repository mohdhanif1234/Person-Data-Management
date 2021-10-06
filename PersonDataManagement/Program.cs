using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDataManagement
{
    class Program
    {
        // UC-2: Retrieving top 2 records from the list whose age is less than 60 years
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>();
            AddPersonDetails(list); // Calling method to add person details
            RetrieveTop2Records(list);
            Console.ReadLine();
        }
        
        public static void AddPersonDetails(List<Person> list)
        {
            list.Add(new Person() { SSN = 1, Name = "Shrikanth", Address = "Bangalore", Age = 14 });
            list.Add(new Person() { SSN = 2, Name = "UV", Address = "Mumbai", Age = 70 });
            list.Add(new Person() { SSN = 3, Name = "Arun", Address = "Chennai", Age = 32 });
            list.Add(new Person() { SSN = 4, Name = "Kalpana", Address = "Delhi", Age = 16 });
            list.Add(new Person() { SSN = 5, Name = "Sachin", Address = "Pune", Age = 63 });
            list.Add(new Person() { SSN = 6, Name = "Arun", Address = "Kolkata", Age = 36 });
            IterateOverLoop(list);
        }

        // Displaying the person details from the list
        public static void IterateOverLoop(List<Person> list)
        {
            foreach (Person person in list)
            {
                Console.WriteLine("SSN={0}\tName={1}\tAddress={2}\tAge={3}", person.SSN, person.Name, person.Address, person.Age);
            }
            Console.WriteLine("");
        }

        // Retrieving top 2 records from the list whose age is less than 60 years
        public static void RetrieveTop2Records(List<Person> list)
        {
            Console.WriteLine("Retrieving top 2 records from the list whose age is less than 60 years");
            Console.WriteLine("");
            List<Person> result = list.FindAll(person => person.Age < 60).OrderBy(s => s.Age).Take(2).ToList();
            IterateOverLoop(result);
        }
    }
}
