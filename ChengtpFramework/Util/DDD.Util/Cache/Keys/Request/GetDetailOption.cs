using System.Threading.Tasks;
using DDD.Util.Cache.Keys.Response;

namespace DDD.Util.Cache.Keys.Request
{
    /// <summary>
    /// Get key detail option
    /// </summary>
    public class GetDetailOption : CacheRequestOption<GetDetailResponse>
    {
        /// <summary>
        /// Gets or sets cache key
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
        /// <returns>Return get key detail response</returns>
        protected override async Task<GetDetailResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.GetKeyDetailAsync(server, this).ConfigureAwait(false);
        }
    }
}
