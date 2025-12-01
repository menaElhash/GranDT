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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarPlantilla));
            gbDatos = new GroupBox();
            btnGuardar = new Button();
            lblFechaCreacion = new Label();
            lblPlantillaId = new Label();
            tbPresupuesto = new TextBox();
            lblPresupuesto = new Label();
            cbEquipo = new ComboBox();
            lblEquipo = new Label();
            lblRestante = new Label();
            dgvJugadores = new DataGridView();
            btnAgregarJugador = new Button();
            btnCancelar = new Button();
            gbJugadores = new GroupBox();
            gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvJugadores).BeginInit();
            gbJugadores.SuspendLayout();
            SuspendLayout();
            // 
            // gbDatos
            // 
            gbDatos.BackColor = Color.Transparent;
            gbDatos.Controls.Add(btnGuardar);
            gbDatos.Controls.Add(lblFechaCreacion);
            gbDatos.Controls.Add(lblPlantillaId);
            gbDatos.Controls.Add(tbPresupuesto);
            gbDatos.Controls.Add(lblPresupuesto);
            gbDatos.Controls.Add(cbEquipo);
            gbDatos.Controls.Add(lblEquipo);
            gbDatos.Controls.Add(lblRestante);
            gbDatos.Location = new Point(36, 12);
            gbDatos.Name = "gbDatos";
            gbDatos.Size = new Size(465, 241);
            gbDatos.TabIndex = 0;
            gbDatos.TabStop = false;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(0, 186);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(448, 30);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar Cambios";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lblFechaCreacion
            // 
            lblFechaCreacion.AutoSize = true;
            lblFechaCreacion.Location = new Point(88, 44);
            lblFechaCreacion.Name = "lblFechaCreacion";
            lblFechaCreacion.Size = new Size(65, 15);
            lblFechaCreacion.TabIndex = 1;
            lblFechaCreacion.Text = "01/01/2025";
            // 
            // lblPlantillaId
            // 
            lblPlantillaId.AutoSize = true;
            lblPlantillaId.Location = new Point(112, 19);
            lblPlantillaId.Name = "lblPlantillaId";
            lblPlantillaId.Size = new Size(13, 15);
            lblPlantillaId.TabIndex = 0;
            lblPlantillaId.Text = "0";
            // 
            // tbPresupuesto
            // 
            tbPresupuesto.Location = new Point(6, 157);
            tbPresupuesto.Name = "tbPresupuesto";
            tbPresupuesto.Size = new Size(448, 23);
            tbPresupuesto.TabIndex = 5;
            // 
            // lblPresupuesto
            // 
            lblPresupuesto.AutoSize = true;
            lblPresupuesto.Location = new Point(125, 134);
            lblPresupuesto.Name = "lblPresupuesto";
            lblPresupuesto.Size = new Size(0, 15);
            lblPresupuesto.TabIndex = 4;
            // 
            // cbEquipo
            // 
            cbEquipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEquipo.FormattingEnabled = true;
            cbEquipo.Location = new Point(6, 97);
            cbEquipo.Name = "cbEquipo";
            cbEquipo.Size = new Size(448, 23);
            cbEquipo.TabIndex = 3;
            // 
            // lblEquipo
            // 
            lblEquipo.AutoSize = true;
            lblEquipo.Location = new Point(88, 59);
            lblEquipo.Name = "lblEquipo";
            lblEquipo.Size = new Size(0, 15);
            lblEquipo.TabIndex = 2;
            // 
            // lblRestante
            // 
            lblRestante.AutoSize = true;
            lblRestante.Location = new Point(6, 160);
            lblRestante.Name = "lblRestante";
            lblRestante.Size = new Size(70, 15);
            lblRestante.TabIndex = 7;
            lblRestante.Text = "Restante: $0";
            // 
            // dgvJugadores
            // 
            dgvJugadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvJugadores.Location = new Point(23, 25);
            dgvJugadores.Name = "dgvJugadores";
            dgvJugadores.Size = new Size(442, 188);
            dgvJugadores.TabIndex = 0;
            // 
            // btnAgregarJugador
            // 
            btnAgregarJugador.Location = new Point(23, 220);
            btnAgregarJugador.Name = "btnAgregarJugador";
            btnAgregarJugador.Size = new Size(448, 26);
            btnAgregarJugador.TabIndex = 1;
            btnAgregarJugador.Text = "Agregar Jugador";
            btnAgregarJugador.UseVisualStyleBackColor = true;
            btnAgregarJugador.Click += btnAgregarJugador_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(18, 252);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(460, 30);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // gbJugadores
            // 
            gbJugadores.BackColor = Color.Transparent;
            gbJugadores.Controls.Add(btnCancelar);
            gbJugadores.Controls.Add(btnAgregarJugador);
            gbJugadores.Controls.Add(dgvJugadores);
            gbJugadores.Location = new Point(12, 234);
            gbJugadores.Name = "gbJugadores";
            gbJugadores.Size = new Size(489, 319);
            gbJugadores.TabIndex = 1;
            gbJugadores.TabStop = false;
            // 
            // EditarPlantilla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(527, 528);
            Controls.Add(gbJugadores);
            Controls.Add(gbDatos);
            Name = "EditarPlantilla";
            Text = "Editar Plantilla";
            Load += EditarPlantilla_Load;
            gbDatos.ResumeLayout(false);
            gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvJugadores).EndInit();
            gbJugadores.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblPlantillaId;
        private System.Windows.Forms.Label lblFechaCreacion;
        private System.Windows.Forms.Label lblEquipo;
        private System.Windows.Forms.ComboBox cbEquipo;
        private System.Windows.Forms.Label lblPresupuesto;
        private System.Windows.Forms.TextBox tbPresupuesto;
        private System.Windows.Forms.Label lblRestante;
        private System.Windows.Forms.Button btnGuardar;
        private DataGridView dgvJugadores;
        private Button btnAgregarJugador;
        private Button btnCancelar;
        private GroupBox gbJugadores;
    }
}
