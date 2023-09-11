namespace Shapes
{
    class Program
    {
        public static void Main(string[] args)
        {
            Shape[] shapes = new Shape[]
            {
                new Triangle(4, 5),
                new Rectangle(6, 7),
                new Square(8)
            };

            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"Surface Area {shape.GetType().Name}: {shape.CalculateSurface()} square units");
            }
        }
    }
}
