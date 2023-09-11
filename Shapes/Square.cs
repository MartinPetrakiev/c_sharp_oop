﻿namespace Shapes
{
    public class Square : Shape
    {
        public Square(double side) : base(side, side)
        {
        }
        public override double CalculateSurface()
        {
            return width * height;
        }
    }
}
