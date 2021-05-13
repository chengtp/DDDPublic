using System.Collections.Generic;

namespace DDD.Util.Data.Configuration
{
    /// <summary>
    /// Data configuration
    /// </summary>
    public class DataConfiguration
    {
        /// <summary>
        /// Gets or sets the server type configuration
        /// </summary>
        public Dictionary<DatabaseServerType, DatabaseServerConfiguration> Servers
        {
            get; set;
        }
    }
}
