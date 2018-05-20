using System;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.StaticFiles;
using Newtonsoft.Json;
using Owin;
using SchoolExpress.WebService.Controllers.Api;
using SchoolExpress.WebService.Filters;
using SchoolExpress.WebService.Providers;
using SchoolExpress.WebService.Utils;
using Unity;

namespace SchoolExpress.WebService
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            config.MapHttpAttributeRoutes(new CustomDirectRouteProvider());

            config.Routes.MapHttpRoute(
                "ApiControllerId",
                "api/{controller}/{id}",
                null,
                new {id = @"^\d+$"}
            );

            config.Routes.MapHttpRoute(
                "ApiController",
                "api/{controller}"
            );

            config.Routes.MapHttpRoute(
                "ApiControllerActionId",
                "api/{controller}/{action}/{id}",
                null,
                new {id = @"^\d+$"}
            );

            config.Routes.MapHttpRoute(
                "ApiControllerAction",
                "api/{controller}/{action}"
            );

            IUnityContainer container = UnityConfig.GetContainer();
            UnityResolver dependencyResolver = new UnityResolver(container);
            config.DependencyResolver = dependencyResolver;
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling =
                PreserveReferencesHandling.None;
            // config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            // config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            appBuilder.Use<OwinContextMiddleware>();
            string authenticationMode = ConfigurationManager.AppSettings["AuthenticationMode"];
            if (authenticationMode == "OAUTH")
            {
                appBuilder.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
                {
                    ApplicationCanDisplayErrors = true,
                    AllowInsecureHttp = true,
                    TokenEndpointPath = new PathString("/oauth"),
                    AccessTokenExpireTimeSpan =
                        TimeSpan.FromMinutes(double.Parse(ConfigurationManager.AppSettings["TokenExpiration"])),
                    Provider = container.Resolve<CustomOAuthAuthorizationProvider>()
                });
            }
            else if (authenticationMode == "JWT")
            {
                config.Filters.Add(new JwtAuthorizeFilter());
            }
            else
            {
                config.Filters.Add(new AnonymousAuthorizeFilter());
            }

            appBuilder.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            appBuilder.UseFileServer(new FileServerOptions
            {
                RequestPath = new PathString(string.Empty),
                EnableDirectoryBrowsing = true,
                EnableDefaultFiles = true,
                DefaultFilesOptions = {DefaultFileNames = {"index.html"}},
                FileSystem = new PhysicalFileSystem("./wwwroot"),
                StaticFileOptions = {ContentTypeProvider = new CustomContentTypeProvider()}
            });
            config.Filters.Add(new ValidationActionFilter());
            appBuilder.UseWebApi(config);
            //config.MessageHandlers.Add(new BasicAuthenticationHandler());
            //Configure SSL
            //https://github.com/tonysneed/FloridaPower.Samples/blob/master/07-Web%20API%20Security/07a-Transport%20Security/Owin%20Self-Host%20SSL%20ReadMe.txt
        }
    }
}