using System;
using System.Collections.Generic;

namespace School_classes
{
    public class SchoolClass : IComment
    {
        public SchoolClass()
        {
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
        }

        public string classId { get; set; }

        public List<Student> Students { get; set; }

        public List<Teacher> Teachers { get; set; }

        public string Comment { get; set; }
    }
}
