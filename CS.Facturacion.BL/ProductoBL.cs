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
    public class ProductoBL
    {
        //OBTENER DATOS DE LA BASE DE DATOS
        public List<Producto> ObtenerProductos()
        {
            try
            {
                return ProductoDAL.ObtenerProductos();
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
        public int AgregarProducto(Producto pProducto)
        {
            try
            {
                return ProductoDAL.AgregarProductos(pProducto);
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

        //METODO PARA EDITAR PRODUCTO
        public int EditarProducto(Producto pProducto)
        {
            try
            {
                return ProductoDAL.ModificarProducto(pProducto);
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
        public int EliminarProducto(Int64 pId)
        {
            try
            {
                return ProductoDAL.EliminarProducto(pId);
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

        public  List<Producto> BuscarProductoPorNombre(string pTexto)
        {
        
            try
            {
                return ProductoDAL.BuscarProductoPorNombre(pTexto);
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
