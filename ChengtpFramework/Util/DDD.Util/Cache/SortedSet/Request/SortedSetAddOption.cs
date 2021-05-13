﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Util.Cache.SortedSet.Response;

namespace DDD.Util.Cache.SortedSet.Request
{
    /// <summary>
    /// Sorted set add option
    /// </summary>
    public class SortedSetAddOption : CacheRequestOption<SortedSetAddResponse>
    {
        /// <summary>
        /// Gets or sets the cache key
        /// </summary>
        public CacheKey Key
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the members
        /// </summary>
        public List<SortedSetMember> Members
        {
            get; set;
        }

        /// <summary>
        /// Execute cache operation
        /// </summary>
        /// <param name="cacheProvider">Cache provider</param>
        /// <param name="server">Cache server</param>
        /// <returns>Return sorted set response</returns>
        protected override async Task<SortedSetAddResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.SortedSetAddAsync(server, this).ConfigureAwait(false);
        }
    }
}
