using FrontCine.Http;
using LibreriaApi.Data;
using LibreriaApi.Data.Implementaciones;
using LibreriaApi.Data.Interfaces;
using LibreriaApi.Dominio;
using Newtonsoft.Json;
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
            try
            {

                dtpFechaHora.Value = Convert.ToDateTime(lFunciones[posicion].Fecha);
                cboHorario.Text = lFunciones[posicion].Horario.ToString();
                txtPrecio.Text = lFunciones[posicion].Precio.ToString();
                cboPelicula.SelectedIndex = lFunciones[posicion].IdPelicula - 1;
                cboSala.SelectedIndex = lFunciones[posicion].IdSala - 1;
                cboFormato.SelectedIndex = lFunciones[posicion].IdFormato - 1;
            }
            catch (Exception) { }

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

        private async void btnEnviar_Click(object sender, EventArgs e)
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


            oFuncion.Fecha = dtpFechaHora.Text;
            oFuncion.Horario = cboHorario.Text;
            oFuncion.IdPelicula = cboPelicula.SelectedIndex + 1;
            oFuncion.IdSala = cboSala.SelectedIndex + 1;
            oFuncion.IdFormato = cboFormato.SelectedIndex + 1;
            oFuncion.Precio = Convert.ToDouble(txtPrecio.Text);
            oFuncion.Titulo = cboPelicula.Text;


            if (!Existe(oFuncion))
            {
                List<Parametro> lParametros = new List<Parametro>();
                lParametros.Add(new Parametro("@fecha", oFuncion.Fecha));
                lParametros.Add(new Parametro("@precio", oFuncion.Precio));
                lParametros.Add(new Parametro("@id_pelicula", oFuncion.IdPelicula));
                lParametros.Add(new Parametro("@id_sala", oFuncion.IdSala));
                lParametros.Add(new Parametro("@id_formato", oFuncion.IdFormato));
                lParametros.Add(new Parametro("@hora", oFuncion.Horario));

                if (cboPelicula.Enabled)
                {
                    if (await PostearFuncion(oFuncion) == true)
                    {
                        MessageBox.Show("Función registrada", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Habilitar(false);
                        Limpiar();
                        CargarLista();
                    }
                    else
                    {
                        MessageBox.Show("ERROR. No se pudo registrar la Función", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    oFuncion.IdFuncion = lFunciones[lstFunciones.SelectedIndex].IdFuncion;


                    if (await EditarFuncion(oFuncion) == true)
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
            else
            {
                MessageBox.Show("Ya existe esta función", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private bool Existe(Funcion funcion)
        {
            for (int i = 0; i < lFunciones.Count; i++)
            {
                if (lFunciones[i].IdFormato == funcion.IdFormato && 
                    lFunciones[i].IdSala == funcion.IdSala && 
                    lFunciones[i].IdPelicula == funcion.IdPelicula && 
                    lFunciones[i].Fecha == funcion.Fecha && 
                    lFunciones[i].Horario == funcion.Horario) return true;
            }

            return false;
        }

        private async Task<bool> PostearFuncion(Funcion oFuncion)
        {
            string bodyContent = JsonConvert.SerializeObject(oFuncion);

            string url = "http://localhost:5115/savefuncion";
            var result = await ClientSingleton.GetInstance().PostAsync(url, bodyContent);

            return result.Equals("true");
        }

        private async Task<bool> EditarFuncion(Funcion oFuncion)
        {
            string bodyContent = JsonConvert.SerializeObject(oFuncion);

            string url = "http://localhost:5115/editfuncion";
            var result = await ClientSingleton.GetInstance().UpdateAsync(url, bodyContent);

            return result.Equals("true");
        }


        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (await EliminarFuncion(lFunciones) == true)
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

        private async Task<bool> EliminarFuncion(List<Funcion> lFunciones)
        {
            string url = $"http://localhost:5115/deletefuncion/{lFunciones[lstFunciones.SelectedIndex].IdFuncion}";
            var result = await ClientSingleton.GetInstance().DeleteAsync(url);

            return result.Equals("true");
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
            try
            {
                MostrarDatos(lstFunciones.SelectedIndex);
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                btnNuevo.Enabled = false;
                btnCancelar.Enabled = true;
            }
            catch (Exception) { }
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
