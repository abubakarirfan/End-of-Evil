using SplashKitSDK;

namespace CombatGame
{
    public class MainMenu : IMenu
    {
        private int _checkState;

        private int _checkSinglePlayerButtonState;
        private int _checkTwoPlayerButtonState;
        private int _checkInstructionButtonState;

        private Boxes _playVsAI;
        private Boxes _twoPlayers;
        private Boxes _instructions;
        private Bitmap _nameOfGame;

        private Bitmap _background;
        private Bitmap _logo;
        private Music _music;

        /// <summary>
        /// This is the constructor. It is used to define the MainMenu
        /// </summary>

        public MainMenu()
        {
            _checkState = 0;
            _nameOfGame = new Bitmap("game name", "resources/img/name.png");
            _background = new Bitmap("background main menu", "resources/img/b3.png");
            _logo = new Bitmap("logo", "resources/img/logo.png");
            _music = new Music("background music", "resources/music/theme.mp3");
        }

        /// <summary>
        /// This is used to execute the main menu state
        /// </summary>
         
        public void Execute()
        {
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                SplashKit.DrawBitmap(_background, 0, 0);


                SplashKit.DrawBitmap(_nameOfGame, 50, 100);
                SplashKit.DrawBitmap(_logo, 150, 250);

                if (!SplashKit.MusicPlaying())
                {
                    _music.FadeIn(3000);
                    _music.Play();
                }

                if (_checkSinglePlayerButtonState == 1)
                {
                    _playVsAI = new Boxes("AI", "resources/button/singleplayer.png", 600, 100);
                }
                else
                {
                    _playVsAI = new Boxes("AI Hover", "resources/button/hover_singleplayer.png", 600, 100);
                }


                if (_checkTwoPlayerButtonState == 1)
                {
                    _twoPlayers = new Boxes("Two Players", "resources/button/twoplayer.png", 600, 200);
                }
                else
                {
                    _twoPlayers = new Boxes("Two Players Hover", "resources/button/hover_twoplayer.png", 600, 200);
                }

                if (_checkInstructionButtonState == 1)
                {
                    _instructions = new Boxes("_instructions", "resources/button/instruction.png", 600, 300);
                }
                else
                {
                    _instructions = new Boxes("_instructions Hover", "resources/button/hover_instruction.png", 600, 300);
                }


                _playVsAI.Draw();
                _twoPlayers.Draw();
                _instructions.Draw();

                _checkSinglePlayerButtonState = 1;
                _checkInstructionButtonState = 1;
                _checkTwoPlayerButtonState = 1;

                //AI VS PLAYER
                if (_playVsAI.IsAt(SplashKit.MousePosition()))
                {
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        _checkState = 1;
                    }
                    _checkSinglePlayerButtonState = 0;
                }

                //PLAYER VS PLAYER
                if (_twoPlayers.IsAt(SplashKit.MousePosition()))
                {
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        _checkState = 2;
                    }
                    _checkTwoPlayerButtonState = 0;
                }

                // _instructions
                if (_instructions.IsAt(SplashKit.MousePosition()))
                {
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        _checkState = 3;
                    }
                    _checkInstructionButtonState = 0;
                }
                SplashKit.RefreshScreen();
            } while (!SplashKit.WindowCloseRequested("End of Evil") && _checkState == 0);
        }

        /// <summary>
        /// this is used to check/set the state of the program
        /// </summary>

        public int CheckState
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

    }
}
