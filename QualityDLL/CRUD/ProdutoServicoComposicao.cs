using System;

namespace WS.CRUD
{
    public class ProdutoServicoComposicao : WS.CRUD.Base
    {
        public ProdutoServicoComposicao(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoComposicao input = (Data.ProdutoServicoComposicao)parametros["Key"];
            Tables.ProdutoServicoComposicao bd = new Tables.ProdutoServicoComposicao();

            bd.idProdutoServicoComposicao.isNull = true;
            bd.idProdutoServico.value = input.idProdutoServico;
            bd.idProdutoServicoBase.value = input.idProdutoServicoBase;
            bd.quantidade.value = input.quantidade;
            bd.unidadeProdutoServico.idUnidadeProdutoServico.value = input.unidadeProdutoServico.idUnidadeProdutoServico;

            this.m_EntityManager.persist(bd);

            ((Data.ProdutoServicoComposicao)parametros["Key"]).idProdutoServicoComposicao = (int)bd.idProdutoServicoComposicao.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoComposicao input = (Data.ProdutoServicoComposicao)parametros["Key"];
            Tables.ProdutoServicoComposicao bd = (Tables.ProdutoServicoComposicao)this.m_EntityManager.find
            (
                typeof(Tables.ProdutoServicoComposicao),
                new Object[]
                {
                    input.idProdutoServicoComposicao
                }
            );

            bd.idProdutoServico.value = input.idProdutoServico;
            bd.idProdutoServicoBase.value = input.idProdutoServicoBase;
            bd.quantidade.value = input.quantidade;
            bd.unidadeProdutoServico.idUnidadeProdutoServico.value = input.unidadeProdutoServico.idUnidadeProdutoServico;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ProdutoServicoComposicao bd = new Tables.ProdutoServicoComposicao();

            bd.idProdutoServicoComposicao.value = ((Data.ProdutoServicoComposicao)parametros["Key"]).idProdutoServicoComposicao;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ProdutoServicoComposicao)bd).idProdutoServicoComposicao.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ProdutoServicoComposicao)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ProdutoServicoComposicao)input).idProdutoServicoComposicao = ((Tables.ProdutoServicoComposicao)bd).idProdutoServicoComposicao.value;
                    ((Data.ProdutoServicoComposicao)input).idProdutoServico = ((Tables.ProdutoServicoComposicao)bd).idProdutoServico.value;
                    ((Data.ProdutoServicoComposicao)input).idProdutoServicoBase = ((Tables.ProdutoServicoComposicao)bd).idProdutoServicoBase.value;
                    ((Data.ProdutoServicoComposicao)input).quantidade = ((Tables.ProdutoServicoComposicao)bd).quantidade.value;
                    ((Data.ProdutoServicoComposicao)input).unidadeProdutoServico = (Data.UnidadeProdutoServico)(new WS.CRUD.UnidadeProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.UnidadeProdutoServico(),
                        ((Tables.ProdutoServicoComposicao)bd).unidadeProdutoServico,
                        level + 1
                    );
                    ((Data.ProdutoServicoComposicao)input).produtoServico = (Data.ProdutoServico)(new WS.CRUD.ProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ProdutoServico(),
                        ((Tables.ProdutoServicoComposicao)bd).produtoServico,
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
            Data.ProdutoServicoComposicao result = (Data.ProdutoServicoComposicao)parametros["Key"];

            try
            {
                result = (Data.ProdutoServicoComposicao)this.preencher
                (
                    new Data.ProdutoServicoComposicao(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ProdutoServicoComposicao),
                        new Object[]
                        {
                            result.idProdutoServicoComposicao
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
            Data.ProdutoServicoComposicao input = (Data.ProdutoServicoComposicao)parametros["Key"];
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
                    typeof(Tables.ProdutoServicoComposicao),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ProdutoServicoComposicao _data in
                    (System.Collections.Generic.List<Tables.ProdutoServicoComposicao>)this.m_EntityManager.list
                    (
                        typeof(Tables.ProdutoServicoComposicao),
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
                    _base = (Data.Base)this.preencher(new Data.ProdutoServicoComposicao(), _data, level);

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

        public override String makeSelect(Type classBase, Data.Base input, Object _fieldKeys, System.Collections.Hashtable _params = null)
        {
            String
                result = "",
                sqlInner = "",
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

            Data.ProdutoServicoComposicao _input = (Data.ProdutoServicoComposicao)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idProdutoServicoComposicao > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoComposicao.idProdutoServicoComposicao = @idProdutoServicoComposicao");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idProdutoServicoComposicao", _input.idProdutoServicoComposicao));
                    if (!sqlOrderBy.Contains("produtoServicoComposicao.idProdutoServicoComposicao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoComposicao.idProdutoServicoComposicao");
                    else { }
                }
                else { }

                if (_input.idProdutoServico > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoComposicao.idProdutoServico = @idProdutoServico");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idProdutoServico", _input.idProdutoServico));
                    if (!sqlOrderBy.Contains("produtoServicoComposicao.idProdutoServico"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoComposicao.idProdutoServico");
                    else { }
                }
                else { }

                if (_input.idProdutoServicoBase > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoComposicao.idProdutoServicoBase = @idProdutoServicoBase");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idProdutoServicoBase", _input.idProdutoServicoBase));
                    if (!sqlOrderBy.Contains("produtoServicoComposicao.idProdutoServicoBase"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoComposicao.idProdutoServicoBase");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "produtoServicoComposicao.* ") +
                    "from " +
                    "   produtoServicoComposicao " +
                    (sqlInner.Length > 0 ? sqlInner : "") +
                    (sqlWhere.Length > 0 ? " where " + sqlWhere : "") +
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

    }
}
