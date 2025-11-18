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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaPlantilla));
            cbEquipo = new ComboBox();
            btnCrear = new Button();
            btnCancelar = new Button();
            lblEquipo = new Label();
            lblPresupuesto = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // cbEquipo
            // 
            cbEquipo.FormattingEnabled = true;
            cbEquipo.Location = new Point(150, 168);
            cbEquipo.Name = "cbEquipo";
            cbEquipo.Size = new Size(500, 23);
            cbEquipo.TabIndex = 0;
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(438, 336);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(200, 41);
            btnCrear.TabIndex = 1;
            btnCrear.Text = "Crear Plantilla";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(168, 341);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(187, 30);
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
            lblEquipo.Size = new Size(106, 15);
            lblEquipo.TabIndex = 3;
            lblEquipo.Text = "Selecciona Equipo:";
            // 
            // lblPresupuesto
            // 
            lblPresupuesto.AutoSize = true;
            lblPresupuesto.Location = new Point(150, 208);
            lblPresupuesto.Name = "lblPresupuesto";
            lblPresupuesto.Size = new Size(138, 15);
            lblPresupuesto.TabIndex = 4;
            lblPresupuesto.Text = "Presupuesto: $10,000,000";
            // 
            // pictureBox1
            // 
            pictureBox1.Enabled = false;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-1, -5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(805, 458);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // AltaPlantilla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblPresupuesto);
            Controls.Add(cbEquipo);
            Controls.Add(pictureBox1);
            Controls.Add(lblEquipo);
            Controls.Add(btnCrear);
            Controls.Add(btnCancelar);
            Name = "AltaPlantilla";
            Text = "Crear Nueva Plantilla";
            Load += AltaPlantilla_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbEquipo;
        private Button btnCrear;
        private Button btnCancelar;
        private Label lblEquipo;
        private Label lblPresupuesto;
        private PictureBox pictureBox1;
    }
}