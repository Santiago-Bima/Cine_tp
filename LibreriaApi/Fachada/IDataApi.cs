using LibreriaApi.Data;
using LibreriaApi.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaApi.Fachada
{
    public interface IDataApi
    {
        public List<Funcion> GetFunciones();
        public bool SaveFuncion(Funcion funcion);
        public bool DeleteFuncion(int id);
        public bool EditFuncion(Funcion funcion);
    }
}
