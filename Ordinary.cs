using System;
using SplashKitSDK;
using System.IO;
namespace CustomProject
{
    public class Ordinary : Fruit
    {
        public Ordinary(float x, float y)
            : this(Color.Red, 10)
        {
            X = x;
            Y = y;
            Point = new Point2D(x, y);
        }

        public Ordinary(Color clr, int rad)
        {
            color = clr;
            Radius = rad;
            On = false;
        }

        public Ordinary()
        {

        }

        public override void Create()
        {
            SplashKit.FillCircle(color, X, Y, Radius);           
        }

        public override void LoadLayout(StreamReader reader)
        {
            base.LoadLayout(reader);
            Radius = reader.ReadInteger();  
        }

    }
}

