using System;
using System.IO;

namespace CustomProject
{
    public class Loader
    {
        public Loader()
        {
        }

        public void LoadCount(string file, Fruit z)
        {
            StreamReader reader = new StreamReader(file);
            try
            {
                z.bg = ExtensionMethods.ReadColor(reader);
                int Numoffruit = ExtensionMethods.ReadInteger(reader);
                z.Collectables.Clear();
                string FruitKind;
                Fruit f;

                for (int i = 0; i < Numoffruit; i++)
                {
                    FruitKind = reader.ReadLine();
                    switch (FruitKind)
                    {
                        case "Ordinary":
                            f = new Ordinary();
                            break;
                        case "PowerUp":
                            f = new PowerUp();
                            break;
                        default:
                            throw new InvalidDataException("Unknown fruit kind" + FruitKind);
                    }
                    f.LoadLayout(reader);
                    z.AddFruit(f);
                }
                reader.Close();

            }
            finally
            {
                reader.Close();
            }
        }

        public void LoadCount(string file, Map m)
        {
            StreamReader reader = new StreamReader(file);
            try
            {
 
                int NumofWall = ExtensionMethods.ReadInteger(reader);
                m.map.Clear();
                string wall;
                Wall w;

                for (int i = 0; i < NumofWall; i++)
                {

                    wall = reader.ReadLine();
                    switch (wall)
                    {
                        case "Wall":
                            w = new Wall();
                            break;
                        default:
                            throw new InvalidDataException("Unknown fruit kind" + wall);
                    }

                    w.LoadLayout(reader);
                    m.AddWall(w);
                }
                reader.Close();

            }
            finally
            {
                reader.Close();
            }
        }

    }
}

