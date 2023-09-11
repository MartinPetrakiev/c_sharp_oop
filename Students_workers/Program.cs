namespace Students_workers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<Worker> workers = new List<Worker>();

            string[] firstNameExamples = {"Wade","Dave","Seth","Ivan","Riley","Daisy","Deborah","Isabel","Stella","Debra" };
            string[] lastNameExamples = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez" };

            for (int i = 0; i < 10; i++)
            {
                Random random = new Random();

                int randomIndex = random.Next(0,firstNameExamples.Length);

                int randomGrade = random.Next(1,13);
                decimal randomWeekSalary = new decimal(random.Next(random.Next(25,100), random.Next(100, 1001)));
                double randomWorkHoursPerDay = (double)random.Next(1, 13);
                int randomWorkDaysPerWeek = random.Next(1, 8);

                Student student = new Student(firstNameExamples[randomIndex], lastNameExamples[randomIndex]);
                student.Grade = randomGrade;
                students.Add(student);

                Worker worker = new Worker(firstNameExamples[randomIndex], lastNameExamples[randomIndex]);
                worker.WeekSalary = randomWeekSalary;
                worker.WorkDaysPerWeek = randomWorkDaysPerWeek;
                worker.WorkHoursPerDay = randomWorkHoursPerDay;
                workers.Add(worker);
            }

            Console.WriteLine("---------Students---------");

            IEnumerable<Student> queryStudents = students.OrderBy(student => student.Grade);
            foreach (Student student in queryStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
                Console.WriteLine($"- grade: {student.Grade}");
            }

            Console.WriteLine("---------Workers---------");

            IEnumerable<Worker> queryWorkers = workers.OrderBy(worker => worker.MoneyPeHour());
            foreach (Worker worker in queryWorkers)
            {
                Console.WriteLine($"{worker.FirstName} {worker.LastName}");
                Console.WriteLine($"- Money per hour: {worker.MoneyPeHour():F2}");
            }

            List<Human> mergedList = new List<Human>();
            mergedList.AddRange(students);
            mergedList.AddRange(workers);

            Console.WriteLine("---------All Humans---------");

            IEnumerable<Human> queryHumans = mergedList.OrderBy(human => human.FirstName).ThenBy(human => human.LastName);
            foreach (Human human in queryHumans)
            {
                Console.WriteLine($"{human.FirstName} {human.LastName}");
            }
        }
    }
}
