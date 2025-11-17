using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;
using Dapper;
using Core;

namespace el_dt_by_menardi_y_tello
{
    public partial class Menú : Form
    {
        private bool nuevoUsuarioCreado = false; // bandera para saber si entró por "Nuevo Usuario"
        private Usuario? usuarioActual = null; // Almacena el usuario logueado

        public Menú()
        {
            InitializeComponent();
        }

        private void Menú_Load(object sender, EventArgs e)
        {
            // Al cargar el form podés dejar esto vacío o agregar música si querés
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Abre el formulario nuevo_usuario y oculta este
            nuevo_usuario nuevoForm = new nuevo_usuario();
            nuevoForm.Show();
            this.Hide();

            // Marca que se creó un usuario nuevo (para saltar validaciones)
            nuevoUsuarioCreado = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string contraseña = textBox4.Text.Trim();

            // Validaciones
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(contraseña))
            {
                error errorForm = new error();
                errorForm.ShowDialog();
                return;
            }

            try
            {
                // Conexión a BD y login
                string connectionString = "Server=localhost;Database=futboldtdb;Uid=root;Pwd=;";
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var repoUsuario = new RepoUsuario(connection);
                    
                    // Hashear contraseña con SHA256
                    string passwordHash = HashearSHA256(contraseña);
                    usuarioActual = repoUsuario.LoginUsuario(email, passwordHash);

                    if (usuarioActual != null)
                    {
                        // Login exitoso → entra al menú principal
                        Menu_pricipal menuForm = new Menu_pricipal();
                        menuForm.UsuarioActual = usuarioActual; // Pasar usuario a siguiente form
                        menuForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Credenciales inválidas
                        error errorForm = new error();
                        errorForm.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string HashearSHA256(string texto)
        {
            using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(texto));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        private void label3_Click_original(object sender, EventArgs e)
        {
            // Verifica si los campos están completos o si viene de nuevo usuario
            if (nuevoUsuarioCreado ||
                (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox4.Text)))
            {
                // Si todo está correcto → entra al menú principal
                Menu_pricipal menuForm = new Menu_pricipal();
                menuForm.Show();
                this.Hide();
            }
            else
            {
                // Si falta algo → abre el form de error
                error error = new error();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Acá podrías poner validaciones en tiempo real si querés más adelante
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Igual que arriba, si querés agregar condiciones mientras escribe
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
