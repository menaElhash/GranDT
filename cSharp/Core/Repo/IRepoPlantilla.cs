namespace Core.Repos;

public interface IRepoPlantilla
{
    int AltaPlantilla(Plantilla plantilla);
    IEnumerable<Plantilla> TraerPlantillasPorIdUsuario(int idUsuario);

    void AltaJugadorEnPlantilla(int idJugador, int idPlantilla, bool esTitular); 
    void ActualizarEstadoJugador(int idJugador, int idPlantilla, bool esTitular);
}