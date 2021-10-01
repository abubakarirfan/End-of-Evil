using SplashKitSDK;
using System;

namespace CombatGame
{
    public class Health
    {
        private double _health;

        /// <summary>
        /// THis is used to define health
        /// </summary>
        
        public Health()
        {
            _health = 100;
        }

        /// <summary>
        /// This is used to increase the health 
        /// </summary>

        public void IncreaseHealth()
        {
            _health += 0.2;
        }

        /// <summary>
        /// This is used to decrease the health
        /// </summary>

        public void DecreaseHealth()
        {
            _health -= 0.005;
        }

        /// <summary>
        /// This is used to return the health
        /// </summary>

        public int GetHealth
        {
            get
            {
                return (int)Math.Truncate(_health);
            }
        }

        /// <summary>
        /// this is used to draw the health
        /// </summary>
        /// <param name="x">x coordinate where to draw</param>
        /// <param name="y">y corrdinate where to draw</param>

        public void Draw(double x, double y)
        {
            SplashKit.DrawText("Health: " + Math.Truncate(_health).ToString(), Color.White, x, y);
        }

    }
}
