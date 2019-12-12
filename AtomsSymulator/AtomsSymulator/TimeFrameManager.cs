using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AtomsSymulator
{
    class TimeFrameManager
    {
        private const int timeStep = 10; //time in miliseconds
        private List<Point> points;

        private double time = 0.0;
        private double deltaTime;
        private Canvas canvas;
        private Scene scene;
        private Thread renderThread;
        private MainWindow mainWindow;

        public TimeFrameManager(double deltaTime, Canvas canvas, Scene scene, MainWindow mainWindow)
        {
            this.deltaTime = deltaTime;
            this.canvas = canvas;
            this.scene = scene;
            this.mainWindow = mainWindow;
            points = new List<Point>();
            renderThread = new Thread(CreateFrame);
        }

        public void AddPointToRenderer(Point point)
        {
            points.Add(point);
        }

        public double GetActualTime()
        {
            return time;
        }

        public void CheckCollisions()
        {
            throw new NotImplementedException();
        }

        //Thread function
        public void CreateFrame()
        {
            while (true)
            {
                Console.WriteLine("Framing");
                Move();
                MakePhysics();
                Render();
                Thread.Sleep((int)(1000 * deltaTime));
            }
        }

        private void Render()
        {
            mainWindow.Dispatcher.Invoke((Action)(() =>
            {
                // Clear canvas
                canvas.Children.Clear();
                //Draw points
                foreach (Point p in points)
                {
                    p.Draw(canvas);
                }
            }));
            
        }

        private void Move()
        {
            // Move points
            foreach (Point p in points)
            {
                p.Move();
            }
        }

        private void MakePhysics()
        {
            List<Point> checkedPoints = new List<Point>();
            // Check collisions
            int i = 0;
            foreach (Point p in points)
            {
                // Collisions with points
                
                foreach(Point pp in points)
                {
                    if (pp != p && !checkedPoints.Contains(pp))
                    {
                        if (p.IsColliding(pp))
                        {
                            //double average_speed = (p.GetSpeed().GetLength() + pp.GetSpeed().GetLength()) / 2;
                            Console.WriteLine("Force atom");
                            Vector2D nc_spped = p.GetSpeed(); //(p.GetSpeed()  + not_checked[i].GetSpeed() * (not_checked[i].GetR() / p.GetR())).Normalized() * average_speed;
                            Vector2D p_spped = pp.GetSpeed();// (not_checked[i].GetSpeed() + p.GetSpeed() * (p.GetR() / not_checked[i].GetR())).Normalized() * average_speed;

                            pp.SetSpeed(nc_spped);
                            p.SetSpeed(p_spped);
                            checkedPoints.Add(p);
                        }
                    }
                }


                // Set speed vector if collide walls, else change nothing
                p.SetSpeed( AtomPhysics.GetWallReflectionVector(p.GetSpeed(), p.IsColliding(scene)) );
                
            }
        }



        public void Start()
        {
            renderThread = new Thread(CreateFrame);
            renderThread.Start();
        }

        public void Stop()
        {
            renderThread.Abort();
        }

        public void LoadStates(State[] states)
        {
            throw new NotImplementedException();
        }


    }
}
