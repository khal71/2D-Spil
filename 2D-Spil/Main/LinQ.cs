using _2D_Spil.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Spil.Main
{
    public class LinQ : ILinQtest
    {
        public int GetCreatureDead(IEnumerable<Creature> creatureList)
        {
            if (!creatureList.Any())
            {
                return 0;
            }
            return creatureList.Where(c => c.Health <= 0).Count();
        }

        public bool GetObjectsOutOfBound(IEnumerable<WorldObject> worldObjectsList, int x, int y)
        {
            if (!worldObjectsList.Any())
            {
                return false;
            }
            return worldObjectsList.Where(o => o.X < 0 || o.X > x || o.Y < 0 || o.Y > y).Any(); 
            
        }
    }
}
