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
            pictureBox3 = new PictureBox();
            btnRegistrar = new PictureBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label6 = new Label();
            textBox4 = new TextBox();
            textBox2 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnRegistrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(12, 411);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(106, 43);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 9;
            pictureBox3.TabStop = false;
            pictureBox3.Click += label5_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.Transparent;
            btnRegistrar.Image = (Image)resources.GetObject("btnRegistrar.Image");
            btnRegistrar.Location = new Point(638, 400);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(193, 54);
            btnRegistrar.SizeMode = PictureBoxSizeMode.Zoom;
            btnRegistrar.TabIndex = 9;
            btnRegistrar.TabStop = false;
            btnRegistrar.Click += label3_Click;
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
            // textBox1
            // 
            textBox1.Location = new Point(134, 104);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(216, 23);
            textBox1.TabIndex = 12;
            textBox1.Click += textBox1_TextChanged;
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
            // textBox4
            // 
            textBox4.Location = new Point(134, 150);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(216, 23);
            textBox4.TabIndex = 12;
            textBox4.Click += textBox2_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(134, 206);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(216, 23);
            textBox2.TabIndex = 12;
            textBox2.Click += textBox2_TextChanged;
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
            Controls.Add(textBox2);
            Controls.Add(textBox4);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(btnRegistrar);
            Controls.Add(pictureBox3);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Menú";
            Text = "Gran DT";
            Load += Menú_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnRegistrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtEmail;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private PictureBox pictureBox3;
        private PictureBox btnRegistrar;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label6;
        private TextBox textBox4;
        private TextBox textBox2;
        private Label label3;
        private Label label4;
    }
}