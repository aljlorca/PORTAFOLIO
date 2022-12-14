namespace MercadoChile.Template
{
    partial class Procesos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Procesos));
            this.btnAceptar = new System.Windows.Forms.Button();
            this.DgvProducto = new System.Windows.Forms.DataGridView();
            this.cnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnEstadoV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnClientee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnMontoNetoVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnTipoVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnMontoBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnMontoAduana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnMontoTrans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnComisionVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCantVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(731, 274);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(220, 40);
            this.btnAceptar.TabIndex = 109;
            this.btnAceptar.Text = "Aceptar Venta";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // DgvProducto
            // 
            this.DgvProducto.AllowUserToAddRows = false;
            this.DgvProducto.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnId,
            this.cnDescripcion,
            this.cnEstadoV,
            this.cnFecha,
            this.cnClientee,
            this.cnMontoNetoVenta,
            this.cnTipoVenta,
            this.cnMontoBruto,
            this.cnIva,
            this.cnMontoAduana,
            this.cnMontoTrans,
            this.cnPago,
            this.cnComisionVenta,
            this.cnCantVenta});
            this.DgvProducto.Location = new System.Drawing.Point(111, 64);
            this.DgvProducto.Name = "DgvProducto";
            this.DgvProducto.Size = new System.Drawing.Size(544, 513);
            this.DgvProducto.TabIndex = 107;
            // 
            // cnId
            // 
            this.cnId.DataPropertyName = "id_venta";
            this.cnId.HeaderText = "ID";
            this.cnId.Name = "cnId";
            this.cnId.Visible = false;
            // 
            // cnDescripcion
            // 
            this.cnDescripcion.DataPropertyName = "descripcion_venta";
            this.cnDescripcion.HeaderText = "Descripcion Venta";
            this.cnDescripcion.Name = "cnDescripcion";
            // 
            // cnEstadoV
            // 
            this.cnEstadoV.DataPropertyName = "estado_venta";
            this.cnEstadoV.HeaderText = "Estado";
            this.cnEstadoV.Name = "cnEstadoV";
            // 
            // cnFecha
            // 
            this.cnFecha.DataPropertyName = "fecha_venta";
            this.cnFecha.HeaderText = "Fecha Venta";
            this.cnFecha.Name = "cnFecha";
            // 
            // cnClientee
            // 
            this.cnClientee.DataPropertyName = "id_usuario";
            this.cnClientee.HeaderText = "Cliente";
            this.cnClientee.Name = "cnClientee";
            // 
            // cnMontoNetoVenta
            // 
            this.cnMontoNetoVenta.DataPropertyName = "monto_neto_venta";
            this.cnMontoNetoVenta.HeaderText = "Monto neto venta";
            this.cnMontoNetoVenta.Name = "cnMontoNetoVenta";
            this.cnMontoNetoVenta.Visible = false;
            // 
            // cnTipoVenta
            // 
            this.cnTipoVenta.DataPropertyName = "tipo_venta";
            this.cnTipoVenta.HeaderText = "Tipo Venta";
            this.cnTipoVenta.Name = "cnTipoVenta";
            // 
            // cnMontoBruto
            // 
            this.cnMontoBruto.DataPropertyName = "monto_bruto_venta";
            this.cnMontoBruto.HeaderText = "Monto Bruto";
            this.cnMontoBruto.Name = "cnMontoBruto";
            this.cnMontoBruto.Visible = false;
            // 
            // cnIva
            // 
            this.cnIva.DataPropertyName = "iva";
            this.cnIva.HeaderText = "Iva";
            this.cnIva.Name = "cnIva";
            this.cnIva.Visible = false;
            // 
            // cnMontoAduana
            // 
            this.cnMontoAduana.DataPropertyName = "monto_aduanas";
            this.cnMontoAduana.HeaderText = "Monto Aduana";
            this.cnMontoAduana.Name = "cnMontoAduana";
            this.cnMontoAduana.Visible = false;
            // 
            // cnMontoTrans
            // 
            this.cnMontoTrans.DataPropertyName = "monto_transporte";
            this.cnMontoTrans.HeaderText = "Monto Transporte";
            this.cnMontoTrans.Name = "cnMontoTrans";
            this.cnMontoTrans.Visible = false;
            // 
            // cnPago
            // 
            this.cnPago.DataPropertyName = "pago_servicio";
            this.cnPago.HeaderText = "Pago Servicio";
            this.cnPago.Name = "cnPago";
            this.cnPago.Visible = false;
            // 
            // cnComisionVenta
            // 
            this.cnComisionVenta.DataPropertyName = "comision_venta";
            this.cnComisionVenta.HeaderText = "Comision Venta";
            this.cnComisionVenta.Name = "cnComisionVenta";
            this.cnComisionVenta.Visible = false;
            // 
            // cnCantVenta
            // 
            this.cnCantVenta.DataPropertyName = "cantidad_venta";
            this.cnCantVenta.HeaderText = "Cantidad Venta";
            this.cnCantVenta.Name = "cnCantVenta";
            this.cnCantVenta.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(412, 13);
            this.label2.TabIndex = 108;
            this.label2.Text = "---------------------------------------------------------------------------------" +
    "------------------------------------------------------";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(430, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(183, 25);
            this.label8.TabIndex = 106;
            this.label8.Text = "Rechazo de Ventas";
            // 
            // Procesos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 601);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.DgvProducto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Procesos";
            this.Text = "Procesos";
            this.Load += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridView DgvProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnEstadoV;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnClientee;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnMontoNetoVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnTipoVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnMontoBruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnMontoAduana;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnMontoTrans;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnComisionVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCantVenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
    }
}