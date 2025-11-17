namespace el_dt_by_menardi_y_tello
{
    partial class nuevo_usuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(nuevo_usuario));
            textBox4 = new TextBox();
            textBox1 = new TextBox();
            label6 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            label1 = new Label();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            btnRegistrar = new PictureBox();
            pictureBox3 = new PictureBox();
            maskedTextBox1 = new MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnRegistrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // textBox4
            // 
            textBox4.Location = new Point(151, 154);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(216, 23);
            textBox4.TabIndex = 15;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(151, 97);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(216, 23);
            textBox1.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.LightGray;
            label6.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(52, 147);
            label6.Name = "label6";
            label6.Size = new Size(72, 30);
            label6.TabIndex = 13;
            label6.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.LightGray;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(41, 90);
            label2.Name = "label2";
            label2.Size = new Size(94, 30);
            label2.TabIndex = 14;
            label2.Text = "Usuario:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(151, 251);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(216, 23);
            textBox2.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightGray;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 242);
            label1.Name = "label1";
            label1.Size = new Size(129, 30);
            label1.TabIndex = 17;
            label1.Text = "Contraseña:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.LightGray;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(8, 198);
            label3.Name = "label3";
            label3.Size = new Size(133, 30);
            label3.TabIndex = 18;
            label3.Text = "Nacimiento:";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(-8, -3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(806, 452);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 22;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.Transparent;
            btnRegistrar.Image = (Image)resources.GetObject("btnRegistrar.Image");
            btnRegistrar.Location = new Point(591, 384);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(193, 54);
            btnRegistrar.SizeMode = PictureBoxSizeMode.Zoom;
            btnRegistrar.TabIndex = 23;
            btnRegistrar.TabStop = false;
            btnRegistrar.Click += button1_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(8, 395);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(106, 43);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 24;
            pictureBox3.TabStop = false;
            pictureBox3.Click += label1_Click;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(160, 205);
            maskedTextBox1.Mask = "0000-00-00";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(166, 23);
            maskedTextBox1.TabIndex = 25;
            maskedTextBox1.ValidatingType = typeof(DateTime);
            // 
            // nuevo_usuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(796, 444);
            Controls.Add(maskedTextBox1);
            Controls.Add(btnRegistrar);
            Controls.Add(pictureBox3);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(textBox4);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "nuevo_usuario";
            Text = "Gran DT";
            Load += nuevo_usuario_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnRegistrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox4;
        private TextBox textBox1;
        private Label label6;
        private Label label2;
        private TextBox textBox2;
        private Label label1;
        private Label label3;
        private PictureBox pictureBox2;
        private PictureBox btnRegistrar;
        private PictureBox pictureBox3;
        private MaskedTextBox maskedTextBox1;
    }
}