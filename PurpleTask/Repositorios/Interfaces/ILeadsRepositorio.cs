using PurpleTask.Models;

namespace PurpleTask.Repositorios.Interfaces
{
    public interface ILeadsRepositorio
    {
        Task<ResponseModel<List<Led>>> ListarPorFiltros(Led lead);

        Task<ResponseModel<List<Led>>> ListarTodos();

        Task<ResponseModel<Led>> Adicionar(Led lead);
    }
}
