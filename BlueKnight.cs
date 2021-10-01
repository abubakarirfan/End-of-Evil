using SplashKitSDK;

namespace CombatGame
{
    public class BlueKnight : Player
    {
        Sprite _sprite;
        Bitmap _bitmap;

        /// <summary>
        /// This is the constructor. It is used to define the player
        /// </summary>
        /// <param name="name">Stores the name of the player</param>

        public BlueKnight(string name) : base(name)
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
                _bitmap = new Bitmap("die blue knight", "resources/img/blueknight/die.png");
            }
            else if (State == StatePlayer.ATTACK)
            {
                _bitmap = new Bitmap("attack blue knight", "resources/img/blueknight/attack.png");
            }
            else if (State == StatePlayer.HURT)
            {
                _bitmap = new Bitmap("hurt blue knight", "resources/img/blueknight/hurt.png");
            }
            else if (State == StatePlayer.JUMP)
            {
                _bitmap = new Bitmap("jump blue knight", "resources/img/blueknight/jump.png");
            }
            else
            {
                _bitmap = new Bitmap("idle blue knight", "resources/img/blueknight/start.png");
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
