using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Emigrantes.ConexionBD
{
    public class Conexion
    {
        private SqlConnection sqlConnection;

        public Conexion(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public static SqlConnection Conectar()

        {
            
            SqlConnection cn = new SqlConnection("Data Source = CASA; Initial Catalog = Emigrantes; Integrated Security = True");
            cn.Open();
            return cn;

        }

       

    }
}