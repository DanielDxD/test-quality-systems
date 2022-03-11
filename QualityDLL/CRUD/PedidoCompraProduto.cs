using System;

namespace WS.CRUD
{
    public class PedidoCompraProdutoServico : WS.CRUD.Base
    {
        public PedidoCompraProdutoServico(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PedidoCompraProdutoServico input = (Data.PedidoCompraProdutoServico)parametros["Key"];
            Tables.PedidoCompraProdutoServico bd = new Tables.PedidoCompraProdutoServico();

            bd.idPedidoCompraProdutoServico.isNull = true;
            bd.idPedidoCompra.value = input.idPedidoCompra;
            bd.produtoServico.idProdutoServico.value = input.produtoServico.idProdutoServico;
            bd.unidadeProdutoServico.idUnidadeProdutoServico.value = input.unidadeProdutoServico.idUnidadeProdutoServico;
            bd.quantidade.value = input.quantidade;
            bd.valor.value = input.valor;
            if (input.idRequisicaoCotacaoProdutoServico > 0)
                bd.idRequisicaoCotacaoProdutoServico.value = input.idRequisicaoCotacaoProdutoServico;
            else
                bd.idRequisicaoCotacaoProdutoServico.isNull = true;

            this.m_EntityManager.persist(bd);

            ((Data.PedidoCompraProdutoServico)parametros["Key"]).idPedidoCompraProdutoServico = (int)bd.idPedidoCompraProdutoServico.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PedidoCompraProdutoServico input = (Data.PedidoCompraProdutoServico)parametros["Key"];
            Tables.PedidoCompraProdutoServico bd = (Tables.PedidoCompraProdutoServico)this.m_EntityManager.find
            (
                typeof(Tables.PedidoCompraProdutoServico),
                new Object[]
                {
                    input.idPedidoCompraProdutoServico
                }
            );

            bd.idPedidoCompra.value = input.idPedidoCompra;
            bd.produtoServico.idProdutoServico.value = input.produtoServico.idProdutoServico;
            bd.unidadeProdutoServico.idUnidadeProdutoServico.value = input.unidadeProdutoServico.idUnidadeProdutoServico;
            bd.quantidade.value = input.quantidade;
            bd.valor.value = input.valor;
            if (input.idRequisicaoCotacaoProdutoServico > 0)
                bd.idRequisicaoCotacaoProdutoServico.value = input.idRequisicaoCotacaoProdutoServico;
            else
                bd.idRequisicaoCotacaoProdutoServico.isNull = true;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PedidoCompraProdutoServico bd = new Tables.PedidoCompraProdutoServico();

            bd.idPedidoCompraProdutoServico.value = ((Data.PedidoCompraProdutoServico)parametros["Key"]).idPedidoCompraProdutoServico;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PedidoCompraProdutoServico)bd).idPedidoCompraProdutoServico.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PedidoCompraProdutoServico)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PedidoCompraProdutoServico)input).idPedidoCompraProdutoServico = ((Tables.PedidoCompraProdutoServico)bd).idPedidoCompraProdutoServico.value;
                    ((Data.PedidoCompraProdutoServico)input).idPedidoCompra = ((Tables.PedidoCompraProdutoServico)bd).idPedidoCompra.value;
                    ((Data.PedidoCompraProdutoServico)input).produtoServico = (Data.ProdutoServico)(new WS.CRUD.ProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ProdutoServico(),
                        ((Tables.PedidoCompraProdutoServico)bd).produtoServico,
                        level + 1
                    );
                    ((Data.PedidoCompraProdutoServico)input).unidadeProdutoServico = (Data.UnidadeProdutoServico)(new WS.CRUD.UnidadeProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.UnidadeProdutoServico(),
                        ((Tables.PedidoCompraProdutoServico)bd).unidadeProdutoServico,
                        level + 1
                    );
                    ((Data.PedidoCompraProdutoServico)input).quantidade = ((Tables.PedidoCompraProdutoServico)bd).quantidade.value;
                    ((Data.PedidoCompraProdutoServico)input).valor = ((Tables.PedidoCompraProdutoServico)bd).valor.value;
                    ((Data.PedidoCompraProdutoServico)input).idRequisicaoCotacaoProdutoServico = ((Tables.PedidoCompraProdutoServico)bd).idRequisicaoCotacaoProdutoServico.value;
                    try
                    {
                        ((Data.PedidoCompraProdutoServico)input).valorUltimaCompra = ((Data.PedidoCompraProdutoServico)input).produtoServico.valorUltimaCompra;
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
            Data.PedidoCompraProdutoServico result = (Data.PedidoCompraProdutoServico)parametros["Key"];

            try
            {
                result = (Data.PedidoCompraProdutoServico)this.preencher
                (
                    new Data.PedidoCompraProdutoServico(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.PedidoCompraProdutoServico),
                        new Object[]
                        {
                            result.idPedidoCompraProdutoServico
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

        public override String makeSelect(Type classBase, Data.Base input, Object _fieldKeys, System.Collections.Hashtable _params = null)
        {
            String
                result = "",
                sqlWhere = "",
                sqlOrderBy = "";

            int
                numRows = 0,
                offSet = -1;

            bool onlyCount = false;

            if (_params != null)
            {
                if (_params.ContainsKey("numRows"))
                    numRows = (int)_params["numRows"];
                else { }

                if (_params.ContainsKey("onlyCount"))
                    onlyCount = (bool)_params["onlyCount"];
                else { }

                if (_params.ContainsKey("offSet"))
                    offSet = (int)_params["offSet"];
                else { }

                if (_params.ContainsKey("where"))
                    sqlWhere = ((String)_params["where"] ?? "");
                else { }

                if (_params.ContainsKey("orderBy"))
                    sqlOrderBy = ((String)_params["orderBy"] ?? "");
                else { }
            }
            else { }

            Data.PedidoCompraProdutoServico _input = (Data.PedidoCompraProdutoServico)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                if (_input.idPedidoCompra > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   pedidoCompraProdutoServico.idPedidoCompra = @idPedidoCompra");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPedidoCompra", _input.idPedidoCompra));
                    if (!sqlOrderBy.Contains("pedidoCompraProdutoServico.idPedidoCompra"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pedidoCompraProdutoServico.idPedidoCompra");
                    else { }
                }
                else { }

                if (_input.idPedidoCompraProdutoServico > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   pedidoCompraProdutoServico.idPedidoCompraProdutoServico = @idPedidoCompraProdutoServico");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPedidoCompraProdutoServico", _input.idPedidoCompra));
                    if (!sqlOrderBy.Contains("pedidoCompraProdutoServico.idPedidoCompraProdutoServico"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pedidoCompraProdutoServico.idPedidoCompraProdutoServico");
                    else { }
                }
                else { }

                if (_input.produtoServico != null)
                {
                    if (_input.produtoServico.idProdutoServico > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   pedidoCompraProdutoServico.idProdutoServico = @idProdutoServico");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idProdutoServico", _input.produtoServico.idProdutoServico));
                        if (!sqlOrderBy.Contains("pedidoCompraProdutoServico.idProdutoServico"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pedidoCompraProdutoServico.idProdutoServico");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.unidadeProdutoServico != null)
                {
                    if (_input.unidadeProdutoServico.idUnidadeProdutoServico > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   pedidoCompraProdutoServico.idUnidadeProdutoServico = @idUnidadeProdutoServico");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idUnidadeProdutoServico", _input.unidadeProdutoServico.idUnidadeProdutoServico));
                        if (!sqlOrderBy.Contains("pedidoCompraProdutoServico.idUnidadeProdutoServico"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pedidoCompraProdutoServico.idUnidadeProdutoServico");
                        else { }
                    }
                    else { }
                }
                else { }
                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "pedidoCompraProdutoServico.* ") +
                    "from \n" +
                    (
                        "pedidoCompraProdutoServico pedidoCompraProdutoServico\n" +
                        "   inner join pedidoCompraServico pedidoCompraServico\n" +
                        "       on  pedidoCompraServico.idPedidoCompra = pedidoCompraProdutoServico.idPedidoCompra\n"
                    ) +
                    (sqlWhere.Length > 0 ? "where " + sqlWhere : "") + "\n" +
                    (onlyCount ? "" :
                        (sqlOrderBy.Length > 0 ? " order by " + sqlOrderBy : "") +
                        (((numRows > 0) && (offSet >= 0)) ? " offset " + offSet + " rows fetch next " + numRows + " rows only" : "")
                    )
                );

                table = null;
            }
            else { }

            return result;
        }


        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.PedidoCompraProdutoServico input = (Data.PedidoCompraProdutoServico)parametros["Key"];
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
                    typeof(Tables.PedidoCompraProdutoServico),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.PedidoCompraProdutoServico _data in
                    (System.Collections.Generic.List<Tables.PedidoCompraProdutoServico>)this.m_EntityManager.list
                    (
                        typeof(Tables.PedidoCompraProdutoServico),
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
                    _base = (Data.Base)this.preencher(new Data.PedidoCompraProdutoServico(), _data, level);

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
