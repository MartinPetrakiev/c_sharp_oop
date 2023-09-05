namespace School_classes
{
    internal class Student : Person
    {
        private int classNumber;

        public int ClassNumber
        {
            get { return classNumber; }
            set { classNumber = value; }
        }
    }
}
