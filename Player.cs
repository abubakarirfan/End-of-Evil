using SplashKitSDK;
using System;

namespace CombatGame
{
    public abstract class Player : GameObject
    {
        private double _x, _y;
        private Score _score;
        private Health _health;
        private string _name;

        private bool isJump;
        private double jumpCount;
        private double neg;

        private string _state;

        private Point2D _currentPos;

        public Player(string name) : base(name)
        {
            _name = name;
            _health = new Health();
            _score = new Score();
            isJump = false;
            jumpCount = 10;
            _state = "idle";
            _currentPos.X = 0;
            _currentPos.Y = 0;
        }

        public abstract void Draw();

        public abstract bool IsAt(Point2D pt);


        public void Jump()
        {
            if (isJump)
            {
                if (jumpCount >= -10)
                {
                    neg = 1;

                    if (jumpCount < 0)
                    {
                        neg = -1;
                    }
                    _y -= Math.Pow(jumpCount, 2) * neg;
                    jumpCount -= 10;
                }
                else
                {
                    isJump = false;
                    jumpCount = 10;
                }
            }
        }

        public void Attack()
        {
        }

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


        public bool IsJump
        {
            get
            {
                return isJump;
            }
            set
            {
                isJump = value;
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

        public string State
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
