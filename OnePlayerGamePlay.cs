using SplashKitSDK;

namespace CombatGame
{
    public class OnePlayerGamePlay : GamePlay, IMenu
    {
        private int _checkState;
        private string _winner;
        private int _count;
        private Context _context;

        /// <summary>
        /// this is used to define the oneplayergameplay object
        /// </summary>

        public OnePlayerGamePlay()
        {
            _checkState = 0;
            _count = 1;
            _context = new Context();
        }

        /// <summary>
        /// this is used to execute the state of the program
        /// </summary>

        public override void Execute()
        {
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.Black);
                SplashKit.DrawBitmap(Background, 0, 0);

                P1.Jump();
                Bot.Jump();

                P1.Score.Draw(50, 50);
                Bot.Score.Draw(650, 50);

                Bot.Health.Draw(650, 25);
                P1.Health.Draw(50, 25);

                if (!SplashKit.MusicPlaying())
                {
                    music.Play();
                }


                if (P1.Health.GetHealth <= 0 || Bot.Health.GetHealth <= 0)
                {
                    if (P1.Health.GetHealth <= 0)
                    {
                        P1.State = "die";
                        _winner = "Bot";
                        _count++;
                    }
                    else
                    {
                        _winner = "Player 1";
                        Bot.State = "die";
                        _count++;
                    }

                    // draw dead players
                    P1.Draw();
                    Bot.Draw();

                    SplashKit.RefreshScreen();
                    SplashKit.Delay(5000);

                    _checkState = 1;
                }
                else
                {
                    // if attacking or jumping, switch the state of idle
                    if (_count != 0)
                    {
                        P1.State = "idle";
                        Bot.State = "idle";
                        _count = 0;
                    }


                    if (Bot.IsAt(P1.CurrentPos))
                    {
                        _context.setStrategy(new StrategyMoveAttack(Bot));
                        P1.State = "hurt";
                        _count++;
                        SoundEffect.Play();
                        P1.Health.DecreaseHealth();
                        _context.executeStrategy();
                    }

                    if (P1.X <= 350)
                    {
                        _context.setStrategy(new StrategyMoveForward(Bot));
                        _context.executeStrategy();
                    }
                    else
                    {
                        _context.setStrategy(new StrategyMoveBackward(Bot));
                        _context.executeStrategy();
                    }


                    if (SplashKit.KeyDown(KeyCode.SpaceKey))
                    {
                        P1.State = "attack";

                        if (P1.IsAt(Bot.CurrentPos) || Bot.IsAt(P1.CurrentPos))
                        {
                            // for testing purpose
                            SplashKit.DrawText(".....", Color.Green, 500, 160);

                            Bot.State = "hurt";
                            Bot.Health.DecreaseHealth();
                            P1.Score.IncreaseScore();
                            SoundEffect.Play();
                        }
                        _count++;
                    }

                    if (SplashKit.KeyDown(KeyCode.WKey))
                    {
                        P1.IsJump = true;
                        P1.State = "jump";
                        _count++;
                    }

                    // Draw Both players 
                    P1.Draw();
                    Bot.Draw();

                    // Player One move backward 
                    if (SplashKit.KeyDown(KeyCode.AKey))
                    {
                        if (P1.X >= 10)
                        {
                            P1.X -= 0.2;
                        }
                    }

                    // Player One move forward
                    if (SplashKit.KeyDown(KeyCode.DKey))
                    {
                        if (P1.X <= 650)
                        {
                            P1.X += 0.2;
                        }
                    }

                    // Player One move fast forward
                    if (SplashKit.KeyDown(KeyCode.RKey))
                    {
                        if (P1.X <= 650)
                        {
                            P1.X += 0.5;
                        }
                    }

                    // Player One move fast backward
                    if (SplashKit.KeyDown(KeyCode.QKey))
                    {
                        if (P1.X >= 10)
                        {
                            P1.X -= 0.5;
                        }
                    }
                }
                SplashKit.RefreshScreen();
            } while (!SplashKit.WindowCloseRequested("End of Evil") && _checkState == 0);
        }


        /// <summary>
        /// this is used to set/check the state
        /// </summary>

        public override int CheckState
        {
            get
            {
                return _checkState;
            }
            set
            {
                _checkState = value;
            }
        }


        /// <summary>
        /// This is return to access the winner
        /// </summary>

        public override string Winner
        {
            get
            {
                return _winner;
            }
        }
    }
}
