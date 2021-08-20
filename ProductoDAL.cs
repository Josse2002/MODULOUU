using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CS.Facturacion.Entities;

namespace CS.Facturacion.DAL
{
    public class ProductoDAL
    {
       //METODO PARA OBTENER LOS PRODUCTOS EN LA BASE DE DATOS

       public static List<Producto> ObtenerProductos()
        {
            List<Producto> _ListaProductos = new List<Producto>();
            try
            {
                using (SqlConnection _connection = ComunDB.GetConnection() as SqlConnection)
                {
                    //Abrir Conexion a la BD
                    _connection.Open();

                    //Crear un comando
                    SqlCommand _command = new SqlCommand("ObtenerDatosProducto", _connection);
                    //Especificar que es un Stored Procedure
                    _command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader _reader = _command.ExecuteReader();

                    while (_reader.Read())
                    {
                        Producto _product = new Producto();

                        _product.Id = _reader.GetInt64(0);
                        _product.Nombre = _reader.GetString(1);
                        _product.Descripcion = _reader.GetString(2);
                        _product.Marca = _reader.GetString(3);
                        _product.Modelo = _reader.GetString(4);
                        _product.Largo = _reader.GetDecimal(5);
                        _product.Ancho = _reader.GetDecimal(6);
                        _product.Alto = _reader.GetDecimal(7);
                        _product.Talla = _reader.GetString(8);
                        _product.Color = _reader.GetString(9);
                        _product.IdProveedor = _reader.GetInt64(10);

                        //AGREGAR LO QUE SE LEYO DE LA BD A LA LISTA
                        _ListaProductos.Add(_product);

                    }

                    //CERRAR LECTURA
                    _reader.Close();
                    //CERRAR CONEXION
                    _connection.Close();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (TimeoutException ex)
            {
                throw;
            }
            catch(FormatException ex)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw;
            }

            //RETORNAR LISTA PRODUCTOS
            return _ListaProductos;
        }
       
        //METODO PARA AGREGAR UN NUEVO REGISTRO EN LA BASE DE DATOS

        public static int AgregarProductos(Producto pProducto)
        {
            int resultado = 0;

            try
            {
                using (SqlConnection _conecction = ComunDB.GetConnection() as SqlConnection)
                {
                    _conecction.Open();
                    SqlCommand _command = new SqlCommand("AgregarProducto", _conecction);
                    _command.CommandType = CommandType.StoredProcedure;

                    //CONFIGURAR PARAMETROS
                    _command.Parameters.AddWithValue("@Nombre", pProducto.Nombre);
                    _command.Parameters.AddWithValue("@Descripcion", pProducto.Descripcion);
                    _command.Parameters.AddWithValue("@Marca", pProducto.Marca);
                    _command.Parameters.AddWithValue("@Modelo", pProducto.Modelo);
                    _command.Parameters.AddWithValue("@Largo", pProducto.Largo);
                    _command.Parameters.AddWithValue("@Ancho", pProducto.Ancho);
                    _command.Parameters.AddWithValue("@Alto", pProducto.Alto);
                    _command.Parameters.AddWithValue("@Talla", pProducto.Talla);
                    _command.Parameters.AddWithValue("@Color", pProducto.Color);
                    _command.Parameters.AddWithValue("@IdProveedor", pProducto.IdProveedor);

                    resultado = _command.ExecuteNonQuery();
                    _conecction.Close();

                    return resultado;
                }

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

        public static int ModificarProducto(Producto pProducto)
        {
            int _resultado = 0;

            try
            {
                using (SqlConnection _connection = ComunDB.GetConnection() as SqlConnection)
                {
                    _connection.Open();
                    SqlCommand _command = new SqlCommand("ModificarProducto", _connection);
                    _command.CommandType = CommandType.StoredProcedure;

                    //Parametros

                    _command.Parameters.AddWithValue("@Id", pProducto.Id);
                    _command.Parameters.AddWithValue("@Nombre", pProducto.Nombre);
                    _command.Parameters.AddWithValue("@Descripcion", pProducto.Descripcion);
                    _command.Parameters.AddWithValue("@Marca", pProducto.Marca);
                    _command.Parameters.AddWithValue("@Modelo", pProducto.Modelo);
                    _command.Parameters.AddWithValue("@Largo", pProducto.Largo);
                    _command.Parameters.AddWithValue("@Ancho", pProducto.Ancho);
                    _command.Parameters.AddWithValue("@Alto", pProducto.Alto);
                    _command.Parameters.AddWithValue("@Talla", pProducto.Talla);
                    _command.Parameters.AddWithValue("@Color", pProducto.Color);
                    _command.Parameters.AddWithValue("@IdProveedor", pProducto.IdProveedor);

                    _resultado = _command.ExecuteNonQuery();

                    //Cerrar la conexion
                    _connection.Close();

                    return _resultado;

                }
                
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

        public static int EliminarProducto(Int64 pId)
        {
            int _resultado = 0;
            try
            {
                using (SqlConnection _connection = ComunDB.GetConnection() as SqlConnection)
                {
                    _connection.Open();
                    SqlCommand _command = new SqlCommand("EliminarProducto", _connection);
                    _command.CommandType = CommandType.StoredProcedure;

                    _command.Parameters.AddWithValue("@Id", pId);
                    _resultado = _command.ExecuteNonQuery();

                    _connection.Close();

                    return _resultado;
                }
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

        public static List<Producto> BuscarProductoPorNombre(string pTexto)
        {
            List<Producto> _ListaProductos = new List<Producto>();
            try
            {
                using (SqlConnection _connection = ComunDB.GetConnection() as SqlConnection)
                {
                    //Abrir Conexion a la BD
                    _connection.Open();

                    //Crear un comando
                    SqlCommand _command = new SqlCommand("BuscarProductosPorNombre", _connection);
                    //Especificar que es un Stored Procedure
                    _command.CommandType = CommandType.StoredProcedure;
                    _command.Parameters.AddWithValue("@Nombre", pTexto);

                    SqlDataReader _reader = _command.ExecuteReader();

                    while (_reader.Read())
                    {
                        Producto _product = new Producto();

                        _product.Id = _reader.GetInt64(0);
                        _product.Nombre = _reader.GetString(1);
                        _product.Descripcion = _reader.GetString(2);
                        _product.Marca = _reader.GetString(3);
                        _product.Modelo = _reader.GetString(4);
                        _product.Largo = _reader.GetDecimal(5);
                        _product.Ancho = _reader.GetDecimal(6);
                        _product.Alto = _reader.GetDecimal(7);
                        _product.Talla = _reader.GetString(8);
                        _product.Color = _reader.GetString(9);
                        _product.IdProveedor = _reader.GetInt64(10);

                        //AGREGAR LO QUE SE LEYO DE LA BD A LA LISTA
                        _ListaProductos.Add(_product);

                    }

                    //CERRAR LECTURA
                    _reader.Close();
                    //CERRAR CONEXION
                    _connection.Close();
                }
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

            //RETORNAR LISTA PRODUCTOS
            return _ListaProductos;
        }




    }
}
