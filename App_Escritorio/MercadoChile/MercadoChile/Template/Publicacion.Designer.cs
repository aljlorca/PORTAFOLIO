namespace MercadoChile.Template
{
    partial class Publicacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Publicacion));
            this.DgvProducto = new System.Windows.Forms.DataGridView();
            this.btnListar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPublicar = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.txtDescrip = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.btnSelProd = new System.Windows.Forms.Button();
            this.cnDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProducto)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvProducto
            // 
            this.DgvProducto.AllowUserToAddRows = false;
            this.DgvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnDescripcion,
            this.cnFecha,
            this.cnCliente,
            this.cnId});
            this.DgvProducto.Location = new System.Drawing.Point(52, 34);
            this.DgvProducto.Name = "DgvProducto";
            this.DgvProducto.RowHeadersVisible = false;
            this.DgvProducto.RowTemplate.Height = 150;
            this.DgvProducto.Size = new System.Drawing.Size(305, 347);
            this.DgvProducto.TabIndex = 1;
            // 
            // btnListar
            // 
            this.btnListar.FlatAppearance.BorderSize = 0;
            this.btnListar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnListar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListar.Image = ((System.Drawing.Image)(resources.GetObject("btnListar.Image")));
            this.btnListar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListar.Location = new System.Drawing.Point(76, 387);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(250, 40);
            this.btnListar.TabIndex = 99;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(363, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(242, 25);
            this.label8.TabIndex = 100;
            this.label8.Text = "Listar y Publicar Productos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnPublicar);
            this.groupBox1.Controls.Add(this.label37);
            this.groupBox1.Controls.Add(this.txtDescrip);
            this.groupBox1.Controls.Add(this.txtFecha);
            this.groupBox1.Controls.Add(this.label38);
            this.groupBox1.Location = new System.Drawing.Point(379, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(644, 247);
            this.groupBox1.TabIndex = 101;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modificar Usuario";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(163, 162);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(214, 20);
            this.txtCliente.TabIndex = 84;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 81;
            this.label3.Text = "Cliente";
            // 
            // btnPublicar
            // 
            this.btnPublicar.FlatAppearance.BorderSize = 0;
            this.btnPublicar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnPublicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPublicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPublicar.Image = ((System.Drawing.Image)(resources.GetObject("btnPublicar.Image")));
            this.btnPublicar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPublicar.Location = new System.Drawing.Point(411, 133);
            this.btnPublicar.Name = "btnPublicar";
            this.btnPublicar.Size = new System.Drawing.Size(216, 40);
            this.btnPublicar.TabIndex = 68;
            this.btnPublicar.Text = "Publicar";
            this.btnPublicar.UseVisualStyleBackColor = true;
            this.btnPublicar.Click += new System.EventHandler(this.btnPublicar_Click);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(50, 110);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(54, 20);
            this.label37.TabIndex = 72;
            this.label37.Text = "Fecha";
            // 
            // txtDescrip
            // 
            this.txtDescrip.Location = new System.Drawing.Point(163, 55);
            this.txtDescrip.Name = "txtDescrip";
            this.txtDescrip.Size = new System.Drawing.Size(214, 20);
            this.txtDescrip.TabIndex = 76;
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(163, 110);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(214, 20);
            this.txtFecha.TabIndex = 77;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(21, 55);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(92, 20);
            this.label38.TabIndex = 71;
            this.label38.Text = "Descripcion";
            // 
            // btnSelProd
            // 
            this.btnSelProd.FlatAppearance.BorderSize = 0;
            this.btnSelProd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSelProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelProd.Image = ((System.Drawing.Image)(resources.GetObject("btnSelProd.Image")));
            this.btnSelProd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelProd.Location = new System.Drawing.Point(522, 328);
            this.btnSelProd.Name = "btnSelProd";
            this.btnSelProd.Size = new System.Drawing.Size(207, 40);
            this.btnSelProd.TabIndex = 85;
            this.btnSelProd.Text = "        Selccione un Producto";
            this.btnSelProd.UseVisualStyleBackColor = true;
            this.btnSelProd.Click += new System.EventHandler(this.btnSelProd_Click);
            // 
            // cnDescripcion
            // 
            this.cnDescripcion.DataPropertyName = "descripcion_pedido";
            this.cnDescripcion.HeaderText = "Descripcion";
            this.cnDescripcion.Name = "cnDescripcion";
            // 
            // cnFecha
            // 
            this.cnFecha.DataPropertyName = "fecha_sla_pedido";
            this.cnFecha.HeaderText = "Fecha SLA";
            this.cnFecha.Name = "cnFecha";
            // 
            // cnCliente
            // 
            this.cnCliente.DataPropertyName = "id_usuario";
            this.cnCliente.HeaderText = "Cliente";
            this.cnCliente.Name = "cnCliente";
            // 
            // cnId
            // 
            this.cnId.DataPropertyName = "id_pedido";
            this.cnId.HeaderText = "Id";
            this.cnId.Name = "cnId";
            this.cnId.Visible = false;
            // 
            // Publicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(1035, 634);
            this.Controls.Add(this.btnSelProd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.DgvProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Publicacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Publiacion";
            ((System.ComponentModel.ISupportInitialize)(this.DgvProducto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvProducto;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPublicar;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txtDescrip;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnId;
    }
}