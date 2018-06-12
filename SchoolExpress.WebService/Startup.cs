using System;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.StaticFiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
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
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
            appBuilder.Use<OwinContextMiddleware>();

            string[] authenticationModes = ConfigurationManager.AppSettings["AuthenticationModes"].Split(',');

            if (authenticationModes.Contains("NONE"))
            {
                config.Filters.Add(new AnonymousAuthorizeAttribute());
            }

            if (authenticationModes.Contains("BASIC"))
            {
                config.Filters.Add(container.Resolve<BasicAuthorizeAttribute>());
            }

            if (authenticationModes.Contains("JWT"))
            {
                config.Filters.Add(new JwtAuthorizeAttribute());
            }

            if (authenticationModes.Contains("OAUTH"))
            {
                double tokenExpiration = double.Parse(ConfigurationManager.AppSettings["TokenExpirationMinutes"]);
                appBuilder.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
                {
                    ApplicationCanDisplayErrors = true,
                    AllowInsecureHttp = true,
                    TokenEndpointPath = new PathString("/oauth"),
                    AccessTokenExpireTimeSpan =
                        TimeSpan.FromMinutes(tokenExpiration),
                    Provider = container.Resolve<CustomOAuthAuthorizationProvider>()
                });
                appBuilder.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            }

            appBuilder.UseFileServer(new FileServerOptions
            {
                RequestPath = new PathString(string.Empty),
                EnableDirectoryBrowsing = true,
                EnableDefaultFiles = true,
                DefaultFilesOptions = {DefaultFileNames = {"index.html"}},
                FileSystem = new PhysicalFileSystem("./wwwroot"),
                StaticFileOptions = {ContentTypeProvider = new CustomContentTypeProvider()}
            });
            config.Filters.Add(new ValidationAttribute());
            appBuilder.UseWebApi(config);
        }
    }
}