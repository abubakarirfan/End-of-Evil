using SplashKitSDK;

namespace CombatGame
{
    public class TwoPlayerGamePlay : GamePlay, IMenu
    {
        
        private int _checkState;
        private string _winner;
        private int _count;

        /// <summary>
        /// this is used to define TwoPlayerGamePlay object
        /// </summary>

        public TwoPlayerGamePlay()
        {
            _checkState = 0;
            _count = 1;
        }

        /// <summary>
        /// this is used to execute the TwoPlayerGamePlay state
        /// </summary>

        public override void Execute()
        {
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.Black);
                SplashKit.DrawBitmap(Background, 0, 0);

                // call jump for player 1 and player 2
                P1.Jump();
                P2.Jump();

                // display players score
                P1.Score.Draw(50, 50);
                P2.Score.Draw(650, 50);

                // check if music is playing if not, play music
                if (!SplashKit.MusicPlaying())
                {
                    music.Play();
                }

                // display players health
                P2.Health.Draw(650, 25);
                P1.Health.Draw(50, 25);

                P1.State = StatePlayer.IDLE;
                P2.State = StatePlayer.IDLE;



                if (P1.Health.GetHealth <= 0 || P2.Health.GetHealth <= 0)
                {
                    if (P1.Health.GetHealth <= 0)
                    {
                        P1.State = StatePlayer.DIE;
                        _winner = "Player 2";
                        _count++;
                    }
                    else
                    {
                        _winner = "Player 1";
                        P2.State = StatePlayer.DIE;
                        _count++;
                    }

                    // draw dead players
                    P1.Draw();
                    P2.Draw();

                    SplashKit.RefreshScreen();
                    SplashKit.Delay(5000);

                    _checkState = 1;
                }
                else
                {
                    // if attacking or jumping, switch the state of idle
                    if (_count != 0)
                    {
                        P1.State = StatePlayer.IDLE;
                        P2.State = StatePlayer.IDLE;
                        _count = 0;
                    }

                    // Player two attack
                    if (SplashKit.KeyDown(KeyCode.LKey))
                    {

                        P2.State = StatePlayer.ATTACK;

                        if (P2.IsAt(P1.CurrentPos) || P1.IsAt(P2.CurrentPos))
                        {
                            P1.State = StatePlayer.HURT;
                            P1.Health.DecreaseHealth();
                            P2.Score.IncreaseScore();
                            _count++;
                            SoundEffect.Play();
                        }
                    }

                    // Player one attack
                    if (SplashKit.KeyDown(KeyCode.SpaceKey))
                    {
                        P1.State = StatePlayer.ATTACK;

                        if (P1.IsAt(P2.CurrentPos) || P2.IsAt(P1.CurrentPos))
                        {
                            P2.State = StatePlayer.HURT;
                            P2.Health.DecreaseHealth();
                            P1.Score.IncreaseScore();
                            _count++;
                            SoundEffect.Play();
                        }
                    }

                    // Player one Jump 
                    if (SplashKit.KeyDown(KeyCode.WKey))
                    {
                        P1.IsJump = true;
                        P1.State = StatePlayer.JUMP;
                        _count++;
                    }

                    // Player two Jump
                    if (SplashKit.KeyDown(KeyCode.UpKey))
                    {
                        P2.IsJump = true;
                        P2.State = StatePlayer.JUMP;
                        _count++;
                    }

                    // Draw both players 
                    P1.Draw();
                    P2.Draw();


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

                    // Player Two move backward
                    if (SplashKit.KeyDown(KeyCode.LeftKey))
                    {
                        if (P2.X >= 10)
                        {
                            P2.X -= 0.2;
                        }
                    }

                    // Player Two move forward
                    if (SplashKit.KeyDown(KeyCode.RightKey))
                    {
                        if (P2.X <= 570)
                        {
                            P2.X += 0.2;
                        }
                    }

                    // Player Two Move fast backward
                    if (SplashKit.KeyDown(KeyCode.MKey))
                    {
                        if (P2.X >= 10)
                        {
                            P2.X -= 0.5;
                        }
                    }

                    // Player Two Move fast forward
                    if (SplashKit.KeyDown(KeyCode.CommaKey))
                    {
                        if (P2.X <= 570)
                        {
                            P2.X += 0.5;
                        }
                    }
                }
                SplashKit.RefreshScreen();
            } while (!SplashKit.WindowCloseRequested("End of Evil") && _checkState == 0);
        }

        /// <summary>
        /// this is used to set/get the state of the program
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
        /// this is used to return the winner
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
