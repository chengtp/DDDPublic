using System.IO;
using DDD.Util.DataValidation;
using DDD.DevelopWebCore.Mvc.Display;

namespace WebSite.Config
{
    /// <summary>
    /// mvc config
    /// </summary>
    public static class MvcConfig
    {
        public static void Config()
        {
            var rootPath = Directory.GetCurrentDirectory();
            //数据验证
            ValidationManager.ConfigureByConfigFile(rootPath);
            //显示验证
            DisplayManager.ConfigureByConfigFile(rootPath);
        }
    }
}
