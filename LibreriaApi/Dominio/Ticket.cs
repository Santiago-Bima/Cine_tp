using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaApi.Dominio
{
    public class Ticket
    {
        public int IdTicket { get; set; }
        public double Precio { get; set; }
        public Funcion Funcion { get; set; }
        public int Butaca { get; set; }
        

        public Ticket()
        {
            IdTicket = 0;
            Precio = 0;
            Funcion = new Funcion();
            Butaca = 0;
        }
    }
}
