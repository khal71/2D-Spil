using _2D_Spil.Interface;
using _2D_Spil.Logging;
using _2D_Spil.Main;
using _2D_Spil.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Spil.Factory
{
    public class WeaponsFactory
    {
        private readonly GameLogger _weaponslog = GameLogger.Instance;
        public IWeaponItem CreateWeapon(string weapontype, AttackItem attackItem)
        {
            _weaponslog.AddLoggerListener(SourceLevels.Information, TraceEventType.Information, 6, $"Creating {weapontype} with {attackItem.Name}. Hit: {attackItem.Hit}, Range: {attackItem.Range}");
            switch (weapontype.ToLower())
            {
                case "sword":
                    return new Sword(attackItem);
                case "bow":
                    return new Bow(attackItem);
                case "axe":
                    return new Axe(attackItem);

                default: return null;
            }
        }

    }
}
