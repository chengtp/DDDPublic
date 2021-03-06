﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Util.Cache.String.Response;

namespace DDD.Util.Cache.String.Request
{
    /// <summary>
    /// String set option
    /// </summary>
    public class StringSetOption : CacheRequestOption<StringSetResponse>
    {
        /// <summary>
        /// Gets or sets the data items
        /// </summary>
        public List<CacheEntry> Items
        {
            get; set;
        }

        /// <summary>
        /// Execute cache operation
        /// </summary>
        /// <param name="cacheProvider">Cache provider</param>
        /// <param name="server">Cache server</param>
        /// <returns>Return string set response</returns>
        protected override async Task<StringSetResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.StringSetAsync(server, this).ConfigureAwait(false);
        }
    }
}
