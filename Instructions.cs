using SplashKitSDK;

namespace CombatGame
{
    public class Instructions : IMenu
    {
        private int checkState;
        private int checkBackButtonState;
        private Boxes back;
        private Bitmap bg;

        public Instructions()
        {
            checkState = 0;
            bg = new Bitmap("Background Instructions", "resources/img/instructions.png");
        }

        public void Execute()
        {
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.Black);
                SplashKit.DrawBitmap(bg, 0, 0);

                if (checkBackButtonState == 1)
                {
                    back = new Boxes("Back", "resources/button/back.png", 25, 25);
                }
                else
                {
                    back = new Boxes("Back Hover", "resources/button/hover_back.png", 25, 25);
                }

                checkBackButtonState = 1;

                back.Draw();

                if (back.IsAt(SplashKit.MousePosition()))
                {
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        checkState = 1;
                    }
                    checkBackButtonState = 0;
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
