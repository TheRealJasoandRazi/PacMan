using System;
using System.Collections.Generic;
using System.Linq;
using SplashKitSDK;
using System.IO;
namespace CustomProject
{
    public class GhostParent : Characters
    {
        private float _x2, _y2, _x3, _y3;
        private Point2D _point2, _point3;
        private bool _onwall;
        private List<GhostParent> _list;
        private List<string> _directions;

        public GhostParent()
        {
            _list = new List<GhostParent>();
            _directions = new List<string>();
        }

        public Point2D Point2
        {
            get
            {
                return _point2;
            }
            set
            {
                _point2 = value;
            }
        }

        public List<GhostParent> List
        {
            get
            {
                return _list;
            }
            set
            {
                _list = value;
            }
        }

        public int ListCount
        {
            get
            {
                return _list.Count;
            }
        }

        public Point2D Point3
        {
            get
            {
                return _point3;
            }
            set
            {
                _point3 = value;
            }
        }

        public float X2
        {
            get
            {
                return _x2;
            }
            set
            {
                _x2 = value;
            }
        }

        public bool OnWall
        {
            get
            {
                return _onwall;
            }
            set
            {
                _onwall = value;
            }   
        }

        public float Y2
        {
            get
            {
                return _y2;
            }
            set
            {
                _y2 = value;
            }
        }

        public float X3
        {
            get
            {
                return _x3;
            }
            set
            {
                _x3 = value;
            }
        }

        public float Y3
        {
            get
            {
                return _y3;
            }
            set
            {
                _y3 = value;
            }
        }

        public void GhostAdd(GhostParent c)
        {
            _list.Add(c);
        }

        public virtual void travel()
        {
           foreach(GhostParent p in _list)
            {
                p.travel();
            }
        }

        public void checkplayercollision(PacMan p)
        {
            foreach(GhostParent i in _list)
            {
                if (i.IsAt(p.Point))
                {
                    if(i.GetType() == new Vince().GetType())
                    {
                        p.Alive = false;
                    } else
                    {
                        if(p.InvincibilityProperty == true)
                        {
                            i.Alive = false;
                        } else if(p.InvincibilityProperty == false)
                        {
                            p.Alive = false;
                        }
                    }
                }
            }
        }

        public void ReturnDirection(string st)
        {
            if (st == "n")
            {
                this.Y += 1;
                Point = new Point2D(X, Y);
                this.Y2 += 1;
                Point2 = new Point2D(X2, Y2);
                this.Y3 += 1;
                Point3 = new Point2D(X3, Y3);
            }
            else if (st == "s")
            {
                this.Y -= 1;
                Point = new Point2D(X, Y);
                this.Y2 -= 1;
                Point2 = new Point2D(X2, Y2);
                this.Y3 -= 1;
                Point3 = new Point2D(X3, Y3);
            }
            else if (st == "w")
            {
                this.X += 1;
                Point = new Point2D(X, Y);
                this.X2 += 1;
                Point2 = new Point2D(X2, Y2);
                this.X3 += 1;
                Point3 = new Point2D(X3, Y3);
            }
            else if (st == "e")
            {
                this.X -= 1;
                Point = new Point2D(X, Y);
                this.X2 -= 1;
                Point2 = new Point2D(X2, Y2);
                this.X3 -= 1;
                Point3 = new Point2D(X3, Y3);
            }
        }


        public void Restore()
        {
            _directions.Add("n");
            _directions.Add("e");
            _directions.Add("s");
            _directions.Add("w");
        }

        public List<string> Directions
        {
            get
            {
                return _directions;
            }
            set
            {
                _directions = value;
            }
        }
    }
}

