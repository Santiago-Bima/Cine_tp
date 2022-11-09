namespace FrontCine.Formularios.Reportes
{
    partial class FrmRepFacturas
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
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.IdFuncion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPelicula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIdioma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGenero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFormato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(38, 442);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(172, 48);
            this.btnFiltrar.TabIndex = 0;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha Desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(385, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha Hasta: ";
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.AllowUserToAddRows = false;
            this.dgvFacturas.AllowUserToDeleteRows = false;
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdFuncion,
            this.ColPelicula,
            this.ColIdioma,
            this.ColGenero,
            this.ColFormato,
            this.ColFecha,
            this.ColTotal});
            this.dgvFacturas.Location = new System.Drawing.Point(38, 107);
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.RowHeadersWidth = 62;
            this.dgvFacturas.RowTemplate.Height = 33;
            this.dgvFacturas.Size = new System.Drawing.Size(965, 309);
            this.dgvFacturas.TabIndex = 3;
            this.dgvFacturas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacturas_CellContentClick);
            // 
            // dtpFecha1
            // 
            this.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha1.Location = new System.Drawing.Point(172, 34);
            this.dtpFecha1.Name = "dtpFecha1";
            this.dtpFecha1.Size = new System.Drawing.Size(155, 31);
            this.dtpFecha1.TabIndex = 4;
            this.dtpFecha1.ValueChanged += new System.EventHandler(this.dtpFecha1_ValueChanged);
            // 
            // dtpFecha2
            // 
            this.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha2.Location = new System.Drawing.Point(508, 35);
            this.dtpFecha2.Name = "dtpFecha2";
            this.dtpFecha2.Size = new System.Drawing.Size(150, 31);
            this.dtpFecha2.TabIndex = 5;
            this.dtpFecha2.ValueChanged += new System.EventHandler(this.dtpFecha2_ValueChanged);
            // 
            // IdFuncion
            // 
            this.IdFuncion.HeaderText = "Id";
            this.IdFuncion.MinimumWidth = 8;
            this.IdFuncion.Name = "IdFuncion";
            this.IdFuncion.Visible = false;
            this.IdFuncion.Width = 150;
            // 
            // ColPelicula
            // 
            this.ColPelicula.HeaderText = "Pelicula";
            this.ColPelicula.MinimumWidth = 8;
            this.ColPelicula.Name = "ColPelicula";
            this.ColPelicula.Width = 150;
            // 
            // ColIdioma
            // 
            this.ColIdioma.HeaderText = "Idioma";
            this.ColIdioma.MinimumWidth = 8;
            this.ColIdioma.Name = "ColIdioma";
            this.ColIdioma.Width = 150;
            // 
            // ColGenero
            // 
            this.ColGenero.HeaderText = "Genero";
            this.ColGenero.MinimumWidth = 8;
            this.ColGenero.Name = "ColGenero";
            this.ColGenero.Width = 150;
            // 
            // ColFormato
            // 
            this.ColFormato.HeaderText = "Formato";
            this.ColFormato.MinimumWidth = 8;
            this.ColFormato.Name = "ColFormato";
            this.ColFormato.Width = 150;
            // 
            // ColFecha
            // 
            this.ColFecha.HeaderText = "Fecha";
            this.ColFecha.MinimumWidth = 8;
            this.ColFecha.Name = "ColFecha";
            this.ColFecha.Width = 150;
            // 
            // ColTotal
            // 
            this.ColTotal.HeaderText = "Total Vendido";
            this.ColTotal.MinimumWidth = 8;
            this.ColTotal.Name = "ColTotal";
            this.ColTotal.Width = 150;
            // 
            // FrmRepFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 502);
            this.Controls.Add(this.dtpFecha2);
            this.Controls.Add(this.dtpFecha1);
            this.Controls.Add(this.dgvFacturas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFiltrar);
            this.Name = "FrmRepFacturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Facturas";
            this.Load += new System.EventHandler(this.FrmRepFacturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnFiltrar;
        private Label label1;
        private Label label2;
        private DataGridView dgvFacturas;
        private DateTimePicker dtpFecha1;
        private DateTimePicker dtpFecha2;
        private DataGridViewTextBoxColumn IdFuncion;
        private DataGridViewTextBoxColumn ColPelicula;
        private DataGridViewTextBoxColumn ColIdioma;
        private DataGridViewTextBoxColumn ColGenero;
        private DataGridViewTextBoxColumn ColFormato;
        private DataGridViewTextBoxColumn ColFecha;
        private DataGridViewTextBoxColumn ColTotal;
    }
}