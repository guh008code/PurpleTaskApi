using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurpleTask.Models;
using PurpleTask.Repositorios.Interfaces;

namespace PurpleTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetorController : ControllerBase
    {
        private readonly ISetorRepositorio setorRepositorio;

        public SetorController(ISetorRepositorio setorRepositorio)
        {
            this.setorRepositorio = setorRepositorio;
        }

        [HttpGet("BuscarPorId/{id}/{idEmpresa}/{idInstalacao}")]
        [Authorize(Roles = "setor")]
        public async Task<ActionResult<ResponseModel<Set>>> BuscarPorId(int id, int idEmpresa, int idInstalacao)
        {
            var setores = await setorRepositorio.BuscarPorId(id, idEmpresa, idInstalacao);
            return Ok(setores);
        }

        [HttpGet("ListarTodos/{idEmpresa}/{idLocal}/{idCentroDeCusto}/{idInstalacao}")]
        [Authorize(Roles = "setor")]
        public async Task<ActionResult<ResponseModel<List<Set>>>> ListarTodos(int idEmpresa, int idLocal, int idCentroDeCusto, int idInstalacao)
        {
            var setores = await setorRepositorio.ListarTodos(idEmpresa, idLocal, idCentroDeCusto, idInstalacao);
            return Ok(setores);
        }

    }
}
