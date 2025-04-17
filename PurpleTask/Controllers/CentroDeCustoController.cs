using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurpleTask.Models;
using PurpleTask.Repositorios.Interfaces;

namespace PurpleTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentroDeCustoController : ControllerBase
    {
        private readonly ICentroDeCustoRepositorio centroDeCustoRepositorio;

        public CentroDeCustoController(ICentroDeCustoRepositorio centroDeCustoRepositorio)
        {
            this.centroDeCustoRepositorio = centroDeCustoRepositorio;
        }

        [HttpGet("BuscarPorId/{id}/{idEmpresa}/{idInstalacao}")]
        [Authorize(Roles = "centrodecusto")]
        public async Task<ActionResult<ResponseModel<Cec>>> BuscarPorId(int? id, int? idEmpresa, int? idInstalacao)
        {
            var centroDeCustos = await centroDeCustoRepositorio.BuscarPorId(id, idEmpresa, idInstalacao);
            return Ok(centroDeCustos);
        }

        [HttpGet("ListarTodos/{idEmpresa}/{idLocal}/{idInstalacao}")]
        [Authorize(Roles = "centrodecusto")]
        public async Task<ActionResult<ResponseModel<List<Cec>>>> ListarTodos(int? idEmpresa, int? idLocal, int? idInstalacao)
        {
            var centroDeCustos = await centroDeCustoRepositorio.ListarTodos(idEmpresa, idLocal, idInstalacao);
            return Ok(centroDeCustos);
        }

    }
}
