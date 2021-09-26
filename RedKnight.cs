using SplashKitSDK;

namespace CombatGame
{
    public class RedKnight : Player
    {
        Sprite _sprite;
        Bitmap _bitmap;

        public RedKnight(string name) : base(name)
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
                _bitmap = new Bitmap("die red knight", "resources/img/redknight/die.png");
            }
            else if (State == "attack")
            {
                _bitmap = new Bitmap("attack red knight", "resources/img/redknight/attack.png");
            }
            else if (State == "hurt")
            {
                _bitmap = new Bitmap("hurt red knight", "resources/img/redknight/hurt.png");
            }
            else if (State == "jump")
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

        public override Sprite Sprite
        {
            get
            {
                return _sprite;
            }
        }
    }
}
