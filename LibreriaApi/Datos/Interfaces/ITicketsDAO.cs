using LibreriaApi.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaApi.Data.Interfaces
{
    public interface ITicketsDAO
    {
        DataTable ConsultarDB(string sp, List<Parametro> values);
        int AaltaBaja(string sp, List<Parametro> lParamatros);
        int EjecutarTransaccion(Factura oFactura, List<Parametro> values);
        int ConsultaEscalarSQL(string sp, string sPout);
        public int EjecutarSQL(string strSql, List<Parametro> values);
    }
}
