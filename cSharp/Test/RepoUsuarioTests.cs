using Core.Repos;
using Dapper;
using Core; // Para el modelo Usuario

namespace Test;

public class RepoUsuarioTests : TestRepo
{
    readonly IRepoUsuario repoUsuario;
    private static int _userCounter = 100; // Contador estático para emails únicos
    private const int RolUsuarioId = 1; 
    private const int RolAdminId = 2; 

    public RepoUsuarioTests() : base()
        => repoUsuario = new RepoUsuario(_conexion);

    // Método auxiliar para crear un usuario y obtener su ID
    private int CrearUsuarioDePrueba(string nombre, string password, int idRol)
    {
        var usuario = new Usuario
        {
            nombre = nombre, 
            apellido = "Test", 
            email = $"user_{_userCounter++}@test.com", 
            fecha_nacimiento = new DateTime(2000, 1, 1), 
            password = password, // Asume que es el hash SHA-256 (64 chars)
            id_rol = idRol 
        };
        return repoUsuario.AltaUsuario(usuario);
    }

    [Theory]
    [InlineData("Juan", "pass123", RolUsuarioId)] 
    [InlineData("Maria", "pass456", RolAdminId)] 
    public void AltaUsuario_DevuelveIdValido(string nombre, string password, int idRol)
    {
        var id = CrearUsuarioDePrueba(nombre, password, idRol);
        Assert.True(id > 0);
    }

    [Fact]
    public void LoginUsuarioCORRECTO_DebeRetornarUsuario()
    {
        // 1. Crear un usuario de prueba
        var emailTest = $"login_{_userCounter++}@test.com";
        var passwordHash = "A1B2C3D4E5F67890A1B2C3D4E5F67890A1B2C3D4E5F67890A1B2C3D4E5F67890"; // 64 chars
        
        var usuarioTest = new Usuario
        {
            nombre = "Login",
            apellido = "User",
            email = emailTest,
            fecha_nacimiento = new DateTime(2000, 1, 1),
            password = passwordHash,
            id_rol = RolUsuarioId
        };
        repoUsuario.AltaUsuario(usuarioTest);

        // 2. Intentar loguear
        Usuario? resultado = repoUsuario.LoginUsuario(emailTest, passwordHash);

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal(emailTest, resultado.email);
    }

    [Fact]
    public void LoginUsuarioINCORRECTO_DebeRetornarNull()
    {
        var email = $"no_existe_{_userCounter++}@outlook.com";
        var contrasena = "ContrasenaMala";

        Usuario? resultado = repoUsuario.LoginUsuario(email, contrasena);

        Assert.Null(resultado);
    }
}