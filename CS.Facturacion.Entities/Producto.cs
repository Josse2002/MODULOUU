using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Facturacion.Entities
{
    public class Producto
    {
        public Int64 Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public Decimal Largo { get; set; }

        public Decimal Ancho { get; set; }

        public Decimal Alto { get; set; }
        
        public string Talla { get; set; }

        public string Color { get; set; }

        public Int64 IdProveedor { get; set; }

        public Producto() { }

        public Producto(Int64 pId, string pNombre, string pDescripcion, string pMarca, string pModelo, Decimal pLargo,
            Decimal pAncho, Decimal pAlto, string pTalla, string pColor, Int64 pIdProveedor)
        {
            Id = pId;
            Nombre = pNombre;
            Descripcion = pDescripcion;
            Marca = pMarca;
            Modelo = pModelo;
            Largo = pLargo;
            Ancho = pAncho;
            Alto = pAlto;
            Talla = pTalla;
            Color = pColor;
            IdProveedor = pIdProveedor;

        }
    }
}
