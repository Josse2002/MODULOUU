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
    public class FacturaDAL
    {
        //METODO PARA OBTENER LOS PRODUCTOS EN LA BASE DE DATOS

        public static List<Factura> ObtenerFactura()
        {
            List<Factura> _ListaFactura = new List<Factura>();
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
                        Factura _Factura = new Factura();

                        _Factura.Id = _reader.GetInt64(0);
                        _Factura.Numero = _reader.GetInt64(1);
                        _Factura.Fecha = _reader.GetDateTime(2);
                        _Factura.IdCliente = _reader.GetInt64(3);
                        _Factura.SubTotal = _reader.GetDecimal(4);
                        _Factura.TotalImpuesto = _reader.GetDecimal(5);
                        _Factura.Total = _reader.GetDecimal(6);
                        _Factura.Estado = _reader.GetString(7);
                        

                        //AGREGAR LO QUE SE LEYO DE LA BD A LA LISTA
                        _ListaFactura.Add(_Factura);

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
            return _ListaFactura;
        }

        public static int AgregarFactura(Factura pFactura)
        {
            int _resultado = 0;

            try
            {
                using (SqlConnection _connection = ComunDB.GetConnection() as SqlConnection)
                {
                    _connection.Open();

                    SqlCommand _command = new SqlCommand("AgregarFactura", _connection);
                    _command.CommandType = CommandType.StoredProcedure;

                    //FORMA ABREVIADA DE CONFIGURAR PARÁMETROS
                    _command.Parameters.AddWithValue("@Numero", pFactura.Numero);
                    _command.Parameters.AddWithValue("@Fecha", pFactura.Fecha);
                    _command.Parameters.AddWithValue("@IdCliente", pFactura.IdCliente);
                    _command.Parameters.AddWithValue("@SubTotal", pFactura.SubTotal);
                    _command.Parameters.AddWithValue("@TotalImpuesto", pFactura.TotalImpuesto);
                    _command.Parameters.AddWithValue("@Total", pFactura.Total);

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
