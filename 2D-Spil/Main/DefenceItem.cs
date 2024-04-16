namespace _2D_Spil.Main
{
    public class DefenceItem
    {
        public string Name { get; set; }
        public int ReduceHitPoint { get; set; }

        public DefenceItem(string name, int reduceHitPoint)
        {
            Name = name;
            ReduceHitPoint = reduceHitPoint;
        }
    }

}
