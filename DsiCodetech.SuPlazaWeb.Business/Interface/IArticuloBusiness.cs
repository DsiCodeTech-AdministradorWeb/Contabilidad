using DsiCodeTech.SuPlazaWeb.Domain;
using DsiCodeTech.SuPlazaWeb.Domain.Filter.Model;
using DsiCodeTech.SuPlazaWeb.Domain.Filter.Page;
using DsiCodeTech.SuPlazaWeb.Domain.Filter.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.SuPlazaWeb.Business.Interface
{
    public interface IArticuloBusiness
    {
        List<ArticuloDM> GetAllEntidades();
        PageResponse<ArticuloFilterDM> GetArticulosPaging(ArticuloQuery query);
    }
}
