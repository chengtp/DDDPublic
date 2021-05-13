﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Util.Cache.String.Response;

namespace DDD.Util.Cache.String.Request
{
    /// <summary>
    /// String bit operation option
    /// </summary>
    public class StringBitOperationOption : CacheRequestOption<StringBitOperationResponse>
    {
        /// <summary>
        /// Gets or sets the bit wise
        /// </summary>
        public CacheBitwise Bitwise
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the destination key for store
        /// </summary>
        public CacheKey DestinationKey
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the cache keys
        /// </summary>
        public List<CacheKey> Keys
        {
            get; set;
        }

        /// <summary>
        /// Execute cache operation
        /// </summary>
        /// <param name="cacheProvider">Cache provider</param>
        /// <param name="server">Cache server</param>
        /// <returns>Return string bit operation response</returns>
        protected override async Task<StringBitOperationResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.StringBitOperationAsync(server, this).ConfigureAwait(false);
        }
    }
}
