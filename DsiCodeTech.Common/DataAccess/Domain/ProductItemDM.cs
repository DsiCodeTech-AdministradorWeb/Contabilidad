using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodeTech.Common.DataAccess.Domain
{
    public class ProductItemDM
    {
        public string CodBarras { get; set; }

        public string CodAsociado { get; set; }

        public string CodInterno { get; set; }

        public string Descripcion { get; set; }

        public string DescripcionCorta { get; set; }

        public decimal CantidadUm { get; set; }

        public decimal PrecioCompra { get; set; }

        public decimal Utilidad { get; set; }

        public decimal PrecioVenta { get; set; }

        public string TipoArticulo { get; set; }

        public decimal Stock { get; set; }

        public decimal StockMin { get; set; }

        public decimal StockMax { get; set; }

        public decimal Iva { get; set; }

        public bool IsDisponible { get; set; }

        public bool IsKit { get; set; }

        public bool IsVisible { get; set; }

        public short Puntos { get; set; }

        public string CveProducto { get; set; }

        public DateTime? KitFechaIni { get; set; }

        public DateTime? KitFechaFin { get; set; }

        public DateTime FechaRegistro { get; set; }

        public DateTime LastUpdateInventory { get; set; }

        /* Referencias a otras tablas */

        public long IdClasificacion { get; set; }

        public Guid IdUnidad { get; set; }

        public Guid IdProveedor { get; set; }

        public CategoryDM Categoria { get; set; }

        public UnitMeasureDM Unidad { get; set; }

        public VendorDM Proveedor { get; set; }
    }
}
