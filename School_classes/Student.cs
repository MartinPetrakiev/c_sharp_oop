namespace School_classes
{
    public class Student : Person
    {
        public uint classNumber;

        public Student(string name) : base(name) {}

        public uint ClassNumber
        {
            get { return classNumber; }
            set { classNumber = value; }
        }
    }
}
