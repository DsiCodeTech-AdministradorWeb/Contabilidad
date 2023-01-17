using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodeTech.SuPlazaWeb.Domain
{
    public class UsuarioDM
    {
        public string User_name { get; set; }
        public string Password { get; set; }
        public string Tipo_usuario { get; set; }
        public bool Enable { get; set; }
        public short User_code_bascula { get; set; }
        public DateTime Fecha_registro { get; set; }
    }
}
