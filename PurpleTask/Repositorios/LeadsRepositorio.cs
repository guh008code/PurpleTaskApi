using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PurpleTask.Models;
using PurpleTask.Repositorios.Interfaces;

namespace PurpleTask.Repositorios
{
    public class LeadsRepositorio : ILeadsRepositorio
    {
        private readonly PurpleMgmContext _dbContext;
        public LeadsRepositorio(PurpleMgmContext purpleTaskDBContex)
        {
            _dbContext = purpleTaskDBContex;
        }


        public async Task<ResponseModel<List<Led>>> ListarTodos()
        {

            ResponseModel<List<Led>> resposta = new ResponseModel<List<Led>>();
            //ResponseModel<Set> resposta = new ResponseModel<Set>();
            try
            {
                    var leads = await _dbContext.Led.ToListAsync();
                    if (leads == null)
                    {
                        resposta.Mensagem = "Nenhum Registro foi localizado";
                        resposta.Status = false;
                        return resposta;
                    }
                    else
                    {
                        if (leads.Count <= 0)
                        {
                            resposta.Mensagem = "Nenhum Registro foi localizado";
                            resposta.Status = false;
                            return resposta;
                        }
                    }

                    resposta.Dados = leads;
                    resposta.Mensagem = "Registro localizado";
                    return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Led>>> ListarPorFiltros(Led lead)
        {

            ResponseModel<List<Led>> resposta = new ResponseModel<List<Led>>();
            //ResponseModel<Set> resposta = new ResponseModel<Set>();
            try
            {
                if (!string.IsNullOrEmpty(lead.LedMail) && !string.IsNullOrEmpty(lead.LedNom))
                {

                    var leads = await _dbContext.Led.Where(x => x.LedNom == lead.LedNom
                                                                            && x.LedMail == lead.LedMail).ToListAsync();
                    if (leads == null)
                    {
                        resposta.Mensagem = "Nenhum Registro foi localizado";
                        resposta.Status = false;
                        return resposta;
                    }
                    else
                    {
                        if (leads.Count <= 0)
                        {
                            resposta.Mensagem = "Nenhum Registro foi localizado";
                            resposta.Status = false;
                            return resposta;
                        }
                    }

                    resposta.Dados = leads;
                    resposta.Mensagem = "Registro localizado";

                }
                else if (!string.IsNullOrEmpty(lead.LedNom))
                {
                    var leads = await _dbContext.Led.Where(x =>  EF.Functions.Like(x.LedNom, "%" + lead.LedNom +"%")).ToListAsync();
                    if (leads == null)
                    {
                        resposta.Mensagem = "Nenhum Registro foi localizado";
                        resposta.Status = false;
                        return resposta;
                    }
                    else
                    {
                        if (leads.Count <= 0)
                        {
                            resposta.Mensagem = "Nenhum Registro foi localizado";
                            resposta.Status = false;
                            return resposta;
                        }
                    }

                    resposta.Dados = leads;
                    resposta.Mensagem = "Registro localizado";

                }
                else if (!string.IsNullOrEmpty(lead.LedMail))
                {
                    var leads = await _dbContext.Led.Where(x => EF.Functions.Like(x.LedMail, "%" + lead.LedMail + "%")).ToListAsync();
                    if (leads == null)
                    {
                        resposta.Mensagem = "Nenhum Registro foi localizado";
                        resposta.Status = false;
                        return resposta;
                    }
                    else
                    {
                        if (leads.Count <= 0)
                        {
                            resposta.Mensagem = "Nenhum Registro foi localizado";
                            resposta.Status = false;
                            return resposta;
                        }
                    }

                    resposta.Dados = leads;
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

        public async Task<ResponseModel<Led>> Adicionar(Led lead)
        {
            ResponseModel<Led> resposta = new ResponseModel<Led>();

            try
            {
                var leads = new Led()
                {
                    LedNom = lead.LedNom,
                    LedMail = lead.LedMail,
                    LedTel = lead.LedTel,
                    LedDes = lead.LedDes,
                    LedDatInc = DateTime.Now
                };

                _dbContext.Add(leads);
                await _dbContext.SaveChangesAsync();

                resposta.Dados = leads;
                resposta.Mensagem = "Lead incluído com sucesso";

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
