using DsiCodeTech.SuPlazaWeb.Contabilidad.Dto;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace DsiCodeTech.SuPlazaWeb.Contabilidad.Handler
{
    public class ValidateModelFilterAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {

                var field = actionContext.ModelState.Where(state => state.Value.Errors.Any())
                    .Select(value => new { value.Key, value.Value.Errors });

                var fieldFirst = field.First();

                actionContext.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new ObjectContent<HttpResponseOnError>(new HttpResponseOnError() { Id = fieldFirst.Key, Description = string.Join("|", fieldFirst.Errors.Select(e => e.ErrorMessage)) },
                    new JsonMediaTypeFormatter() { SerializerSettings = { ContractResolver = new JsonLowerCaseResolver() } }, "application/json")
                };
            }
        }
    }
}