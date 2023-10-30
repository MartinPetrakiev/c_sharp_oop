using System;
using System.Globalization;

namespace Defining_Class_2
{
    [Version("1.0")]
    public class Matrix<T> where T : struct
    {
        private T[,] elements;
        private int rows;
        private int columns;

        public Matrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentException("Matrix dimensions must be positive.");
            }

            this.rows = rows;
            this.columns = columns;
            this.elements = new T[rows, columns];
        }

        public int Rows
        {
            get { return rows; }
        }

        public int Columns
        {
            get { return columns; }
        }

        public T this[int row, int col]
        {
            get
            {
                CheckIndices(row, col);
                return this.elements[row, col];
            }
            set
            {
                CheckIndices(row, col);
                this.elements[row, col] = value;
            }
        }

        private void CheckIndices(int row, int col)
        {
            if (row < 0 || row >= this.rows || col < 0 || col >= this.columns)
            {
                throw new IndexOutOfRangeException("Matrix indices are out of range.");
            }
        }

        private static void CheckDimensions(Matrix<T> a, Matrix<T> b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
            {
                throw new InvalidOperationException("Mtrices are not the same size/dimensions.");
            }
        }

        private static Matrix<T> PerformOperation(Matrix<T> a, Matrix<T> b, Func<decimal, decimal, decimal> operation)
        {
            CheckDimensions(a, b);

            Matrix<T> result = new Matrix<T>(a.Rows, a.Columns);

            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    decimal aValue = Convert.ToDecimal(a[i, j]);
                    decimal bValue = Convert.ToDecimal(b[i, j]);

                    decimal resultValue = operation(aValue, bValue);

                    result[i, j] = (T)Convert.ChangeType(resultValue, typeof(T));
                }
            }

            return result;
        }

        public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b) 
        {
            return PerformOperation(a, b, (x, y) => x + y);
        }

        public static Matrix<T> operator -(Matrix<T> a, Matrix<T> b)
        {
            return PerformOperation(a, b, (x, y) => x - y);
        }

        public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
        {
            return PerformOperation(a, b, (x, y) => x * y);
        }

        public static bool operator true(Matrix<T> matrix)
        {
            return matrix.elements.Cast<T>().Any(element => !element.Equals(default(T)));
        }

        public static bool operator false(Matrix<T> matrix)
        {
            return matrix.elements.Cast<T>().All(element => element.Equals(default(T)));
        }
    }
}
