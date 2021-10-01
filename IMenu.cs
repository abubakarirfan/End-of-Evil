namespace CombatGame
{
    public interface IMenu
    {
     
        public void Execute();

        public int CheckState
        {
            get;
            set;
        }
    }
}
