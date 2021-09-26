using SplashKitSDK;

namespace CombatGame
{
    public class King : Player
    {

        Sprite _sprite;
        Bitmap _bitmap;

        public King(string name) : base(name)
        {
        }

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


        public override void Draw()
        {
            if (State == "die")
            {
                _bitmap = new Bitmap("die king", "resources/img/king/die.png");
            }
            else if (State == "attack")
            {
                _bitmap = new Bitmap("attack king", "resources/img/king/attack.png");
            }
            else if (State == "hurt")
            {
                _bitmap = new Bitmap("hurt king", "resources/img/king/hurt.png");
            }
            else if (State == "jump")
            {
                _bitmap = new Bitmap("jump king", "resources/img/king/jump.png");
            }
            else
            {
                _bitmap = new Bitmap("idle king", "resources/img/king/start.png");
            }

            _sprite = SplashKit.CreateSprite(_bitmap);
            SplashKit.DrawSprite(_sprite, X, Y);
        }

        public override Sprite Sprite
        {
            get
            {
                return _sprite;
            }
        }
    }
}
