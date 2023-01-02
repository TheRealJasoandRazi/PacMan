using System;
using System.IO;
using SplashKitSDK;
namespace CustomProject
{
    public class Wall : Map
    {
        public Wall(float x, float y, int width, int height) : this(Color.Purple)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Point = new Point2D(x, y);
        }

        public Wall(Color clr)
        {
            color = clr;
        }

        public Wall()
        {

        }

        public override void Create()
        {
            SplashKit.FillRectangle(color, X, Y, Width, Height);
        }

        public bool IsAt(Point2D pt)
        {
            return (pt.X <= X + Width && pt.X >= X && pt.Y <= Y + Height && pt.Y >= Y);
        }

        public override void LoadLayout(StreamReader reader)
        {
            base.LoadLayout(reader);
            Width = reader.ReadInteger();
            Height = reader.ReadInteger();
        }



    }
}

