using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DsiCodeTech.SuPlazaWeb.Contabilidad.Dto
{
    public class ImpuestoDto
    {
        public int id { get; set; }
        public string cod_barras { get; set; }
        public double ieps { get; set; }
        public DateTime fecha_registro { get; set; }
    }
}