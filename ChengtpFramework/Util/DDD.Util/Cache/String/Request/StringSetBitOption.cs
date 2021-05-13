﻿using System.Threading.Tasks;
using DDD.Util.Cache.String.Response;

namespace DDD.Util.Cache.String.Request
{
    /// <summary>
    /// String set bit option
    /// </summary>
    public class StringSetBitOption : CacheRequestOption<StringSetBitResponse>
    {
        /// <summary>
        /// Gets or sets the cache key
        /// </summary>
        public CacheKey Key
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the offset
        /// </summary>
        public long Offset
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets whether set bit value
        /// </summary>
        public bool Bit
        {
            get; set;
        }

        /// <summary>
        /// Execute cache operation
        /// </summary>
        /// <param name="cacheProvider">Cache provider</param>
        /// <param name="server">Cache server</param>
        /// <returns>Return string bit response</returns>
        protected override async Task<StringSetBitResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.StringSetBitAsync(server, this).ConfigureAwait(false);
        }
    }
}
