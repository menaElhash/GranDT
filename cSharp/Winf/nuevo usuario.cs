using System;
using System.Windows.Forms;

namespace el_dt_by_menardi_y_tello
{
    public partial class nuevo_usuario : Form
    {
        public nuevo_usuario()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Podés usar esto si más adelante querés agregar otra función
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Lo mismo que arriba
        }

        private void nuevo_usuario_Load(object sender, EventArgs e)
        {
            // Si querés algo al cargar el form, lo ponés acá
        }

        // --- BOTÓN SIGUIENTE ---
        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text.Trim();
            string email = textBox4.Text.Trim();
            string contraseña = textBox2.Text.Trim();

            // Validaciones (solo campos vacíos)
            bool camposIncompletos = string.IsNullOrWhiteSpace(usuario) ||
                                     string.IsNullOrWhiteSpace(email) ||
                                     string.IsNullOrWhiteSpace(contraseña);

            if (camposIncompletos)
            {
                // Si hay error, abre el form de error
                error errorForm = new error();
                errorForm.ShowDialog();
                return;
            }

            // Si todo está correcto → pasa al menú principal
            Menu_pricipal menuForm = new Menu_pricipal();
            menuForm.Show();
            this.Hide();
        }

        // --- BOTÓN volver ---
        private void label1_Click(object sender, EventArgs e)
        {
            Menú menú = new Menú();
            menú.Show();
            this.Hide();
        }
    }
}
