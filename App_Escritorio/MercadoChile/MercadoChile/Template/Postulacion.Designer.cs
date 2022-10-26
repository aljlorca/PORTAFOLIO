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
            this.btnListar = new System.Windows.Forms.Button();
            this.DgvSubastas = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.DgvCarga = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cnSubasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCapacidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnRefrig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnTamano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnEstadoFila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnTransportista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnButon = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnDelSubasta = new System.Windows.Forms.Button();
            this.cnIdS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnBoton = new System.Windows.Forms.DataGridViewButtonColumn();
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
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.DgvSubastas);
            this.tabPage1.Controls.Add(this.btnListar);
            this.tabPage1.Controls.Add(this.btnEliminar);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1028, 564);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Aceptacion de Subastas";
            // 
            // btnListar
            // 
            this.btnListar.FlatAppearance.BorderSize = 0;
            this.btnListar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnListar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListar.Location = new System.Drawing.Point(744, 347);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(216, 40);
            this.btnListar.TabIndex = 99;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // DgvSubastas
            // 
            this.DgvSubastas.AllowUserToAddRows = false;
            this.DgvSubastas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvSubastas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSubastas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnIdS,
            this.cnMonto,
            this.cnFecha,
            this.cnVenta,
            this.cnCliente,
            this.cnBoton});
            this.DgvSubastas.Location = new System.Drawing.Point(6, 46);
            this.DgvSubastas.Name = "DgvSubastas";
            this.DgvSubastas.Size = new System.Drawing.Size(664, 520);
            this.DgvSubastas.TabIndex = 104;
            // 
            // btnEliminar
            // 
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(744, 267);
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
            this.tabPage4.Controls.Add(this.btnDelSubasta);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.DgvCarga);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1028, 564);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Aceptacion de Carga";
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
            this.cnSubasta,
            this.cnCapacidad,
            this.cnRefrig,
            this.cnTamano,
            this.cnEstadoFila,
            this.cnTransportista,
            this.cnId,
            this.cnButon});
            this.DgvCarga.Location = new System.Drawing.Point(20, 45);
            this.DgvCarga.Name = "DgvCarga";
            this.DgvCarga.RowTemplate.Height = 150;
            this.DgvCarga.Size = new System.Drawing.Size(748, 508);
            this.DgvCarga.TabIndex = 94;
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
            // cnSubasta
            // 
            this.cnSubasta.DataPropertyName = "id_subasta";
            this.cnSubasta.HeaderText = "Monto Subasta";
            this.cnSubasta.Name = "cnSubasta";
            // 
            // cnCapacidad
            // 
            this.cnCapacidad.DataPropertyName = "capacidad_carga";
            this.cnCapacidad.HeaderText = "Capacidad Carga";
            this.cnCapacidad.Name = "cnCapacidad";
            // 
            // cnRefrig
            // 
            this.cnRefrig.DataPropertyName = "refrigeracion_carga";
            this.cnRefrig.HeaderText = "Refrigeracion Carga";
            this.cnRefrig.Name = "cnRefrig";
            // 
            // cnTamano
            // 
            this.cnTamano.DataPropertyName = "tamano_carga";
            this.cnTamano.HeaderText = "Tamaño Carga";
            this.cnTamano.Name = "cnTamano";
            // 
            // cnEstadoFila
            // 
            this.cnEstadoFila.DataPropertyName = "estado_fila";
            this.cnEstadoFila.HeaderText = "Estado Fila";
            this.cnEstadoFila.Name = "cnEstadoFila";
            // 
            // cnTransportista
            // 
            this.cnTransportista.DataPropertyName = "id_usuario";
            this.cnTransportista.HeaderText = "Transportista";
            this.cnTransportista.Name = "cnTransportista";
            // 
            // cnId
            // 
            this.cnId.DataPropertyName = "id_carga";
            this.cnId.HeaderText = "ID";
            this.cnId.Name = "cnId";
            this.cnId.Visible = false;
            // 
            // cnButon
            // 
            this.cnButon.HeaderText = "";
            this.cnButon.Name = "cnButon";
            // 
            // btnDelSubasta
            // 
            this.btnDelSubasta.FlatAppearance.BorderSize = 0;
            this.btnDelSubasta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnDelSubasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelSubasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelSubasta.Image = ((System.Drawing.Image)(resources.GetObject("btnDelSubasta.Image")));
            this.btnDelSubasta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelSubasta.Location = new System.Drawing.Point(786, 242);
            this.btnDelSubasta.Name = "btnDelSubasta";
            this.btnDelSubasta.Size = new System.Drawing.Size(220, 40);
            this.btnDelSubasta.TabIndex = 105;
            this.btnDelSubasta.Text = "Eliminar Subasta";
            this.btnDelSubasta.UseVisualStyleBackColor = true;
            // 
            // cnIdS
            // 
            this.cnIdS.DataPropertyName = "id_subasta";
            this.cnIdS.HeaderText = "ID";
            this.cnIdS.Name = "cnIdS";
            this.cnIdS.Visible = false;
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
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.DataGridView DgvSubastas;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DgvCarga;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnSubasta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCapacidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnRefrig;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnTamano;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnEstadoFila;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnTransportista;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnId;
        private System.Windows.Forms.DataGridViewButtonColumn cnButon;
        private System.Windows.Forms.Button btnDelSubasta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnIdS;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCliente;
        private System.Windows.Forms.DataGridViewButtonColumn cnBoton;
    }
}