namespace School_classes
{
    public class Discipline : IDiscipline
    {
        public string Name { get; set; }

        public uint NumberOfLectures { get; set; }

        public uint NumberOfExercises { get; set; }

        public string Comment { get; set; }
    }
}