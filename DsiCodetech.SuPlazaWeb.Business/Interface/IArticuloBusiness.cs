using DsiCodeTech.SuPlazaWeb.Domain;
using DsiCodeTech.SuPlazaWeb.Domain.Filter.Model;
using DsiCodeTech.SuPlazaWeb.Domain.Filter.Page;
using DsiCodeTech.SuPlazaWeb.Domain.Filter.Query;
using System.Collections.Generic;

namespace DsiCodetech.SuPlazaWeb.Business.Interface
{
    public interface IArticuloBusiness
    {
        List<ArticuloDM> GetAllEntidades();
        PageResponse<ArticuloFilterDM> GetArticulosPaging(ArticuloQuery query);

        /// <summary>
        /// Este metodo se encarga de consultar  un articulo por codigo de barras
        /// </summary>
        /// <param name="codigo">codigo de barras</param>
        /// <returns>la entidad del tipo ArticuloDM</returns>
        ArticuloDM GetArticuloByCodigoBarras(string codigo);
    }
}
