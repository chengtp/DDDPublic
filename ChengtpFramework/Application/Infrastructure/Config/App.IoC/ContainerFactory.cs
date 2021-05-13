using System;
using Microsoft.Extensions.DependencyInjection;
using DDD.Util.Drawing.VerificationCode;
using DDD.Util.DependencyInjection;
using DDD.DevelopWebCore.DependencyInjection;

namespace App.IoC
{
    public class ContainerFactory : IServiceProviderFactory<IDIContainer>
    {
        /// <summary>
        /// 自定义服务注入
        /// </summary>
        /// <param name="container"></param>
        static void RegisterServices(IDIContainer container)
        {
            WebDependencyInjectionManager.ConfigureDefaultWebService();
            container.Register(typeof(VerificationCodeProvider), typeof(SkiaSharpVerificationCode));
        }

        public IDIContainer CreateBuilder(IServiceCollection services)
        {
            ContainerManager.Init(services, serviceRegisterAction: RegisterServices);
            return ContainerManager.Container;
        }

        public IServiceProvider CreateServiceProvider(IDIContainer containerBuilder)
        {
            return containerBuilder.BuildServiceProvider();
        }
    }
}
