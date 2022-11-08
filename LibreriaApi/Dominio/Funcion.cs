using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaApi.Dominio
{
    public class Funcion
    {
        public int IdFuncion { get; set; }
        public string Fecha { get; set; }
        public string Horario { get; set; }
        public double Precio { get; set; }
        public int IdPelicula { get; set; }
        public int IdSala { get; set; }
        public int IdFormato { get; set; }

        public Funcion()
        {
            IdFuncion = 0;
            Fecha = string.Empty;
            Horario = string.Empty;
            Precio = 0;
            IdPelicula = 0;
            IdSala = 0;
            IdFormato = 0;
        }
    }
}
