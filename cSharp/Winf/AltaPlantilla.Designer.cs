namespace el_dt_by_menardi_y_tello
{
    partial class AltaPlantilla
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
            cbEquipo = new ComboBox();
            btnCrear = new Button();
            btnCancelar = new Button();
            lblEquipo = new Label();
            lblPresupuesto = new Label();
            SuspendLayout();
            // 
            // cbEquipo
            // 
            cbEquipo.FormattingEnabled = true;
            cbEquipo.Location = new Point(150, 100);
            cbEquipo.Name = "cbEquipo";
            cbEquipo.Size = new Size(500, 23);
            cbEquipo.TabIndex = 0;
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(200, 350);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(100, 30);
            btnCrear.TabIndex = 1;
            btnCrear.Text = "Crear Plantilla";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(500, 350);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 30);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblEquipo
            // 
            lblEquipo.AutoSize = true;
            lblEquipo.Location = new Point(150, 50);
            lblEquipo.Name = "lblEquipo";
            lblEquipo.Size = new Size(100, 15);
            lblEquipo.TabIndex = 3;
            lblEquipo.Text = "Selecciona Equipo:";
            // 
            // lblPresupuesto
            // 
            lblPresupuesto.AutoSize = true;
            lblPresupuesto.Location = new Point(150, 150);
            lblPresupuesto.Name = "lblPresupuesto";
            lblPresupuesto.Size = new Size(150, 15);
            lblPresupuesto.TabIndex = 4;
            lblPresupuesto.Text = "Presupuesto: $10,000,000";
            // 
            // AltaPlantilla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblPresupuesto);
            Controls.Add(lblEquipo);
            Controls.Add(btnCancelar);
            Controls.Add(btnCrear);
            Controls.Add(cbEquipo);
            Name = "AltaPlantilla";
            Text = "Crear Nueva Plantilla";
            Load += AltaPlantilla_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbEquipo;
        private Button btnCrear;
        private Button btnCancelar;
        private Label lblEquipo;
        private Label lblPresupuesto;
    }
}