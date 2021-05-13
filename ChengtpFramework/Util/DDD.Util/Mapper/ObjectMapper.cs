﻿using DDD.Util.Fault;
using DDD.Util.DependencyInjection;

namespace DDD.Util.Mapper
{
    /// <summary>
    /// Object mapper
    /// </summary>
    public static class ObjectMapper
    {
        static ObjectMapper()
        {
            Current = ContainerManager.Resolve<IMapper>();
        }

        /// <summary>
        /// Get or set current object mapper
        /// </summary>
        public static IMapper Current { get; set; }

        /// <summary>
        /// Convert object
        /// </summary>
        /// <typeparam name="TTarget">Target data type</typeparam>
        /// <param name="sourceObject">Source object</param>
        /// <returns>Return the target data object</returns>
        public static TTarget MapTo<TTarget>(object sourceObject)
        {
            if (Current == null)
            {
                throw new EZNEWException($"{nameof(Current)} is not initialized");
            }
            return Current.MapTo<TTarget>(sourceObject);
        }
    }
}
