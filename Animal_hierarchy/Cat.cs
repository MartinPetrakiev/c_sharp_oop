namespace Animal_hierarchy
{
    public class Cat : Animal, ISound
    {
        public Cat (string name, string sex, int age) : base(name, sex, age) { }

        public void MakeSound()
        {
            Console.WriteLine("Meow!");
        }
    }
}
