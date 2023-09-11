using System;
using System.Collections.Generic;

namespace School_classes
{
    public class Person
    {
        private string name;

        public Person()
        {
        }

        public Person(string name) 
        {
            this.Name = name;
        }

        public string Name 
        { 
            get { return name; }
            set { name = value; } 
        }

        public string Comment 
        { 
            get; set; 
        }
    }
}
