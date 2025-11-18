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
using Core.Repos;
using Dapper;

namespace el_dt_by_menardi_y_tello
{
    public partial class AltaPlantilla : Form
    {
        private const decimal PRESUPUESTO_FIJO = 6500000;
            

        private readonly IRepoPlantilla _repoPlantilla;
        private readonly IRepoJugador _repoJugador;
        private readonly IDbConnection _conexion;
        private int _usuarioId;

        public AltaPlantilla(int usuarioId)
        {
            InitializeComponent();
            _usuarioId = usuarioId;
            _conexion = DbConnection.GetConnection();
            _repoPlantilla = new RepoPlantilla(_conexion);
            _repoJugador = new RepoJugador(_conexion);
        }

        private void AltaPlantilla_Load(object sender, EventArgs e)
        {
            CargarEquipos();
            lblPresupuesto.Text = $"Presupuesto: ${PRESUPUESTO_FIJO:N0}";
        }

        private void CargarEquipos()
        {
            try
            {
                var equipos = _repoJugador.TraerEquipo().ToList();
                cbEquipo.DataSource = new BindingSource(equipos, null);
                cbEquipo.DisplayMember = "nombre";
                cbEquipo.ValueMember = "id_equipo";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar equipos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (_usuarioId <= 0)
            {
                MessageBox.Show("No se puede crear la plantilla sin un usuario válido.", "Sesión requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbEquipo.SelectedItem == null)
            {
                MessageBox.Show("Por favor selecciona un equipo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var equipoSeleccionado = (Equipo)cbEquipo.SelectedItem;
                var plantilla = new Plantilla
                {
                    id_usuario = _usuarioId,
                    id_equipo = equipoSeleccionado.id_equipo,
                    presupuesto_max = PRESUPUESTO_FIJO,
                    fecha_creacion = DateTime.Now
                };

                int idPlantillaCreada = _repoPlantilla.AltaPlantilla(plantilla);
                if (idPlantillaCreada > 0)
                {
                    MessageBox.Show("Plantilla creada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo crear la plantilla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear plantilla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
