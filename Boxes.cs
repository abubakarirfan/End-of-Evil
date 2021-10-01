using SplashKitSDK;

namespace CombatGame
{
    public class Boxes : GameObject
    {
        private double _x, _y;
        private int _width, _height;
        Bitmap _bitmap;


        /// <summary>
        /// This is used to define the box object
        /// </summary>
        /// <param name="name">It is the name of the box</param>
        /// <param name="path">It is a path of the box image</param>
        /// <param name="x">It is the x coordinate for drawing</param>
        /// <param name="y">It is the y corrdinate for drawing</param>

        public Boxes(string name, string path, double x, double y) : base(name)
        {
            _x = x;
            _y = y;
            _bitmap = new Bitmap(name, path);
            _width = _bitmap.Width;
            _height = _bitmap.Height;
        }

        /// <summary>
        /// This is used to draw the box on the screen
        /// </summary>

        public void Draw()
        {
            SplashKit.DrawBitmap(_bitmap, _x, _y);
        }


        /// <summary>
        /// This is used to check if a current object is at position of the box
        /// </summary>
        /// <param name="pt">Position of the thing/object being checked</param>
        /// <returns>true if same position, false if not</returns>

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
