using SplashKitSDK;

namespace CombatGame
{
    public class BlueKnight : Player
    {
        Sprite _sprite;
        Bitmap _bitmap;

        public BlueKnight(string name) : base(name)
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
                _bitmap = new Bitmap("die blue knight", "resources/img/blueknight/die.png");
            }
            else if (State == "attack")
            {
                _bitmap = new Bitmap("attack blue knight", "resources/img/blueknight/attack.png");
            }
            else if (State == "hurt")
            {
                _bitmap = new Bitmap("hurt blue knight", "resources/img/blueknight/hurt.png");
            }
            else if (State == "jump")
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

        public override Sprite Sprite
        {
            get
            {
                return _sprite;
            }
        }
    }
}
