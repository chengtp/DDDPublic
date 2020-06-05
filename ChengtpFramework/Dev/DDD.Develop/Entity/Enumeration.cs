using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Develop.Entity
{
    /// <summary>
    /// entity field cache option
    /// </summary>
    [Flags]
    public enum EntityFieldCacheOption
    {
        None = 0,
        CacheKey = 2,
        Ignore = 4,
        CacheKeyPrefix = 8
    }
}
