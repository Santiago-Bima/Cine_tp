using LibreriaApi.Data.Interfaces;
using LibreriaApi.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaApi.Data.Implementaciones
{
    public class TicketsDAO : ITicketsDAO
    {
        public DataTable ConsultarDB(string sp, List<Parametro> values)
        {
            return HelperTicketsDAO.ObtenerInstancia().ConsultarDB(sp, values);
        }

        public int AaltaBaja(string sp, List<Parametro> lParametros)
        {
            return HelperTicketsDAO.ObtenerInstancia().AltaBaja(sp, lParametros);
        }

        public int EjecutarTransaccion(Factura oFactura, List<Parametro> lParametros)
        {
            return HelperTicketsDAO.ObtenerInstancia().EjecutarTransaccion(oFactura, lParametros);
        }

        public int ConsultaEscalarSQL(string sp, string sPout)
        {
            return HelperTicketsDAO.ObtenerInstancia().ConsultaEscalarSQL(sp, sPout);
        }

        public int EjecutarSQL(string strSql, List<Parametro> values)
        {
            return HelperTicketsDAO.ObtenerInstancia().EjecutarSQL(strSql, values);
        }
    }
}
