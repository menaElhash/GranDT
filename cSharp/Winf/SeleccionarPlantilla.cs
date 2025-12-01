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
    public partial class SeleccionarPlantilla : Form
    {
        private readonly IRepoPlantilla _repoPlantilla;
        private readonly IRepoJugador _repoJugador;
        private readonly IDbConnection _conexion;
        private int _usuarioId;
        private List<Plantilla> _plantillas = new List<Plantilla>();

        public SeleccionarPlantilla() : this(0)
        {
        }

        public SeleccionarPlantilla(int usuarioId)
        {
            InitializeComponent();
            _usuarioId = usuarioId;
            _conexion = DbConnection.GetConnection();
            _repoPlantilla = new RepoPlantilla(_conexion);
            _repoJugador = new RepoJugador(_conexion);
        }

        private void SeleccionarPlantilla_Load(object sender, EventArgs e)
        {
            if (_usuarioId <= 0)
            {
                MessageBox.Show("No se detectó el usuario. Volvé a iniciar sesión para elegir una plantilla.", "Sesión requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnCrear.Enabled = false;
                btnConfirmar.Enabled = false;
                return;
            }

            CargarPlantillas();
        }

        private void CargarPlantillas()
        {
            try
            {
                _plantillas = _repoPlantilla.TraerPlantillasPorIdUsuario(_usuarioId).ToList();
                if (_plantillas.Count > 0)
                {
                    // obtener nombres de equipos para mostrar en el combo
                    var equipos = _repoJugador.TraerEquipo().ToList();
                    var lista = _plantillas.Select(p => new
                    {
                        id_plantilla = p.id_plantilla,
                        id_equipo = p.id_equipo,
                        Nombre = $"Plantilla {p.id_plantilla} - { (equipos.FirstOrDefault(e => e.id_equipo == p.id_equipo)?.nombre ?? "Equipo") }"
                    }).ToList();

                    cbPlantillas.DisplayMember = "Nombre";
                    cbPlantillas.ValueMember = "id_plantilla";
                    cbPlantillas.DataSource = lista;
                }
                else
                {
                    MessageBox.Show("No tienes plantillas creadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar plantillas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (_usuarioId <= 0)
            {
                MessageBox.Show("No se puede crear la plantilla porque falta el usuario.", "Sesión requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AltaPlantilla formAlta = new AltaPlantilla(_usuarioId);
            if (formAlta.ShowDialog() == DialogResult.OK)
            {
                CargarPlantillas();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cbPlantillas.SelectedValue == null)
            {
                MessageBox.Show("Por favor selecciona una plantilla", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idPlantilla = Convert.ToInt32(cbPlantillas.SelectedValue);
            var plantillaSeleccionada = _plantillas.FirstOrDefault(p => p.id_plantilla == idPlantilla);
            if (plantillaSeleccionada == null)
            {
                MessageBox.Show("No se encontró la plantilla seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // pasar usuarioId a EditarPlantilla para control de permisos
            EditarPlantilla formEditar = new EditarPlantilla(plantillaSeleccionada.id_plantilla, plantillaSeleccionada.id_equipo, _usuarioId);
            formEditar.ShowDialog();
        }
    }
}
