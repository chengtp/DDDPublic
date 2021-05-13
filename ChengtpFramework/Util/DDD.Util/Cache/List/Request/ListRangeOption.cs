using System.Threading.Tasks;
using DDD.Util.Cache.List.Response;

namespace DDD.Util.Cache.List.Request
{
    /// <summary>
    /// List range option
    /// </summary>
    public class ListRangeOption : CacheRequestOption<ListRangeResponse>
    {
        /// <summary>
        /// Gets or sets the cache key
        /// </summary>
        public CacheKey Key
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the start index
        /// </summary>
        public int Start
        {
            get; set;
        } = 0;

        /// <summary>
        /// Gets or sets the stop index
        /// </summary>
        public int Stop
        {
            get; set;
        } = -1;

        /// <summary>
        /// Execute cache operation
        /// </summary>
        /// <param name="cacheProvider">Cache provider</param>
        /// <param name="server">Cache server</param>
        /// <returns>Return list range response</returns>
        protected override async Task<ListRangeResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.ListRangeAsync(server, this).ConfigureAwait(false);
        }
    }
}
