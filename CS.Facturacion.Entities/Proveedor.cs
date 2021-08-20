using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Facturacion.Entities
{
    public class Proveedor
    {
        public Int64 Id { get; set; }
        
        public string Direccion { get; set; }

        public string Municipio { get; set; }

        public string Departamento { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public string RazonSocial { get; set; }

        public Proveedor() { }

        public Proveedor(Int64 pId, string pDireccion, string pMunicipio, string pDepartamento, 
            string pTelefono, string pEmail, string pRazonSocial)
        {
            Id = pId;
            Direccion = pDireccion;
            Municipio = pMunicipio;
            Departamento = pDepartamento;
            Telefono = pTelefono;
            Email = pEmail;
            RazonSocial = pRazonSocial;

        }
    }
}
