using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomsSymulator
{
    class Vector2D
    {
        private double x;
        private double y;

        public Vector2D()
        {
            this.x = 0.0f;
            this.y = 0.0f;
        }

        public Vector2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X
        {
            get { return x; }
            set { this.x = value; }
        }
        public double Y
        {
            get { return y; }
            set { this.y = value; }
        }

        public double GetLength()
        {
            double l = Math.Sqrt(x * x + y * y);
            return l;
        }

        public Vector2D Normalized()
        {
            double l = GetLength();
            Vector2D vector2D = new Vector2D(x / l, y / l);
            return vector2D;
        }
    }
}
