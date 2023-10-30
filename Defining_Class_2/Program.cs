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

            //Generic list test
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

            Console.WriteLine(matrix ? "Matrix is fine." : "Not ok!");
        }
    }
}

/*
1 Structure
Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidean 3D space.
Implement the ToString() to enable printing a 3D point.

2 Static read-only field
Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}.
Add a static property to return the point O.

3 Static class
Write a static class with a static method to calculate the distance between two points in the 3D space.

4 Path
Create a class Path to hold a sequence of points in the 3D space.
Create a static class PathStorage with static methods to save and load paths from a text file.
Use a file format of your choice.

5 Generic class
Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
Keep the elements of the list in an array with fixed capacity which is given as a parameter in the class constructor.
Implement methods for adding element, accessing element by index, removing element by index, inserting element at given position, clearing the list, finding element by its value and ToString().
Check all input parameters to avoid accessing elements at invalid positions.

6 Auto-grow
Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.

7 Min and Max
Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the GenericList<T>.
You may need to add generic constraints for the type T.

8 Matrix
Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals).

9 Matrix indexer
Implement an indexer this[row, col] to access the inner matrix cells.

10 Matrix operations
Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication.
Throw an exception when the operation cannot be performed.
Implement the true operator (check for non-zero elements).

11 Version attribute
Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods and holds a version in the format major.minor (e.g. 2.11).
Apply the version attribute to a sample class and display its version at runtime.
*/