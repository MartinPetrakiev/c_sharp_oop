namespace Animal_hierarchy
{
    public interface ISound
    {
        void MakeSound();
    }

    public class Animal
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }

        public Animal(string name, string sex, int age)
        {
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
        }
    }
}
