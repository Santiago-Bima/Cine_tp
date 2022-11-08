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
        public bool SaveFuncion(Funcion funcion)
        {
            if (dao.EjecutarSQL("insertar_funciones", null, funcion) > 0) return true;
            else return false;
        }
    }
}
