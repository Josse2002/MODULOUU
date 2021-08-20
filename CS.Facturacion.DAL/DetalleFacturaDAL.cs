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
    public class DetalleFacturaDAL
    {
        public static List<DetalleFactura> ObtenerDetalleFactura()
        {
            List<DetalleFactura> _ListaDetalleFactura = new List<DetalleFactura>();
            try
            {
                using (SqlConnection _connection = ComunDB.GetConnection() as SqlConnection)
                {
                    //Abrir Conexion a la BD
                    _connection.Open();

                    //Crear un comando
                    SqlCommand _command = new SqlCommand("ObtenerDatosFactura", _connection);
                    //Especificar que es un Stored Procedure
                    _command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader _reader = _command.ExecuteReader();

                    while (_reader.Read())
                    {
                        DetalleFactura _DetalleFactura = new DetalleFactura();
                        _DetalleFactura.Id = _reader.GetInt64(0);
                        _DetalleFactura.IdFactura = _reader.GetInt64(1);
                        _DetalleFactura.Cantidad = _reader.GetInt64(2);
                        _DetalleFactura.IdProducto = _reader.GetInt64(3);
                        _DetalleFactura.PrecioUnitario = _reader.GetDecimal(4);
                        _DetalleFactura.SubTotal = _reader.GetDecimal(5);
                        _DetalleFactura.TotalImpuesto = _reader.GetDecimal(6);
                        _DetalleFactura.TotalLinea = _reader.GetDecimal(7);
                        _DetalleFactura.Estado = _reader.GetString(8);
                        
                       


                        //AGREGAR LO QUE SE LEYO DE LA BD A LA LISTA
                        _ListaDetalleFactura.Add(_DetalleFactura);

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
            return _ListaDetalleFactura;
        }

        public static int AgregarDetalleFactura(DetalleFactura pDetalleFactura)
        {
            int _resultado = 0;

            try
            {
                using (SqlConnection _connection = ComunDB.GetConnection() as SqlConnection)
                {
                    _connection.Open();

                    SqlCommand _command = new SqlCommand("AgregarDetalleFactura", _connection);
                    _command.CommandType = CommandType.StoredProcedure;

                    //FORMA ABREVIADA DE CONFIGURAR PARÁMETROS
                    _command.Parameters.AddWithValue("@IdFactura", pDetalleFactura.IdFactura);
                    _command.Parameters.AddWithValue("@Cantidad", pDetalleFactura.Cantidad);
                    _command.Parameters.AddWithValue("@IdProducto", pDetalleFactura.IdProducto);
                    _command.Parameters.AddWithValue("@PrecioUnitario", pDetalleFactura.PrecioUnitario);
                    _command.Parameters.AddWithValue("@SubTotal", pDetalleFactura.SubTotal);
                    _command.Parameters.AddWithValue("@TotalImpuesto", pDetalleFactura.TotalImpuesto);
                    _command.Parameters.AddWithValue("@TotalLinea", pDetalleFactura.TotalLinea);


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
    }
}
