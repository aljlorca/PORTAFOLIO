namespace MercadoChile.Template
{
    partial class Contrato
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txt_TipoContrato = new System.Windows.Forms.TextBox();
            this.abrir = new System.Windows.Forms.Button();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Crear_Contrato = new System.Windows.Forms.Button();
            this.cmb_TipoEmpresa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNacionalidad = new System.Windows.Forms.TextBox();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDireccionCliente = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRut = new System.Windows.Forms.TextBox();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(548, 171);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // txt_TipoContrato
            // 
            this.txt_TipoContrato.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TipoContrato.ForeColor = System.Drawing.Color.DimGray;
            this.txt_TipoContrato.Location = new System.Drawing.Point(205, 171);
            this.txt_TipoContrato.Name = "txt_TipoContrato";
            this.txt_TipoContrato.Size = new System.Drawing.Size(200, 26);
            this.txt_TipoContrato.TabIndex = 1;
            this.txt_TipoContrato.Text = "Tipo Empresa";
            this.txt_TipoContrato.TextChanged += new System.EventHandler(this.txt_TipoContrato_TextChanged);
            // 
            // abrir
            // 
            this.abrir.Location = new System.Drawing.Point(0, 0);
            this.abrir.Name = "abrir";
            this.abrir.Size = new System.Drawing.Size(75, 23);
            this.abrir.TabIndex = 8;
            // 
            // lblArchivo
            // 
            this.lblArchivo.Location = new System.Drawing.Point(0, 0);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(100, 23);
            this.lblArchivo.TabIndex = 7;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "PDF Files(*.pdf)|*.pdf|All Files(*.*)|*.*";
            // 
            // Crear_Contrato
            // 
            this.Crear_Contrato.Location = new System.Drawing.Point(440, 341);
            this.Crear_Contrato.Name = "Crear_Contrato";
            this.Crear_Contrato.Size = new System.Drawing.Size(125, 23);
            this.Crear_Contrato.TabIndex = 5;
            this.Crear_Contrato.Text = "Crear Contrato";
            this.Crear_Contrato.UseVisualStyleBackColor = true;
            this.Crear_Contrato.Click += new System.EventHandler(this.Crear_Contrato_Click);
            // 
            // cmb_TipoEmpresa
            // 
            this.cmb_TipoEmpresa.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_TipoEmpresa.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_TipoEmpresa.FormattingEnabled = true;
            this.cmb_TipoEmpresa.Location = new System.Drawing.Point(205, 225);
            this.cmb_TipoEmpresa.Name = "cmb_TipoEmpresa";
            this.cmb_TipoEmpresa.Size = new System.Drawing.Size(200, 28);
            this.cmb_TipoEmpresa.TabIndex = 6;
            this.cmb_TipoEmpresa.Text = "Empresa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(380, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "Ingreso de Contrato";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(555, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 25);
            this.label2.TabIndex = 25;
            this.label2.Text = "Fecha De Contrato";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1003, 567);
            this.tabControl1.TabIndex = 28;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.Crear_Contrato);
            this.tabPage1.Controls.Add(this.cmb_TipoEmpresa);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.txt_TipoContrato);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(995, 541);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ingreso Contrato";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(545, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(196, 13);
            this.label7.TabIndex = 105;
            this.label7.Text = "---------------------------------------------------------------";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(282, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(412, 13);
            this.label6.TabIndex = 104;
            this.label6.Text = "---------------------------------------------------------------------------------" +
    "------------------------------------------------------";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.txtNacionalidad);
            this.tabPage2.Controls.Add(this.txtCargo);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.txtDireccionCliente);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.txtRut);
            this.tabPage2.Controls.Add(this.txtNombreCliente);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(995, 541);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Creacion Contrato";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(195, 262);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(139, 23);
            this.label12.TabIndex = 120;
            this.label12.Text = "Nacionalidad";
            // 
            // txtNacionalidad
            // 
            this.txtNacionalidad.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNacionalidad.ForeColor = System.Drawing.Color.DimGray;
            this.txtNacionalidad.Location = new System.Drawing.Point(375, 259);
            this.txtNacionalidad.Name = "txtNacionalidad";
            this.txtNacionalidad.Size = new System.Drawing.Size(214, 26);
            this.txtNacionalidad.TabIndex = 119;
            this.txtNacionalidad.Text = "Nacionalidad";
            this.txtNacionalidad.Enter += new System.EventHandler(this.NacionalidadEnter);
            this.txtNacionalidad.Leave += new System.EventHandler(this.txtNacionalidad_Leave);
            // 
            // txtCargo
            // 
            this.txtCargo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCargo.ForeColor = System.Drawing.Color.DimGray;
            this.txtCargo.Location = new System.Drawing.Point(375, 309);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(214, 26);
            this.txtCargo.TabIndex = 118;
            this.txtCargo.Text = "Cargo";
            this.txtCargo.Enter += new System.EventHandler(this.CargoEnter);
            this.txtCargo.Leave += new System.EventHandler(this.Cargo);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(195, 312);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 23);
            this.label11.TabIndex = 117;
            this.label11.Text = "Cargo";
            // 
            // txtDireccionCliente
            // 
            this.txtDireccionCliente.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccionCliente.ForeColor = System.Drawing.Color.DimGray;
            this.txtDireccionCliente.Location = new System.Drawing.Point(375, 203);
            this.txtDireccionCliente.Name = "txtDireccionCliente";
            this.txtDireccionCliente.Size = new System.Drawing.Size(214, 26);
            this.txtDireccionCliente.TabIndex = 116;
            this.txtDireccionCliente.Text = "Direccion ";
            this.txtDireccionCliente.Enter += new System.EventHandler(this.DireccionEnter);
            this.txtDireccionCliente.Leave += new System.EventHandler(this.DireccionLeave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(195, 206);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(174, 23);
            this.label10.TabIndex = 115;
            this.label10.Text = "Direccion_Cliente";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(195, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 23);
            this.label9.TabIndex = 114;
            this.label9.Text = "Nombre_Cliente";
            // 
            // txtRut
            // 
            this.txtRut.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRut.ForeColor = System.Drawing.Color.DimGray;
            this.txtRut.Location = new System.Drawing.Point(375, 102);
            this.txtRut.Name = "txtRut";
            this.txtRut.Size = new System.Drawing.Size(214, 26);
            this.txtRut.TabIndex = 113;
            this.txtRut.Text = "Rut Cliente ";
            this.txtRut.Enter += new System.EventHandler(this.rutCliente);
            this.txtRut.Leave += new System.EventHandler(this.rutClienteLeave);
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCliente.ForeColor = System.Drawing.Color.DimGray;
            this.txtNombreCliente.Location = new System.Drawing.Point(375, 150);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(214, 26);
            this.txtNombreCliente.TabIndex = 112;
            this.txtNombreCliente.Text = "Nombre Cliente";
            this.txtNombreCliente.Enter += new System.EventHandler(this.nombreClienteEnter);
            this.txtNombreCliente.Leave += new System.EventHandler(this.nombreClienteLeave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(195, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 23);
            this.label8.TabIndex = 111;
            this.label8.Text = "Rut Cliente ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(114, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 107;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(412, 13);
            this.label3.TabIndex = 106;
            this.label3.Text = "---------------------------------------------------------------------------------" +
    "------------------------------------------------------";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(370, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 25);
            this.label4.TabIndex = 105;
            this.label4.Text = "Creacion de Contrato";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(375, 407);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generacion Contrato";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Contrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 569);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblArchivo);
            this.Controls.Add(this.abrir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Contrato";
            this.Text = "Contrato";
            this.Load += new System.EventHandler(this.Cargar_Empresa);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txt_TipoContrato;
        private System.Windows.Forms.Button abrir;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button Crear_Contrato;
        private System.Windows.Forms.ComboBox cmb_TipoEmpresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRut;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.TextBox txtDireccionCliente;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCargo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNacionalidad;
    }
}