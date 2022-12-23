using DsiCodeTech.SuPlazaWeb.Domain.Filter.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodeTech.SuPlazaWeb.Domain.Filter.Query
{
    public class ArticuloQuery
    {
        public string Cod_Barras { get; set; }
        public string Cod_Asociado { get; set; }
        public string Cod_Interno { get; set; }
        public string Descripcion { get; set; }
        public string Descripcion_Corta { get; set; }
        public PageRequest Page { get; set; }
    }
}
