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
    
    public partial class pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pedido()
        {
            this.compra = new HashSet<compra>();
            this.pedido_articulo = new HashSet<pedido_articulo>();
        }
    
        public System.Guid id_pedido { get; set; }
        public long num_pedido { get; set; }
        public System.DateTime fecha_pedido { get; set; }
        public System.Guid id_proveedor { get; set; }
        public string status_pedido { get; set; }
        public short no_dias { get; set; }
        public Nullable<System.DateTime> fecha_autorizado { get; set; }
        public string plan { get; set; }
        public short anio { get; set; }
        public short mes { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<compra> compra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pedido_articulo> pedido_articulo { get; set; }
        public virtual proveedor proveedor { get; set; }
    }
}
