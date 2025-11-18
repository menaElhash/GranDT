namespace el_dt_by_menardi_y_tello
{
    partial class seleccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(seleccion));
            labelTipo = new Label();
            comboBoxTipo = new ComboBox();
            labelJugadores = new Label();
            listadoJugadores = new DataGridView();
            labelSeleccionar = new Label();
            comboBoxJugadores = new ComboBox();
            buttonReiniciar = new Button();
            buttonAvanzar = new Button();
            buttonAtras = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)listadoJugadores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelTipo
            // 
            labelTipo.AutoSize = true;
            labelTipo.BackColor = Color.Transparent;
            labelTipo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelTipo.Location = new Point(20, 20);
            labelTipo.Name = "labelTipo";
            labelTipo.Size = new Size(134, 21);
            labelTipo.TabIndex = 0;
            labelTipo.Text = "Selecciona Tipo:";
            // 
            // comboBoxTipo
            // 
            comboBoxTipo.FormattingEnabled = true;
            comboBoxTipo.Location = new Point(20, 50);
            comboBoxTipo.Name = "comboBoxTipo";
            comboBoxTipo.Size = new Size(200, 23);
            comboBoxTipo.TabIndex = 1;
            comboBoxTipo.SelectedIndexChanged += comboBoxTipo_SelectedIndexChanged;
            // 
            // labelJugadores
            // 
            labelJugadores.AutoSize = true;
            labelJugadores.BackColor = Color.Transparent;
            labelJugadores.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelJugadores.Location = new Point(20, 90);
            labelJugadores.Name = "labelJugadores";
            labelJugadores.Size = new Size(186, 21);
            labelJugadores.TabIndex = 2;
            labelJugadores.Text = "Jugadores Disponibles:";
            // 
            // listadoJugadores
            // 
            listadoJugadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            listadoJugadores.Location = new Point(20, 120);
            listadoJugadores.Name = "listadoJugadores";
            listadoJugadores.Size = new Size(560, 200);
            listadoJugadores.TabIndex = 3;
            // 
            // labelSeleccionar
            // 
            labelSeleccionar.AutoSize = true;
            labelSeleccionar.BackColor = Color.Transparent;
            labelSeleccionar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelSeleccionar.Location = new Point(20, 330);
            labelSeleccionar.Name = "labelSeleccionar";
            labelSeleccionar.Size = new Size(187, 21);
            labelSeleccionar.TabIndex = 4;
            labelSeleccionar.Text = "Selecciona un Jugador:";
            // 
            // comboBoxJugadores
            // 
            comboBoxJugadores.FormattingEnabled = true;
            comboBoxJugadores.Location = new Point(20, 360);
            comboBoxJugadores.Name = "comboBoxJugadores";
            comboBoxJugadores.Size = new Size(200, 23);
            comboBoxJugadores.TabIndex = 5;
            // 
            // buttonReiniciar
            // 
            buttonReiniciar.Location = new Point(385, 81);
            buttonReiniciar.Name = "buttonReiniciar";
            buttonReiniciar.Size = new Size(181, 30);
            buttonReiniciar.TabIndex = 6;
            buttonReiniciar.Text = "Reiniciar";
            buttonReiniciar.UseVisualStyleBackColor = true;
            buttonReiniciar.Click += buttonReiniciar_Click;
            // 
            // buttonAvanzar
            // 
            buttonAvanzar.Location = new Point(605, 458);
            buttonAvanzar.Name = "buttonAvanzar";
            buttonAvanzar.Size = new Size(175, 30);
            buttonAvanzar.TabIndex = 7;
            buttonAvanzar.Text = "Avanzar";
            buttonAvanzar.UseVisualStyleBackColor = true;
            buttonAvanzar.Click += buttonAvanzar_Click;
            // 
            // buttonAtras
            // 
            buttonAtras.Location = new Point(12, 458);
            buttonAtras.Name = "buttonAtras";
            buttonAtras.Size = new Size(134, 30);
            buttonAtras.TabIndex = 8;
            buttonAtras.Text = "Atrás";
            buttonAtras.UseVisualStyleBackColor = true;
            buttonAtras.Click += Botonatras_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-3, -11);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(805, 499);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // seleccion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.Disable;
            ClientSize = new Size(794, 486);
            Controls.Add(labelTipo);
            Controls.Add(comboBoxTipo);
            Controls.Add(labelJugadores);
            Controls.Add(listadoJugadores);
            Controls.Add(labelSeleccionar);
            Controls.Add(comboBoxJugadores);
            Controls.Add(pictureBox1);
            Controls.Add(buttonReiniciar);
            Controls.Add(buttonAvanzar);
            Controls.Add(buttonAtras);
            Name = "seleccion";
            Text = "Selección de Jugadores";
            Load += seleccion_Load;
            ((System.ComponentModel.ISupportInitialize)listadoJugadores).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTipo;
        private ComboBox comboBoxTipo;
        private Label labelJugadores;
        private DataGridView listadoJugadores;
        private Label labelSeleccionar;
        private ComboBox comboBoxJugadores;
        private Button buttonReiniciar;
        private Button buttonAvanzar;
        private Button buttonAtras;
        private PictureBox pictureBox1;
    }
}
