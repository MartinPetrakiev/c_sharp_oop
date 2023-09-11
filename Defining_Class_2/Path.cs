namespace Defining_Class_2
{
    [Version("1.0")]
    public class Path
    {
        private List<Point3D> points;

        public Path()
        {
            points = new List<Point3D>();
        }

        public void AddPoint(Point3D point)
        {
            points.Add(point);
        }

        public List<Point3D> GetPoints()
        {
            return points;
        }
    }
}
