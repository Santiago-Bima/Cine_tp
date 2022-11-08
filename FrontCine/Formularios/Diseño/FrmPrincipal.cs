using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontCine.Formularios.Diseño
{
    public partial class FrmPrincipal : Form
    {
        private static FrmPrincipal instancia;
        

        public static FrmPrincipal ObtenerInstancia()
        {
            if (instancia == null) instancia = new FrmPrincipal();
            return instancia;
        }
        public FrmPrincipal()
        {
            InitializeComponent();
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar la sesion?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                FrmLogin frmLogin = FrmLogin.ObtenerInstancia();
                frmLogin.Show();
                this.Hide();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir del formulario?",
                "saliendo...",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes) Close();
        }

        private void funcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFunciones frmFunciones = FrmFunciones.ObtenerInstancia();
            frmFunciones.Show();
            frmFunciones.Focus();
        }

        private void nuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFacturas frmFacturas = FrmFacturas.ObtenerInstancia();
            frmFacturas.Show();
            frmFacturas.Focus();
        }

        private void darDeAltaBajaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmAltaBajaFacturas frmAltaBajaFacturas = FrmAltaBajaFacturas.ObtenerInstancia();
            frmAltaBajaFacturas.Show();
            frmAltaBajaFacturas.Focus();
        }

        private void quienesSomosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mensaje = "Proyecto de cine \n" + "Integrantes:  \n" + "112961 - Alfonso Juan Manuel \n" + "114219 - Barrera Mariano \n" + "114191 - Corvalán María Victoria \n" + "114007 - Bima Santiago \n" + "114039 - Pastor Jonás Alejandro";
            MessageBox.Show(mensaje, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
