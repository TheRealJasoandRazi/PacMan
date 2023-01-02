using System;
using SplashKitSDK;
namespace CustomProject
{
    public class GUI : Object
    {
        private int _width, _height;

        public GUI(Color clr, float x, float y, int w, int h)
        {
            color = clr;
            X = x;
            Y = y;
            _width = w;
            _height = h;
        }

        public void CreateButton()
        {
            SplashKit.FillRectangle(color, X, Y, _width, _height);

        }
        public bool IsAtButton(Point2D pt)
        {
            return (pt.X <= X + _width && pt.X >= X && pt.Y <= Y + _height && pt.Y >= Y);
        }
    }
}

