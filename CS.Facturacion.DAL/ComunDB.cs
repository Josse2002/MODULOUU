
//USINGS PARA SQL SERVER
using System.Data;
using System.Data.SqlClient;

namespace CS.Facturacion.DAL
{
    public class ComunDB
    {
        //CONEXION STRING
        public const string _connectionString = @"Data Source=LAPTOP-9O9LN3PN;Initial Catalog=PRACTICA;Integrated Security=True";
        public static IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}