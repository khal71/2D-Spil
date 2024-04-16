using _2D_Spil.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Spil.Interface
{
    public interface ILinQtest
    {
        int GetCreatureDead(IEnumerable<Creature> creatureList);

        bool GetObjectsOutOfBound(IEnumerable<WorldObject> worldObjectsList, int x, int y);

    }
}
