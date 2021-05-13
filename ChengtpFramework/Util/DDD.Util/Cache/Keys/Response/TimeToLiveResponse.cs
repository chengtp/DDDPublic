using System;

namespace DDD.Util.Cache.Keys.Response
{
    /// <summary>
    /// Time to live response
    /// </summary>
    public class TimeToLiveResponse : CacheResponse
    {
        /// <summary>
        /// Gets or sets the to live time
        /// </summary>
        public TimeSpan? TimeToLive
        {
            get; set;
        }
    }
}
