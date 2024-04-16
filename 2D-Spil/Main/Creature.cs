using _2D_Spil.Logging;
using _2D_Spil.Template;
using System.Diagnostics;

namespace _2D_Spil.Main
{
    public class Creature : CreatureTemplate
    {
        private readonly GameLogger _Logger; 
        public string Name { get; set; }
        public int Health { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public List<AttackItem> AttackItems { get; set; }
        public List<DefenceItem> DefenceItems { get; set; }
        public List<WorldObject> LootObject { get; set; }

        public Creature(string name, int hitP, int x, int y, GameLogger logger )
        {
            Name = name;
            Health = hitP;
            X = x;
            Y = y;
            AttackItems = new List<AttackItem>();
            DefenceItems = new List<DefenceItem>();
            LootObject = new List<WorldObject>();
            _Logger = logger;
        }

        /// <summary>
        /// Calculates the total hit value for the current character's attack items.
        /// </summary>
        /// <returns>The total hit value calculated from all attack items.</returns>
        protected override int CalculateToHit()
        {
            int attack = AttackItems.Sum(AttackItems => AttackItems.Hit);
            return attack;
        }

        /// <summary>
        /// Reduces the health of the creature by the specified amount when hit, and logs the action.
        /// </summary>
        /// <param name="hit">The amount of damage received by the creature.</param>
        /// <returns>The remaining health points after deducting the damage.</returns>
        public override int Receivehit(int hit)
        {
            Health -= hit;
            if (Health <= 0)
            {
                _Logger.AddLoggerListener(SourceLevels.Information, TraceEventType.Information, 1, "Creature is defeted");
            }
            else
            {
              _Logger.AddLoggerListener(SourceLevels.Warning, TraceEventType.Warning, 2 , $"Creature '{Name}' received {Health} hit points of damage. Remaining hit points: {Health}");
            }
            return Health;
        }

        /// <summary>
        /// Overrides the Lootable behavior to add a WorldObject to the loot collection of the creature.
        /// </summary>
        /// <param name="obj">The WorldObject to be added to the loot collection.</param>
        protected override void Lootable(WorldObject obj)
        {
             LootObject.Add(obj);
            _Logger.AddLoggerListener(SourceLevels.Information, TraceEventType.Information, 3, $"Creature picked up the {obj.Name}");
        }
    }
}
