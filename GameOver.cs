using SplashKitSDK;

namespace CombatGame
{
    public class GameOver : IMenu
    {
        private int _checkState;
        private int _checkStateReturnToMainMenu;
        private Boxes _returnToMainMenu;
        private Bitmap _gameOver;
        private string _winner;

        /// <summary>
        /// This is used to define the gameover object
        /// </summary>

        public GameOver()
        {
            _checkState = 0;
            _gameOver = new Bitmap("GameOver", "resources/img/gameOver.png");
        }


        /// <summary>
        /// This is used to excute the gameover state
        /// </summary>

        public void Execute()
        {
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.Black);
                SplashKit.DrawBitmap(_gameOver, 0, 0);

                SplashKit.DrawText(_winner + " WINS!!!!", Color.White, 300, 300);


                if (_checkStateReturnToMainMenu == 1)
                {
                    _returnToMainMenu = new Boxes("return to main", "resources/button/returnmenu.png", 275, 400);
                }
                else
                {
                    _returnToMainMenu = new Boxes("Hover return to main", "resources/button/hover_returnmenu.png", 275, 400);
                }


                _returnToMainMenu.Draw();

                _checkStateReturnToMainMenu = 1;

                if (_returnToMainMenu.IsAt(SplashKit.MousePosition()))
                {
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        _checkState = 1;
                    }
                    _checkStateReturnToMainMenu = 0;
                }

                SplashKit.RefreshScreen();
            } while (!SplashKit.WindowCloseRequested("End of Evil") && _checkState == 0);
        }
 

        /// <summary>
        /// This is used to set and return the winner
        /// </summary>

        public string Winner
        {
            set
            {
                _winner = value;
            }
            get
            {
                return _winner; 
            }
        }

        /// <summary>
        /// This is used to check/set the state of the program
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
