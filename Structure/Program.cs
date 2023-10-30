using System.Drawing;

namespace Structure
{
    public struct Point3D
    {
        public double X;
        public double Y;
        public double Z;

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}, Z: {Z}";
        }

    }
    class Program
    {
        public static void Main(string[] args)
        {
            Point3D point = new Point3D(2.5, 3, -1);
            Console.WriteLine(point.ToString());
        }
    }
}
