using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace el_dt_by_menardi_y_tello
{
    public partial class Menú : Form
    {
        private bool nuevoUsuarioCreado = false; // bandera para saber si entró por "Nuevo Usuario"

        public Menú()
        {
            InitializeComponent();
        }

        private void Menú_Load(object sender, EventArgs e)
        {
            // Al cargar el form podés dejar esto vacío o agregar música si querés
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Abre el formulario nuevo_usuario y oculta este
            nuevo_usuario nuevoForm = new nuevo_usuario();
            nuevoForm.Show();
            this.Hide();

            // Marca que se creó un usuario nuevo (para saltar validaciones)
            nuevoUsuarioCreado = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Verifica si los campos están completos o si viene de nuevo usuario
            if (nuevoUsuarioCreado ||
                (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox4.Text)))
            {
                // Si todo está correcto → entra al menú principal
                Menu_pricipal menuForm = new Menu_pricipal();
                menuForm.Show();
                this.Hide();
            }
            else
            {
                // Si falta algo → abre el form de error
                error error = new error();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Acá podrías poner validaciones en tiempo real si querés más adelante
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Igual que arriba, si querés agregar condiciones mientras escribe
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
