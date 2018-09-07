using System;
using Common.Logging;
using Common.Logging.Configuration;
using Common.Logging.Simple;

namespace SchoolExpress.WebService.Utils
{
    /// <summary>
    /// Factory for creating <see cref="ILog" /> instances that write data to <see cref="Console.Out" />.
    /// </summary>
    /// <remarks>
    /// <example>
    /// Below is an example how to configure this adapter:
    /// <code>
    /// <configuration>
    ///   <configSections>
    ///     <sectionGroup name="common">
    ///       <section name="logging"
    ///                type="Common.Logging.ConfigurationSectionHandler, Common.Logging"
    ///                requirePermission="false" />
    ///     </sectionGroup>
    ///   </configSections>
    /// 
    ///   <common>
    ///     <logging>
    ///       <factoryAdapter type="SchoolExpress.WebService.Utils.ColoredConsoleOutLoggerFactoryAdapter, SchoolExpress.WebService">
    ///         <arg key="level" value="ALL" />
    ///       </factoryAdapter>
    ///     </logging>
    ///   </common>
    /// 
    /// </configuration>
    /// </code>
    /// </example>
    /// </remarks>
    /// <seealso cref="AbstractSimpleLoggerFactoryAdapter"/>
    /// <seealso cref="LogManager.Adapter"/>
    /// <seealso cref="ConfigurationSectionHandler"/>
    /// <author>Gilles Bayon</author>
    /// <author>Mark Pollack</author>
    /// <author>Erich Eichinger</author>
    public class ColoredConsoleOutLoggerFactoryAdapter : AbstractSimpleLoggerFactoryAdapter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleOutLoggerFactoryAdapter"/> class using default 
        /// settings.
        /// </summary>
        public ColoredConsoleOutLoggerFactoryAdapter()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColoredConsoleOutLoggerFactoryAdapter"/> class.
        /// </summary>
        /// <remarks>
        /// Looks for level, showDateTime, showLogName, dateTimeFormat items from 
        /// <paramref name="properties" /> for use when the GetLogger methods are called.
        /// <see cref="ConfigurationSectionHandler"/> for more information on how to use the 
        /// standard .NET application configuraiton file (App.config/Web.config) 
        /// to configure this adapter.
        /// </remarks>
        /// <param name="properties">The name value collection, typically specified by the user in 
        /// a configuration section named common/logging.</param>
        public ColoredConsoleOutLoggerFactoryAdapter(NameValueCollection properties)
            : base(properties)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractSimpleLoggerFactoryAdapter"/> class with 
        /// default settings for the loggers created by this factory.
        /// </summary>
        public ColoredConsoleOutLoggerFactoryAdapter(LogLevel level, bool showDateTime, bool showLogName,
            bool showLevel, string dateTimeFormat)
            : base(level, showDateTime, showLogName, showLevel, dateTimeFormat)
        {
        }

        /// <summary>
        /// Creates a new <see cref="ColoredConsoleOutLogger"/> instance.
        /// </summary>
        protected override ILog CreateLogger(string name, LogLevel level, bool showLevel, bool showDateTime,
            bool showLogName, string dateTimeFormat)
        {
            ILog log = new ColoredConsoleOutLogger(name, level, showLevel, showDateTime, showLogName, dateTimeFormat);
            return log;
        }
    }
}