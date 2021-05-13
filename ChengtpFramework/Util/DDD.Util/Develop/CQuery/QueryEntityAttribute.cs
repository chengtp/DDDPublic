using System;
using DDD.Util.Develop.Entity;

namespace DDD.Util.Develop.CQuery
{
    /// <summary>
    /// Query model entity
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class QueryEntityAttribute : Attribute
    {
        public QueryEntityAttribute(Type relevanceType)
        {
            EntityManager.ConfigureEntity(relevanceType);
            RelevanceType = relevanceType;
        }

        /// <summary>
        /// Gets or sets the relevance type
        /// </summary>
        public Type RelevanceType
        {
            get; set;
        }
    }
}
