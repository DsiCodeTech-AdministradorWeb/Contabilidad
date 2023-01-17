using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DsiCodeTech.SuPlazaWeb.Contabilidad.Dto
{
    public class UsuarioDto
    {
        public string user_name { get; set; }
        public string password { get; set; }

        public string tipo_usuario{ get; set; }

        public bool enable { get; set; }
        public int user_code_bascula { get; set; }

        public DateTime fecha_registro { get; set; }
    }
}