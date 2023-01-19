using DsiCodetech.SuPlazaWeb.Business.Interface;
using DsiCodeTech.SuPlazaWeb.Contabilidad.Dto;
using DsiCodeTech.SuPlazaWeb.Contabilidad.Handler.ExceptionHandler;
using DsiCodeTech.SuPlazaWeb.Domain;
using NLog;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace DsiCodeTech.SuPlazaWeb.Contabilidad.Api
{
    [SuPlazaExceptionFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix(prefix: "api/articulos")]
    public class ArticulosController : ApiController
    {
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");
        private readonly IArticuloBusiness _articuloBusiness;
        private readonly IImpuestosBusiness _impuestosBusiness;

        public ArticulosController(IArticuloBusiness articuloBusiness, IImpuestosBusiness impuestosBusiness)
        {
            this._articuloBusiness = articuloBusiness;
            this._impuestosBusiness = impuestosBusiness;
        }


        [ResponseType(typeof(ArticuloDto))]
        [Route("getcodigobarras")]
        [HttpGet]
        public IHttpActionResult GetArticulosByCodigoBarras(string codigo)
        {
            try 
            {
                var articulo = _articuloBusiness.GetArticuloByCodigoBarras(codigo);
                var articuloDto = AutoMapper.Mapper.Map<ArticuloDto>(articulo);
                return Ok( articuloDto);
            }
            catch (Exception ex)
            {
                
                loggerdb.Error(ex);
                throw;
            }
            
        }

        
        [Route("insertarimpuestos")]
        [HttpPost]
        public IHttpActionResult InsertArticuloImpuesto(ImpuestoDto impuestoDto)
        {
            try
            {
                if (impuestoDto.cod_barras != null)
                {
                    var impuestoDM = AutoMapper.Mapper.Map<ImpuestoDM>(impuestoDto);
                    _impuestosBusiness.AddUpdateImpuesto(impuestoDM);
                    return Ok();
                }
                else {
                    return BadRequest("No se pudo encontrar la ruta especificada");
                }
            }
            catch (Exception ex)
            {

                loggerdb.Error(ex);
                throw;
            }
        }


    }
}
