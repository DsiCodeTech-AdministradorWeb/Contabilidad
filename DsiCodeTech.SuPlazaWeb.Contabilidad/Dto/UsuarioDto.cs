﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DsiCodeTech.SuPlazaWeb.Contabilidad.Dto
{
    public class UsuarioDto
    {
        public string User_name { get; set; }
        public string Password { get; set; }

        public string Tipo_usuario{ get; set; }

        public bool Enable { get; set; }
        public int User_code_bascula { get; set; }

        public DateTime Fecha_registro { get; set; }
    }
}