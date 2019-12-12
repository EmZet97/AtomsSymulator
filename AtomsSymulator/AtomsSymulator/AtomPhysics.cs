using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomsSymulator
{
    class AtomPhysics
    {
        public static Vector2D GetWallReflectionVector(Vector2D vector, Wall wall)
        {
            Vector2D finalVector = vector;
            switch (wall)
            {
                case Wall.Vertical:
                    finalVector = new Vector2D(-vector.X, vector.Y);
                    break;
                case Wall.Horizontal:
                    finalVector = new Vector2D(vector.X, -vector.Y);
                    break;

            }

            return finalVector;
        }

        public enum Wall
        {
            Vertical, Horizontal, None
        }
    }
}
