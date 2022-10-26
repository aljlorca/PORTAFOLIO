namespace MercadoChile.Template
{
    partial class Postulacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Postulacion));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBusVenta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnListar = new System.Windows.Forms.Button();
            this.DgvSubastas = new System.Windows.Forms.DataGridView();
            this.cnIdP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnDesrip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnEstadoF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnBoton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.DgvCarga = new System.Windows.Forms.DataGridView();
            this.cnImagen = new System.Windows.Forms.DataGridViewImageColumn();
            this.cnNomProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCantProduc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSubastas)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCarga)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.AccessibleName = "";
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(20, 15);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1036, 590);
            this.tabControl1.TabIndex = 23;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtBusVenta);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btnListar);
            this.tabPage1.Controls.Add(this.DgvSubastas);
            this.tabPage1.Controls.Add(this.btnEliminar);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1028, 564);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Proceso Postulacion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(749, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(259, 13);
            this.label4.TabIndex = 119;
            this.label4.Text = "---------------------------------------------------------------";
            // 
            // txtBusVenta
            // 
            this.txtBusVenta.Location = new System.Drawing.Point(782, 158);
            this.txtBusVenta.Name = "txtBusVenta";
            this.txtBusVenta.Size = new System.Drawing.Size(193, 20);
            this.txtBusVenta.TabIndex = 118;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(806, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 19);
            this.label5.TabIndex = 117;
            this.label5.Text = "Buscador Venta";
            // 
            // btnListar
            // 
            this.btnListar.FlatAppearance.BorderSize = 0;
            this.btnListar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnListar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListar.Location = new System.Drawing.Point(792, 323);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(216, 40);
            this.btnListar.TabIndex = 99;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            // 
            // DgvSubastas
            // 
            this.DgvSubastas.AllowUserToAddRows = false;
            this.DgvSubastas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvSubastas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSubastas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnIdP,
            this.cnDesrip,
            this.cnEstado,
            this.cnVenta,
            this.cnCliente,
            this.cnProduto,
            this.cnEstadoF,
            this.cnBoton});
            this.DgvSubastas.Location = new System.Drawing.Point(6, 46);
            this.DgvSubastas.Name = "DgvSubastas";
            this.DgvSubastas.Size = new System.Drawing.Size(664, 520);
            this.DgvSubastas.TabIndex = 104;
            // 
            // cnIdP
            // 
            this.cnIdP.DataPropertyName = "id_postulacion";
            this.cnIdP.HeaderText = "ID";
            this.cnIdP.Name = "cnIdP";
            this.cnIdP.Visible = false;
            // 
            // cnDesrip
            // 
            this.cnDesrip.DataPropertyName = "descripcion_postulacion";
            this.cnDesrip.HeaderText = "Descripcion Postulacion";
            this.cnDesrip.Name = "cnDesrip";
            // 
            // cnEstado
            // 
            this.cnEstado.DataPropertyName = "estado_postulacion";
            this.cnEstado.HeaderText = "Estado Postulacion";
            this.cnEstado.Name = "cnEstado";
            // 
            // cnVenta
            // 
            this.cnVenta.DataPropertyName = "id_venta";
            this.cnVenta.HeaderText = "Venta";
            this.cnVenta.Name = "cnVenta";
            // 
            // cnCliente
            // 
            this.cnCliente.DataPropertyName = "id_usuario";
            this.cnCliente.HeaderText = "Cliente";
            this.cnCliente.Name = "cnCliente";
            // 
            // cnProduto
            // 
            this.cnProduto.DataPropertyName = "id_producto";
            this.cnProduto.HeaderText = "Nombre Producto";
            this.cnProduto.Name = "cnProduto";
            // 
            // cnEstadoF
            // 
            this.cnEstadoF.DataPropertyName = "estado_fila";
            this.cnEstadoF.HeaderText = "Estado Fila";
            this.cnEstadoF.Name = "cnEstadoF";
            this.cnEstadoF.Visible = false;
            // 
            // cnBoton
            // 
            this.cnBoton.HeaderText = "";
            this.cnBoton.Name = "cnBoton";
            this.cnBoton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cnBoton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cnBoton.Text = "";
            // 
            // btnEliminar
            // 
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(814, 238);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(220, 40);
            this.btnEliminar.TabIndex = 98;
            this.btnEliminar.Text = "Eliminar Empresa";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(547, 13);
            this.label3.TabIndex = 103;
            this.label3.Text = "---------------------------------------------------------------------------------" +
    "------------------------------------------------------";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(423, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Control de Proceso Subastas";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.DgvCarga);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1028, 564);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Productos a Rechazar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(547, 13);
            this.label2.TabIndex = 104;
            this.label2.Text = "---------------------------------------------------------------------------------" +
    "------------------------------------------------------";
            // 
            // DgvCarga
            // 
            this.DgvCarga.AllowUserToAddRows = false;
            this.DgvCarga.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvCarga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCarga.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnImagen,
            this.cnNomProd,
            this.cnCantProduc,
            this.cnPrecio,
            this.cnSaldo,
            this.cnCalidad,
            this.cnProveedor,
            this.cnId,
            this.cnUrl});
            this.DgvCarga.Location = new System.Drawing.Point(54, 53);
            this.DgvCarga.Name = "DgvCarga";
            this.DgvCarga.RowTemplate.Height = 150;
            this.DgvCarga.Size = new System.Drawing.Size(925, 508);
            this.DgvCarga.TabIndex = 94;
            // 
            // cnImagen
            // 
            this.cnImagen.HeaderText = "Imagen Produto";
            this.cnImagen.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.cnImagen.Name = "cnImagen";
            this.cnImagen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cnImagen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cnNomProd
            // 
            this.cnNomProd.DataPropertyName = "nombre_producto";
            this.cnNomProd.HeaderText = "Nombre Produto";
            this.cnNomProd.Name = "cnNomProd";
            // 
            // cnCantProduc
            // 
            this.cnCantProduc.DataPropertyName = "cantidad_producto";
            this.cnCantProduc.HeaderText = "Cantidad Producto";
            this.cnCantProduc.Name = "cnCantProduc";
            // 
            // cnPrecio
            // 
            this.cnPrecio.DataPropertyName = "precio_producto";
            this.cnPrecio.HeaderText = "Precio";
            this.cnPrecio.Name = "cnPrecio";
            // 
            // cnSaldo
            // 
            this.cnSaldo.DataPropertyName = "saldo_producto";
            this.cnSaldo.HeaderText = "Saldo Producto";
            this.cnSaldo.Name = "cnSaldo";
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
            // cnId
            // 
            this.cnId.DataPropertyName = "id_producto";
            this.cnId.HeaderText = "ID";
            this.cnId.Name = "cnId";
            this.cnId.Visible = false;
            // 
            // cnUrl
            // 
            this.cnUrl.DataPropertyName = "imagen_producto";
            this.cnUrl.HeaderText = "Url Imagen";
            this.cnUrl.Name = "cnUrl";
            this.cnUrl.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(359, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(338, 25);
            this.label8.TabIndex = 93;
            this.label8.Text = "Eliminacion de Productos rechazados";
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
            // Postulacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 620);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Postulacion";
            this.Text = "Postulacion";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSubastas)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCarga)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBusVenta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.DataGridView DgvSubastas;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnIdP;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnDesrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnEstadoF;
        private System.Windows.Forms.DataGridViewButtonColumn cnBoton;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DgvCarga;
        private System.Windows.Forms.DataGridViewImageColumn cnImagen;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnNomProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCantProduc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnUrl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
    }
}