using Animal_hierarchy.Interfaces;

namespace Animal_hierarchy
{
    public class Cat : Animal, ISound
    {
        public Cat (string name, string sex, uint age) : base(name, sex, age) { }

        public void MakeSound()
        {
            Console.WriteLine("Meow!");
        }
    }
}
