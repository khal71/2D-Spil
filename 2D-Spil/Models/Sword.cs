using _2D_Spil.Interface;
using _2D_Spil.Logging;
using _2D_Spil.Main;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Spil.Models
{
    public class Sword : IWeaponItem
    {
        private AttackItem attackItem;
        private readonly GameLogger SwordLogger= GameLogger.Instance;
        public Sword(AttackItem attackItem)
        {
            this.attackItem = attackItem;
        }

        public void Attack()
        {
            SwordLogger.AddLoggerListener(SourceLevels.Information, TraceEventType.Information, 3, $"damge with an Axe {attackItem.Name}. Hit:{attackItem.Hit}. Range:{attackItem.Range}");
        }
    }
}
