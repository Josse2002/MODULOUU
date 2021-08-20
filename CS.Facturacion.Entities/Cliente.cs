using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Facturacion.Entities
{
    public class Cliente
    {
        //PROPIEDADES DE CLASE
        public Int64 Id { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public DateTime FechaNacimiento { get; set; }
        
        public string DUI { get; set; } 

        public string Municipio { get; set; }

        public string Departamento { get; set; }

        public string Telefono { get; set; }

        public string EMail { get; set; }

        public Cliente() { }

        public Cliente (Int64 pId, string pNombres, string pApellidos, DateTime pFechaNacimiento, 
            string pDUI, string pMunicipio, string pDepartamento, string pTelefono, string pEmail)
        {
            Id = pId;
            Nombres = pNombres;
            Apellidos = pApellidos;
            FechaNacimiento = pFechaNacimiento;
            DUI = pDUI;
            Municipio = pMunicipio;
            Departamento = pDepartamento;
            Telefono = pTelefono;
            EMail = pEmail;
        }
    }
}
