using DsiCodeTech.SuPlazaWeb.Contabilidad.Dto;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace DsiCodeTech.SuPlazaWeb.Contabilidad.Handler.ExceptionHandler
{
    public class SuPlazaExceptionHandler : System.Web.Http.ExceptionHandling.ExceptionHandler
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public override void Handle(ExceptionHandlerContext context)
        {
            Exception exception = context.Exception;

            if (context.ExceptionContext.ActionContext != null && context.ExceptionContext.ControllerContext != null)
            {
                Log.Error(exception,
                    $"Error generado en {context.ExceptionContext.ActionContext.ActionDescriptor.ActionName} " +
                    $"en el controller {context.ExceptionContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName}");

            }

            var response = context.Request
                .CreateResponse(HttpStatusCode.Conflict,
                new HttpResponseOnError { Description = context.Exception.Message },
                new JsonMediaTypeFormatter() { SerializerSettings = { ContractResolver = new JsonLowerCaseResolver() } });

            context.Result = new ResponseMessageResult(response);
            base.Handle(context);
        }

    }
}