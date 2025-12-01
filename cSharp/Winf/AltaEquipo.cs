using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Core;
using Dapper;

namespace el_dt_by_menardi_y_tello
{
    public class AltaEquipo : Form
    {
        private TextBox txtNombre;
        private Button btnGuardar;
        private Button btnCancelar;

        public AltaEquipo()
        {
            Text = "Alta Equipo";
            Width = 400;
            Height = 180;
            StartPosition = FormStartPosition.CenterParent;

            var lbl = new Label { Text = "Nombre del equipo:", Location = new Point(12, 18), AutoSize = true };
            Controls.Add(lbl);

            txtNombre = new TextBox { Location = new Point(12, 40), Width = 350 };
            Controls.Add(txtNombre);

            btnGuardar = new Button { Text = "Guardar", Location = new Point(200, 80), Width = 80 };
            btnGuardar.Click += BtnGuardar_Click;
            Controls.Add(btnGuardar);

            btnCancelar = new Button { Text = "Cancelar", Location = new Point(290, 80), Width = 80 };
            btnCancelar.Click += (s, e) => this.Close();
            Controls.Add(btnCancelar);
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            var nombre = txtNombre.Text?.Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Ingresa un nombre de equipo válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (IDbConnection conexion = DbConnection.GetConnection())
                {
                    var repo = new RepoJugador(conexion);
                    uint nuevoId = repo.AltaEquipo(nombre);
                    MessageBox.Show($"Equipo creado con ID {nuevoId}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear equipo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
