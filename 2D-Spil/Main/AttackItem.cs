namespace _2D_Spil.Main
{
    public class AttackItem
    {
        public string Name { get; set; }
        public int Hit { get; set; }
        public int Range { get; set; }
        public AttackItem(string name, int hit, int range)
        {
            Name = name;
            Hit = hit;
            Range = range;
        }
    }
}
