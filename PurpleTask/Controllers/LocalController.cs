using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurpleTask.Models;
using PurpleTask.Repositorios.Interfaces;

namespace PurpleTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalController : ControllerBase
    {
        private readonly ILocalRepositorio localRepositorio;

        public LocalController(ILocalRepositorio localRepositorio)
        {
            this.localRepositorio = localRepositorio;
        }

        [HttpGet("BuscarPorId/{id}/{idEmpresa}/{idInstalacao}")]
        [Authorize(Roles = "local")]
        public async Task<ActionResult<ResponseModel<Loc>>> BuscarPorId(int? id, int? idEmpresa, int? idInstalacao)
        {
            var locais = await localRepositorio.BuscarPorId(id, idEmpresa, idInstalacao);
            return Ok(locais);
        }

        [HttpGet("ListarTodos/{idEmpresa}/{idInstalacao}")]
        [Authorize(Roles = "local")]
        public async Task<ActionResult<ResponseModel<List<Loc>>>> ListarTodos(int? idEmpresa, int? idInstalacao)
        {
            var locais = await localRepositorio.ListarTodos(idEmpresa, idInstalacao);
            return Ok(locais);
        }

    }
}
