using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomsSymulator
{
    class Scene
    {
        private double a;
        private Vector2D position;

        public Scene(double a, Vector2D position)
        {
            this.a = a;
            this.position = position;
        }

        public double GetA()
        {
            return a;
        }

        public Vector2D GetPosition()
        {
            return position;
        }
    }
}
