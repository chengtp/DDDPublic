using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Util.Cache.Keys.Response;

namespace DDD.Util.Cache.Keys.Request
{
    /// <summary>
    /// Exists key option
    /// </summary>
    public class ExistsOption : CacheRequestOption<ExistsResponse>
    {
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
        /// <returns>Return exists key response</returns>
        protected override Task<ExistsResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            throw new NotImplementedException();
        }
    }
}
