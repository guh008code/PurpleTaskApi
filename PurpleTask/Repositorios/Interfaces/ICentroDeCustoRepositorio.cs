using PurpleTask.Models;

namespace PurpleTask.Repositorios.Interfaces
{
    public interface ICentroDeCustoRepositorio
    {
        Task<ResponseModel<Cec>> BuscarPorId(int id, int idEmpresa, int idInstalacao);

        Task<ResponseModel<List<Cec>>> ListarTodos(int? idEmpresa, int? idLocal, int idInstalacao);

    }
}
