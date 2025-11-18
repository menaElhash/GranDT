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
using Dapper;
using Core;

namespace el_dt_by_menardi_y_tello
{
    public partial class Menú : Form
    {
        private bool nuevoUsuarioCreado = false; // bandera para saber si entró por "Nuevo Usuario"

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
            string email = UsuarioBox.Text.Trim();
            string contraseña = PasswordBox.Text.Trim();

            // Validación de campos vacíos
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(contraseña))
            {
                error errorForm = new error();
                errorForm.ShowDialog();
                return;
            }

            try
            {
                // Usar RepoUsuario para hacer login
                using (IDbConnection conexion = DbConnection.GetConnection())
                {
                    var repoUsuario = new Dapper.RepoUsuario(conexion);
                    Usuario? usuarioAutenticado = repoUsuario.LoginUsuario(email, contraseña);

                    if (usuarioAutenticado != null)
                    {
                        // Login exitoso
                        Menu_pricipal menuForm = new Menu_pricipal(usuarioAutenticado.id_usuario);
                        menuForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Usuario no encontrado o contraseña incorrecta
                        MessageBox.Show(
                            "Email o contraseña incorrectos. Intenta nuevamente.",
                            "Error de Login",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        PasswordBox.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al intentar loguear: {ex.Message}",
                    "Error de Conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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
