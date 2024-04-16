using _2D_Spil.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Spil.Template
{
    public abstract class CreatureTemplate
    {

        /// <summary>
        /// Initiates a hit action for the creature.
        /// </summary>
        public void Hit()
        {
            int tohit = CalculateToHit();
            Receivehit(tohit); 
        }
        
        /// <summary>
        /// Initiates a loot action for the creature.
        /// </summary>
        /// <param name="worldObject">The WorldObject to be looted.</param>
        public void Loot(WorldObject worldObject)
        {
            Lootable(worldObject);
        }

        protected abstract int CalculateToHit();
        public abstract int Receivehit(int tohit);
        protected abstract void Lootable(WorldObject worldObject);
    }
}
