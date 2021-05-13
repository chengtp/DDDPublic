﻿using System.Threading.Tasks;
using DDD.Util.Cache.String.Response;

namespace DDD.Util.Cache.String.Request
{
    /// <summary>
    /// String get set option
    /// </summary>
    public class StringGetSetOption : CacheRequestOption<StringGetSetResponse>
    {
        /// <summary>
        /// Gets or sets the cache key
        /// </summary>
        public CacheKey Key
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the new value
        /// </summary>
        public string NewValue
        {
            get; set;
        }

        /// <summary>
        /// Execute cache operation
        /// </summary>
        /// <param name="cacheProvider">Cache provider</param>
        /// <param name="server">Cache server</param>
        /// <returns>Return string get set response</returns>
        protected override async Task<StringGetSetResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.StringGetSetAsync(server, this).ConfigureAwait(false);
        }
    }
}
