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
            this.cnNombreProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnPrecioProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnSado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnImagen = new System.Windows.Forms.DataGridViewLinkColumn();
            this.cnImagen1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnListar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtNomProd = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.txtSaldoProd = new System.Windows.Forms.TextBox();
            this.txtCalidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelProd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProducto)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvProducto
            // 
            this.DgvProducto.AllowUserToAddRows = false;
            this.DgvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnNombreProd,
            this.cnCantidad,
            this.cnPrecioProd,
            this.cnSado,
            this.cnCalidad,
            this.cnProveedor,
            this.cnImagen,
            this.cnImagen1});
            this.DgvProducto.Location = new System.Drawing.Point(40, 34);
            this.DgvProducto.Name = "DgvProducto";
            this.DgvProducto.RowHeadersVisible = false;
            this.DgvProducto.RowTemplate.Height = 150;
            this.DgvProducto.Size = new System.Drawing.Size(854, 347);
            this.DgvProducto.TabIndex = 1;
            // 
            // cnNombreProd
            // 
            this.cnNombreProd.DataPropertyName = "nombre_producto";
            this.cnNombreProd.HeaderText = "Nombre Producto";
            this.cnNombreProd.Name = "cnNombreProd";
            // 
            // cnCantidad
            // 
            this.cnCantidad.DataPropertyName = "cantidad_producto";
            this.cnCantidad.HeaderText = "Cantidad";
            this.cnCantidad.Name = "cnCantidad";
            // 
            // cnPrecioProd
            // 
            this.cnPrecioProd.DataPropertyName = "precio_producto";
            this.cnPrecioProd.HeaderText = "Precio";
            this.cnPrecioProd.Name = "cnPrecioProd";
            // 
            // cnSado
            // 
            this.cnSado.DataPropertyName = "saldo_producto";
            this.cnSado.HeaderText = "Saldo Producto";
            this.cnSado.Name = "cnSado";
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
            // cnImagen
            // 
            this.cnImagen.DataPropertyName = "imagen_producto";
            this.cnImagen.HeaderText = "Urls Producto";
            this.cnImagen.Name = "cnImagen";
            this.cnImagen.ReadOnly = true;
            this.cnImagen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // cnImagen1
            // 
            this.cnImagen1.HeaderText = "Imagen";
            this.cnImagen1.Name = "cnImagen1";
            this.cnImagen1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cnImagen1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cnImagen1.Width = 150;
            // 
            // btnListar
            // 
            this.btnListar.FlatAppearance.BorderSize = 0;
            this.btnListar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnListar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListar.Image = ((System.Drawing.Image)(resources.GetObject("btnListar.Image")));
            this.btnListar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListar.Location = new System.Drawing.Point(106, 387);
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
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtProveedor);
            this.groupBox1.Controls.Add(this.txtSaldoProd);
            this.groupBox1.Controls.Add(this.txtCalidad);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.label37);
            this.groupBox1.Controls.Add(this.txtPrecio);
            this.groupBox1.Controls.Add(this.txtNomProd);
            this.groupBox1.Controls.Add(this.txtCantidad);
            this.groupBox1.Controls.Add(this.label38);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Location = new System.Drawing.Point(362, 387);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(644, 247);
            this.groupBox1.TabIndex = 101;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modificar Usuario";
            // 
            // btnEdit
            // 
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(411, 133);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(216, 40);
            this.btnEdit.TabIndex = 68;
            this.btnEdit.Text = "Publicar";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(60, 107);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(53, 20);
            this.label36.TabIndex = 73;
            this.label36.Text = "Precio";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(21, 55);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(133, 20);
            this.label38.TabIndex = 71;
            this.label38.Text = "Nombre Producto";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(163, 79);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(214, 20);
            this.txtCantidad.TabIndex = 77;
            // 
            // txtNomProd
            // 
            this.txtNomProd.Location = new System.Drawing.Point(163, 55);
            this.txtNomProd.Name = "txtNomProd";
            this.txtNomProd.Size = new System.Drawing.Size(214, 20);
            this.txtNomProd.TabIndex = 76;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(163, 107);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(214, 20);
            this.txtPrecio.TabIndex = 78;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(50, 79);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(73, 20);
            this.label37.TabIndex = 72;
            this.label37.Text = "Cantidad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 80;
            this.label1.Text = "Calidad";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Location = new System.Drawing.Point(163, 185);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(214, 20);
            this.txtProveedor.TabIndex = 84;
            // 
            // txtSaldoProd
            // 
            this.txtSaldoProd.Location = new System.Drawing.Point(163, 133);
            this.txtSaldoProd.Name = "txtSaldoProd";
            this.txtSaldoProd.Size = new System.Drawing.Size(214, 20);
            this.txtSaldoProd.TabIndex = 82;
            // 
            // txtCalidad
            // 
            this.txtCalidad.Location = new System.Drawing.Point(163, 157);
            this.txtCalidad.Name = "txtCalidad";
            this.txtCalidad.Size = new System.Drawing.Size(214, 20);
            this.txtCalidad.TabIndex = 83;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 79;
            this.label2.Text = "Saldo Producto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 81;
            this.label3.Text = "Proveedor";
            // 
            // btnSelProd
            // 
            this.btnSelProd.FlatAppearance.BorderSize = 0;
            this.btnSelProd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSelProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelProd.Image = ((System.Drawing.Image)(resources.GetObject("btnSelProd.Image")));
            this.btnSelProd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelProd.Location = new System.Drawing.Point(106, 474);
            this.btnSelProd.Name = "btnSelProd";
            this.btnSelProd.Size = new System.Drawing.Size(207, 40);
            this.btnSelProd.TabIndex = 85;
            this.btnSelProd.Text = "        Selccione un Producto";
            this.btnSelProd.UseVisualStyleBackColor = true;
            this.btnSelProd.Click += new System.EventHandler(this.btnSelProd_Click);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn cnNombreProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnPrecioProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnSado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnProveedor;
        private System.Windows.Forms.DataGridViewLinkColumn cnImagen;
        private System.Windows.Forms.DataGridViewImageColumn cnImagen1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtNomProd;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.TextBox txtSaldoProd;
        private System.Windows.Forms.TextBox txtCalidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelProd;
    }
}