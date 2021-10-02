using SplashKitSDK;

namespace CombatGame
{
    public class RedKnight : Player
    {
        Sprite _sprite;
        Bitmap _bitmap;

        /// <summary>
        /// THis is used to define the redknight object
        /// </summary>
        /// <param name="name">name of the player</param>

        public RedKnight(string name) : base(name)
        {
        }

        /// <summary>
        /// This is used to check the position of the player
        /// </summary>
        /// <param name="pt">This is the coordinate being checked against</param>
        /// <returns>true if player is at the position, otherwise false</returns>

        public override bool IsAt(Point2D pt)
        {
            if (((pt.X >= X) && (pt.X <= (_sprite.Width + X))) && ((pt.Y >= Y) && (pt.Y <= (Y + _sprite.Height))))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This is a method used to assign value to bitmap and draw it
        /// </summary>

        public override void Draw()
        {
            if (State == StatePlayer.DIE)
            {
                _bitmap = new Bitmap("die red knight", "resources/img/redknight/die.png");
            }
            else if (State == StatePlayer.ATTACK)
            {
                _bitmap = new Bitmap("attack red knight", "resources/img/redknight/attack.png");
            }
            else if (State == StatePlayer.HURT)
            {
                _bitmap = new Bitmap("hurt red knight", "resources/img/redknight/hurt.png");
            }
            else if (State == StatePlayer.JUMP)
            {
                _bitmap = new Bitmap("jump red knight", "resources/img/redknight/jump.png");
            }
            else
            {
                _bitmap = new Bitmap("idle red knight", "resources/img/redknight/start.png");
            }

            _sprite = SplashKit.CreateSprite(_bitmap);
            SplashKit.DrawSprite(_sprite, X, Y);
        }

        /// <summary>
        /// This is a property used to return current sprite
        /// </summary>

        public override Sprite Sprite
        {
            get
            {
                return _sprite;
            }
        }
    }
}
