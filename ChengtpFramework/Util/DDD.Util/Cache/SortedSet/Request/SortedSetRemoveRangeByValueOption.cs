﻿using System.Threading.Tasks;
using DDD.Util.Cache.SortedSet.Response;

namespace DDD.Util.Cache.SortedSet.Request
{
    /// <summary>
    /// Sorted set remove range by value option
    /// </summary>
    public class SortedSetRemoveRangeByValueOption : CacheRequestOption<SortedSetRemoveRangeByValueResponse>
    {
        /// <summary>
        /// Gets or sets the cache key
        /// </summary>
        public CacheKey Key
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the min value
        /// </summary>
        public decimal MinValue
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the max value
        /// </summary>
        public decimal MaxValue
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the exclude type
        /// </summary>
        public SortedSetExclude Exclude
        {
            get; set;
        } = SortedSetExclude.None;

        /// <summary>
        /// Execute cache operation
        /// </summary>
        /// <param name="cacheProvider">Cache provider</param>
        /// <param name="server">Cache server</param>
        /// <returns>Return sorted set remove range by value response</returns>
        protected override async Task<SortedSetRemoveRangeByValueResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.SortedSetRemoveRangeByValueAsync(server, this).ConfigureAwait(false);
        }
    }
}
