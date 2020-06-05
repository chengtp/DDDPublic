using DDD.Develop.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Develop.CQuery
{
    /// <summary>
    /// query model entity
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class QueryEntityAttribute : Attribute
    {
        public QueryEntityAttribute(Type relevanceType)
        {
            EntityManager.ConfigEntity(relevanceType);
            RelevanceType = relevanceType;
        }

        /// <summary>
        /// relevance type
        /// </summary>
        public Type RelevanceType
        {
            get; set;
        }
    }
}
