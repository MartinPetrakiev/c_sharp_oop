﻿namespace Students_workers
{
    public class Student : Human
    {
        public Student(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public int Grade
        {
            get; set;
        }
    }
}
