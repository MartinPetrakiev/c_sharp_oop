using System.Drawing;

namespace Defining_Class
{
    public class Display
    {
        private double size;
        private int numberOfColors;

        public double Size {
            get { return size; }
            set
            {
                if (value > 0)
                    size = value;
                else
                    throw new ArgumentException("Size must be greater than 0.");
            }
        }
        public int NumberOfColors 
        {
            get { return numberOfColors; }
            set
            {
                if (value >= 0)
                    numberOfColors = value;
                else
                    throw new ArgumentException("NumberOfColors cannot be negative.");
            }
        }

        public Display() 
        {
        }

        public Display(double size, int colors) 
        {
            this.Size = size;
            this.NumberOfColors = colors;
        }
    }
}
