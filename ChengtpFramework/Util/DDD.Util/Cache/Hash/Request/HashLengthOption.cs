using System.Threading.Tasks;
using DDD.Util.Cache.Hash.Response;

namespace DDD.Util.Cache.Hash.Request
{
    /// <summary>
    /// Hash length option
    /// </summary>
    public class HashLengthOption : CacheRequestOption<HashLengthResponse>
    {
        /// <summary>
        /// Gets or sets the cache key
        /// </summary>
        public CacheKey Key
        {
            get; set;
        }

        /// <summary>
        /// Execute cache operation
        /// </summary>
        /// <param name="cacheProvider">Cache provider</param>
        /// <param name="server">Cache server</param>
        /// <returns>Return hash length response</returns>
        protected override async Task<HashLengthResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.HashLengthAsync(server, this).ConfigureAwait(false);
        }
    }
}
