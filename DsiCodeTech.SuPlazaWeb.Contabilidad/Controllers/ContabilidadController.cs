using DsiCodetech.SuPlazaWeb.Business.Interface;
using DsiCodeTech.SuPlazaWeb.Contabilidad.Dto;
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
    public class ContabilidadController : Controller
    {
        
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");
        private readonly IArticuloBusiness _articuloBusiness;

        public ContabilidadController(IArticuloBusiness articuloBusiness)
        {
            _articuloBusiness = articuloBusiness;
        }


        // GET: Contabilidad
        public ActionResult mostrar()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetArticulos(string codigo)
        {
            try
            {
               return Json( AutoMapper.Mapper.Map<ArticuloDto>(_articuloBusiness.GetArticuloByCodigoBarras(codigo)),JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

               loggerdb.Error(ex);
                throw;
            }
        }
    }
}