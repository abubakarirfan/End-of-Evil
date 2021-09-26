using SplashKitSDK;

namespace CombatGame
{
    public class Knight : Player
    {
        Sprite _sprite;
        Bitmap _bitmap;

        public Knight(string name) : base(name)
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
                _bitmap = new Bitmap("die knight", "resources/img/knight/die.png");
            }
            else if (State == "attack")
            {
                _bitmap = new Bitmap("attack knight", "resources/img/knight/attack.png");
            }
            else if (State == "hurt")
            {
                _bitmap = new Bitmap("hurt knight", "resources/img/knight/hurt.png");
            }
            else if (State == "jump")
            {
                _bitmap = new Bitmap("jump knight", "resources/img/knight/jump.png");
            }
            else
            {
                _bitmap = new Bitmap("idle knight", "resources/img/knight/start.png");
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
