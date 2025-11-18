using System;
using System.Windows.Forms;
using Dapper;
using Core;
using System.Data;

namespace el_dt_by_menardi_y_tello
{
    public partial class nuevo_usuario : Form
    {
        public nuevo_usuario()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Podés usar esto si más adelante querés agregar otra función
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Lo mismo que arriba
        }

        private void nuevo_usuario_Load(object sender, EventArgs e)
        {
            // Si querés algo al cargar el form, lo ponés acá
        }

        // --- BOTÓN SIGUIENTE ---
        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = NombreBox.Text.Trim();
            string email = EmailBox.Text.Trim();
            string contraseña = PasswordBox.Text.Trim();
            string apellido = ApellidoBox.Text.Trim();
            string fechaNacimientoStr = NacimientoBox.Text.Trim();

            // Validaciones
            if (string.IsNullOrWhiteSpace(nombre) || 
                string.IsNullOrWhiteSpace(email) || 
                string.IsNullOrWhiteSpace(contraseña) ||
                string.IsNullOrWhiteSpace(fechaNacimientoStr))
            {
                MessageBox.Show(
                    "Por favor completa todos los campos.",
                    "Campos Incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Validar formato de fecha
            if (!DateTime.TryParse(fechaNacimientoStr, out DateTime fechaNacimiento))
            {
                MessageBox.Show(
                    "Formato de fecha incorrecto. Usa YYYY-MM-DD.",
                    "Error de Fecha",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            try
            {
                // Crear objeto Usuario
                Usuario nuevoUsuario = new Usuario
                {
                    nombre = nombre,
                    apellido = apellido,
                    email = email,
                    fecha_nacimiento = fechaNacimiento,
                    password = contraseña,
                    id_rol = 2 // Rol por defecto para usuario nuevo (ajusta según tu BD)
                };

                // Usar RepoUsuario para registrar
                using (IDbConnection conexion = DbConnection.GetConnection())
                {
                    var repoUsuario = new Dapper.RepoUsuario(conexion);
                    int idUsuarioCreado = repoUsuario.AltaUsuario(nuevoUsuario);

                    if (idUsuarioCreado > 0)
                    {
                        // Registro exitoso
                        MessageBox.Show(
                            "¡Usuario registrado exitosamente!",
                            "Éxito",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        // Volver al menú de login
                        Menú menú = new Menú();
                        menú.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Error al registrar el usuario. Intenta nuevamente.",
                            "Error de Registro",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al registrar: {ex.Message}",
                    "Error de Conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // --- BOTÓN volver ---
        private void label1_Click(object sender, EventArgs e)
        {
            Menú menú = new Menú();
            menú.Show();
            this.Hide();
        }
    }
}
