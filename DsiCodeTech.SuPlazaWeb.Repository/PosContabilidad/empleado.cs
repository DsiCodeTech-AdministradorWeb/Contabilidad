//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DsiCodeTech.SuPlazaWeb.Repository.PosContabilidad
{
    using System;
    using System.Collections.Generic;
    
    public partial class empleado
    {
        public System.Guid id_empleado { get; set; }
        public string nombre { get; set; }
        public string a_paterno { get; set; }
        public string a_materno { get; set; }
        public string user_name { get; set; }
        public System.DateTime fecha_registro { get; set; }
    
        public virtual usuario usuario { get; set; }
    }
}
