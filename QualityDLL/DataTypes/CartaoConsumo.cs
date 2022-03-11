using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Utils;

namespace CartaoConsumo
{
    public static class CartaoConsumo
    {

        public static Data.Cartao criarCartao
            (
                Data.EmpresaRelacionamento empresaRelacionamento,
                DateTime? dataEmissao = null,
                DateTime? dataValidade = null,
                Char ativo = 's',
                String codigoBarras = null,
                String numeroCartao = null,
                String numeroRFID = null,
                double saldoAtual = 0,
                bool incrementarSaldo = false
            )
        {

            /* Verificar se cartão existe */


            Data.EmpresaRelacionamentoCartao erc = criaEmpresaRelacionamentoCartao(empresaRelacionamento, saldoAtual, incrementarSaldo);
            Data.Cartao key = null;
            if (erc != null && erc.idEmpresaRelacionamentoCartao > 0)
            {
                key = new Data.Cartao();
                key.empresaRelacionamento = empresaRelacionamento;
                if (dataEmissao != null)
                    key.dataEmissao = (DateTime)dataEmissao;
                else { }
                if (dataValidade != null)
                    key.dataValidade = (DateTime)dataValidade;
                else { }
                key.ativo = ativo.ToString();
                key.codigoBarras = codigoBarras;
                key.numeroRFID = numeroRFID;
                key.numeroCartao = numeroCartao;
                key.operacao = ENum.eOperacao.INCLUIR;
                key = (Data.Cartao)Utils.Utils.sr(key.empresaRelacionamento.idEmpresa).atualizar(key);
            }
            else { }
            return key;
        }

        public static Data.EmpresaRelacionamentoCartao criaEmpresaRelacionamentoCartao
            (
                Data.EmpresaRelacionamento empresaRelacionamento,
                double saldoAtual,
                bool incrementarSaldo = false
            )
        {

            Data.EmpresaRelacionamentoCartao key = new Data.EmpresaRelacionamentoCartao();
            key.empresaRelacionamento = empresaRelacionamento;

            try
            {
                if (empresaRelacionamento != null && empresaRelacionamento.idEmpresaRelacionamento > 0)
                {
                    key = (Data.EmpresaRelacionamentoCartao)Utils.Utils.listaDados(key.empresaRelacionamento.idEmpresa, key, 0)[0];
                    if (incrementarSaldo)
                    {
                        key.saldoAtual += saldoAtual;
                        key.operacao = ENum.eOperacao.ALTERAR;
                        key = (Data.EmpresaRelacionamentoCartao)Utils.Utils.sr(key.empresaRelacionamento.idEmpresa).atualizar(key);
                    }
                }
                else
                    throw new Exception();
            }
            catch
            {
                key = null;
                if (empresaRelacionamento != null && empresaRelacionamento.idEmpresaRelacionamento > 0)
                {
                    key = new Data.EmpresaRelacionamentoCartao();
                    key.empresaRelacionamento = empresaRelacionamento;
                    key.saldoAtual = saldoAtual;
                    key.operacao = ENum.eOperacao.INCLUIR;
                    key = (Data.EmpresaRelacionamentoCartao)Utils.Utils.sr(key.empresaRelacionamento.idEmpresa).atualizar(key);
                }
                else { }
            }

            return key;
        }

        public static Data.EmpresaRelacionamentoCartaoMovimento criaMovimento
            (
                Data.EmpresaRelacionamentoCartao cartao,
                Hashtable parametros,
                string tipoOperacao
            )
        {
            try
            {
                Data.EmpresaRelacionamentoCartaoMovimento data = null;
                switch (tipoOperacao.ToUpper())
                {
                    case "C":
                        data = credito(cartao, parametros, tipoOperacao); // feito
                        break;
                    case "E":
                        data = estorno(cartao, parametros);
                        break;
                    case "V":
                        data = venda(cartao, parametros); //feito
                        break;
                    case "D":
                        data = devolucao(cartao, parametros);
                        break;
                }
                return data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private static Data.EmpresaRelacionamentoCartaoMovimento credito(Data.EmpresaRelacionamentoCartao cartao, Hashtable parametros, string tipoOperacao)
        {
            double valorMovimento = (double)parametros["valorMovimento"];
            Data.ContaPagamentoMovimento contaPagamentoMovimento = (Data.ContaPagamentoMovimento)parametros["contaPagamentoMovimento"];
            Data.ContaPagamento contaPagamento = (Data.ContaPagamento)parametros["contaPagamento"];


            string
                tipoMovimento = (string)parametros["tipoMovimento"],
                numeroDocumento = (string)parametros["numeroDocumento"];

            int
                idNaturezaOperacao = (int)parametros["idNaturezaOperacao"],
                idDepartamento = (int)parametros["idDepartamento"],
                idPdvEstacao = 0,
                idFuncionario = 0;

            if (parametros["idFuncionario"] != null)
                idFuncionario = (int)parametros["idFuncionario"];
            else { }

            if (parametros["idPdvEstacao"] != null)
                idPdvEstacao = (int)parametros["idPdvEstacao"];
            else { }

            bool
                atualizarSaldo = true,
                flagCriarContasAReceber = true;

            if (parametros["atualizarSaldo"] != null)
                atualizarSaldo = (bool)parametros["atualizarSaldo"];
            else { }

            if (parametros["criarContasAReceber"] != null)
                flagCriarContasAReceber = (bool)parametros["criarContasAReceber"];
            else { }

            if (valorMovimento == 0)
                throw new Exception("Valor do movimento deve ser maior que zero!");
            else { }

            if (String.IsNullOrEmpty(tipoMovimento))
                throw new Exception("Tipo de movimento não informado.");
            else { }

            if (String.IsNullOrEmpty(tipoOperacao))
                throw new Exception("Tipo de operação não informado.");
            else { }

            if (contaPagamento == null || (contaPagamento != null && contaPagamento.idContaPagamento == 0))
                throw new Exception("Informar a conta pagamento!");
            else { }

            if (cartao == null || (cartao != null && cartao.idEmpresaRelacionamentoCartao == 0))
            {
                cartao = (Data.EmpresaRelacionamentoCartao)Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).atualizar(cartao);
                if (cartao != null && cartao.idEmpresaRelacionamentoCartao > 0)
                    cartao.operacao = ENum.eOperacao.ALTERAR;
            }
            else { }

            Data.ContasAReceber contasAReceber = null;
            if (flagCriarContasAReceber)
            {
                if (contaPagamentoMovimento == null || (contaPagamentoMovimento != null && contaPagamentoMovimento.idContaPagamentoMovimento == 0))
                {
                    Hashtable retorno = criarContasAReceber(
                        valorMovimento,
                        cartao,
                        contaPagamento,
                        idNaturezaOperacao,
                        idDepartamento,
                        numeroDocumento,
                        null,
                        idFuncionario,
                        idPdvEstacao
                        );

                    contasAReceber = (Data.ContasAReceber)retorno["contasAReceber"];
                    contaPagamentoMovimento = new Data.ContaPagamentoMovimento();
                    contaPagamentoMovimento.idContaPagamentoMovimento = (int)retorno["idContaPagamentoMovimento"];
                }
                else
                {
                    contaPagamentoMovimento = (Data.ContaPagamentoMovimento)Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).consultar(contaPagamentoMovimento);
                    if (contaPagamentoMovimento != null && contaPagamentoMovimento.idContaPagamentoMovimento > 0)
                    {
                        Data.DocumentoRecebimento dr = contaPagamentoMovimento.documentoRecebimento;
                        dr = (Data.DocumentoRecebimento)Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).consultar(dr);
                        if (dr != null && dr.idDocumentoRecebimento > 0)
                            if (dr.documentoRecebimentoContasARecebers != null && dr.documentoRecebimentoContasARecebers.Length > 0)
                                contasAReceber = dr.documentoRecebimentoContasARecebers[0].contasAReceber;
                            else { }
                    }
                    else { }
                }
            }
            else { }

