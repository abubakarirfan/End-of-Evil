namespace CombatGame
{
    public class StrategyMoveForward : IStrategy
    {
        private Player _bot;

        /// <summary>
        /// this is used to define StrategyMoveForward
        /// </summary>
        /// <param name="bot">player being controlled by the program</param>
        
        public StrategyMoveForward(Player bot)
        {
            _bot = bot;
        }

        /// <summary>
        /// this is used to move the bot player forward
        /// </summary>

        public void Execute()
        {
            if (_bot.X >= 10)
            {
                _bot.X -= 0.2;
            }
        }
    }
}
