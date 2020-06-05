﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Develop.CQuery
{
    /// <summary>
    /// global condition filter
    /// </summary>
    public class GlobalConditionFilter
    {
        /// <summary>
        /// entity type
        /// </summary>
        public Type EntityType
        {
            get; set;
        }

        /// <summary>
        /// usage scene entity type
        /// </summary>
        public Type UsageSceneEntityType
        {
            get; set;
        }

        /// <summary>
        /// original query
        /// </summary>
        public IQuery OriginalQuery
        {
            get; set;
        }

        /// <summary>
        /// query source type
        /// </summary>
        public QuerySourceType SourceType
        {
            get; set;
        }

        /// <summary>
        /// query usage scene
        /// </summary>
        public QueryUsageScene UsageScene
        {
            get; set;
        }
    }
}
