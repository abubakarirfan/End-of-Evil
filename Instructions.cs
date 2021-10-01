using SplashKitSDK;

namespace CombatGame
{
    public class Instructions : IMenu
    {
        private int _checkState;
        private int _checkBackButtonState;
        private Boxes _back;
        private Bitmap _background;

        /// <summary>
        /// THis is used to define the instruction object
        /// </summary>

        public Instructions()
        {
            _checkState = 0;
            _background = new Bitmap("Background Instructions", "resources/img/instructions.png");
        }

        /// <summary>
        /// THis is used to execute the instruction state
        /// </summary>

        public void Execute()
        {
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.Black);
                SplashKit.DrawBitmap(_background, 0, 0);

                if (_checkBackButtonState == 1)
                {
                    _back = new Boxes("Back", "resources/button/back.png", 25, 25);
                }
                else
                {
                    _back = new Boxes("Back Hover", "resources/button/hover_back.png", 25, 25);
                }

                _checkBackButtonState = 1;

                _back.Draw();

                if (_back.IsAt(SplashKit.MousePosition()))
                {
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        _checkState = 1;
                    }
                    _checkBackButtonState = 0;
                }

                SplashKit.RefreshScreen();
            } while (!SplashKit.WindowCloseRequested("End of Evil") && _checkState == 0);
        }

        /// <summary>
        /// This is used to set/check the state of the program
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
