using SplashKitSDK;

namespace CombatGame
{
    public class Troll : Player
    {
        Sprite _sprite;
        Bitmap _bitmap;

        /// <summary>
        /// This is the constructor. It is used to define the player
        /// </summary>
        /// <param name="name">Stores the name of the player</param>

        public Troll(string name) : base(name)
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
            if (State == "die")
            {
                _bitmap = new Bitmap("troll die", "resources/img/troll/die.png");
            }
            else if (State == "attack")
            {
                _bitmap = new Bitmap("troll attack", "resources/img/troll/attack.png");
            }
            else if (State == "hurt")
            {
                _bitmap = new Bitmap("hurt troll", "resources/img/troll/hurt.png");
            }
            else if (State == "jump")
            {
                _bitmap = new Bitmap("attack troll", "resources/img/troll/jump.png");
            }
            else
            {
                _bitmap = new Bitmap("troll idle", "resources/img/troll/start.png");
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
