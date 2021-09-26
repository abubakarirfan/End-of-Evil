using SplashKitSDK;

namespace CombatGame
{
    public class Robot : Player
    {
        Sprite _sprite;
        Bitmap _bitmap;

        public Robot(string name) : base(name)
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
                _bitmap = new Bitmap("die robot", "resources/img/robot/die.png");
            }
            else if (State == "attack")
            {
                _bitmap = new Bitmap("attack robot", "resources/img/robot/attack.png");
            }
            else if (State == "hurt")
            {
                _bitmap = new Bitmap("hurt robot", "resources/img/robot/hurt.png");
            }
            else if (State == "jump")
            {
                _bitmap = new Bitmap("jump robot", "resources/img/robot/jump.png");
            }
            else
            {
                _bitmap = new Bitmap("idle robot", "resources/img/robot/start.png");
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
