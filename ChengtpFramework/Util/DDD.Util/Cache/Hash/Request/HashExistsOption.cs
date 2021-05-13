using System.Threading.Tasks;
using DDD.Util.Cache.Hash.Response;

namespace DDD.Util.Cache.Hash.Request
{
    /// <summary>
    /// Hash exists option
    /// </summary>
    public class HashExistsOption : CacheRequestOption<HashExistsResponse>
    {
        /// <summary>
        /// Gets or sets the cache key
        /// </summary>
        public CacheKey Key
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the hash field
        /// </summary>
        public string HashField
        {
            get; set;
        }

        /// <summary>
        /// Execute cache operation
        /// </summary>
        /// <param name="cacheProvider">Cache provider</param>
        /// <param name="server">Cache server</param>
        /// <returns>Return hash exists response</returns>
        protected override async Task<HashExistsResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.HashExistsAsync(server, this).ConfigureAwait(false);
        }
    }
}
