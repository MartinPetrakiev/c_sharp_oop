using Animal_hierarchy.Interfaces;

namespace Animal_hierarchy
{
    public class Frog : Animal, ISound
    {
        public Frog(string name, string sex, uint age) : base(name, sex, age)
        {
        }

        public void MakeSound()
        {
            Console.WriteLine("Croak");
        }
    }
}
