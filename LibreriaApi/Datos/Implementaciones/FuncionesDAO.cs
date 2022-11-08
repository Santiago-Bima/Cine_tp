using LibreriaApi.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaApi.Data.Implementaciones
{
    public class FuncionesDAO : IFuncionesDAO
    {
        public DataTable ConsultarDB(string sp, List<Parametro> values)
        {
            return HelperFuncionesDAO.ObtenerInstancia().ConsultarDB(sp, values);
        }

        public int EjecutarSQL(string sp, List<Parametro> lParametros)
        {
            return HelperFuncionesDAO.ObtenerInstancia().EjecutarSQL(sp, lParametros);
        }
    }
}
