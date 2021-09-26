using SplashKitSDK;
using System;

namespace CombatGame
{
    public class Score
    {
        private double _score;

        public Score()
        {
            _score = 0;
        }

        public void IncreaseScore()
        {
            _score += 0.5;
        }

        public void DecreaseScore()
        {
            _score -= 0.5;
        }


        public void Draw(double x, double y)
        {
            SplashKit.DrawText("Score: " + Math.Truncate(_score).ToString(), Color.White, x, y);
        }


    }
}
