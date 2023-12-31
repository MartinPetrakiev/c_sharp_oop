﻿namespace School_classes
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
                Comments = "Calculus"
            };

            Discipline history = new Discipline()
            {
                Name = "History",
                NumberOfLectures = 3,
                NumberOfExercises = 2,
                Comments = "World history"
            };

            Student student1 = new Student()
            {
                Name = "Katerina",
                ClassNumber = 10,
                Comments = "Top student in class"
            };

            Teacher teacher1 = new Teacher()
            {
                Name = "Mr. Ivanov",
                Comments = "Experienced teacher"
            };
            teacher1.Disciplines.Add(math);
            teacher1.Disciplines.Add(history);

            SchoolClass classA = new SchoolClass
            {
                classId = "Class A",
                Comments = "Grade 10"
            };
            classA.AddStudent(student1);
            classA.AddTeacher(teacher1);

            // Print
            Console.WriteLine($"Student: {student1.Name}, Class Number: {student1.ClassNumber}");
            Console.WriteLine($"Teacher: {teacher1.Name}");
            Console.WriteLine($"Class: {classA.classId}");

            Console.WriteLine("Taught Disciplines by Teacher:");
            foreach (var discipline in teacher1.Disciplines)
            {
                Console.WriteLine($"- {discipline.Name} ({discipline.Comments}) -- Lectures: {discipline.NumberOfLectures}, Excercises: {discipline.NumberOfExercises}");
            }

            Console.ReadLine();
        }
    }
}

/*
1 School classes

We are given a school. In the school there are classes of students. Each class has a set of teachers. Each teacher teaches, a set of disciplines. Students have a name and unique class number. 
Classes have unique text identifier. Teachers have a name.
Disciplines have a name, number of lectures and number of exercises. Both teachers and students are people. 
Students, classes, teachers and disciplines could have optional comments (free text block).

Your task is to identify the classes (in terms of OOP) and their attributes and operations, encapsulate their fields, define the class hierarchy and create a class diagram with Visual Studio.
*/