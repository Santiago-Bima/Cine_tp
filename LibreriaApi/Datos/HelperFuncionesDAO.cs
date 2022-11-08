using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaApi.Data
{
    public class HelperFuncionesDAO : ConexionDB
    {
        private static HelperFuncionesDAO instancia;

        public static HelperFuncionesDAO ObtenerInstancia()
        {
            if (instancia == null) instancia = new HelperFuncionesDAO();
            return instancia;
        }

        public DataTable ConsultarDB(string sp, List<Parametro> values)
        {

            DataTable dt = new DataTable();
            SqlCommand cmd = Conectar(sp);
            if (values != null)
            {
                foreach (Parametro param in values)
                {
                    cmd.Parameters.AddWithValue(param.Clave, param.Valor);
                }
            }
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            return dt;
        }

        public int EjecutarSQL(string strSql, List<Parametro> values)
        {
            int afectadas = 0;
            SqlTransaction t = null;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = strSql;
                cmd.Transaction = t;

                if (values != null)
                {
                    foreach (Parametro param in values)
                    {
                        cmd.Parameters.AddWithValue(param.Clave, param.Valor);
                    }
                }
                afectadas = cmd.ExecuteNonQuery();
                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null) { t.Rollback(); }
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            return afectadas;
        }
    }
}
