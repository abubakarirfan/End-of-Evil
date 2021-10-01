using SplashKitSDK;
using System;

namespace CombatGame
{
    public class Score
    {
        private double _score;

        /// <summary>
        /// This is used to define/declare Score
        /// </summary>
        
        public Score()
        {
            _score = 0;
        }

        /// <summary>
        /// this is used to increase the score
        /// </summary>

        public void IncreaseScore()
        {
            _score += 0.5;
        }

        /// <summary>
        /// this is used to decrease the score
        /// </summary>

        public void DecreaseScore()
        {
            _score -= 0.5;
        }

        /// <summary>
        /// this is used to draw the score
        /// </summary>
        /// <param name="x">x coordinate of where to draw</param>
        /// <param name="y">y coordinate of where to draw</param>

        public void Draw(double x, double y)
        {
            SplashKit.DrawText("Score: " + Math.Truncate(_score).ToString(), Color.White, x, y);
        }


    }
}
