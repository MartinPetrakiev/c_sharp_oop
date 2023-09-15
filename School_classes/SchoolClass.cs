using School_classes.Interfaces;

namespace School_classes
{
    public class SchoolClass : IComments
    {
        public SchoolClass()
        {
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
        }

        public string classId { get; set; }

        public List<Student> Students { get; }

        public List<Teacher> Teachers { get; }

        public string Comments { get; set; }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public void AddTeacher(Teacher teacher)
        {
            Teachers.Add(teacher);
        }
    }
}
