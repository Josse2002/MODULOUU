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
    public class ProveedorDAL
    {
        #region OBTENER PROVEEDOR...

        //OBTENER PROVEEDORES DE LA BASE DE DATOS

        public static List<Proveedor> ObtenerProveedor()
        {
            List<Proveedor> _listaProveedor = new List<Proveedor>();

            try
            {
                using (SqlConnection _connection = ComunDB.GetConnection() as SqlConnection)
                {
                    _connection.Open();

                    SqlCommand _command = new SqlCommand("ObtenerProveedor", _connection);
                    _command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader _reader = _command.ExecuteReader();

                    while (_reader.Read())
                    {
                        Proveedor _Proveedor = new Proveedor();

                        _Proveedor.Id = _reader.GetInt64(0);
                        _Proveedor.Direccion = _reader.GetString(1);
                        _Proveedor.Municipio = _reader.GetString(2);
                        _Proveedor.Departamento = _reader.GetString(3);
                        _Proveedor.Telefono = _reader.GetString(4);
                        _Proveedor.Email = _reader.GetString(5);
                        _Proveedor.RazonSocial = _reader.GetString(6);
                       

                        _listaProveedor.Add(_Proveedor);
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

            return _listaProveedor;

        }

        #endregion
    }
}
