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
        private const decimal PRESUPUESTO_FIJO = 65000000; // presupuesto fijado a 65,000,000

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

            // Verificar rol del usuario: sólo admin (id_rol == 1) puede crear plantillas
            try
            {
                var usuario = _conexion.QueryFirstOrDefault<Usuario>("SELECT * FROM Gran_DT.Usuario WHERE id_usuario = @id", new { id = _usuarioId });
                bool esAdmin = usuario != null && usuario.id_rol == 1;
                if (!esAdmin)
                {
                    MessageBox.Show("Solo los administradores pueden crear plantillas.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbEquipo.Enabled = false;
                    btnCrear.Enabled = false;
                }
            }
            catch
            {
                // En caso de error al comprobar rol, deshabilitar creación por seguridad
                cbEquipo.Enabled = false;
                btnCrear.Enabled = false;
            }
        }

        private void CargarEquipos()
        {
            try
            {
                var equipos = _repoJugador.TraerEquipo().ToList();
                // Set Display/Value before DataSource to avoid transient binding issues
                cbEquipo.DisplayMember = "nombre";
                cbEquipo.ValueMember = "id_equipo";
                cbEquipo.DataSource = new BindingSource(equipos, null);
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
                // Verificar nuevamente rol del usuario por seguridad
                var usuario = _conexion.QueryFirstOrDefault<Usuario>("SELECT * FROM Gran_DT.Usuario WHERE id_usuario = @id", new { id = _usuarioId });
                if (usuario == null || usuario.id_rol != 1)
                {
                    MessageBox.Show("Acción no permitida: requiere permisos de administrador.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
