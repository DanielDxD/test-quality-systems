using System;

namespace WS.CRUD
{
    public class ProdutoServicoImpressora : WS.CRUD.Base
    {
        public ProdutoServicoImpressora(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoImpressora input = (Data.ProdutoServicoImpressora)parametros["Key"];
            Tables.ProdutoServicoImpressora bd = new Tables.ProdutoServicoImpressora();

            bd.idProdutoServicoImpressora.isNull = true;

            if (input.pdvEstacao != null)
                if (input.pdvEstacao.idPdvEstacao > 0)
                    bd.pdvEstacao.idPdvEstacao.value = input.pdvEstacao.idPdvEstacao;
                else { }
            else { }

            if (input.produtoServico != null)
                if (input.produtoServico.idProdutoServico > 0)
                    bd.produtoServico.idProdutoServico.value = input.produtoServico.idProdutoServico;
                else { }
            else { }

            if (input.pdvImpressora != null)
                if (input.pdvImpressora.idPdvImpressora > 0)
                    bd.pdvImpressora.idPdvImpressora.value = input.pdvImpressora.idPdvImpressora;
                else { }
            else { }           

            this.m_EntityManager.persist(bd);

            ((Data.ProdutoServicoImpressora)parametros["Key"]).idProdutoServicoImpressora = (int)bd.idProdutoServicoImpressora.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoImpressora input = (Data.ProdutoServicoImpressora)parametros["Key"];
            Tables.ProdutoServicoImpressora bd = (Tables.ProdutoServicoImpressora)this.m_EntityManager.find
            (
                typeof(Tables.ProdutoServicoImpressora),
                new Object[]
                {
                    input.idProdutoServicoImpressora
                }
            );

            if (input.pdvEstacao != null)
                if (input.pdvEstacao.idPdvEstacao > 0)
                    bd.pdvEstacao.idPdvEstacao.value = input.pdvEstacao.idPdvEstacao;
                else { }
            else { }

            if (input.produtoServico != null)
                if (input.produtoServico.idProdutoServico > 0)
                    bd.produtoServico.idProdutoServico.value = input.produtoServico.idProdutoServico;
                else { }
            else { }

            if (input.pdvImpressora != null)
                if (input.pdvImpressora.idPdvImpressora > 0)
                    bd.pdvImpressora.idPdvImpressora.value = input.pdvImpressora.idPdvImpressora;
                else { }
            else { }

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ProdutoServicoImpressora bd = new Tables.ProdutoServicoImpressora();

            bd.idProdutoServicoImpressora.value = ((Data.ProdutoServicoImpressora)parametros["Key"]).idProdutoServicoImpressora;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ProdutoServicoImpressora)bd).idProdutoServicoImpressora.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ProdutoServicoImpressora)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ProdutoServicoImpressora)input).idProdutoServicoImpressora = ((Tables.ProdutoServicoImpressora)bd).idProdutoServicoImpressora.value;
                    
                    ((Data.ProdutoServicoImpressora)input).pdvEstacao = (Data.PdvEstacao)(new WS.CRUD.PdvEstacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PdvEstacao(),
                        ((Tables.ProdutoServicoImpressora)bd).pdvEstacao,
                        level + 1
                    );
                    ((Data.ProdutoServicoImpressora)input).produtoServico = (Data.ProdutoServico)(new WS.CRUD.ProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ProdutoServico(),
                        ((Tables.ProdutoServicoImpressora)bd).produtoServico,
                        level + 1
                    );

                    ((Data.ProdutoServicoImpressora)input).pdvImpressora = (Data.PdvImpressora)(new WS.CRUD.PdvImpressora(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PdvImpressora(),
                        ((Tables.ProdutoServicoImpressora)bd).pdvImpressora,
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
            Data.ProdutoServicoImpressora result = (Data.ProdutoServicoImpressora)parametros["Key"];

            try
            {
                result = (Data.ProdutoServicoImpressora)this.preencher
                (
                    new Data.ProdutoServicoImpressora(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ProdutoServicoImpressora),
                        new Object[]
                        {
                            result.idProdutoServicoImpressora
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
            Data.ProdutoServicoImpressora input = (Data.ProdutoServicoImpressora)parametros["Key"];
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
                    typeof(Tables.ProdutoServicoImpressora),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ProdutoServicoImpressora _data in
                    (System.Collections.Generic.List<Tables.ProdutoServicoImpressora>)this.m_EntityManager.list
                    (
                        typeof(Tables.ProdutoServicoImpressora),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.ProdutoServicoImpressora(), _data, level);

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

            Data.ProdutoServicoImpressora _input = (Data.ProdutoServicoImpressora)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idProdutoServicoImpressora > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoImpressora.idProdutoServicoImpressora = @idProdutoServicoImpressora");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idProdutoServicoImpressora", _input.idProdutoServicoImpressora));
                    if (!sqlOrderBy.Contains("produtoServicoImpressora.idProdutoServicoImpressora"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoImpressora.idProdutoServicoImpressora");
                    else { }
                }
                else { }

                if (_input.pdvEstacao != null)
                {
                    if (_input.pdvEstacao.idPdvEstacao > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoImpressora.idPdvEstacao = @idPdvEstacao");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacao", _input.pdvEstacao.idPdvEstacao));
                        if (!sqlOrderBy.Contains("produtoServicoImpressora.idPdvEstacao"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoImpressora.idPdvEstacao");
                        else { }
                    }
                    else { }
                }
                else { }


                if (_input.produtoServico != null)
                {
                    if (_input.produtoServico.idProdutoServico > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoImpressora.idProdutoServico = @idProdutoServico");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idProdutoServico", _input.produtoServico.idProdutoServico));
                        if (!sqlOrderBy.Contains("produtoServicoImpressora.idProdutoServico"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoImpressora.idProdutoServico");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.pdvImpressora != null)
                {
                    if (_input.pdvImpressora.idPdvImpressora > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoImpressora.idPdvImpressora = @idPdvImpressora");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvImpressora", _input.pdvImpressora.idPdvImpressora));
                        if (!sqlOrderBy.Contains("produtoServicoImpressora.idPdvImpressora"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoImpressora.idPdvImpressora");
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "produtoServicoImpressora.* ") +
                    "from " +
                    (
                        "   produtoServicoImpressora produtoServicoImpressora " +
                        "       inner join produtoServico produtoServico " +
                        "           on	produtoServico.idProdutoServico = produtoServicoImpressora.idProdutoServico " +
                        "       inner join pdvEstacoes pdvEstacoes " +
                        "           on	pdvEstacoes.idPdvEstacao = produtoServicoImpressora.idPdvEstacao " +
                        "       inner join pdvImpressora pdvImpressora " +
                        "           on	pdvImpressora.idPdvImpressora = produtoServicoImpressora.idPdvImpressora "
                    ) +
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
