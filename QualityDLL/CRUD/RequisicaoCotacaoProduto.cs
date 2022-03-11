using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace WS.CRUD
{
    public class RequisicaoCotacaoProdutoServico : WS.CRUD.Base
    {
        public RequisicaoCotacaoProdutoServico(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoCotacaoProdutoServico input = (Data.RequisicaoCotacaoProdutoServico)parametros["Key"];
            Tables.RequisicaoCotacaoProdutoServico bd = new Tables.RequisicaoCotacaoProdutoServico();

            bd.idRequisicaoCotacaoProdutoServico.isNull = true;
            bd.idRequisicaoCotacao.value = input.idRequisicaoCotacao;
            bd.idProdutoServico.value = input.idProdutoServico;
            bd.quantidadeAtendida.value = input.quantidadeAtendida;
            bd.quantidadePedida.value = input.quantidadePedida;
            bd.quantidadePedida.value = input.quantidadePedida;
            bd.quantidadeAprovada.value = input.quantidadeAprovada;
            bd.valor.value = input.valor;
            if (input.unidadeProdutoServico != null)
                bd.unidadeProdutoServico.idUnidadeProdutoServico.value = input.unidadeProdutoServico.idUnidadeProdutoServico;
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.RequisicaoCotacaoProdutoServico)parametros["Key"]).idRequisicaoCotacaoProdutoServico = (int)bd.idRequisicaoCotacaoProdutoServico.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoCotacaoProdutoServico input = (Data.RequisicaoCotacaoProdutoServico)parametros["Key"];
            Tables.RequisicaoCotacaoProdutoServico bd = (Tables.RequisicaoCotacaoProdutoServico)this.m_EntityManager.find
            (
                typeof(Tables.RequisicaoCotacaoProdutoServico),
                new Object[]
                {
                    input.idRequisicaoCotacaoProdutoServico
                }
            );

            bd.idRequisicaoCotacao.value = input.idRequisicaoCotacao;
            bd.idProdutoServico.value = input.idProdutoServico;
            bd.quantidadeAtendida.value = input.quantidadeAtendida;
            bd.quantidadePedida.value = input.quantidadePedida;
            bd.quantidadeAprovada.value = input.quantidadeAprovada;
            bd.valor.value = input.valor;
            if (input.unidadeProdutoServico != null)
                bd.unidadeProdutoServico.idUnidadeProdutoServico.value = input.unidadeProdutoServico.idUnidadeProdutoServico;
            else { }

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.RequisicaoCotacaoProdutoServico bd = new Tables.RequisicaoCotacaoProdutoServico();

            bd.idRequisicaoCotacaoProdutoServico.value = ((Data.RequisicaoCotacaoProdutoServico)parametros["Key"]).idRequisicaoCotacaoProdutoServico;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.RequisicaoCotacaoProdutoServico)bd).idRequisicaoCotacaoProdutoServico.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.RequisicaoCotacaoProdutoServico)input).operacao = ENum.eOperacao.NONE;

                    ((Data.RequisicaoCotacaoProdutoServico)input).idRequisicaoCotacaoProdutoServico = ((Tables.RequisicaoCotacaoProdutoServico)bd).idRequisicaoCotacaoProdutoServico.value;
                    ((Data.RequisicaoCotacaoProdutoServico)input).idRequisicaoCotacao = ((Tables.RequisicaoCotacaoProdutoServico)bd).idRequisicaoCotacao.value;
                    ((Data.RequisicaoCotacaoProdutoServico)input).idProdutoServico = ((Tables.RequisicaoCotacaoProdutoServico)bd).idProdutoServico.value;
                    ((Data.RequisicaoCotacaoProdutoServico)input).quantidadePedida = ((Tables.RequisicaoCotacaoProdutoServico)bd).quantidadePedida.value;
                    ((Data.RequisicaoCotacaoProdutoServico)input).quantidadeAtendida = ((Tables.RequisicaoCotacaoProdutoServico)bd).quantidadeAtendida.value;
                    ((Data.RequisicaoCotacaoProdutoServico)input).quantidadeAprovada = ((Tables.RequisicaoCotacaoProdutoServico)bd).quantidadeAprovada.value;
                    ((Data.RequisicaoCotacaoProdutoServico)input).valor = ((Tables.RequisicaoCotacaoProdutoServico)bd).valor.value;
                    ((Data.RequisicaoCotacaoProdutoServico)input).unidadeProdutoServico = (Data.UnidadeProdutoServico)(new WS.CRUD.UnidadeProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.UnidadeProdutoServico(),
                        ((Tables.RequisicaoCotacaoProdutoServico)bd).unidadeProdutoServico,
                        level + 1
                    );

                    try
                    {
                        List<Utils.NameValue> p = new List<Utils.NameValue>();
                        p.Add(new Utils.NameValue { name = "Key", value = new Data.ProdutoServico { idProdutoServico = ((Data.RequisicaoCotacaoProdutoServico)input).idProdutoServico } });
                        p.Add(new Utils.NameValue { name = "Mode", value = "Roll" });
                        ((Data.RequisicaoCotacaoProdutoServico)input).produtoServico = (Data.ProdutoServico)Utils.Utils.sr((long)this.m_IdEmpresaCorrente).listar(p.ToArray())[0];
                        p.Clear();
                        p = null;
                    }
                    catch { }

                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoCotacaoProdutoServico result = (Data.RequisicaoCotacaoProdutoServico)parametros["Key"];

            try
            {
                result = (Data.RequisicaoCotacaoProdutoServico)this.preencher
                (
                    new Data.RequisicaoCotacaoProdutoServico(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.RequisicaoCotacaoProdutoServico),
                        new Object[]
                        {
                            result.idRequisicaoCotacaoProdutoServico
                        }
                    ),
                    0
                );
            }
            catch (Exception e)
            {
                Utils.Utils.WriteLog(this.GetType().ToString() + ".consultar() -> " + e.ToString());
                throw new Exception(e.Message);
            }

            return result;
        }

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoCotacaoProdutoServico input = (Data.RequisicaoCotacaoProdutoServico)parametros["Key"];
            System.Collections.Generic.List<Data.Base> result = new System.Collections.Generic.List<Data.Base>();
            string mode = (string)(parametros["Mode"] == null ? "" : parametros["Mode"]);
            int level = (int)(parametros["Level"] == null ? 0 : parametros["Level"]);

            System.Collections.Hashtable makeSelectParams = new System.Collections.Hashtable();
            makeSelectParams["numRows"] = (parametros["Top"] == null ? 0 : (int)parametros["Top"]);
            makeSelectParams["where"] = (parametros["Filter"] == null ? "" : (String)parametros["Filter"]);
            makeSelectParams["orderBy"] = (parametros["Order"] == null ? "" : (String)parametros["Order"]);
            makeSelectParams["offSet"] = (parametros["Offset"] == null ? -1 : parametros["Offset"]);

            Report.Base report = (Report.Base)parametros["Report"];

            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> _fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();

                if (parametros["Filter"] != null)
                {
                    String
                        _filter = (String)parametros["Filter"],
                        _keys = "";

                    while (_filter.Contains("@"))
                    {
                        String _key = _filter.Substring(_filter.IndexOf("@")).Split(new char[] { ' ', ')' })[0];

                        if (!_keys.Contains("[" + _key + "]"))
                        {
                            _fieldKeys.Add((EJB.TableBase.TField)parametros[_key]);
                            _keys += "[" + _key + "]";
                        }
                        else { }

                        _filter = _filter.Substring(_filter.IndexOf("@") + _key.Length);
                    }
                }
                else { }

                String _select = this.makeSelect
                (
                    typeof(Tables.RequisicaoCotacaoProdutoServico),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.RequisicaoCotacaoProdutoServico _data in
                    (System.Collections.Generic.List<Tables.RequisicaoCotacaoProdutoServico>)this.m_EntityManager.list
                    (
                        typeof(Tables.RequisicaoCotacaoProdutoServico),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    //if (mode == "Roll")
                    //{
                    //_base = new Data.ResultadoConsulta();

                    //if (!_data.codConsCampo.codUsuario.isNull)
                    //{
                    //    ((Data.ResultadoConsulta)_base).codigo = (int)_data.codConsCampo.codUsuario.value;
                    //    ((Data.ResultadoConsulta)_base).descricao =
                    //    (
                    //        _data.descricao.value + "(" + _data.codConsCampo.idCadastro.nome.value + ")"
                    //    );
                    //}
                    //else
                    //{
                    //    ((Data.ResultadoConsulta)_base).codigo = (int)_data.codCarteira.value;
                    //    ((Data.ResultadoConsulta)_base).descricao = _data.descricao.value;
                    //}
                    //}
                    //else
                    _base = (Data.Base)this.preencher(new Data.RequisicaoCotacaoProdutoServico(), _data, level);

                    if (report != null)
                        report.ProcessRecord(_base);
                    else
                        result.Add(_base);
                }

                if (report != null)
                    report.ProcessRecord(null);
                else { }

                _fieldKeys.Clear();
                _fieldKeys = null;
                _select = null;
            }
            catch (Exception e)
            {
                Utils.Utils.WriteLog(this.GetType().ToString() + ".listar() -> " + e.ToString());
                throw new Exception(e.Message);
            }

            return ((result.Count > 0) ? result.ToArray() : null);
        }
    }
}
