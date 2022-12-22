using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodeTech.SuPlazaWeb.Domain
{
    public class ArticuloDM
    {
        public string cod_barras { get; set; }
        public string cod_asociado { get; set; }
        public long id_clasificacion { get; set; }
        public string cod_interno { get; set; }
        public string descripcion { get; set; }
        public string descripcion_corta { get; set; }
        public decimal cantidad_um { get; set; }
        public Guid id_unidad { get; set; }
        public Guid id_proveedor { get; set; }
        public decimal precio_compra { get; set; }
        public decimal utilidad { get; set; }
        public decimal precio_venta { get; set; }
        public string tipo_articulo { get; set; }
        public decimal stock { get; set; }
        public decimal stock_min { get; set; }
        public decimal stock_max { get; set; }
        public decimal iva { get; set; }
        public DateTime kit_fecha_ini { get; set; }
        public DateTime kit_fecha_fin { get; set; }
        public bool articulo_disponible { get; set; }
        public bool kit { get; set; }
        public DateTime fecha_registro { get; set; }
        public bool visible { get; set; }
        public short puntos { get; set; }
        public DateTime last_update_inventory { get; set; }
        public string cve_producto { get; set; }

    }
}
