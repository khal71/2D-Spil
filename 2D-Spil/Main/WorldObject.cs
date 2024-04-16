namespace _2D_Spil.Main
{
    public class WorldObject
    {


        public string Name { get; set; }
        public bool Lootable { get; set; }
        public bool Removeable { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public WorldObject(string name, bool lootable, bool removeable, int x, int y)
        {
            Name = name;
            Lootable = lootable;
            Removeable = removeable;
            X = x;
            Y = y;
        }

    }
}
