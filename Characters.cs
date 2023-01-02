using System;
using System.Collections.Generic;
using System.IO;
using SplashKitSDK;
namespace CustomProject
{
    public class Characters : Object
    {
        private bool _alive;
        private string _name;
        private List<Characters> _characters;

        public Characters()
        {
            _characters = new List<Characters>();
        }

        public virtual bool IsAt(Point2D pt)
        {
            return false;
        }

        public virtual void Draw()
        {
            Inky ink = new Inky();
            foreach(Characters i in _characters)
            {
                i.Draw();
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public bool Alive
        {
            get
            {
                return _alive;
            }
            set
            {
                _alive = value;
            }
        }

        public void CharacterAdd(Characters c)
        {
            _characters.Add(c);
        }

    }
}

