using DsiCodetech.SuPlazaWeb.Business.Interface;
using DsiCodeTech.SuPlazaWeb.Domain;
using DsiCodeTech.SuPlazaWeb.Domain.Extensions;
using DsiCodeTech.SuPlazaWeb.Domain.Filter.Model;
using DsiCodeTech.SuPlazaWeb.Domain.Filter.Page;
using DsiCodeTech.SuPlazaWeb.Domain.Filter.Query;
using DsiCodeTech.SuPlazaWeb.Repository;
using DsiCodeTech.SuPlazaWeb.Repository.Infraestructure.Contract;
using DsiCodeTech.SuPlazaWeb.Repository.PosContabilidad;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.SuPlazaWeb.Business
{
    /// <summary>
    /// clase de negocio que implementa la interfaz de negocio
    /// </summary>
    public class ArticuloBusiness:IArticuloBusiness
    {
        /// <summary>
        /// implementacion de la unidad de trabajo
        /// </summary>
        private readonly IUnitOfWork unitOfWork;
        /// <summary>
        /// Implementacion del repositorio Articulo
        /// </summary>
        private readonly ArticuloRepository repository;
        private readonly ILogger _logger;

        public ArticuloBusiness(IUnitOfWork _unitOfWork, ILogger logger)
        {
            unitOfWork = _unitOfWork;
            repository = new ArticuloRepository(unitOfWork);
            _logger = logger;
        }

        /// <summary>
        /// Este metodo se encarga de consultar todas las entidades de la tabla
        /// articulos
        /// </summary>
        /// <returns>
        /// una coleccion de todas las entidades del tipo articuloDM
        /// </returns>
        public List<ArticuloDM> GetAllEntidades() 
        {
            return  this.repository.GetAll().Select( e=>  new ArticuloDM {
                articulo_disponible = true,
                cantidad_um = e.cantidad_um,
                cod_asociado = e.cod_asociado,
                cod_barras = e.cod_barras,
                cod_interno = e.cod_interno,
                cve_producto = e.cve_producto,
                descripcion = e.descripcion,
                descripcion_corta = e.descripcion_corta,
                fecha_registro = e.fecha_registro,
                id_clasificacion = e.id_clasificacion,
                id_proveedor = e.id_proveedor,
                id_unidad = e.id_unidad,
                iva=e.iva,
                kit=e.kit,
                kit_fecha_fin=e.kit_fecha_fin.Value,
                kit_fecha_ini=e.kit_fecha_ini.Value,
                last_update_inventory = e.last_update_inventory,
                precio_compra=e.precio_compra,
                precio_venta=e.precio_venta,
                puntos= e.puntos,
                stock=e.stock,
                stock_max=e.stock_max,
                stock_min=e.stock_min,
                tipo_articulo=e.tipo_articulo,
                utilidad=e.utilidad,
                visible=e.visible,

            }).ToList();
        }

        /// <summary>
        /// Metodo que se encarga de consultar  todos los articulos realizando paginacion
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>

        public PageResponse<ArticuloFilterDM> GetArticulosPaging(ArticuloQuery query)
        {
            var whereFunc = PredicateBuilder.False<articulo>();
            Expression<Func<articulo, string>> orderByFunc = null;
            IEnumerable<articulo> articulos = null;
            bool isWhere = false;
            int count = 0;

            switch (query.Page.sort.Name) 
            {
                case "cod_barras":
                    orderByFunc = articulo => articulo.cod_barras;
                    break;
                case "cod_asociado":
                    orderByFunc=articulo => articulo.cod_asociado;
                    break;
                case "cod_interno":
                    orderByFunc = articulo => articulo.cod_interno;
                    break;
                case "descripcion":
                    orderByFunc = articulo => articulo.descripcion;
                    break;
                default:
                    orderByFunc = articulo => articulo.descripcion_corta;
                    break;
            }
            if (!String.IsNullOrEmpty(query.Cod_Barras))
                whereFunc = whereFunc.Or(f => f.cod_barras.StartsWith(query.Cod_Barras));
            if (!String.IsNullOrEmpty(query.Cod_Asociado))
                whereFunc = whereFunc.Or(f => f.cod_asociado.StartsWith(query.Cod_Asociado));
            if (!String.IsNullOrEmpty(query.Cod_Interno))
                whereFunc = whereFunc.Or(f => f.cod_interno.StartsWith(query.Cod_Interno));
            if (!String.IsNullOrEmpty(query.Descripcion))
                whereFunc = whereFunc.Or(f => f.descripcion.StartsWith(query.Descripcion));
            if (!String.IsNullOrEmpty(query.Cod_Barras) ||
                !String.IsNullOrEmpty(query.Cod_Asociado) || !String.IsNullOrEmpty(query.Cod_Interno)
                || !String.IsNullOrEmpty(query.Descripcion))
                isWhere = true;


        }


    }
}
