using System.Data;
using Core;
using Core.Repos;
using Dapper;

namespace Dapper
{
    public class RepoPlantilla : Repo, IRepoPlantilla
    {
        public RepoPlantilla(IDbConnection connection) : base(connection) { }
        private static readonly string spAltaPlantilla = "altaPlantilla";
        private static readonly string spTraerPlantillasPorIdUsuario = "PlantillasPorIdUsuario";
        private static readonly string spAltaPlantillaJugador = "altaPlantillaJugador";
        private static readonly string spActualizarPlantillaJugador = "actualizarPlantillaJugador";

        // --- Operaciones de Plantilla ---

        public int AltaPlantilla(Plantilla plantilla)
        {
            var p = new DynamicParameters();

            // Parámetros de entrada (IN)
            p.Add("UnPresupuesto", plantilla.presupuesto);
            p.Add("UnidUsuario", plantilla.id_usuario);
            p.Add("UnFechaCreacion", plantilla.fecha_creacion);

            // Parámetro de salida (OUT)
            p.Add("AIidPlantilla", dbType: DbType.Int32, direction: ParameterDirection.Output);

            _conexion.Execute(spAltaPlantilla, p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("AIidPlantilla");
        }

        public IEnumerable<Plantilla> TraerPlantillasPorIdUsuario(int idUsuario)
        {
            var p = new DynamicParameters();
            p.Add("UnidUsuario", idUsuario);

            return _conexion.Query<Plantilla>(
                spTraerPlantillasPorIdUsuario,
                p,
                commandType: CommandType.StoredProcedure
            ).ToList();
        }

        // --- Operaciones de PlantillaJugador ---

        public void AltaJugadorEnPlantilla(int idJugador, int idPlantilla, bool esTitular)
        {
            var p = new DynamicParameters();
            p.Add("UnidJugador", idJugador);
            p.Add("UnidPlantilla", idPlantilla);
            p.Add("UnesTitular", esTitular); // Dapper mapea bool a TINYINT (0 o 1)

            _conexion.Execute(spAltaPlantillaJugador, p, commandType: CommandType.StoredProcedure);
        }

        public void ActualizarEstadoJugador(int idJugador, int idPlantilla, bool esTitular)
        {
            var p = new DynamicParameters();
            p.Add("UnidJugador", idJugador);
            p.Add("UnidPlantilla", idPlantilla);
            p.Add("UnesTitular", esTitular);

            _conexion.Execute(spActualizarPlantillaJugador, p, commandType: CommandType.StoredProcedure);
        }
    }
}