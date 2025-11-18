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
    public partial class anuncio2 : Form
    {
        private readonly int _usuarioId;

        public anuncio2() : this(0)
        {
        }

        public anuncio2(int usuarioId)
        {
            InitializeComponent();
            _usuarioId = usuarioId;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            SeleccionarPlantilla seleccionarPlantilla = new SeleccionarPlantilla(_usuarioId);
            seleccionarPlantilla .Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(_usuarioId);
            form2.Show();
            this.Hide();
        }
    }
}
