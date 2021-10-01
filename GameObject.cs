namespace CombatGame
{
    public abstract class GameObject
    {
        private string _name;

        /// <summary>
        /// This is used to define the GameObject
        /// </summary>
        /// <param name="name">name of the gameobject</param>
        
        public GameObject(string name)
        {
            _name = name;
        }

        /// <summary>
        /// this propety is used to return the name of the object
        /// </summary>

        public string Name
        {
            get
            {
                return _name;
            }
        }
    }
}
