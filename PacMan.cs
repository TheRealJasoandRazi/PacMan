using System;
using System.IO;
using System.Numerics;
using SplashKitSDK;
namespace CustomProject
{
    public class PacMan : Characters
    {
        private int _score;
        private int _radius;
        private bool _invincibility;

        public PacMan()
            : this(Color.White, "pacman", 630, 620, 20)
        {
        }

        public PacMan(Color clr, string name, float x, float y, int radius)
        {
            color = clr;
            Name = name;
            X = x;
            Y = y;
            _radius = radius;
            Alive = true;
            Point = new Point2D(x, y);
        }

        public void Move(KeyCode Key)
        {
            switch(Key)
            {
                case KeyCode.DKey :
                    this.X += 1;
                    Point = new Point2D(X, Y);
                    break;
                case KeyCode.AKey :
                    this.X -= 1;
                    Point = new Point2D(X, Y);
                    break;
                case KeyCode.WKey:
                    this.Y -= 1;
                    Point = new Point2D(X, Y);
                    break;
                case KeyCode.SKey:
                    this.Y += 1;
                    Point = new Point2D(X, Y);
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
            
                
        }

        public override void Draw()
        {
            if(Alive)
            {
                SplashKit.FillCircle(color, X, Y, _radius);
            }
        }

        
        public override bool IsAt(Point2D pt)
        {
            if (SplashKit.PointInCircle(pt, SplashKit.CircleAt(X, Y, _radius))) {
                return true;
            }
            return false;
        }
        

        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
            }
        }

        public bool InvincibilityProperty
        {
            get
            {
                return _invincibility;
            }
            set
            {
                _invincibility = value;
            }
        }

        public void Invincibility()
        {
            SplashKit.ResumeTimer("invincibility");
            this.color = SplashKit.RandomColor();
            if (SplashKit.TimerTicks("invincibility") > 5000)
            {
                SplashKit.ResetTimer("invincibility");
                SplashKit.PauseTimer("invincibility");
                this.InvincibilityProperty = false;
                this.color = Color.White;
            }
        }
    }
}

