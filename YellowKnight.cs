using SplashKitSDK;

namespace CombatGame
{
    public class YellowKnight : Player
    {
        Sprite _sprite;
        Bitmap _bitmap;


        public YellowKnight(string name) : base(name)
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
                _bitmap = new Bitmap("die yellow knight", "resources/img/yellowknight/die.png");
            }
            else if (State == "attack")
            {
                _bitmap = new Bitmap("attack yellow knight", "resources/img/yellowknight/attack.png");
            }
            else if (State == "hurt")
            {
                _bitmap = new Bitmap("hurt yellow knight", "resources/img/yellowknight/hurt.png");
            }
            else if (State == "jump")
            {
                _bitmap = new Bitmap("jump yellow knight", "resources/img/yellowknight/jump.png");
            }
            else
            {
                _bitmap = new Bitmap("idle yellow knight", "resources/img/yellowknight/start.png");
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
