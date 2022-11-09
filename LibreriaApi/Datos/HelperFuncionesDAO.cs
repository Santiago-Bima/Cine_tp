using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaApi.Dominio;

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

        public List<Funcion> ObtenerFunciones()
        {
            List<Funcion> lst = new List<Funcion>();

            DataTable t = new DataTable();
            SqlCommand cmd = Conectar("Consultar_Lista_Funciones");
            t.Load(cmd.ExecuteReader());
            cnn.Close();

            foreach (DataRow dr in t.Rows)
            {
                Funcion oFuncion = new Funcion();
                oFuncion.IdFuncion = Convert.ToInt32(dr[0]);
                oFuncion.IdPelicula = Convert.ToInt32(dr[3]);
                oFuncion.Fecha = dr[2].ToString();
                oFuncion.Horario = Convert.ToString(dr[1]);
                oFuncion.IdSala = Convert.ToInt32(dr[5]);
                oFuncion.IdFormato = Convert.ToInt32(dr[7]);
                oFuncion.Precio = Convert.ToDouble(dr[10]);
                oFuncion.Titulo = dr[4].ToString();

                lst.Add(oFuncion);
            }

            return lst;
        }
        public int EjecutarSQL(string strSql, List<Parametro> values, Funcion funcion)
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
                }else
                {
                    cmd.Parameters.AddWithValue("@fecha", funcion.Fecha);
                    cmd.Parameters.AddWithValue("@precio", funcion.Precio);
                    cmd.Parameters.AddWithValue("@id_pelicula", funcion.IdPelicula);
                    cmd.Parameters.AddWithValue("@id_sala", funcion.IdSala);
                    cmd.Parameters.AddWithValue("@id_formato", funcion.IdFormato);
                    cmd.Parameters.AddWithValue("@hora", funcion.Horario);
                    cmd.Parameters.AddWithValue("@id_funcion", funcion.IdFuncion);
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
