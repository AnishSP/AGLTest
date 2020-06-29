using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectSorting
{
    /// <summary>
    /// Model class for defining the Person's attributes
    /// </summary>
    public class Person
    {
        public string Name { get; set; }
        public string Gender { get; set; }

        public int Age { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
