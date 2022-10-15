namespace MercadoChile.Template
{
    partial class Publiacion
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Publiacion));
            this.dgvProducto = new System.Windows.Forms.DataGridView();
            this.btnListar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cnImagen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnNombreProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnPrecioProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnSado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProducto
            // 
            this.dgvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnImagen,
            this.cnNombreProd,
            this.cnCantidad,
            this.cnPrecioProd,
            this.cnSado,
            this.cnCalidad,
            this.cnProveedor});
            this.dgvProducto.Location = new System.Drawing.Point(1, 12);
            this.dgvProducto.Name = "dgvProducto";
            this.dgvProducto.Size = new System.Drawing.Size(898, 225);
            this.dgvProducto.TabIndex = 1;
            // 
            // btnListar
            // 
            this.btnListar.FlatAppearance.BorderSize = 0;
            this.btnListar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnListar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListar.Image = ((System.Drawing.Image)(resources.GetObject("btnListar.Image")));
            this.btnListar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListar.Location = new System.Drawing.Point(310, 274);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(250, 40);
            this.btnListar.TabIndex = 99;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cnImagen
            // 
            this.cnImagen.DataPropertyName = "imagen_producto";
            this.cnImagen.HeaderText = "Imagen Producto";
            this.cnImagen.Name = "cnImagen";
            this.cnImagen.ReadOnly = true;
            this.cnImagen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cnImagen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // Publiacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(911, 543);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.dgvProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Publiacion";
            this.Text = "Publiacion";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProducto;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnImagen;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnNombreProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnPrecioProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnSado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnProveedor;
    }
}