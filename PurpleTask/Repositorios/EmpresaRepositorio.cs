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

        public async Task<ResponseModel<Ep>> BuscarPorId(int? idEmpresa, int? idInstalacao)
        {
            ResponseModel<Ep> resposta = new ResponseModel<Ep>();
            try
            {
                if (!string.IsNullOrEmpty(idEmpresa.ToString()) && !string.IsNullOrEmpty(idInstalacao.ToString()))
                {
                    var empresa = await _dbContext.Eps.FirstOrDefaultAsync(x => x.EpsId == idEmpresa
                                                                            && x.EpsIstId == idInstalacao);

                    if (empresa == null)
                    {
                        resposta.Mensagem = "Nenhum Registro foi localizado";
                        resposta.Status = false;
                        return resposta;
                    }

                    resposta.Dados = empresa;
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



        public async Task<ResponseModel<List<Ep>>> ListarTodos(int? idInstalacao)
        {
            ResponseModel<List<Ep>> resposta = new ResponseModel<List<Ep>>();
            //ResponseModel<Loc> resposta = new ResponseModel<Loc>();
            try
            {
                if (!string.IsNullOrEmpty(idInstalacao.ToString()))
                {
                    var empresas = await _dbContext.Eps.Where(x => x.EpsIstId == idInstalacao).ToListAsync();

                    if (empresas == null)
                    {
                        resposta.Mensagem = "Nenhum Registro foi localizado";
                        resposta.Status = false;
                        return resposta;
                    }

                    resposta.Dados = empresas;
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
