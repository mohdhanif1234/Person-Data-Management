using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDataManagement
{
    class Program
    {
        // UC-7: Removing specific name from the list
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>();
            AddPersonDetails(list); // Calling method to add person details
            //RetrieveTop2Records(list);
            //RetrieveTeenageAgeRecords(list);
            //FindoutAverageage(list);
            Console.Write("Enter the name of the person you want to remove from the list: ");
            string name = Console.ReadLine();
            //SearchName(list, name);
            //RetrieveRecordsAgeabove60(list);
            RemovePerson(list, name);
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

        // Retrieving teenage age records from the list whose age is between 13 and 18 years
        public static void RetrieveTeenageAgeRecords(List<Person> list)
        {
            Console.WriteLine("Retrieving teenage age records between 13 and 18 years");
            Console.WriteLine("");
            List<Person> result = list.FindAll(p => p.Age >= 13 && p.Age <= 18).ToList();
            IterateOverLoop(result);
        }

        // Retrieving average age from the list
        public static void FindoutAverageage(List<Person> list)
        {
            Console.WriteLine("Retrieving average age");
            var result = list.Average<Person>(p => p.Age);
            Console.WriteLine("Average age = " + result + " years");
        }

        // Checking whether a specific name is present in the list or not

        public static Person SearchName(List<Person> list, string name)
        {
            try
            {
                Console.WriteLine();
                var personObj = list.Find(p => p.Name == name);
                if (personObj != null)
                {
                    Console.WriteLine(name + " is present in the list" + "\n");
                    return personObj;
                }
                else
                {
                    Console.WriteLine(name + " is not present in the list");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // Skipping the age from the list less than 60 years
        public static void RetrieveRecordsAgeabove60(List<Person> list)
        {
            Console.WriteLine("Displaying age above 60 years");
            Console.WriteLine("");
            List<Person> result = list.FindAll(p => p.Age > 60).Skip(0).ToList();
            IterateOverLoop(result);
        }

        // Removing a specific person details from the list
        public static void RemovePerson(List<Person> list, string name)
        {
            Person result = SearchName(list, name);
            if (result != null)
            {
                list.Remove(result);
                Console.WriteLine("The new list after removing "+ name + "'s" +" details is" + "\n");
                IterateOverLoop(list);
            }
            else
            {
                Console.WriteLine("");
                IterateOverLoop(list);
            }
        }
    }
}
