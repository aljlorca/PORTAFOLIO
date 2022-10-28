
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
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbEmpresa = new System.Windows.Forms.ComboBox();
            this.cmbCiudad = new System.Windows.Forms.ComboBox();
            this.cmbRegion = new System.Windows.Forms.ComboBox();
            this.cmbPais = new System.Windows.Forms.ComboBox();
            this.cmbCargo = new System.Windows.Forms.ComboBox();
            this.btnCrear = new System.Windows.Forms.Button();
            this.txtConUsua = new System.Windows.Forms.TextBox();
            this.txtCorUsua = new System.Windows.Forms.TextBox();
            this.txtTelUsua = new System.Windows.Forms.TextBox();
            this.txtDirecUsua = new System.Windows.Forms.TextBox();
            this.txtNombreUsua = new System.Windows.Forms.TextBox();
            this.txtRutUsua = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.cmbEmpresaEdit = new System.Windows.Forms.ComboBox();
            this.cmbCiudadEdit = new System.Windows.Forms.ComboBox();
            this.cmbRegionEdit = new System.Windows.Forms.ComboBox();
            this.cmbPaisEdit = new System.Windows.Forms.ComboBox();
            this.cmbCargoEdit = new System.Windows.Forms.ComboBox();
            this.txtConEdit = new System.Windows.Forms.TextBox();
            this.txtRutEdit = new System.Windows.Forms.TextBox();
            this.txtTeleEdit = new System.Windows.Forms.TextBox();
            this.txtDirEdit = new System.Windows.Forms.TextBox();
            this.txtNomEdit = new System.Windows.Forms.TextBox();
            this.txtCorEdit = new System.Windows.Forms.TextBox();
            this.DgvClientes = new System.Windows.Forms.DataGridView();
            this.cnNumeIdenUsuar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnFeha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCiudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnRegion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnPais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvClientes)).BeginInit();
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
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.cmbEmpresa);
            this.tabPage1.Controls.Add(this.cmbCiudad);
            this.tabPage1.Controls.Add(this.cmbRegion);
            this.tabPage1.Controls.Add(this.cmbPais);
            this.tabPage1.Controls.Add(this.cmbCargo);
            this.tabPage1.Controls.Add(this.btnCrear);
            this.tabPage1.Controls.Add(this.txtConUsua);
            this.tabPage1.Controls.Add(this.txtCorUsua);
            this.tabPage1.Controls.Add(this.txtTelUsua);
            this.tabPage1.Controls.Add(this.txtDirecUsua);
            this.tabPage1.Controls.Add(this.txtNombreUsua);
            this.tabPage1.Controls.Add(this.txtRutUsua);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1036, 584);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Crear Cliente";
            this.tabPage1.Enter += new System.EventHandler(this.tabPage1_Enter);
            this.tabPage1.Leave += new System.EventHandler(this.tabPage1_Leave);
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
            this.cmbEmpresa.Location = new System.Drawing.Point(373, 354);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(214, 26);
            this.cmbEmpresa.TabIndex = 39;
            this.cmbEmpresa.Text = "Empresa";
            this.cmbEmpresa.Enter += new System.EventHandler(this.cmbEmpresa_Enter);
            this.cmbEmpresa.Leave += new System.EventHandler(this.cmbEmpresa_Leave);
            // 
            // cmbCiudad
            // 
            this.cmbCiudad.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCiudad.ForeColor = System.Drawing.Color.DimGray;
            this.cmbCiudad.FormattingEnabled = true;
            this.cmbCiudad.Location = new System.Drawing.Point(373, 294);
            this.cmbCiudad.Name = "cmbCiudad";
            this.cmbCiudad.Size = new System.Drawing.Size(214, 26);
            this.cmbCiudad.TabIndex = 38;
            this.cmbCiudad.Text = "Ciudad";
            this.cmbCiudad.Enter += new System.EventHandler(this.cmbCiudad_Enter);
            this.cmbCiudad.Leave += new System.EventHandler(this.cmbCiudad_Leave);
            // 
            // cmbRegion
            // 
            this.cmbRegion.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRegion.ForeColor = System.Drawing.Color.DimGray;
            this.cmbRegion.FormattingEnabled = true;
            this.cmbRegion.Location = new System.Drawing.Point(373, 239);
            this.cmbRegion.Name = "cmbRegion";
            this.cmbRegion.Size = new System.Drawing.Size(214, 26);
            this.cmbRegion.TabIndex = 37;
            this.cmbRegion.Text = "Region";
            this.cmbRegion.SelectionChangeCommitted += new System.EventHandler(this.cmbRegion_SelectionChangeCommitted);
            this.cmbRegion.Enter += new System.EventHandler(this.cmbRegion_Enter);
            this.cmbRegion.Leave += new System.EventHandler(this.cmbRegion_Leave);
            // 
            // cmbPais
            // 
            this.cmbPais.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPais.ForeColor = System.Drawing.Color.DimGray;
            this.cmbPais.FormattingEnabled = true;
            this.cmbPais.Location = new System.Drawing.Point(373, 182);
            this.cmbPais.Name = "cmbPais";
            this.cmbPais.Size = new System.Drawing.Size(214, 26);
            this.cmbPais.TabIndex = 36;
            this.cmbPais.Text = "Pais";
            this.cmbPais.SelectionChangeCommitted += new System.EventHandler(this.cmbPais_SelectionChangeCommitted);
            this.cmbPais.Enter += new System.EventHandler(this.cmbPais_Enter);
            this.cmbPais.Leave += new System.EventHandler(this.cmbPais_Leave);
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
            this.cmbCargo.SelectedIndexChanged += new System.EventHandler(this.cmbCargo_SelectedIndexChanged);
            this.cmbCargo.Enter += new System.EventHandler(this.cmbCargo_Enter);
            this.cmbCargo.Leave += new System.EventHandler(this.cmbCargo_Leave);
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
            this.txtConUsua.Location = new System.Drawing.Point(24, 432);
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
            this.txtCorUsua.Location = new System.Drawing.Point(24, 354);
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
            this.txtTelUsua.Location = new System.Drawing.Point(24, 294);
            this.txtTelUsua.Name = "txtTelUsua";
            this.txtTelUsua.Size = new System.Drawing.Size(214, 26);
            this.txtTelUsua.TabIndex = 30;
            this.txtTelUsua.Text = "Telefono";
            this.txtTelUsua.Enter += new System.EventHandler(this.txtTelUsua_Enter);
            this.txtTelUsua.Leave += new System.EventHandler(this.txtTelUsua_Leave);
            // 
            // txtDirecUsua
            // 
            this.txtDirecUsua.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDirecUsua.ForeColor = System.Drawing.Color.DimGray;
            this.txtDirecUsua.Location = new System.Drawing.Point(24, 239);
            this.txtDirecUsua.Name = "txtDirecUsua";
            this.txtDirecUsua.Size = new System.Drawing.Size(214, 26);
            this.txtDirecUsua.TabIndex = 29;
            this.txtDirecUsua.Text = "Direccion";
            this.txtDirecUsua.Enter += new System.EventHandler(this.txtDirecUsua_Enter);
            this.txtDirecUsua.Leave += new System.EventHandler(this.txtDirecUsua_Leave);
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
            this.txtRutUsua.TextChanged += new System.EventHandler(this.txtRutUsua_TextChanged);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(464, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(412, 13);
            this.label3.TabIndex = 102;
            this.label3.Text = "---------------------------------------------------------------------------------" +
    "------------------------------------------------------";
            this.label3.Click += new System.EventHandler(this.label3_Click);
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
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnModificar);
            this.groupBox1.Controls.Add(this.cmbEmpresaEdit);
            this.groupBox1.Controls.Add(this.cmbCiudadEdit);
            this.groupBox1.Controls.Add(this.cmbRegionEdit);
            this.groupBox1.Controls.Add(this.cmbPaisEdit);
            this.groupBox1.Controls.Add(this.cmbCargoEdit);
            this.groupBox1.Controls.Add(this.txtConEdit);
            this.groupBox1.Controls.Add(this.txtRutEdit);
            this.groupBox1.Controls.Add(this.txtTeleEdit);
            this.groupBox1.Controls.Add(this.txtDirEdit);
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
            this.btnEdit.Location = new System.Drawing.Point(6, 437);
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
            this.cmbEmpresaEdit.Location = new System.Drawing.Point(17, 395);
            this.cmbEmpresaEdit.Name = "cmbEmpresaEdit";
            this.cmbEmpresaEdit.Size = new System.Drawing.Size(214, 27);
            this.cmbEmpresaEdit.TabIndex = 86;
            this.cmbEmpresaEdit.Text = "Empresa";
            // 
            // cmbCiudadEdit
            // 
            this.cmbCiudadEdit.ForeColor = System.Drawing.Color.DimGray;
            this.cmbCiudadEdit.FormattingEnabled = true;
            this.cmbCiudadEdit.Location = new System.Drawing.Point(17, 362);
            this.cmbCiudadEdit.Name = "cmbCiudadEdit";
            this.cmbCiudadEdit.Size = new System.Drawing.Size(214, 27);
            this.cmbCiudadEdit.TabIndex = 85;
            this.cmbCiudadEdit.Text = "Ciudad";
            // 
            // cmbRegionEdit
            // 
            this.cmbRegionEdit.ForeColor = System.Drawing.Color.DimGray;
            this.cmbRegionEdit.FormattingEnabled = true;
            this.cmbRegionEdit.Location = new System.Drawing.Point(17, 329);
            this.cmbRegionEdit.Name = "cmbRegionEdit";
            this.cmbRegionEdit.Size = new System.Drawing.Size(214, 27);
            this.cmbRegionEdit.TabIndex = 84;
            this.cmbRegionEdit.Text = "Region";
            this.cmbRegionEdit.SelectionChangeCommitted += new System.EventHandler(this.cmbRegion_SelectionChangeCommitted);
            this.cmbRegionEdit.TextUpdate += new System.EventHandler(this.cmbRegion_SelectionChangeCommitted);
            // 
            // cmbPaisEdit
            // 
            this.cmbPaisEdit.ForeColor = System.Drawing.Color.DimGray;
            this.cmbPaisEdit.FormattingEnabled = true;
            this.cmbPaisEdit.Location = new System.Drawing.Point(17, 296);
            this.cmbPaisEdit.Name = "cmbPaisEdit";
            this.cmbPaisEdit.Size = new System.Drawing.Size(214, 27);
            this.cmbPaisEdit.TabIndex = 83;
            this.cmbPaisEdit.Text = "Pais";
            this.cmbPaisEdit.SelectionChangeCommitted += new System.EventHandler(this.cmbPais_SelectionChangeCommitted);
            this.cmbPaisEdit.TextUpdate += new System.EventHandler(this.cmbPais_SelectionChangeCommitted);
            // 
            // cmbCargoEdit
            // 
            this.cmbCargoEdit.DisplayMember = "1";
            this.cmbCargoEdit.ForeColor = System.Drawing.Color.DimGray;
            this.cmbCargoEdit.FormattingEnabled = true;
            this.cmbCargoEdit.Location = new System.Drawing.Point(17, 263);
            this.cmbCargoEdit.Name = "cmbCargoEdit";
            this.cmbCargoEdit.Size = new System.Drawing.Size(214, 27);
            this.cmbCargoEdit.TabIndex = 82;
            this.cmbCargoEdit.Text = "Cargo";
            this.cmbCargoEdit.ValueMember = "0";
            // 
            // txtConEdit
            // 
            this.txtConEdit.ForeColor = System.Drawing.Color.DimGray;
            this.txtConEdit.Location = new System.Drawing.Point(17, 230);
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
            this.txtRutEdit.Location = new System.Drawing.Point(17, 59);
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
            this.txtTeleEdit.Location = new System.Drawing.Point(17, 164);
            this.txtTeleEdit.Name = "txtTeleEdit";
            this.txtTeleEdit.Size = new System.Drawing.Size(214, 27);
            this.txtTeleEdit.TabIndex = 76;
            this.txtTeleEdit.Text = "Telefono";
            this.txtTeleEdit.Enter += new System.EventHandler(this.txtTeleEdit_Enter);
            this.txtTeleEdit.Leave += new System.EventHandler(this.txtTeleEdit_Leave);
            // 
            // txtDirEdit
            // 
            this.txtDirEdit.ForeColor = System.Drawing.Color.DimGray;
            this.txtDirEdit.Location = new System.Drawing.Point(17, 129);
            this.txtDirEdit.Name = "txtDirEdit";
            this.txtDirEdit.Size = new System.Drawing.Size(214, 27);
            this.txtDirEdit.TabIndex = 75;
            this.txtDirEdit.Text = "Direccion";
            this.txtDirEdit.Enter += new System.EventHandler(this.txtDirEdit_Enter);
            this.txtDirEdit.Leave += new System.EventHandler(this.txtDirEdit_Leave);
            // 
            // txtNomEdit
            // 
            this.txtNomEdit.ForeColor = System.Drawing.Color.DimGray;
            this.txtNomEdit.Location = new System.Drawing.Point(17, 96);
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
            this.txtCorEdit.Location = new System.Drawing.Point(17, 197);
            this.txtCorEdit.Name = "txtCorEdit";
            this.txtCorEdit.Size = new System.Drawing.Size(214, 27);
            this.txtCorEdit.TabIndex = 77;
            this.txtCorEdit.Text = "Correo";
            this.txtCorEdit.Enter += new System.EventHandler(this.txtCorEdit_Enter);
            this.txtCorEdit.Leave += new System.EventHandler(this.txtCorEdit_Leave);
            // 
            // DgvClientes
            // 
            this.DgvClientes.AllowUserToAddRows = false;
            this.DgvClientes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnNumeIdenUsuar,
            this.cnNombre,
            this.cnDireccion,
            this.cnTelefono,
            this.cnCorreo,
            this.cnFeha,
            this.cnCargo,
            this.cnEmpresa,
            this.cnCiudad,
            this.cnRegion,
            this.cnPais});
            this.DgvClientes.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DgvClientes.Location = new System.Drawing.Point(240, 49);
            this.DgvClientes.Name = "DgvClientes";
            this.DgvClientes.Size = new System.Drawing.Size(793, 529);
            this.DgvClientes.TabIndex = 94;
            // 
            // cnNumeIdenUsuar
            // 
            this.cnNumeIdenUsuar.DataPropertyName = "numero_identificacion_usuario";
            this.cnNumeIdenUsuar.HeaderText = "Numero Identificacion Usuario";
            this.cnNumeIdenUsuar.Name = "cnNumeIdenUsuar";
            // 
            // cnNombre
            // 
            this.cnNombre.DataPropertyName = "nombre_usuario";
            this.cnNombre.HeaderText = "Nombre Usuario";
            this.cnNombre.Name = "cnNombre";
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
            // cnCiudad
            // 
            this.cnCiudad.DataPropertyName = "id_ciudad";
            this.cnCiudad.HeaderText = "Ciudad";
            this.cnCiudad.Name = "cnCiudad";
            // 
            // cnRegion
            // 
            this.cnRegion.DataPropertyName = "id_region";
            this.cnRegion.HeaderText = "Region";
            this.cnRegion.Name = "cnRegion";
            // 
            // cnPais
            // 
            this.cnPais.DataPropertyName = "id_pais";
            this.cnPais.HeaderText = "Pais";
            this.cnPais.Name = "cnPais";
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtConUsua;
        private System.Windows.Forms.TextBox txtCorUsua;
        private System.Windows.Forms.TextBox txtTelUsua;
        private System.Windows.Forms.TextBox txtDirecUsua;
        private System.Windows.Forms.TextBox txtNombreUsua;
        private System.Windows.Forms.TextBox txtRutUsua;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.ComboBox cmbCiudad;
        private System.Windows.Forms.ComboBox cmbRegion;
        private System.Windows.Forms.ComboBox cmbPais;
        private System.Windows.Forms.ComboBox cmbCargo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cmbEmpresaEdit;
        private System.Windows.Forms.ComboBox cmbCiudadEdit;
        private System.Windows.Forms.ComboBox cmbRegionEdit;
        private System.Windows.Forms.ComboBox cmbPaisEdit;
        private System.Windows.Forms.ComboBox cmbCargoEdit;
        private System.Windows.Forms.TextBox txtConEdit;
        private System.Windows.Forms.TextBox txtRutEdit;
        private System.Windows.Forms.TextBox txtTeleEdit;
        private System.Windows.Forms.TextBox txtDirEdit;
        private System.Windows.Forms.TextBox txtNomEdit;
        private System.Windows.Forms.TextBox txtCorEdit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView DgvClientes;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnNumeIdenUsuar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnFeha;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCiudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnRegion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnPais;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
    }
}