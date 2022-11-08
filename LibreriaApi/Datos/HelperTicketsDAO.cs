using LibreriaApi.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaApi.Data
{
    public class HelperTicketsDAO : ConexionDB
    {
        private static HelperTicketsDAO instancia;
        public static HelperTicketsDAO ObtenerInstancia()
        {
            if (instancia == null) instancia = new HelperTicketsDAO();
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

        public int AltaBaja(string strSql, List<Parametro> values)
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
        public int EjecutarTransaccion(Factura oFactura, List<Parametro> values)
        {
            int afectadas = 0;
            SqlTransaction t = null;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd = new SqlCommand("insertar_factura", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;

                if (values != null)
                {
                    foreach (Parametro param in values)
                    {
                        cmd.Parameters.AddWithValue(param.Clave, param.Valor);
                    }
                }
                afectadas = cmd.ExecuteNonQuery();

                foreach (Ticket ticket in oFactura.lTicket)
                {
                    SqlCommand cmdTicket = new SqlCommand("Crear_Ticket", cnn, t);
                    cmdTicket.CommandType = CommandType.StoredProcedure;
                    cmdTicket.Parameters.AddWithValue("@nro_factura", oFactura.IdFactura);
                    cmdTicket.Parameters.AddWithValue("@precio", ticket.Precio);
                    cmdTicket.Parameters.AddWithValue("@id_funcion", ticket.Funcion.IdFuncion);
                    cmdTicket.Parameters.AddWithValue("@id_butaca", ticket.Butaca);
                    cmdTicket.ExecuteNonQuery();
                }

                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null) t.Rollback();
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            return afectadas;
        }

        public int ConsultaEscalarSQL(string spNombre, string pOutNombre)
        {
            SqlCommand cmd = Conectar(spNombre);
            SqlParameter pOut = new SqlParameter();
            pOut.ParameterName = pOutNombre;
            pOut.DbType = DbType.Int32;
            pOut.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pOut);
            cmd.ExecuteNonQuery();
            cnn.Close();

            try
            {
                return Convert.ToInt32(pOut.Value);
            }
            catch (Exception)
            {
                return 1;
            }

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
