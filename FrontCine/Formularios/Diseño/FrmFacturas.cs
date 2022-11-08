using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaApi.Data;
using LibreriaApi.Data.Implementaciones;
using LibreriaApi.Data.Interfaces;
using LibreriaApi.Dominio;

namespace FrontCine.Formularios.Diseño
{
    public partial class FrmFacturas : Form
    {
        private Factura oFactura;
        private ITicketsDAO oDao;
        private static FrmFacturas instancia;

        public static FrmFacturas ObtenerInstancia()
        {
            if (instancia == null) instancia = new FrmFacturas();
            return instancia;
        }
        public FrmFacturas()
        {
            InitializeComponent();
            oFactura = new Factura();
            oDao = new TicketsDAO();
        }

        private void FrmFacturas_Load(object sender, EventArgs e)
        {
            CargarCombos(cboClientes, "combo_clientes");
            CargarCombos(cboFormasPago, "combo_formasPago");
            CargarFunciones();
            Limpiar();
            ProximaTransaccion();
        }
        private void ProximaTransaccion()
        {
            int next = oDao.ConsultaEscalarSQL("consultar_proxFactura", "@id");
            if (next > 0)
                lblNroFactura.Text = "Número de Factura: N° " + next.ToString();
            else
                MessageBox.Show("Error de datos. No se puede obtener Nº de Factura!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Limpiar()
        {
            cboClientes.SelectedIndex = -1;
            cboButacas.SelectedItem = -1;
            cboFormasPago.SelectedIndex = -1;
            cboFunciones.SelectedIndex = -1;
            cboFormato.SelectedIndex = -1;
            cboIdioma.SelectedIndex = -1;
            cboSala.SelectedIndex = -1;

            cboButacas.Enabled = false;

            txtFecha.Text = string.Empty;
            txtDescuento.Text = string.Empty;
            txtHora.Text = string.Empty;
            txtPrecio.Text = string.Empty;

            lblCantTickets.Text = "Cantidad de Tickets: ";
            lblNroFactura.Text = "Número de Factura: N°";
            lblTotal.Text = "Total: ";
            lblSubTotal.Text = "SubTotal: ";
        }

        private void CargarCombos(ComboBox cbo, string sp)
        {
            DataTable tabla = oDao.ConsultarDB(sp, null);
            cbo.DataSource = tabla;
            cbo.ValueMember = tabla.Columns[0].ColumnName;
            cbo.DisplayMember = tabla.Columns[1].ColumnName;
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CargarFunciones()
        {
            DataTable tabla = oDao.ConsultarDB("consultar_funciones", null);
            cboFunciones.DataSource = tabla;
            cboFunciones.ValueMember = "idFuncion";
            cboFunciones.DisplayMember = "titulo";
            cboFunciones.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cboFunciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboFunciones.SelectedValue is not DataRowView)
            {
                List<Parametro> lParametros = new List<Parametro>();
                lParametros.Add(new Parametro("@id_funcion", Convert.ToInt32(cboFunciones.SelectedValue)));
                DataTable tabla = oDao.ConsultarDB("consultar_funcion", lParametros);

                

                foreach (DataRow row in tabla.Rows)
                {
                    cboFormato.DataSource = tabla;
                    cboIdioma.DataSource = tabla;
                    cboSala.DataSource = tabla;

                    txtPrecio.Text = row["Precio"].ToString();
                    txtFecha.Text = row["Fecha"].ToString();
                    txtHora.Text = row["Hora"].ToString();

                    cboSala.ValueMember = "idSala";
                    cboSala.DisplayMember = "sala";

                    cboIdioma.ValueMember = "ididioma";
                    cboIdioma.DisplayMember = "idioma";

                    cboFormato.ValueMember = "idformato";
                    cboFormato.DisplayMember = "formato";
                }

                if (cboFunciones.SelectedIndex > 0)
                {
                    cboButacas.Enabled = true;
                    DataTable tablaButacas = oDao.ConsultarDB("combo_butacas", lParametros);
                    cboButacas.DataSource = tablaButacas;
                    cboButacas.ValueMember = "butaca";
                    cboButacas.DisplayMember = "butaca";
                    cboButacas.DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir del formulario?",
                 "saliendo...",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question,
                 MessageBoxDefaultButton.Button2) == DialogResult.Yes) Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboFunciones.Text.Equals(String.Empty))
            {
                MessageBox.Show("Debe seleccionar una Función!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboFunciones.Focus();
                return;
            }

            if (cboButacas.Text.Equals(String.Empty))
            {
                MessageBox.Show("Debe seleccionar una butaca!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboButacas.Focus();
                return;
            }



            foreach (DataGridViewRow row in dgvTickets.Rows)
            {
                if (row.Cells["colButaca"].Value.ToString().Equals(cboButacas.SelectedIndex.ToString()) &&
                    row.Cells["idFuncion"].Value.ToString().Equals(cboFunciones.SelectedIndex.ToString())){
                    MessageBox.Show("Ya se esta utilizando esa Butaca", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            double precio = Convert.ToDouble(txtPrecio.Text);

            Funcion funcion = new Funcion();
            funcion.Fecha = txtFecha.Text;
            funcion.IdFormato = cboFormato.SelectedIndex;
            funcion.IdSala = cboSala.SelectedIndex;
            funcion.IdPelicula = cboFunciones.SelectedIndex;
            funcion.Horario = txtHora.Text;

            Ticket ticket = new Ticket();
            ticket.Precio = precio;
            ticket.Butaca = cboButacas.SelectedIndex;
            ticket.Funcion = funcion;

            oFactura.AgregarTicket(ticket);

            dgvTickets.Rows.Add(cboFunciones.SelectedIndex,cboFunciones.Text, cboSala.Text, cboButacas.Text, txtFecha.Text, txtHora.Text, cboIdioma.Text, cboFormato.Text, txtPrecio.Text);

            CalcularSubTotal();
            lblTotal.Text = "Total: " + CalcularTotal().ToString();
            CalcularCantTickets();
            cboFunciones.SelectedIndex = -1;
            cboButacas.SelectedIndex = -1;
        }

        private void CalcularCantTickets()
        {
            int cantidad;
            cantidad = dgvTickets.Rows.Count;
            lblCantTickets.Text = "Cantidad de Tickets: " + cantidad.ToString();
        }

        private void CalcularSubTotal()
        {
            double subTotal = oFactura.CalcularSubTotal();
            lblSubTotal.Text = "SubTotal: " + subTotal.ToString();
        }
        private double CalcularTotal()
        {
            double total = oFactura.CalcularSubTotal();
            if (!txtDescuento.Text.Equals(string.Empty)) total -= Convert.ToInt32(txtDescuento.Text);

            return total; 

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvTickets.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos una Función!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }else if(cboClientes.SelectedIndex == -1 || cboFormasPago.SelectedIndex == -1)
            {
                MessageBox.Show("Debe completar los campos Cliente y Formas de Pago!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GuardarTransaccion();
        }
        private void GuardarTransaccion()
        {

            oFactura.IdCliente = cboClientes.SelectedIndex;
            oFactura.Fecha = txtFecha.Text;
            if (txtDescuento.Text.Equals(string.Empty)) oFactura.Descuento = 0;
            else oFactura.Descuento = Convert.ToDouble(txtDescuento.Text);
            oFactura.IdFormaPago = cboFormasPago.SelectedIndex;

            List<Parametro> lParametros = new List<Parametro>();
            lParametros.Add(new Parametro("@id_cliente", oFactura.IdCliente));
            lParametros.Add(new Parametro("@id_forma_pago", oFactura.IdFormaPago));
            lParametros.Add(new Parametro("@fecha", oFactura.Fecha));
            lParametros.Add(new Parametro("@descuento", oFactura.Descuento));
            lParametros.Add(new Parametro("@total", CalcularTotal()));

            if (oDao.EjecutarTransaccion(oFactura, lParametros) > 0)
            {
                MessageBox.Show("Transacción registrada", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("ERROR. No se pudo registrar la Transacción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTickets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTickets.CurrentCell.ColumnIndex == 9)
            {
                oFactura.QuitaTicket(dgvTickets.CurrentRow.Index);
                dgvTickets.Rows.Remove(dgvTickets.CurrentRow);
                CalcularSubTotal();
                lblTotal.Text = "Total: " + CalcularTotal().ToString();
                CalcularCantTickets();

            }
        }

        private void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            lblTotal.Text = "Total: " + CalcularTotal().ToString();
        }
    }
}
