using FrontCine.Formularios.Diseño;
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
using System.Windows.Forms;

namespace FrontCine.Formularios.Reportes
{
    public partial class FrmRepFunciones : Form
    {
        private Funcion oFuncion;
        private ITicketsDAO oDao;
        private List<Funcion> lFunciones;
        private static FrmRepFunciones instancia;

        public static FrmRepFunciones ObtenerInstancia()
        {
            if (instancia == null) instancia = new FrmRepFunciones();
            return instancia;
        }


        public FrmRepFunciones()
        {
            InitializeComponent();
            oFuncion = new Funcion();
            oDao = new TicketsDAO();
            lFunciones = new List<Funcion>();
        }

        private void FrmRepFunciones_Load(object sender, EventArgs e)
        {
            CargarCombos(cboGenero,"combo_generos");
        }

        private void CargarCombos(ComboBox cbo, string sp)
        {
            DataTable tabla = oDao.ConsultarDB(sp, null);
            cbo.DataSource = tabla;
            cbo.ValueMember = tabla.Columns[0].ColumnName;
            cbo.DisplayMember = tabla.Columns[1].ColumnName;
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            dgvFunciones.Rows.Clear();
            DataTable tabla = oDao.

        }

        private void dgvFunciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmRepFunciones_Load_1(object sender, EventArgs e)
        {

        }
    }
}
