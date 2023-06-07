using System.Web.Http;
using WebActivatorEx;
using StudentApplication;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace StudentApplication
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
              .EnableSwagger(c => c.SingleApiVersion("v1", "First WEB API Demo"))
              .EnableSwaggerUi();
        }
    }
}
