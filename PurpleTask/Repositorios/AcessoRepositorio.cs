using Microsoft.EntityFrameworkCore;
using PurpleTask.Models;
using PurpleTask.Repositorios.Interfaces;

namespace PurpleTask.Repositorios
{
    public class AcessoRepositorio : IAcessoRepositorio
    {
        private readonly PurpleMgmContext _dbContext;
        public AcessoRepositorio(PurpleMgmContext purpleTaskDBContex)
        {
            _dbContext = purpleTaskDBContex;
        }

        public async Task<ResponseModel<AuthToken>> Login(string email, string senha)
        {
            ResponseModel<AuthToken> resposta = new ResponseModel<AuthToken>();
            resposta.Dados = new AuthToken();

            senha = ConfigurationUtils.Criptografar(senha.Replace("'",""));
            try
            {
                var usuarios = await _dbContext.Usrs.FirstOrDefaultAsync(user => user.UsrEma.ToLower() == email.ToLower() && user.UsrSnh == senha);

                if (usuarios == null)
                {
                    resposta.Mensagem = "Login inválido";
                    resposta.Status = false;
                    return resposta;
                }

                resposta.Dados.Nome = usuarios.UsrNom;
                resposta.Dados.Email = usuarios.UsrEma;
                resposta.Dados.Instalacao = usuarios.UsrIstId.ToString();
                resposta.Dados.Empresa = usuarios.UsrEpsId.ToString();
                resposta.Dados.AcessToken = ConfigurationUtils.GenerateToken(usuarios);

                resposta.Mensagem = "Login e token gerado com sucesso.";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
