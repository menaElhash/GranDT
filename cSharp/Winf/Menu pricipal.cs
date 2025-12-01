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
        private readonly int _usuarioId;
        private readonly int _usuarioRol; // 1 = admin

        public Menu_pricipal() : this(0, 0)
        {
        }

        public Menu_pricipal(int usuarioId) : this(usuarioId, 0)
        {
        }

        public Menu_pricipal(int usuarioId, int usuarioRol)
        {
            InitializeComponent();
            _usuarioId = usuarioId;
            _usuarioRol = usuarioRol;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Ejemplo si después querés que haga algo cuando se toque la imagen
        }

        private void Menu_pricipal_Load(object sender, EventArgs e)
        {
            // Mostrar botones admin solo si el usuario es admin
            if (_usuarioRol == 1)
            {
                CrearBotonesAdmin();
            }
        }

        private void CrearBotonesAdmin()
        {
            // Button: Alta Equipo
            var btnAltaEquipo = new Button
            {
                Name = "btnAltaEquipo",
                Text = "Alta Equipo",
                Size = new Size(160, 40),
                Location = new Point(500, 120)
            };
            btnAltaEquipo.Click += BtnAltaEquipo_Click;
            Controls.Add(btnAltaEquipo);

            // Button: Alta Puntuación
            var btnAltaPuntuacion = new Button
            {
                Name = "btnAltaPuntuacion",
                Text = "Alta Puntuación",
                Size = new Size(160, 40),
                Location = new Point(500, 180)
            };
            btnAltaPuntuacion.Click += BtnAltaPuntuacion_Click;
            Controls.Add(btnAltaPuntuacion);

            // Button: Alta Jugador
            var btnAltaJugador = new Button
            {
                Name = "btnAltaJugador",
                Text = "Alta Jugador",
                Size = new Size(160, 40),
                Location = new Point(500, 240)
            };
            btnAltaJugador.Click += BtnAltaJugador_Click;
            Controls.Add(btnAltaJugador);
        }

        private void BtnAltaEquipo_Click(object? sender, EventArgs e)
        {
            AltaEquipo form = new AltaEquipo();
            form.ShowDialog();
        }

        private void BtnAltaPuntuacion_Click(object? sender, EventArgs e)
        {
            AltaPuntuacion form = new AltaPuntuacion();
            form.ShowDialog();
        }

        private void BtnAltaJugador_Click(object? sender, EventArgs e)
        {
            CrarJugador form = new CrarJugador();
            form.ShowDialog();
        }

        // --- BOTÓN JUGAR ---
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(_usuarioId);
            form2.Show();
            this.Hide();
        }

        // --- BOTÓN OPCIONES ---
        private void button2_Click(object sender, EventArgs e)
        {
            opciones opcionesForm = new opciones(_usuarioId);
            opcionesForm.Show();
            this.Hide();
        }

        // --- BOTÓN SALIR ---
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(_usuarioId);
            form2.Show();
            this.Hide();
        }
    }
}
