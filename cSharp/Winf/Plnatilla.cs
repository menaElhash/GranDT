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
    public partial class Plnatilla : Form
    {
        public Plnatilla()
        {
            InitializeComponent();

            // Asociamos el mismo evento a los botones 3 a 18
            for (int i = 3; i <= 18; i++)
            {
                Button btn = this.Controls.Find("button" + i, true).FirstOrDefault() as Button;
                if (btn != null)
                {
                    btn.Click += BotonJugador_Click;
                }
            }
        }

        private void Plnatilla_Load(object sender, EventArgs e)
        {
            // Código al cargar el form (si querés poner música o fondo)
        }

        // Evento que se dispara cuando tocás cualquiera de los botones de jugador
        private void BotonJugador_Click(object sender, EventArgs e)
        {
            // Abre el formulario de selección y oculta la plantilla actual
            seleccion selForm = new seleccion();
            selForm.Show();
        }
        private void BotonCrear_Click(object sender, EventArgs e)
        {
            // Abre el formulario de selección 
            CrarJugador crarjugador = new CrarJugador();
            crarjugador.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
