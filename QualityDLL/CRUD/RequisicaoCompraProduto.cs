using System;

namespace WS.CRUD
{
    public class RequisicaoCompraProdutoServico : WS.CRUD.Base
    {
        public RequisicaoCompraProdutoServico(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoCompraProdutoServico input = (Data.RequisicaoCompraProdutoServico)parametros["Key"];
            Tables.RequisicaoCompraProdutoServico bd = new Tables.RequisicaoCompraProdutoServico();

            bd.idRequisicaoCompraProdutoServico.isNull = true;
            bd.idRequisicaoCompra.value = input.idRequisicaoCompra;
            bd.produtoServico.idProdutoServico.value = input.produtoServico.idProdutoServico;
            bd.unidadeProdutoServico.idUnidadeProdutoServico.value = input.unidadeProdutoServico.idUnidadeProdutoServico;

            bd.quantidade.value = input.quantidade;
            if ((input.fornecedor != null) && (input.fornecedor.idEmpresaRelacionamento > 0))
                bd.fornecedor.fornecedorEmpresaRelacionamento.idEmpresaRelacionamento.value = input.fornecedor.idEmpresaRelacionamento;
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.RequisicaoCompraProdutoServico)parametros["Key"]).idRequisicaoCompraProdutoServico = (int)bd.idRequisicaoCompraProdutoServico.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoCompraProdutoServico input = (Data.RequisicaoCompraProdutoServico)parametros["Key"];
            Tables.RequisicaoCompraProdutoServico bd = (Tables.RequisicaoCompraProdutoServico)this.m_EntityManager.find
            (
                typeof(Tables.RequisicaoCompraProdutoServico),
                new Object[]
                {
                    input.idRequisicaoCompraProdutoServico
                }
            );

            bd.idRequisicaoCompra.value = input.idRequisicaoCompra;
            bd.produtoServico.idProdutoServico.value = input.produtoServico.idProdutoServico;
            bd.unidadeProdutoServico.idUnidadeProdutoServico.value = input.unidadeProdutoServico.idUnidadeProdutoServico;
            bd.quantidade.value = input.quantidade;
            if ((input.fornecedor != null) && (input.fornecedor.idEmpresaRelacionamento > 0))
                bd.fornecedor.fornecedorEmpresaRelacionamento.idEmpresaRelacionamento.value = input.fornecedor.idEmpresaRelacionamento;
            else { }

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.RequisicaoCompraProdutoServico bd = new Tables.RequisicaoCompraProdutoServico();

            bd.idRequisicaoCompraProdutoServico.value = ((Data.RequisicaoCompraProdutoServico)parametros["Key"]).idRequisicaoCompraProdutoServico;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.RequisicaoCompraProdutoServico)bd).idRequisicaoCompraProdutoServico.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.RequisicaoCompraProdutoServico)input).operacao = ENum.eOperacao.NONE;

                    ((Data.RequisicaoCompraProdutoServico)input).idRequisicaoCompraProdutoServico = ((Tables.RequisicaoCompraProdutoServico)bd).idRequisicaoCompraProdutoServico.value;
                    ((Data.RequisicaoCompraProdutoServico)input).idRequisicaoCompra = ((Tables.RequisicaoCompraProdutoServico)bd).idRequisicaoCompra.value;
                    ((Data.RequisicaoCompraProdutoServico)input).produtoServico = (Data.ProdutoServico)(new WS.CRUD.ProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ProdutoServico(),
                        ((Tables.RequisicaoCompraProdutoServico)bd).produtoServico,
                        level + 1
                    );
                    ((Data.RequisicaoCompraProdutoServico)input).unidadeProdutoServico = (Data.UnidadeProdutoServico)(new WS.CRUD.UnidadeProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.UnidadeProdutoServico(),
                        ((Tables.RequisicaoCompraProdutoServico)bd).unidadeProdutoServico,
                        level + 1
                    );
                    ((Data.RequisicaoCompraProdutoServico)input).quantidade = ((Tables.RequisicaoCompraProdutoServico)bd).quantidade.value;
                    ((Data.RequisicaoCompraProdutoServico)input).fornecedor = (Data.Fornecedor)(new WS.CRUD.Fornecedor(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Fornecedor(),
                        ((Tables.RequisicaoCompraProdutoServico)bd).fornecedor,
                        level + 1
                    );

                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoCompraProdutoServico result = (Data.RequisicaoCompraProdutoServico)parametros["Key"];

            try
            {
                result = (Data.RequisicaoCompraProdutoServico)this.preencher
                (
                    new Data.RequisicaoCompraProdutoServico(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.RequisicaoCompraProdutoServico),
                        new Object[]
                        {
                            result.idRequisicaoCompraProdutoServico
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
            Data.RequisicaoCompraProdutoServico input = (Data.RequisicaoCompraProdutoServico)parametros["Key"];
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
                    typeof(Tables.RequisicaoCompraProdutoServico),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.RequisicaoCompraProdutoServico _data in
                    (System.Collections.Generic.List<Tables.RequisicaoCompraProdutoServico>)this.m_EntityManager.list
                    (
                        typeof(Tables.RequisicaoCompraProdutoServico),
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
                    _base = (Data.Base)this.preencher(new Data.RequisicaoCompraProdutoServico(), _data, level);

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
