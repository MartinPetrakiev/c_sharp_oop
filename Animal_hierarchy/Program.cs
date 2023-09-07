﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Animal_hierarchy
{
    class Program
    {
        public static void Main(string[] args)
        {
            Animal[] animals = new Animal[]
            {
                new Dog("Pancho", "Male", 3),
                new Frog("Froggy", "Male", 1),
                new Cat("Whiskers", "Female", 4),
                new Kitten("Pisi", 1),
                new Tomcat("Tom", 5)
            };

            var averageAges = animals.GroupBy(a => a.GetType().Name)
                                        .Select(group => new
                                        {
                                            AnimalType = group.Key,
                                            AverageAge = group.Average(a => a.Age)
                                        });

            foreach (var avgAge in averageAges)
            {
                Console.WriteLine($"{avgAge.AnimalType}: Average Age = {avgAge.AverageAge}");
            }

            Dog[] dogs = new Dog[]
            {
                new Dog("Pes", "Male", 4),
                new Dog("Sara", "Female", 2),
                new Dog("Roshko", "Male", 1),
            };

            foreach (Dog dog in dogs)
            {
                Console.WriteLine($"{dog.Name} says: ");
                dog.MakeSound();
            }
        }
    }
}
