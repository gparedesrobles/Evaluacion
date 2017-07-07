using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Conexion
    {
        private SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["App"].ConnectionString);

        public SqlConnection Obtener()
        {
            return cn;
        }


    }
}
