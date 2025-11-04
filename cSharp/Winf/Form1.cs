using System;
using System.Windows.Forms;

namespace el_dt_by_menardi_y_tello
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Inicia la música global (solo una vez)
            MusicaGlobal.Iniciar();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // No hace falta nada acá por ahora
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Ir al menú principal
            Menú menuForm = new Menú();
            menuForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // También ir al menú principal
            Menú menuForm = new Menú();
            menuForm.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // Cierra la aplicación
            Application.Exit();
        }
    }
}
