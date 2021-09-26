using SplashKitSDK;

namespace CombatGame
{
    public class OnePlayerGamePlayer : IMenu
    {
        private string _selectedPlayerName;
        private int changeState;
        private string _winner;
        private SoundEffect soundEffect;
        private Player p1;
        private Player bot;
        private int count;
        private Music music;
        private Bitmap background;
        private Context context;


        public OnePlayerGamePlayer()
        {
            changeState = 0;
            soundEffect = new SoundEffect("sword", "resources/music/sword.wav");
            count = 1;
            music = new Music("background music", "resources/music/background.mp3");
            background = new Bitmap("background", "resources/img/b1.jpg");
            context = new Context();
        }


        public void AssignSelectedPlayer(string selectedPlayer)
        {
            _selectedPlayerName = selectedPlayer;

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
            bot = new Troll("Troll");
        }

        public void AssignCoordinatesForStart()
        {
            p1.X = 50;
            bot.X = 550;

            p1.Y = 400;
            bot.Y = 400;
        }


        public void Execute()
        {
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.Black);
                SplashKit.DrawBitmap(background, 0, 0);

                p1.Jump();
                bot.Jump();

                p1.Score.Draw(50, 50);
                bot.Score.Draw(650, 50);

                bot.Health.Draw(650, 25);
                p1.Health.Draw(50, 25);

                if (!SplashKit.MusicPlaying())
                {
                    music.Play();
                }


                if (p1.Health.GetHealth <= 0 || bot.Health.GetHealth <= 0)
                {
                    if (p1.Health.GetHealth <= 0)
                    {
                        p1.State = "die";
                        _winner = "Bot";
                        count++;
                    }
                    else
                    {
                        _winner = "Player 1";
                        bot.State = "die";
                        count++;
                    }

                    // draw dead players
                    p1.Draw();
                    bot.Draw();

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
                        bot.State = "idle";
                        count = 0;
                    }


                    if (bot.IsAt(p1.CurrentPos))
                    {
                        context.setStrategy(new StrategyMoveAttack(bot));
                        p1.State = "hurt";
                        count++;
                        soundEffect.Play();
                        p1.Health.DecreaseHealth();
                        context.executeStrategy();
                    }

                    if (p1.X <= 350)
                    {
                        context.setStrategy(new StrategyMoveForward(bot));
                        context.executeStrategy();
                    }
                    else
                    {
                        context.setStrategy(new StrategyMoveBackward(bot));
                        context.executeStrategy();
                    }


                    if (SplashKit.KeyDown(KeyCode.SpaceKey))
                    {
                        p1.State = "attack";

                        if (p1.IsAt(bot.CurrentPos) || bot.IsAt(p1.CurrentPos))
                        {
                            // for testing purpose
                            SplashKit.DrawText(".....", Color.Green, 500, 160);

                            bot.State = "hurt";
                            bot.Health.DecreaseHealth();
                            p1.Score.IncreaseScore();
                            soundEffect.Play();
                        }
                        count++;
                    }

                    if (SplashKit.KeyDown(KeyCode.WKey))
                    {
                        p1.IsJump = true;
                        p1.State = "jump";
                        count++;
                    }

                    // Draw both players 
                    p1.Draw();
                    bot.Draw();

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
