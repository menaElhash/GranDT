using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Core;
using Core.Repos;
using Dapper;

namespace el_dt_by_menardi_y_tello
{
    public partial class EditarPlantilla : Form
    {
        private readonly IRepoPlantilla _repoPlantilla;
        private readonly IRepoJugador _repoJugador;
        private readonly IDbConnection _conexion;
        private int _plantillaId;
        private int _idEquipoSeleccionado;
        private Plantilla _plantillaActual;
        private int _usuarioId;

        public EditarPlantilla(int plantillaId, int idEquipo, int usuarioId)
        {
            InitializeComponent();
            _plantillaId = plantillaId;
            _idEquipoSeleccionado = idEquipo;
            _usuarioId = usuarioId;
            _conexion = DbConnection.GetConnection();
            _repoPlantilla = new RepoPlantilla(_conexion);
            _repoJugador = new RepoJugador(_conexion);
        }

        private void EditarPlantilla_Load(object sender, EventArgs e)
        {
            CargarEquipos();
            CargarPlantilla();
            CargarJugadoresEnPlantilla();

            // Control de permisos: mostrar boton guardar solo si es admin
            try
            {
                var usuario = _conexion.QueryFirstOrDefault<Usuario>("SELECT * FROM Gran_DT.Usuario WHERE id_usuario = @id", new { id = _usuarioId });
                bool esAdmin = usuario != null && usuario.id_rol == 1;
                btnGuardar.Visible = esAdmin;
                // si no es admin, no permitir cambiar equipo o presupuesto
                cbEquipo.Enabled = esAdmin;
                tbPresupuesto.ReadOnly = !esAdmin;
            }
            catch
            {
                // Si no se puede determinar el rol, esconder guardar por seguridad
                btnGuardar.Visible = false;
                cbEquipo.Enabled = false;
                tbPresupuesto.ReadOnly = true;
            }

            // Mostrar presupuesto restante al cargar
            ActualizarRestanteUI();
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
                MessageBox.Show($"Error al cargar equipos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPlantilla()
        {
            try
            {
                // Traer plantilla directamente con Dapper
                var query = "SELECT * FROM Gran_DT.Plantilla WHERE id_plantilla = @id";
                _plantillaActual = _conexion.QuerySingleOrDefault<Plantilla>(query, new { id = _plantillaId });

                if (_plantillaActual != null)
                {
                    tbPresupuesto.Text = _plantillaActual.presupuesto_max.ToString();
                    cbEquipo.SelectedValue = _idEquipoSeleccionado;
                    lblPlantillaId.Text = $": {_plantillaActual.id_plantilla}";
                    lblFechaCreacion.Text = $": {_plantillaActual.fecha_creacion:dd/MM/yyyy}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar plantilla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarJugadoresEnPlantilla()
        {
            try
            {
                // Traer jugadores de la plantilla
                var query = @"SELECT pj.id_plantilla, pj.id_jugador, pj.es_titular,
                                    j.nombre, j.apellido, j.cotizacion
                             FROM Gran_DT.PlantillaJugador pj
                             INNER JOIN Gran_DT.Jugador j ON pj.id_jugador = j.id_jugador
                             WHERE pj.id_plantilla = @id";
                var jugadores = _conexion.Query(query, new { id = _plantillaId }).ToList();
                dgvJugadores.DataSource = jugadores;

                ActualizarRestanteUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar jugadores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarRestanteUI()
        {
            try
            {
                if (_plantillaActual == null) return;
                var totalSum = _conexion.QuerySingleOrDefault<decimal?>(@"SELECT COALESCE(SUM(j.cotizacion),0) FROM Gran_DT.PlantillaJugador pj
                                                                           INNER JOIN Gran_DT.Jugador j ON pj.id_jugador = j.id_jugador
                                                                           WHERE pj.id_plantilla = @id", new { id = _plantillaId }) ?? 0m;
                var restante = _plantillaActual.presupuesto_max - totalSum;
                lblRestante.Text = $"Restante: ${restante:N0}";
            }
            catch
            {
                lblRestante.Text = "Restante: -";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbEquipo.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar un equipo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(tbPresupuesto.Text, out decimal presupuesto) || presupuesto <= 0)
            {
                MessageBox.Show("Ingresa un presupuesto válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Actualizar directamente con Dapper
                var query = @"UPDATE Gran_DT.Plantilla 
                            SET presupuesto_max = @presupuesto, id_equipo = @id_equipo 
                            WHERE id_plantilla = @id_plantilla";
                _conexion.Execute(query, new
                {
                    presupuesto = presupuesto,
                    id_equipo = (int)cbEquipo.SelectedValue,
                    id_plantilla = _plantillaId
                });

                MessageBox.Show("Plantilla actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // refrescar plantilla
                _plantillaActual = _conexion.QuerySingleOrDefault<Plantilla>("SELECT * FROM Gran_DT.Plantilla WHERE id_plantilla = @id", new { id = _plantillaId });
                ActualizarRestanteUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar cambios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarJugador_Click(object sender, EventArgs e)
        {
            if (_plantillaActual == null || _plantillaActual.id_equipo <= 0)
            {
                MessageBox.Show("No se puede agregar jugadores: la plantilla no tiene un equipo asignado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Abrir formulario de selección de jugadores pasando el ID de la plantilla, el equipo y el presupuesto actual
            seleccion selForm = new seleccion(_plantillaId, _plantillaActual.id_equipo, _plantillaActual.presupuesto_max);
            if (selForm.ShowDialog() == DialogResult.OK)
            {
                // Recargar jugadores después de agregar uno
                CargarJugadoresEnPlantilla();

                // Calcular suma de cotizaciones y mostrar dinero restante
                try
                {
                    var totalSum = _conexion.QuerySingleOrDefault<decimal?>(@"SELECT COALESCE(SUM(j.cotizacion),0) FROM Gran_DT.PlantillaJugador pj
                                                                           INNER JOIN Gran_DT.Jugador j ON pj.id_jugador = j.id_jugador
                                                                           WHERE pj.id_plantilla = @id", new { id = _plantillaId }) ?? 0m;
                    var restante = _plantillaActual.presupuesto_max - totalSum;
                    MessageBox.Show($"Dinero restante: ${restante:N0}", "Presupuesto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarRestanteUI();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al calcular presupuesto restante: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblPlantillaId_Click(object sender, EventArgs e)
        {

        }
    }
}
