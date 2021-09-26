using SplashKitSDK;
using System;

namespace CombatGame
{
    public class Health
    {
        private double _health;

        public Health()
        {
            _health = 100;
        }

        public void IncreaseHealth()
        {
            _health += 0.2;
        }

        public void DecreaseHealth()
        {
            _health -= 0.005;
        }

        public int GetHealth
        {
            get
            {
                return (int)Math.Truncate(_health);
            }
        }

        public void Draw(double x, double y)
        {
            SplashKit.DrawText("Health: " + Math.Truncate(_health).ToString(), Color.White, x, y);
        }

    }
}
