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
            this.txt_Id = new System.Windows.Forms.TextBox();
            this.abrir = new System.Windows.Forms.Button();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Crear_Contrato = new System.Windows.Forms.Button();
            this.cmb_TipoEmpresa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(288, 198);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // txt_TipoContrato
            // 
            this.txt_TipoContrato.Location = new System.Drawing.Point(288, 304);
            this.txt_TipoContrato.Name = "txt_TipoContrato";
            this.txt_TipoContrato.Size = new System.Drawing.Size(200, 20);
            this.txt_TipoContrato.TabIndex = 1;
            // 
            // txt_Id
            // 
            this.txt_Id.Location = new System.Drawing.Point(288, 125);
            this.txt_Id.Name = "txt_Id";
            this.txt_Id.Size = new System.Drawing.Size(200, 20);
            this.txt_Id.TabIndex = 2;
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
            this.Crear_Contrato.Location = new System.Drawing.Point(318, 398);
            this.Crear_Contrato.Name = "Crear_Contrato";
            this.Crear_Contrato.Size = new System.Drawing.Size(125, 23);
            this.Crear_Contrato.TabIndex = 5;
            this.Crear_Contrato.Text = "Crear Contrato";
            this.Crear_Contrato.UseVisualStyleBackColor = true;
            this.Crear_Contrato.Click += new System.EventHandler(this.Crear_Contrato_Click);
            // 
            // cmb_TipoEmpresa
            // 
            this.cmb_TipoEmpresa.FormattingEnabled = true;
            this.cmb_TipoEmpresa.Location = new System.Drawing.Point(288, 349);
            this.cmb_TipoEmpresa.Name = "cmb_TipoEmpresa";
            this.cmb_TipoEmpresa.Size = new System.Drawing.Size(200, 21);
            this.cmb_TipoEmpresa.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(294, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "Creacion de Contrato";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(163, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 25);
            this.label5.TabIndex = 24;
            this.label5.Text = "Id Contrato";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(105, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 25);
            this.label2.TabIndex = 25;
            this.label2.Text = "Fecha De Contrato";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(140, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 25);
            this.label3.TabIndex = 26;
            this.label3.Text = "Tipo Contrato";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(163, 345);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 25);
            this.label4.TabIndex = 27;
            this.label4.Text = "Empresa";
            // 
            // Contrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_TipoEmpresa);
            this.Controls.Add(this.Crear_Contrato);
            this.Controls.Add(this.lblArchivo);
            this.Controls.Add(this.abrir);
            this.Controls.Add(this.txt_Id);
            this.Controls.Add(this.txt_TipoContrato);
            this.Controls.Add(this.dateTimePicker1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Contrato";
            this.Text = "Contrato";
            this.Load += new System.EventHandler(this.Cargar_Empresa);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txt_TipoContrato;
        private System.Windows.Forms.TextBox txt_Id;
        private System.Windows.Forms.Button abrir;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button Crear_Contrato;
        private System.Windows.Forms.ComboBox cmb_TipoEmpresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}