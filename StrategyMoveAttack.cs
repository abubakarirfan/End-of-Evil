namespace CombatGame
{
    public class StrategyMoveAttack : IStrategy
    {
        private Player _bot;

        /// <summary>
        /// this is used to define StrategyMoveAttack
        /// </summary>
        /// <param name="bot">player being controlled by the program</param>

        public StrategyMoveAttack(Player bot)
        {
            _bot = bot;
        }

        /// <summary>
        /// this is used to unleash bot's attack
        /// </summary>

        public void Execute()
        {
            _bot.State = StatePlayer.ATTACK;
            _bot.Score.IncreaseScore();
        }
    }
}
