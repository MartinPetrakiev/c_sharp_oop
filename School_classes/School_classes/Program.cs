using System;
using System.Collections.Generic;

namespace School_classes
{
    public class Program
    {
        public static void Main()
        {
            Discipline math = new Discipline()
            {
                Name = "Mathematics",
                NumberOfLectures = 4,
                NumberOfExercises = 3,
                Comment = "Calculus"
            };

            Discipline history = new Discipline()
            {
                Name = "History",
                NumberOfLectures = 3,
                NumberOfExercises = 2,
                Comment = "World history"
            };

            Student student1 = new Student()
            {
                Name = "Katerina",
                ClassNumber = 10,
                Comment = "Top student in class"
            };

            Teacher teacher1 = new Teacher()
            {
                Name = "Mr. Ivanov",
                Comment = "Experienced teacher"
            };
            teacher1.Disciplines.Add(math);
            teacher1.Disciplines.Add(history);

            SchoolClass classA = new SchoolClass
            {
                classId = "Class A",
                Comment = "Grade 10"
            };
            classA.Students.Add(student1);
            classA.Teachers.Add(teacher1);

            // Print
            Console.WriteLine($"Student: {student1.Name}, Class Number: {student1.ClassNumber}");
            Console.WriteLine($"Teacher: {teacher1.Name}");
            Console.WriteLine($"Class: {classA.classId}");

            Console.WriteLine("Taught Disciplines by Teacher:");
            foreach (var discipline in teacher1.Disciplines)
            {
                Console.WriteLine($"- {discipline.Name}");
            }
        }
    }
}
