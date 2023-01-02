using System;
using SplashKitSDK;
using System.Threading;
using System.Web;
using System.Windows;

namespace CustomProject
{
    public class Program
    {
        public static void Main()
        {
            bool open = false;
            Window main = new Window("Selection Screen", 800, 600);
            SplashKit.SetCurrentWindow(main);
      
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                SplashKit.FillRectangle(Color.Black, 0, 0, 800, 600);
                GUI SelectLevelButton1 = new GUI(Color.Purple, 200, 200, 200, 100);

                SplashKit.DrawTextOnWindow(main, "Pac-Man", Color.White, FontStyle.NormalFont.ToString(), 100, 200, 10);

                SelectLevelButton1.CreateButton();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    if (SelectLevelButton1.IsAtButton(SplashKit.MousePosition()))
                    {
                        open = true;
                        SplashKit.CloseCurrentWindow();
                    }
                }

                SplashKit.RefreshScreen();
            } while (!main.CloseRequested);

            if (open == true)
            {

                Characters character = new Characters();
                PacMan player = new PacMan();
                Clyde clyde = new Clyde();
                Inky inky = new Inky();
                Blinky blinky = new Blinky();
                Vince vince = new Vince();

                GhostParent par = new GhostParent();
                
                par.GhostAdd(clyde);
                par.GhostAdd(inky);
                par.GhostAdd(blinky);
                par.GhostAdd(vince);
                               
                character.CharacterAdd(player);
                character.CharacterAdd(clyde);
                character.CharacterAdd(inky);
                character.CharacterAdd(blinky);
                character.CharacterAdd(vince);

                Map map = new Map();

                Window levelwindow = new Window("PacMan", 1250, 750);
                Fruit fruit = new Fruit();

                SplashKit.CreateTimer("invincibility");
                SplashKit.StartTimer("invincibility");
                SplashKit.PauseTimer("invincibility");

                SplashKit.CreateTimer("invisibility");
                SplashKit.StartTimer("invisibility");
                SplashKit.PauseTimer("invisibility");

                SplashKit.CreateTimer("multiply");
                SplashKit.StartTimer("multiply");

                SplashKit.CreateTimer("speed");
                SplashKit.StartTimer("speed");
                SplashKit.PauseTimer("speed");

                SplashKit.CreateTimer("Stop");
                SplashKit.StartTimer("Stop");
                SplashKit.PauseTimer("Stop");
                int c = 0;
                Loader load = new Loader();
                load.LoadCount("/Users/nemanjapopovic/Desktop/OOP/CustomProgramFruit.docx", fruit);
                load.LoadCount("/Users/nemanjapopovic/Desktop/OOP/CustomProgramLevel.docx", map);
                bool finished = false;
                do
                {
                    c++;
                    SplashKit.ProcessEvents();
                    SplashKit.ClearScreen();

                    if (map.Check(player.Point) == false)
                    {
                        if (SplashKit.KeyDown(KeyCode.WKey))
                        {
                            player.Move(KeyCode.WKey);
                        }
                        else if (SplashKit.KeyDown(KeyCode.SKey))
                        {
                            player.Move(KeyCode.SKey);
                        }
                        else if (SplashKit.KeyDown(KeyCode.DKey))
                        {
                            player.Move(KeyCode.DKey);
                        }
                        else if (SplashKit.KeyDown(KeyCode.AKey))
                        {
                            player.Move(KeyCode.AKey);
                        }
                    }
                    else
                    {
                        player.Alive = false;
                        Console.WriteLine("you died");
                    }

                    map.Create();
                    
                    map.Check(player.Point);
 
                    map.Check(par);

                    character.Draw();
               
                    inky.Multiply(character, par);

                    fruit.Create();

                    if (c % 2 == 0)
                    {
                        par.travel();
                    }

                    par.checkplayercollision(player);

                    if (fruit.Check(player))
                    {
                        fruit.DeleteSelectedFruit();
                    }
         
                    SplashKit.DrawTextOnWindow(levelwindow,player.Score.ToString(), Color.White, 10, 10);

                    if (player.InvincibilityProperty)
                    {

                        clyde.Invisibility();
                        player.Invincibility();
                        blinky.SpeedUp();
                        vince.Travel = false;
                        vince.Stop();
                    } else {
                        vince.Travel = true;
                    }


                    if(fruit.Collectables.Count == 0)
                    {
                        Console.WriteLine("you win");
                        SplashKit.CloseCurrentWindow();
                        finished = true;
                        open = false;

                    }

                    if (player.Alive == false) { SplashKit.CloseCurrentWindow(); }


                    SplashKit.RefreshScreen();
                } while (!levelwindow.CloseRequested);

                if (finished == true)
                {
                    Window end = new Window("End Screen", 800, 600);
                    do {
                        SplashKit.ProcessEvents();
                        SplashKit.ClearScreen();

                        GUI returnbutton = new GUI(Color.Purple, 200, 200, 200, 100);
                        returnbutton.CreateButton();
                        SplashKit.DrawTextOnWindow(end, "You Have Completed the Level!", Color.White, FontStyle.NormalFont.ToString(), fontSize: 100, 200, 10);
                        SplashKit.FillRectangle(Color.Black, 0, 0, 800, 600);

                        if (SplashKit.MouseClicked(MouseButton.LeftButton))
                        {
                            if (returnbutton.IsAtButton(SplashKit.MousePosition()))
                            {
                                SplashKit.CloseCurrentWindow();
                                open = true;
                            }
                        }

                        SplashKit.RefreshScreen();
                    } while (!levelwindow.CloseRequested) ;
                }
            }
        }
    }
}

