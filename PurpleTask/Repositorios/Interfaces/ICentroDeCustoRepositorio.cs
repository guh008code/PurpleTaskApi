using PurpleTask.Models;

namespace PurpleTask.Repositorios.Interfaces
{
    public interface ICentroDeCustoRepositorio
    {
        Task<ResponseModel<Cec>> BuscarPorId(int id, int? idEmpresa, int? idLocal, int idInstalacao);

    }
}
