using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Common.Logging;
using Common.Logging.Simple;

namespace SchoolExpress.WebService.Utils
{
    public class ColoredConsoleOutLogger : AbstractSimpleLogger
    {
        private TraceSource _traceSource;
        private static readonly Dictionary<LogLevel, ConsoleColor> Colors = new Dictionary<LogLevel, ConsoleColor>
        {
            {LogLevel.Fatal, ConsoleColor.DarkRed},
            {LogLevel.Error, ConsoleColor.Red},
            {LogLevel.Warn, ConsoleColor.Yellow},
            {LogLevel.Info, ConsoleColor.Cyan},
            {LogLevel.Debug, ConsoleColor.Green},
            {LogLevel.Trace, ConsoleColor.White},
        };


        /// <summary>
        /// Creates and initializes a logger that writes messages to <see cref="Console.Out" />.
        /// </summary>
        /// <param name="logName">The name, usually type name of the calling class, of the logger.</param>
        /// <param name="logLevel">The current logging threshold. Messages recieved that are beneath this threshold will not be logged.</param>
        /// <param name="showLevel">Include the current log level in the log message.</param>
        /// <param name="showDateTime">Include the current time in the log message.</param>
        /// <param name="showLogName">Include the instance name in the log message.</param>
        /// <param name="dateTimeFormat">The date and time format to use in the log message.</param>
        public ColoredConsoleOutLogger(string logName, LogLevel logLevel, bool showLevel, bool showDateTime,
            bool showLogName, string dateTimeFormat)
            : base(logName, logLevel, showLevel, showDateTime, showLogName, dateTimeFormat)
        {
        }

        /// <summary>
        /// Creates a new TraceLogger instance.
        /// </summary>
        /// <param name="useTraceSource">whether to use <see cref="TraceSource"/> or <see cref="Trace"/> for logging.</param>
        /// <param name="logName">the name of this logger</param>
        /// <param name="logLevel">the default log level to use</param>
        /// <param name="showLevel">Include the current log level in the log message.</param>
        /// <param name="showDateTime">Include the current time in the log message.</param>
        /// <param name="showLogName">Include the instance name in the log message.</param>
        /// <param name="dateTimeFormat">The date and time format to use in the log message.</param>
        public ColoredConsoleOutLogger(bool useTraceSource, string logName, LogLevel logLevel, bool showLevel, bool showDateTime, bool showLogName, string dateTimeFormat)
            : base(logName, logLevel, showLevel, showDateTime, showLogName, dateTimeFormat)
        {
            if (useTraceSource)
            {
                _traceSource = new TraceSource(logName, Map2SourceLevel(logLevel));
            }
        }

        /// <summary>
        /// Do the actual logging by constructing the log message using a <see cref="StringBuilder" /> then
        /// sending the output to <see cref="Console.Out" />.
        /// </summary>
        /// <param name="level">The <see cref="LogLevel" /> of the message.</param>
        /// <param name="message">The log message.</param>
        /// <param name="e">An optional <see cref="Exception" /> associated with the message.</param>
        protected override void WriteInternal(LogLevel level, object message, Exception e)
        {
            // Use a StringBuilder for better performance
            StringBuilder sb = new StringBuilder();

            FormatOutput(sb, level, message, e);

            // Print to the appropriate destination
            ConsoleColor color;

            if (Colors.TryGetValue(level, out color))
            {
                ConsoleColor originalForegroundColor = Console.ForegroundColor;
                try
                {
                    Console.ForegroundColor = color;
                    Console.Out.WriteLine(sb.ToString());
                }
                finally
                {
                    Console.ForegroundColor = originalForegroundColor;
                }
            }

            if (_traceSource != null)
            {
                _traceSource.TraceEvent(Map2TraceEventType(level), 0, "{0}", message);
            }
        }

        private SourceLevels Map2SourceLevel(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.All:
                case LogLevel.Trace:
                    return SourceLevels.All;
                case LogLevel.Debug:
                    return SourceLevels.Verbose;
                case LogLevel.Info:
                    return SourceLevels.Information;
                case LogLevel.Warn:
                    return SourceLevels.Warning;
                case LogLevel.Error:
                    return SourceLevels.Error;
                case LogLevel.Fatal:
                    return SourceLevels.Critical;
                default:
                    return SourceLevels.Off;
            }
        }

        private TraceEventType Map2TraceEventType(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:
                    return TraceEventType.Verbose;
                case LogLevel.Debug:
                    return TraceEventType.Verbose;
                case LogLevel.Info:
                    return TraceEventType.Information;
                case LogLevel.Warn:
                    return TraceEventType.Warning;
                case LogLevel.Error:
                    return TraceEventType.Error;
                case LogLevel.Fatal:
                    return TraceEventType.Critical;
                default:
                    return 0;
            }
        }
    }
}