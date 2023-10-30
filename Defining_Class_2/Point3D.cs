namespace Defining_Class_2
{
    [Version("1.0")]
    public struct Point3D
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        private static readonly Point3D origin = new Point3D(0, 0, 0);

        public static Point3D Origin
        {
            get { return origin; }
        }

        public override string ToString()
        {
            return $"{{{X}, {Y}, {Z}}}";
        }
    }
}
