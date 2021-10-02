using SplashKitSDK;

namespace CombatGame
{
    public enum PlayerChosen
    {
        KNIGHT,
        ROBOT,
        KING, 
        YELLOWKNIGHT,
        REDKNIGHT,
        BLUEKNIGHT
    }

    public class SelectPlayer : IMenu
    {
        private int _checkState;
        private int _checkBackButtonState;
        private Boxes _back;
        private Boxes _knight;
        private Boxes _robot;
        private Boxes _king;
        private Boxes _redKnight;
        private Boxes _yellowKnight;
        private Boxes _blueKnight;
        private Bitmap _bitmap;
        private Music _music;
        private PlayerChosen _selectedPlayer;


        /// <summary>
        /// this is used to define selectplayer
        /// </summary>

        public SelectPlayer()
        {
            _checkState = 0;
            _knight = new Boxes("Knight", "resources/img/knight.png", 100, 200);
            _robot = new Boxes("Robot", "resources/img/robot.png", 250, 200);
            _king = new Boxes("King", "resources/img/king.png", 400, 200);
            _redKnight = new Boxes("Red Knight", "resources/img/redknight.png", 550, 200);
            _yellowKnight = new Boxes("Yellow Knight", "resources/img/yellowknight.png", 250, 350);
            _blueKnight = new Boxes("Blue Knight", "resources/img/blueknight.png", 400, 350);
            _bitmap = new Bitmap("banner", "resources/img/banner.png");
            _music = new Music("bg music", "resources/music/theme.mp3");
            _selectedPlayer = PlayerChosen.KNIGHT;
        }

        /// <summary>
        /// this is used to execute selectplayer state
        /// </summary>

        public void Execute()
        {
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.Black);

                if (_checkBackButtonState == 1)
                {
                    _back = new Boxes("Back", "resources/button/back.png", 25, 25);
                }
                else
                {
                    _back = new Boxes("Back Hover", "resources/button/hover_back.png", 25, 25);
                }

                _back.Draw();

                _checkBackButtonState = 1;

                if (!SplashKit.MusicPlaying())
                {
                    _music.FadeIn(3000);
                    _music.Play();
                }

                SplashKit.DrawBitmap(_bitmap, 100, 0);

                _knight.Draw();
                _robot.Draw();
                _king.Draw();
                _redKnight.Draw();
                _yellowKnight.Draw();
                _blueKnight.Draw();

                if (_knight.IsAt(SplashKit.MousePosition()))
                {
                    SplashKit.DrawText("Player: " + _knight.Name, Color.White, 300, 525);

                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        _checkState = 1;
                        _selectedPlayer = PlayerChosen.KNIGHT;
                    }
                }

                if (_robot.IsAt(SplashKit.MousePosition()))
                {
                    SplashKit.DrawText("Player: " + _robot.Name, Color.White, 300, 525);

                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        _checkState = 2;
                        _selectedPlayer = PlayerChosen.ROBOT;
                    }
                }

                if (_king.IsAt(SplashKit.MousePosition()))
                {
                    SplashKit.DrawText("Player: " + _king.Name, Color.White, 300, 525);

                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        _checkState = 3;
                        _selectedPlayer = PlayerChosen.KING;
                    }
                }

                if (_redKnight.IsAt(SplashKit.MousePosition()))
                {
                    SplashKit.DrawText("Player: " + _redKnight.Name, Color.White, 300, 525);

                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        _checkState = 4;
                        _selectedPlayer = PlayerChosen.REDKNIGHT;
                    }
                }

                if (_yellowKnight.IsAt(SplashKit.MousePosition()))
                {
                    SplashKit.DrawText("Player: " + _yellowKnight.Name, Color.White, 300, 525);

                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        _checkState = 5;
                        _selectedPlayer = PlayerChosen.YELLOWKNIGHT;
                    }
                }

                if (_blueKnight.IsAt(SplashKit.MousePosition()))
                {
                    SplashKit.DrawText("Player: " + _blueKnight.Name, Color.White, 300, 525);

                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        _checkState = 6;
                        _selectedPlayer = PlayerChosen.BLUEKNIGHT;
                    }
                }

                if (_back.IsAt(SplashKit.MousePosition()))
                {
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        _checkState = 7;
                    }
                    _checkBackButtonState = 0;
                }

                SplashKit.RefreshScreen();
            } while (!SplashKit.WindowCloseRequested("End of Evil") && _checkState == 0);
        }

        /// <summary>
        /// this is used to set/check the state of the program
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

        /// <summary>
        /// this is used to set/check the selectedplayer
        /// </summary>


        public PlayerChosen SelectedPlayer
        {
            get
            {
                return _selectedPlayer;
            }
            set
            {
                _selectedPlayer = value;
            }
        }

    }
}
