using PurpleTask.Models;

namespace PurpleTask.Repositorios.Interfaces
{
    public interface ISetorRepositorio
    {
        Task<ResponseModel<Set>> BuscarPorId(int id, int? idEmpresa, int? idLocal, int? idCentroDeCusto, int idInstalacao);

    }
}
