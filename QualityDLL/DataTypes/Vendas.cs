using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using NFe.Classes.Servicos.Recepcao;
using NFe.Utils.Excecoes;
using System.Threading;
using ACBr.Net.Sat;
using NF;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;

namespace DataTypes
{
    public class Vendas
    {

        public static Hashtable cancelarVenda(long idEmpresa, int idPdvCompra, int idFuncionario, bool cancelarTotalmente = true)
        {

            bool
                useNfc = false;

            try
            {
                Hashtable
                    retorno = new Hashtable();

                Data.Empresa empresa = new Data.Empresa
                {
                    idEmpresa = (int)idEmpresa
                };
                empresa = (Data.Empresa)Utils.Utils.sr((int)idEmpresa).consultar(empresa);

                if (idPdvCompra == 0)
                    throw new Exception("Informar o ID da venda!");
                else { }

                if (idFuncionario == 0)
                    throw new Exception("Informar o funcionário responsável pelo cancelamento!");
                else { }

                Data.PdvCompra pdvCompra = new Data.PdvCompra
                {
                    idPdvCompra = idPdvCompra
                };
                pdvCompra = (Data.PdvCompra)Utils.Utils.sr(idEmpresa).consultar(pdvCompra);

                if (pdvCompra == null || (pdvCompra != null && pdvCompra.idPdvCompra == 0))
                    throw new Exception("Venda não encontrada!");
                else { }

                useNfc = true;
                if (useNfc)
                {
                    Data.MovimentoFiscal mf = new Data.MovimentoFiscal
                    {
                        pdvCompra = new Data.PdvCompra
                        {
                            idPdvCompra = idPdvCompra
                        },
                        serie = -1,
                        cancelada = "n"
                    };
                    try
                    {
                        mf = (Data.MovimentoFiscal)Utils.Utils.listaDados(idEmpresa, mf, 1)[0];
                    }
                    catch
                    {
                        mf = null;
                    }

                    if (mf != null)
                    {
                        switch (mf.tipoDocumento)
                        {

                            case 65:
                                {
                                    if (mf != null && mf.idMovimentoFiscal > 0)
                                    {
                                        retEnviNFe ret = null;
                                        if (mf.xmlRetorno != null && mf.xmlRetorno.Length > 0 && mf.status != ENum.eMovimentoFiscalStatus.cancelada)
                                        {
                                            string justificativa = String.Format("Cancelamento total da venda {0}", idPdvCompra.ToString());
                                            ret = DFe.Utils.FuncoesXml.XmlStringParaClasse<retEnviNFe>(Encoding.ASCII.GetString(mf.xmlRetorno));

                                            if (!String.IsNullOrEmpty(((retEnviNFe)ret).protNFe.infProt.nProt))
                                            {
                                                NF.Custom.RetornoCancelamento cancelar = null;
                                                string schema = Utils.Utils.GetSchemaDir();

                                                try
                                                {

                                                    int
                                                        maxTentativas = 3,
                                                        tentativa = 1;

                                                    while (tentativa <= maxTentativas)
                                                    {
                                                        try
                                                        {
                                                            cancelar = NF.EventosNFe.Cancelar((int)idEmpresa, ((retEnviNFe)ret).protNFe.infProt.nProt, ((retEnviNFe)ret).protNFe.infProt.chNFe, justificativa, empresa.pessoa.cpfCnpj, schema, mf.idMovimentoFiscal);
                                                            break;
                                                        }
                                                        catch (ComunicacaoException Ex)
                                                        {
                                                            if (tentativa == maxTentativas)
                                                                throw Ex;
                                                            else { }
                                                            Thread.Sleep(2000);
                                                            tentativa++;
                                                        }
                                                    }

                                                    if (cancelar == null)
                                                        throw new Exceptions.NFCException("Esta venda possui movimento fiscal.<br />Não foi possível cancelar pelo motivo: " + cancelar.motivo);
                                                    else { }
                                                }
                                                catch (Exception e)
                                                {
                                                    throw e;
                                                }
                                            }
                                            else { }
                                        }

                                        if (ret == null || (ret != null && ((retEnviNFe)ret).protNFe.infProt.nProt == null))
                                        {
                                            if (mf.status != ENum.eMovimentoFiscalStatus.cancelada)
                                            {
                                                Data.EventoNFe ev = new Data.EventoNFe
                                                {
                                                    movimentoFiscal = mf
                                                };
                                                foreach (Data.EventoNFe item in Utils.Utils.listaDados(empresa.idEmpresa, ev, 0))
                                                {
                                                    Data.EventoNFe _item = new Data.EventoNFe
                                                    {
                                                        idEventoNFe = item.idEventoNFe,
                                                        operacao = ENum.eOperacao.EXCLUIR
                                                    };
                                                    Utils.Utils.sr(empresa.idEmpresa).atualizar(ev);
                                                }

                                                mf.operacao = ENum.eOperacao.EXCLUIR;
                                                Utils.Utils.sr(empresa.idEmpresa).atualizar(mf);
                                            }
                                            else { }
                                        }
                                        else { }
                                    }
                                    else { }
                                    break;
                                }

                            case 59:
                                {
                                    if (mf != null && mf.idMovimentoFiscal > 0)
                                    {
                                        CFe ret = null;
                                        if (mf.xmlRetorno != null && mf.xmlRetorno.Length > 0 && mf.status != ENum.eMovimentoFiscalStatus.cancelada)
                                        {
                                            string justificativa = String.Format("Cancelamento total da venda {0}", idPdvCompra.ToString());
                                            try
                                            {
                                                ret = CFe.Load(Encoding.ASCII.GetString(mf.xmlRetorno));
                                                ret.InfCFe.Parent = null;
                                            }
                                            catch
                                            {
                                                ret = null;
                                            }

                                            if (ret != null)
                                            {

                                                try
                                                {

                                                    string jsonNota = JsonConvert.SerializeObject(ret, new JsonSerializerSettings()
                                                    {
                                                        TypeNameHandling = TypeNameHandling.All
                                                    });

                                                    if (pdvCompra.pdvEstacao == null)
                                                        pdvCompra = (Data.PdvCompra)Utils.Utils.sr(idEmpresa).consultar(pdvCompra);
                                                    else { }

                                                    Fiscal.SAT.FiscalSAT sat = new Fiscal.SAT.FiscalSAT(Convert.ToInt32(pdvCompra.numeroComanda), pdvCompra, null, null);
                                                    CFeCanc _cfe = sat.Cancelar(ret);
                                                    if (_cfe != null)
                                                    {
                                                        _cfe.InfCFe.Dest.Parent = null;
                                                        Data.EventoNFe evento = new Data.EventoNFe
                                                        {
                                                            dhEvento = (DateTime)_cfe.InfCFe.Ide.DhEmissao,
                                                            nProt = _cfe.InfCFe.Id,
                                                            nSeqEvento = _cfe.InfCFe.Ide.NCFe.ToString(),
                                                            xCorrecao = "",
                                                            descEvento = "Cancelamento nota #" + _cfe.InfCFe.Ide.NCFe,
                                                            xml = Encoding.Default.GetBytes(JsonConvert.SerializeObject(_cfe)),
                                                            xMotivo = justificativa,
                                                            cstat = 7000,
                                                            tipoEvento = (int)TipoEvento.CANCELAMENTO,
                                                            idEmpresa = (int)idEmpresa,
                                                            operacao = ENum.eOperacao.INCLUIR,
                                                            ambiente = mf.ambiente,
                                                            tipoDocumento = mf.tipoDocumento
                                                        };

                                                        if (mf.idMovimentoFiscal > 0)
                                                        {
                                                            evento.movimentoFiscal = new Data.MovimentoFiscal
                                                            {
                                                                idMovimentoFiscal = mf.idMovimentoFiscal,
                                                            };
                                                            evento.movimentoFiscal = (Data.MovimentoFiscal)Utils.Utils.sr(idEmpresa).consultar(evento.movimentoFiscal);
                                                            if (evento.movimentoFiscal != null && evento.movimentoFiscal.idMovimentoFiscal > 0)
                                                            {
                                                                evento.movimentoFiscal.cancelada = "s";
                                                                evento.movimentoFiscal.operacao = ENum.eOperacao.ALTERAR;
                                                            }
                                                            else { }
                                                        }
                                                        else { }

                                                        evento = (Data.EventoNFe)Utils.Utils.sr(idEmpresa).atualizar(evento);
                                                    }
                                                    else { }
                                                    break;
                                                }
                                                catch (Exception Ex)
                                                {
                                                    throw Ex;
                                                }

                                            }
                                            else { }
                                        }

                                        if (ret == null)
                                        {
                                            if (mf.status != ENum.eMovimentoFiscalStatus.cancelada)
                                            {
                                                Data.EventoNFe ev = new Data.EventoNFe
                                                {
                                                    movimentoFiscal = mf
                                                };
                                                foreach (Data.EventoNFe item in Utils.Utils.listaDados(empresa.idEmpresa, ev, 0))
                                                {
                                                    Data.EventoNFe _item = new Data.EventoNFe
                                                    {
                                                        idEventoNFe = item.idEventoNFe,
                                                        operacao = ENum.eOperacao.EXCLUIR
                                                    };
                                                    Utils.Utils.sr(empresa.idEmpresa).atualizar(ev);
                                                }
                                            }
                                            else { }
                                        }
                                        else { }
                                    }
                                    else { }
                                    break;
                                }
                        }
                    }
                    else { }
                }

                List<Data.EmpresaRelacionamentoCartaoMovimento> estornosPrePagos = new List<Data.EmpresaRelacionamentoCartaoMovimento>();

                /* Cancelando a requisição */
                Data.PdvCompra _c = null;
                if (pdvCompra != null)
                {
                    pdvCompra.contasAReceber = (Data.ContasAReceber)Utils.Utils.sr(idEmpresa).consultar(pdvCompra.contasAReceber);
                    if (pdvCompra.contasAReceber != null && pdvCompra.contasAReceber.idContasAReceber > 0)

                        if (pdvCompra.contasAReceber.contasAReceberPagamentos != null)
                            foreach (Data.ContasAReceberPagamento crp in pdvCompra.contasAReceber.contasAReceberPagamentos)
                                estornarVenda(idEmpresa, crp, true);
                        else { }
                    else { }

                    /* Removendo recebimentos pré pagos */
                    {
                        List<Data.Base> pagamentosPrePagos = buscaPagamentosPrePagos(idEmpresa, pdvCompra, new string[] { "PR", "PP" }, "V");

                        foreach (Data.EmpresaRelacionamentoCartaoMovimento _item in pagamentosPrePagos)
                        {

                            Data.EmpresaRelacionamentoCartaoMovimento item = new Data.EmpresaRelacionamentoCartaoMovimento
                            {
                                idEmpresaRelacionamentoCartaoMovimento = _item.idEmpresaRelacionamentoCartaoMovimento
                            };
                            //item = (Data.EmpresaRelacionamentoCartaoMovimento)Utils.Utils.sr(idEmpresa).consultar(item);
                            item = (Data.EmpresaRelacionamentoCartaoMovimento)Utils.Utils.listaDados(idEmpresa, item, 1, new List<Utils.NameValue>() { new Utils.NameValue { name = "Mode", value = "Roll" } })[0];
                            /*if (item.flagEstornoDevolucao)
                                throw new Exception("Este pagamento já foi estornado / devolvido!");
                            else { }*/

                            if (item != null && item.idEmpresaRelacionamentoCartaoMovimento > 0 && !item.flagEstornoDevolucao)
                            {
                                item.pdvEstacao = (Data.PdvEstacao)Utils.Utils.listaDados(idEmpresa, item.pdvEstacao, 1, new List<Utils.NameValue>() { new Utils.NameValue { name = "Mode", value = "Roll" } })[0];

                                Hashtable parametros = new Hashtable();
                                parametros["valorMovimento"] = item.valorMovimento;
                                parametros["valorDesconto"] = item.valorDesconto;
                                parametros["tipoMovimento"] = item.tipoMovimento;
                                parametros["tipoOperacao"] = "D";
                                parametros["numeroDocumento"] = "";

                                parametros["idNaturezaOperacao"] = item.pdvEstacao.prePagoNaturezaOperacao.idNaturezaOperacao;
                                parametros["idDepartamento"] = item.pdvEstacao.prePagoDepartamento.idDepartamento;
                                parametros["idEmpresaRelacionamentoFuncionario"] = idFuncionario;
                                parametros["idEmpresaRelacionamentoCartaoMovimentoReferencia"] = item.idEmpresaRelacionamentoCartaoMovimento;
                                parametros["pdvCompra"] = item.pdvCompra;
                                parametros["cancelarVenda"] = false;
                                if (item.empresaRelacionamentoCartao.empresaRelacionamento == null)
                                    item.empresaRelacionamentoCartao = (Data.EmpresaRelacionamentoCartao)Utils.Utils.listaDados(idEmpresa, item.empresaRelacionamentoCartao, 1, new List<Utils.NameValue>() { new Utils.NameValue { name = "Mode", value = "Roll" } })[0];
                                else { }
                                Data.EmpresaRelacionamentoCartaoMovimento movEstorno = CartaoConsumo.CartaoConsumo.criaMovimento(item.empresaRelacionamentoCartao, parametros, "D");

                                if (item.tipoMovimento == "PP")
                                    if (item.contasAReceber != null && item.contasAReceber.idContasAReceber > 0)
                                    {
                                        item.contasAReceber = (Data.ContasAReceber)Utils.Utils.listaDados(idEmpresa, item.contasAReceber, 1, null)[0];
                                        if (item.contasAReceber.contasAReceberPagamentos != null)
                                            foreach (Data.ContasAReceberPagamento crp in item.contasAReceber.contasAReceberPagamentos)
                                                estornarVenda(idEmpresa, crp, true);
                                        else { }
                                    }
                                    else { }
                                else { }

                                if (movEstorno != null && movEstorno.idEmpresaRelacionamentoCartaoMovimento > 0)
                                {
                                    retirarDescontoItem(idEmpresa, item.pdvCompra, movEstorno.valorDesconto);
                                    estornosPrePagos.Add(item);
                                }
                                else { }
                            }
                            else { }
                        }

                        retorno["estornosPrePagos"] = estornosPrePagos;
                    }

                    if (pdvCompra.statusCompra == "C")
                        throw new Exception("Não é possível finalizar esta venda, pois ela já está cancelada!");
                    else { }

                    _c = pdvCompra;
                    _c.statusCompra = (cancelarTotalmente ? "C" : "A");
                    _c.operacao = ENum.eOperacao.ALTERAR;
                    //_c.contasAReceber = null;
                    Data.RequisicaoInterna _riTemp = null;

                    if (_c.pdvCompraTaxaServico != null)
                    {
                        for (int i = 0; i < _c.pdvCompraTaxaServico.Length; i++)
                        {
                            _c.pdvCompraTaxaServico[i].operacao = ENum.eOperacao.EXCLUIR;
                            _c.pdvCompraTaxaServico[i] = (Data.PdvCompraTaxaServico)Utils.Utils.sr(idEmpresa).atualizar(_c.pdvCompraTaxaServico[i]);
                        }
                        _c.pdvCompraTaxaServico = null;
                    }
                    else { }

                    if (cancelarTotalmente)
                    {
                        for (int i = 0; (_c.pdvCompraCupons != null && i < _c.pdvCompraCupons.Length); i++)
                        {
                            _c.pdvCompraCupons[i].operacao = ENum.eOperacao.ALTERAR;
                            _c.pdvCompraCupons[i].statusCupom = "C";

                            if (_c.pdvCompraCupons[i].pdvCompraCupomItem == null || (_c.pdvCompraCupons[i].pdvCompraCupomItem != null && _c.pdvCompraCupons[i].pdvCompraCupomItem.Length == 0))
                            {
                                /* Removendo requisicao em branco */

                                _riTemp = _c.pdvCompraCupons[i].requisicaoInterna;
                                _riTemp.operacao = ENum.eOperacao.EXCLUIR;
                                _c.pdvCompraCupons[i].requisicaoInterna = null;
                            }
                            else { }
                        }

                        _c = (Data.PdvCompra)Utils.Utils.sr(idEmpresa).atualizar(_c);

                        if (_riTemp != null)
                            Utils.Utils.sr(0).atualizar(_riTemp);

                        if (_c != null && _c.idPdvCompra > 0)
                        {
                            pdvCompra = _c;
                            /*
                             * Cancelar contas a receber */
                            if (pdvCompra.contasAReceber != null && pdvCompra.contasAReceber.idContasAReceber > 0)
                            {
                                pdvCompra.contasAReceber.operacao = ENum.eOperacao.ALTERAR;
                                pdvCompra.contasAReceber.dataCancelamento = DateTime.Now;
                                pdvCompra.contasAReceber = (Data.ContasAReceber)Utils.Utils.sr(idEmpresa).atualizar(pdvCompra.contasAReceber);
                            }
                            else { }

                            devolverEstoque(idEmpresa, _c, idFuncionario);
                            devolverEstoqueComposicao(idEmpresa, _c, idFuncionario);
                            Data.PdvCompraStatus pdvStatus = null;
                            {
                                try
                                {
                                    pdvStatus = new Data.PdvCompraStatus
                                    {
                                        pdvCompra = pdvCompra,
                                        statusVenda = pdvCompra.statusCompra
                                    };
                                    pdvStatus = (Data.PdvCompraStatus)Utils.Utils.sr(idEmpresa).consultar(pdvStatus);

                                    if (pdvStatus == null || (pdvStatus != null && pdvStatus.idPdvCompraStatus == 0))
                                        throw new Exception("");
                                }
                                catch
                                {

                                    pdvStatus = new Data.PdvCompraStatus
                                    {
                                        pdvCompra = pdvCompra,
                                        statusVenda = pdvCompra.statusCompra,
                                        data = DateTime.Now,
                                        funcionario = new Data.Funcionario
                                        {
                                            idEmpresaRelacionamento = idFuncionario
                                        },
                                        operacao = ENum.eOperacao.INCLUIR
                                    };
                                    pdvStatus = (Data.PdvCompraStatus)Utils.Utils.sr(idEmpresa).atualizar(pdvStatus);
                                }
                            }
                        }
                        else { }
                    }
                    else
                    {
                        Data.PdvCompraStatus pdvStatus = new Data.PdvCompraStatus
                        {
                            pdvCompra = _c,
                            statusVenda = _c.statusCompra,
                            data = DateTime.Now,
                            funcionario = new Data.Funcionario
                            {
                                idEmpresaRelacionamento = idFuncionario
                            },
                            operacao = ENum.eOperacao.INCLUIR
                        };
                        pdvStatus = (Data.PdvCompraStatus)Utils.Utils.sr(idEmpresa).atualizar(pdvStatus);
                        _c = (Data.PdvCompra)Utils.Utils.sr(idEmpresa).atualizar(_c);
                    }
                    return retorno;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return null;
        }

        public static bool cancelarCupom(int idEmpresa, int idPdvCompraCupom, int idFuncionario)
        {
            try
            {
                if (idEmpresa == 0)
                    throw new Exception("Informar o ID da empresa!");
                else { }

                if (idPdvCompraCupom == 0)
                    throw new Exception("Informar o ID do cupom!");
                else { }

                if (idFuncionario == 0)
                    throw new Exception("Informar o ID do funcionário!");
                else { }

                Data.PdvCompraCupom pcc = new Data.PdvCompraCupom
                {
                    idPdvCompraCupom = idPdvCompraCupom
                };

                pcc = (Data.PdvCompraCupom)Utils.Utils.listaDados(idEmpresa, pcc, 1, null)[0];
                if (pcc != null)
                {
                    devolverEstoque(idEmpresa, pcc, idFuncionario);
                    pcc.operacao = ENum.eOperacao.ALTERAR;
                    pcc.statusCupom = "C";
                    pcc = (Data.PdvCompraCupom)Utils.Utils.sr(idEmpresa).atualizar(pcc);

                    return (pcc.statusCupom == "C" ? true : false);
                }
                else { }
            }
            catch (Exception e)
            {
                throw e;
            }

            return false;
        }

        public static List<Data.Base> buscaPagamentosPrePagos(long idEmpresa, Data.PdvCompra compra, string[] tipoMovimento, string tipoOperacao = "V")
        {

            List<Data.Base> pagamentosPrePago = new List<Data.Base>();
            List<Utils.NameValue> _params = new List<Utils.NameValue>();
            _params.Add(new Utils.NameValue { name = "Mode", value = "Roll" });

            Data.EmpresaRelacionamentoCartaoMovimento _key = new Data.EmpresaRelacionamentoCartaoMovimento();
            if (tipoOperacao == "V")
                _key.pdvCompra = compra;
            else
                _key.pdvCompra = null;

            _key.tipoOperacao = tipoOperacao;

            string _filter = "";
            if (tipoMovimento.Length > 0)
            {
                int i = 0;
                _filter += "(empresaRelacionamentoCartaoMovimento.tipoMovimento IN (";
                foreach (string item in tipoMovimento)
                {
                    _filter += "'" + item + "'";
                    _filter += (tipoMovimento.Length - 1) > i ? ", " : null;
                    i++;
                }
                _filter += "))";
            }

            _params.Add(new Utils.NameValue { name = "Filter", value = _filter });
            pagamentosPrePago.AddRange(Utils.Utils.listaDados(idEmpresa, _key, 0, _params));

            return pagamentosPrePago;
        }

        public static void retirarDescontoItem(long idEmpresa, Data.PdvCompra compra, double valorDesconto)
        {
            try
            {
                if (compra.idPdvCompra == 0)
                    throw new Exception("");
                else { }
                compra = (Data.PdvCompra)Utils.Utils.listaDados(idEmpresa, compra, 1)[0];
            }
            catch
            {
                compra = null;
            }

            if (compra != null)
            {
                compra.pdvCompraCupons = listaCupons(idEmpresa, compra).Cast<Data.PdvCompraCupom>().ToArray();
                Double
                    descontoTotal = valorDesconto,
                    descontoAplicado = 0,
                    novoDesconto = 0,
                    valorTotal = 0;

                int
                    i = 1,
                    totalItens = 0;
                try
                {
                    valorTotal = compra.pdvCompraCupons.Sum(X => X.pdvCompraCupomItem.Sum(Z => Z.valor));
                    totalItens = compra.pdvCompraCupons.Sum(X => X.pdvCompraCupomItem.Length);
                }
                catch
                {
                    valorTotal = 0;
                    totalItens = 0;
                }

                if (compra.pdvCompraCupons != null)
                {
                    foreach (Data.PdvCompraCupom _c in compra.pdvCompraCupons)
                    {
                        Data.PdvCompraCupom _cupom = (Data.PdvCompraCupom)Utils.Utils.sr(idEmpresa).consultar(_c);
                        if (_cupom.pdvCompraCupomItem != null)
                        {
                            foreach (Data.PdvCompraCupomItem item in _cupom.pdvCompraCupomItem)
                            {

                                Data.PdvCompraCupomItem _i = item;
                                if (descontoTotal > 0)
                                {
                                    novoDesconto = Convert.ToDouble(((descontoTotal * _i.valor) / valorTotal).ToString("0.00"));
                                    if (totalItens == i)
                                        novoDesconto = Convert.ToDouble((descontoTotal - descontoAplicado).ToString("0.00"));
                                    else { }
                                    _i.desconto -= novoDesconto;
                                    descontoAplicado = Convert.ToDouble((descontoAplicado + novoDesconto).ToString("0.00"));
                                    _i.operacao = ENum.eOperacao.ALTERAR;
                                    _i = (Data.PdvCompraCupomItem)Utils.Utils.sr(idEmpresa).atualizar(_i);
                                }
                                else { }
                                i++;
                            }
                        }
                        else { }
                    }
                }
                else { }
            }
            else { }
        }

        public static List<Data.Base> listaCupons(long idEmpresa, Data.PdvCompra pc, List<Utils.NameValue> _params = null)
        {
            List<Data.Base> results = new List<Data.Base>();
            Data.PdvCompraCupom key = new Data.PdvCompraCupom
            {
                pdvCompra = pc
            };
            results.AddRange(Utils.Utils.listaDados(idEmpresa, key, 0, _params));
            return results;
        }

        public static bool estornarVenda(long idEmpresa, Data.ContasAReceberPagamento crp, bool cancelarVenda = false)
        {
            try
            {
                crp = (Data.ContasAReceberPagamento)Utils.Utils.sr(idEmpresa).consultar(crp);
                Data.ContasAReceber cr = null;
                if (crp != null && crp.idContasAReceberPagamento > 0)
                {
                    Data.DocumentoRecebimento dr = new Data.DocumentoRecebimento { idDocumentoRecebimento = crp.idDocumentoRecebimento };
                    cr = (Data.ContasAReceber)Utils.Utils.sr(idEmpresa).consultar(new Data.ContasAReceber { idContasAReceber = crp.idContasAReceber });

                    /* Removendo contas a receber pagamento */
                    crp.operacao = ENum.eOperacao.EXCLUIR;
                    Utils.Utils.sr(idEmpresa).atualizar(crp);

                    /* Removendo movimentos */
                    Data.ContaPagamentoMovimento cpm = new Data.ContaPagamentoMovimento { documentoRecebimento = dr };
                    foreach (Data.ContaPagamentoMovimento _cpm in Utils.Utils.listaDados(idEmpresa, cpm, 0))
                    {
                        _cpm.operacao = ENum.eOperacao.EXCLUIR;
                        Utils.Utils.sr(idEmpresa).atualizar(_cpm);
                    }

                    dr = (Data.DocumentoRecebimento)Utils.Utils.sr(idEmpresa).consultar(dr);
                    if (dr != null && dr.idDocumentoRecebimento > 0)
                    {
                        dr.operacao = ENum.eOperacao.ALTERAR;
                        dr.dataCancelamento = DateTime.Now;
                        Utils.Utils.sr(idEmpresa).atualizar(dr);
                    }
                    else { }

                    List<Data.Base> drcr = new List<Data.Base>();
                    if (dr.idDocumentoRecebimento > 0)
                    {
                        Data.DocumentoRecebimentoContasAReceber _drcr = new Data.DocumentoRecebimentoContasAReceber { idDocumentoRecebimento = dr.idDocumentoRecebimento };
                        drcr.AddRange(Utils.Utils.listaDados(idEmpresa, _drcr, 0));
                    }
                    else { }

                    if (drcr != null)
                    {
                        foreach (Data.DocumentoRecebimentoContasAReceber item in drcr)
                        {
                            /* Removendo o documento recebimento contas a receber */
                            Data.DocumentoRecebimentoContasAReceber itemDRCR = new Data.DocumentoRecebimentoContasAReceber { idDocumentoRecebimentoContasAReceber = item.idDocumentoRecebimentoContasAReceber };
                            itemDRCR.operacao = ENum.eOperacao.EXCLUIR;
                            Utils.Utils.sr(idEmpresa).atualizar(itemDRCR);
                        }
                    }
                    else { }

                    if (cancelarVenda && cr.dataCancelamento.Ticks == 0)
                    {
                        cr.contasAReceberPagamentos = cr.contasAReceberPagamentos.Where(X => X.idContasAReceberPagamento != crp.idContasAReceberPagamento).ToArray();
                        if (cr.contasAReceberItems != null)
                            for (int i = 0; i < cr.contasAReceberItems.Length; i++)
                            {
                                cr.contasAReceberItems[i].operacao = ENum.eOperacao.ALTERAR;
                                cr.contasAReceberItems[i].pdvCompraCupomItem = null;
                            }
                        else { }
                        cr.dataCancelamento = DateTime.Now;
                        cr.operacao = ENum.eOperacao.ALTERAR;
                        cr.emAberto = "N";
                        cr = (Data.ContasAReceber)Utils.Utils.sr(idEmpresa).atualizar(cr);
                    }
                    else { }

                }
                else { }

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void devolverEstoque(long idEmpresa, Data.PdvCompra pdvCompra, int idFuncionario)
        {

            if (pdvCompra != null && pdvCompra.idPdvCompra > 0)
            {
                foreach (Data.PdvCompraCupom pcc in listaCupons(idEmpresa, pdvCompra))
                {
                    if (pcc.requisicaoInterna != null && pcc.requisicaoInterna.idRequisicaoInterna > 0)
                    {
                        Data.RequisicaoInterna ri = pcc.requisicaoInterna;
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
                            _ris.funcionario = new Data.Funcionario { idEmpresaRelacionamento = idFuncionario };
                            _ris.dataSituacao = DateTime.Now;
                            _ris.situacao = "C";
                            _ris.operacao = ENum.eOperacao.INCLUIR;
                            situacoes.Add(_ris);
                        }
                        else { }
                        ri.requisicaoInternaSituacaos = situacoes.ToArray();
                        ri = (Data.RequisicaoInterna)Utils.Utils.sr(idEmpresa).atualizar(ri);

                        if (ri != null && ri.idRequisicaoInterna > 0)
                            pcc.requisicaoInterna = ri;
                        else { }
                    }
                    else { }
                }
            }
            else { }
        }

        public static void devolverEstoqueComposicao(long idEmpresa, Data.PdvCompra pdvCompra, int idFuncionario)
        {

            if (pdvCompra != null && pdvCompra.idPdvCompra > 0)
            {
                foreach (Data.PdvCompraCupom pcc in listaCupons(idEmpresa, pdvCompra))
                {
                    if (pcc.pdvCompraCupomItem == null)
                        return;
                    else { }
                    foreach (Data.PdvCompraCupomItem pcci in pcc.pdvCompraCupomItem)
                    {
                        if (pcci.requisicaoInternaComposicao != null && pcci.requisicaoInternaComposicao.idRequisicaoInterna > 0)
                        {
                            Data.RequisicaoInterna ri = pcci.requisicaoInternaComposicao;
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
                                _ris.funcionario = new Data.Funcionario { idEmpresaRelacionamento = idFuncionario };
                                _ris.dataSituacao = DateTime.Now;
                                _ris.situacao = "C";
                                _ris.operacao = ENum.eOperacao.INCLUIR;
                                situacoes.Add(_ris);
                            }
                            else { }
                            ri.requisicaoInternaSituacaos = situacoes.ToArray();
                            ri = (Data.RequisicaoInterna)Utils.Utils.sr(idEmpresa).atualizar(ri);

                            if (ri != null && ri.idRequisicaoInterna > 0)
                                pcc.requisicaoInterna = ri;
                            else { }
                        }
                        else { }
                    }
                }
            }
            else { }
        }

        public static void devolverEstoque(long idEmpresa, Data.PdvCompraCupom pdvCompraCupom, int idFuncionario)
        {
            Data.PdvCompraCupom pcc = pdvCompraCupom;
            if (pcc != null && pcc.idPdvCompraCupom > 0)
            {
                if (pcc.requisicaoInterna != null && pcc.requisicaoInterna.idRequisicaoInterna > 0)
                {
                    Data.RequisicaoInterna ri = pcc.requisicaoInterna;
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
                        _ris.funcionario = new Data.Funcionario { idEmpresaRelacionamento = idFuncionario };
                        _ris.dataSituacao = DateTime.Now;
                        _ris.situacao = "C";
                        _ris.operacao = ENum.eOperacao.INCLUIR;
                        situacoes.Add(_ris);
                    }
                    else { }
                    ri.requisicaoInternaSituacaos = situacoes.ToArray();
                    ri = (Data.RequisicaoInterna)Utils.Utils.sr(idEmpresa).atualizar(ri);

                    if (ri != null && ri.idRequisicaoInterna > 0)
                        pcc.requisicaoInterna = ri;
                    else { }
                }
                else { }
            }
            else { }
        }

        public static List<Data.ProdutoServicoComposicao> buscaProdutoServicoComposicao(long idEmpresa, Data.ProdutoServico produto)
        {

            if (produto != null && produto.idProdutoServico > 0)
            {
                if (produto.produtoServicoComposicaos == null)
                {
                    List<Data.ProdutoServicoComposicao> listPsc = new List<Data.ProdutoServicoComposicao>();
                    Data.ProdutoServicoComposicao psc = new Data.ProdutoServicoComposicao
                    {
                        idProdutoServico = produto.idProdutoServico
                    };

                    foreach (Data.ProdutoServicoComposicao item in Utils.Utils.listaDados(idEmpresa, psc, 0, null))
                        listPsc.Add(item);

                    return listPsc;

                }
                else { }
            }
            else { }

            return null;
        }
    }
}
