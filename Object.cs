using System;
using System.Collections.Generic;
using System.Linq;
using SplashKitSDK;
using System.IO;
namespace CustomProject
{
    public abstract class Object
    {
        private float _x, _y;
        private Color _color;
        private Point2D _point;

        public Point2D Point
        {
            get
            {
                return _point;
            }
            set
            {
                _point = value;
            }
        }

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }


        public Color color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
    }
}

