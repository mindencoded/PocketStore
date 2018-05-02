using System;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.StaticFiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using SchoolExpress.WebService.Providers;
using Unity;

namespace SchoolExpress.WebService
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

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
            config.DependencyResolver = new UnityResolver(container);
            var serializerSettings = config.Formatters.JsonFormatter.SerializerSettings;
            serializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            serializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            serializerSettings.NullValueHandling = NullValueHandling.Ignore;
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            appBuilder.Use<OwinContextMiddleware>();
            config.Filters.Add(new ValidationActionFilter());
            appBuilder.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                ApplicationCanDisplayErrors = true,
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan =
                    TimeSpan.FromSeconds(double.Parse(ConfigurationManager.AppSettings["AccessTokenExpire"])),
                Provider = container.Resolve<CustomOAuthAuthorizationServerProvider>()
            });
            appBuilder.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            appBuilder.UseWebApi(config);
            appBuilder.UseFileServer(new FileServerOptions
            {
                RequestPath = new PathString(string.Empty),
                EnableDirectoryBrowsing = true,
                EnableDefaultFiles = true,
                DefaultFilesOptions = {DefaultFileNames = {"index.html"}},
                FileSystem = new PhysicalFileSystem("./wwwroot"),
                StaticFileOptions = {ContentTypeProvider = new CustomContentTypeProvider()}
            });

            //Configure SSL
            //https://github.com/tonysneed/FloridaPower.Samples/blob/master/07-Web%20API%20Security/07a-Transport%20Security/Owin%20Self-Host%20SSL%20ReadMe.txt
        }
    }
}