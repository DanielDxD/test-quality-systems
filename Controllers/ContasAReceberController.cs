using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prova.UtilsGestao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasAReceberController : ControllerQuality
    {

        [
            Route(""),
            HttpGet
        ]
        public async Task<ActionResult<dynamic>> Detalhe()
        {
            try
            {
                /*
                 * O JSON do REQUEST deve ter o mesmo corpo da classe em questão, no caso Data.ContasAReceber */
                var body = await this.GetBody<Data.ContasAReceber>();

                if (body == null)
                    throw new Exception("Parâmetros incorretos!");
                else { }

                Data.ContasAReceber cr = new Data.ContasAReceber();

                /* ID do Contas A Receber que desejo detalhar, obtido do front-end, */
                cr.idContasAReceber = body.idContasAReceber;


                /* Instanciamos a classe NameValue, para passar parâmetros adicionais a consulta */
                List<Utils.NameValue> _params = new List<Utils.NameValue>();


                /*
                 * Chama a função sr.consultar(), passando:
                 * classeBase
                 * 
                 * Irá retornar somente um registro, ou seja, o registro passado na variável body.idContasAReceber
                 */
                cr = (Data.ContasAReceber)sr.consultar(cr);

                /*
                 * Utilizamos a função Retorno, para transformar o objeto em JSON, respeitando suas tipagens.
                 */
                return UtilsGestao.UtilsApi.Retorno(cr);
            }
            catch (Exception ex)
            {
                return BadRequest(UtilsGestao.UtilsApi.CatchError(ex));
            }
        }
        [Route(""), HttpPost]
        public async Task<ActionResult<dynamic>> Buscar()
        { 
            try
            {
                var body = await this.GetBody<Data.ContaPagamento>() ?? throw new Exception("Nenhum parâmetro foi enviado.");
                Data.ContaPagamento contaPagamento = new Data.ContaPagamento
                {
                    descricao = body.descricao,
                    idEmpresa = body.idEmpresa
                };

               
                List<Data.Base> contasPagamento = Utils.Utils.listaDados(body.idEmpresa, contaPagamento, 10, null);

                var grid = new UtilsApi.Grid();
                var gridCreatd = grid.FillFormComponentFields(contasPagamento.GetType(), false);

                return UtilsGestao.UtilsApi.Retorno(gridCreatd);
            }
            catch (Exception ex)
            {
                return BadRequest(UtilsGestao.UtilsApi.CatchError(ex));
            }
        }
        [Route("{id}"), HttpGet]
        public ActionResult<dynamic> DetalheContaPagamento([FromRoute] int id)
        {
            try
            {
                Data.ContaPagamento contaPagamento = new Data.ContaPagamento
                {
                    idContaPagamento = id
                };

                contaPagamento = (Data.ContaPagamento)sr.consultar(contaPagamento);

                return UtilsGestao.UtilsApi.Retorno(contaPagamento);
            }
            catch(Exception ex)
            {
                return BadRequest(UtilsGestao.UtilsApi.CatchError(ex));
            }
        }
    }
}
