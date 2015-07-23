using System.Collections.Generic;
using System.Drawing;

namespace Hell1024.model
{
    public class Game
    {
        protected Game()
        {
            Core = new Core(5);
            Move = new Movement();
            Behave = new Behave(Move, Core);
            PositiveArea = new Rectangle(0, 0, Core.GameSize - 1, Core.GameSize - 1);
            NegativeArea = new Rectangle(Core.GameSize + 1, 0, Core.GameSize - 1, Core.GameSize - 1);
            DoorArea = new Rectangle(Core.GameSize, 0, 1, Core.GameSize);
            Door = new Door(Core, DoorArea, Move);
            Door.SetValue(-1, -1, 0, -1, -1);
            Door.Post();
            InitialParametrs = new Dictionary<List<long>, Rectangle>
            {
                {PositiveGenrate, PositiveArea},
                {NegativeGenrate, NegativeArea}
            };
        }
        static Game()
        {
            Instance = new Game();
        }
        static public Game Instance { get; private set; }
        public Core Core { get; set; }
        public Movement Move { get; set; }
        public Behave Behave { get; set; }
        public Door Door { get; set; }

        public List<long> PositiveGenrate = new List<long>() { 2, 4 };
        public List<long> NegativeGenrate = new List<long>() { -2, -4 };
        public Rectangle PositiveArea, NegativeArea, DoorArea;
        public Dictionary<List<long>, Rectangle> InitialParametrs;  

        public int NextToGenerate = 1;

        public void GenerateSingleSide()
        {
            switch (NextToGenerate)
            {
                case 1:
                    Behave.Generate(PositiveGenrate, PositiveArea);
                    break;
                case -1:
                    Behave.Generate(NegativeGenrate, NegativeArea);
                    break;
            }
            NextToGenerate *= -1;
        }

        public void GenerateBothSide()
        {
            Behave.Generate(PositiveGenrate, PositiveArea);
            Behave.Generate(NegativeGenrate, NegativeArea);
        }

        public void Generate()
        {
            if (Door.FitTarget(-1, -1, 0, -1, -1))
                GenerateBothSide();
            else GenerateSingleSide();
        }

        public void NewGame()
        {
            Behave.Clear(0);
            Behave.NewGame(InitialParametrs, 1);   
        }
    }
}