namespace MercadoChile.Template
{
    partial class Reporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reporte));
            this.DgvReporte = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReporte = new System.Windows.Forms.Button();
            this.cnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnEstadoVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CnMontoNeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnMontoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnTipoVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvReporte
            // 
            this.DgvReporte.AllowUserToAddRows = false;
            this.DgvReporte.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvReporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnID,
            this.cnDescripcion,
            this.cnEstadoVenta,
            this.CnMontoNeto,
            this.cnIva,
            this.cnMontoTotal,
            this.cnTipoVenta});
            this.DgvReporte.Location = new System.Drawing.Point(70, 71);
            this.DgvReporte.Name = "DgvReporte";
            this.DgvReporte.Size = new System.Drawing.Size(821, 355);
            this.DgvReporte.TabIndex = 95;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(412, 13);
            this.label3.TabIndex = 110;
            this.label3.Text = "---------------------------------------------------------------------------------" +
    "------------------------------------------------------";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(358, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 23);
            this.label1.TabIndex = 109;
            this.label1.Text = "Generador de Reportes";
            // 
            // btnReporte
            // 
            this.btnReporte.FlatAppearance.BorderSize = 0;
            this.btnReporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte.Image = ((System.Drawing.Image)(resources.GetObject("btnReporte.Image")));
            this.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReporte.Location = new System.Drawing.Point(396, 443);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(220, 40);
            this.btnReporte.TabIndex = 113;
            this.btnReporte.Text = "Generar Reporte";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // cnID
            // 
            this.cnID.DataPropertyName = "id_venta";
            this.cnID.HeaderText = "Id Venta";
            this.cnID.Name = "cnID";
            this.cnID.Visible = false;
            // 
            // cnDescripcion
            // 
            this.cnDescripcion.DataPropertyName = "descripcion_venta";
            this.cnDescripcion.HeaderText = "Descripcion Venta ";
            this.cnDescripcion.Name = "cnDescripcion";
            // 
            // cnEstadoVenta
            // 
            this.cnEstadoVenta.DataPropertyName = "estado_venta";
            this.cnEstadoVenta.HeaderText = "Estado Venta";
            this.cnEstadoVenta.Name = "cnEstadoVenta";
            this.cnEstadoVenta.Visible = false;
            // 
            // CnMontoNeto
            // 
            this.CnMontoNeto.DataPropertyName = "monto_bruto_venta";
            this.CnMontoNeto.HeaderText = "Monto Neto";
            this.CnMontoNeto.Name = "CnMontoNeto";
            // 
            // cnIva
            // 
            this.cnIva.DataPropertyName = "iva";
            this.cnIva.HeaderText = "IVA";
            this.cnIva.Name = "cnIva";
            // 
            // cnMontoTotal
            // 
            this.cnMontoTotal.DataPropertyName = "monto_neto_venta";
            this.cnMontoTotal.HeaderText = "Monto Total";
            this.cnMontoTotal.Name = "cnMontoTotal";
            // 
            // cnTipoVenta
            // 
            this.cnTipoVenta.DataPropertyName = "tipo_venta";
            this.cnTipoVenta.HeaderText = "Tipo Venta ";
            this.cnTipoVenta.Name = "cnTipoVenta";
            // 
            // Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 554);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgvReporte);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reporte";
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.Reporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvReporte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnEstadoVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CnMontoNeto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnMontoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnTipoVenta;
    }
}