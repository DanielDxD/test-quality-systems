using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                var body = await this.GetBody<Data.ContasAReceber>();

                if (body == null)
                    throw new Exception("Parâmetros incorretos!");
                else { }

                Data.ContasAReceber cr = new Data.ContasAReceber();


                Data.Usuario usuario = new Data.Usuario();

                List<Data.Base> listaUsuarios = Utils.Utils.listaDados(0, usuario, 0, null);


                return UtilsGestao.UtilsApi.Retorno(body);
            }
            catch (Exception ex)
            {
                return BadRequest(UtilsGestao.UtilsApi.CatchError(ex));
            }
        }
    }
}
