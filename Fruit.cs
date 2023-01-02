using System;
using System.Collections.Generic;
using System.Linq;
using SplashKitSDK;
using System.IO;

namespace CustomProject
{
    public class Fruit : Object
    {

        private Color BG;
        private bool _on;
        private List<Fruit> _collectables;
        private List<Fruit> result;
        private int _radius;

        public Fruit(Color clr)
        {
            BG = clr;
        }

        public Fruit() : this(Color.White)
        {
            _collectables = new List<Fruit>();
        }
        public virtual void Create()
        {
            foreach (Fruit f in _collectables)
            {
                f.Create();
            }
        }

        public int FruitCount
        {
            get
            {
                return _collectables.Count();
            }
        }

        public Color bg
        {
            get
            {
                return BG;
            }
            set
            {
                BG = value;
            }
        }

        public bool On
        {
            get
            {
                return _on;
            }
            set
            {
                _on = value;
            }
        }

        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }

        public List<Fruit> Collectables
        {
            get
            {
                return _collectables;
            }
            set
            {
                _collectables = value;
            }
        }

        public void AddFruit(Fruit f)
        {
            _collectables.Add(f);
        }

        private void RemoveFruit(Fruit f)
        {
            _collectables.Remove(f);
        }

        public List<Fruit> FruitOn
        {
            get
            {
                result = new List<Fruit>();
                foreach (Fruit f in _collectables)
                {
                    if (f.On == true)
                    {
                        result.Add(f);
                    }
                }
                return result;
            }
        }

        public void DeleteSelectedFruit()
        {
            foreach (Fruit f in FruitOn)
            {
                RemoveFruit(f);
            }
        }

        public bool Check(PacMan p)
        {

            foreach (Fruit f in _collectables)
            {
                f.Point = new Point2D(f.X, f.Y);
                if (p.IsAt(f.Point))
                {
                    if (Object.ReferenceEquals(f.GetType(), new Ordinary().GetType()))
                    {
                        p.Score += 1;
                        f.On = true;
                        return f.On;

                    }
                    else if (Object.ReferenceEquals(f.GetType(), new PowerUp().GetType()))
                    {
                        if (p.InvincibilityProperty == true)
                        {

                        }
                        else
                        {
                            p.InvincibilityProperty = true;
                            f.On = true;
                            return f.On;
                        }

                    }
                }
                else
                {
                    f.On = false;
                }
            }
            return false;
        }

        public virtual void LoadLayout(StreamReader reader)
        {
            color = reader.ReadColor();
            X = reader.ReadInteger();
            Y = reader.ReadInteger();
        }
    }
        
}


