namespace el_dt_by_menardi_y_tello
{
    partial class Menú
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menú));
            Cerrar = new PictureBox();
            Siguiente = new PictureBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            UsuarioBox = new TextBox();
            label6 = new Label();
            PasswordBox = new TextBox();
            RepetirPasswordBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)Cerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Siguiente).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Cerrar
            // 
            Cerrar.BackColor = Color.Transparent;
            Cerrar.Image = (Image)resources.GetObject("Cerrar.Image");
            Cerrar.Location = new Point(12, 411);
            Cerrar.Name = "Cerrar";
            Cerrar.Size = new Size(106, 43);
            Cerrar.SizeMode = PictureBoxSizeMode.Zoom;
            Cerrar.TabIndex = 9;
            Cerrar.TabStop = false;
            Cerrar.Click += label5_Click;
            // 
            // Siguiente
            // 
            Siguiente.BackColor = Color.Transparent;
            Siguiente.Image = (Image)resources.GetObject("Siguiente.Image");
            Siguiente.Location = new Point(638, 400);
            Siguiente.Name = "Siguiente";
            Siguiente.Size = new Size(193, 54);
            Siguiente.SizeMode = PictureBoxSizeMode.Zoom;
            Siguiente.TabIndex = 9;
            Siguiente.TabStop = false;
            Siguiente.Click += label3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(688, 150);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(113, 95);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(663, 248);
            label1.Name = "label1";
            label1.Size = new Size(159, 30);
            label1.TabIndex = 11;
            label1.Text = "Nuevo Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(24, 97);
            label2.Name = "label2";
            label2.Size = new Size(94, 30);
            label2.TabIndex = 11;
            label2.Text = "Usuario:";
            // 
            // UsuarioBox
            // 
            UsuarioBox.Location = new Point(134, 104);
            UsuarioBox.Name = "UsuarioBox";
            UsuarioBox.Size = new Size(216, 23);
            UsuarioBox.TabIndex = 12;
            UsuarioBox.Click += textBox1_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(3, 141);
            label6.Name = "label6";
            label6.Size = new Size(129, 30);
            label6.TabIndex = 11;
            label6.Text = "Contraseña:";
            label6.Click += label6_Click;
            // 
            // PasswordBox
            // 
            PasswordBox.Location = new Point(134, 150);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.Size = new Size(216, 23);
            PasswordBox.TabIndex = 12;
            PasswordBox.Click += textBox2_TextChanged;
            // 
            // RepetirPasswordBox
            // 
            RepetirPasswordBox.Location = new Point(134, 206);
            RepetirPasswordBox.Name = "RepetirPasswordBox";
            RepetirPasswordBox.Size = new Size(216, 23);
            RepetirPasswordBox.TabIndex = 12;
            RepetirPasswordBox.Click += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(24, 185);
            label3.Name = "label3";
            label3.Size = new Size(89, 30);
            label3.TabIndex = 11;
            label3.Text = "Repetir ";
            label3.Click += label6_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(3, 215);
            label4.Name = "label4";
            label4.Size = new Size(135, 30);
            label4.TabIndex = 11;
            label4.Text = "Contraseña: ";
            label4.Click += label6_Click;
            // 
            // Menú
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(861, 466);
            Controls.Add(RepetirPasswordBox);
            Controls.Add(PasswordBox);
            Controls.Add(UsuarioBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(Siguiente);
            Controls.Add(Cerrar);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Menú";
            Text = "Gran DT";
            Load += Menú_Load;
            ((System.ComponentModel.ISupportInitialize)Cerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)Siguiente).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtEmail;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private PictureBox Cerrar;
        private PictureBox Siguiente;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private TextBox UsuarioBox;
        private Label label6;
        private TextBox PasswordBox;
        private TextBox RepetirPasswordBox;
        private Label label3;
        private Label label4;
    }
}