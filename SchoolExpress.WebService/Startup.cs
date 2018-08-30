using System;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.StaticFiles;
using Newtonsoft.Json;
using Owin;
using SchoolExpress.WebService.Filters;
using SchoolExpress.WebService.Handlers;
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

            config.Services.Replace(typeof(IExceptionLogger), new UnhandledExceptionLogger());

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
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            appBuilder.Use<OwinContextMiddleware>();

            string[] authenticationModes = ConfigurationManager.AppSettings["AuthenticationModes"].Split(',');

            if (authenticationModes.Contains("NONE"))
            {
                config.Filters.Add(new AnonymousAuthorizeAttribute());
            }
            else
            {
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
                    appBuilder.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
                    {
                        ApplicationCanDisplayErrors = true,
                        AllowInsecureHttp = true,
                        TokenEndpointPath = new PathString("/oauth"),
                        AccessTokenExpireTimeSpan =
                            TimeSpan.FromMinutes(
                                double.Parse(ConfigurationManager.AppSettings["TokenExpirationMinutes"])),
                        Provider = container.Resolve<CustomOAuthAuthorizationProvider>()
                    });
                    appBuilder.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
                }
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
            config.MessageHandlers.Add(new CustomLogHandler());
            appBuilder.UseWebApi(config);
        }
    }
}