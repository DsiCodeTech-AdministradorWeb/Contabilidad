using DsiCodeTech.SuPlazaWeb.Contabilidad.Handler.ExceptionHandler;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace DsiCodeTech.SuPlazaWeb.Contabilidad.Controllers
{
    [SuPlazaExceptionFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SeguridadController : Controller
    {
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
    }
}