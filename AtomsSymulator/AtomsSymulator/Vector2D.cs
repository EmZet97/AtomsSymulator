﻿using System;
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

        public double DistanceTo(Vector2D vector)
        {
            double xDiff = vector.X - x;
            double yDiff = vector.Y - y;

            double distance = Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
            return distance;
        }

        public static Vector2D operator +(Vector2D v1, Vector2D v2)
        {
            Vector2D new_vec = new Vector2D(x: v1.X + v2.X, v1.Y + v2.Y);
            return new_vec;
        }

        public static Vector2D operator *(Vector2D v1, double m)
        {
            Vector2D new_vec = new Vector2D(x: v1.X * m, v1.Y * m);
            return new_vec;
        }
    }
}
