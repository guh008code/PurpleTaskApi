using PurpleTask.Models;

namespace PurpleTask.Repositorios.Interfaces
{
    public interface ILocalRepositorio
    {
        Task<ResponseModel<Loc>> BuscarPorId(int? id, int? idEmpresa, int? idInstalacao);

        Task<ResponseModel<List<Loc>>> ListarTodos(int? idEmpresa, int? idInstalacao);
    }
}
