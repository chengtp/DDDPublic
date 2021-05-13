﻿using System.Threading.Tasks;
using DDD.Util.Cache.String.Response;

namespace DDD.Util.Cache.String.Request
{
    /// <summary>
    /// String set range option
    /// </summary>
    public class StringSetRangeOption : CacheRequestOption<StringSetRangeResponse>
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
        public int Offset
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public string Value
        {
            get; set;
        }

        /// <summary>
        /// Execute cache operation
        /// </summary>
        /// <param name="cacheProvider">Cache provider</param>
        /// <param name="server">Cache server</param>
        /// <returns>Return string range response</returns>
        protected override async Task<StringSetRangeResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.StringSetRangeAsync(server, this).ConfigureAwait(false);
        }
    }
}
