using LibreriaApi.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaApi.Data.Interfaces
{
    public interface IFuncionesDAO
    {
        DataTable ConsultarDB(string sp, List<Parametro> values);
        int EjecutarSQL(string sp, List<Parametro> lParametros);
        List<Funcion> ObtenerFunciones();
    }
}
