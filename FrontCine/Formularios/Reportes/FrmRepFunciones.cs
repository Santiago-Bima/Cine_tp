using FrontCine.Formularios.Diseño;
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
using System.Windows.Forms;

namespace FrontCine.Formularios.Reportes
{
    public partial class FrmRepFunciones : Form
    {
        private Funcion oFuncion;
        private IFuncionesDAO oDao;
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
            oDao = new FuncionesDAO();
            lFunciones = new List<Funcion>();
        }



        private void FrmRepFunciones_Load_1(object sender, EventArgs e)
        {
            CargarCombos(cboGenero, "combo_generos");
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
            List<Parametro> lParametros = new List<Parametro>();
            lParametros.Add(new Parametro("@genero", cboGenero.SelectedValue));

            DataTable tabla = oDao.ConsultarDB("Reportes_funciones", lParametros);
            foreach (DataRow fila in tabla.Rows)
            {
                dgvFunciones.Rows.Add(fila[0].ToString(),
                                    fila[1].ToString(),
                                    fila[2].ToString(),
                                    fila[3].ToString(),
                                    fila[4].ToString(),
                                    fila[5].ToString(),
                                    fila[6].ToString(),
                                    fila[7].ToString()
               );
            }


        }

        private void dgvFunciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click_1(object sender, EventArgs e)
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
