namespace FrontCine.Formularios.Reportes
{
    partial class FrmRepFunciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvFunciones = new System.Windows.Forms.DataGridView();
            this.ColTitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIdioma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFormato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGenero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCantVendidas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboGenero = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFunciones
            // 
            this.dgvFunciones.AllowUserToAddRows = false;
            this.dgvFunciones.AllowUserToDeleteRows = false;
            this.dgvFunciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFunciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColTitulo,
            this.ColIdioma,
            this.ColFecha,
            this.ColHora,
            this.dataGridViewTextBoxColumn1,
            this.ColFormato,
            this.ColGenero,
            this.ColCantVendidas});
            this.dgvFunciones.Location = new System.Drawing.Point(12, 78);
            this.dgvFunciones.Name = "dgvFunciones";
            this.dgvFunciones.RowHeadersWidth = 62;
            this.dgvFunciones.RowTemplate.Height = 33;
            this.dgvFunciones.Size = new System.Drawing.Size(1264, 349);
            this.dgvFunciones.TabIndex = 0;
            this.dgvFunciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFunciones_CellContentClick);
            // 
            // ColTitulo
            // 
            this.ColTitulo.HeaderText = "Titulo";
            this.ColTitulo.MinimumWidth = 8;
            this.ColTitulo.Name = "ColTitulo";
            this.ColTitulo.Width = 150;
            // 
            // ColIdioma
            // 
            this.ColIdioma.HeaderText = "Idioma";
            this.ColIdioma.MinimumWidth = 8;
            this.ColIdioma.Name = "ColIdioma";
            this.ColIdioma.Width = 150;
            // 
            // ColFecha
            // 
            this.ColFecha.HeaderText = "Fecha";
            this.ColFecha.MinimumWidth = 8;
            this.ColFecha.Name = "ColFecha";
            this.ColFecha.Width = 150;
            // 
            // ColHora
            // 
            this.ColHora.HeaderText = "Hora";
            this.ColHora.MinimumWidth = 8;
            this.ColHora.Name = "ColHora";
            this.ColHora.Width = 150;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Idioma";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // ColFormato
            // 
            this.ColFormato.HeaderText = "Formato";
            this.ColFormato.MinimumWidth = 8;
            this.ColFormato.Name = "ColFormato";
            this.ColFormato.Width = 150;
            // 
            // ColGenero
            // 
            this.ColGenero.HeaderText = "Genero";
            this.ColGenero.MinimumWidth = 8;
            this.ColGenero.Name = "ColGenero";
            this.ColGenero.Width = 150;
            // 
            // ColCantVendidas
            // 
            this.ColCantVendidas.HeaderText = "Cantidad Vendida";
            this.ColCantVendidas.MinimumWidth = 8;
            this.ColCantVendidas.Name = "ColCantVendidas";
            this.ColCantVendidas.Width = 150;
            // 
            // cboGenero
            // 
            this.cboGenero.FormattingEnabled = true;
            this.cboGenero.Location = new System.Drawing.Point(113, 26);
            this.cboGenero.Name = "cboGenero";
            this.cboGenero.Size = new System.Drawing.Size(182, 33);
            this.cboGenero.TabIndex = 1;
            this.cboGenero.SelectedIndexChanged += new System.EventHandler(this.cboGenero_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Generos: ";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(21, 475);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(142, 61);
            this.btnFiltrar.TabIndex = 3;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // FrmRepFunciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 561);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboGenero);
            this.Controls.Add(this.dgvFunciones);
            this.Name = "FrmRepFunciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Funciones";
            this.Load += new System.EventHandler(this.FrmRepFunciones_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvFunciones;
        private ComboBox cboGenero;
        private Label label1;
        private Button btnFiltrar;
        private DataGridViewTextBoxColumn ColTitulo;
        private DataGridViewTextBoxColumn ColIdioma;
        private DataGridViewTextBoxColumn ColFecha;
        private DataGridViewTextBoxColumn ColHora;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn ColFormato;
        private DataGridViewTextBoxColumn ColGenero;
        private DataGridViewTextBoxColumn ColCantVendidas;
    }
}