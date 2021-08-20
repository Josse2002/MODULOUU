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
    public class ClienteBL
    {
        //OBTENER DATOS DE LA DB DESDE BL 
        public List<Cliente> ObtenerClientes()
        {
            try
            {
                return ClienteDAL.ObtenerClientes();
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

        //METODO PARA AGREGAR NUEVOS CLIENTES
        public int AgregarCliente(Cliente pCliente)
        {
            try
            {
                return ClienteDAL.AgregarCliente(pCliente);
            }
            catch (SqlException)
            {
                throw;
            }
            catch (NullReferenceException)
            {
                throw;
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;

            }
        }

        //METODO PARA EDITAR CLIENTE
        public int EditarCliente(Cliente pCliente)
        {
            try
            {
                return ClienteDAL.ModificarCliente(pCliente);
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

        //METODO PARA ELIMINAR CLIENTE
        public int EliminarCliente(Int64 pId)
        {
            try
            {
                return ClienteDAL.EliminarCliente(pId);
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

        public List<Cliente> BuscarClientePorNombres(string pNombre)
        {
            try
            {
                return ClienteDAL.BuscarClientePorNombres(pNombre);
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

        public static Cliente BuscarClientePorId(Int64 pId)
        {
            try
            {
                return ClienteDAL.BuscarClientePorId(pId);
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
