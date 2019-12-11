using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomsSymulator
{
    class Vector2D
    {
        private float x;
        private float y;

        public Vector2D()
        {
            this.x = 0.0f;
            this.y = 0.0f;
        }

        public Vector2D(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public float X
        {
            get { return x; }
            set { this.x = value; }
        }
        public float Y
        {
            get { return y; }
            set { this.y = value; }
        }
    }
}
