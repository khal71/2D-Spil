using System.Diagnostics;

namespace _2D_Spil.Logging
{
    /// <summary>
    /// Represents a singleton logger for the game.
    /// </summary>
    public class GameLogger
    {
        private static TraceSource tracer;
       
        /// <summary>
        /// The single instance of the GameLogger.
        /// </summary>
        private static GameLogger instance = new GameLogger();

        /// <summary>
        /// Gets the single instance of the GameLogger.
        /// </summary>
        /// <returns>The single instance of the GameLogger.</returns>
        public static GameLogger Instance
        {
            // Getter for the Instance property.
            get
            {
                // If there is already an instance of GameLogger, return it.
                // Otherwise, create a new instance and return it.
                return instance;
            }
        }
        private GameLogger()
        {
            //Directory called Logs 
            string logDirectory = "Logs";

            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            // To be saved in txt file 
            string logFilePath = Path.Combine(logDirectory, "GameLog.txt");

            tracer = new TraceSource("GameSource");
            tracer.Switch = new SourceSwitch("First log", "All");


            TraceListener fileListener = new TextWriterTraceListener(
                new StreamWriter(logFilePath, append: true) { AutoFlush = true });
            tracer.Listeners.Add(fileListener);

            // Add a ConsoleTraceListener for logging to the console
            TraceListener consoleListener = new ConsoleTraceListener();
            tracer.Listeners.Add(consoleListener);
        }
        // TO log the informations when GameLogger is being called/instans in other classes. 
        public void AddLoggerListener(SourceLevels type, TraceEventType eventType, int eventId, string message)
        {
            // Log the message with the specified type and event type
            tracer.TraceEvent(eventType, eventId, message);
        }
    }
}
