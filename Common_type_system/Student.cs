using Common_type_system.Enum;
using System.Xml.Linq;

namespace Common_type_system
{
    public class Student : ICloneable
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string ssn;

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public string PermanentAddress { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public uint Course { get; set; }
        public Specialty StudentSpecialty { get; set; }
        public University StudentUniversity { get; set; }
        public Faculty StudentFaculty { get; set; }

        public Student
            (
                string firstName, string middleName, string lastName, string ssn,
                string permanentAddress, string mobilePhone, string email, uint course,
                Specialty specialty, University university, Faculty faculty
            )
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.StudentSpecialty = specialty;
            this.StudentUniversity = university;
            this.StudentFaculty = faculty;
        }

        public override bool Equals(object obj)
        {
            bool IsEqual = false;
            Student testedStudent = obj as Student;
            if (testedStudent != null)
            {
                IsEqual = base.Equals((Student)obj) && SSN == testedStudent.SSN;
            }
            return IsEqual;
        }

        public override int GetHashCode()
        {
            return SSN.GetHashCode();
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.MiddleName} {this.LastName}, (SSN: {this.SSN})\n" +
                   $"e-mail: {this.MobilePhone}, mobile phone: {this.MobilePhone}\n" +
                   $"Student at: {this.StudentUniversity}, faculty: {this.StudentFaculty}";
        }

        public static bool operator ==(Student student1, Student student2)
        {

            bool areEqual = student1?.Equals(student2) == true; //check student1 is not null and if both students are equal

            if (student1 is null && student2 is null)
            {
                areEqual = true;
            }
                
            return areEqual;
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !(student1 == student2);
        }

        public object Clone()
        {
            Student clonedStudent = new Student
                (
                    FirstName, MiddleName, LastName, SSN,
                    PermanentAddress, MobilePhone, Email, 
                    Course, StudentSpecialty, StudentUniversity, StudentFaculty
                );

            return clonedStudent;
        }
    }
}
