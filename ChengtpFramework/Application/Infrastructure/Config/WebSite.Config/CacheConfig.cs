using System;
using System.Collections.Generic;
using System.Text;
using DDD.Util.Cache;

namespace WebSite.Config
{
    public static class CacheConfig
    {
        public static void Init()
        {
            CacheManager.Configuration.ConfigureCacheServer(option =>
            {
                return new List<CacheServer>()
               {
                    new CacheServer()
                    {
                        ServerType=CacheServerType.InMemory
                    }
               };
            });
        }
    }
}
