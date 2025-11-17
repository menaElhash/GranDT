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
    public partial class seleccion : Form
    {
        private Usuario? usuarioActual = null;
        private Plantilla? plantillaActual = null;
        private List<Jugador> jugadoresDisponibles = new List<Jugador>();
        private Jugador? jugadorSeleccionado = null;

        public Usuario? UsuarioActual
        {
            get { return usuarioActual; }
            set { usuarioActual = value; }
        }

        public Plantilla? PlantillaActual
        {
            get { return plantillaActual; }
            set { plantillaActual = value; }
        }

        public seleccion()
        {
            InitializeComponent();
        }

        private void seleccion_Load(object sender, EventArgs e)
        {
            if (plantillaActual != null)
            {
                CargarJugadoresDisponibles();
            }
        }

        private void CargarJugadoresDisponibles()
        {
            try
            {
                string connectionString = "Server=localhost;Database=futboldtdb;Uid=root;Pwd=;";
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var repoJugador = new RepoJugador(connection);
                    
                    // Traer jugadores por tipo y equipo (puedes ajustar estos parámetros)
                    jugadoresDisponibles = repoJugador.TraerJugadoresBasicoXTipoXEquipo(1, 1).ToList();
                    
                    // Mostrar los jugadores en los labels
                    MostrarJugadores();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar jugadores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarJugadores()
        {
            // Limpiar labels anteriores
            for (int i = 1; i <= 22; i++)
            {
                Label lbl = this.Controls.Find("label" + i, true).FirstOrDefault() as Label;
                if (lbl != null)
                {
                    lbl.Text = "";
                }
            }

            // Mostrar jugadores en los labels
            for (int i = 0; i < jugadoresDisponibles.Count && i < 22; i++)
            {
                Label lbl = this.Controls.Find("label" + (i + 1), true).FirstOrDefault() as Label;
                if (lbl != null)
                {
                    lbl.Text = $"{jugadoresDisponibles[i].nombre} {jugadoresDisponibles[i].apellido}";
                    lbl.Tag = jugadoresDisponibles[i].id_jugador;
                    lbl.Cursor = Cursors.Hand;
                    lbl.Click += (s, e) => SeleccionarJugador(jugadoresDisponibles[i]);
                }
            }
        }

        private void SeleccionarJugador(Jugador jugador)
        {
            jugadorSeleccionado = jugador;
            
            try
            {
                string connectionString = "Server=localhost;Database=futboldtdb;Uid=root;Pwd=;";
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var repoPlantilla = new RepoPlantilla(connection);
                    
                    // Agregar jugador a la plantilla (como suplente por defecto)
                    if (plantillaActual != null)
                    {
                        repoPlantilla.AltaJugadorEnPlantilla(jugador.id_jugador, plantillaActual.id_plantilla, false);
                        MessageBox.Show($"Jugador {jugador.nombre} agregado a la plantilla", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar jugador: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void Botonatras_Click(object sender, EventArgs e)
        {
            // cerrar form
            this.Hide();
        }
    }
}
