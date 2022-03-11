using System;

namespace WS.CRUD
{
    public class EntradaMercadoriaItem : WS.CRUD.Base
    {
        public EntradaMercadoriaItem(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.EntradaMercadoriaItem input = (Data.EntradaMercadoriaItem)parametros["Key"];
            Tables.EntradaMercadoriaItem bd = new Tables.EntradaMercadoriaItem();
            int idPedidoCompra = (int)parametros["idPedidoCompra"];
            DateTime dataEntrada = (DateTime)parametros["dataEntrada"];

            bd.idEntradaMercadoriaItem.isNull = true;
            bd.idEntradaMercadoria.value = input.idEntradaMercadoria;
            if ((input.produtoServico != null) && (input.produtoServico.idProdutoServico > 0))
                bd.produtoServico.idProdutoServico.value = input.produtoServico.idProdutoServico;
            else { }

            bd.quantidade.value = input.quantidade;
            bd.valor.value = input.valor;
            if ((input.unidadeProdutoServico != null) && (input.unidadeProdutoServico.idUnidadeProdutoServico > 0))
                bd.unidadeProdutoServico.idUnidadeProdutoServico.value = input.unidadeProdutoServico.idUnidadeProdutoServico;
            else { }
            if (input.dataFabricacao.Ticks > 0)
                bd.dataFabricacao.value = input.dataFabricacao;
            else
                bd.dataFabricacao.isNull = true;
            if (input.dataValidade.Ticks > 0)
                bd.dataValidade.value = input.dataValidade;
            else
                bd.dataValidade.isNull = true;
            if (!String.IsNullOrEmpty(input.numeroLote))
                bd.numeroLote.value = input.numeroLote;
            else
                bd.numeroLote.isNull = true;
            try
            {
                this.m_EntityManager.persist(bd);
            }
            catch (Exception e)
            {
                throw new Utils.BusinessRuleException(e.Message);
            }

            ((Data.EntradaMercadoriaItem)parametros["Key"]).idEntradaMercadoriaItem = (int)bd.idEntradaMercadoriaItem.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.EntradaMercadoriaItem input = (Data.EntradaMercadoriaItem)parametros["Key"];
            Tables.EntradaMercadoriaItem bd = (Tables.EntradaMercadoriaItem)this.m_EntityManager.find
            (
                typeof(Tables.EntradaMercadoriaItem),
                new Object[]
                {
                    input.idEntradaMercadoriaItem
                }
            );
            int idPedidoCompra = (int)parametros["idPedidoCompra"];
            DateTime dataEntrada = (DateTime)parametros["dataEntrada"];

            bd.idEntradaMercadoria.value = input.idEntradaMercadoria;
            if ((input.produtoServico != null) && (input.produtoServico.idProdutoServico > 0))
                bd.produtoServico.idProdutoServico.value = input.produtoServico.idProdutoServico;
            else { }

            bd.quantidade.value = input.quantidade;
            bd.valor.value = input.valor;
            if ((input.unidadeProdutoServico != null) && (input.unidadeProdutoServico.idUnidadeProdutoServico > 0))
                bd.unidadeProdutoServico.idUnidadeProdutoServico.value = input.unidadeProdutoServico.idUnidadeProdutoServico;
            else { }
            if (input.dataFabricacao.Ticks > 0)
                bd.dataFabricacao.value = input.dataFabricacao;
            else
                bd.dataFabricacao.isNull = true;
            if (input.dataValidade.Ticks > 0)
                bd.dataValidade.value = input.dataValidade;
            else
                bd.dataValidade.isNull = true;
            if (!String.IsNullOrEmpty(input.numeroLote))
                bd.numeroLote.value = input.numeroLote;
            else
                bd.numeroLote.isNull = true;

            try
            {
                this.m_EntityManager.merge(bd);
            }
            catch (Exception e)
            {
                throw new Utils.BusinessRuleException(e.Message);
            }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.EntradaMercadoriaItem bd = (Tables.EntradaMercadoriaItem)this.m_EntityManager.find
            (
                typeof(Tables.EntradaMercadoriaItem),
                new Object[]
                {
                     ((Data.EntradaMercadoriaItem)parametros["Key"]).idEntradaMercadoriaItem
                }
            );

            int idPedidoCompra = (int)parametros["idPedidoCompra"];
            DateTime dataEntrada = (DateTime)parametros["dataEntrada"];

            Data.EntradaMercadoriaItem item = (Data.EntradaMercadoriaItem)this.preencher(new Data.EntradaMercadoriaItem(), bd, 0);
            item.quantidade = 0.0;

            try
            {
                this.m_EntityManager.remove(bd);
            }
            catch (Exception e)
            {
                throw new Utils.BusinessRuleException(e.Message);
            }
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.EntradaMercadoriaItem)bd).idEntradaMercadoriaItem.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.EntradaMercadoriaItem)input).operacao = ENum.eOperacao.NONE;

                    ((Data.EntradaMercadoriaItem)input).idEntradaMercadoriaItem = ((Tables.EntradaMercadoriaItem)bd).idEntradaMercadoriaItem.value;
                    ((Data.EntradaMercadoriaItem)input).idEntradaMercadoria = ((Tables.EntradaMercadoriaItem)bd).idEntradaMercadoria.value;
                    ((Data.EntradaMercadoriaItem)input).produtoServico = (Data.ProdutoServico)(new WS.CRUD.ProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ProdutoServico(),
                        ((Tables.EntradaMercadoriaItem)bd).produtoServico,
                        level + 1
                    );
                    ((Data.EntradaMercadoriaItem)input).quantidade = ((Tables.EntradaMercadoriaItem)bd).quantidade.value;
                    ((Data.EntradaMercadoriaItem)input).valor = ((Tables.EntradaMercadoriaItem)bd).valor.value;
                    ((Data.EntradaMercadoriaItem)input).unidadeProdutoServico = (Data.UnidadeProdutoServico)(new WS.CRUD.UnidadeProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.UnidadeProdutoServico(),
                        ((Tables.EntradaMercadoriaItem)bd).unidadeProdutoServico,
                        level + 1
                    );
                    ((Data.EntradaMercadoriaItem)input).dataFabricacao = ((Tables.EntradaMercadoriaItem)bd).dataFabricacao.value;
                    ((Data.EntradaMercadoriaItem)input).dataValidade = ((Tables.EntradaMercadoriaItem)bd).dataValidade.value;
                    ((Data.EntradaMercadoriaItem)input).numeroLote = ((Tables.EntradaMercadoriaItem)bd).numeroLote.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.EntradaMercadoriaItem result = (Data.EntradaMercadoriaItem)parametros["Key"];

            try
            {
                result = (Data.EntradaMercadoriaItem)this.preencher
                (
                    new Data.EntradaMercadoriaItem(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.EntradaMercadoriaItem),
                        new Object[]
                        {
                            result.idEntradaMercadoriaItem
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

            Data.EntradaMercadoriaItem _input = (Data.EntradaMercadoriaItem)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                if (_input.idEntradaMercadoria > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   entradaMercadoriaItem.idEntradaMercadoria = @idEntradaMercadoria");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEntradaMercadoria", _input.idEntradaMercadoria));
                    if (!sqlOrderBy.Contains("entradaMercadoriaItem.idEntradaMercadoria"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "entradaMercadoriaItem.idEntradaMercadoria");
                    else { }
                }
                else { }

                if (_input.idEntradaMercadoriaItem > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   entradaMercadoriaItem.idEntradaMercadoriaItem = @idEntradaMercadoriaItem");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEntradaMercadoriaItem", _input.idEntradaMercadoriaItem));
                    if (!sqlOrderBy.Contains("entradaMercadoriaItem.idEntradaMercadoriaItem"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "entradaMercadoriaItem.idEntradaMercadoriaItem");
                    else { }
                }
                else { }

                if (_input.produtoServico != null)
                {
                    if (_input.produtoServico.idProdutoServico > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   entradaMercadoriaItem.idProdutoServico = @idProdutoServico");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idProdutoServico", _input.produtoServico.idProdutoServico));
                        if (!sqlOrderBy.Contains("entradaMercadoriaItem.idProdutoServico"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "entradaMercadoriaItem.idProdutoServico");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.unidadeProdutoServico != null)
                {
                    if (_input.unidadeProdutoServico.idUnidadeProdutoServico > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   entradaMercadoriaItem.idUnidadeProdutoServico = @idUnidadeProdutoServico");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idUnidadeProdutoServico", _input.unidadeProdutoServico.idUnidadeProdutoServico));
                        if (!sqlOrderBy.Contains("entradaMercadoriaItem.idUnidadeProdutoServico"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "entradaMercadoriaItem.idUnidadeProdutoServico");
                        else { }
                    }
                    else { }
                }
                else { }
                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "entradaMercadoriaItem.* ") +
                    "from \n" + 
                    (
                        "entradaMercadoriaItem entradaMercadoriaItem\n"
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
            Data.EntradaMercadoriaItem input = (Data.EntradaMercadoriaItem)parametros["Key"];
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
                    typeof(Tables.EntradaMercadoriaItem),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.EntradaMercadoriaItem _data in
                    (System.Collections.Generic.List<Tables.EntradaMercadoriaItem>)this.m_EntityManager.list
                    (
                        typeof(Tables.EntradaMercadoriaItem),
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
                    _base = (Data.Base)this.preencher(new Data.EntradaMercadoriaItem(), _data, level);

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
