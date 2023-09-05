using System;
using System.Collections.Generic;

namespace School_classes
{
    internal class Teacher : Person
    {
        public List<Discipline> Disciplines 
        { 
            get; set; 
        } = new List<Discipline>();
    }
}
