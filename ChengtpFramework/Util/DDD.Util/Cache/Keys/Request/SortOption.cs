﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Util.Cache.Keys.Response;

namespace DDD.Util.Cache.Keys.Request
{
    /// <summary>
    /// Sort option
    /// </summary>
    public class SortOption : CacheRequestOption<SortResponse>
    {
        /// <summary>
        /// Gets or sets the cache key
        /// </summary>
        public CacheKey Key
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the skip count
        /// </summary>
        public long Skip
        {
            get; set;
        } = 0;

        /// <summary>
        /// Gets or sets the take count
        /// </summary>
        public long Take
        {
            get; set;
        } = -1;

        /// <summary>
        /// Gets or sets order
        /// </summary>
        public SortedOrder Order
        {
            get; set;
        } = SortedOrder.Ascending;

        /// <summary>
        /// Gets or sets the sort type
        /// </summary>
        public CacheSortType SortType
        {
            get; set;
        } = CacheSortType.Numeric;

        /// <summary>
        /// Gets or sets the sort by value
        /// </summary>
        public string By
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the get values
        /// </summary>
        public List<string> Gets
        {
            get; set;
        }

        /// <summary>
        /// Execute cache operation
        /// </summary>
        /// <param name="cacheProvider">Cache provider</param>
        /// <param name="server">Cache server</param>
        /// <returns>Return sort response</returns>
        protected override async Task<SortResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.SortAsync(server, this).ConfigureAwait(false);
        }
    }
}
