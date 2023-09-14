namespace Animal_hierarchy
{
    public class Animal
    {
        public uint Age { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }

        public Animal(string name, string sex, uint age)
        {
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
        }
    }
}
