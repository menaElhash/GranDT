using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Dapper;
using Core;

namespace el_dt_by_menardi_y_tello
{
    public partial class Plnatilla : Form
    {
        private Usuario? usuarioActual = null;
        private Plantilla? plantillaActual = null;
        private List<Plantilla> plantillas = new List<Plantilla>();
        private Dictionary<int, PlantillaJugador> jugadoresEnPlantilla = new Dictionary<int, PlantillaJugador>();

        public Usuario? UsuarioActual
        {
            get { return usuarioActual; }
            set { usuarioActual = value; }
        }

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
            if (usuarioActual == null)
            {
                MessageBox.Show("No hay usuario logueado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            CargarPlantillas();
            if (plantillas.Count > 0)
            {
                CargarPlantilla(plantillas.First());
            }
        }

        private void CargarPlantillas()
        {
            try
            {
                string connectionString = "Server=localhost;Database=futboldtdb;Uid=root;Pwd=;";
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var repoPlantilla = new RepoPlantilla(connection);
                    plantillas = repoPlantilla.TraerPlantillasPorIdUsuario(usuarioActual!.id_usuario).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar plantillas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPlantilla(Plantilla plantilla)
        {
            plantillaActual = plantilla;
            // Aquí podrías cargar los jugadores de la plantilla
            // y mostrarlos en los botones correspondientes
        }

        // Evento que se dispara cuando tocás cualquiera de los botones de jugador
        private void BotonJugador_Click(object sender, EventArgs e)
        {
            // Abre el formulario de selección y oculta la plantilla actual
            seleccion selForm = new seleccion();
            selForm.PlantillaActual = plantillaActual;
            selForm.UsuarioActual = usuarioActual;
            selForm.Show();
        }
        
        private void BotonCrear_Click(object sender, EventArgs e)
        {
            // Abre el formulario de creación de jugador 
            CrarJugador crarjugador = new CrarJugador();
            crarjugador.PlantillaActual = plantillaActual;
            crarjugador.UsuarioActual = usuarioActual;
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
