using Microsoft.AspNetCore.Http;
using DDD.Util.DependencyInjection;

namespace DDD.DevelopWebCore.Utility
{
    /// <summary>
    /// Http context helper
    /// </summary>
    public static class HttpContextHelper
    {
        /// <summary>
        /// Gets the current http context
        /// </summary>
        public static HttpContext Current
        {
            get
            {
                object factory = ContainerManager.Resolve<IHttpContextAccessor>();
                HttpContext context = ((HttpContextAccessor)factory).HttpContext;
                return context;
            }
        }
    }
}
