using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PurpleTask.Models;
using PurpleTask.Repositorios;
using PurpleTask.Repositorios.Interfaces;

namespace PurpleTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcessoController : ControllerBase
    {
        private readonly IAcessoRepositorio _acessoRepositorio;
        private readonly IConfiguration _configuration;

        public AcessoController(IAcessoRepositorio acesso, IConfiguration configuration)
        {
            _acessoRepositorio = acesso;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("Login/")]

        public async Task<ActionResult<ResponseModel<AuthToken>>> Login(Login login)
        {
            var hash = _configuration["KeyEncript:hash"];

            //senha = ConfigurationUtils.Criptografar(senha);
            var usuarios = await _acessoRepositorio.Login(login, hash);
                return Ok(usuarios);
        }

        [HttpPut("Atualizar")]
        [Authorize(Roles = "acesso")]
        public async Task<ActionResult<ResponseModel<Usr>>> Atualizar(Usr atualizar)
        {
            var hash = _configuration["KeyEncript:hash"];

            //senha = ConfigurationUtils.Criptografar(senha);
            var usuario = await _acessoRepositorio.Atualizar(atualizar, hash);
            return Ok(usuario);
        }

    }
}
