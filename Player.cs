using SplashKitSDK;
using System;

namespace CombatGame
{
    public enum StatePlayer
    {
        IDLE,
        ATTACK,
        JUMP,
        HURT,
        DIE
    }


    public abstract class Player : GameObject
    {
        private double _x, _y;
        private Score _score;
        private Health _health;

        private bool _isJump;
        private double _jumpCount;
        private double _neg;

        private StatePlayer _state;

        private Point2D _currentPos;

        /// <summary>
        /// This is used to define the player object
        /// </summary>
        /// <param name="name">Name of the player</param>

        public Player(string name) : base(name)
        {
            _health = new Health();
            _score = new Score();
            _isJump = false;
            _jumpCount = 10;
            _state = StatePlayer.IDLE;
            _currentPos.X = 0;
            _currentPos.Y = 0;
        }

        public abstract void Draw();

        public abstract bool IsAt(Point2D pt);

        /// <summary>
        /// This is used to make the player jump
        /// </summary>

        public void Jump()
        {
            if (_isJump)
            {
                if (_jumpCount >= -10)
                {
                    _neg = 1;

                    if (_jumpCount < 0)
                    {
                        _neg = -1;
                    }
                    _y -= Math.Pow(_jumpCount, 2) * _neg;
                    _jumpCount -= 10;
                }
                else
                {
                    _isJump = false;
                    _jumpCount = 10;
                }
            }
        }

        /// <summary>
        /// this is a property that return the current position of the player
        /// </summary>

        public Point2D CurrentPos
        {
            get
            {
                _currentPos.X = X;
                _currentPos.Y = Y;
                return _currentPos;
            }
            set
            {
                _currentPos = value;
            }
        }

        public abstract Sprite Sprite
        {
            get;
        }

        /// <summary>
        /// this is used to check if the player is jumping
        /// </summary>
        
        public bool IsJump
        {
            get
            {
                return _isJump;
            }
            set
            {
                _isJump = value;
            }
        }

        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public StatePlayer State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }


        public Health Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
            }
        }

        public Score Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
            }
        }

    }
}
