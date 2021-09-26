namespace CombatGame
{
    public class StrategyMoveAttack : IStrategy
    {
        private Player bot;

        public StrategyMoveAttack(Player bot)
        {
            this.bot = bot;
        }

        public void Execute()
        {
            bot.State = "attack";
            bot.Score.IncreaseScore();
        }
    }
}
