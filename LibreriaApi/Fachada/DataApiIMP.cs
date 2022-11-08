using LibreriaApi.Data;
using LibreriaApi.Data.Implementaciones;
using LibreriaApi.Data.Interfaces;
using LibreriaApi.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaApi.Fachada
{
    public class DataApiIMP : IDataApi
    {
        private IFuncionesDAO dao;

        public DataApiIMP()
        {
            dao = new FuncionesDAO();
        }

        public List<Funcion> GetFunciones()
        {
            return dao.ObtenerFunciones();
        }
        public int SaveFuncion(List<Parametro> lParametros)
        {

            return dao.EjecutarSQL("insertar_funciones", lParametros);
        }
    }
}
