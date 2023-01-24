using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DsiCodeTech.SuPlazaWeb.Contabilidad.Dto
{
    public class ImpuestoDto
    {
        public int id { get; set; }
        [Required(ErrorMessage ="El campo codigo de barras es requerido.")]
        public string cod_barras { get; set; }
        [Required(ErrorMessage = "El campo descripción es requerido.")]
        public string descripcion { get; set; }
        
        public decimal porcentaje { get; set; } 
        public DateTime fecha_registro { get; set; }
    }
}