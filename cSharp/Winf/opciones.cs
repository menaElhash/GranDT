using System;
using System.Windows.Forms;

namespace el_dt_by_menardi_y_tello
{
    public partial class opciones : Form
    {
        private readonly int _usuarioId;

        public opciones() : this(0)
        {
        }

        public opciones(int usuarioId)
        {
            InitializeComponent();
            _usuarioId = usuarioId;

            // El checkbox arranca según si la música está sonando o no
            checkBox1.Checked = MusicaGlobal.Iniciada;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                MusicaGlobal.Reanudar(); // vuelve a sonar
            }
            else
            {
                MusicaGlobal.Detener(); // pausa
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu_pricipal menu = new Menu_pricipal(_usuarioId);
            menu.Show();
            this.Hide();
        }
    }
}
