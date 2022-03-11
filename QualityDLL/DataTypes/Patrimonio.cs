using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Patrimonio
{
    public static class Patrimonio
    {

        public static Data.ProdutoServicoPatrimonioMovimento cadastrarMovimento(Hashtable parametros)
        {
            try
            {
                if (parametros == null)
                    throw new Exception("Parâmetros não informados!");
                else { }

                if (parametros["produtoServicoPatrimonio"] == null)
                    throw new Exception("Parâmetro 'produtoServicoPatrimonio' não informado!");
                else { }

                if (parametros["departamentoOrigem"] == null)
                    throw new Exception("Parâmetro 'departamentoOrigem' não informado!");
                else { }

                if (parametros["departamentoDestino"] == null)
                    throw new Exception("Parâmetro 'departamentoDestino' não informado!");
                else { }

                if (parametros["tipoOperacao"] == null)
                    throw new Exception("Parâmetro 'tipoOperacao' não informado!");
                else { }

                if (parametros["valorMovimento"] == null)
                    throw new Exception("Parâmetro 'valorMovimento' não informado!");
                else { }

                Double valorMovimento = (Double)parametros["valorMovimento"];
                String tipoOperacao = (String)parametros["tipoOperacao"];

                Data.Departamento
                    departamentoOrigem = (Data.Departamento)parametros["departamentoOrigem"],
                    departamentoDestino = (Data.Departamento)parametros["departamentoDestino"];

                Data.ProdutoServicoPatrimonio produtoServicoPatrimonio = (Data.ProdutoServicoPatrimonio)parametros["produtoServicoPatrimonio"];

                if(produtoServicoPatrimonio.idProdutoServicoPatrimonio == 0)
                    throw new Exception("Parâmetro 'produtoServicoPatrimonio' não informado!");
                else { }

                if (departamentoOrigem.idDepartamento == 0)
                    throw new Exception("Parâmetro 'departamentoOrigem' não informado!");
                else { }

                if (departamentoDestino.idDepartamento == 0)
                    throw new Exception("Parâmetro 'departamentoDestino' não informado!");
                else { }

                if(String.IsNullOrEmpty(tipoOperacao))
                    throw new Exception("Parâmetro 'tipoOperacao' não informado!");
                else { }

                Data.ProdutoServicoPatrimonioMovimento pspm = new Data.ProdutoServicoPatrimonioMovimento();
                pspm.departamentoOrigem = departamentoOrigem;
                pspm.departamentoDestino = departamentoDestino;
                pspm.produtoServicoPatrimonio = produtoServicoPatrimonio;
                pspm.valorMovimento = valorMovimento;
                pspm.tipoOperacao = tipoOperacao;
                pspm.dataMovimento = DateTime.Now;
                pspm.operacao = ENum.eOperacao.INCLUIR;

                pspm = (Data.ProdutoServicoPatrimonioMovimento)Utils.Utils.sr(0).atualizar(pspm); //verificar

                return pspm;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
