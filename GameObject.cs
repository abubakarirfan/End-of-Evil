namespace CombatGame
{
    public abstract class GameObject
    {
        private string _name;

        public GameObject(string name)
        {
            _name = name;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }
    }
}
