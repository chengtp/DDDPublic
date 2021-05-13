﻿using System.Threading.Tasks;
using DDD.Util.Cache.List.Response;

namespace DDD.Util.Cache.List.Request
{
    /// <summary>
    /// List right pop left push option
    /// </summary>
    public class ListRightPopLeftPushOption : CacheRequestOption<ListRightPopLeftPushResponse>
    {
        /// <summary>
        /// Gets or sets the source key
        /// </summary>
        public CacheKey SourceKey
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the destination key
        /// </summary>
        public CacheKey DestinationKey
        {
            get; set;
        }

        /// <summary>
        /// Execute cache operation
        /// </summary>
        /// <param name="cacheProvider">Cache provider</param>
        /// <param name="server">Cache server</param>
        /// <returns>Return right pop left push response</returns>
        protected override async Task<ListRightPopLeftPushResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.ListRightPopLeftPushAsync(server, this).ConfigureAwait(false);
        }
    }
}
