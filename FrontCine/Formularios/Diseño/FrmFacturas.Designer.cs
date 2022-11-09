namespace FrontCine.Formularios.Diseño
{
    partial class FrmFacturas
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
            this.label11 = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblNroFactura = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblCantTickets = new System.Windows.Forms.Label();
            this.cboFormasPago = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboButacas = new System.Windows.Forms.ComboBox();
            this.cboClientes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboFunciones = new System.Windows.Forms.ComboBox();
            this.dgvTickets = new System.Windows.Forms.DataGridView();
            this.idFuncion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFuncion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSala = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colButaca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdioma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFormato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cboSala = new System.Windows.Forms.ComboBox();
            this.cboIdioma = new System.Windows.Forms.ComboBox();
            this.cboFormato = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(606, 140);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 25);
            this.label11.TabIndex = 21;
            this.label11.Text = "Sala:";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Location = new System.Drawing.Point(795, 683);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(84, 25);
            this.lblSubTotal.TabIndex = 28;
            this.lblSubTotal.Text = "SubTotal:";
            // 
            // txtHora
            // 
            this.txtHora.Enabled = false;
            this.txtHora.Location = new System.Drawing.Point(957, 93);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(111, 31);
            this.txtHora.TabIndex = 5;
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Location = new System.Drawing.Point(686, 94);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(193, 31);
            this.txtFecha.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(570, 225);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 25);
            this.label9.TabIndex = 23;
            this.label9.Text = "Formato:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(582, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 25);
            this.label8.TabIndex = 22;
            this.label8.Text = "Idioma:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Enabled = false;
            this.txtPrecio.Location = new System.Drawing.Point(573, 285);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(176, 31);
            this.txtPrecio.TabIndex = 9;
            // 
            // lblNroFactura
            // 
            this.lblNroFactura.AutoSize = true;
            this.lblNroFactura.Location = new System.Drawing.Point(27, 26);
            this.lblNroFactura.Name = "lblNroFactura";
            this.lblNroFactura.Size = new System.Drawing.Size(192, 25);
            this.lblNroFactura.TabIndex = 15;
            this.lblNroFactura.Text = "Número de Factura: N°";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(165, 177);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(208, 31);
            this.txtDescuento.TabIndex = 2;
            this.txtDescuento.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 25);
            this.label10.TabIndex = 18;
            this.label10.Text = "Descuento:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(826, 718);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(53, 25);
            this.lblTotal.TabIndex = 29;
            this.lblTotal.Text = "Total:";
            // 
            // lblCantTickets
            // 
            this.lblCantTickets.AutoSize = true;
            this.lblCantTickets.Location = new System.Drawing.Point(715, 648);
            this.lblCantTickets.Name = "lblCantTickets";
            this.lblCantTickets.Size = new System.Drawing.Size(164, 25);
            this.lblCantTickets.TabIndex = 27;
            this.lblCantTickets.Text = "Cantiad de Tickets: ";
            // 
            // cboFormasPago
            // 
            this.cboFormasPago.FormattingEnabled = true;
            this.cboFormasPago.Location = new System.Drawing.Point(165, 129);
            this.cboFormasPago.Name = "cboFormasPago";
            this.cboFormasPago.Size = new System.Drawing.Size(383, 33);
            this.cboFormasPago.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 25);
            this.label7.TabIndex = 17;
            this.label7.Text = "Forma de Pago:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(896, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 25);
            this.label6.TabIndex = 25;
            this.label6.Text = "Hora:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(593, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 25);
            this.label5.TabIndex = 20;
            this.label5.Text = "Fecha:";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(587, 718);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(134, 48);
            this.btnSalir.TabIndex = 14;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(401, 718);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(131, 48);
            this.btnAceptar.TabIndex = 13;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(970, 282);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(112, 34);
            this.btnAgregar.TabIndex = 11;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(755, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 25);
            this.label4.TabIndex = 26;
            this.label4.Text = "Butaca:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "Cliente:";
            // 
            // cboButacas
            // 
            this.cboButacas.FormattingEnabled = true;
            this.cboButacas.Location = new System.Drawing.Point(829, 282);
            this.cboButacas.Name = "cboButacas";
            this.cboButacas.Size = new System.Drawing.Size(122, 33);
            this.cboButacas.TabIndex = 10;
            this.cboButacas.SelectedIndexChanged += new System.EventHandler(this.cboButacas_SelectedIndexChanged);
            // 
            // cboClientes
            // 
            this.cboClientes.FormattingEnabled = true;
            this.cboClientes.Location = new System.Drawing.Point(165, 78);
            this.cboClientes.Name = "cboClientes";
            this.cboClientes.Size = new System.Drawing.Size(382, 33);
            this.cboClientes.TabIndex = 0;
            this.cboClientes.SelectedIndexChanged += new System.EventHandler(this.cboClientes_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(503, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 24;
            this.label2.Text = "Precio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "Función:";
            // 
            // cboFunciones
            // 
            this.cboFunciones.FormattingEnabled = true;
            this.cboFunciones.Location = new System.Drawing.Point(106, 282);
            this.cboFunciones.Name = "cboFunciones";
            this.cboFunciones.Size = new System.Drawing.Size(391, 33);
            this.cboFunciones.TabIndex = 3;
            this.cboFunciones.SelectedIndexChanged += new System.EventHandler(this.cboFunciones_SelectedIndexChanged);
            // 
            // dgvTickets
            // 
            this.dgvTickets.AllowUserToAddRows = false;
            this.dgvTickets.AllowUserToDeleteRows = false;
            this.dgvTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTickets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idFuncion,
            this.colFuncion,
            this.colSala,
            this.colButaca,
            this.colFecha,
            this.colHora,
            this.colIdioma,
            this.colFormato,
            this.colPrecio,
            this.colAccion});
            this.dgvTickets.Location = new System.Drawing.Point(27, 342);
            this.dgvTickets.Name = "dgvTickets";
            this.dgvTickets.RowHeadersWidth = 62;
            this.dgvTickets.RowTemplate.Height = 33;
            this.dgvTickets.ShowEditingIcon = false;
            this.dgvTickets.Size = new System.Drawing.Size(1060, 273);
            this.dgvTickets.TabIndex = 12;
            this.dgvTickets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTickets_CellContentClick);
            // 
            // idFuncion
            // 
            this.idFuncion.HeaderText = "idFuncion";
            this.idFuncion.MinimumWidth = 8;
            this.idFuncion.Name = "idFuncion";
            this.idFuncion.Visible = false;
            this.idFuncion.Width = 150;
            // 
            // colFuncion
            // 
            this.colFuncion.HeaderText = "Funcion";
            this.colFuncion.MinimumWidth = 8;
            this.colFuncion.Name = "colFuncion";
            this.colFuncion.Width = 200;
            // 
            // colSala
            // 
            this.colSala.HeaderText = "Sala";
            this.colSala.MinimumWidth = 8;
            this.colSala.Name = "colSala";
            this.colSala.Width = 80;
            // 
            // colButaca
            // 
            this.colButaca.HeaderText = "Butaca";
            this.colButaca.MinimumWidth = 8;
            this.colButaca.Name = "colButaca";
            this.colButaca.Width = 80;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.MinimumWidth = 8;
            this.colFecha.Name = "colFecha";
            this.colFecha.Width = 150;
            // 
            // colHora
            // 
            this.colHora.HeaderText = "Hora";
            this.colHora.MinimumWidth = 8;
            this.colHora.Name = "colHora";
            this.colHora.Width = 130;
            // 
            // colIdioma
            // 
            this.colIdioma.HeaderText = "Idioma";
            this.colIdioma.MinimumWidth = 8;
            this.colIdioma.Name = "colIdioma";
            this.colIdioma.Width = 80;
            // 
            // colFormato
            // 
            this.colFormato.HeaderText = "Formato";
            this.colFormato.MinimumWidth = 8;
            this.colFormato.Name = "colFormato";
            this.colFormato.Width = 80;
            // 
            // colPrecio
            // 
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.MinimumWidth = 8;
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.Width = 110;
            // 
            // colAccion
            // 
            this.colAccion.HeaderText = "Acciones";
            this.colAccion.MinimumWidth = 8;
            this.colAccion.Name = "colAccion";
            this.colAccion.Text = "Eliminar";
            this.colAccion.ToolTipText = "Eliminar";
            this.colAccion.Width = 85;
            // 
            // cboSala
            // 
            this.cboSala.Enabled = false;
            this.cboSala.FormattingEnabled = true;
            this.cboSala.Items.AddRange(new object[] {
            "Débito",
            "Efectivo",
            "Crédito"});
            this.cboSala.Location = new System.Drawing.Point(686, 137);
            this.cboSala.Name = "cboSala";
            this.cboSala.Size = new System.Drawing.Size(193, 33);
            this.cboSala.TabIndex = 6;
            // 
            // cboIdioma
            // 
            this.cboIdioma.Enabled = false;
            this.cboIdioma.FormattingEnabled = true;
            this.cboIdioma.Items.AddRange(new object[] {
            "Débito",
            "Efectivo",
            "Crédito"});
            this.cboIdioma.Location = new System.Drawing.Point(686, 180);
            this.cboIdioma.Name = "cboIdioma";
            this.cboIdioma.Size = new System.Drawing.Size(193, 33);
            this.cboIdioma.TabIndex = 7;
            // 
            // cboFormato
            // 
            this.cboFormato.Enabled = false;
            this.cboFormato.FormattingEnabled = true;
            this.cboFormato.Items.AddRange(new object[] {
            "Débito",
            "Efectivo",
            "Crédito"});
            this.cboFormato.Location = new System.Drawing.Point(686, 222);
            this.cboFormato.Name = "cboFormato";
            this.cboFormato.Size = new System.Drawing.Size(193, 33);
            this.cboFormato.TabIndex = 8;
            // 
            // FrmFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 792);
            this.Controls.Add(this.cboFormato);
            this.Controls.Add(this.cboIdioma);
            this.Controls.Add(this.cboSala);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.txtHora);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lblNroFactura);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblCantTickets);
            this.Controls.Add(this.cboFormasPago);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboButacas);
            this.Controls.Add(this.cboClientes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboFunciones);
            this.Controls.Add(this.dgvTickets);
            this.Name = "FrmFacturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturas";
            this.Load += new System.EventHandler(this.FrmFacturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label11;
        private Label lblSubTotal;
        private TextBox txtHora;
        private TextBox txtFecha;
        private Label label9;
        private Label label8;
        private TextBox txtPrecio;
        private Label lblNroFactura;
        private TextBox txtDescuento;
        private Label label10;
        private Label lblTotal;
        private Label lblCantTickets;
        private ComboBox cboFormasPago;
        private Label label7;
        private Label label6;
        private Label label5;
        private Button btnSalir;
        private Button btnAceptar;
        private Button btnAgregar;
        private Label label4;
        private Label label3;
        private ComboBox cboButacas;
        private ComboBox cboClientes;
        private Label label2;
        private Label label1;
        private ComboBox cboFunciones;
        private DataGridView dgvTickets;
        private ComboBox cboSala;
        private ComboBox cboIdioma;
        private ComboBox cboFormato;
        private DataGridViewTextBoxColumn idFuncion;
        private DataGridViewTextBoxColumn colFuncion;
        private DataGridViewTextBoxColumn colSala;
        private DataGridViewTextBoxColumn colButaca;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colHora;
        private DataGridViewTextBoxColumn colIdioma;
        private DataGridViewTextBoxColumn colFormato;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewButtonColumn colAccion;
    }
}