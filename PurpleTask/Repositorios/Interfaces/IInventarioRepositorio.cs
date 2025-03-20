using PurpleTask.Models;

namespace PurpleTask.Repositorios.Interfaces
{
    public interface IInventarioRepositorio
    {
        Task<ResponseModel<List<AvlItm>>> ListarTodos();

        Task<ResponseModel<AvlItm>> BuscarPorId(int id);

        Task<ResponseModel<AvlItm>> Adicionar(AvlItm inventario);
        Task<ResponseModel<List<AvlItm>>> Atualizar(AvlItm inventario);

        Task<ResponseModel<List<AvlItm>>> Apagar(int id);
    }
}
