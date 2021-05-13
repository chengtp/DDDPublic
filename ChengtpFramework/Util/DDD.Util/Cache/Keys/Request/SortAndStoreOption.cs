﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Util.Cache.Keys.Response;

namespace DDD.Util.Cache.Keys.Request
{
    /// <summary>
    /// Sort and store option
    /// </summary>
    public class SortAndStoreOption : CacheRequestOption<SortAndStoreResponse>
    {
        /// <summary>
        /// Gets or sets the destination key
        /// </summary>
        public CacheKey DestinationKey
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the source key
        /// </summary>
        public CacheKey SourceKey
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets skip count
        /// </summary>
        public long Skip
        {
            get; set;
        } = 0;

        /// <summary>
        /// Gets or sets take count
        /// </summary>
        public long Take
        {
            get; set;
        } = -1;

        /// <summary>
        /// Gets or sets order type
        /// </summary>
        public SortedOrder Order
        {
            get; set;
        } = SortedOrder.Ascending;

        /// <summary>
        /// Gets or sets sort type
        /// </summary>
        public CacheSortType SortType
        {
            get; set;
        } = CacheSortType.Numeric;

        /// <summary>
        /// Gets or sets sort by value
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
        /// <returns>Return sort and store response</returns>
        protected override async Task<SortAndStoreResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.SortAndStoreAsync(server, this).ConfigureAwait(false);
        }
    }
}
