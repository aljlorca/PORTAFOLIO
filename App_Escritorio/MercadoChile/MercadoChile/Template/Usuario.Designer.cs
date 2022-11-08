
namespace MercadoChile
{
    partial class Usuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Usuario));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbDire = new System.Windows.Forms.ComboBox();
            this.btnBuscDir = new System.Windows.Forms.Button();
            this.btnLimpiarDir = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbEmpresa = new System.Windows.Forms.ComboBox();
            this.cmbCargo = new System.Windows.Forms.ComboBox();
            this.btnCrear = new System.Windows.Forms.Button();
            this.txtConUsua = new System.Windows.Forms.TextBox();
            this.txtCorUsua = new System.Windows.Forms.TextBox();
            this.txtTelUsua = new System.Windows.Forms.TextBox();
            this.txtNombreUsua = new System.Windows.Forms.TextBox();
            this.txtRutUsua = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.DgvClientes = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.cmbEmpresaEdit = new System.Windows.Forms.ComboBox();
            this.cmbCargoEdit = new System.Windows.Forms.ComboBox();
            this.txtConEdit = new System.Windows.Forms.TextBox();
            this.txtRutEdit = new System.Windows.Forms.TextBox();
            this.txtTeleEdit = new System.Windows.Forms.TextBox();
            this.txtNomEdit = new System.Windows.Forms.TextBox();
            this.txtCorEdit = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbDireEdit = new System.Windows.Forms.ComboBox();
            this.btnBuscarDire = new System.Windows.Forms.Button();
            this.btnLimpiarDire = new System.Windows.Forms.Button();
            this.cnNumeIdenUsuar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnUsAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnContraseña = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnFeha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvClientes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.AccessibleName = "";
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl1.Location = new System.Drawing.Point(12, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1044, 610);
            this.tabControl1.TabIndex = 20;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.button1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.cmbDire);
            this.tabPage1.Controls.Add(this.btnBuscDir);
            this.tabPage1.Controls.Add(this.btnLimpiarDir);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.cmbEmpresa);
            this.tabPage1.Controls.Add(this.cmbCargo);
            this.tabPage1.Controls.Add(this.btnCrear);
            this.tabPage1.Controls.Add(this.txtConUsua);
            this.tabPage1.Controls.Add(this.txtCorUsua);
            this.tabPage1.Controls.Add(this.txtTelUsua);
            this.tabPage1.Controls.Add(this.txtNombreUsua);
            this.tabPage1.Controls.Add(this.txtRutUsua);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1036, 584);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Crear Cliente";
            // 
            // cmbDire
            // 
            this.cmbDire.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDire.ForeColor = System.Drawing.Color.Black;
            this.cmbDire.FormattingEnabled = true;
            this.cmbDire.Location = new System.Drawing.Point(364, 239);
            this.cmbDire.Name = "cmbDire";
            this.cmbDire.Size = new System.Drawing.Size(300, 28);
            this.cmbDire.TabIndex = 108;
            this.cmbDire.Text = "cmbDire";
            // 
            // btnBuscDir
            // 
            this.btnBuscDir.FlatAppearance.BorderSize = 0;
            this.btnBuscDir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscDir.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscDir.Image")));
            this.btnBuscDir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscDir.Location = new System.Drawing.Point(345, 305);
            this.btnBuscDir.Name = "btnBuscDir";
            this.btnBuscDir.Size = new System.Drawing.Size(183, 40);
            this.btnBuscDir.TabIndex = 49;
            this.btnBuscDir.Text = "     Buscar Direccion";
            this.btnBuscDir.UseVisualStyleBackColor = true;
            this.btnBuscDir.Click += new System.EventHandler(this.btnBuscDir_Click);
            // 
            // btnLimpiarDir
            // 
            this.btnLimpiarDir.FlatAppearance.BorderSize = 0;
            this.btnLimpiarDir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnLimpiarDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarDir.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiarDir.Image")));
            this.btnLimpiarDir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiarDir.Location = new System.Drawing.Point(543, 305);
            this.btnLimpiarDir.Name = "btnLimpiarDir";
            this.btnLimpiarDir.Size = new System.Drawing.Size(174, 40);
            this.btnLimpiarDir.TabIndex = 48;
            this.btnLimpiarDir.Text = "       Limpiar Direccion";
            this.btnLimpiarDir.UseVisualStyleBackColor = true;
            this.btnLimpiarDir.Click += new System.EventHandler(this.btnLimpiarDir_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(412, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "---------------------------------------------------------------------------------" +
    "------------------------------------------------------";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(19, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(247, 28);
            this.label10.TabIndex = 45;
            this.label10.Text = "Creacion de Cliente";
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpresa.ForeColor = System.Drawing.Color.DimGray;
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.Location = new System.Drawing.Point(373, 164);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(214, 26);
            this.cmbEmpresa.TabIndex = 39;
            this.cmbEmpresa.Text = "Empresa";
            this.cmbEmpresa.Click += new System.EventHandler(this.cmbEmpresa_Click);
            // 
            // cmbCargo
            // 
            this.cmbCargo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCargo.ForeColor = System.Drawing.Color.DimGray;
            this.cmbCargo.FormattingEnabled = true;
            this.cmbCargo.Location = new System.Drawing.Point(373, 118);
            this.cmbCargo.Name = "cmbCargo";
            this.cmbCargo.Size = new System.Drawing.Size(214, 26);
            this.cmbCargo.TabIndex = 35;
            this.cmbCargo.Text = "Cargo";
            this.cmbCargo.Enter += new System.EventHandler(this.cmbCargo_Enter);
            // 
            // btnCrear
            // 
            this.btnCrear.FlatAppearance.BorderSize = 0;
            this.btnCrear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrear.Image = ((System.Drawing.Image)(resources.GetObject("btnCrear.Image")));
            this.btnCrear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrear.Location = new System.Drawing.Point(373, 424);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(250, 40);
            this.btnCrear.TabIndex = 34;
            this.btnCrear.Text = "Crear Cliente";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // txtConUsua
            // 
            this.txtConUsua.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConUsua.ForeColor = System.Drawing.Color.DimGray;
            this.txtConUsua.Location = new System.Drawing.Point(24, 370);
            this.txtConUsua.Name = "txtConUsua";
            this.txtConUsua.Size = new System.Drawing.Size(214, 26);
            this.txtConUsua.TabIndex = 32;
            this.txtConUsua.Text = "Contraseña";
            this.txtConUsua.Enter += new System.EventHandler(this.txtConUsua_Enter);
            this.txtConUsua.Leave += new System.EventHandler(this.txtConUsua_Leave);
            // 
            // txtCorUsua
            // 
            this.txtCorUsua.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorUsua.ForeColor = System.Drawing.Color.DimGray;
            this.txtCorUsua.Location = new System.Drawing.Point(24, 301);
            this.txtCorUsua.Name = "txtCorUsua";
            this.txtCorUsua.Size = new System.Drawing.Size(214, 26);
            this.txtCorUsua.TabIndex = 31;
            this.txtCorUsua.Text = "Correo";
            this.txtCorUsua.Enter += new System.EventHandler(this.txtCorUsua_Enter);
            this.txtCorUsua.Leave += new System.EventHandler(this.txtCorUsua_Leave);
            // 
            // txtTelUsua
            // 
            this.txtTelUsua.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelUsua.ForeColor = System.Drawing.Color.DimGray;
            this.txtTelUsua.Location = new System.Drawing.Point(24, 241);
            this.txtTelUsua.Name = "txtTelUsua";
            this.txtTelUsua.Size = new System.Drawing.Size(214, 26);
            this.txtTelUsua.TabIndex = 30;
            this.txtTelUsua.Text = "Telefono";
            this.txtTelUsua.Enter += new System.EventHandler(this.txtTelUsua_Enter);
            this.txtTelUsua.Leave += new System.EventHandler(this.txtTelUsua_Leave);
            // 
            // txtNombreUsua
            // 
            this.txtNombreUsua.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreUsua.ForeColor = System.Drawing.Color.DimGray;
            this.txtNombreUsua.Location = new System.Drawing.Point(24, 183);
            this.txtNombreUsua.Name = "txtNombreUsua";
            this.txtNombreUsua.Size = new System.Drawing.Size(214, 26);
            this.txtNombreUsua.TabIndex = 28;
            this.txtNombreUsua.Text = "Nombre Cliente";
            this.txtNombreUsua.Enter += new System.EventHandler(this.txtNombreUsua_Enter);
            this.txtNombreUsua.Leave += new System.EventHandler(this.txtNombreUsua_Leave);
            // 
            // txtRutUsua
            // 
            this.txtRutUsua.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRutUsua.ForeColor = System.Drawing.Color.DimGray;
            this.txtRutUsua.Location = new System.Drawing.Point(24, 118);
            this.txtRutUsua.Name = "txtRutUsua";
            this.txtRutUsua.Size = new System.Drawing.Size(214, 26);
            this.txtRutUsua.TabIndex = 27;
            this.txtRutUsua.Text = "Rut Cliente";
            this.txtRutUsua.Enter += new System.EventHandler(this.txtRutUsua_Enter);
            this.txtRutUsua.Leave += new System.EventHandler(this.txtRutUsua_Leave);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.DgvClientes);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1036, 584);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Listar Cliente";
            // 
            // DgvClientes
            // 
            this.DgvClientes.AllowUserToAddRows = false;
            this.DgvClientes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnNumeIdenUsuar,
            this.cnUsAd,
            this.cnNombre,
            this.cnContraseña,
            this.cnDireccion,
            this.cnTelefono,
            this.cnCorreo,
            this.cnFeha,
            this.cnCargo,
            this.cnEmpresa});
            this.DgvClientes.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DgvClientes.Location = new System.Drawing.Point(274, 49);
            this.DgvClientes.Name = "DgvClientes";
            this.DgvClientes.Size = new System.Drawing.Size(733, 399);
            this.DgvClientes.TabIndex = 94;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(464, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(412, 13);
            this.label3.TabIndex = 102;
            this.label3.Text = "---------------------------------------------------------------------------------" +
    "------------------------------------------------------";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(572, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(205, 28);
            this.label8.TabIndex = 101;
            this.label8.Text = "Lista De Usuarios";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscarDire);
            this.groupBox1.Controls.Add(this.cmbDireEdit);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnLimpiarDire);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnModificar);
            this.groupBox1.Controls.Add(this.cmbEmpresaEdit);
            this.groupBox1.Controls.Add(this.cmbCargoEdit);
            this.groupBox1.Controls.Add(this.txtConEdit);
            this.groupBox1.Controls.Add(this.txtRutEdit);
            this.groupBox1.Controls.Add(this.txtTeleEdit);
            this.groupBox1.Controls.Add(this.txtNomEdit);
            this.groupBox1.Controls.Add(this.txtCorEdit);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 566);
            this.groupBox1.TabIndex = 96;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modificar Usuario";
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(6, 520);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(250, 40);
            this.button2.TabIndex = 98;
            this.button2.Text = "Eliminar Cliente";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(10, 437);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(216, 40);
            this.btnEdit.TabIndex = 68;
            this.btnEdit.Text = "Editar Cliente";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(6, 474);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(216, 40);
            this.btnModificar.TabIndex = 97;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // cmbEmpresaEdit
            // 
            this.cmbEmpresaEdit.ForeColor = System.Drawing.Color.DimGray;
            this.cmbEmpresaEdit.FormattingEnabled = true;
            this.cmbEmpresaEdit.Location = new System.Drawing.Point(12, 244);
            this.cmbEmpresaEdit.Name = "cmbEmpresaEdit";
            this.cmbEmpresaEdit.Size = new System.Drawing.Size(214, 27);
            this.cmbEmpresaEdit.TabIndex = 86;
            this.cmbEmpresaEdit.Text = "Empresa";
            // 
            // cmbCargoEdit
            // 
            this.cmbCargoEdit.DisplayMember = "1";
            this.cmbCargoEdit.ForeColor = System.Drawing.Color.DimGray;
            this.cmbCargoEdit.FormattingEnabled = true;
            this.cmbCargoEdit.Location = new System.Drawing.Point(12, 211);
            this.cmbCargoEdit.Name = "cmbCargoEdit";
            this.cmbCargoEdit.Size = new System.Drawing.Size(214, 27);
            this.cmbCargoEdit.TabIndex = 82;
            this.cmbCargoEdit.Text = "Cargo";
            this.cmbCargoEdit.ValueMember = "0";
            // 
            // txtConEdit
            // 
            this.txtConEdit.ForeColor = System.Drawing.Color.DimGray;
            this.txtConEdit.Location = new System.Drawing.Point(12, 178);
            this.txtConEdit.Name = "txtConEdit";
            this.txtConEdit.Size = new System.Drawing.Size(214, 27);
            this.txtConEdit.TabIndex = 78;
            this.txtConEdit.Text = "Nueva contraseña";
            this.txtConEdit.Enter += new System.EventHandler(this.txtConEdit_Enter);
            this.txtConEdit.Leave += new System.EventHandler(this.txtConEdit_Leave);
            // 
            // txtRutEdit
            // 
            this.txtRutEdit.ForeColor = System.Drawing.Color.DimGray;
            this.txtRutEdit.Location = new System.Drawing.Point(12, 46);
            this.txtRutEdit.Name = "txtRutEdit";
            this.txtRutEdit.Size = new System.Drawing.Size(214, 27);
            this.txtRutEdit.TabIndex = 81;
            this.txtRutEdit.Text = "Rut Cliente";
            this.txtRutEdit.Enter += new System.EventHandler(this.txtRutEdit_Enter);
            this.txtRutEdit.Leave += new System.EventHandler(this.txtRutEdit_Leave);
            // 
            // txtTeleEdit
            // 
            this.txtTeleEdit.ForeColor = System.Drawing.Color.DimGray;
            this.txtTeleEdit.Location = new System.Drawing.Point(12, 112);
            this.txtTeleEdit.Name = "txtTeleEdit";
            this.txtTeleEdit.Size = new System.Drawing.Size(214, 27);
            this.txtTeleEdit.TabIndex = 76;
            this.txtTeleEdit.Text = "Telefono";
            this.txtTeleEdit.Enter += new System.EventHandler(this.txtTeleEdit_Enter);
            this.txtTeleEdit.Leave += new System.EventHandler(this.txtTeleEdit_Leave);
            // 
            // txtNomEdit
            // 
            this.txtNomEdit.ForeColor = System.Drawing.Color.DimGray;
            this.txtNomEdit.Location = new System.Drawing.Point(12, 79);
            this.txtNomEdit.Name = "txtNomEdit";
            this.txtNomEdit.Size = new System.Drawing.Size(214, 27);
            this.txtNomEdit.TabIndex = 74;
            this.txtNomEdit.Text = "Nombre Cliente";
            this.txtNomEdit.Enter += new System.EventHandler(this.txtNomEdit_Enter);
            this.txtNomEdit.Leave += new System.EventHandler(this.txtNomEdit_Leave);
            // 
            // txtCorEdit
            // 
            this.txtCorEdit.ForeColor = System.Drawing.Color.DimGray;
            this.txtCorEdit.Location = new System.Drawing.Point(12, 145);
            this.txtCorEdit.Name = "txtCorEdit";
            this.txtCorEdit.Size = new System.Drawing.Size(214, 27);
            this.txtCorEdit.TabIndex = 77;
            this.txtCorEdit.Text = "Correo";
            this.txtCorEdit.Enter += new System.EventHandler(this.txtCorEdit_Enter);
            this.txtCorEdit.Leave += new System.EventHandler(this.txtCorEdit_Leave);
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
            // cmbDireEdit
            // 
            this.cmbDireEdit.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDireEdit.ForeColor = System.Drawing.Color.Black;
            this.cmbDireEdit.FormattingEnabled = true;
            this.cmbDireEdit.Location = new System.Drawing.Point(0, 277);
            this.cmbDireEdit.Name = "cmbDireEdit";
            this.cmbDireEdit.Size = new System.Drawing.Size(227, 28);
            this.cmbDireEdit.TabIndex = 109;
            this.cmbDireEdit.Text = "Direccion";
            // 
            // btnBuscarDire
            // 
            this.btnBuscarDire.FlatAppearance.BorderSize = 0;
            this.btnBuscarDire.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscarDire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarDire.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarDire.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarDire.Image")));
            this.btnBuscarDire.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarDire.Location = new System.Drawing.Point(21, 311);
            this.btnBuscarDire.Name = "btnBuscarDire";
            this.btnBuscarDire.Size = new System.Drawing.Size(183, 40);
            this.btnBuscarDire.TabIndex = 111;
            this.btnBuscarDire.Text = "     Buscar Direccion";
            this.btnBuscarDire.UseVisualStyleBackColor = true;
            // 
            // btnLimpiarDire
            // 
            this.btnLimpiarDire.FlatAppearance.BorderSize = 0;
            this.btnLimpiarDire.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnLimpiarDire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarDire.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarDire.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiarDire.Image")));
            this.btnLimpiarDire.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiarDire.Location = new System.Drawing.Point(21, 357);
            this.btnLimpiarDire.Name = "btnLimpiarDire";
            this.btnLimpiarDire.Size = new System.Drawing.Size(174, 40);
            this.btnLimpiarDire.TabIndex = 110;
            this.btnLimpiarDire.Text = "       Limpiar Direccion";
            this.btnLimpiarDire.UseVisualStyleBackColor = true;
            // 
            // cnNumeIdenUsuar
            // 
            this.cnNumeIdenUsuar.DataPropertyName = "numero_identificacion_usuario";
            this.cnNumeIdenUsuar.HeaderText = "Numero Identificacion Usuario";
            this.cnNumeIdenUsuar.Name = "cnNumeIdenUsuar";
            // 
            // cnUsAd
            // 
            this.cnUsAd.DataPropertyName = "administrador_usuario";
            this.cnUsAd.HeaderText = "usad";
            this.cnUsAd.Name = "cnUsAd";
            this.cnUsAd.Visible = false;
            // 
            // cnNombre
            // 
            this.cnNombre.DataPropertyName = "nombre_usuario";
            this.cnNombre.HeaderText = "Nombre Usuario";
            this.cnNombre.Name = "cnNombre";
            // 
            // cnContraseña
            // 
            this.cnContraseña.DataPropertyName = "contrasena_usuario";
            this.cnContraseña.HeaderText = "Contraseña Usuario";
            this.cnContraseña.Name = "cnContraseña";
            // 
            // cnDireccion
            // 
            this.cnDireccion.DataPropertyName = "direccion_usuario";
            this.cnDireccion.HeaderText = "Direccion Usuario";
            this.cnDireccion.Name = "cnDireccion";
            // 
            // cnTelefono
            // 
            this.cnTelefono.DataPropertyName = "telefono_usuario";
            this.cnTelefono.HeaderText = "Telefono Usuario";
            this.cnTelefono.Name = "cnTelefono";
            // 
            // cnCorreo
            // 
            this.cnCorreo.DataPropertyName = "correo_usuario";
            this.cnCorreo.HeaderText = "Correo";
            this.cnCorreo.Name = "cnCorreo";
            // 
            // cnFeha
            // 
            this.cnFeha.DataPropertyName = "fecha_creacion_usuario";
            this.cnFeha.HeaderText = "Fecha Creacion";
            this.cnFeha.Name = "cnFeha";
            // 
            // cnCargo
            // 
            this.cnCargo.DataPropertyName = "id_cargo";
            this.cnCargo.HeaderText = "Cargo Usuario";
            this.cnCargo.Name = "cnCargo";
            // 
            // cnEmpresa
            // 
            this.cnEmpresa.DataPropertyName = "id_empresa";
            this.cnEmpresa.HeaderText = "Empresa";
            this.cnEmpresa.Name = "cnEmpresa";
            // 
            // Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 617);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Usuario";
            this.Text = "ta";
            this.Load += new System.EventHandler(this.Clientes_Carga);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvClientes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtConUsua;
        private System.Windows.Forms.TextBox txtCorUsua;
        private System.Windows.Forms.TextBox txtTelUsua;
        private System.Windows.Forms.TextBox txtNombreUsua;
        private System.Windows.Forms.TextBox txtRutUsua;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.ComboBox cmbCargo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cmbEmpresaEdit;
        private System.Windows.Forms.ComboBox cmbCargoEdit;
        private System.Windows.Forms.TextBox txtConEdit;
        private System.Windows.Forms.TextBox txtRutEdit;
        private System.Windows.Forms.TextBox txtTeleEdit;
        private System.Windows.Forms.TextBox txtNomEdit;
        private System.Windows.Forms.TextBox txtCorEdit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView DgvClientes;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBuscDir;
        private System.Windows.Forms.Button btnLimpiarDir;
        private System.Windows.Forms.ComboBox cmbDire;
        private System.Windows.Forms.ComboBox cmbDireEdit;
        private System.Windows.Forms.Button btnBuscarDire;
        private System.Windows.Forms.Button btnLimpiarDire;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnNumeIdenUsuar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnUsAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnContraseña;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnFeha;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnEmpresa;
    }
}