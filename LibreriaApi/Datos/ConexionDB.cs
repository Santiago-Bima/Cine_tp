using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaApi.Data
{
    public class ConexionDB
    {
        protected SqlConnection cnn = new SqlConnection(@"Data Source=santipc\sqlexpress;Initial Catalog=cine_tp;Integrated Security=True");

        public SqlCommand Conectar(string sp)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sp, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
    }
}
