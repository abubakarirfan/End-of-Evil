using SplashKitSDK;

namespace CombatGame
{
    public class Boxes : GameObject
    {
        private string _name;
        private double _x, _y;
        private int _width, _height;
        Bitmap _bitmap;

        public Boxes(string name, string _path, double x, double y) : base(name)
        {
            _name = name;
            _x = x;
            _y = y;
            _bitmap = new Bitmap(_name, _path);
            _width = _bitmap.Width;
            _height = _bitmap.Height;
        }


        public void Draw()
        {
            SplashKit.DrawBitmap(_bitmap, _x, _y);
        }

        public bool IsAt(Point2D pt)
        {
            if (((pt.X >= _x) && (pt.X <= (_width + _x))) && ((pt.Y >= _y) && (pt.Y <= (_y + _height))))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
