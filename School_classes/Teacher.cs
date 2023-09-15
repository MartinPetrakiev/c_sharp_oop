using School_classes.Interfaces;

namespace School_classes
{
    public class Teacher : IPerson, IComments
    {
        public Teacher()
        {
            this.Disciplines = new List<Discipline>();
        }

        public string Name { get; set; }

        public List<Discipline> Disciplines { get; set; }

        public string Comments { get; set; }
    }
}