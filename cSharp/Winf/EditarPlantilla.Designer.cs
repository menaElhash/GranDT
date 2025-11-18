namespace el_dt_by_menardi_y_tello
{
    partial class EditarPlantilla
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lblFechaCreacion = new System.Windows.Forms.Label();
            this.lblPlantillaId = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tbPresupuesto = new System.Windows.Forms.TextBox();
            this.lblPresupuesto = new System.Windows.Forms.Label();
            this.cbEquipo = new System.Windows.Forms.ComboBox();
            this.lblEquipo = new System.Windows.Forms.Label();
            this.gbJugadores = new System.Windows.Forms.GroupBox();
            this.dgvJugadores = new System.Windows.Forms.DataGridView();
            this.btnAgregarJugador = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbDatos.SuspendLayout();
            this.gbJugadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJugadores)).BeginInit();
            this.SuspendLayout();
            
            // gbDatos
            this.gbDatos.Controls.Add(this.btnGuardar);
            this.gbDatos.Controls.Add(this.lblFechaCreacion);
            this.gbDatos.Controls.Add(this.lblPlantillaId);
            this.gbDatos.Controls.Add(this.tbPresupuesto);
            this.gbDatos.Controls.Add(this.lblPresupuesto);
            this.gbDatos.Controls.Add(this.cbEquipo);
            this.gbDatos.Controls.Add(this.lblEquipo);
            this.gbDatos.Location = new System.Drawing.Point(12, 12);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(460, 200);
            this.gbDatos.TabIndex = 0;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos de Plantilla";
            
            // lblPlantillaId
            this.lblPlantillaId.AutoSize = true;
            this.lblPlantillaId.Location = new System.Drawing.Point(6, 22);
            this.lblPlantillaId.Name = "lblPlantillaId";
            this.lblPlantillaId.Size = new System.Drawing.Size(80, 15);
            this.lblPlantillaId.TabIndex = 0;
            this.lblPlantillaId.Text = "ID Plantilla: 0";
            
            // lblFechaCreacion
            this.lblFechaCreacion.AutoSize = true;
            this.lblFechaCreacion.Location = new System.Drawing.Point(6, 47);
            this.lblFechaCreacion.Name = "lblFechaCreacion";
            this.lblFechaCreacion.Size = new System.Drawing.Size(98, 15);
            this.lblFechaCreacion.TabIndex = 1;
            this.lblFechaCreacion.Text = "Creada: 01/01/2025";
            
            // lblEquipo
            this.lblEquipo.AutoSize = true;
            this.lblEquipo.Location = new System.Drawing.Point(6, 72);
            this.lblEquipo.Name = "lblEquipo";
            this.lblEquipo.Size = new System.Drawing.Size(45, 15);
            this.lblEquipo.TabIndex = 2;
            this.lblEquipo.Text = "Equipo:";
            
            // cbEquipo
            this.cbEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipo.FormattingEnabled = true;
            this.cbEquipo.Location = new System.Drawing.Point(6, 90);
            this.cbEquipo.Name = "cbEquipo";
            this.cbEquipo.Size = new System.Drawing.Size(448, 23);
            this.cbEquipo.TabIndex = 3;
            
            // lblPresupuesto
            this.lblPresupuesto.AutoSize = true;
            this.lblPresupuesto.Location = new System.Drawing.Point(6, 117);
            this.lblPresupuesto.Name = "lblPresupuesto";
            this.lblPresupuesto.Size = new System.Drawing.Size(72, 15);
            this.lblPresupuesto.TabIndex = 4;
            this.lblPresupuesto.Text = "Presupuesto:";
            
            // tbPresupuesto
            this.tbPresupuesto.Location = new System.Drawing.Point(6, 135);
            this.tbPresupuesto.Name = "tbPresupuesto";
            this.tbPresupuesto.Size = new System.Drawing.Size(448, 23);
            this.tbPresupuesto.TabIndex = 5;
            
            // btnGuardar
            this.btnGuardar.Location = new System.Drawing.Point(6, 164);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(448, 30);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            
            // gbJugadores
            this.gbJugadores.Controls.Add(this.btnAgregarJugador);
            this.gbJugadores.Controls.Add(this.dgvJugadores);
            this.gbJugadores.Location = new System.Drawing.Point(12, 218);
            this.gbJugadores.Name = "gbJugadores";
            this.gbJugadores.Size = new System.Drawing.Size(460, 300);
            this.gbJugadores.TabIndex = 1;
            this.gbJugadores.TabStop = false;
            this.gbJugadores.Text = "Jugadores en Plantilla";
            
            // dgvJugadores
            this.dgvJugadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJugadores.Location = new System.Drawing.Point(6, 22);
            this.dgvJugadores.Name = "dgvJugadores";
            this.dgvJugadores.RowTemplate.Height = 25;
            this.dgvJugadores.Size = new System.Drawing.Size(448, 242);
            this.dgvJugadores.TabIndex = 0;
            
            // btnAgregarJugador
            this.btnAgregarJugador.Location = new System.Drawing.Point(6, 268);
            this.btnAgregarJugador.Name = "btnAgregarJugador";
            this.btnAgregarJugador.Size = new System.Drawing.Size(448, 26);
            this.btnAgregarJugador.TabIndex = 1;
            this.btnAgregarJugador.Text = "Agregar Jugador";
            this.btnAgregarJugador.UseVisualStyleBackColor = true;
            this.btnAgregarJugador.Click += new System.EventHandler(this.btnAgregarJugador_Click);
            
            // btnCancelar
            this.btnCancelar.Location = new System.Drawing.Point(12, 524);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(460, 30);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            
            // EditarPlantilla
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 566);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gbJugadores);
            this.Controls.Add(this.gbDatos);
            this.Name = "EditarPlantilla";
            this.Text = "Editar Plantilla";
            this.Load += new System.EventHandler(this.EditarPlantilla_Load);
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.gbJugadores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJugadores)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblPlantillaId;
        private System.Windows.Forms.Label lblFechaCreacion;
        private System.Windows.Forms.Label lblEquipo;
        private System.Windows.Forms.ComboBox cbEquipo;
        private System.Windows.Forms.Label lblPresupuesto;
        private System.Windows.Forms.TextBox tbPresupuesto;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox gbJugadores;
        private System.Windows.Forms.DataGridView dgvJugadores;
        private System.Windows.Forms.Button btnAgregarJugador;
        private System.Windows.Forms.Button btnCancelar;
    }
}
