using DDD.Util.Develop.CQuery.CriteriaConverter;

namespace DDD.Util.Data.CriteriaConverter
{
    /// <summary>
    /// Criteria converter parse option
    /// </summary>
    public class CriteriaConverterParseOption
    {
        /// <summary>
        /// Gets or sets the criteria converter
        /// </summary>
        public ICriteriaConverter CriteriaConverter { get; set; }

        /// <summary>
        /// Gets or sets the database server type
        /// </summary>
        public DatabaseServerType ServerType { get; set; }

        /// <summary>
        /// Gets or sets the object name
        /// </summary>
        public string ObjectName { get; set; }

        /// <summary>
        /// Gets or sets the field name
        /// </summary>
        public string FieldName { get; set; }
    }
}
