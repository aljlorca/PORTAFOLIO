namespace MercadoChile.Template
{
    partial class Procesos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Procesos));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.cmbCiudadEdit = new System.Windows.Forms.ComboBox();
            this.cmbRegionEdit = new System.Windows.Forms.ComboBox();
            this.cmbPaisEdit = new System.Windows.Forms.ComboBox();
            this.cmbTipoEmpEdit = new System.Windows.Forms.ComboBox();
            this.txtDunsEdit = new System.Windows.Forms.TextBox();
            this.txtGiroEdit = new System.Windows.Forms.TextBox();
            this.txtDirEdit = new System.Windows.Forms.TextBox();
            this.txtRazonEdit = new System.Windows.Forms.TextBox();
            this.DgvPostulacion = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.DgvProducto = new System.Windows.Forms.DataGridView();
            this.cnImagen = new System.Windows.Forms.DataGridViewImageColumn();
            this.cnNomProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCantProduc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cnIdP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnDesrip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPostulacion)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.AccessibleName = "";
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1036, 590);
            this.tabControl1.TabIndex = 22;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.DgvPostulacion);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1028, 564);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Crear Cliente";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnListar);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnModificar);
            this.groupBox1.Controls.Add(this.cmbCiudadEdit);
            this.groupBox1.Controls.Add(this.cmbRegionEdit);
            this.groupBox1.Controls.Add(this.cmbPaisEdit);
            this.groupBox1.Controls.Add(this.cmbTipoEmpEdit);
            this.groupBox1.Controls.Add(this.txtDunsEdit);
            this.groupBox1.Controls.Add(this.txtGiroEdit);
            this.groupBox1.Controls.Add(this.txtDirEdit);
            this.groupBox1.Controls.Add(this.txtRazonEdit);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 513);
            this.groupBox1.TabIndex = 105;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modificar Empresa";
            // 
            // btnListar
            // 
            this.btnListar.FlatAppearance.BorderSize = 0;
            this.btnListar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnListar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListar.Location = new System.Drawing.Point(6, 450);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(216, 40);
            this.btnListar.TabIndex = 99;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(6, 404);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(220, 40);
            this.btnEliminar.TabIndex = 98;
            this.btnEliminar.Text = "Eliminar Empresa";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(4, 312);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(216, 40);
            this.btnEdit.TabIndex = 68;
            this.btnEdit.Text = "Editar Empresa";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(-1, 358);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(216, 40);
            this.btnModificar.TabIndex = 97;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // cmbCiudadEdit
            // 
            this.cmbCiudadEdit.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCiudadEdit.ForeColor = System.Drawing.Color.DimGray;
            this.cmbCiudadEdit.FormattingEnabled = true;
            this.cmbCiudadEdit.Location = new System.Drawing.Point(6, 258);
            this.cmbCiudadEdit.Name = "cmbCiudadEdit";
            this.cmbCiudadEdit.Size = new System.Drawing.Size(214, 28);
            this.cmbCiudadEdit.TabIndex = 85;
            this.cmbCiudadEdit.Text = "Ciudad";
            // 
            // cmbRegionEdit
            // 
            this.cmbRegionEdit.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRegionEdit.ForeColor = System.Drawing.Color.DimGray;
            this.cmbRegionEdit.FormattingEnabled = true;
            this.cmbRegionEdit.Location = new System.Drawing.Point(6, 225);
            this.cmbRegionEdit.Name = "cmbRegionEdit";
            this.cmbRegionEdit.Size = new System.Drawing.Size(214, 28);
            this.cmbRegionEdit.TabIndex = 84;
            this.cmbRegionEdit.Text = "Region";
            // 
            // cmbPaisEdit
            // 
            this.cmbPaisEdit.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaisEdit.ForeColor = System.Drawing.Color.DimGray;
            this.cmbPaisEdit.FormattingEnabled = true;
            this.cmbPaisEdit.Location = new System.Drawing.Point(6, 192);
            this.cmbPaisEdit.Name = "cmbPaisEdit";
            this.cmbPaisEdit.Size = new System.Drawing.Size(214, 28);
            this.cmbPaisEdit.TabIndex = 83;
            this.cmbPaisEdit.Text = "Pais";
            // 
            // cmbTipoEmpEdit
            // 
            this.cmbTipoEmpEdit.DisplayMember = "1";
            this.cmbTipoEmpEdit.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoEmpEdit.ForeColor = System.Drawing.Color.DimGray;
            this.cmbTipoEmpEdit.FormattingEnabled = true;
            this.cmbTipoEmpEdit.Location = new System.Drawing.Point(6, 159);
            this.cmbTipoEmpEdit.Name = "cmbTipoEmpEdit";
            this.cmbTipoEmpEdit.Size = new System.Drawing.Size(214, 28);
            this.cmbTipoEmpEdit.TabIndex = 82;
            this.cmbTipoEmpEdit.Text = "Tipo Empresa";
            this.cmbTipoEmpEdit.ValueMember = "0";
            // 
            // txtDunsEdit
            // 
            this.txtDunsEdit.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDunsEdit.ForeColor = System.Drawing.Color.DimGray;
            this.txtDunsEdit.Location = new System.Drawing.Point(6, 31);
            this.txtDunsEdit.Name = "txtDunsEdit";
            this.txtDunsEdit.Size = new System.Drawing.Size(214, 26);
            this.txtDunsEdit.TabIndex = 81;
            this.txtDunsEdit.Text = "Duns Empresa";
            // 
            // txtGiroEdit
            // 
            this.txtGiroEdit.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiroEdit.ForeColor = System.Drawing.Color.DimGray;
            this.txtGiroEdit.Location = new System.Drawing.Point(6, 126);
            this.txtGiroEdit.Name = "txtGiroEdit";
            this.txtGiroEdit.Size = new System.Drawing.Size(214, 26);
            this.txtGiroEdit.TabIndex = 76;
            this.txtGiroEdit.Text = "Giro empresa";
            // 
            // txtDirEdit
            // 
            this.txtDirEdit.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDirEdit.ForeColor = System.Drawing.Color.DimGray;
            this.txtDirEdit.Location = new System.Drawing.Point(6, 93);
            this.txtDirEdit.Name = "txtDirEdit";
            this.txtDirEdit.Size = new System.Drawing.Size(214, 26);
            this.txtDirEdit.TabIndex = 75;
            this.txtDirEdit.Text = "Direccion";
            // 
            // txtRazonEdit
            // 
            this.txtRazonEdit.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonEdit.ForeColor = System.Drawing.Color.DimGray;
            this.txtRazonEdit.Location = new System.Drawing.Point(6, 63);
            this.txtRazonEdit.Name = "txtRazonEdit";
            this.txtRazonEdit.Size = new System.Drawing.Size(214, 26);
            this.txtRazonEdit.TabIndex = 74;
            this.txtRazonEdit.Text = "Rason Social";
            // 
            // DgvPostulacion
            // 
            this.DgvPostulacion.AllowUserToAddRows = false;
            this.DgvPostulacion.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvPostulacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPostulacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnIdP,
            this.cnDesrip,
            this.cnEstado,
            this.cnVenta,
            this.cnCliente,
            this.cnProduto});
            this.DgvPostulacion.Location = new System.Drawing.Point(252, 38);
            this.DgvPostulacion.Name = "DgvPostulacion";
            this.DgvPostulacion.Size = new System.Drawing.Size(770, 520);
            this.DgvPostulacion.TabIndex = 104;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(547, 13);
            this.label3.TabIndex = 103;
            this.label3.Text = "---------------------------------------------------------------------------------" +
    "------------------------------------------------------";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(423, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Control de Proceso Postulacion";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.DgvProducto);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1028, 564);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Listar Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(547, 13);
            this.label2.TabIndex = 104;
            this.label2.Text = "---------------------------------------------------------------------------------" +
    "------------------------------------------------------";
            // 
            // DgvProducto
            // 
            this.DgvProducto.AllowUserToAddRows = false;
            this.DgvProducto.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnImagen,
            this.cnNomProd,
            this.cnCantProduc,
            this.cnPrecio,
            this.cnSaldo,
            this.cnCalidad,
            this.cnProveedor,
            this.cnId,
            this.cnUrl});
            this.DgvProducto.Location = new System.Drawing.Point(54, 53);
            this.DgvProducto.Name = "DgvProducto";
            this.DgvProducto.RowTemplate.Height = 150;
            this.DgvProducto.Size = new System.Drawing.Size(925, 508);
            this.DgvProducto.TabIndex = 94;
            this.DgvProducto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProducto_CellClick);
            // 
            // cnImagen
            // 
            this.cnImagen.HeaderText = "Imagen Produto";
            this.cnImagen.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.cnImagen.Name = "cnImagen";
            this.cnImagen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cnImagen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cnNomProd
            // 
            this.cnNomProd.DataPropertyName = "nombre_producto";
            this.cnNomProd.HeaderText = "Nombre Produto";
            this.cnNomProd.Name = "cnNomProd";
            // 
            // cnCantProduc
            // 
            this.cnCantProduc.DataPropertyName = "cantidad_producto";
            this.cnCantProduc.HeaderText = "Cantidad Producto";
            this.cnCantProduc.Name = "cnCantProduc";
            // 
            // cnPrecio
            // 
            this.cnPrecio.DataPropertyName = "precio_producto";
            this.cnPrecio.HeaderText = "Precio";
            this.cnPrecio.Name = "cnPrecio";
            // 
            // cnSaldo
            // 
            this.cnSaldo.DataPropertyName = "saldo_producto";
            this.cnSaldo.HeaderText = "Saldo Producto";
            this.cnSaldo.Name = "cnSaldo";
            // 
            // cnCalidad
            // 
            this.cnCalidad.DataPropertyName = "id_calidad";
            this.cnCalidad.HeaderText = "Calidad";
            this.cnCalidad.Name = "cnCalidad";
            // 
            // cnProveedor
            // 
            this.cnProveedor.DataPropertyName = "id_usuario";
            this.cnProveedor.HeaderText = "Proveedor";
            this.cnProveedor.Name = "cnProveedor";
            // 
            // cnId
            // 
            this.cnId.DataPropertyName = "id_producto";
            this.cnId.HeaderText = "ID";
            this.cnId.Name = "cnId";
            this.cnId.Visible = false;
            // 
            // cnUrl
            // 
            this.cnUrl.DataPropertyName = "imagen_producto";
            this.cnUrl.HeaderText = "Url Imagen";
            this.cnUrl.Name = "cnUrl";
            this.cnUrl.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(359, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(231, 25);
            this.label8.TabIndex = 93;
            this.label8.Text = "Listar y Eliminar Empresa";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(38, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(10, 10);
            this.button1.TabIndex = 95;
            this.button1.Tag = "";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cnIdP
            // 
            this.cnIdP.DataPropertyName = "id_postulacion";
            this.cnIdP.HeaderText = "ID";
            this.cnIdP.Name = "cnIdP";
            this.cnIdP.Visible = false;
            // 
            // cnDesrip
            // 
            this.cnDesrip.DataPropertyName = "descripcion_postulacion";
            this.cnDesrip.HeaderText = "Descripcion Postulacion";
            this.cnDesrip.Name = "cnDesrip";
            // 
            // cnEstado
            // 
            this.cnEstado.DataPropertyName = "estado_postulacion";
            this.cnEstado.HeaderText = "Estado Postulacion";
            this.cnEstado.Name = "cnEstado";
            // 
            // cnVenta
            // 
            this.cnVenta.DataPropertyName = "id_venta";
            this.cnVenta.HeaderText = "Venta";
            this.cnVenta.Name = "cnVenta";
            // 
            // cnCliente
            // 
            this.cnCliente.DataPropertyName = "id_usuario";
            this.cnCliente.HeaderText = "Cliente";
            this.cnCliente.Name = "cnCliente";
            // 
            // cnProduto
            // 
            this.cnProduto.DataPropertyName = "id_producto";
            this.cnProduto.HeaderText = "Nombre Producto";
            this.cnProduto.Name = "cnProduto";
            // 
            // Procesos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 601);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Procesos";
            this.Text = "Procesos";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPostulacion)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DgvProducto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewImageColumn cnImagen;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnNomProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCantProduc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnUrl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.ComboBox cmbCiudadEdit;
        private System.Windows.Forms.ComboBox cmbRegionEdit;
        private System.Windows.Forms.ComboBox cmbPaisEdit;
        private System.Windows.Forms.ComboBox cmbTipoEmpEdit;
        private System.Windows.Forms.TextBox txtDunsEdit;
        private System.Windows.Forms.TextBox txtGiroEdit;
        private System.Windows.Forms.TextBox txtDirEdit;
        private System.Windows.Forms.TextBox txtRazonEdit;
        private System.Windows.Forms.DataGridView DgvPostulacion;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnIdP;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnDesrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnProduto;
    }
}