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
            this.btnIngresarSubasta = new System.Windows.Forms.Button();
            this.btnSelccVenta = new System.Windows.Forms.Button();
            this.btnListarVent = new System.Windows.Forms.Button();
            this.DgvVenta = new System.Windows.Forms.DataGridView();
            this.cnDescripionVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnClienteExterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtBusVenta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelSub = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTamaño = new System.Windows.Forms.TextBox();
            this.txtRefrigeracion = new System.Windows.Forms.TextBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.txtCapacidad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTransportista = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPublicar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnListarSub = new System.Windows.Forms.Button();
            this.DgvSubasta = new System.Windows.Forms.DataGridView();
            this.cnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnTransportista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescVenta = new System.Windows.Forms.TextBox();
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
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.btnListarVent.Location = new System.Drawing.Point(101, 413);
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
            this.DgvVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnDescripionVenta,
            this.cnClienteExterno});
            this.DgvVenta.Location = new System.Drawing.Point(53, 28);
            this.DgvVenta.Name = "DgvVenta";
            this.DgvVenta.Size = new System.Drawing.Size(255, 343);
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
            this.tabPage2.Controls.Add(this.txtBusVenta);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btnSelSub);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.btnListarSub);
            this.tabPage2.Controls.Add(this.DgvSubasta);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1035, 551);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtBusVenta
            // 
            this.txtBusVenta.Location = new System.Drawing.Point(636, 117);
            this.txtBusVenta.Name = "txtBusVenta";
            this.txtBusVenta.Size = new System.Drawing.Size(186, 20);
            this.txtBusVenta.TabIndex = 115;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(506, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 114;
            this.label2.Text = "Buscador Venta";
            // 
            // btnSelSub
            // 
            this.btnSelSub.FlatAppearance.BorderSize = 0;
            this.btnSelSub.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSelSub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelSub.Image = ((System.Drawing.Image)(resources.GetObject("btnSelSub.Image")));
            this.btnSelSub.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelSub.Location = new System.Drawing.Point(223, 459);
            this.btnSelSub.Name = "btnSelSub";
            this.btnSelSub.Size = new System.Drawing.Size(207, 40);
            this.btnSelSub.TabIndex = 110;
            this.btnSelSub.Text = "        Selccione una Subasta";
            this.btnSelSub.UseVisualStyleBackColor = true;
            this.btnSelSub.Click += new System.EventHandler(this.btnSelSub_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTamaño);
            this.groupBox1.Controls.Add(this.txtRefrigeracion);
            this.groupBox1.Controls.Add(this.txtMonto);
            this.groupBox1.Controls.Add(this.label38);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Controls.Add(this.txtCapacidad);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTransportista);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnPublicar);
            this.groupBox1.Location = new System.Drawing.Point(436, 182);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 317);
            this.groupBox1.TabIndex = 113;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar Carga";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 91;
            this.label1.Text = "Tamaño";
            // 
            // txtTamaño
            // 
            this.txtTamaño.Location = new System.Drawing.Point(188, 188);
            this.txtTamaño.Name = "txtTamaño";
            this.txtTamaño.Size = new System.Drawing.Size(214, 20);
            this.txtTamaño.TabIndex = 92;
            // 
            // txtRefrigeracion
            // 
            this.txtRefrigeracion.Location = new System.Drawing.Point(188, 156);
            this.txtRefrigeracion.Name = "txtRefrigeracion";
            this.txtRefrigeracion.Size = new System.Drawing.Size(214, 20);
            this.txtRefrigeracion.TabIndex = 90;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(188, 50);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(214, 20);
            this.txtMonto.TabIndex = 89;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(36, 120);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(146, 20);
            this.label38.TabIndex = 87;
            this.label38.Text = "Agregar Capacidad";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(21, 156);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(165, 20);
            this.label36.TabIndex = 88;
            this.label36.Text = "Agregar Refrigeracion";
            // 
            // txtCapacidad
            // 
            this.txtCapacidad.Location = new System.Drawing.Point(188, 120);
            this.txtCapacidad.Name = "txtCapacidad";
            this.txtCapacidad.Size = new System.Drawing.Size(214, 20);
            this.txtCapacidad.TabIndex = 86;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(90, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 85;
            this.label4.Text = "Monto";
            // 
            // txtTransportista
            // 
            this.txtTransportista.Location = new System.Drawing.Point(188, 84);
            this.txtTransportista.Name = "txtTransportista";
            this.txtTransportista.Size = new System.Drawing.Size(214, 20);
            this.txtTransportista.TabIndex = 84;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 81;
            this.label3.Text = "Transportista";
            // 
            // btnPublicar
            // 
            this.btnPublicar.FlatAppearance.BorderSize = 0;
            this.btnPublicar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnPublicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPublicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPublicar.Image = ((System.Drawing.Image)(resources.GetObject("btnPublicar.Image")));
            this.btnPublicar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPublicar.Location = new System.Drawing.Point(170, 248);
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
            this.label8.Location = new System.Drawing.Point(305, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(237, 25);
            this.label8.TabIndex = 112;
            this.label8.Text = "Listar y Publicar Subastas";
            // 
            // btnListarSub
            // 
            this.btnListarSub.FlatAppearance.BorderSize = 0;
            this.btnListarSub.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnListarSub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListarSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListarSub.Image = ((System.Drawing.Image)(resources.GetObject("btnListarSub.Image")));
            this.btnListarSub.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListarSub.Location = new System.Drawing.Point(9, 459);
            this.btnListarSub.Name = "btnListarSub";
            this.btnListarSub.Size = new System.Drawing.Size(250, 40);
            this.btnListarSub.TabIndex = 111;
            this.btnListarSub.Text = "Listar";
            this.btnListarSub.UseVisualStyleBackColor = true;
            this.btnListarSub.Click += new System.EventHandler(this.btnListarSub_Click);
            // 
            // DgvSubasta
            // 
            this.DgvSubasta.AllowUserToAddRows = false;
            this.DgvSubasta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSubasta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnId,
            this.cnMonto,
            this.cnVenta,
            this.cnFecha,
            this.cnTransportista});
            this.DgvSubasta.Location = new System.Drawing.Point(9, 81);
            this.DgvSubasta.Name = "DgvSubasta";
            this.DgvSubasta.RowHeadersVisible = false;
            this.DgvSubasta.RowTemplate.Height = 150;
            this.DgvSubasta.Size = new System.Drawing.Size(421, 347);
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
            // txtDescVenta
            // 
            this.txtDescVenta.Location = new System.Drawing.Point(239, 63);
            this.txtDescVenta.Name = "txtDescVenta";
            this.txtDescVenta.Size = new System.Drawing.Size(214, 20);
            this.txtDescVenta.TabIndex = 90;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTamaño;
        private System.Windows.Forms.TextBox txtRefrigeracion;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txtCapacidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTransportista;
        private System.Windows.Forms.Label label3;
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
    }
}