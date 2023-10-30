namespace Defining_Class_2
{
    [Version("1.0")]
    public static class PathStorage
    {
        public static void SavePath(Path path, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Point3D point in path.GetPoints())
                {
                    writer.WriteLine($"{point.X} {point.Y} {point.Z}");
                }
            }
        }

        public static Path LoadPath(string filePath)
        {
            Path path = new Path();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');
                    bool xSuccess = double.TryParse(parts[0], out double x);
                    bool ySuccess = double.TryParse(parts[1], out double y);
                    bool zSuccess = double.TryParse(parts[2], out double z);

                    if (parts.Length == 3 && xSuccess && ySuccess && zSuccess)
                    {
                        Point3D point = new Point3D(x, y, z);
                        path.AddPoint(point);
                    }
                }
            }
            return path;
        }
    }
}
