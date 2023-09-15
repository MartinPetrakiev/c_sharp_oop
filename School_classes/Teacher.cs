﻿using System;
using System.Collections.Generic;

namespace School_classes
{
    public class Teacher : Person
    {
        public Teacher(string name) : base(name)
        {
            this.Disciplines = new List<Discipline>();
        }

        public List<Discipline> Disciplines { get; set; }
    }
}