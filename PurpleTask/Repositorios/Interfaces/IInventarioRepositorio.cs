﻿using PurpleTask.Models;

namespace PurpleTask.Repositorios.Interfaces
{
    public interface IInventarioRepositorio
    {
        Task<ResponseModel<List<AvlItm>>> ListarTodos(int? idEmpresa, int? idInstalacao);

        Task<ResponseModel<List<AvlItm>>> ListarPorLocal(int? idEmpresa, int? idLocal, int? idInstalacao);

        Task<ResponseModel<List<AvlItm>>> ListarPorCentroDeCusto(int? idEmpresa, int? idLocal, int? idCentroDeCusto, int? idInstalacao);

        Task<ResponseModel<AvlItm>> BuscarPorId(int? id, int? idEmpresa, int? idInstalacao);

        Task<ResponseModel<List<AvlItm>>> BuscarPlaqueta(int? AvlItmPlq, int? idEmpresa, int? idInstalacao);

        Task<ResponseModel<List<AvlItm>>> BuscarPlaquetaPorLocal(int? AvlItmPlq, int? idEmpresa, int? idLocal, int? idInstalacao);
        Task<ResponseModel<List<AvlItm>>> BuscarPlaquetaPorCentroDeCusto(int? AvlItmPlq, int? idEmpresa, int? idLocal, int? idCentroDeCusto, int? idInstalacao);

        Task<ResponseModel<AvlItm>> Adicionar(AvlItm inventario);
        Task<ResponseModel<List<AvlItm>>> Atualizar(AvlItm inventario);

        Task<ResponseModel<List<AvlItm>>> Apagar(int? idInventario);
    }
}
