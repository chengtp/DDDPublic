using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Data.Config
{
    /// <summary>
    /// db engine config
    /// </summary>
    public class DataConfig
    {
        /// <summary>
        /// server type config
        /// </summary>
        public Dictionary<ServerType, ServerTypeConfig> Servers
        {
            get;set;
        }
    }
}
