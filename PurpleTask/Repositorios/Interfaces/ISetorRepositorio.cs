﻿using PurpleTask.Models;

namespace PurpleTask.Repositorios.Interfaces
{
    public interface ISetorRepositorio
    {
        Task<ResponseModel<Set>> BuscarPorId(int? id, int? idEmpresa, int? idInstalacao);

        Task<ResponseModel<List<Set>>> ListarTodos(int? idEmpresa, int? idLocal, int? idCentroDeCusto, int? idInstalacao);
    }
}
