namespace MercadoChile
{
    partial class inicioSesion
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
            this.iniciar = new System.Windows.Forms.Button();
            this.txtrut_admin = new System.Windows.Forms.TextBox();
            this.txtcontraseña_admin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contraseña = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // iniciar
            // 
            this.iniciar.Location = new System.Drawing.Point(110, 240);
            this.iniciar.Name = "iniciar";
            this.iniciar.Size = new System.Drawing.Size(75, 23);
            this.iniciar.TabIndex = 0;
            this.iniciar.Text = "iniciar";
            this.iniciar.UseVisualStyleBackColor = true;
            this.iniciar.Click += new System.EventHandler(this.iniciar_Click);
            // 
            // txtrut_admin
            // 
            this.txtrut_admin.Location = new System.Drawing.Point(96, 101);
            this.txtrut_admin.Name = "txtrut_admin";
            this.txtrut_admin.Size = new System.Drawing.Size(129, 20);
            this.txtrut_admin.TabIndex = 1;
            // 
            // txtcontraseña_admin
            // 
            this.txtcontraseña_admin.AccessibleName = "contrasena_administrador";
            this.txtcontraseña_admin.Location = new System.Drawing.Point(96, 186);
            this.txtcontraseña_admin.Name = "txtcontraseña_admin";
            this.txtcontraseña_admin.Size = new System.Drawing.Size(129, 20);
            this.txtcontraseña_admin.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "nombre";
            // 
            // contraseña
            // 
            this.contraseña.AutoSize = true;
            this.contraseña.Location = new System.Drawing.Point(107, 154);
            this.contraseña.Name = "contraseña";
            this.contraseña.Size = new System.Drawing.Size(61, 13);
            this.contraseña.TabIndex = 4;
            this.contraseña.Text = "Contraseña";
            // 
            // inicioSesion
            // 
            this.AccessibleName = "rut_administrador";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 374);
            this.Controls.Add(this.contraseña);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtcontraseña_admin);
            this.Controls.Add(this.txtrut_admin);
            this.Controls.Add(this.iniciar);
            this.Name = "inicioSesion";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button iniciar;
        private System.Windows.Forms.TextBox txtrut_admin;
        private System.Windows.Forms.TextBox txtcontraseña_admin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label contraseña;
    }
}