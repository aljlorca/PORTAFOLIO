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
            this.cnDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnListar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnPublicar = new System.Windows.Forms.Button();
            this.txtDescrip = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.btnSelProd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProducto)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvProducto
            // 
            this.DgvProducto.AllowUserToAddRows = false;
            this.DgvProducto.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnDescripcion,
            this.cnFecha,
            this.cnCliente,
            this.cnId});
            this.DgvProducto.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DgvProducto.Location = new System.Drawing.Point(511, 53);
            this.DgvProducto.Name = "DgvProducto";
            this.DgvProducto.RowHeadersVisible = false;
            this.DgvProducto.RowTemplate.Height = 150;
            this.DgvProducto.Size = new System.Drawing.Size(304, 362);
            this.DgvProducto.TabIndex = 1;
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
            // btnListar
            // 
            this.btnListar.FlatAppearance.BorderSize = 0;
            this.btnListar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnListar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListar.Image = ((System.Drawing.Image)(resources.GetObject("btnListar.Image")));
            this.btnListar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListar.Location = new System.Drawing.Point(451, 469);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(250, 40);
            this.btnListar.TabIndex = 99;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.btnPublicar);
            this.groupBox1.Controls.Add(this.txtDescrip);
            this.groupBox1.Controls.Add(this.txtFecha);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(88, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 397);
            this.groupBox1.TabIndex = 101;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Productos";
            // 
            // txtCliente
            // 
            this.txtCliente.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.ForeColor = System.Drawing.Color.DimGray;
            this.txtCliente.Location = new System.Drawing.Point(82, 161);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(214, 26);
            this.txtCliente.TabIndex = 84;
            this.txtCliente.Text = "Cliente";
            this.txtCliente.Enter += new System.EventHandler(this.txtCliente_Enter);
            this.txtCliente.Leave += new System.EventHandler(this.txtCliente_Leave);
            // 
            // btnPublicar
            // 
            this.btnPublicar.FlatAppearance.BorderSize = 0;
            this.btnPublicar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnPublicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPublicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPublicar.Image = ((System.Drawing.Image)(resources.GetObject("btnPublicar.Image")));
            this.btnPublicar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPublicar.Location = new System.Drawing.Point(82, 236);
            this.btnPublicar.Name = "btnPublicar";
            this.btnPublicar.Size = new System.Drawing.Size(216, 40);
            this.btnPublicar.TabIndex = 68;
            this.btnPublicar.Text = "Publicar";
            this.btnPublicar.UseVisualStyleBackColor = true;
            this.btnPublicar.Click += new System.EventHandler(this.btnPublicar_Click);
            // 
            // txtDescrip
            // 
            this.txtDescrip.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescrip.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescrip.Location = new System.Drawing.Point(82, 64);
            this.txtDescrip.Name = "txtDescrip";
            this.txtDescrip.Size = new System.Drawing.Size(214, 26);
            this.txtDescrip.TabIndex = 76;
            this.txtDescrip.Text = "Descripcion";
            this.txtDescrip.Enter += new System.EventHandler(this.txtDescrip_Enter);
            this.txtDescrip.Leave += new System.EventHandler(this.txtDescrip_Leave);
            // 
            // txtFecha
            // 
            this.txtFecha.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.ForeColor = System.Drawing.Color.DimGray;
            this.txtFecha.Location = new System.Drawing.Point(82, 115);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(214, 26);
            this.txtFecha.TabIndex = 77;
            this.txtFecha.Text = "Fecha";
            this.txtFecha.Enter += new System.EventHandler(this.txtFecha_Enter);
            this.txtFecha.Leave += new System.EventHandler(this.txtFecha_Leave);
            // 
            // btnSelProd
            // 
            this.btnSelProd.FlatAppearance.BorderSize = 0;
            this.btnSelProd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSelProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelProd.Image = ((System.Drawing.Image)(resources.GetObject("btnSelProd.Image")));
            this.btnSelProd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelProd.Location = new System.Drawing.Point(707, 469);
            this.btnSelProd.Name = "btnSelProd";
            this.btnSelProd.Size = new System.Drawing.Size(207, 40);
            this.btnSelProd.TabIndex = 85;
            this.btnSelProd.Text = "        Selccione un Producto";
            this.btnSelProd.UseVisualStyleBackColor = true;
            this.btnSelProd.Click += new System.EventHandler(this.btnSelProd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(412, 13);
            this.label1.TabIndex = 104;
            this.label1.Text = "---------------------------------------------------------------------------------" +
    "------------------------------------------------------";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(436, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 28);
            this.label2.TabIndex = 103;
            this.label2.Text = "Pedidos";
            // 
            // Publicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(1028, 543);
            this.Controls.Add(this.btnSelProd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPublicar;
        private System.Windows.Forms.TextBox txtDescrip;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnSelProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}