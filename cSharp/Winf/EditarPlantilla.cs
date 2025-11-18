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

        public EditarPlantilla(int plantillaId, int idEquipo)
        {
            InitializeComponent();
            _plantillaId = plantillaId;
            _idEquipoSeleccionado = idEquipo;
            _conexion = DbConnection.GetConnection();
            _repoPlantilla = new RepoPlantilla(_conexion);
            _repoJugador = new RepoJugador(_conexion);
        }

        private void EditarPlantilla_Load(object sender, EventArgs e)
        {
            CargarEquipos();
            CargarPlantilla();
            CargarJugadoresEnPlantilla();
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
                    lblPlantillaId.Text = $"ID Plantilla: {_plantillaActual.id_plantilla}";
                    lblFechaCreacion.Text = $"Creada: {_plantillaActual.fecha_creacion:dd/MM/yyyy}";
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar jugadores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Abrir formulario de selección de jugadores pasando el ID de la plantilla y el equipo
            seleccion selForm = new seleccion(_plantillaId, _plantillaActual.id_equipo);
            if (selForm.ShowDialog() == DialogResult.OK)
            {
                // Recargar jugadores después de agregar uno
                CargarJugadoresEnPlantilla();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
