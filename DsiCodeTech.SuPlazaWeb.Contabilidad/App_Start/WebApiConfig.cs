using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;
using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using DsiCodeTech.SuPlazaWeb.Contabilidad.Handler.ExceptionHandler;

namespace DsiCodeTech.SuPlazaWeb.Contabilidad
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API
            //habilitamos cors para nuestra web api
            //primer elemento debe ser el hosting donde se publica el proyecto: www.example.com
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Filters.Add(new SuPlazaExceptionFilterAttribute());
            config.Services.Replace(typeof(IExceptionHandler), new SuPlazaExceptionHandler());

            /* Eliminar formatos XML para las respuestas */
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            /* Json por defecto en las respuestas */
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
        }
    }
}
