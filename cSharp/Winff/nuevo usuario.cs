using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;
using Core;

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
            string usuario = textBox1.Text.Trim();
            string email = textBox4.Text.Trim();
            string contraseña = textBox2.Text.Trim();
            string fechaNacimiento = maskedTextBox1.Text.Trim();

            // Validaciones (solo campos vacíos)
            bool camposIncompletos = string.IsNullOrWhiteSpace(usuario) ||
                                     string.IsNullOrWhiteSpace(email) ||
                                     string.IsNullOrWhiteSpace(contraseña) ||
                                     string.IsNullOrWhiteSpace(fechaNacimiento);

            if (camposIncompletos)
            {
                // Si hay error, abre el form de error
                error errorForm = new error();
                errorForm.ShowDialog();
                return;
            }

            try
            {
                // Validar formato de fecha (dd/mm/yyyy)
                if (!DateTime.TryParseExact(fechaNacimiento, "dd/MM/yyyy", 
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime fecha))
                {
                    error errorForm = new error();
                    errorForm.ShowDialog();
                    return;
                }

                // Conectar a BD y registrar usuario
                string connectionString = "Server=localhost;Database=futboldtdb;Uid=root;Pwd=;";
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var repoUsuario = new RepoUsuario(connection);

                    // Crear usuario con rol por defecto (1 = usuario común)
                    var nuevoUsuario = new Usuario
                    {
                        nombre = usuario,
                        email = email,
                        password = HashearSHA256(contraseña),
                        fecha_nacimiento = fecha,
                        id_rol = 1 // Rol por defecto
                    };

                    int idUsuario = repoUsuario.AltaUsuario(nuevoUsuario);

                    if (idUsuario > 0)
                    {
                        // Registro exitoso → pasa al menú principal
                        Menu_pricipal menuForm = new Menu_pricipal();
                        menuForm.UsuarioActual = nuevoUsuario;
                        menuForm.UsuarioActual.id_usuario = idUsuario;
                        menuForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        error errorForm = new error();
                        errorForm.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- BOTÓN volver ---
        private void label1_Click(object sender, EventArgs e)
        {
            Menú menú = new Menú();
            menú.Show();
            this.Hide();
        }

        private string HashearSHA256(string texto)
        {
            using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(texto));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
