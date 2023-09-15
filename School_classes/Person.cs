namespace School_classes
{
    public class Person : IComment
    {
        public string name;

        public Person(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Comment { get; set; }
    }
}
