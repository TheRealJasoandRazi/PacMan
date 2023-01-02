using System;
using System.Collections.Generic;
using SplashKitSDK;
using System.Timers;
using System.IO;

namespace CustomProject
{
    public class Clyde : GhostParent, Ghost
    {
        private int x;

        public Clyde() : this(Color.Red, 500, 200, 540, 200, 520, 240, "clyde")
        {
           
        }

        public Clyde(Color clr, float x, float y, float x2, float y2, float x3, float y3, string n)
        {
            X2 = x2;
            X3 = x3;
            Y2 = y2;
            Y3 = y3;
            X = x;
            Y = y;
            color = clr;
            Name = n;
            Point = new Point2D(x, y);
            Point2 = new Point2D(x2, y2);
            Point3 = new Point2D(x3, y3);
            OnWall = false;
            Alive = true;
        }

        public override void Draw()
        {
            if (Alive)
            {
                SplashKit.FillTriangle(color, X, Y, X2, Y2, X3, Y3);
            }
        }

        public override bool IsAt(Point2D pt)
        {
            return (SplashKit.PointInTriangle(pt, SplashKit.TriangleFrom(Point, Point2, Point3)));
        }

        public override void travel()
        {
            Random random = new Random();
            if (Directions.Count < 1)
            {
                Restore();
            }
            else
            {
                string selected = Directions[x];
                    if (this.OnWall == false)
                    {
                        if (!Directions.Contains(selected))
                        {
                  
                        }
                        else
                        {
                            if (Directions[x] == "n")
                            {

                                this.Y -= 1;
                                Point = new Point2D(X, Y);
                                this.Y2 -= 1;
                                Point2 = new Point2D(X2, Y2);
                                this.Y3 -= 1;
                                Point3 = new Point2D(X3, Y3);
                            }
                            else if (Directions[x] == "s")
                            {
                                this.Y += 1;
                                Point = new Point2D(X, Y);
                                this.Y2 += 1;
                                Point2 = new Point2D(X2, Y2);
                                this.Y3 += 1;
                                Point3 = new Point2D(X3, Y3);

                            }
                            else if (Directions[x] == "e")
                            {
                                this.X += 1;
                                Point = new Point2D(X, Y);
                                this.X2 += 1;
                                Point2 = new Point2D(X2, Y2);
                                this.X3 += 1;
                                Point3 = new Point2D(X3, Y3);

                            }
                            else if (Directions[x] == "w")
                            {
                                this.X -= 1;
                                Point = new Point2D(X, Y);
                                this.X2 -= 1;
                                Point2 = new Point2D(X2, Y2);
                                this.X3 -= 1;
                                Point3 = new Point2D(X3, Y3);
                            }
                        }
                    }
                    else
                    {
                        ReturnDirection(selected);
                        //RemoveDirection(selected);
                        Directions.Remove(selected);
                        Directions.Sort();
                        x = random.Next(0, Directions.Count);
                        this.OnWall = false;
                    }
            
            }
        }

        public void Invisibility()
        {
            SplashKit.ResumeTimer("invisibility");
            this.color = Color.Black;

            if (SplashKit.TimerTicks("invisibility") > 5000)
            {
                this.color = Color.Red;
                SplashKit.ResetTimer("invisibility");
                SplashKit.PauseTimer("invisibility");
            }  
        }
      
    }
}

