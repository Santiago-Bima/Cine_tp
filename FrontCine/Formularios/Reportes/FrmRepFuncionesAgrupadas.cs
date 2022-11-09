using LibreriaApi.Data;
using LibreriaApi.Data.Implementaciones;
using LibreriaApi.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontCine.Formularios.Reportes
{
    public partial class FrmRepAgrupadoFunciones : Form
    {

        private static FrmRepAgrupadoFunciones instancia;
        private ITicketsDAO oDao;

        public static FrmRepAgrupadoFunciones ObtenerInstancia()
        {
            if (instancia == null) instancia = new FrmRepAgrupadoFunciones();
            return instancia;
        }
        public FrmRepAgrupadoFunciones()
        {
            InitializeComponent();
            oDao = new TicketsDAO();
        }

        private void FrmRepFacturas_Load(object sender, EventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            dgvFacturas.Rows.Clear();
            List<Parametro> lParametros = new List<Parametro>();
            lParametros.Add(new Parametro("@año1", Convert.ToInt32(dtpFecha1.Value.Year)));
            lParametros.Add(new Parametro("@año2", Convert.ToInt32(dtpFecha2.Value.Year)));

            DataTable tabla = oDao.ConsultarDB("Reportes_Facturas", lParametros);
            foreach(DataRow fila in tabla.Rows)
            {
                dgvFacturas.Rows.Add(fila[0].ToString(),
                                    fila[1].ToString(),
                                    fila[2].ToString(),
                                    fila[3].ToString(),
                                    fila[4].ToString(),
                                    fila[5].ToString(),
                                    fila[6].ToString()
               );
            }
        }

        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpFecha2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpFecha1_ValueChanged(object sender, EventArgs e)
        {

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
    }
}
