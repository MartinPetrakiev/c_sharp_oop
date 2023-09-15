using School_classes.Interfaces;

namespace School_classes
{
    public class Discipline : IDiscipline, IComments
    {
        public string Name { get; set; }

        public uint NumberOfLectures { get; set; }

        public uint NumberOfExercises { get; set; }

        public string Comments { get; set; }
    }
}