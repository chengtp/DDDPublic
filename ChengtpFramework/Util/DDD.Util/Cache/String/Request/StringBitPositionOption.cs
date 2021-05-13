﻿using System.Threading.Tasks;
using DDD.Util.Cache.String.Response;

namespace DDD.Util.Cache.String.Request
{
    /// <summary>
    /// String bit position option
    /// </summary>
    public class StringBitPositionOption : CacheRequestOption<StringBitPositionResponse>
    {
        /// <summary>
        /// Gets or sets cache key
        /// </summary>
        public CacheKey Key
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets whether set bit
        /// </summary>
        public bool Bit
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the start
        /// </summary>
        public long Start
        {
            get; set;
        } = 0;

        /// <summary>
        /// Gets or sets the end
        /// </summary>
        public long End
        {
            get; set;
        } = -1;

        /// <summary>
        /// Execute cache operation
        /// </summary>
        /// <param name="cacheProvider">Cache provider</param>
        /// <param name="server">Cache server</param>
        /// <returns>Return string bit position response</returns>
        protected override async Task<StringBitPositionResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.StringBitPositionAsync(server, this).ConfigureAwait(false);
        }
    }
}
