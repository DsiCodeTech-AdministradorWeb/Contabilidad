using DsiCodeTech.SuPlazaWeb.Contabilidad.Infraestructure;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DsiCodeTech.SuPlazaWeb.Contabilidad
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            AutomaperWebProfile.Run();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configuration
                .Formatters
                .JsonFormatter
                .SerializerSettings
                .ContractResolver = new JsonLowerCaseResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                };
        }
    }
    public class JsonLowerCaseResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}
