using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

namespace CombatGame
{
    public abstract class GamePlay
    {
        private string _selectedPlayerName;
        private Player _p1;
        private Player _p2;
        private SoundEffect _soundEffect;
        private Music _music;
        private Bitmap _background;
        
        /// <summary>
        /// This is used to define the GamePlay Object
        /// </summary>

        public GamePlay()
        {
            _music = new Music("bg music", "resources/music/background.mp3");
            _background = new Bitmap("background", "resources/img/b1.jpg");
            _soundEffect = new SoundEffect("sword", "resources/music/sword.wav");
        }

        /// <summary>
        /// This is used to declare players
        /// </summary>
        /// <param name="selectedPlayer">Stores player selected by the user</param>

        public void AssignSelectedPlayer(string selectedPlayer)
        {
            _selectedPlayerName = selectedPlayer;

            if (_selectedPlayerName == "Knight")
            {
                _p1 = new Knight("Knight");
            }
            else if (_selectedPlayerName == "Robot")
            {
                _p1 = new Robot("Robot");
            }
            else if (_selectedPlayerName == "King")
            {
                _p1 = new King("King");
            }
            else if (_selectedPlayerName == "Yellow Knight")
            {
                _p1 = new YellowKnight("YellowKnight");
            }
            else if (_selectedPlayerName == "Blue Knight")
            {
                _p1 = new BlueKnight("BlueKnight");
            }
            else
            {
                _p1 = new RedKnight("Red Knight");
            }
            _p2 = new Troll("Troll");
        }

        /// <summary>
        /// This is used to assign starting coordinates to both player
        /// </summary>

        public void AssignPlayersCoordinates()
        {
            _p1.X = 50;
            _p2.X = 550;

            _p1.Y = 400;
            _p2.Y = 400;
        }


        public abstract void Execute();

        public abstract int CheckState
        {
            get;
            set;
        }

        public abstract string Winner
        {
            get;
        }

        public Bitmap Background
        {
            get
            {
                return _background;
            }
        }

        public Player P1
        {
            get
            {
                return _p1;
            }
        }

        public Player P2
        {
            get
            {
                return _p2;
            }
        }

        public Music music
        {
            get
            {
                return _music;
            }
        }

        public Player Bot
        {
            get
            {
                return _p2;
            }
        }

        public SoundEffect SoundEffect
        {
            get
            {
                return _soundEffect;
            }
        }


    }
}
