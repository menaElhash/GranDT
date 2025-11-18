namespace el_dt_by_menardi_y_tello
{
    partial class SeleccionarPlantilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeleccionarPlantilla));
            cbPlantillas = new ComboBox();
            btnConfirmar = new Button();
            btnCrear = new Button();
            lblTitulo = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // cbPlantillas
            // 
            cbPlantillas.FormattingEnabled = true;
            cbPlantillas.Location = new Point(150, 176);
            cbPlantillas.Name = "cbPlantillas";
            cbPlantillas.Size = new Size(500, 23);
            cbPlantillas.TabIndex = 0;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(440, 337);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(194, 45);
            btnConfirmar.TabIndex = 1;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(171, 344);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(180, 30);
            btnCrear.TabIndex = 2;
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(150, 50);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(134, 15);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "Selecciona una Plantilla:";
            // 
            // pictureBox1
            // 
            pictureBox1.Enabled = false;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-1, -4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(803, 459);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // SeleccionarPlantilla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cbPlantillas);
            Controls.Add(pictureBox1);
            Controls.Add(lblTitulo);
            Controls.Add(btnCrear);
            Controls.Add(btnConfirmar);
            Name = "SeleccionarPlantilla";
            Text = "Seleccionar Plantilla";
            Load += SeleccionarPlantilla_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbPlantillas;
        private Button btnConfirmar;
        private Button btnCrear;
        private Label lblTitulo;
        private PictureBox pictureBox1;
    }
}