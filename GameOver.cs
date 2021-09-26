using SplashKitSDK;

namespace CombatGame
{
    public class GameOver : IMenu
    {
        private int checkState;
        private int checkStateReturnToMainMenu;
        private Boxes returnToMainMenu;
        private Bitmap gameOver;
        private string _winner;


        public GameOver(string winner)
        {
            _winner = winner;
            checkState = 0;
            gameOver = new Bitmap("GameOver", "resources/img/gameOver.png");
        }

        public void Execute()
        {
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.Black);
                SplashKit.DrawBitmap(gameOver, 0, 0);

                SplashKit.DrawText(_winner + " WINS!!!!", Color.White, 300, 300);


                if (checkStateReturnToMainMenu == 1)
                {
                    returnToMainMenu = new Boxes("return to main", "resources/button/returnmenu.png", 275, 400);
                }
                else
                {
                    returnToMainMenu = new Boxes("Hover return to main", "resources/button/hover_returnmenu.png", 275, 400);
                }


                returnToMainMenu.Draw();

                checkStateReturnToMainMenu = 1;

                if (returnToMainMenu.IsAt(SplashKit.MousePosition()))
                {
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        checkState = 1;
                    }
                    checkStateReturnToMainMenu = 0;
                }

                SplashKit.RefreshScreen();
            } while (!SplashKit.WindowCloseRequested("End of Evil") && checkState == 0);
        }


        public int CheckState
        {
            get
            {
                return checkState;
            }
            set
            {
                checkState = value;
            }
        }

    }
}
