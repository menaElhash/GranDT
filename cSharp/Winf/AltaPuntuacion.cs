using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Core;
using Dapper;

namespace el_dt_by_menardi_y_tello
{
    public class AltaPuntuacion : Form
    {
        private ComboBox cbJugador;
        private NumericUpDown nudFecha;
        private NumericUpDown nudNota;
        private Button btnGuardar;
        private Button btnCancelar;

        public AltaPuntuacion()
        {
            Text = "Alta Puntuación";
            Width = 420;
            Height = 220;
            StartPosition = FormStartPosition.CenterParent;

            var lblJugador = new Label { Text = "Jugador:", Location = new Point(12, 14), AutoSize = true };
            Controls.Add(lblJugador);

            cbJugador = new ComboBox { Location = new Point(12, 36), Width = 360, DropDownStyle = ComboBoxStyle.DropDownList };
            Controls.Add(cbJugador);

            var lblFecha = new Label { Text = "Fecha (número):", Location = new Point(12, 70), AutoSize = true };
            Controls.Add(lblFecha);

            nudFecha = new NumericUpDown { Location = new Point(12, 92), Width = 100, Minimum = 1, Maximum = 50, Value = 1 };
            Controls.Add(nudFecha);

            var lblNota = new Label { Text = "Nota (1-10):", Location = new Point(140, 70), AutoSize = true };
            Controls.Add(lblNota);

            nudNota = new NumericUpDown { Location = new Point(140, 92), Width = 100, Minimum = 1, Maximum = 10, DecimalPlaces = 1, Increment = 0.1M, Value = 6 };
            Controls.Add(nudNota);

            btnGuardar = new Button { Text = "Guardar", Location = new Point(200, 140), Width = 80 };
            btnGuardar.Click += BtnGuardar_Click;
            Controls.Add(btnGuardar);

            btnCancelar = new Button { Text = "Cancelar", Location = new Point(290, 140), Width = 80 };
            btnCancelar.Click += (s, e) => this.Close();
            Controls.Add(btnCancelar);

            Load += AltaPuntuacion_Load;
        }

        private void AltaPuntuacion_Load(object? sender, EventArgs e)
        {
            try
            {
                using (IDbConnection conexion = DbConnection.GetConnection())
                {
                    var jugadores = conexion.Query<Jugador>("SELECT id_jugador, nombre, apellido FROM Gran_DT.Jugador").ToList();
                    var lista = jugadores.Select(j => new { Id = j.id_jugador, Nombre = $"{j.nombre} {j.apellido}" }).ToList();

                    cbJugador.DisplayMember = "Nombre";
                    cbJugador.ValueMember = "Id";
                    cbJugador.DataSource = lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar jugadores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (cbJugador.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un jugador.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idJugador = Convert.ToInt32(cbJugador.SelectedValue);
            int fechaNumero = (int)nudFecha.Value;
            decimal nota = nudNota.Value;

            var puntuacion = new Puntuacion { fecha_numero = fechaNumero, nota = nota, id_jugador = idJugador };
            try
            {
                using (IDbConnection conexion = DbConnection.GetConnection())
                {
                    var repo = new RepoJugador(conexion);
                    int idP = repo.AltaPuntuacion(puntuacion, idJugador);
                    MessageBox.Show($"Puntuación creada con ID {idP}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear puntuación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
