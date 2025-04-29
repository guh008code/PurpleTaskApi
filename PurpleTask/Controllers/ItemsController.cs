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
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepositorio itemsRepositorio;

        public ItemsController(IItemsRepositorio itemsRepositorio)
        {
            this.itemsRepositorio = itemsRepositorio;
        }

        [HttpGet("ListarTodos/{idInstalacao}")]
        [Authorize(Roles = "items")]
        public async Task<ActionResult<ResponseModel<List<Itm>>>> ListarTodos(int? idInstalacao)
        {
            var items = await itemsRepositorio.ListarTodos(idInstalacao);
            return Ok(items);
        }

    }
}
