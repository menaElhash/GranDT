using System.Data;
using Core;
using Core.Repos;
using Dapper;

namespace Dapper
{
    public class RepoUsuario : Repo, IRepoUsuario
    {
        public RepoUsuario(IDbConnection connection) : base(connection) { }

        private static readonly string spAltaUsuario = "altaUsuario";
        private static readonly string spLoginUsuario = "loginUsuario";

        public int AltaUsuario(Usuario usuario)
        {
            var p = new DynamicParameters();

            // Parámetros de entrada (IN)
            p.Add("UnNombre", usuario.nombre);
            p.Add("UnApellido", usuario.apellido);
            p.Add("UnEmail", usuario.email);
            p.Add("UnFechaNacimiento", usuario.fecha_nacimiento);
            // La contraseña DEBE ser un hash SHA256 (64 chars) antes de llegar aquí
            p.Add("UnContrasena", usuario.password);
            p.Add("UnidRol", usuario.id_rol);

            // Parámetro de salida (OUT)
            p.Add("AIidUsuario", dbType: DbType.Int32, direction: ParameterDirection.Output);

            _conexion.Execute(spAltaUsuario, p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("AIidUsuario");
        }

        public Usuario? LoginUsuario(string email, string contrasena)
        {
            // NOTA: Se asume que la LÓGICA de hashing (SHA256) se realiza en 
            // el Stored Procedure de MySQL, o la capa de Servicio/Negocio.
            // Aquí enviamos el email y la contraseña hasheada (si se hace fuera) o en texto plano (si se hace dentro).

            var p = new DynamicParameters();
            p.Add("UnEmail", email);
            p.Add("UnContrasena", contrasena); // Debe ser el hash SHA256 (64 caracteres)

            // Dapper mapea los resultados a la clase Usuario
            return _conexion.QueryFirstOrDefault<Usuario>(
                spLoginUsuario,
                p,
                commandType: CommandType.StoredProcedure
            );
        }

    }
}