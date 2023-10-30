using System;
using System.Collections.Generic;
using System.Linq;

namespace Animal_hierarchy
{
    class Program
    {
        public static List<AnimalAverageAge> GetAverageAges(Animal[] animals)
        {
            return animals.GroupBy(a => a.GetType().Name)
                            .Select(group =>
                            {
                                string animalType = group.Key;
                                double averageAge = group.Average(a => a.Age);
                                return new AnimalAverageAge(animalType, averageAge);
                            })
                            .ToList();
        }

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

            var averageAges = GetAverageAges(animals);

            foreach (var avgAge in averageAges)
            {
                Console.WriteLine($"{avgAge.AnimalType} - Average Age: {avgAge.AverageAge}");
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

            Console.ReadLine();
        }
    }
}

/*
3 Animal hierarchy

Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods. Dogs, frogs and cats are Animals. 
All animals can produce sound (specified by the ISound interface). Kittens and tomcats are cats. All animals are described by age, name and sex. 
Kittens can be only female and tomcats can be only male. Each animal produces a specific sound.
Create arrays of different kinds of animals and calculate the average age of each kind of animal using a static method (you may use LINQ).
*/