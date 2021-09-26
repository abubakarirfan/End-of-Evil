using SplashKitSDK;

namespace CombatGame
{
    public class TwoPlayerGamePlay : IMenu
    {
        private string _selectedPlayerName;
        private int changeState;
        private string _winner;
        private SoundEffect soundEffect;

        private Player p1;
        private Player p2;

        private int count;

        private Music music;
        private Bitmap background;

        public TwoPlayerGamePlay()
        {
            // Initilization of everything
            music = new Music("bg music", "resources/music/background.mp3");
            background = new Bitmap("background", "resources/img/b1.jpg");
            changeState = 0;
            soundEffect = new SoundEffect("sword", "resources/music/sword.wav");
            count = 1;
        }

        public void AssignSelectedPlayer(string selectedPlayerName)
        {
            _selectedPlayerName = selectedPlayerName;

            // Allocate Appropiate Player 
            if (_selectedPlayerName == "Knight")
            {
                p1 = new Knight("Knight");
            }
            else if (_selectedPlayerName == "Robot")
            {
                p1 = new Robot("Robot");
            }
            else if (_selectedPlayerName == "King")
            {
                p1 = new King("King");
            }
            else if (_selectedPlayerName == "Yellow Knight")
            {
                p1 = new YellowKnight("YellowKnight");
            }
            else if (_selectedPlayerName == "Blue Knight")
            {
                p1 = new BlueKnight("BlueKnight");
            }
            else
            {
                p1 = new RedKnight("Red Knight");
            }
            p2 = new Troll("Troll");
        }


        public void AssignPlayersCoordinates()
        {
            p1.X = 50;
            p2.X = 550;

            p1.Y = 400;
            p2.Y = 400;
        }

        public void Execute()
        {
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.Black);
                SplashKit.DrawBitmap(background, 0, 0);

                // call jump for player 1 and player 2
                p1.Jump();
                p2.Jump();

                // display players score
                p1.Score.Draw(50, 50);
                p2.Score.Draw(650, 50);

                // check if music is playing if not, play music
                if (!SplashKit.MusicPlaying())
                {
                    music.Play();
                }

                // temp for assissting in coding
                SplashKit.DrawText("Player 1:", Color.White, 100, 90);
                SplashKit.DrawText(p1.X.ToString(), Color.White, 100, 100);
                SplashKit.DrawText(p1.Y.ToString(), Color.White, 100, 110);
                SplashKit.DrawText("Player 2:", Color.White, 100, 130);
                SplashKit.DrawText(p2.X.ToString(), Color.White, 100, 140);
                SplashKit.DrawText(p2.Y.ToString(), Color.White, 100, 150);

                // display players health
                p2.Health.Draw(650, 25);
                p1.Health.Draw(50, 25);

                p1.State = "idle";
                p2.State = "idle";

                SplashKit.DrawText("Sprite 1: " + p1.Sprite, Color.White, 500, 90);
                SplashKit.DrawText("Sprite 2: " + p2.Sprite, Color.White, 500, 100);


                if (p1.Health.GetHealth <= 0 || p2.Health.GetHealth <= 0)
                {
                    if (p1.Health.GetHealth <= 0)
                    {
                        p1.State = "die";
                        _winner = "Player 2";
                        count++;
                    }
                    else
                    {
                        _winner = "Player 1";
                        p2.State = "die";
                        count++;
                    }

                    // draw dead players
                    p1.Draw();
                    p2.Draw();

                    SplashKit.RefreshScreen();
                    SplashKit.Delay(5000);

                    changeState = 1;
                }
                else
                {
                    // if attacking or jumping, switch the state of idle
                    if (count != 0)
                    {
                        p1.State = "idle";
                        p2.State = "idle";
                        count = 0;
                    }

                    // Player two attack
                    if (SplashKit.KeyDown(KeyCode.LKey))
                    {
                        p2.State = "attack";

                        if (p2.IsAt(p1.CurrentPos) || p1.IsAt(p2.CurrentPos))
                        {
                            // for testing purpose
                            SplashKit.DrawText(".....", Color.White, 500, 150);

                            p1.State = "hurt";
                            p1.Health.DecreaseHealth();
                            p2.Score.IncreaseScore();
                            count++;
                            soundEffect.Play();
                        }
                    }

                    // Player one attack
                    if (SplashKit.KeyDown(KeyCode.SpaceKey))
                    {
                        p1.State = "attack";

                        if (p1.IsAt(p2.CurrentPos) || p2.IsAt(p1.CurrentPos))
                        {
                            // for testing purpose
                            SplashKit.DrawText(".....", Color.Green, 500, 160);

                            p2.State = "hurt";
                            p2.Health.DecreaseHealth();
                            p1.Score.IncreaseScore();
                            count++;
                            soundEffect.Play();
                        }
                    }

                    // Player one Jump 
                    if (SplashKit.KeyDown(KeyCode.WKey))
                    {
                        p1.IsJump = true;
                        p1.State = "jump";
                        count++;
                    }

                    // Player two Jump
                    if (SplashKit.KeyDown(KeyCode.UpKey))
                    {
                        p2.IsJump = true;
                        p2.State = "jump";
                        count++;
                    }

                    // Draw both players 
                    p1.Draw();
                    p2.Draw();


                    // Player One move backward 
                    if (SplashKit.KeyDown(KeyCode.AKey))
                    {
                        if (p1.X >= 10)
                        {
                            p1.X -= 0.2;
                        }
                    }

                    // Player One move forward
                    if (SplashKit.KeyDown(KeyCode.DKey))
                    {
                        if (p1.X <= 650)
                        {
                            p1.X += 0.2;
                        }
                    }

                    // Player One move fast forward
                    if (SplashKit.KeyDown(KeyCode.RKey))
                    {
                        if (p1.X <= 650)
                        {
                            p1.X += 0.5;
                        }
                    }

                    // Player One move fast backward
                    if (SplashKit.KeyDown(KeyCode.QKey))
                    {
                        if (p1.X >= 10)
                        {
                            p1.X -= 0.5;
                        }
                    }

                    // Player Two move backward
                    if (SplashKit.KeyDown(KeyCode.LeftKey))
                    {
                        if (p2.X >= 10)
                        {
                            p2.X -= 0.2;
                        }
                    }

                    // Player Two move forward
                    if (SplashKit.KeyDown(KeyCode.RightKey))
                    {
                        if (p2.X <= 570)
                        {
                            p2.X += 0.2;
                        }
                    }

                    // Player Two Move fast backward
                    if (SplashKit.KeyDown(KeyCode.MKey))
                    {
                        if (p2.X >= 10)
                        {
                            p2.X -= 0.5;
                        }
                    }

                    // Player Two Move fast forward
                    if (SplashKit.KeyDown(KeyCode.CommaKey))
                    {
                        if (p2.X <= 570)
                        {
                            p2.X += 0.5;
                        }
                    }
                }
                SplashKit.RefreshScreen();
            } while (!SplashKit.WindowCloseRequested("End of Evil") && changeState == 0);
        }


        public int CheckState
        {
            get
            {
                return changeState;
            }
            set
            {
                changeState = value;
            }
        }

        public string Winner
        {
            get
            {
                return _winner;
            }
        }
    }
}
