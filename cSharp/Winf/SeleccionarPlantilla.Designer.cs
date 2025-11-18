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
            cbPlantillas = new ComboBox();
            btnConfirmar = new Button();
            btnCrear = new Button();
            lblTitulo = new Label();
            SuspendLayout();
            // 
            // cbPlantillas
            // 
            cbPlantillas.FormattingEnabled = true;
            cbPlantillas.Location = new Point(150, 100);
            cbPlantillas.Name = "cbPlantillas";
            cbPlantillas.Size = new Size(500, 23);
            cbPlantillas.TabIndex = 0;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(500, 350);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(100, 30);
            btnConfirmar.TabIndex = 1;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(200, 350);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(100, 30);
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
            lblTitulo.Size = new Size(150, 15);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "Selecciona una Plantilla:";
            // 
            // SeleccionarPlantilla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTitulo);
            Controls.Add(btnCrear);
            Controls.Add(btnConfirmar);
            Controls.Add(cbPlantillas);
            Name = "SeleccionarPlantilla";
            Text = "Seleccionar Plantilla";
            Load += SeleccionarPlantilla_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbPlantillas;
        private Button btnConfirmar;
        private Button btnCrear;
        private Label lblTitulo;
    }
}