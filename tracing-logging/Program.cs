// See https://aka.ms/new-console-template for more information
using System.Diagnostics;


TraceSource trace = new TraceSource("EtNavn");
trace.Switch = new SourceSwitch("Game log", "All");

TraceListener consoleListener = new ConsoleTraceListener();
trace.Listeners.Add(consoleListener);
consoleListener.Filter = new EventTypeFilter(SourceLevels.Error);   

TraceListener fileListener = new TextWriterTraceListener(
    new StreamWriter("traceDemo.txt"));
trace.Listeners.Add(fileListener);

TraceListener xmlListener = new XmlWriterTraceListener(
    new StreamWriter("traceDemo.xml") { AutoFlush = true });
trace.Listeners.Add(xmlListener);



TraceListener eventListener = new EventLogTraceListener("Application");
trace.Listeners.Add(eventListener);



trace.TraceEvent(TraceEventType.Information,23,"Information");
trace.TraceEvent(TraceEventType.Warning, 23, "Warning");
trace.TraceEvent(TraceEventType.Error, 23, "Error");
trace.TraceEvent(TraceEventType.Critical,23,"Critical");


consoleListener.Filter=new EventTypeFilter(SourceLevels.Information);
trace.TraceEvent(TraceEventType.Information, 23, "Information");
//trace.Flush();
