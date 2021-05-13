using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Util.Cache.Keys.Response;

namespace DDD.Util.Cache.Keys.Request
{
    /// <summary>
    /// Delete key option
    /// </summary>
    public class DeleteOption : CacheRequestOption<DeleteResponse>
    {
        /// <summary>
        /// Gets or sets the cache keys
        /// </summary>
        public List<CacheKey> Keys
        {
            get; set;
        }

        /// <summary>
        /// Execute the cache operation
        /// </summary>
        /// <param name="cacheProvider">Cache provider</param>
        /// <param name="server">Cache server</param>
        /// <returns>Return delete key response</returns>
        protected override async Task<DeleteResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.KeyDeleteAsync(server, this).ConfigureAwait(false);
        }
    }
}
