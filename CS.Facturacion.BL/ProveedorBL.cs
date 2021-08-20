using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS.Facturacion.Entities;
using CS.Facturacion.DAL;
using System.Data.SqlClient;

namespace CS.Facturacion.BL
{
   public class ProveedorBL
    {
        //OBTENER DATOS DE LA DB DESDE BL 
        public List<Proveedor> ObtenerProveedor()
        {
            try
            {
                return ProveedorDAL.ObtenerProveedor();
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (TimeoutException ex)
            {
                throw;
            }
            catch (FormatException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
