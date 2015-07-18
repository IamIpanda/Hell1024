namespace Hell1024.model
{
    public class Game
    {
        protected Game()
        {
            Core = new Core(5);
            Move = new Movement();
            Generate = new Movement();
            Behave = new Behave(Move, Core);
        }
        static Game()
        {
            Instance = new Game();
        }
        static public Game Instance { get; private set; }
        public Core Core { get; set; }
        public Movement Move { get; set; }
        public Movement Generate { get; set; }
        public Behave Behave { get; set; }
    }
}