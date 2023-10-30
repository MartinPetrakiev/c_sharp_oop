namespace School_classes.Interfaces
{
    public interface IDiscipline
    {
        string Name { get; set; }

        uint NumberOfLectures { get; set; }

        uint NumberOfExercises { get; set; }
    }
}