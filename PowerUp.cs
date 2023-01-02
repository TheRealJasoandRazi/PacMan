using System;
using SplashKitSDK;
using System.IO;
namespace CustomProject
{
    public class PowerUp : Fruit
    {
        public PowerUp(float x, float y) : this(Color.Red, 15)
        {
            X = x;
            Y = y;
            Point = new Point2D(x, y);
        }

        public PowerUp()
        {

        }
        public PowerUp(Color clr, int radd)
        {
            color = clr;
            Radius = radd;
            On = false;
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

