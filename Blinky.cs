﻿using System;
using SplashKitSDK;
using System.Xml.Linq;
using System.Collections.Generic;
using System.IO;

namespace CustomProject
{
    public class Blinky : GhostParent, Ghost
    {
        
        private int x;
        private int s = 1;

        public Blinky() : this(Color.Blue, 500, 200, 540, 200, 520, 240, "Blinky")
        {
            
        }

        public Blinky(Color clr, float x, float y, float x2, float y2, float x3, float y3, string n)
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

                            this.Y -= s;
                            Point = new Point2D(X, Y);
                            this.Y2 -= s;
                            Point2 = new Point2D(X2, Y2);
                            this.Y3 -= s;
                            Point3 = new Point2D(X3, Y3);
                        }
                        else if (Directions[x] == "s")
                        {
                            this.Y += s;
                            Point = new Point2D(X, Y);
                            this.Y2 += s;
                            Point2 = new Point2D(X2, Y2);
                            this.Y3 += s;
                            Point3 = new Point2D(X3, Y3);

                        }
                        else if (Directions[x] == "e")
                        {
                            this.X += s;
                            Point = new Point2D(X, Y);
                            this.X2 += s;
                            Point2 = new Point2D(X2, Y2);
                            this.X3 += s;
                            Point3 = new Point2D(X3, Y3);

                        }
                        else if (Directions[x] == "w")
                        {
                            this.X -= s;
                            Point = new Point2D(X, Y);
                            this.X2 -= s;
                            Point2 = new Point2D(X2, Y2);
                            this.X3 -= s;
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
        
        private new void ReturnDirection(string st)
        {
            if (st == "n")
            {
                this.Y += s;
                Point = new Point2D(X, Y);
                this.Y2 += s;
                Point2 = new Point2D(X2, Y2);
                this.Y3 += s;
                Point3 = new Point2D(X3, Y3);
            }
            else if (st == "s")
            {
                this.Y -= s;
                Point = new Point2D(X, Y);
                this.Y2 -= s;
                Point2 = new Point2D(X2, Y2);
                this.Y3 -= s;
                Point3 = new Point2D(X3, Y3);
            }
            else if (st == "w")
            {
                this.X += s;
                Point = new Point2D(X, Y);
                this.X2 += s;
                Point2 = new Point2D(X2, Y2);
                this.X3 += s;
                Point3 = new Point2D(X3, Y3);
            }
            else if (st == "e")
            {
                this.X -= s;
                Point = new Point2D(X, Y);
                this.X2 -= s;
                Point2 = new Point2D(X2, Y2);
                this.X3 -= s;
                Point3 = new Point2D(X3, Y3);
            }
        } 

        public void SpeedUp()
        {
            SplashKit.ResumeTimer("speed");
            s = 2;
            if(SplashKit.TimerTicks("speed") > 5000) {
                s = 1;
                SplashKit.ResetTimer("speed");
                SplashKit.PauseTimer("speed");
            }
        }
    }
}
