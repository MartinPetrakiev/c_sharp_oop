using System;
using System.Collections.Generic;

namespace School_classes
{
    public class Teacher : Person
    {
        public Teacher()
        {
            this.Disciplines = new List<Discipline>();
        }

        public List<Discipline> Disciplines 
        { 
            get; set; 
        }
    }
}
