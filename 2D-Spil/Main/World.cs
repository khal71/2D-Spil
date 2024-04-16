namespace _2D_Spil.Main
{
    public class World
    {
        private static World instance;
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        // add relation to Creatures class where one world have many Creatures 
        public List<Creature> Creatures { get; set; }
        // add relation to WorldObjects class where one world have many WorldObjects 
        public List<WorldObject> WorldObjects { get; set; }

        //private constructor to prevent instantiation from outside the class
        private World(int maxX, int maxY,List<Creature> creatures, List<WorldObject> worldObjects)
        {
            MaxX = maxX;
            MaxY = maxY;
            Creatures = creatures;
            WorldObjects=worldObjects;
        }
        public static World GetInstance(int maxX, int maxY, List<Creature> creatures,List<WorldObject>worldObjects)
        {
            if (instance is null)
            {
                instance = new World (maxX, maxY, creatures,worldObjects); 
            }
            return instance;
        }
    }
}