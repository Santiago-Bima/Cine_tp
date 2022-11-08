using LibreriaApi.Data;
using LibreriaApi.Data.Implementaciones;
using LibreriaApi.Data.Interfaces;
using LibreriaApi.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace FrontCine.Formularios.Diseño
{
    public partial class FrmAltaBajaFacturas : Form
    {
        private static FrmAltaBajaFacturas instancia;
        List<Factura> lFacturas;
        Factura oFactura;
        private ITicketsDAO oDao;

        public static FrmAltaBajaFacturas ObtenerInstancia()
        {
            if (instancia == null) instancia = new FrmAltaBajaFacturas();
            return instancia;
        }
        public FrmAltaBajaFacturas()
        {
            InitializeComponent();
            lFacturas = new List<Factura>();
            oDao = new TicketsDAO();
        }

        private void FrmAltaBajaFacturas_Load(object sender, EventArgs e)
        {
            CargarListaFacturas();
        }

        private void CargarListaFacturas()
        {
            lstFacturas.Items.Clear();
            DataTable tabla = oDao.ConsultarDB("consultar_altafacturas",null);

            foreach (DataRow fila in tabla.Rows)
            {
                oFactura = new Factura();
                oFactura.IdFactura = Convert.ToInt32(fila["nro_factura"]);
                
                lFacturas.Add(oFactura);

                string baja;
                if (fila["baja"].ToString() == "0x00")
                {
                    baja = "si";
                    oFactura.Baja = true;
                }
                else
                {
                    baja = "no";
                    oFactura.Baja = false;
                }

                lstFacturas.Items.Add("Factura: " + Convert.ToString(fila["nro_factura"]) + " - "
                                        + "Cliente: " + fila["cliente"] + " - "
                                        + "Froma de Pago: " + fila["forma_pago"] + " - "
                                        + "Descuento: $" + fila["descuento"] + " - "
                                        + "Total: $" + fila["total"] + " - "
                                        + "Fecha: " + fila["fecha"] + " - "
                                        + "De Baja?: " + baja);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir del formulario?",
                "saliendo...",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                instancia = null;
                Close();
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            MandarSql("baja_factura", lFacturas[lstFacturas.SelectedIndex].IdFactura);
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {

            MandarSql("alta_factura", lFacturas[lstFacturas.SelectedIndex].IdFactura);
        }

        private void MandarSql(string nombreSp, int nro_factura)
        {
            List<Parametro> lParametros = new List<Parametro>();
            lParametros.Add(new Parametro("@nro_factura", nro_factura));

            if (oDao.EjecutarSQL(nombreSp, lParametros) > 0 )
                MessageBox.Show("Se ha podido actualizar la transaccion");
            CargarListaFacturas();
        }

        private void lstFacturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lFacturas[lstFacturas.SelectedIndex].Baja)
                {
                    btnAlta.Enabled = true;
                    btnBaja.Enabled = false;
                }
                else
                {
                    btnBaja.Enabled = true;
                    btnAlta.Enabled = false;
                }
            }
            catch (Exception) { }
        }
    }
}
