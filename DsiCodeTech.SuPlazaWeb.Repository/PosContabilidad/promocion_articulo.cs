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
    
    public partial class promocion_articulo
    {
        public System.Guid id_promo { get; set; }
        public string cod_barras { get; set; }
        public decimal cantidad_lleva { get; set; }
        public decimal cantidad_paga { get; set; }
        public decimal porcent_desc { get; set; }
    
        public virtual articulo articulo { get; set; }
        public virtual promocion promocion { get; set; }
    }
}