using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CS.Facturacion.Entities;
using CS.Facturacion.DAL;

namespace CS.Facturacion.BL
{
    class DetalleFacturaBL
    {
        public static List<DetalleFactura> ObtenerDetalleFactura()
        {

            try
            {
                return DetalleFacturaDAL.ObtenerDetalleFactura();
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

        public static int AgregarDetalleFactura(DetalleFactura pDetalleFactura)
        {


            try
            {
                return DetalleFacturaDAL.AgregarDetalleFactura(pDetalleFactura);
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (NullReferenceException)
            {
                throw;
            }
            catch (ArgumentException ex)
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
