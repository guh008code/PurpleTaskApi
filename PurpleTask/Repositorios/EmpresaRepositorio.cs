using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PurpleTask.Models;
using PurpleTask.Repositorios.Interfaces;

namespace PurpleTask.Repositorios
{
    public class EmpresaRepositorio : IEmpresaRepositorio
    {
        private readonly PurpleMgmContext _dbContext;
        public EmpresaRepositorio(PurpleMgmContext purpleTaskDBContex)
        {
            _dbContext = purpleTaskDBContex;
        }

        public async Task<ResponseModel<Ep>> BuscarPorId(int idEmpresa, int idInstalacao)
        {
            ResponseModel<Ep> resposta = new ResponseModel<Ep>();
            try
            {
                if (!string.IsNullOrEmpty(idEmpresa.ToString()) && !string.IsNullOrEmpty(idInstalacao.ToString()))
                {
                    var usuarios = await _dbContext.Eps.FirstOrDefaultAsync(x => x.EpsId == idEmpresa
                                                                            && x.EpsIstId == idInstalacao);

                    if (usuarios == null)
                    {
                        resposta.Mensagem = "Nenhum Registro foi localizado";
                        return resposta;
                    }

                    resposta.Dados = usuarios;
                    resposta.Mensagem = "Registro localizado";

                }

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
