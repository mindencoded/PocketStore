using System;
using System.Collections.Generic;
using System.Text;
using Common.Logging;
using Common.Logging.Simple;

namespace SchoolExpress.WebService.Utils
{
    public class ColoredConsoleOutLogger : AbstractSimpleLogger
    {
        private static readonly Dictionary<LogLevel, ConsoleColor> Colors = new Dictionary<LogLevel, ConsoleColor>
        {
            {LogLevel.Fatal, ConsoleColor.Red},
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
        }
    }
}