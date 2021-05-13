using System.Threading.Tasks;
using DDD.Util.Cache.Keys.Response;

namespace DDD.Util.Cache.Keys.Request
{
    /// <summary>
    /// Move option
    /// </summary>
    public class MoveOption : CacheRequestOption<MoveResponse>
    {
        /// <summary>
        /// Gets or sets the cache key
        /// </summary>
        public CacheKey Key
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the database
        /// </summary>
        public int DataBase
        {
            get; set;
        }

        /// <summary>
        /// Execute cache operation
        /// </summary>
        /// <param name="cacheProvider">Cache provider</param>
        /// <param name="server">Cache server</param>
        /// <returns>Return move response</returns>
        protected override async Task<MoveResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.KeyMoveAsync(server, this).ConfigureAwait(false);
        }
    }
}
