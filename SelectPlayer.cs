using SplashKitSDK;

namespace CombatGame
{
    public class SelectPlayer : IMenu
    {
        private int checkState;
        private string selectedPlayer;
        private int checkBackButtonState;
        private Boxes back;
        private Boxes knight;
        private Boxes robot;
        private Boxes king;
        private Boxes redKnight;
        private Boxes yellowKnight;
        private Boxes blueKnight;
        private Bitmap bitmap;
        private Music music;


        public SelectPlayer()
        {
            checkState = 0;
            knight = new Boxes("Knight", "resources/img/knight.png", 100, 200);
            robot = new Boxes("Robot", "resources/img/robot.png", 250, 200);
            king = new Boxes("King", "resources/img/king.png", 400, 200);
            redKnight = new Boxes("Red Knight", "resources/img/redknight.png", 550, 200);
            yellowKnight = new Boxes("Yellow Knight", "resources/img/yellowknight.png", 250, 350);
            blueKnight = new Boxes("Blue Knight", "resources/img/blueknight.png", 400, 350);
            bitmap = new Bitmap("banner", "resources/img/banner.png");
            music = new Music("bg music", "resources/music/theme.mp3");
        }

        public void Execute()
        {
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.Black);

                if (checkBackButtonState == 1)
                {
                    back = new Boxes("Back", "resources/button/back.png", 25, 25);
                }
                else
                {
                    back = new Boxes("Back Hover", "resources/button/hover_back.png", 25, 25);
                }

                back.Draw();

                checkBackButtonState = 1;

                if (!SplashKit.MusicPlaying())
                {
                    music.FadeIn(3000);
                    music.Play();
                }

                SplashKit.DrawBitmap(bitmap, 100, 0);

                knight.Draw();
                robot.Draw();
                king.Draw();
                redKnight.Draw();
                yellowKnight.Draw();
                blueKnight.Draw();

                if (knight.IsAt(SplashKit.MousePosition()))
                {
                    SplashKit.DrawText("Player: " + knight.Name, Color.White, 300, 525);

                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        checkState = 1;
                        selectedPlayer = knight.Name;
                    }
                }

                if (robot.IsAt(SplashKit.MousePosition()))
                {
                    SplashKit.DrawText("Player: " + robot.Name, Color.White, 300, 525);

                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        checkState = 2;
                        selectedPlayer = robot.Name;
                    }
                }

                if (king.IsAt(SplashKit.MousePosition()))
                {
                    SplashKit.DrawText("Player: " + king.Name, Color.White, 300, 525);

                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        checkState = 3;
                        selectedPlayer = king.Name;
                    }
                }

                if (redKnight.IsAt(SplashKit.MousePosition()))
                {
                    SplashKit.DrawText("Player: " + redKnight.Name, Color.White, 300, 525);

                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        checkState = 4;
                        selectedPlayer = redKnight.Name;
                    }
                }

                if (yellowKnight.IsAt(SplashKit.MousePosition()))
                {
                    SplashKit.DrawText("Player: " + yellowKnight.Name, Color.White, 300, 525);

                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        checkState = 5;
                        selectedPlayer = yellowKnight.Name;
                    }
                }

                if (blueKnight.IsAt(SplashKit.MousePosition()))
                {
                    SplashKit.DrawText("Player: " + blueKnight.Name, Color.White, 300, 525);

                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        checkState = 6;
                        selectedPlayer = blueKnight.Name;
                    }
                }

                if (back.IsAt(SplashKit.MousePosition()))
                {
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        checkState = 7;
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

        public string SelectedPlayer
        {
            get
            {
                return selectedPlayer;
            }
            set
            {
                selectedPlayer = value;
            }
        }

    }
}
