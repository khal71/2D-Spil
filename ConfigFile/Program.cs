using System.Xml;

XmlDocument xml = new XmlDocument();
        xml.Load("ConFIGfile.xml");


        // Read World Configuration
        Console.WriteLine("World Configuration:");
        XmlNode? worldNode = xml.DocumentElement.SelectSingleNode("World");
        int maxX = int.Parse(worldNode.SelectSingleNode("MaxX").InnerText);
        int maxY = int.Parse(worldNode.SelectSingleNode("MaxY").InnerText);
        Console.WriteLine($"MaxX: {maxX}, MaxY: {maxY}");

        // Read Creature Configuration
        Console.WriteLine("\nCreature Configuration:");
        foreach (XmlNode creatureNode in xml.DocumentElement.SelectNodes("Creatures/Creature"))
        {
            string name = creatureNode.SelectSingleNode("Name").InnerText;
            int x = int.Parse(creatureNode.SelectSingleNode("X").InnerText);
            int y = int.Parse(creatureNode.SelectSingleNode("Y").InnerText);
            int hitPoints = int.Parse(creatureNode.SelectSingleNode("HitPoints").InnerText);
            Console.WriteLine($"Name: {name}, X: {x}, Y: {y}, HitPoints: {hitPoints}");
        }

        // Read Object Configuration
        Console.WriteLine("\nObject Configuration:");
        foreach (XmlNode objectNode in xml.DocumentElement.SelectNodes("Objects/*"))
        {
            string objectType = objectNode.Name;
            string name = objectNode.SelectSingleNode("Name").InnerText;
            int x = int.Parse(objectNode.SelectSingleNode("X").InnerText);
            int y = int.Parse(objectNode.SelectSingleNode("Y").InnerText);

            if (objectType == "AttackItem")
            {
                int range = int.Parse(objectNode.SelectSingleNode("Range").InnerText);
                Console.WriteLine($"Type: {objectType}, Name: {name}, X: {x}, Y: {y}, Range: {range}");
            }
            else if (objectType == "DefenseItem")
            {
                int defensePoints = int.Parse(objectNode.SelectSingleNode("DefensePoints").InnerText);
                Console.WriteLine($"Type: {objectType}, Name: {name}, X: {x}, Y: {y}, DefensePoints: {defensePoints}");
            }
        }

//XmlDocument xml = new XmlDocument();
//xml.Load("ConfigFile.xml");

//Console.WriteLine("Name");
//XmlNode? nameNode = xml.DocumentElement.SelectSingleNode("Name");
//if (nameNode is not null)
//{
//    string nameStr= nameNode .InnerText.Trim();
//    Console.WriteLine("Name:" + nameStr); 
//}
//Console.WriteLine("Number");
//XmlNode? numberNode = xml.DocumentElement.SelectSingleNode("Number");
//if(numberNode is not null)
//{
//    string numberStr= numberNode .InnerText.Trim();
//    int number = int.Parse(numberStr);
//    Console.WriteLine("Number:"+number);
//}




//// Create the service collection
//var services = new ServiceCollection();

//// Register Configuration class as singleton instance
//services.AddSingleton<Configuration>();

//// Build the service provider
//var serviceProvider = services.BuildServiceProvider();

//// Retrieve the Configuration instance
//var configuration = serviceProvider.GetRequiredService<Configuration>();

//var worldConfig = configuration._worldConfig;

//// Use the world configuration
//if (worldConfig is not null)
//{
//    // Do something with worldConfig
//}

