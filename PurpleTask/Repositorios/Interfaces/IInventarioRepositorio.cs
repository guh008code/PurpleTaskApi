using PurpleTask.Models;

namespace PurpleTask.Repositorios.Interfaces
{
    public interface IInventarioRepositorio
    {
        Task<ResponseModel<List<AvlItm>>> ListarTodos(int idInstalacao);

        Task<ResponseModel<AvlItm>> BuscarPorId(int id, int idInstalacao);

        Task<ResponseModel<AvlItm>> Adicionar(AvlItm inventario);
        Task<ResponseModel<List<AvlItm>>> Atualizar(AvlItm inventario);

        Task<ResponseModel<List<AvlItm>>> Apagar(int id);
    }
}
