using System;
using System.Collections.Generic;
using System.IO;
using SplashKitSDK;
namespace CustomProject
{
    public class Map : Object
    {
        private int _width, _height;
        private List<Map> _map;

        public Map() : this(Color.Gray, 500, 500, 0, 0)
        {
            _map = new List<Map>();
        }

        public Map(Color clr, int width, int height, float x, float y)
        {
            color = clr;
            _width = width;
            _height = height;
            X = x;
            Y = y;
        }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public List<Map> map
        {
            get
            {
                return _map;
            }
        }

        public int mapcount
        {
            get
            {
                return _map.Count;
            }
        }


        public virtual void Create()
        {
            SplashKit.FillRectangle(Color.Black, 0, 0, 1250, 750);
            foreach(Wall w in _map) {
                w.Create();
            }
        }

        public void AddWall(Wall w)
        {
            _map.Add(w);
        }

        public bool Check(Point2D pt)
        {
            foreach (Wall m in _map)
            {
                if ((m.IsAt(pt)))
                {
                    return true;
                }
            }
            return false;
        }

        public void Check(GhostParent s)
        {
            foreach (Wall m in _map)
            {
                foreach (GhostParent i in s.List)
                {
                    if ((m.IsAt(i.Point)))
                    {
                        i.OnWall = true;
                    }
                    if ((m.IsAt(i.Point2)))
                    {
                        i.OnWall = true;
                    }
                    if ((m.IsAt(i.Point3)))
                    {
                        i.OnWall = true;
                    }
                }
            }
        }

        public virtual void LoadLayout(StreamReader reader)
        {
            color = reader.ReadColor();
            X = reader.ReadInteger();
            Y = reader.ReadInteger();
        }
    }
}

