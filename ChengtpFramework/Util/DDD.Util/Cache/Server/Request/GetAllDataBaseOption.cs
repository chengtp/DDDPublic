using System.Threading.Tasks;
using DDD.Util.Cache.Server.Response;

namespace DDD.Util.Cache.Server.Request
{
    /// <summary>
    /// Get all database option
    /// </summary>
    public class GetAllDataBaseOption : CacheRequestOption<GetAllDataBaseResponse>
    {
        /// <summary>
        /// Execute cache operation
        /// </summary>
        /// <param name="cacheProvider">Cache provider</param>
        /// <param name="server">Cache server</param>
        /// <returns>Return get all database response</returns>
        protected override async Task<GetAllDataBaseResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.GetAllDataBaseAsync(server, this).ConfigureAwait(false);
        }
    }
}
