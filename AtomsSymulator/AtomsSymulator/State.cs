using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomsSymulator
{
    class State
    {
        private List<Point> data;


        public State(List<Point> points)
        {
            data = new List<Point>();
            foreach(Point point in points)
            {
                Vector2D position = new Vector2D(point.GetPosition().X, point.GetPosition().Y);
                Vector2D speed = new Vector2D(point.GetSpeed().X, point.GetSpeed().Y);
                double r = point.GetR();

                Point p = new Point(position, speed, r);
                data.Add(p);
            }
        }


        public List<Point> GetState()
        {
            return data;
        }
    }
}
