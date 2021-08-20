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
    public class ClienteDAL
    {
        //METODO DE OBTENER CLIENTES YA REGISTRADOS EN LA BASE DE DATOS.
        public static List<Cliente> ObtenerClientes()
        {
            List<Cliente> _listaClientes = new List<Cliente>();

            try
            {
                using (SqlConnection _connection = ComunDB.GetConnection() as SqlConnection)
                {
                    _connection.Open();

                    SqlCommand _command = new SqlCommand("ObtenerDatosCliente", _connection);
                    _command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader _reader = _command.ExecuteReader();

                    while (_reader.Read())
                    {
                        Cliente _cliente = new Cliente();

                        _cliente.Id = _reader.GetInt64(0);
                        _cliente.Nombres = _reader.GetString(1);
                        _cliente.Apellidos = _reader.GetString(2);
                        _cliente.FechaNacimiento = _reader.GetDateTime(3);
                        _cliente.DUI = _reader.GetString(4);
                        _cliente.Municipio = _reader.GetString(5);
                        _cliente.Departamento = _reader.GetString(6);
                        _cliente.Telefono = _reader.GetString(7);
                        _cliente.EMail = _reader.GetString(8);

                        _listaClientes.Add(_cliente);
                    }

                    _reader.Close();

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

            return _listaClientes;

        }

        //MÉTODO QUE PERMITE AGREGAR UN NUEVO REGISTRO DE CLIENTE EN LA BASE DE DATOS
        public static int AgregarCliente(Cliente pCliente)
        {
            int _resultado = 0;

            try
            {
                using (SqlConnection _connection = ComunDB.GetConnection() as SqlConnection)
                {
                    _connection.Open();

                    SqlCommand _command = new SqlCommand("AgregarCliente", _connection);
                    _command.CommandType = CommandType.StoredProcedure;

                    //FORMA LARGA DE CONFIGURAR PARÁMETROS
                    _command.Parameters.Add(new SqlParameter("@Nombres", pCliente.Nombres));
                    //FORMA ABREVIADA DE CONFIGURAR PARÁMETROS
                    _command.Parameters.AddWithValue("@Apellidos", pCliente.Apellidos);
                    _command.Parameters.AddWithValue("@FechaNacimiento", pCliente.FechaNacimiento);
                    _command.Parameters.AddWithValue("@DUI", pCliente.DUI);
                    _command.Parameters.AddWithValue("@Municipio", pCliente.Municipio);
                    _command.Parameters.AddWithValue("@Departamento", pCliente.Departamento);
                    _command.Parameters.AddWithValue("@Telefono", pCliente.Telefono);
                    _command.Parameters.AddWithValue("@EMail", pCliente.EMail);

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

        //METODO PARA MODIFICAR EN LA BASE DE DATOS
        public static int ModificarCliente(Cliente pCliente)
        {
            int _resultado = 0;

            try
            {
                using (SqlConnection _connection = ComunDB.GetConnection() as SqlConnection)
                {
                    _connection.Open();

                    SqlCommand _command = new SqlCommand("ModificarCliente", _connection);
                    _command.CommandType = CommandType.StoredProcedure;

                    //FORMA LARGA DE CONFIGURAR PARÁMETROS
                    _command.Parameters.AddWithValue("@Id", pCliente.Id);
                    _command.Parameters.Add(new SqlParameter("@Nombres", pCliente.Nombres));
                    //FORMA ABREVIADA DE CONFIGURAR PARÁMETROS
                    _command.Parameters.AddWithValue("@Apellidos", pCliente.Apellidos);
                    _command.Parameters.AddWithValue("@FechaNacimiento", pCliente.FechaNacimiento);
                    _command.Parameters.AddWithValue("@DUI", pCliente.DUI);
                    _command.Parameters.AddWithValue("@Municipio", pCliente.Municipio);
                    _command.Parameters.AddWithValue("@Departamento", pCliente.Departamento);
                    _command.Parameters.AddWithValue("@Telefono", pCliente.Telefono);
                    _command.Parameters.AddWithValue("@EMail", pCliente.EMail);

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

        //ELIMINAR REGSTROS DE LA BD

        public static int EliminarCliente(Int64 pId){
            int _resultado = 0;

            try
            {
                using (SqlConnection _connection = ComunDB.GetConnection() as SqlConnection)
                {
                    _connection.Open();

                    SqlCommand _command = new SqlCommand("EliminarCliente", _connection);
                    _command.CommandType = CommandType.StoredProcedure;

                    //FORMA LARGA DE CONFIGURAR PARÁMETROS
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

        //METODO DE OBTENER CLIENTES BUSCADOS YA REGISTRADOS EN LA BASE DE DATOS.
        public static Cliente BuscarClientePorId(Int64 pId)
        {
            
            try
            {
                using (SqlConnection _connection = ComunDB.GetConnection() as SqlConnection)
                {
                    _connection.Open();

                    SqlCommand _command = new SqlCommand("BuscarClientePorId", _connection);
                    _command.CommandType = CommandType.StoredProcedure;

                    _command.Parameters.AddWithValue("@Id", pId);

                    SqlDataReader _reader = _command.ExecuteReader();

                    Cliente _cliente = new Cliente();


                    if (_reader.HasRows)
                    {
                        while (_reader.Read())
                        {
                            
                            _cliente.Id = _reader.GetInt64(0);
                            _cliente.Nombres = _reader.GetString(1);
                            _cliente.Apellidos = _reader.GetString(2);
                            _cliente.FechaNacimiento = _reader.GetDateTime(3);
                            _cliente.DUI = _reader.GetString(4);
                            _cliente.Municipio = _reader.GetString(5);
                            _cliente.Departamento = _reader.GetString(6);
                            _cliente.Telefono = _reader.GetString(7);
                            _cliente.EMail = _reader.GetString(8);
                        }
                    }
                    

                    _reader.Close();

                   
                    _command.ExecuteNonQuery();
                    _connection.Close();
                    return _cliente;

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

        }


        public static List<Cliente> BuscarClientePorNombres(string pNombres)
        {
            List<Cliente> _listaClientes = new List<Cliente>();
            try
            {
                using (SqlConnection _connection = ComunDB.GetConnection() as SqlConnection)
                {
                    _connection.Open();

                    SqlCommand _command = new SqlCommand("BuscarClientePorNombre", _connection);
                    _command.CommandType = CommandType.StoredProcedure;

                    _command.Parameters.AddWithValue("@Nombres", pNombres);

                    SqlDataReader _reader = _command.ExecuteReader();


                    while (_reader.Read())
                    {
                        Cliente _cliente = new Cliente();

                        _cliente.Id = _reader.GetInt64(0);
                        _cliente.Nombres = _reader.GetString(1);
                        _cliente.Apellidos = _reader.GetString(2);
                        _cliente.FechaNacimiento = _reader.GetDateTime(3);
                        _cliente.DUI = _reader.GetString(4);
                        _cliente.Municipio = _reader.GetString(5);
                        _cliente.Departamento = _reader.GetString(6);
                        _cliente.Telefono = _reader.GetString(7);
                        _cliente.EMail = _reader.GetString(8);

                        _listaClientes.Add(_cliente);
                    }

                    _reader.Close();


                    _command.ExecuteNonQuery();
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

            return _listaClientes;

        }
    }
}