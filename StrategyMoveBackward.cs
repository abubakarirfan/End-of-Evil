namespace CombatGame
{
    public class StrategyMoveBackward : IStrategy
    {
        private Player _bot;

        /// <summary>
        /// this is used to define StrategyMoveBackward
        /// </summary>
        /// <param name="bot">player being controlled by the program</param>

        public StrategyMoveBackward(Player bot)
        {
            _bot = bot;
        }

        /// <summary>
        /// This is used to move the bot player backwards
        /// </summary>

        public void Execute()
        {
            if (_bot.X <= 650)
            {
                _bot.X += 0.2;
            }
        }
    }
}
