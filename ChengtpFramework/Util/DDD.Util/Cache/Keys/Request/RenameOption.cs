﻿using System.Threading.Tasks;
using DDD.Util.Cache.Keys.Response;

namespace DDD.Util.Cache.Keys.Request
{
    /// <summary>
    /// Rename option
    /// </summary>
    public class RenameOption : CacheRequestOption<RenameResponse>
    {
        /// <summary>
        /// Gets or sets the cache key
        /// </summary>
        public CacheKey Key
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the new key
        /// </summary>
        public CacheKey NewKey
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the time condition
        /// </summary>
        public CacheSetWhen When
        {
            get; set;
        } = CacheSetWhen.Always;

        /// <summary>
        /// Execute cache operation
        /// </summary>
        /// <param name="cacheProvider">Cache provider</param>
        /// <param name="server">Cache server</param>
        /// <returns>Return rename response</returns>
        protected override async Task<RenameResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.KeyRenameAsync(server, this).ConfigureAwait(false);
        }
    }
}
