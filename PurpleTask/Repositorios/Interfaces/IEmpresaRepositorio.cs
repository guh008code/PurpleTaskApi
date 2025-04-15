using PurpleTask.Models;

namespace PurpleTask.Repositorios.Interfaces
{
    public interface IEmpresaRepositorio
    {
        Task<ResponseModel<Ep>> BuscarPorId(int idEmpresa, int idInstalacao);

    }
}
