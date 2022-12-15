namespace MercadoChile.Template
{
    partial class Empresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Empresa));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbDire = new System.Windows.Forms.ComboBox();
            this.btnBusDirc = new System.Windows.Forms.Button();
            this.btnLimpiarDir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbEmpresa = new System.Windows.Forms.ComboBox();
            this.btnCrear = new System.Windows.Forms.Button();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.txtDunsEmp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbDireEdit = new System.Windows.Forms.ComboBox();
            this.btnBuscarDirec = new System.Windows.Forms.Button();
            this.btnLimpiarDire = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.cmbTipoEmpEdit = new System.Windows.Forms.ComboBox();
            this.txtDunsEdit = new System.Windows.Forms.TextBox();
            this.txtRazonEdit = new System.Windows.Forms.TextBox();
            this.DgvEmpresa = new System.Windows.Forms.DataGridView();
            this.cnDunsEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnRazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnTipoEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEmpresa)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.AccessibleName = "";
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1039, 598);
            this.tabControl1.TabIndex = 21;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.button1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.cmbDire);
            this.tabPage1.Controls.Add(this.btnBusDirc);
            this.tabPage1.Controls.Add(this.btnLimpiarDir);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cmbEmpresa);
            this.tabPage1.Controls.Add(this.btnCrear);
            this.tabPage1.Controls.Add(this.txtRazonSocial);
            this.tabPage1.Controls.Add(this.txtDunsEmp);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1031, 572);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Crear Empresa";
            // 
            // cmbDire
            // 
            this.cmbDire.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDire.ForeColor = System.Drawing.Color.Black;
            this.cmbDire.FormattingEnabled = true;
            this.cmbDire.Location = new System.Drawing.Point(548, 250);
            this.cmbDire.Name = "cmbDire";
            this.cmbDire.Size = new System.Drawing.Size(300, 28);
            this.cmbDire.TabIndex = 107;
            // 
            // btnBusDirc
            // 
            this.btnBusDirc.FlatAppearance.BorderSize = 0;
            this.btnBusDirc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBusDirc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusDirc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBusDirc.Image = ((System.Drawing.Image)(resources.GetObject("btnBusDirc.Image")));
            this.btnBusDirc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBusDirc.Location = new System.Drawing.Point(535, 289);
            this.btnBusDirc.Name = "btnBusDirc";
            this.btnBusDirc.Size = new System.Drawing.Size(183, 40);
            this.btnBusDirc.TabIndex = 106;
            this.btnBusDirc.Text = "     Buscar Direccion";
            this.btnBusDirc.UseVisualStyleBackColor = true;
            this.btnBusDirc.Click += new System.EventHandler(this.btnBusDirc_Click);
            // 
            // btnLimpiarDir
            // 
            this.btnLimpiarDir.FlatAppearance.BorderSize = 0;
            this.btnLimpiarDir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnLimpiarDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarDir.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiarDir.Image")));
            this.btnLimpiarDir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiarDir.Location = new System.Drawing.Point(724, 289);
            this.btnLimpiarDir.Name = "btnLimpiarDir";
            this.btnLimpiarDir.Size = new System.Drawing.Size(174, 40);
            this.btnLimpiarDir.TabIndex = 105;
            this.btnLimpiarDir.Text = "      Limpiar direccion";
            this.btnLimpiarDir.UseVisualStyleBackColor = true;
            this.btnLimpiarDir.Click += new System.EventHandler(this.btnLimpiarDir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(547, 13);
            this.label3.TabIndex = 103;
            this.label3.Text = "---------------------------------------------------------------------------------" +
    "------------------------------------------------------";
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpresa.ForeColor = System.Drawing.Color.Black;
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.Location = new System.Drawing.Point(548, 142);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(214, 28);
            this.cmbEmpresa.TabIndex = 35;
            this.cmbEmpresa.Text = "Tipo Empresa";
            // 
            // btnCrear
            // 
            this.btnCrear.FlatAppearance.BorderSize = 0;
            this.btnCrear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrear.Image = ((System.Drawing.Image)(resources.GetObject("btnCrear.Image")));
            this.btnCrear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrear.Location = new System.Drawing.Point(423, 412);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(250, 40);
            this.btnCrear.TabIndex = 34;
            this.btnCrear.Text = "Crear Cliente";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.ForeColor = System.Drawing.Color.DimGray;
            this.txtRazonSocial.Location = new System.Drawing.Point(283, 195);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(214, 26);
            this.txtRazonSocial.TabIndex = 28;
            this.txtRazonSocial.Text = "Razon social";
            this.txtRazonSocial.Enter += new System.EventHandler(this.txtRazonSocial_Enter);
            this.txtRazonSocial.Leave += new System.EventHandler(this.txtRazonSocial_Leave);
            // 
            // txtDunsEmp
            // 
            this.txtDunsEmp.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDunsEmp.ForeColor = System.Drawing.Color.DimGray;
            this.txtDunsEmp.Location = new System.Drawing.Point(283, 142);
            this.txtDunsEmp.Name = "txtDunsEmp";
            this.txtDunsEmp.Size = new System.Drawing.Size(214, 26);
            this.txtDunsEmp.TabIndex = 27;
            this.txtDunsEmp.Text = "Duns Empresa";
            this.txtDunsEmp.Enter += new System.EventHandler(this.txtDunsEmp_Enter);
            this.txtDunsEmp.Leave += new System.EventHandler(this.txtDunsEmp_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(419, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Creacion de Empresa";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.DgvEmpresa);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1031, 572);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Listar Empresa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(547, 13);
            this.label2.TabIndex = 104;
            this.label2.Text = "---------------------------------------------------------------------------------" +
    "------------------------------------------------------";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbDireEdit);
            this.groupBox1.Controls.Add(this.btnBuscarDirec);
            this.groupBox1.Controls.Add(this.btnLimpiarDire);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnModificar);
            this.groupBox1.Controls.Add(this.cmbTipoEmpEdit);
            this.groupBox1.Controls.Add(this.txtDunsEdit);
            this.groupBox1.Controls.Add(this.txtRazonEdit);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 513);
            this.groupBox1.TabIndex = 96;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modificar Empresa";
            // 
            // cmbDireEdit
            // 
            this.cmbDireEdit.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDireEdit.ForeColor = System.Drawing.Color.Black;
            this.cmbDireEdit.FormattingEnabled = true;
            this.cmbDireEdit.Location = new System.Drawing.Point(6, 135);
            this.cmbDireEdit.Name = "cmbDireEdit";
            this.cmbDireEdit.Size = new System.Drawing.Size(214, 28);
            this.cmbDireEdit.TabIndex = 110;
            // 
            // btnBuscarDirec
            // 
            this.btnBuscarDirec.FlatAppearance.BorderSize = 0;
            this.btnBuscarDirec.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscarDirec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarDirec.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarDirec.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarDirec.Image")));
            this.btnBuscarDirec.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarDirec.Location = new System.Drawing.Point(30, 169);
            this.btnBuscarDirec.Name = "btnBuscarDirec";
            this.btnBuscarDirec.Size = new System.Drawing.Size(183, 40);
            this.btnBuscarDirec.TabIndex = 109;
            this.btnBuscarDirec.Text = "     Buscar Direccion";
            this.btnBuscarDirec.UseVisualStyleBackColor = true;
            this.btnBuscarDirec.Click += new System.EventHandler(this.btnBuscarDirec_Click);
            // 
            // btnLimpiarDire
            // 
            this.btnLimpiarDire.FlatAppearance.BorderSize = 0;
            this.btnLimpiarDire.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnLimpiarDire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarDire.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarDire.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiarDire.Image")));
            this.btnLimpiarDire.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiarDire.Location = new System.Drawing.Point(30, 215);
            this.btnLimpiarDire.Name = "btnLimpiarDire";
            this.btnLimpiarDire.Size = new System.Drawing.Size(183, 40);
            this.btnLimpiarDire.TabIndex = 108;
            this.btnLimpiarDire.Text = "      Limpiar direccion";
            this.btnLimpiarDire.UseVisualStyleBackColor = true;
            this.btnLimpiarDire.Click += new System.EventHandler(this.btnLimpiarDire_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(6, 261);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(207, 40);
            this.btnEliminar.TabIndex = 98;
            this.btnEliminar.Text = "Eliminar Empresa";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(6, 307);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(214, 40);
            this.btnEdit.TabIndex = 68;
            this.btnEdit.Text = "Editar Empresa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(0, 467);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(216, 40);
            this.btnModificar.TabIndex = 97;
            this.btnModificar.Text = "        Seleccione una Empresa";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // cmbTipoEmpEdit
            // 
            this.cmbTipoEmpEdit.DisplayMember = "1";
            this.cmbTipoEmpEdit.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoEmpEdit.ForeColor = System.Drawing.Color.DimGray;
            this.cmbTipoEmpEdit.FormattingEnabled = true;
            this.cmbTipoEmpEdit.Location = new System.Drawing.Point(6, 101);
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
            this.txtDunsEdit.Enter += new System.EventHandler(this.txtDunsEdit_Enter);
            this.txtDunsEdit.Leave += new System.EventHandler(this.txtDunsEdit_Leave);
            // 
            // txtRazonEdit
            // 
            this.txtRazonEdit.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonEdit.ForeColor = System.Drawing.Color.DimGray;
            this.txtRazonEdit.Location = new System.Drawing.Point(6, 63);
            this.txtRazonEdit.Name = "txtRazonEdit";
            this.txtRazonEdit.Size = new System.Drawing.Size(214, 26);
            this.txtRazonEdit.TabIndex = 74;
            this.txtRazonEdit.Text = "Razon Social";
            this.txtRazonEdit.Enter += new System.EventHandler(this.txtRazonEdit_Enter);
            this.txtRazonEdit.Leave += new System.EventHandler(this.txtRazonEdit_Leave);
            // 
            // DgvEmpresa
            // 
            this.DgvEmpresa.AllowUserToAddRows = false;
            this.DgvEmpresa.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvEmpresa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEmpresa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnDunsEmpresa,
            this.cnRazonSocial,
            this.cnDireccion,
            this.cnTipoEmpresa});
            this.DgvEmpresa.Location = new System.Drawing.Point(344, 61);
            this.DgvEmpresa.Name = "DgvEmpresa";
            this.DgvEmpresa.Size = new System.Drawing.Size(533, 407);
            this.DgvEmpresa.TabIndex = 94;
            // 
            // cnDunsEmpresa
            // 
            this.cnDunsEmpresa.DataPropertyName = "duns_empresa";
            this.cnDunsEmpresa.HeaderText = "Duns Empresa";
            this.cnDunsEmpresa.Name = "cnDunsEmpresa";
            // 
            // cnRazonSocial
            // 
            this.cnRazonSocial.DataPropertyName = "razon_social_empresa";
            this.cnRazonSocial.HeaderText = "Razon Social";
            this.cnRazonSocial.Name = "cnRazonSocial";
            // 
            // cnDireccion
            // 
            this.cnDireccion.DataPropertyName = "direccion_empresa";
            this.cnDireccion.HeaderText = "Direccion Empresa";
            this.cnDireccion.Name = "cnDireccion";
            // 
            // cnTipoEmpresa
            // 
            this.cnTipoEmpresa.DataPropertyName = "id_tipo_empresa";
            this.cnTipoEmpresa.HeaderText = "Tipo Empresa";
            this.cnTipoEmpresa.Name = "cnTipoEmpresa";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(458, 5);
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
            // Empresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 607);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Empresa";
            this.Text = "Empresa";
            this.Load += new System.EventHandler(this.Empresa_Carga);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEmpresa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridView DgvEmpresa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbTipoEmpEdit;
        private System.Windows.Forms.TextBox txtDunsEdit;
        private System.Windows.Forms.TextBox txtRazonEdit;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.TextBox txtDunsEmp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBusDirc;
        private System.Windows.Forms.Button btnLimpiarDir;
        private System.Windows.Forms.ComboBox cmbDire;
        private System.Windows.Forms.ComboBox cmbDireEdit;
        private System.Windows.Forms.Button btnBuscarDirec;
        private System.Windows.Forms.Button btnLimpiarDire;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnDunsEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnRazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnTipoEmpresa;
    }
}