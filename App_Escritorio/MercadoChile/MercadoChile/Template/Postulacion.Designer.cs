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
            this.DgvSubastas = new System.Windows.Forms.DataGridView();
            this.cnCapaCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnRefrigeracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnTamanoCa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnEstadoS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnBoton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cnIdS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnIdC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnListar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSubastas)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvSubastas
            // 
            this.DgvSubastas.AllowUserToAddRows = false;
            this.DgvSubastas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvSubastas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSubastas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnCapaCarga,
            this.cnRefrigeracion,
            this.cnTamanoCa,
            this.cnMonto,
            this.cnFecha,
            this.cnEstadoS,
            this.cnVenta,
            this.cnCliente,
            this.cnBoton,
            this.cnIdS,
            this.cnIdC});
            this.DgvSubastas.Location = new System.Drawing.Point(43, 66);
            this.DgvSubastas.Name = "DgvSubastas";
            this.DgvSubastas.Size = new System.Drawing.Size(943, 520);
            this.DgvSubastas.TabIndex = 109;
            this.DgvSubastas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Click_Aceptar);
            // 
            // cnCapaCarga
            // 
            this.cnCapaCarga.DataPropertyName = "capacidad_carga";
            this.cnCapaCarga.HeaderText = "Capacidad Carga";
            this.cnCapaCarga.Name = "cnCapaCarga";
            // 
            // cnRefrigeracion
            // 
            this.cnRefrigeracion.DataPropertyName = "refrigeracion_carga";
            this.cnRefrigeracion.HeaderText = "Refrigeracion Carga";
            this.cnRefrigeracion.Name = "cnRefrigeracion";
            // 
            // cnTamanoCa
            // 
            this.cnTamanoCa.DataPropertyName = "tamano_carga";
            this.cnTamanoCa.HeaderText = "Tamaño Carga";
            this.cnTamanoCa.Name = "cnTamanoCa";
            // 
            // cnMonto
            // 
            this.cnMonto.DataPropertyName = "monto_subasta";
            this.cnMonto.HeaderText = "Monto Subasta";
            this.cnMonto.Name = "cnMonto";
            // 
            // cnFecha
            // 
            this.cnFecha.DataPropertyName = "fecha_subasta";
            this.cnFecha.HeaderText = "Fecha Subasta";
            this.cnFecha.Name = "cnFecha";
            // 
            // cnEstadoS
            // 
            this.cnEstadoS.DataPropertyName = "estado_subasta";
            this.cnEstadoS.HeaderText = "Estado Subasta";
            this.cnEstadoS.Name = "cnEstadoS";
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
            // cnBoton
            // 
            this.cnBoton.HeaderText = "";
            this.cnBoton.Name = "cnBoton";
            this.cnBoton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cnBoton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cnBoton.Text = "";
            // 
            // cnIdS
            // 
            this.cnIdS.DataPropertyName = "id_subasta";
            this.cnIdS.HeaderText = "ID";
            this.cnIdS.Name = "cnIdS";
            this.cnIdS.Visible = false;
            // 
            // cnIdC
            // 
            this.cnIdC.DataPropertyName = "id_carga";
            this.cnIdC.HeaderText = "IDc";
            this.cnIdC.Name = "cnIdC";
            this.cnIdC.Visible = false;
            // 
            // btnListar
            // 
            this.btnListar.FlatAppearance.BorderSize = 0;
            this.btnListar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnListar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListar.Location = new System.Drawing.Point(808, 292);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(58, 40);
            this.btnListar.TabIndex = 107;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(229, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(412, 13);
            this.label3.TabIndex = 108;
            this.label3.Text = "---------------------------------------------------------------------------------" +
    "------------------------------------------------------";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(276, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 23);
            this.label1.TabIndex = 105;
            this.label1.Text = "Control de Proceso Subastas";
            // 
            // Postulacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 620);
            this.Controls.Add(this.DgvSubastas);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Postulacion";
            this.Text = "Postulacion";
            this.Load += new System.EventHandler(this.btnListar_Click);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSubastas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvSubastas;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCapaCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnRefrigeracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnTamanoCa;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnEstadoS;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCliente;
        private System.Windows.Forms.DataGridViewButtonColumn cnBoton;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnIdS;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnIdC;
    }
}