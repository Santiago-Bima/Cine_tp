using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaApi.Dominio
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public int IdFormaPago { get; set; }
        public string Fecha { get; set; }
        public double Descuento { get; set; }
        public double Total { get; set; }
        public List<Ticket> lTicket { get; set; }
        public bool Baja { get; set; }

        public Factura()
        {
            IdFactura = 0;
            IdCliente = 0;
            IdFormaPago = 0;
            Fecha = string.Empty;
            Descuento = 0;
            Total = 0;
            lTicket = new List<Ticket>();
            Baja = false;
        }

        public void AgregarTicket(Ticket t)
        {
            lTicket.Add(t);
        }

        public void QuitaTicket(int posicion)
        {
            lTicket.RemoveAt(posicion);
        }



        public double CalcularSubTotal()
        {
            double subTotal = 0;
            foreach (Ticket item in lTicket)
            {
                subTotal += item.Precio;
            }
            return subTotal;
        }
    }
}
