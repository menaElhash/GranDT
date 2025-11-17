namespace Core.Repos;

public interface IRepoPlantilla
{
    int AltaPlantilla(Plantilla plantilla); // Usa Plantilla en singular
    IEnumerable<Plantilla> TraerPlantillasPorIdUsuario(int idUsuario);

    // Usa id_jugador y es_titular coherente con los modelos y SPs
    void AltaJugadorEnPlantilla(int idJugador, int idPlantilla, bool esTitular); 
    void ActualizarEstadoJugador(int idJugador, int idPlantilla, bool esTitular);

    // Nota: El SP TraerPlantillasPorEmail no se implementó en MySQL, 
    // pero se incluye en la interfaz si se necesita en el futuro.
    // IEnumerable<Plantilla> TraerPlantillasPorEmail(string email); 
}