using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Facturacion.Entities
{
    public class DetalleFactura
    {
        public Int64 Id { get; set; }

        public Int64 IdFactura { get; set; }

        public Int64 Cantidad { get; set; }

        public Int64 IdProducto { get; set; }

        public Decimal PrecioUnitario { get; set; }

        public Decimal SubTotal { get; set; }

        public Decimal TotalImpuesto { get; set; }

        public Decimal TotalLinea { get; set; }

        public string Estado { get; set; }

        public DetalleFactura(){  }

        public DetalleFactura(Int64 pId, Int64 pIdFactura, Int64 pCantidad, Int64 pIdProducto, Decimal pPrecioUnitario, 
            Decimal pSubTotal, Decimal pTotalImpuesto, Decimal pTotalLinea, string pEstado)
        {
            Id = pId;
            IdFactura = pIdFactura;
            Cantidad = pCantidad;
            IdProducto = pIdProducto;
            PrecioUnitario = pPrecioUnitario;
            SubTotal = pSubTotal;
            TotalImpuesto = pTotalImpuesto;
            TotalLinea = pTotalLinea;
            Estado = pEstado;
        }
    }
}