            Data.EmpresaRelacionamentoCartaoMovimento key = new Data.EmpresaRelacionamentoCartaoMovimento();
            key.operacao = ENum.eOperacao.INCLUIR;
            key.tipoMovimento = tipoMovimento;
            key.tipoOperacao = tipoOperacao;
            key.valorMovimento = valorMovimento;
            key.dataMovimento = DateTime.Now;
            key.contaPagamentoMovimento = contaPagamentoMovimento;
            key.empresaRelacionamentoCartao = cartao;
            key.contasAReceber = contasAReceber;
            if (idPdvEstacao > 0)
                key.pdvEstacao = new Data.PdvEstacao { idPdvEstacao = idPdvEstacao };
            else { }
            key = (Data.EmpresaRelacionamentoCartaoMovimento)Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).atualizar(key);

            if (key != null && key.idEmpresaRelacionamentoCartaoMovimento > 0)
            {
                if (atualizarSaldo)
                {
                    cartao.saldoAtual += valorMovimento;
                    cartao.operacao = ENum.eOperacao.ALTERAR;
                    cartao = (Data.EmpresaRelacionamentoCartao)Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).atualizar(cartao);

                    if (cartao == null || (cartao != null && cartao.idEmpresaRelacionamentoCartao == 0))
                    {
                        key.operacao = ENum.eOperacao.EXCLUIR;
                        Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).atualizar(key);
                        throw new Exception("Não foi possível criar o movimento, pois houve um erro na atualizaçao do saldo da comanda.");
                    }
                    else { }
                }
                else { }
            }
            else { }

            return key;
        }

        private static Data.EmpresaRelacionamentoCartaoMovimento estorno(Data.EmpresaRelacionamentoCartao cartao, Hashtable parametros)
        {
            double valorMovimento = (double)parametros["valorMovimento"];

            string
                tipoMovimento = (string)parametros["tipoMovimento"],
                tipoOperacao = (string)parametros["tipoOperacao"],
                numeroDocumento = (string)parametros["numeroDocumento"];

            int
                idNaturezaOperacao = (int)parametros["idNaturezaOperacao"],
                idDepartamento = (int)parametros["idDepartamento"],
                idPdvEstacao = 0,
                idFuncionario = 0;

            if (parametros["idPdvEstacao"] != null)
                idPdvEstacao = (int)parametros["idPdvEstacao"];
            else { }

            if (parametros["idFuncionario"] != null)
                idFuncionario = (int)parametros["idFuncionario"];
            else { }

            Data.ContaPagamento contaPagamento = (Data.ContaPagamento)parametros["contaPagamento"];
            Data.ContaPagamentoMovimento contaPagamentoMovimento = (Data.ContaPagamentoMovimento)parametros["contaPagamentoMovimento"];
            int idTipoDocumento = (int)parametros["idTipoDocumento"];

            if (valorMovimento <= 0)
                throw new Exception("Valor do estorno deve ser maior que zero!");
            else { }

            if (String.IsNullOrEmpty(tipoMovimento))
                throw new Exception("Tipo de movimento não informado.");
            else { }

            if (String.IsNullOrEmpty(tipoOperacao))
                throw new Exception("Tipo de operação não informado.");
            else { }

            if (contaPagamento == null || (contaPagamento != null && contaPagamento.idContaPagamento == 0))
                throw new Exception("Infor e a conta de origem do estorno!");
            else { }

            if (cartao == null || (cartao != null && cartao.idEmpresaRelacionamentoCartao == 0))
                throw new Exception("Cartão informado inválido!");
            else { }

            if (idTipoDocumento == 0)
                throw new Exception("Informe o tipo de documento do estorno!");
            else { }

            if (cartao.saldoAtual <= 0)
                throw new Exception("Este cartão não possui saldo remanescente!");
            else { }

            if (idNaturezaOperacao == 0)
                throw new Exception("Necessário informar a natureza de operação para geração do Contas A Pagar!");
            else { }

            if (idDepartamento == 0)
                throw new Exception("Necessário informar o departamento para geração do Contas A Pagar!");
            else { }

            if (valorMovimento > cartao.saldoAtual)
                throw new Exception("Valor do estorno maior que o saldo atual!");
            else { }

            /* Sem estoque, sem venda, criar contas a pagar */

            Hashtable paramsRetorno = criarContasAPagar(valorMovimento, cartao, contaPagamento, idTipoDocumento, idNaturezaOperacao, idDepartamento, numeroDocumento, null, idFuncionario);

            Data.ContasAPagar contasAPagar = (Data.ContasAPagar)paramsRetorno["contasAPagar"];
            int idContaPagamentoMovimento = (int)paramsRetorno["idContaPagamentoMovimento"];
            Data.EmpresaRelacionamentoCartaoMovimento key = null;

            if (contasAPagar != null && contasAPagar.idContasAPagar > 0)
            {
                key = new Data.EmpresaRelacionamentoCartaoMovimento();
                key.operacao = ENum.eOperacao.INCLUIR;
                key.tipoMovimento = tipoMovimento;
                key.tipoOperacao = tipoOperacao;
                key.valorMovimento = valorMovimento;
                key.dataMovimento = DateTime.Now;
                key.contaPagamentoMovimento = (Data.ContaPagamentoMovimento)Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).consultar(new Data.ContaPagamentoMovimento { idContaPagamentoMovimento = idContaPagamentoMovimento });
                key.empresaRelacionamentoCartao = cartao;
                if (idPdvEstacao > 0)
                    key.pdvEstacao = new Data.PdvEstacao { idPdvEstacao = idPdvEstacao };
                else { }
                key = (Data.EmpresaRelacionamentoCartaoMovimento)Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).atualizar(key);

                if (key != null && key.idEmpresaRelacionamentoCartaoMovimento > 0)
                {
                    if (tipoMovimento.ToUpper() == "PR")
                    {
                        cartao.saldoAtual -= valorMovimento;
                        cartao.operacao = ENum.eOperacao.ALTERAR;
                        cartao = (Data.EmpresaRelacionamentoCartao)Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).atualizar(cartao);

                        if (cartao == null || (cartao != null && cartao.idEmpresaRelacionamentoCartao == 0))
                        {
                            key.operacao = ENum.eOperacao.EXCLUIR;
                            Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).atualizar(key);
                            throw new Exception("Não foi possível criar o movimento de estorno, pois houve um erro na atualizaçao do saldo da comanda.");
                        }
                        else { }
                    }
                    else { }
                }
                else { }
            }
            else { }

            return key;
        }

        private static Data.EmpresaRelacionamentoCartaoMovimento venda(Data.EmpresaRelacionamentoCartao cartao, Hashtable parametros)
        {
            double
                valorMovimento = (double)parametros["valorMovimento"],
                valorDesconto = parametros["valorDesconto"] == null ? 0 : (double)parametros["valorDesconto"],
                valorTaxaServico = parametros["valorTaxaServico"] == null ? 0 : (double)parametros["valorTaxaServico"];

            string tipoMovimento = (string)parametros["tipoMovimento"];
            string tipoOperacao = (string)parametros["tipoOperacao"];
            Data.PdvCompra pdvCompra = (Data.PdvCompra)parametros["pdvCompra"];

            if (String.IsNullOrEmpty(tipoMovimento))
                throw new Exception("Tipo de movimento não informado.");
            else { }

            if (String.IsNullOrEmpty(tipoOperacao))
                throw new Exception("Tipo de operação não informado.");
            else { }

            if (cartao == null || (cartao != null && cartao.idEmpresaRelacionamentoCartao == 0))
                throw new Exception("Cartão informado inválido!");
            else { }

            if (pdvCompra == null || (pdvCompra != null && pdvCompra.idPdvCompra == 0))
                throw new Exception("Venda não informada!");
            else { }

            if (tipoMovimento.ToUpper() == "PR")
                if (cartao.saldoAtual < ((valorMovimento + valorTaxaServico) - valorDesconto))
                    throw new Exception("Saldo no cartão insuficiente!");
                else { }
            else { }

            Data.EmpresaRelacionamentoCartaoMovimento key = new Data.EmpresaRelacionamentoCartaoMovimento();
            key.operacao = ENum.eOperacao.INCLUIR;
            key.tipoMovimento = tipoMovimento;
            key.tipoOperacao = tipoOperacao;
            key.valorMovimento = (valorMovimento + valorTaxaServico);
            key.dataMovimento = DateTime.Now;
            key.pdvCompra = pdvCompra;
            key.valorDesconto = valorDesconto;
            key.empresaRelacionamentoCartao = cartao;
            if (pdvCompra.pdvEstacao != null && pdvCompra.pdvEstacao.idPdvEstacao > 0)
                key.pdvEstacao = pdvCompra.pdvEstacao;
            else { }
            key = (Data.EmpresaRelacionamentoCartaoMovimento)Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).atualizar(key);

            if (key != null && key.idEmpresaRelacionamentoCartaoMovimento > 0)
            {

                if (valorTaxaServico > 0)
                {
                    /* Aplicando taxas */
                    Data.PdvCompraTaxaServico pcts = new Data.PdvCompraTaxaServico
                    {
                        valor = valorTaxaServico,
                        operacao = ENum.eOperacao.INCLUIR,
                        pdvCompra = pdvCompra
                    };
                    pcts = (Data.PdvCompraTaxaServico)Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).atualizar(pcts);
                }
                else { }

                if (tipoMovimento.ToUpper() == "PR")
                {
                    cartao.saldoAtual -= ((valorMovimento + valorTaxaServico) - valorDesconto);
                    cartao.operacao = ENum.eOperacao.ALTERAR;
                    cartao = (Data.EmpresaRelacionamentoCartao)Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).atualizar(cartao);

                    if (cartao == null || (cartao != null && cartao.idEmpresaRelacionamentoCartao == 0))
                    {
                        key.operacao = ENum.eOperacao.EXCLUIR;
                        Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).atualizar(key);
                        throw new Exception("Não foi possível criar o movimento, pois houve um erro na atualizaçao do saldo da comanda.");
                    }
                    else { }
                }
                else { }
            }
            else { }

            return key;
        }

        private static Data.EmpresaRelacionamentoCartaoMovimento devolucao(Data.EmpresaRelacionamentoCartao cartao, Hashtable parametros)
        {

            double
                valorMovimento = (double)parametros["valorMovimento"],
                valorDesconto = parametros["valorDesconto"] == null ? 0 : (double)parametros["valorDesconto"];

            string
                tipoMovimento = (string)parametros["tipoMovimento"],
                tipoOperacao = (string)parametros["tipoOperacao"],
                numeroDocumento = (string)parametros["numeroDocumento"];

            int
                idNaturezaOperacao = (int)parametros["idNaturezaOperacao"],
                idDepartamento = (int)parametros["idDepartamento"],
                idEmpresaRelacionamentoFuncionario = (int)parametros["idEmpresaRelacionamentoFuncionario"],
                idEmpresaRelacionamentoCartaoMovimentoReferencia = (int)parametros["idEmpresaRelacionamentoCartaoMovimentoReferencia"];

            bool flagCancelarVenda = true;
            if (parametros["cancelarVenda"] != null)
                flagCancelarVenda = (bool)parametros["cancelarVenda"];
            else { }

            Data.PdvCompra pdvCompra = (Data.PdvCompra)parametros["pdvCompra"];
            if (cartao.empresaRelacionamento == null)
                cartao.empresaRelacionamento = (Data.EmpresaRelacionamento)Utils.Utils.listaDados(0, cartao.empresaRelacionamento, 1, new List<NameValue>() { new NameValue { name = "Mode", value = "Roll" } })[0];
            pdvCompra = (Data.PdvCompra)Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).consultar(pdvCompra);

            if (valorMovimento <= 0)
                throw new Exception("Valor do estorno deve ser maior que zero!");
            else { }

            if (idEmpresaRelacionamentoCartaoMovimentoReferencia == 0)
                throw new Exception("Informe qual movimento você está devolvendo!");
            else { }

            if (String.IsNullOrEmpty(tipoMovimento))
                throw new Exception("Tipo de movimento não informado.");
            else { }

            if (String.IsNullOrEmpty(tipoOperacao))
                throw new Exception("Tipo de operação não informado.");
            else { }

            if (pdvCompra == null || (pdvCompra != null && pdvCompra.idPdvCompra == 0))
                throw new Exception("Venda não informada!");
            else { }

            if (cartao == null || (cartao != null && cartao.idEmpresaRelacionamentoCartao == 0))
                throw new Exception("Cartão informado inválido!");
            else { }

            if (idEmpresaRelacionamentoFuncionario == 0)
                throw new Exception("Informe o funcionário que está realizando a devolução. Campo necessário: idEmpresaRelacionamento!");
            else { }


            if (flagCancelarVenda)
                cancelarVenda(cartao.empresaRelacionamento.idEmpresa, pdvCompra, idEmpresaRelacionamentoFuncionario);
            else { }


            Data.EmpresaRelacionamentoCartaoMovimento key = null;

            key = new Data.EmpresaRelacionamentoCartaoMovimento();
            key.operacao = ENum.eOperacao.INCLUIR;
            key.tipoMovimento = tipoMovimento;
            key.tipoOperacao = tipoOperacao;
            key.valorMovimento = valorMovimento;
            key.valorDesconto = valorDesconto;
            key.dataMovimento = DateTime.Now;
            key.pdvCompra = pdvCompra;
            key.empresaRelacionamentoCartao = cartao;
            if (pdvCompra.pdvEstacao != null && pdvCompra.pdvEstacao.idPdvEstacao > 0)
                key.pdvEstacao = pdvCompra.pdvEstacao;
            else { }
            key = (Data.EmpresaRelacionamentoCartaoMovimento)Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).atualizar(key);

            if (key != null && key.idEmpresaRelacionamentoCartaoMovimento > 0)
            {
                if (tipoMovimento.ToUpper() == "PR" || tipoMovimento.ToUpper() == "PP")
                {

                    Data.EmpresaRelacionamentoCartaoMovimento _KeyAntigo = new Data.EmpresaRelacionamentoCartaoMovimento
                    {
                        idEmpresaRelacionamentoCartaoMovimento = idEmpresaRelacionamentoCartaoMovimentoReferencia
                    };
                    _KeyAntigo = (Data.EmpresaRelacionamentoCartaoMovimento)Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).consultar(_KeyAntigo);

                    if (_KeyAntigo != null && _KeyAntigo.idEmpresaRelacionamentoCartaoMovimento > 0)
                    {
                        _KeyAntigo.operacao = ENum.eOperacao.ALTERAR;
                        _KeyAntigo.estornoDevolucao = new Data.EmpresaRelacionamentoCartaoMovimento
                        {
                            idEmpresaRelacionamentoCartaoMovimento = key.idEmpresaRelacionamentoCartaoMovimento
                        };
                        _KeyAntigo = (Data.EmpresaRelacionamentoCartaoMovimento)Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).atualizar(_KeyAntigo);
                    }
                    else { }

                    if (tipoMovimento.ToUpper() == "PR")
                    {
                        cartao.saldoAtual += (valorMovimento - valorDesconto);
                        cartao.operacao = ENum.eOperacao.ALTERAR;
                        cartao = (Data.EmpresaRelacionamentoCartao)Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).atualizar(cartao);

                        if (cartao == null || (cartao != null && cartao.idEmpresaRelacionamentoCartao == 0))
                        {
                            key.operacao = ENum.eOperacao.EXCLUIR;
                            Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).atualizar(key);
                            throw new Exception("Não foi possível criar o movimento de devolução, pois houve um erro na atualizaçao do saldo da comanda.");
                        }
                        else { }
                    }
                    else { }
                }
                else { }
            }
            else { }

            return key;
        }

        private static void cancelarVenda(long idEmpresa, Data.PdvCompra pdvCompra, int idEmpresaRelacionamentoFuncionario)
        {
            pdvCompra = (Data.PdvCompra)Utils.Utils.sr(idEmpresa).consultar(new Data.PdvCompra { idPdvCompra = pdvCompra.idPdvCompra });

            if (pdvCompra != null && pdvCompra.idPdvCompra > 0)
            {
                /* Cancelando a requisição */
                pdvCompra.contasAReceber = (Data.ContasAReceber)Utils.Utils.sr(idEmpresa).consultar(pdvCompra.contasAReceber);
                if (pdvCompra.contasAReceber != null && pdvCompra.contasAReceber.idContasAReceber > 0 && pdvCompra.contasAReceber.contasAReceberPagamentos != null && pdvCompra.contasAReceber.contasAReceberPagamentos.Length > 0)
                    throw new Exception("Não é possível finalizar esta venda, pois já existem pagamentos realizados!");
                else { }

                if (pdvCompra.statusCompra == "C")
                    throw new Exception("Não é possível finalizar esta venda, pois ela já está cancelada!");
                else { }

                Data.PdvCompra _c = pdvCompra;
                _c.statusCompra = "C";
                _c.operacao = ENum.eOperacao.ALTERAR;
                _c.contasAReceber = null;
                _c = (Data.PdvCompra)Utils.Utils.sr(idEmpresa).atualizar(_c);

                if (_c != null && _c.idPdvCompra > 0)
                {
                    pdvCompra = _c;
                    /*
                     * Cancelar contas a receber */
                    if (pdvCompra.contasAReceber != null && pdvCompra.contasAReceber.idContasAReceber > 0)
                    {
                        pdvCompra.contasAReceber.operacao = ENum.eOperacao.EXCLUIR;
                        pdvCompra.contasAReceber.dataCancelamento = DateTime.Now;
                        pdvCompra.contasAReceber = (Data.ContasAReceber)Utils.Utils.sr(idEmpresa).atualizar(pdvCompra.contasAReceber);
                    }
                    else { }

                    if (pdvCompra.requisicaoInterna != null && pdvCompra.requisicaoInterna.idRequisicaoInterna > 0)
                    {
                        Data.RequisicaoInterna ri = pdvCompra.requisicaoInterna;
                        ri = (Data.RequisicaoInterna)Utils.Utils.sr(idEmpresa).consultar(ri);
                        ri.operacao = ENum.eOperacao.ALTERAR;

                        if (ri.requisicaoInternaProdutoServicos != null)
                        {
                            List<Data.RequisicaoInternaProdutoServico> _rips = new List<Data.RequisicaoInternaProdutoServico>();
                            foreach (Data.RequisicaoInternaProdutoServico rips in ri.requisicaoInternaProdutoServicos)
                            {
                                rips.quantidadeAtendida = 0;
                                rips.operacao = ENum.eOperacao.ALTERAR;
                                _rips.Add(rips);
                            }
                            ri.requisicaoInternaProdutoServicos = _rips.ToArray();

                        }
                        else { }

                        List<Data.RequisicaoInternaSituacao> situacoes = new List<Data.RequisicaoInternaSituacao>();
                        if (ri.requisicaoInternaSituacaos != null)
                            foreach (Data.RequisicaoInternaSituacao _risF in ri.requisicaoInternaSituacaos)
                            {
                                _risF.operacao = ENum.eOperacao.ALTERAR;
                                situacoes.Add(_risF);
                            }
                        else { }

                        if (situacoes.Where(X => X.situacao == "C") == null || (situacoes.Where(X => X.situacao == "C") != null && situacoes.Where(X => X.situacao == "C").ToArray().Length == 0))
                        {
                            Data.RequisicaoInternaSituacao _ris = new Data.RequisicaoInternaSituacao();
                            _ris.funcionario = new Data.Funcionario { idEmpresaRelacionamento = idEmpresaRelacionamentoFuncionario };
                            _ris.dataSituacao = DateTime.Now;
                            _ris.situacao = "C";
                            _ris.operacao = ENum.eOperacao.INCLUIR;
                            situacoes.Add(_ris);
                        }
                        else { }
                        ri.requisicaoInternaSituacaos = situacoes.ToArray();
                        ri = (Data.RequisicaoInterna)Utils.Utils.sr(idEmpresa).atualizar(ri);

                        if (ri != null && ri.idRequisicaoInterna > 0)
                            pdvCompra.requisicaoInterna = ri;
                        else { }
                    }
                    else { }
                }
                else { }
            }
        }

        private static Hashtable criarContasAPagar
                (
                    double valorMovimento,
                    Data.EmpresaRelacionamentoCartao cartao,
                    Data.ContaPagamento contaPagamento,
                    int idTipoDocumento,
                    int idNaturezaOperacao,
                    int idDepartamento,
                    string numeroDocumento = null,
                    Data.ContaPagamentoMovimento contaPagamentoMovimento = null,
                    int idFuncionario = 0
                )
        {

            //Básico
            Data.ContasAPagar result = new Data.ContasAPagar();

            //result.fornecedor;
            result.idEmpresa = cartao.empresaRelacionamento.idEmpresa;
            result.empresaRelacionamento = cartao.empresaRelacionamento;

            List<Data.ContasAPagarItem> cpis = new List<Data.ContasAPagarItem>();
            Data.ContasAPagarItem cpi = new Data.ContasAPagarItem();
            cpi.descricao = "Estorno de crédito";
            cpi.idDepartamento = idDepartamento; //Parametrizado.
            cpi.idNaturezaOperacao = idNaturezaOperacao; //Parametrizado
            cpi.operacao = ENum.eOperacao.INCLUIR;
            cpi.valor = valorMovimento;
            cpis.Add(cpi);
            result.contasAPagarItems = cpis.ToArray();

            result.numeroDocumento = numeroDocumento;
            result.dataMovimento = DateTime.Now;
            result.dataVencimento = DateTime.Now;
            result.valor = valorMovimento;
            result.operacao = ENum.eOperacao.INCLUIR;

            result = (Data.ContasAPagar)Utils.Utils.sr(result.idEmpresa).atualizar(result);
            int idContaPagamentoMovimento = 0;
            if (result != null && result.idContasAPagar > 0)
            {
                Double valorPago = 0;

                if (result.contasAPagarPagamentos != null)
                    foreach (Data.ContasAPagarPagamento _cap in result.contasAPagarPagamentos)
                        valorPago += _cap.valorPrincipal;
                else { }

                Double valorAPagar = valorMovimento;

                if (valorMovimento > (Utils.Utils.ToDouble((result.valor - valorPago).ToString("0.00"))))
                    throw new Utils.BusinessRuleException("O valor da baixa não pode ser maior que o valor total do pagamento!");
                else { }


                Data.DocumentoPagamento dp = new Data.DocumentoPagamento();
                dp.idEmpresa = result.empresaRelacionamento.idEmpresa;
                dp.dataGeracao = DateTime.Now;
                //dp.descricao = result.empresaRelacionamento.pessoa.nomeRazaoSocial;
                dp.descricao = "Estorno de crédito";
                dp.contaPagamento = contaPagamento;
                dp.motivoCancelamento = "";
                dp.tipoDocumento = (Data.TipoDocumento)Utils.Utils.sr(result.idEmpresa).consultar(new Data.TipoDocumento { idTipoDocumento = idTipoDocumento });
                dp.numeroDocumento = "S/N";
                dp.serieDocumento = "";
                dp.operacao = ENum.eOperacao.INCLUIR;
                dp.valorPago = valorAPagar;

                List<Data.DocumentoPagamentoContasAPagar> listDpca = new List<Data.DocumentoPagamentoContasAPagar>();
                Data.DocumentoPagamentoContasAPagar dpca = new Data.DocumentoPagamentoContasAPagar();
                dpca.contasAPagar = result;
                dpca.operacao = ENum.eOperacao.INCLUIR;
                dpca.valorBase = result.valor;
                dpca.valorPago = valorMovimento;
                dpca.valorMulta = 0;
                dpca.valorJuros = 0;
                dpca.valorDesconto = 0;
                dpca.valorINSSRetido = 0;
                dpca.valorISSRetido = 0;
                dpca.valorIRRetido = 0;
                dpca.valorPISRetido = 0;
                dpca.valorCM = 0;
                dpca.valorCOFINSRetido = 0;
                listDpca.Add(dpca);
                dp.documentoPagamentoContasAPagars = listDpca.ToArray();

                int numeroChequeAtual = 0;

                if (dp.contaPagamento.tipoConta == "B" && dp.contaPagamento.numeroChequeInicial > 0 && dp.tipoDocumento.cheque)
                {
                    System.Collections.Generic.List<NameValue> _parameters = new System.Collections.Generic.List<NameValue>();

                    try
                    {
                        _parameters.Add(new NameValue { name = "Order", value = "contaPagamentoCheque.numero desc" });
                        _parameters.Add(new NameValue { name = "Filter", value = "((contaPagamentoCheque.numero >= contaPagamento.numeroChequeInicial) and (contaPagamentoCheque.numero <= contaPagamento.numeroChequeFinal))" });

                        var item = Utils.Utils.listaDados(result.idEmpresa, new Data.ContaPagamentoCheque { contaPagamento = dp.contaPagamento }, 1, _parameters);

                        if (item != null)
                            numeroChequeAtual = item.Max(i => ((Data.ContaPagamentoCheque)i).numero);
                        else { }
                    }
                    catch { }

                    _parameters.Clear();
                    _parameters = null;
                    if (numeroChequeAtual < dp.contaPagamento.numeroChequeInicial)
                        numeroChequeAtual = (dp.contaPagamento.numeroChequeInicial - 1);
                    else { }

                    if
                    (
                        (
                            (dp.contaPagamento.numeroChequeFinal == 0) ||
                            ((numeroChequeAtual + 1) <= dp.contaPagamento.numeroChequeFinal)
                        )
                    )
                        dp.numeroDocumento = (numeroChequeAtual = (numeroChequeAtual + 1)).ToString();
                    else
                        throw new Utils.BusinessRuleException("Número do cheque atual maior que " + dp.contaPagamento.numeroChequeFinal.ToString());
                }
                else { }

                dp = (Data.DocumentoPagamento)Utils.Utils.sr(result.idEmpresa).atualizar(dp);

                if (dp != null)
                {
                    Data.ContaPagamentoMovimento cpm = new Data.ContaPagamentoMovimento();
                    cpm.operacao = ENum.eOperacao.INCLUIR;
                    cpm.contaPagamento = dp.contaPagamento;
                    cpm.documentoPagamento = dp;
                    cpm.dataMovimento = dp.dataGeracao;
                    cpm.descricao = dp.descricao;
                    cpm.valor = dp.valorPago;
                    cpm.dataConciliacao = dp.dataGeracao;
                    cpm.idFuncionario = idFuncionario;
                    cpm = (Data.ContaPagamentoMovimento)Utils.Utils.sr(result.idEmpresa).atualizar(cpm);

                    if (cpm != null && cpm.idContaPagamentoMovimento > 0)
                        idContaPagamentoMovimento = cpm.idContaPagamentoMovimento;
                    else { }

                    if (dp.tipoDocumento.cheque && (numeroChequeAtual > 0))
                    {
                        Data.ContaPagamentoCheque contaPagamentoCheque = new Data.ContaPagamentoCheque();
                        contaPagamentoCheque.operacao = ENum.eOperacao.INCLUIR;
                        contaPagamentoCheque.documentoPagamento = dp;
                        contaPagamentoCheque.contaPagamento = dp.contaPagamento;
                        contaPagamentoCheque.numero = numeroChequeAtual;
                        contaPagamentoCheque.dataEmissao = dp.dataGeracao;
                        contaPagamentoCheque.valor = dp.valorPago;
                        contaPagamentoCheque.valorExtenso = Extenso.toExtenso(dp.valorPago);

                        Utils.Utils.sr(result.idEmpresa).atualizar(contaPagamentoCheque);
                    }
                    else { }

                    foreach (var item in dp.documentoPagamentoContasAPagars)
                    {

                        if
                        (
                            (
                                item.valorPago +
                                (
                                    item.valorMulta +
                                    item.valorJuros +
                                    item.valorCM
                                ) +
                                (
                                    item.valorDesconto +
                                    item.valorINSSRetido +
                                    item.valorISSRetido +
                                    item.valorIRRetido +
                                    item.valorPISRetido +
                                    item.valorCOFINSRetido +
                                    item.valorCSLLRetido
                                )
                            ) > 0.0
                        )
                        {

                            if (item.idDocumentoPagamentoContasAPagar <= 0)
                            {
                                Data.ContasAPagarPagamento _capp = new Data.ContasAPagarPagamento
                                {
                                    operacao = ENum.eOperacao.INCLUIR,
                                    idContasAPagar = item.contasAPagar.idContasAPagar,
                                    idDocumentoPagamento = dp.idDocumentoPagamento,
                                    dataMovimento = dp.dataMovimento,
                                    contaPagamento = dp.contaPagamento,
                                    valorCM = item.valorCM,
                                    valorCOFINSRetido = item.valorCOFINSRetido,
                                    valorDesconto = item.valorDesconto,
                                    valorCSLLRetido = item.valorCSLLRetido,
                                    valorINSSRetido = item.valorINSSRetido,
                                    valorIRRetido = item.valorIRRetido,
                                    valorISSRetido = item.valorISSRetido,
                                    valorJuros = item.valorJuros,
                                    valorMulta = item.valorMulta,
                                    valorPISRetido = item.valorPISRetido,
                                    valorPrincipal =
                                    (
                                        item.valorPago -
                                        (
                                            item.valorMulta +
                                            item.valorJuros +
                                            item.valorCM
                                        ) +
                                        (
                                            item.valorDesconto +
                                            item.valorINSSRetido +
                                            item.valorISSRetido +
                                            item.valorIRRetido +
                                            item.valorPISRetido +
                                            item.valorCOFINSRetido +
                                            item.valorCSLLRetido
                                        )
                                    ),
                                    idFuncionario = idFuncionario
                                };

                                Utils.Utils.sr(result.idEmpresa).atualizar(_capp);
                            }
                            else { }
                        }
                        else { }
                    }
                }
                else { }
            }
            else { }

            result = (Data.ContasAPagar)Utils.Utils.sr(result.idEmpresa).consultar(result);
            Hashtable retorno = new Hashtable();
            retorno["contasAPagar"] = result;
            retorno["idContaPagamentoMovimento"] = idContaPagamentoMovimento;
            return retorno;
        }

        private static Hashtable criarContasAReceber
                (
                    double valorMovimento,
                    Data.EmpresaRelacionamentoCartao cartao,
                    Data.ContaPagamento contaPagamento,
                    int idNaturezaOperacao,
                    int idDepartamento,
                    string numeroDocumento = null,
                    Data.ContaPagamentoMovimento contaPagamentoMovimento = null,
                    int idFuncionario = 0,
                    int idPdvEstacao = 0
                )
        {
            Data.ContasAReceber result = new Data.ContasAReceber();
            result.dataLancamento = DateTime.Now;
            result.dataVencimento = DateTime.Now;
            result.dataUltimoRecebimento = DateTime.Now;
            result.empresaRelacionamento = new Data.EmpresaRelacionamento();
            result.empresaRelacionamento.idEmpresaRelacionamento = cartao.empresaRelacionamento.idEmpresaRelacionamento;
            result.descricao = "Crédito Pré Pago";
            result.valor = valorMovimento;
            result.idEmpresa = cartao.empresaRelacionamento.idEmpresa;
            result.emAberto = "0";
            result.desconto = 0;
            result.operacao = ENum.eOperacao.INCLUIR;

            Data.ContasAReceberItem cri = new Data.ContasAReceberItem();
            cri.departamento = new Data.Departamento { idDepartamento = idDepartamento };
            cri.idDepartamento = idDepartamento;
            cri.idNaturezaOperacao = idNaturezaOperacao;
            cri.valor = result.valor;
            cri.descricao = result.descricao;
            cri.operacao = ENum.eOperacao.INCLUIR;
            List<Data.ContasAReceberItem> listCri = new List<Data.ContasAReceberItem>();
            listCri.Add(cri);
            result.contasAReceberItems = listCri.ToArray();

            result = (Data.ContasAReceber)Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).atualizar(result);

            Double valorRecebido = 0;
            if (result.contasAReceberPagamentos != null)
                foreach (Data.ContasAReceberPagamento _cap in result.contasAReceberPagamentos)
                    valorRecebido += _cap.valorPrincipal;
            else { }

            Double valorAReceber = valorMovimento;

            if (valorMovimento > (Utils.Utils.ToDouble((result.valor - valorRecebido).ToString("0.00"))))
                throw new Utils.BusinessRuleException("O valor da baixa não pode ser maior que o valor total do recebimento!");
            else { }

            List<NameValue> _params = new List<NameValue>();
            _params.Add(new NameValue { name = "Mode", value = "Roll" });

            Data.DocumentoRecebimento dp = new Data.DocumentoRecebimento();
            dp.idEmpresa = cartao.empresaRelacionamento.idEmpresa;
            dp.dataGeracao = DateTime.Now;
            dp.descricao = "Crédito Pré Pago";
            dp.idContaPagamento = (Data.ContaPagamento)Utils.Utils.listaDados(cartao.empresaRelacionamento.idEmpresa, contaPagamento, 1, _params)[0];
            dp.numeroDocumento = "S/N";
            dp.operacao = ENum.eOperacao.INCLUIR;
            dp.valorRecebido = valorAReceber;
            dp.dataMovimento = dp.dataGeracao;
            dp.dataVencimento = DateTime.Now;

            List<Data.DocumentoRecebimentoContasAReceber> listDpca = new List<Data.DocumentoRecebimentoContasAReceber>();
            Data.DocumentoRecebimentoContasAReceber dpca = new Data.DocumentoRecebimentoContasAReceber();
            dpca.contasAReceber = result;
            dpca.operacao = ENum.eOperacao.INCLUIR;
            dpca.valorBase = result.valor;
            dpca.valorRecebido = valorMovimento;
            dpca.valorMulta = 0;
            dpca.valorJuros = 0;
            dpca.valorDesconto = 0;
            dpca.valorINSSRetido = 0;
            dpca.valorISSRetido = 0;
            dpca.valorIRRetido = 0;
            dpca.valorPISRetido = 0;
            dpca.valorCM = 0;
            dpca.valorCOFINSRetido = 0;
            listDpca.Add(dpca);
            dp.documentoRecebimentoContasARecebers = listDpca.ToArray();

            dp = (Data.DocumentoRecebimento)Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).atualizar(dp);
            int idContaPagamentoMovimento = 0;
            if (dp != null)
            {
                Data.ContaPagamentoMovimento cpm = new Data.ContaPagamentoMovimento();
                cpm.operacao = ENum.eOperacao.INCLUIR;
                cpm.contaPagamento = dp.idContaPagamento;
                cpm.documentoRecebimento = dp;
                cpm.dataMovimento = dp.dataGeracao;
                cpm.descricao = dp.descricao;
                cpm.valor = dp.valorRecebido;
                cpm.observacao = "Crédito Pré Pago";
                cpm.dataVencimento = dp.dataVencimento;
                cpm.dataConciliacao = dp.dataGeracao;
                cpm.idFuncionario = idFuncionario;
                cpm = (Data.ContaPagamentoMovimento)Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).atualizar(cpm);
                idContaPagamentoMovimento = cpm.idContaPagamentoMovimento;

                foreach (var item in dp.documentoRecebimentoContasARecebers)
                {
                    if
                    (
                        (
                            item.valorRecebido +
                            (
                                item.valorMulta +
                                item.valorJuros +
                                item.valorCM
                            ) +
                            (
                                item.valorDesconto +
                                item.valorINSSRetido +
                                item.valorISSRetido +
                                item.valorIRRetido +
                                item.valorPISRetido +
                                item.valorCOFINSRetido +
                                item.valorCSLLRetido
                            )
                        ) > 0.0
                    )
                    {

                        if (item.idDocumentoRecebimentoContasAReceber <= 0)
                        {
                            Data.ContasAReceberPagamento _capp = new Data.ContasAReceberPagamento
                            {
                                operacao = ENum.eOperacao.INCLUIR,
                                idContasAReceber = item.contasAReceber.idContasAReceber,
                                idDocumentoRecebimento = dp.idDocumentoRecebimento,
                                dataMovimento = dp.dataMovimento,
                                contaPagamento = dp.idContaPagamento,
                                valorCM = item.valorCM,
                                valorCOFINSRetido = item.valorCOFINSRetido,
                                valorDesconto = item.valorDesconto,
                                valorCSLLRetido = item.valorCSLLRetido,
                                valorINSSRetido = item.valorINSSRetido,
                                valorIRRetido = item.valorIRRetido,
                                valorISSRetido = item.valorISSRetido,
                                valorJuros = item.valorJuros,
                                valorMulta = item.valorMulta,
                                valorPISRetido = item.valorPISRetido,
                                valorPrincipal = item.valorBase,
                                idFuncionario = idFuncionario
                                /*(
                                    item.valorRecebido -
                                    (
                                        item.valorMulta +
                                        item.valorJuros +
                                        item.valorCM
                                    ) +
                                    (
                                        item.valorDesconto +
                                        item.valorINSSRetido +
                                        item.valorISSRetido +
                                        item.valorIRRetido +
                                        item.valorPISRetido +
                                        item.valorCOFINSRetido +
                                        item.valorCSLLRetido
                                    )
                                )*/
                            };

                            Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).atualizar(_capp);
                        }
                        else { }
                    }
                    else { }
                }
            }
            else { }

            result = (Data.ContasAReceber)Utils.Utils.sr(cartao.empresaRelacionamento.idEmpresa).consultar(result);
            Hashtable retorno = new Hashtable();
            retorno["contasAReceber"] = result;
            retorno["idContaPagamentoMovimento"] = idContaPagamentoMovimento;
            return retorno;
        }

        public static Data.Cartao buscaCartao(string term)
        {
            String
                _filter = "";

            List<NameValue> _params = new List<NameValue>();

            long numeroCartao = 0;
            Int64.TryParse(term, out numeroCartao);

            _filter += (_filter.Length > 0 ? " AND" : "") + " (TRY_CAST(cartao.numeroCartao AS NUMERIC) = " + numeroCartao + " OR TRY_CAST(cartao.codigoBarras AS NUMERIC) = " + numeroCartao + " OR cartao.numeroRFID = '" + term + "' OR (cartao.numeroCartao = right(replicate('0',12) + convert(VARCHAR,'" + term + "'),12) OR cartao.codigoBarras = right(replicate('0',12) + convert(VARCHAR,'" + term + "'),12))) AND cartao.ativo = 's' AND cartao.dataCancelamento IS NULL";

            _params.Add(new NameValue { name = "Filter", value = _filter });
            Data.Cartao cartao = new Data.Cartao();
            try
            {
                cartao = (Data.Cartao)Utils.Utils.listaDados(0, cartao, 1, _params)[0]; //verificar
            }
            catch
            {
                cartao = null;
            }

            return cartao;
        }
    }
}
