namespace CombatGame
{
    public class Context
    {
        private IStrategy _strategy;

        /// <summary>
        /// This is used to define context object
        /// </summary>

        public Context()
        {
        }

        /// <summary>
        /// This is used to set the strategy
        /// </summary>
        /// <param name="strategy">value to assign strategy</param>

        public void setStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        /// <summary>
        /// This is used to execute the strategy
        /// </summary>

        public void executeStrategy()
        {
            _strategy.Execute();
        }
    }
}
