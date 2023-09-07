namespace Animal_hierarchy
{
    public class Frog : Animal, ISound
    {
        public Frog(string name, string sex, int age) : base(name, sex, age)
        {
        }

        public void MakeSound()
        {
            Console.WriteLine("Croak");
        }
    }
}
