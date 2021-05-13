﻿namespace DDD.Util.Develop.CQuery.CriteriaConverter
{
    /// <summary>
    /// Criteria converter factory
    /// </summary>
    public static class CriteriaConverterFactory
    {
        /// <summary>
        /// Create a new criterial convert
        /// </summary>
        /// <param name="convertConfigName">Convert config name</param>
        /// <returns>Return a ICriteriaConverter object</returns>
        public static ICriteriaConverter Create(string convertConfigName)
        {
            return new DefaultCriteriaConverter()
            {
                Name = convertConfigName
            };
        }
    }
}
