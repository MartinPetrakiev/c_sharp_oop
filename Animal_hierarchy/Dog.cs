namespace Animal_hierarchy
{
    public class Dog : Animal, ISound
    {
        public Dog(string name, string sex, uint age) :base(name, sex, age)
        {
        }

        public void MakeSound()
        {
            Console.WriteLine("Woof");
        }
    }
}
