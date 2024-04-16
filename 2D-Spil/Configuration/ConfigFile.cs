using _2D_Spil.Logging;
using System.Diagnostics;
using System.Xml;

namespace _2D_Spil.Configuration
{
    public class ConfigFile
    {
        private XmlDocument _xmlDocument;
        private GameLogger _logger;

        public ConfigFile(string filePath, GameLogger logger)
        {
            _xmlDocument = new XmlDocument();
            _xmlDocument.Load(filePath);
            _logger = logger;
        }

        public (int maxX, int maxY) GetWorldConfiguration()
        {
            XmlNode? worldNode = _xmlDocument.DocumentElement.SelectSingleNode("World");
            int maxX = int.Parse(worldNode.SelectSingleNode("MaxX").InnerText);
            int maxY = int.Parse(worldNode.SelectSingleNode("MaxY").InnerText);
            return (maxX, maxY);
        }

        public void CreatureConfiguration()
        {
            _logger.AddLoggerListener(SourceLevels.Information, TraceEventType.Information, 5, "\nCreature Configuration:");
            foreach (XmlNode creatureNode in _xmlDocument.DocumentElement.SelectNodes("Creatures/Creature"))
            {
                string name = creatureNode.SelectSingleNode("Name").InnerText;
                int x = int.Parse(creatureNode.SelectSingleNode("X").InnerText);
                int y = int.Parse(creatureNode.SelectSingleNode("Y").InnerText);
                int hitPoints = int.Parse(creatureNode.SelectSingleNode("HitPoints").InnerText);
                _logger.AddLoggerListener(SourceLevels.Information, TraceEventType.Information, 6, $"Name: {name}, X: {x}, Y: {y}, HitPoints: {hitPoints}");
            }
        }
        public void ObjectConfiguration()
        {
            _logger.AddLoggerListener(SourceLevels.Information, TraceEventType.Information, 7, "\nObject Configuration:");
            foreach (XmlNode objectNode in _xmlDocument.DocumentElement.SelectNodes("Objects/*"))
            {
                string objectType = objectNode.Name;
                string name = objectNode.SelectSingleNode("Name").InnerText;
                int x = int.Parse(objectNode.SelectSingleNode("X").InnerText);
                int y = int.Parse(objectNode.SelectSingleNode("Y").InnerText);

                if (objectType == "AttackItem")
                {
                    int range = int.Parse(objectNode.SelectSingleNode("Range").InnerText);
                    _logger.AddLoggerListener(SourceLevels.Information, TraceEventType.Information, 8, $"Type: {objectType}, Name: {name}, X: {x}, Y: {y}, Range: {range}");
                }
                else if (objectType == "DefenseItem")
                {
                    int defensePoints = int.Parse(objectNode.SelectSingleNode("DefensePoints").InnerText);
                    _logger.AddLoggerListener(SourceLevels.Information, TraceEventType.Information, 9, $"Type: {objectType}, Name: {name}, X: {x}, Y: {y}, DefensePoints: {defensePoints}");
                }
            }
        }

    }
}
