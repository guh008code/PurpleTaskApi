using PurpleTask.Models;

namespace PurpleTask.Repositorios.Interfaces
{
    public interface IInventarioRepositorio
    {
        Task<ResponseModel<List<AvlItm>>> ListarTodos(int? idEmpresa, int? idInstalacao);

        Task<ResponseModel<AvlItm>> BuscarPorId(int? id, int? idEmpresa, int? idInstalacao);

        Task<ResponseModel<List<AvlItm>>> BuscarPlaqueta(int? AvlItmPlq, int? idEmpresa, int? idInstalacao);

        Task<ResponseModel<AvlItm>> Adicionar(AvlItm inventario);
        Task<ResponseModel<List<AvlItm>>> Atualizar(AvlItm inventario);

        Task<ResponseModel<List<AvlItm>>> Apagar(int? idInventario);
    }
}
