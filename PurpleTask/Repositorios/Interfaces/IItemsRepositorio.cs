using PurpleTask.Models;

namespace PurpleTask.Repositorios.Interfaces
{
    public interface IItemsRepositorio
    {
        Task<ResponseModel<List<Itm>>> ListarTodos(int? idInstalacao);

        Task<ResponseModel<List<Itm>>> ListarPorDescricao(Itm item);

        Task<ResponseModel<Itm>> Adicionar(Itm item);
    }
}
