using _2D_Spil.Configuration;
using _2D_Spil.Factory;
using _2D_Spil.Interface;
using _2D_Spil.Logging;
using _2D_Spil.Main;
using System.Diagnostics;






// here we are doing logging when runing the console app. 
GameLogger logger = GameLogger.Instance;

string filePath = "GameConfigFile.xml";
var config = new ConfigFile(filePath, logger);

var worldConfig = config.GetWorldConfiguration();
logger.AddLoggerListener(SourceLevels.Information, TraceEventType.Information, 4, $"World Config - MaxX: {worldConfig.maxX}, MaxY:{worldConfig.maxY}");
config.CreatureConfiguration();
config.ObjectConfiguration();


// world instance 
List<Creature> creatures = new List<Creature>();
List<WorldObject> objects = new List<WorldObject>();
var world = World.GetInstance(10, 10, creatures,objects); 





Console.WriteLine("---------------------------------------------------");
Creature creature = new Creature("Dragon", 100, 10, 10, logger);
creature.Hit();
int result = creature.Receivehit(100);
// if result is bigger then 0 that means the creature is a live then he can pick up the obj
if (result > 0)
{
    creature.Loot(new WorldObject("Treasure", true, true, 10, 10));
}
Console.WriteLine("---------------------------------------------------");


//Weapon Factory
AttackItem swordItem = new AttackItem("GhostSword", 20, 6);
AttackItem bowItem = new AttackItem("Achilles", 15,20);
AttackItem AxeItem = new AttackItem("Axe of godrick",30,5);
//make the weapons
WeaponsFactory weaponsFactory = new WeaponsFactory();

// make the types
IWeaponItem sword = weaponsFactory.CreateWeapon("sword", swordItem);
IWeaponItem bow = weaponsFactory.CreateWeapon("bow", bowItem);
IWeaponItem axe = weaponsFactory.CreateWeapon("axe", AxeItem);

sword.Attack();
bow.Attack();
axe.Attack();

Creature demon1 = new Creature("jj", 0, 4, 5, null);
Creature demon2 = new Creature("kk", 8, 4, 5, null);
creatures.Add(demon2);
creatures.Add(demon1);  

WorldObject treasure = new WorldObject("gold",true,true,11,5);
WorldObject treasure2 = new WorldObject("silver", true, true, 4, 5);
objects.Add(treasure);
objects.Add(treasure2);
LinQ linq = new LinQ();
var result1 = linq.GetCreatureDead(creatures);
Console.WriteLine(result1);
var result2 = linq.GetObjectsOutOfBound(objects,world.MaxX,world.MaxY);
Console.WriteLine(result2);








