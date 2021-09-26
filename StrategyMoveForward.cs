namespace CombatGame
{
    public class StrategyMoveForward : IStrategy
    {
        private Player bot;

        public StrategyMoveForward(Player bot)
        {
            this.bot = bot;
        }

        public void Execute()
        {
            if (bot.X >= 10)
            {
                bot.X -= 0.2;
            }
        }
    }
}
