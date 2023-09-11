namespace Students_workers
{
    public class Worker : Human
    {
        public Worker(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public decimal WeekSalary
        {
            get; set;
        }

        public double WorkHoursPerDay
        { 
            get; set;
        }

        public int WorkDaysPerWeek
        { 
            get; set;
        }

        public decimal MoneyPeHour()
        {
            return this.WeekSalary / ((decimal)this.WorkHoursPerDay * (decimal)this.WorkDaysPerWeek);
        }
    }
}
