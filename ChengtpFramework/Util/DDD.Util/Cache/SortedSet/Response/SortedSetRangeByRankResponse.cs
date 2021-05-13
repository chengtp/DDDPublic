﻿using System.Collections.Generic;

namespace DDD.Util.Cache.SortedSet.Response
{
    /// <summary>
    /// Sorted set range by rank response
    /// </summary>
    public class SortedSetRangeByRankResponse : CacheResponse
    {
        /// <summary>
        /// Gets or sets the members
        /// </summary>
        public List<string> Members
        {
            get; set;
        }
    }
}
