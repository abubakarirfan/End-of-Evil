using SplashKitSDK;

namespace CombatGame
{
    public class MainMenu : IMenu
    {
        private int checkState;

        private int checkSinglePlayerButtonState;
        private int checkTwoPlayerButtonState;
        private int checkInstructionButtonState;

        private Boxes playVsAI;
        private Boxes twoPlayers;
        private Boxes instructions;
        private Bitmap nameOfGame;

        private Bitmap bg;
        private Bitmap logo;
        private Music music;

        public MainMenu()
        {
            checkState = 0;
            nameOfGame = new Bitmap("game name", "resources/img/name.png");
            bg = new Bitmap("background main menu", "resources/img/b3.png");
            logo = new Bitmap("logo", "resources/img/logo.png");
            music = new Music("bg music", "resources/music/theme.mp3");
        }

        public void Execute()
        {
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                SplashKit.DrawBitmap(bg, 0, 0);


                SplashKit.DrawBitmap(nameOfGame, 50, 100);
                SplashKit.DrawBitmap(logo, 150, 250);

                if (!SplashKit.MusicPlaying())
                {
                    music.FadeIn(3000);
                    music.Play();
                }

                if (checkSinglePlayerButtonState == 1)
                {
                    playVsAI = new Boxes("AI", "resources/button/singleplayer.png", 600, 100);
                }
                else
                {
                    playVsAI = new Boxes("AI Hover", "resources/button/hover_singleplayer.png", 600, 100);
                }


                if (checkTwoPlayerButtonState == 1)
                {
                    twoPlayers = new Boxes("Two Players", "resources/button/twoplayer.png", 600, 200);
                }
                else
                {
                    twoPlayers = new Boxes("Two Players Hover", "resources/button/hover_twoplayer.png", 600, 200);
                }

                if (checkInstructionButtonState == 1)
                {
                    instructions = new Boxes("Instructions", "resources/button/instruction.png", 600, 300);
                }
                else
                {
                    instructions = new Boxes("Instructions Hover", "resources/button/hover_instruction.png", 600, 300);
                }


                playVsAI.Draw();
                twoPlayers.Draw();
                instructions.Draw();

                checkSinglePlayerButtonState = 1;
                checkInstructionButtonState = 1;
                checkTwoPlayerButtonState = 1;

                //AI VS PLAYER
                if (playVsAI.IsAt(SplashKit.MousePosition()))
                {
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        checkState = 1;
                    }
                    checkSinglePlayerButtonState = 0;
                }

                //PLAYER VS PLAYER
                if (twoPlayers.IsAt(SplashKit.MousePosition()))
                {
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        checkState = 2;
                    }
                    checkTwoPlayerButtonState = 0;
                }

                // INSTRUCTIONS
                if (instructions.IsAt(SplashKit.MousePosition()))
                {
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        checkState = 3;
                    }
                    checkInstructionButtonState = 0;
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
