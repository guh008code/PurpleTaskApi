using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PurpleTask.Models;
using PurpleTask.Repositorios.Interfaces;

namespace PurpleTask.Repositorios
{
    public class ItemsRepositorio : IItemsRepositorio
    {
        private readonly PurpleMgmContext _dbContext;
        public ItemsRepositorio(PurpleMgmContext purpleTaskDBContex)
        {
            _dbContext = purpleTaskDBContex;
        }


        public async Task<ResponseModel<List<Itm>>> ListarTodos(int? idInstalacao)
        {
            ResponseModel<List<Itm>> resposta = new ResponseModel<List<Itm>>();
            //ResponseModel<Loc> resposta = new ResponseModel<Loc>();
            try
            {
                if (!string.IsNullOrEmpty(idInstalacao.ToString()))
                {

                    var items = await _dbContext.Itms.Where(x => x.ItmIstId == idInstalacao).ToListAsync();

                    if (items == null)
                    {
                        resposta.Mensagem = "Nenhum Registro foi localizado";
                        resposta.Status = false;
                        return resposta;
                    }
                    else
                    {
                        if (items.Count <= 0)
                        {
                            resposta.Mensagem = "Nenhum Registro foi localizado";
                            resposta.Status = false;
                            return resposta;
                        }
                    }

                    resposta.Dados = items;
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

        public async Task<ResponseModel<List<Itm>>> ListarPorDescricao(Itm item)
        {
            ResponseModel<List<Itm>> resposta = new ResponseModel<List<Itm>>();
            //ResponseModel<Loc> resposta = new ResponseModel<Loc>();
            try
            {
                if (!string.IsNullOrEmpty(item.ItmIstId.ToString()))
                {

                    var items = await _dbContext.Itms.Where(x => x.ItmIstId == item.ItmIstId && x.ItmNom == item.ItmNom).ToListAsync();

                    if (items == null)
                    {
                        resposta.Mensagem = "Nenhum Registro foi localizado";
                        resposta.Status = false;
                        return resposta;
                    }
                    else
                    {
                        if (items.Count <= 0)
                        {
                            resposta.Mensagem = "Nenhum Registro foi localizado";
                            resposta.Status = false;
                            return resposta;
                        }
                    }

                    resposta.Dados = items;
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


        public async Task<ResponseModel<Itm>> Adicionar(Itm item)
        {
            ResponseModel<Itm> resposta = new ResponseModel<Itm>();

            try
            {
                var items = new Itm()
                {
                    ItmNom = item.ItmNom,
                    ItmSts = item.ItmSts,
                    ItmUsrIncId = item.ItmUsrIncId,
                    ItmUsrAltId = item.ItmUsrAltId,
                    ItmUsrExcId = (int?)null,
                    ItmDatInc = DateTime.Now,
                    ItmDatAlt = DateTime.Now,
                    ItmDatExc = (DateTime?)null,
                    ItmIstId = item.ItmIstId
                };

                _dbContext.Add(items);
                await _dbContext.SaveChangesAsync();

                resposta.Dados = items;
                resposta.Mensagem = "Item incluído com sucesso";

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
