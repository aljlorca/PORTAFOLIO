namespace MercadoChile.Template
{
    partial class Postulacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Postulacion));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDescVenta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnIngresarSubasta = new System.Windows.Forms.Button();
            this.btnSelccVenta = new System.Windows.Forms.Button();
            this.btnListarVent = new System.Windows.Forms.Button();
            this.DgvVenta = new System.Windows.Forms.DataGridView();
            this.cnDescripionVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnClienteExterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBusVenta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTamaño = new System.Windows.Forms.TextBox();
            this.btnSelSub = new System.Windows.Forms.Button();
            this.txtRefrigeracion = new System.Windows.Forms.TextBox();
            this.btnListarSub = new System.Windows.Forms.Button();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtCapacidad = new System.Windows.Forms.TextBox();
            this.txtTransportista = new System.Windows.Forms.TextBox();
            this.btnPublicar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.DgvSubasta = new System.Windows.Forms.DataGridView();
            this.cnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnTransportista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvVenta)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSubasta)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1043, 577);
            this.tabControl1.TabIndex = 109;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.btnSelccVenta);
            this.tabPage1.Controls.Add(this.btnListarVent);
            this.tabPage1.Controls.Add(this.DgvVenta);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1035, 551);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDescVenta);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnIngresarSubasta);
            this.groupBox2.Location = new System.Drawing.Point(403, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(552, 308);
            this.groupBox2.TabIndex = 114;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agregar Subasta";
            // 
            // txtDescVenta
            // 
            this.txtDescVenta.Location = new System.Drawing.Point(239, 63);
            this.txtDescVenta.Name = "txtDescVenta";
            this.txtDescVenta.Size = new System.Drawing.Size(214, 20);
            this.txtDescVenta.TabIndex = 90;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(72, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 20);
            this.label7.TabIndex = 88;
            this.label7.Text = "Descripcion Venta";
            // 
            // btnIngresarSubasta
            // 
            this.btnIngresarSubasta.FlatAppearance.BorderSize = 0;
            this.btnIngresarSubasta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnIngresarSubasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresarSubasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresarSubasta.Image = ((System.Drawing.Image)(resources.GetObject("btnIngresarSubasta.Image")));
            this.btnIngresarSubasta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngresarSubasta.Location = new System.Drawing.Point(157, 223);
            this.btnIngresarSubasta.Name = "btnIngresarSubasta";
            this.btnIngresarSubasta.Size = new System.Drawing.Size(216, 40);
            this.btnIngresarSubasta.TabIndex = 68;
            this.btnIngresarSubasta.Text = "Ingresar Carga";
            this.btnIngresarSubasta.UseVisualStyleBackColor = true;
            this.btnIngresarSubasta.Click += new System.EventHandler(this.btnIngresarSubasta_Click);
            // 
            // btnSelccVenta
            // 
            this.btnSelccVenta.FlatAppearance.BorderSize = 0;
            this.btnSelccVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSelccVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelccVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelccVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelccVenta.Location = new System.Drawing.Point(600, 404);
            this.btnSelccVenta.Name = "btnSelccVenta";
            this.btnSelccVenta.Size = new System.Drawing.Size(245, 40);
            this.btnSelccVenta.TabIndex = 113;
            this.btnSelccVenta.Text = " Selccione una Venta a Subastar";
            this.btnSelccVenta.UseVisualStyleBackColor = true;
            this.btnSelccVenta.Click += new System.EventHandler(this.btnSelccVenta_Click);
            // 
            // btnListarVent
            // 
            this.btnListarVent.FlatAppearance.BorderSize = 0;
            this.btnListarVent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnListarVent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListarVent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListarVent.Image = ((System.Drawing.Image)(resources.GetObject("btnListarVent.Image")));
            this.btnListarVent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListarVent.Location = new System.Drawing.Point(114, 404);
            this.btnListarVent.Name = "btnListarVent";
            this.btnListarVent.Size = new System.Drawing.Size(217, 40);
            this.btnListarVent.TabIndex = 112;
            this.btnListarVent.Text = "Listar";
            this.btnListarVent.UseVisualStyleBackColor = true;
            this.btnListarVent.Click += new System.EventHandler(this.btnListarVent_Click);
            // 
            // DgvVenta
            // 
            this.DgvVenta.AllowUserToAddRows = false;
            this.DgvVenta.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnDescripionVenta,
            this.cnClienteExterno});
            this.DgvVenta.Location = new System.Drawing.Point(114, 28);
            this.DgvVenta.Name = "DgvVenta";
            this.DgvVenta.Size = new System.Drawing.Size(234, 350);
            this.DgvVenta.TabIndex = 0;
            // 
            // cnDescripionVenta
            // 
            this.cnDescripionVenta.DataPropertyName = "descripcion_venta";
            this.cnDescripionVenta.HeaderText = "Descripcion Venta";
            this.cnDescripionVenta.Name = "cnDescripionVenta";
            // 
            // cnClienteExterno
            // 
            this.cnClienteExterno.DataPropertyName = "id_usuario";
            this.cnClienteExterno.HeaderText = "Cliente Externo";
            this.cnClienteExterno.Name = "cnClienteExterno";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txtBusVenta);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.DgvSubasta);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1035, 551);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(755, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 13);
            this.label1.TabIndex = 116;
            this.label1.Text = "---------------------------------------------------------------";
            // 
            // txtBusVenta
            // 
            this.txtBusVenta.Location = new System.Drawing.Point(758, 168);
            this.txtBusVenta.Name = "txtBusVenta";
            this.txtBusVenta.Size = new System.Drawing.Size(193, 20);
            this.txtBusVenta.TabIndex = 115;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(780, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 19);
            this.label2.TabIndex = 114;
            this.label2.Text = "Buscador Venta";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTamaño);
            this.groupBox1.Controls.Add(this.btnSelSub);
            this.groupBox1.Controls.Add(this.txtRefrigeracion);
            this.groupBox1.Controls.Add(this.btnListarSub);
            this.groupBox1.Controls.Add(this.txtMonto);
            this.groupBox1.Controls.Add(this.txtCapacidad);
            this.groupBox1.Controls.Add(this.txtTransportista);
            this.groupBox1.Controls.Add(this.btnPublicar);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 474);
            this.groupBox1.TabIndex = 113;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar Subasta";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtTamaño
            // 
            this.txtTamaño.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTamaño.ForeColor = System.Drawing.Color.DimGray;
            this.txtTamaño.Location = new System.Drawing.Point(46, 185);
            this.txtTamaño.Name = "txtTamaño";
            this.txtTamaño.Size = new System.Drawing.Size(214, 26);
            this.txtTamaño.TabIndex = 92;
            this.txtTamaño.Text = "Tamaño";
            this.txtTamaño.Enter += new System.EventHandler(this.txtTamaño_Enter);
            this.txtTamaño.Leave += new System.EventHandler(this.txtTamaño_Leave);
            // 
            // btnSelSub
            // 
            this.btnSelSub.FlatAppearance.BorderSize = 0;
            this.btnSelSub.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSelSub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelSub.Image = ((System.Drawing.Image)(resources.GetObject("btnSelSub.Image")));
            this.btnSelSub.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelSub.Location = new System.Drawing.Point(44, 285);
            this.btnSelSub.Name = "btnSelSub";
            this.btnSelSub.Size = new System.Drawing.Size(207, 40);
            this.btnSelSub.TabIndex = 110;
            this.btnSelSub.Text = "        Selccione una Subasta";
            this.btnSelSub.UseVisualStyleBackColor = true;
            this.btnSelSub.Click += new System.EventHandler(this.btnSelSub_Click_1);
            // 
            // txtRefrigeracion
            // 
            this.txtRefrigeracion.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefrigeracion.ForeColor = System.Drawing.Color.DimGray;
            this.txtRefrigeracion.Location = new System.Drawing.Point(46, 153);
            this.txtRefrigeracion.Name = "txtRefrigeracion";
            this.txtRefrigeracion.Size = new System.Drawing.Size(214, 26);
            this.txtRefrigeracion.TabIndex = 90;
            this.txtRefrigeracion.Text = "Agregar Refrigreracion";
            this.txtRefrigeracion.Enter += new System.EventHandler(this.txtRefrigeracion_Enter);
            this.txtRefrigeracion.Leave += new System.EventHandler(this.txtRefrigeracion_Leave);
            // 
            // btnListarSub
            // 
            this.btnListarSub.FlatAppearance.BorderSize = 0;
            this.btnListarSub.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnListarSub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListarSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListarSub.Image = ((System.Drawing.Image)(resources.GetObject("btnListarSub.Image")));
            this.btnListarSub.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListarSub.Location = new System.Drawing.Point(44, 331);
            this.btnListarSub.Name = "btnListarSub";
            this.btnListarSub.Size = new System.Drawing.Size(216, 40);
            this.btnListarSub.TabIndex = 111;
            this.btnListarSub.Text = "Listar";
            this.btnListarSub.UseVisualStyleBackColor = true;
            this.btnListarSub.Click += new System.EventHandler(this.btnListarSub_Click);
            // 
            // txtMonto
            // 
            this.txtMonto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.ForeColor = System.Drawing.Color.DimGray;
            this.txtMonto.Location = new System.Drawing.Point(46, 47);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(214, 26);
            this.txtMonto.TabIndex = 89;
            this.txtMonto.Text = "Monto";
            this.txtMonto.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            this.txtMonto.Enter += new System.EventHandler(this.txtMonto_Enter);
            this.txtMonto.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // txtCapacidad
            // 
            this.txtCapacidad.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapacidad.ForeColor = System.Drawing.Color.DimGray;
            this.txtCapacidad.Location = new System.Drawing.Point(46, 117);
            this.txtCapacidad.Name = "txtCapacidad";
            this.txtCapacidad.Size = new System.Drawing.Size(214, 26);
            this.txtCapacidad.TabIndex = 86;
            this.txtCapacidad.Text = "Capacidad";
            this.txtCapacidad.Enter += new System.EventHandler(this.txtCapacidad_Enter);
            this.txtCapacidad.Leave += new System.EventHandler(this.txtCapacidad_Leave);
            // 
            // txtTransportista
            // 
            this.txtTransportista.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransportista.ForeColor = System.Drawing.Color.DimGray;
            this.txtTransportista.Location = new System.Drawing.Point(46, 81);
            this.txtTransportista.Name = "txtTransportista";
            this.txtTransportista.Size = new System.Drawing.Size(214, 26);
            this.txtTransportista.TabIndex = 84;
            this.txtTransportista.Text = "Transportista";
            this.txtTransportista.Enter += new System.EventHandler(this.txtTransportista_Enter);
            this.txtTransportista.Leave += new System.EventHandler(this.txtTransportista_Leave);
            // 
            // btnPublicar
            // 
            this.btnPublicar.FlatAppearance.BorderSize = 0;
            this.btnPublicar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnPublicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPublicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPublicar.Image = ((System.Drawing.Image)(resources.GetObject("btnPublicar.Image")));
            this.btnPublicar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPublicar.Location = new System.Drawing.Point(44, 239);
            this.btnPublicar.Name = "btnPublicar";
            this.btnPublicar.Size = new System.Drawing.Size(216, 40);
            this.btnPublicar.TabIndex = 68;
            this.btnPublicar.Text = "Ingresar Carga";
            this.btnPublicar.UseVisualStyleBackColor = true;
            this.btnPublicar.Click += new System.EventHandler(this.btnPublicar_Click_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(365, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(237, 25);
            this.label8.TabIndex = 112;
            this.label8.Text = "Listar y Publicar Subastas";
            // 
            // DgvSubasta
            // 
            this.DgvSubasta.AllowUserToAddRows = false;
            this.DgvSubasta.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvSubasta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSubasta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnId,
            this.cnMonto,
            this.cnVenta,
            this.cnFecha,
            this.cnTransportista});
            this.DgvSubasta.Location = new System.Drawing.Point(309, 73);
            this.DgvSubasta.Name = "DgvSubasta";
            this.DgvSubasta.RowHeadersVisible = false;
            this.DgvSubasta.RowTemplate.Height = 150;
            this.DgvSubasta.Size = new System.Drawing.Size(402, 472);
            this.DgvSubasta.TabIndex = 109;
            // 
            // cnId
            // 
            this.cnId.DataPropertyName = "id_subasta";
            this.cnId.HeaderText = "Id Subasta";
            this.cnId.Name = "cnId";
            this.cnId.Visible = false;
            // 
            // cnMonto
            // 
            this.cnMonto.DataPropertyName = "monto_subasta";
            this.cnMonto.HeaderText = "Monto Subasta";
            this.cnMonto.Name = "cnMonto";
            // 
            // cnVenta
            // 
            this.cnVenta.DataPropertyName = "id_venta";
            this.cnVenta.HeaderText = "Venta";
            this.cnVenta.Name = "cnVenta";
            // 
            // cnFecha
            // 
            this.cnFecha.DataPropertyName = "fecha_subasta";
            this.cnFecha.HeaderText = "Fecha Subasta";
            this.cnFecha.Name = "cnFecha";
            // 
            // cnTransportista
            // 
            this.cnTransportista.DataPropertyName = "id_usuario";
            this.cnTransportista.HeaderText = "Transportista";
            this.cnTransportista.Name = "cnTransportista";
            // 
            // Postulacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 620);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Postulacion";
            this.Text = "Postulacion";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvVenta)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSubasta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtBusVenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelSub;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTamaño;
        private System.Windows.Forms.TextBox txtRefrigeracion;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtCapacidad;
        private System.Windows.Forms.TextBox txtTransportista;
        private System.Windows.Forms.Button btnPublicar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnListarSub;
        private System.Windows.Forms.DataGridView DgvSubasta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnTransportista;
        private System.Windows.Forms.DataGridView DgvVenta;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnIngresarSubasta;
        private System.Windows.Forms.Button btnSelccVenta;
        private System.Windows.Forms.Button btnListarVent;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnDescripionVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnClienteExterno;
        private System.Windows.Forms.TextBox txtDescVenta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
    }
}