using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PurpleTask.Models;
using PurpleTask.Repositorios.Interfaces;

namespace PurpleTask.Repositorios
{
    public class CentroDeCustoRepositorio : ICentroDeCustoRepositorio
    {
        private readonly PurpleMgmContext _dbContext;
        public CentroDeCustoRepositorio(PurpleMgmContext purpleTaskDBContex)
        {
            _dbContext = purpleTaskDBContex;
        }

        public async Task<ResponseModel<Cec>> BuscarPorId(int? id, int? idEmpresa, int? idInstalacao)
        {
            ResponseModel<Cec> resposta = new ResponseModel<Cec>();
            try
            {
                if (!string.IsNullOrEmpty(id.ToString()) && !string.IsNullOrEmpty(idEmpresa.ToString()) && !string.IsNullOrEmpty(idInstalacao.ToString()))
                {
                    var custos = await _dbContext.Cecs.FirstOrDefaultAsync(x => x.CecId == id
                                                                            && x.CecEpsId == idEmpresa
                                                                            && x.CecIstId == idInstalacao);

                    if (custos == null)
                    {
                        resposta.Mensagem = "Nenhum Registro foi localizado";
                        return resposta;
                    }

                    resposta.Dados = custos;
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

        public async Task<ResponseModel<List<Cec>>> ListarTodos(int? idEmpresa, int? idLocal, int? idInstalacao)
        {
            ResponseModel<List<Cec>> resposta = new ResponseModel<List<Cec>>();
            //ResponseModel<Cec> resposta = new ResponseModel<Cec>();
            try
            {
                if (!string.IsNullOrEmpty(idEmpresa.ToString()) && !string.IsNullOrEmpty(idLocal.ToString()) && !string.IsNullOrEmpty(idInstalacao.ToString()))
                {

                    var centroDeCustos = await _dbContext.Cecs.Where(x => x.CecEpsId == idEmpresa
                                                                            && x.CecLocId == idLocal
                                                                            && x.CecIstId == idInstalacao).ToListAsync();

                    if (centroDeCustos == null)
                    {
                        resposta.Mensagem = "Nenhum Registro foi localizado";
                        return resposta;
                    }

                    resposta.Dados = centroDeCustos;
                    resposta.Mensagem = "Registros localizados";

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
