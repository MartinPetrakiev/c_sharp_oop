namespace Defining_Class_2
{
    class Program
    {
        public static void Main(string[] args)
        {
            Point3D pointA = new Point3D(0.5, 2, 1);
            Point3D pointB = new Point3D(5, 2.5, 4);

            double distanceAB = DistanceCalculator.CalculateDistance(pointA, pointB);
            Console.WriteLine($"Distance between A{pointA} and B{pointB}: {distanceAB:F2} (units)");

            Point3D origin = Point3D.Origin;
            Console.WriteLine($"Origin is O{origin}");

            //Path storage operations
            Path path = new Path();
            path.AddPoint(new Point3D(1, 2, 3));
            path.AddPoint(new Point3D(4, 5, 6));
            path.AddPoint(new Point3D(7, 8, 9));

            PathStorage.SavePath(path, "D:\\c_sharp_oop\\Defining_Class_2\\path.txt");

            Path loadedPath = PathStorage.LoadPath("D:\\c_sharp_oop\\Defining_Class_2\\path.txt");
            foreach (Point3D point in loadedPath.GetPoints())
            {
                Console.WriteLine(point);
            }

            GenericList<int> list = new GenericList<int>(3);

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            Console.WriteLine("Initial List: " + list);
            Console.WriteLine("Count: " + list.Count);

            list.RemoveAt(2);
            Console.WriteLine("List after removing element at index 2: " + list);
            Console.WriteLine("Count: " + list.Count);

            list.InsertAt(1, 5);
            Console.WriteLine("List after inserting 5 at index 1: " + list);
            Console.WriteLine("Count: " + list.Count);

            int index = list.FindIndex(2);
            Console.WriteLine("Index of 2 in the list: " + index);

            list.Clear();
            Console.WriteLine("List after clearing: " + list);
            Console.WriteLine("Count: " + list.Count);

            //Matrices
            Matrix<int> matrix = new Matrix<int>(5, 5);

            int nextElement = 1;
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    matrix[i, j] = nextElement;
                    nextElement++;
                }
            }

            Matrix<int> matrix2 = new Matrix<int>(5, 5);

            nextElement = 1;
            for (int i = 0; i < matrix2.Rows; i++)
            {
                for (int j = 0; j < matrix2.Columns; j++)
                {
                    matrix2[i, j] = nextElement;
                    nextElement++;
                }
            }

            Matrix<int> multipliedMatrices = matrix * matrix2;

            for (int i = 0; i < multipliedMatrices.Rows; i++)
            {
                for (int j = 0; j < multipliedMatrices.Columns; j++)
                {
                    Console.Write(multipliedMatrices[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Type type = typeof(Matrix<int>);
            object[] attributes = type.GetCustomAttributes(typeof(VersionAttribute), false);

            if (attributes.Length > 0)
            {
                VersionAttribute versionAttribute = (VersionAttribute)attributes[0];
                string version = versionAttribute.Version;
                Console.WriteLine($"Version of Matrix<int>: {version}");
            }
            else
            {
                Console.WriteLine("Version attribute not found for Matrix<int>.");
            }

        }
    }
}
