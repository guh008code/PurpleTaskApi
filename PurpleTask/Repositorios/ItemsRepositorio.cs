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
                        return resposta;
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
    }
}
