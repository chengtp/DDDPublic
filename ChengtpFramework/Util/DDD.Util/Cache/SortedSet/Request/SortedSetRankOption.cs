﻿using System.Threading.Tasks;
using DDD.Util.Cache.SortedSet.Response;

namespace DDD.Util.Cache.SortedSet.Request
{
    /// <summary>
    /// Sorted set rank option
    /// </summary>
    public class SortedSetRankOption : CacheRequestOption<SortedSetRankResponse>
    {
        /// <summary>
        /// Gets or sets the cache key
        /// </summary>
        public CacheKey Key
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the member
        /// </summary>
        public string Member
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the order type
        /// </summary>
        public SortedOrder Order
        {
            get; set;
        } = SortedOrder.Ascending;

        /// <summary>
        /// Execute cache operation
        /// </summary>
        /// <param name="cacheProvider">Cache provider</param>
        /// <param name="server">Cache server</param>
        /// <returns>Return sorted set rank response</returns>
        protected override async Task<SortedSetRankResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.SortedSetRankAsync(server, this).ConfigureAwait(false);
        }
    }
}
