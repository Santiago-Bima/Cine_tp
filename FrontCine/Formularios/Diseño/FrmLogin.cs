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
    public partial class FrmLogin : Form
    {
        private static FrmLogin instancia;
        public static FrmLogin ObtenerInstancia()
        {
            if (instancia == null) instancia = new FrmLogin();
            return instancia;
        }
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" && txtPassword.Text == "")
            {
                MessageBox.Show("Ingrese un Usuario y una contraseña", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (txtUsuario.Text != "" && txtPassword.Text != "")
            {
                if (txtUsuario.Text == "Admin" && txtPassword.Text == "Pass")
                {
                    FrmPrincipal frmPrincipal = FrmPrincipal.ObtenerInstancia();
                    frmPrincipal.Show();
                    Hide();
                }
            }
        }

        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrar.Checked) txtPassword.UseSystemPasswordChar = false;
            else txtPassword.UseSystemPasswordChar = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
