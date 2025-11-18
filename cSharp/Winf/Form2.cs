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
    public partial class Form2 : Form
    {
        private readonly int _usuarioId;

        public Form2() : this(0)
        {
        }

        public Form2(int usuarioId)
        {
            InitializeComponent();
            _usuarioId = usuarioId;
        }
        // --- BOTÓN SIGUIENTE ---
        private void button1_Click(object sender, EventArgs e)
        {
            anuncio2 anuncioForm = new anuncio2(_usuarioId);
            anuncioForm.Show();
            this.Hide();
        }
    }
}
