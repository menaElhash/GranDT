using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Core;
using Dapper;

namespace el_dt_by_menardi_y_tello
{
    public partial class CrarJugador : Form
    {
        private IDbConnection _conexion;
        private RepoJugador _repoJugador;

        public CrarJugador()
        {
            InitializeComponent();
            _conexion = DbConnection.GetConnection();
            _repoJugador = new RepoJugador(_conexion);

            // wire events
            this.Load += CrarJugador_Load;
            button6.Click += button6_Click; // guardar
        }

        private void CrarJugador_Load(object? sender, EventArgs e)
        {
            try
            {
                CargarEquipos();
                ConfigurarTipos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarEquipos()
        {
            try
            {
                var equipos = _repoJugador.TraerEquipo().ToList();
                comboBoxEquipo.DisplayMember = "nombre";
                comboBoxEquipo.ValueMember = "id_equipo";
                comboBoxEquipo.DataSource = equipos;
                comboBoxEquipo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar equipos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarTipos()
        {
            try
            {
                var tipos = new List<object>
                {
                    new { Id = 1, Nombre = "Arquero" },
                    new { Id = 2, Nombre = "Defensa" },
                    new { Id = 3, Nombre = "Volante" },
                    new { Id = 4, Nombre = "Delantero" }
                };

                comboBoxTipoJugador.DisplayMember = "Nombre";
                comboBoxTipoJugador.ValueMember = "Id";
                comboBoxTipoJugador.DataSource = tipos;
                comboBoxTipoJugador.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar tipos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Botonatras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación básica
                var nombre = textBox1.Text?.Trim();
                var apellido = textBox2.Text?.Trim();
                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
                {
                    MessageBox.Show("Nombre y apellido son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var jugador = new Jugador
                {
                    nombre = nombre,
                    apellido = apellido,
                    apodo = string.IsNullOrWhiteSpace(textBox3.Text) ? null : textBox3.Text.Trim(),
                    fecha_nacimiento = dateTimePicker1.Value,
                    cotizacion = decimal.TryParse(textBox4.Text.Trim(), out decimal cot) ? cot : 0
                };

                // id_tipo
                if (comboBoxTipoJugador.SelectedValue != null)
                {
                    jugador.id_tipo = Convert.ToInt32(comboBoxTipoJugador.SelectedValue);
                }

                // id_equipo
                if (comboBoxEquipo.SelectedValue != null)
                {
                    jugador.id_equipo = Convert.ToInt32(comboBoxEquipo.SelectedValue);
                }

                var nuevoId = _repoJugador.AltaJugador(jugador);
                MessageBox.Show($"Jugador creado con ID {nuevoId}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // limpiar
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                dateTimePicker1.Value = DateTime.Now;
                if (comboBoxTipoJugador.Items.Count > 0) comboBoxTipoJugador.SelectedIndex = 0;
                comboBoxEquipo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear jugador: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
