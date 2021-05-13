using System.Collections.Generic;
using DDD.Util.Develop.Entity;

namespace DDD.Util.Data.Configuration
{
    /// <summary>
    /// Data entity configuration
    /// </summary>
    public class DataEntityConfiguration
    {
        #region Properties

        /// <summary>
        /// Gets or sets the table name
        /// </summary>
        public string TableName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the fields
        /// </summary>
        public List<EntityField> Fields
        {
            get; set;
        }

        #endregion
    }
}
