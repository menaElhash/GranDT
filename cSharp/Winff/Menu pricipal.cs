using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;

namespace el_dt_by_menardi_y_tello
{
    public partial class Menu_pricipal : Form
    {
        private Usuario? usuarioActual = null;

        public Usuario? UsuarioActual
        {
            get { return usuarioActual; }
            set { usuarioActual = value; }
        }

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

        // --- BOTÓN JUGAR (Ver Plantilla) ---
        private void button1_Click(object sender, EventArgs e)
        {
            Plnatilla plantillaForm = new Plnatilla();
            plantillaForm.UsuarioActual = usuarioActual;
            plantillaForm.Show();
            this.Hide();
        }

        // --- BOTÓN OPCIONES ---
        private void button2_Click(object sender, EventArgs e)
        {
            opciones opcionesForm = new opciones();
            opcionesForm.Show();
            this.Hide();
        }

        // --- BOTÓN SALIR ---
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
