using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AtomsSymulator
{
    class Point
    {
        private Vector2D position;
        private Vector2D speed;
        private List<Point> collidersEntered;
        private double r;

        public Point(Vector2D position, Vector2D speed, double r)
        {
            this.position = position;
            this.speed = speed;
            this.r = r;
            collidersEntered = new List<Point>();
        }

        public void Draw(Canvas cv)
        {

            Ellipse circle = new Ellipse()
            {
                Width = r*2,
                Height = r*2,
                Stroke = Brushes.Red,
                StrokeThickness = 2
            };

            cv.Children.Add(circle);

            circle.SetValue(Canvas.LeftProperty, (double)position.X - r);
            circle.SetValue(Canvas.TopProperty, (double)position.Y - r);
            //Console.WriteLine("Write: " + position.X + ", " + position.Y + " - " + r);
        }

        public bool IsColliding(Point point)
        {
            if (position.DistanceTo(point.GetPosition()) < (r + point.GetR()))
            {
                if (!collidersEntered.Contains(point))
                {
                    Console.WriteLine("Collision " + position.DistanceTo(point.GetPosition()) + " vs " + (r + point.GetR()));
                    collidersEntered.Add(point);
                    return true;
                }
            }
            else
            {
                collidersEntered.Remove(point);
            }
                

            return false;
        }

        public AtomPhysics.Wall IsColliding(Scene scene)
        {
            double a = scene.GetA();
            double sx = scene.GetPosition().X;
            double sy = scene.GetPosition().Y;

            // Left wall
            if (position.X - r <= sx && speed.X < 0)
                return AtomPhysics.Wall.Vertical;

            // Right wall
            if (position.X + r >= sx + a && speed.X > 0)
                return AtomPhysics.Wall.Vertical;

            // Top wall
            if (position.Y - r <= sy && speed.Y < 0)
                return AtomPhysics.Wall.Horizontal;

            // Bottom wall
            if (position.Y + r >= sy + a && speed.Y > 0)
                return AtomPhysics.Wall.Horizontal;

            return AtomPhysics.Wall.None;

        }

        public State SaveState()
        {
            throw new NotImplementedException();
        }

        public void RecoverState(State state)
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            position = position + speed;
        }

        public void SetSpeed(Vector2D speed)
        {
            this.speed = speed;
        }

        public Vector2D GetSpeed()
        {
            return this.speed;
        }

        public double GetR()
        {
            return r;
        }

        public Vector2D GetPosition()
        {
            return position;
        }




    }
}
