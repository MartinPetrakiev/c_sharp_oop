using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defining_Class_2
{
    [Version("1.0")]
    public class GenericList<T> where T : IComparable<T>
    {
        private T[] elements;
        private int count;

        public GenericList(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be greater than zero.");
            }

            this.elements = new T[capacity];
            this.count = 0;
        }

        public int Count
        {
            get { return this.count; }
        }

        public void Add(T element)
        {
            EnsureCapacity();
            this.elements[this.count] = element;
            this.count++;
        }

        public T Get(int index)
        {
            ValidateIndex(index);
            return this.elements[index];
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);
            for (int i = index; i < count - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }
            this.count--;
        }

        public void InsertAt(int index, T element)
        {
            ValidateIndex(index);
            EnsureCapacity();

            for (int i = count; i > index; i--)
            {
                this.elements[i] = this.elements[i - 1];
            }

            this.elements[index] = element;
            this.count++;
        }

        public void Clear()
        {
            this.elements = new T[this.elements.Length];
            this.count = 0;
        }

        public int FindIndex(T element)
        {
            for (int i = 0; i < count; i++)
            {
                if (object.Equals(this.elements[i], element))
                {
                    return i;
                }
            }
            return -1;
        }

        public T Min()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            T minElement = this.elements[0];
            for (int i = 1; i < this.count; i++)
            {
                if (this.elements[i].CompareTo(minElement) < 0)
                {
                    minElement = this.elements[i];
                }
            }
            return minElement;
        }

        public T Max()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            T maxElement = this.elements[0];
            for (int i = 1; i < this.count; i++)
            {
                if (this.elements[i].CompareTo(maxElement) > 0)
                {
                    maxElement = this.elements[i];
                }
            }
            return maxElement;
        }

        public override string ToString()
        {
            string result = "[";

            for (int i = 0; i < this.count; i++)
            {
                result += this.elements[i];
                if (i < this.count - 1)
                {
                    result += ", ";
                }
            }

            result += "]";
            return result;
        }

        private void EnsureCapacity()
        {
            if (this.count == this.elements.Length)
            {
                int newCapacity = this.elements.Length * 2;
                Array.Resize(ref this.elements, newCapacity);
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
        }
    }
}
