using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace el_dt_by_menardi_y_tello
{
    public partial class Menu_pricipal : Form
    {
        public Menu_pricipal()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Ejemplo si después querés que haga algo cuando se toque la imagen
        }

        private void Menu_pricipal_Load(object sender, EventArgs e)
        {
            // Esto corre al cargar el form
        }

        // --- BOTÓN JUGAR ---
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        // --- BOTÓN OPCIONES ---
        private void button2_Click(object sender, EventArgs e)
        {
            opciones opciones = new opciones();
            opciones.Show();
            this.Hide();
        }

        // --- BOTÓN SALIR ---
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
