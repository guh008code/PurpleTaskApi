using PurpleTask.Models;

namespace PurpleTask.Repositorios.Interfaces
{
    public interface IItemsRepositorio
    {
        Task<ResponseModel<List<Itm>>> ListarTodos(int? idInstalacao);
    }
}
