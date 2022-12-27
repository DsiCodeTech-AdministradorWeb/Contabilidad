using DsiCodeTech.SuPlazaWeb.Contabilidad.Handler.ExceptionHandler;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DsiCodeTech.SuPlazaWeb.Contabilidad.Api
{
    [SuPlazaExceptionFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix(prefix: "api/articulos")]
    public class ArticulosController : ApiController
    {

    }
}
