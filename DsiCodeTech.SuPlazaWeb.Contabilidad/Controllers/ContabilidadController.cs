using DsiCodetech.SuPlazaWeb.Business.Interface;
using DsiCodeTech.SuPlazaWeb.Contabilidad.Dto;
using DsiCodeTech.SuPlazaWeb.Contabilidad.Handler.ExceptionHandler;
using DsiCodeTech.SuPlazaWeb.Domain;
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
        private readonly IImpuestosBusiness impuestosBusiness;
        public ContabilidadController(IArticuloBusiness articuloBusiness, IImpuestosBusiness _impuestosBusiness)
        {
            _articuloBusiness = articuloBusiness;
            impuestosBusiness = _impuestosBusiness;
        }


        // GET: Contabilidad
        [HttpGet]
        public ActionResult mostrar()
        {
            ViewBag.IdTiposImpuestos = new SelectList(this.GetTasasDeImpuestos());
            return View();
        }

        [HttpPost]
        public ActionResult mostrar(ArticuloDto articuloDto)
        {

            if(articuloDto.cod_barras != null)
            {
                var impuesto = new ImpuestoDM
                {
                    cod_barras = articuloDto.ImpuestoDto.cod_barras,
                    descripcion = articuloDto.ImpuestoDto.descripcion,
                    porcentaje = articuloDto.ImpuestoDto.porcentaje,
                    fecha_registro = articuloDto.ImpuestoDto.fecha_registro,
                };
                impuestosBusiness.AddUpdateImpuesto(impuesto);
                ViewBag.IdTiposImpuestos = new SelectList(this.GetTasasDeImpuestos());
                return View();
            }
            //falta regresar un error al momento de que la entidad vaya vacia
            ViewBag.IdTiposImpuestos = new SelectList(this.GetTasasDeImpuestos());
            return View();
        }



        [HttpGet]
        public JsonResult GetArticulos(string codigo)
        {
            try
            {
                var articulo = _articuloBusiness.GetArticuloByCodigoBarras(codigo);
                var articuloDto = AutoMapper.Mapper.Map<ArticuloDto>(articulo);
                return Json( articuloDto,JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

               loggerdb.Error(ex);
                throw;
            }
        }



        #region Utilitario Impuestos
        /// <summary>
        /// Este metodo se encarga de almacenar todos los impuestos  aplicables a un articulo
        /// </summary>
        /// <returns>lista de impuestos aplicables a un articulo</returns>
        private List<string> GetTasasDeImpuestos()
        {
            var impuestos = new List<string>();
            impuestos.Add(Recursos.recursos_tasas_impuestos.Seleccionar);
            impuestos.Add(Recursos.recursos_tasas_impuestos.iva_general);
            impuestos.Add(Recursos.recursos_tasas_impuestos.iva_cero);
            impuestos.Add(Recursos.recursos_tasas_impuestos.ieps);
            impuestos.Add(Recursos.recursos_tasas_impuestos.iva_exento);
            return impuestos;
        }
        #endregion
    }
}