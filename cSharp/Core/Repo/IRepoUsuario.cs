namespace Core;

public interface IRepoUsuario
{
    public void AltaUsuario(Usuario usuario);
    public Usuario? Login (string email, string pass);
}
