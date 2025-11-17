namespace Core.Repos;

public interface IRepoUsuario
{
    int AltaUsuario(Usuario usuario);
    Usuario? LoginUsuario(string email, string contrasena);
}