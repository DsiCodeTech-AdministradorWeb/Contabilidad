using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodeTech.SuPlazaWeb.Domain
{
    public class ImpuestoDM
    {
        public int id { get; set; }
        public string  cod_barras { get; set; }
        public double ieps { get; set; }
        public DateTime fecha_registro { get; set; }
    }
}
