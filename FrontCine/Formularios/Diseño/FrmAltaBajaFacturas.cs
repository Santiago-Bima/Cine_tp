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
    public partial class FrmAltaBajaFacturas : Form
    {
        private static FrmAltaBajaFacturas instancia;

        public static FrmAltaBajaFacturas ObtenerInstancia()
        {
            if (instancia == null) instancia = new FrmAltaBajaFacturas();
            return instancia;
        }
        public FrmAltaBajaFacturas()
        {
            InitializeComponent();
        }

        private void FrmAltaBajaFacturas_Load(object sender, EventArgs e)
        {

        }
    }
}
