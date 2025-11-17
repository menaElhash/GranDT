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
    public partial class CrarJugador : Form
    {
        private Usuario? usuarioActual = null;
        private Plantilla? plantillaActual = null;

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

        public CrarJugador()
        {
            InitializeComponent();
        }

        private void CrarJugador_Load(object sender, EventArgs e)
        {
            // Cargar tipos de jugadores y equipos en los comboBox si existen
        }

        private void Botonatras_Click(object sender, EventArgs e)
        {
            // cerrar form
            this.Hide();
        }

        private void BotonaCrear_Click(object sender, EventArgs e)
        {
            // Obtener datos del formulario
            // Esto depende de qué controles haya en el Designer del formulario
            // Por ahora, mostraré la estructura general

            try
            {
                string connectionString = "Server=localhost;Database=futboldtdb;Uid=root;Pwd=;";
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var repoJugador = new RepoJugador(connection);
                    var repoPlantilla = new RepoPlantilla(connection);

                    // Crear un nuevo jugador
                    var nuevoJugador = new Jugador
                    {
                        nombre = "", // Obtener de textBox
                        apellido = "", // Obtener de textBox
                        apodo = "", // Obtener de textBox
                        fecha_nacimiento = DateTime.Now, // Obtener de DatePicker
                        cotizacion = 0, // Obtener de textBox
                        id_tipo = 1, // Obtener de comboBox
                        id_equipo = 1 // Obtener de comboBox
                    };

                    int idJugador = repoJugador.AltaJugador(nuevoJugador);

                    if (idJugador > 0 && plantillaActual != null)
                    {
                        // Agregar jugador a la plantilla
                        repoPlantilla.AltaJugadorEnPlantilla(idJugador, plantillaActual.id_plantilla, false);
                        MessageBox.Show("Jugador creado y agregado a la plantilla", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear jugador: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
