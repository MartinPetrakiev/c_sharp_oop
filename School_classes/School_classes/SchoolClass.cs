using System;
using System.Collections.Generic;

namespace School_classes
{
    internal class SchoolClass
    {
        public string classId
        {
            get; set;
        }

        public List<Student> Students
        {
            get; set;
        } = new List<Student>();

        public List<Teacher> Teachers 
        { 
            get; set; 
        } = new List<Teacher>();

        public string Comment
        {
            get; set;
        }
    }
}
