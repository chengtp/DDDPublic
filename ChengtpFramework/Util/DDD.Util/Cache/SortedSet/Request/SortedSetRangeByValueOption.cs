﻿using System.Threading.Tasks;
using DDD.Util.Cache.SortedSet.Response;

namespace DDD.Util.Cache.SortedSet.Request
{
    /// <summary>
    /// Sorted set range by value option
    /// </summary>
    public class SortedSetRangeByValueOption : CacheRequestOption<SortedSetRangeByValueResponse>
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
        /// Gets or sets the skip count
        /// </summary>
        public int Skip
        {
            get; set;
        } = 0;

        /// <summary>
        /// Gets or sets the take count
        /// </summary>
        public int Take
        {
            get; set;
        } = -1;

        /// <summary>
        /// Gets or sets the exclude count
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
        /// <returns>Return sorted set range by value response</returns>
        protected override async Task<SortedSetRangeByValueResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.SortedSetRangeByValueAsync(server, this).ConfigureAwait(false);
        }
    }
}
