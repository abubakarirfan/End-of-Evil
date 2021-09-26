namespace CombatGame
{
    public class Context
    {
        private IStrategy strategy;

        public Context()
        {
        }

        public void setStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void executeStrategy()
        {
            strategy.Execute();
        }
    }
}
