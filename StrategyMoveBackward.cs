namespace CombatGame
{
    public class StrategyMoveBackward : IStrategy
    {
        private Player bot;

        public StrategyMoveBackward(Player bot)
        {
            this.bot = bot;
        }

        public void Execute()
        {
            if (bot.X <= 650)
            {
                bot.X += 0.2;
            }
        }
    }
}
