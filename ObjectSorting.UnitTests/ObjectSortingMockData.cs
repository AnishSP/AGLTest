using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using ObjectSorting;

namespace ObjectSorting.UnitTests
{
    class ObjectSortingMockData
    {

        //public static string CATNAMEWITHOWNERGENDER = "\nMale\n\nGarfield\nJim\nMax\nTom\n\nFemale\n\nGarfield\nSimba\nTabby\n";
        public static string VALIDJSON_OUTPUT = "\nMale\n\nGarfield\nMax\nTom\n\nFemale\n\nGarfield\nTabby\n";
        public static string WRONGURLMESSAGE = "One or more errors occurred. (No such host is known.)";
        public static string NOVALUESTODISPLAY = string.Empty;

        public static List<Person> LISTOFPEOPLENULL = null;
        public static List<Person> LISTOFPEOPLEEMPTYOBJECT = new List<Person>();


        public static List<Person> GetValidJSONPeoplePets()
        {
            var  people = new List<Person>();
            people = new List<Person> { new Person { Name = "Bob", Gender = "Male", Age = 23, Pets = new List<Pet> { new Pet { Name = "Garfield", Type = "Cat" }, new Pet { Name = "Fido", Type = "Dog" }} } ,
            new  Person { Name = "Jennifer", Gender = "Female", Age = 18, Pets = new List<Pet> { new Pet { Name = "Garfield", Type = "Cat" }}},
             new Person { Name = "Steve", Gender = "Male", Age = 45, Pets = null },
                new Person { Name = "Fred", Gender = "Male", Age = 40, Pets = new List<Pet> { new Pet { Name = "Tom", Type = "Cat" }, new Pet { Name = "Max", Type = "Cat" }, new Pet { Name = "Sam", Type = "Dog" } } },
                    new Person { Name = "Samantha", Gender = "Female", Age = 40, Pets = new List<Pet> { new Pet { Name = "Tabby", Type = "Cat" }}}
                 
            };

            return people;
            
        }

        public static List<Person> GetValidJSONPeoplePetsNull()
        {
            var people = new List<Person>();
            var person = new Person();


            people = new List<Person> { new Person { Name = "Bob", Gender = "Male", Age = 23, Pets = null } ,
            new  Person { Name = "Jennifer", Gender = "Female", Age = 18, Pets = null},
             new Person { Name = "Steve", Gender = "Male", Age = 45, Pets = null },
                new Person { Name = "Fred", Gender = "Male", Age = 40, Pets = null},
                    new Person { Name = "Samantha", Gender = "Female", Age = 40, Pets = new List<Pet> { null} }

            };

            return people;
        }


    }
}
