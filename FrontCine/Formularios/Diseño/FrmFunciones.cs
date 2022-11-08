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

namespace FrontCine.Formularios.Diseño
{
    public partial class FrmFunciones : Form
    {
        private Funcion oFuncion;
        private IFuncionesDAO oDao;
        private List<Funcion> lFunciones;
        private static FrmFunciones instancia;

        public static FrmFunciones ObtenerInstancia()
        {
            if (instancia == null) instancia = new FrmFunciones();
            return instancia;
        }
        public FrmFunciones()
        {
            InitializeComponent();
            oFuncion = new Funcion();
            oDao = new FuncionesDAO();
            lFunciones = new List<Funcion>();
        }

        private void FrmFunciones_Load(object sender, EventArgs e)
        {
            Habilitar(false);
            CargarCombo(cboSala, "combo_salas");
            CargarCombo(cboPelicula, "Combo_Peliculas");
            CargarCombo(cboSala, "Combo_Salas");
            CargarCombo(cboFormato, "Combo_formatos");
            CargarLista();
            Limpiar();
        }

        private void Habilitar(bool x)
        {
            btnNuevo.Enabled = !x;
            btnEnviar.Enabled = x;
            btnCancelar.Enabled = x;
            btnEliminar.Enabled = x;
            btnEditar.Enabled = x;
            btnSalir.Enabled = !x;
            dtpFechaHora.Enabled = x;
            cboHorario.Enabled = x;
            txtPrecio.Enabled = x;
            cboPelicula.Enabled = x;
            cboSala.Enabled = x;
            cboFormato.Enabled = x;
        }
        private void CargarCombo(ComboBox cbo, string sp)
        {
            DataTable tabla = oDao.ConsultarDB(sp, null);
            cbo.DataSource = tabla;
            cbo.ValueMember = tabla.Columns[0].ColumnName;
            cbo.DisplayMember = tabla.Columns[1].ColumnName;
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void CargarLista()
        {
            lstFunciones.Items.Clear();
            lFunciones.Clear();
            DataTable tabla = oDao.ConsultarDB("Consultar_Lista_Funciones", null);

            foreach (DataRow r in tabla.Rows)
            {
                Funcion funcion = new Funcion();
                funcion.IdFuncion = (int)r[0];
                funcion.Fecha = r[2].ToString();
                funcion.Horario = r[1].ToString();
                funcion.IdPelicula = (int)r[3];
                funcion.IdSala = (int)r[5];
                funcion.IdFormato = (int)r[7];
                funcion.Precio = Convert.ToDouble(r[10]);

                lFunciones.Add(funcion);

                lstFunciones.Items.Add(funcion.IdFuncion.ToString() + " - "
                                        + r[4].ToString() + " - "
                                        + "Idioma: " + r[9].ToString() + " - "
                                        + "Formato: " + r[8].ToString() + " - "
                                        + "Sala: " + r[6].ToString() + " - "
                                        + "Precio: " + r[10].ToString() + " - "
                                        + r[2].ToString() + " - "
                                        + r[1].ToString());
            }
        }

        private void MostrarDatos(int posicion)
        {
            dtpFechaHora.Value = Convert.ToDateTime(lFunciones[posicion].Fecha);
            cboHorario.Text = lFunciones[posicion].Horario.ToString();
            txtPrecio.Text = lFunciones[posicion].Precio.ToString();
            cboPelicula.SelectedIndex = lFunciones[posicion].IdPelicula - 1 ;
            cboSala.SelectedIndex = lFunciones[posicion].IdSala -1;
            cboFormato.SelectedIndex = lFunciones[posicion].IdFormato - 1;

        }
        private void Limpiar()
        {
            dtpFechaHora.Value = DateTime.Today;
            cboHorario.SelectedIndex = -1;
            txtPrecio.Text = string.Empty;
            cboPelicula.SelectedIndex = -1;
            cboSala.SelectedIndex = -1;
            cboFormato.SelectedIndex = -1;

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Habilitar(true);
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Habilitar(true);
            MostrarDatos(lstFunciones.SelectedIndex);
            cboPelicula.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Habilitar(false);
            Limpiar();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtPrecio.Text == string.Empty)
            {
                MessageBox.Show("No se cargo un precio", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecio.Focus();
                return;
            }
            if (cboHorario.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un horario", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboHorario.Focus();
                return;
            }
            if (cboPelicula.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una pelicula", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboPelicula.Focus();
                return;
            }
            if (cboSala.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una sala", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboSala.Focus();
                return;
            }
            if (cboFormato.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un formato", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboFormato.Focus();
                return;
            }

            oFuncion.Fecha = dtpFechaHora.Value.ToString();
            oFuncion.Horario = cboHorario.Text;
            oFuncion.IdPelicula = cboPelicula.SelectedIndex + 1;
            oFuncion.IdSala = cboSala.SelectedIndex +1;
            oFuncion.IdFormato = cboFormato.SelectedIndex + 1;

            List<Parametro> lParametros = new List<Parametro>();
            lParametros.Add(new Parametro("@fecha", oFuncion.Fecha));
            lParametros.Add(new Parametro("@precio", Convert.ToDouble(txtPrecio.Text))); 
            lParametros.Add(new Parametro("@id_pelicula", oFuncion.IdPelicula));
            lParametros.Add(new Parametro("@id_sala", oFuncion.IdSala));
            lParametros.Add(new Parametro("@id_formato", oFuncion.IdFormato));
            lParametros.Add(new Parametro("@hora", oFuncion.Horario));
            if (cboPelicula.Enabled)
            {
                if (oDao.EjecutarSQL("Insertar_Funciones", lParametros) > 0)
                {
                    MessageBox.Show("se ha podido ingresar la función", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Habilitar(false);
                    Limpiar();
                    CargarLista();
                }
                else
                {
                    MessageBox.Show("No se ha podido ingresar la función", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                lParametros.Add(new Parametro("@id_funcion", lFunciones[lstFunciones.SelectedIndex].IdFuncion));
                if (oDao.EjecutarSQL("actualizar_Funciones", lParametros) > 0)
                {
                    MessageBox.Show("se ha podido actualizar la función", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Habilitar(false);
                    Limpiar();
                    CargarLista();
                }
                else
                {
                    MessageBox.Show("No se ha podido actualizar la función", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }
            

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            List<Parametro> lParametros = new List<Parametro>();
            lParametros.Add(new Parametro("@id", lFunciones[lstFunciones.SelectedIndex].IdFuncion));
            if(oDao.EjecutarSQL("Eliminar_Funciones", lParametros) > 0)
            {
                MessageBox.Show("Se ha podido eliminar la función", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lstFunciones.Items.RemoveAt(lstFunciones.SelectedIndex);
                Habilitar(false);
                Limpiar();
                CargarLista();
                return;
            }
            else
            {
                MessageBox.Show("No se ha podido eliminar la función", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
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

        private void lstFunciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDatos(lstFunciones.SelectedIndex);
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnNuevo.Enabled = false;
            btnCancelar.Enabled = true;
        }

        private void cboPelicula_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Parametro> lParametros = new List<Parametro>();
            lParametros.Add(new Parametro("@id_pelicula", cboPelicula.SelectedIndex + 1));

            DataTable tabla = oDao.ConsultarDB("consultar_idioma", lParametros);
            cboIdiomas.DataSource = tabla;
            cboIdiomas.ValueMember = tabla.Columns[0].ColumnName;
            cboIdiomas.DisplayMember = tabla.Columns[1].ColumnName;
            cboIdiomas.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
