using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurpleTask.Models;
using PurpleTask.Repositorios;
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
        public async Task<ActionResult<ResponseModel<Set>>> BuscarPorId(int? id, int? idEmpresa, int? idInstalacao)
        {
            var setor = await setorRepositorio.BuscarPorId(id, idEmpresa, idInstalacao);
            return Ok(setor);
        }

        [HttpPost("ListarPorDescricao/")]
        [Authorize(Roles = "setor")]
        public async Task<ActionResult<ResponseModel<List<Set>>>> ListarPorDescricao(Set setor)
        {
            var setores = await setorRepositorio.ListarPorDescricao(setor);
            return Ok(setores);
        }

        [HttpGet("ListarTodos/{idEmpresa}/{idLocal}/{idInstalacao}")]
        [Authorize(Roles = "setor")]
        public async Task<ActionResult<ResponseModel<List<Set>>>> ListarTodos(int? idEmpresa, int? idLocal, int idInstalacao)
        {
            var setores = await setorRepositorio.ListarTodos(idEmpresa, idLocal, idInstalacao);
            return Ok(setores);
        }

        [HttpPost("Adicionar")]
        [Authorize(Roles = "setor")]
        public async Task<ActionResult<ResponseModel<Set>>> Adicionar(Set setor)
        {
            var setores = await setorRepositorio.Adicionar(setor);
            return Ok(setores);
        }

    }
}
