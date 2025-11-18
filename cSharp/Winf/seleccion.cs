using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using Core;
using Core.Repos;

namespace el_dt_by_menardi_y_tello
{
    public partial class seleccion : Form
    {
        private int _idEquipoActual;
        private int _idPlantilla;
        private int idTipoActual = 1; // ID de tipo actual (cambia según el ComboBox)
        private List<Jugador> jugadoresActuales = new List<Jugador>(); // Lista de jugadores cargados
        private readonly IRepoPlantilla _repoPlantilla;
        private readonly IRepoJugador _repoJugador;
        private readonly IDbConnection _conexion;

        private class TipoJugador
        {
            public int id { get; set; }
            public string nombre { get; set; }
        }

        public seleccion() : this(0, 0)
        {
        }

        public seleccion(int idPlantilla, int idEquipo)
        {
            InitializeComponent();
            _idPlantilla = idPlantilla;
            _idEquipoActual = idEquipo;
            _conexion = DbConnection.GetConnection();
            _repoPlantilla = new RepoPlantilla(_conexion);
            _repoJugador = new RepoJugador(_conexion);
        }

        private void seleccion_Load(object sender, EventArgs e)
        {
            try
            {
                // Configurar ComboBox de tipos (Arquero, Defensa, etc.)
                ConfigurarComboBoxTipos();

                // Cargar jugadores iniciales
                CargarJugadores();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarComboBoxTipos()
        {
            // Limpiar ComboBox de tipos
            comboBoxTipo.Items.Clear();
            comboBoxTipo.Items.Add(new TipoJugador { id = 1, nombre = "Arquero" });
            comboBoxTipo.Items.Add(new TipoJugador { id = 2, nombre = "Defensa" });
            comboBoxTipo.Items.Add(new TipoJugador { id = 3, nombre = "Volante" });
            comboBoxTipo.Items.Add(new TipoJugador { id = 4, nombre = "Delantero" });

            comboBoxTipo.DisplayMember = "nombre";
            comboBoxTipo.ValueMember = "id";
            comboBoxTipo.SelectedIndex = 0;

            if (comboBoxTipo.SelectedItem is TipoJugador item)
            {
                idTipoActual = item.id;
            }
        }

        private void CargarJugadores()
        {
            try
            {
                if (_idEquipoActual <= 0)
                {
                    MessageBox.Show("No se puede cargar jugadores: falta el equipo de la plantilla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                jugadoresActuales = _repoJugador.TraerJugadoresBasicoXTipoXEquipo((uint)idTipoActual, (uint)_idEquipoActual).ToList();

                // Cargar DataGrid
                listadoJugadores.DataSource = jugadoresActuales;

                // Cargar ComboBox de IDs
                CargarComboBoxJugadores();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar jugadores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboBoxJugadores()
        {
            try
            {
                var jugadoresCombo = jugadoresActuales.Select(j => new { id = j.id_jugador, nombre = $"ID: {j.id_jugador}" }).ToList();
                comboBoxJugadores.DataSource = jugadoresCombo;
                comboBoxJugadores.DisplayMember = "nombre";
                comboBoxJugadores.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ComboBox de jugadores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipo.SelectedItem is TipoJugador item)
            {
                idTipoActual = item.id;
            }
        }

        private void buttonReiniciar_Click(object sender, EventArgs e)
        {
            // Recargar jugadores con el nuevo tipo
            CargarJugadores();
        }

        private void buttonAvanzar_Click(object sender, EventArgs e)
        {
            if (_idPlantilla <= 0)
            {
                MessageBox.Show("No se puede agregar el jugador: falta la plantilla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxJugadores.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un jugador.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idJugadorSeleccionado = (int)comboBoxJugadores.SelectedValue;
                Jugador jugadorSeleccionado = jugadoresActuales.FirstOrDefault(j => j.id_jugador == idJugadorSeleccionado);

                if (jugadorSeleccionado != null)
                {
                    // Agregar el jugador a la plantilla (por defecto como suplente, se puede cambiar después)
                    _repoPlantilla.AltaJugadorEnPlantilla(idJugadorSeleccionado, _idPlantilla, esTitular: false);
                    
                    MessageBox.Show($"Jugador '{jugadorSeleccionado.nombre} {jugadorSeleccionado.apellido}' agregado a la plantilla.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Cerrar el formulario para volver a EditarPlantilla
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar jugador: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Botonatras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}

