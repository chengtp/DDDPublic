using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using DDD.Util.DependencyInjection;
using DDD.DevelopWebCore.Mvc;

namespace DDD.DevelopWebCore.DependencyInjection
{
    public class WebDependencyInjectionManager
    {
        /// <summary>
        /// Configure default web service
        /// </summary>
        public static void ConfigureDefaultWebService()
        {
            Configure();
            ContainerManager.BuildServiceProvider();
        }

        /// <summary>
        /// Configure service
        /// </summary>
        static void Configure()
        {
            //Json convert
            ContainerManager.ServiceCollection?.Configure<JsonOptions>(option =>
            {
                var defaultJsonSerializerOptions = option.JsonSerializerOptions;
                defaultJsonSerializerOptions.Converters.Add(new LongJsonConverter());
                defaultJsonSerializerOptions.Converters.Add(new LongAllowNullJsonConverter());
                defaultJsonSerializerOptions.Converters.Add(new ULongJsonConverter());
                defaultJsonSerializerOptions.Converters.Add(new ULongAllowNullJsonConverter());
                defaultJsonSerializerOptions.Converters.Add(new DecimalJsonConverter());
                defaultJsonSerializerOptions.Converters.Add(new DecimalAllowNullJsonConverter());
                defaultJsonSerializerOptions.PropertyNamingPolicy = new DefaultJsonNamingPolicy();
            });
        }
    }
}
