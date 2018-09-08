using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace SchoolExpress.WebService.Utils
{

    public class ColorConsoleTraceListener : ConsoleTraceListener
    {   
        private static readonly IReadOnlyDictionary<TraceEventType, ConsoleColor> Colors;

        static ColorConsoleTraceListener()
        {
            Colors = new Dictionary<TraceEventType, ConsoleColor>
            {
                {TraceEventType.Verbose, ConsoleColor.Green},
                {TraceEventType.Information, ConsoleColor.Cyan},
                {TraceEventType.Warning, ConsoleColor.Yellow},
                {TraceEventType.Error, ConsoleColor.Red},
                {TraceEventType.Critical, ConsoleColor.DarkRed},
                {TraceEventType.Start, ConsoleColor.Gray},
                {TraceEventType.Stop, ConsoleColor.Gray},
                {TraceEventType.Suspend, ConsoleColor.Gray},
                {TraceEventType.Resume, ConsoleColor.Gray},
                {TraceEventType.Transfer, ConsoleColor.Gray}
            };
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
        {
            if (Filter != null && !Filter.ShouldTrace(eventCache, source, eventType, id, message, null, null, null))
                return;

            Trace(source, eventType, id, message);
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string format, params object[] args)
        {
            if (Filter != null && !Filter.ShouldTrace(eventCache, source, eventType, id, format, args, null, null))
                return;
            Trace(source, eventType, id, string.Format(CultureInfo.InvariantCulture, format, args));
        }

        void Trace(string source, TraceEventType eventType, int id, string message)
        {
            ConsoleColor? previousColor;
            ConsoleColor color;

            if (Colors.TryGetValue(eventType, out color))
            {
                previousColor = Console.ForegroundColor;
                Console.ForegroundColor = color;
            }
            else
            {
                previousColor = null;
            }

            WriteLine(source + " " + eventType + ": " + id + " : " + message);

            if (previousColor.HasValue)
            {
                Console.ForegroundColor = previousColor.Value;
            }
        }
    }
}
