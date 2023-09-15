using School_classes.Interfaces;

namespace School_classes
{
    public class Student : IPerson, IComments
    {
        public string Name { get; set; }

        public uint ClassNumber { get; set; }

        public string Comments { get; set; }
    }
}
