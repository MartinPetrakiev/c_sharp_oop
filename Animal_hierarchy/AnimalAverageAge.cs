namespace Animal_hierarchy
{
    public class AnimalAverageAge
    {
        public string AnimalType { get; set; }
        public double AverageAge { get; set; }

        public AnimalAverageAge(string animalType, double averageAge)
        {
            this.AnimalType = animalType;
            this.AverageAge = averageAge;
        }
    }
}
