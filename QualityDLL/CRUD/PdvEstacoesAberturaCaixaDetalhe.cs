using System;

namespace WS.CRUD
{
    public class PdvEstacoesAberturaCaixaDetalhe : WS.CRUD.Base
    {
        public PdvEstacoesAberturaCaixaDetalhe(long? idEmpresa, EJB.EntityManager.EntityManager entityManager) : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacoesAberturaCaixaDetalhe input = (Data.PdvEstacoesAberturaCaixaDetalhe)parametros["Key"];
            Tables.PdvEstacoesAberturaCaixaDetalhe bd = new Tables.PdvEstacoesAberturaCaixaDetalhe();


            bd.idPdvEstacaoAberturaCaixaDetalhe.isNull = true;
            bd.valor.value = input.valor;

            if ((input.pdvEstacaoAberturaCaixa != null) && (input.pdvEstacaoAberturaCaixa.idPdvEstacaoAberturaCaixa > 0))
                bd.pdvEstacaoAberturaCaixa.idPdvEstacaoAberturaCaixa.value = input.pdvEstacaoAberturaCaixa.idPdvEstacaoAberturaCaixa;
            else { }

            if ((input.contaPagamento != null) && (input.contaPagamento.idContaPagamento > 0))
                bd.contaPagamento.idContaPagamento.value = input.contaPagamento.idContaPagamento;
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.PdvEstacoesAberturaCaixaDetalhe)parametros["Key"]).idPdvEstacaoAberturaCaixaDetalhe = (int)bd.idPdvEstacaoAberturaCaixaDetalhe.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacoesAberturaCaixaDetalhe input = (Data.PdvEstacoesAberturaCaixaDetalhe)parametros["Key"];
            Tables.PdvEstacoesAberturaCaixaDetalhe bd = (Tables.PdvEstacoesAberturaCaixaDetalhe)this.m_EntityManager.find
            (
                typeof(Tables.PdvEstacoesAberturaCaixaDetalhe),
                new Object[]
                {
                    input.idPdvEstacaoAberturaCaixaDetalhe
                }
            );

            if ((input.pdvEstacaoAberturaCaixa != null) && (input.pdvEstacaoAberturaCaixa.idPdvEstacaoAberturaCaixa > 0))
                bd.pdvEstacaoAberturaCaixa.idPdvEstacaoAberturaCaixa.value = input.pdvEstacaoAberturaCaixa.idPdvEstacaoAberturaCaixa;
            else { }

            if ((input.contaPagamento != null) && (input.contaPagamento.idContaPagamento > 0))
                bd.contaPagamento.idContaPagamento.value = input.contaPagamento.idContaPagamento;
            else { }

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PdvEstacoesAberturaCaixaDetalhe bd = new Tables.PdvEstacoesAberturaCaixaDetalhe();

            bd.idPdvEstacaoAberturaCaixaDetalhe.value = ((Data.PdvEstacoesAberturaCaixaDetalhe)parametros["Key"]).idPdvEstacaoAberturaCaixaDetalhe;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PdvEstacoesAberturaCaixaDetalhe)bd).idPdvEstacaoAberturaCaixaDetalhe.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PdvEstacoesAberturaCaixaDetalhe)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PdvEstacoesAberturaCaixaDetalhe)input).idPdvEstacaoAberturaCaixaDetalhe = ((Tables.PdvEstacoesAberturaCaixaDetalhe)bd).idPdvEstacaoAberturaCaixaDetalhe.value;
                    ((Data.PdvEstacoesAberturaCaixaDetalhe)input).valor = ((Tables.PdvEstacoesAberturaCaixaDetalhe)bd).valor.value;

                    if (level < 1)
                    {
                        ((Data.PdvEstacoesAberturaCaixaDetalhe)input).pdvEstacaoAberturaCaixa = (Data.PdvEstacoesAberturaCaixa)(new WS.CRUD.PdvEstacoesAberturaCaixa(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.PdvEstacoesAberturaCaixa(),
                            ((Tables.PdvEstacoesAberturaCaixaDetalhe)bd).pdvEstacaoAberturaCaixa,
                            level + 1
                        );

                        ((Data.PdvEstacoesAberturaCaixaDetalhe)input).contaPagamento = (Data.ContaPagamento)(new WS.CRUD.ContaPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.ContaPagamento(),
                            ((Tables.PdvEstacoesAberturaCaixaDetalhe)bd).contaPagamento,
                            level + 1
                        );

                    }
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacoesAberturaCaixaDetalhe result = (Data.PdvEstacoesAberturaCaixaDetalhe)parametros["Key"];
            String queryString = "";
            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();
                string whereKeys = "";

                if ((result.idPdvEstacaoAberturaCaixaDetalhe > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacaoAberturaCaixaDetalhe", result.idPdvEstacaoAberturaCaixaDetalhe));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvEstacoesAberturaCaixaDetalhe.idPdvEstacaoAberturaCaixaDetalhe = @idPdvEstacaoAberturaCaixaDetalhe";
                }
                else { }

                if ((result.pdvEstacaoAberturaCaixa != null) && (result.pdvEstacaoAberturaCaixa.idPdvEstacaoAberturaCaixa > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacaoAberturaCaixa", result.pdvEstacaoAberturaCaixa.idPdvEstacaoAberturaCaixa));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvEstacoesAberturaCaixaDetalhe.idPdvEstacaoAberturaCaixa = @idPdvEstacaoAberturaCaixa";
                }
                else { }

                if ((result.contaPagamento != null) && (result.contaPagamento.idContaPagamento > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContaPagamento", result.contaPagamento.idContaPagamento));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvEstacoesAberturaCaixaDetalhe.idContaPagamento = @idContaPagamento";
                }
                else { }


                if (String.IsNullOrEmpty(whereKeys))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacaoAberturaCaixaDetalhe", result.idPdvEstacaoAberturaCaixaDetalhe));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvEstacoesAberturaCaixaDetalhe.idPdvEstacaoAberturaCaixaDetalhe = @idPdvEstacaoAberturaCaixaDetalhe";
                }
                else { }

                queryString =
                (
                    "select top 1\n" +
                    "    *\n" +
                    "from \n" + 
                    "    pdvEstacoesAberturaCaixaDetalhe pdvEstacoesAberturaCaixaDetalhe\n" +
                    "    inner join pdvEstacoesAberturaCaixa ON pdvEstacoesAberturaCaixa.idPdvEstacaoAberturaCaixa = pdvEstacoesAberturaCaixaDetalhe.idPdvEstacaoAberturaCaixa\n" +
                    "    inner join contaPagamento ON contaPagamento.idContaPagamento = pdvEstacoesAberturaCaixaDetalhe.idContaPagamento\n" +
                    (
                        (whereKeys.Length > 0) ?
                        (
                            "where\n" +
                            "    " + whereKeys + "\n"
                        ) :
                        ""
                    )
                );

                foreach
                (
                    Tables.PdvEstacoesAberturaCaixaDetalhe _data in
                    (System.Collections.Generic.List<Tables.PdvEstacoesAberturaCaixaDetalhe>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvEstacoesAberturaCaixaDetalhe),
                        queryString,
                        fieldKeys.ToArray()
                    )
                )
                {
                    result = (Data.PdvEstacoesAberturaCaixaDetalhe)this.preencher
                    (
                        new Data.PdvEstacoesAberturaCaixaDetalhe(),
                        _data,
                        0
                    );
                }
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

            Data.PdvEstacoesAberturaCaixaDetalhe _input = (Data.PdvEstacoesAberturaCaixaDetalhe)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idPdvEstacaoAberturaCaixaDetalhe > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pdvEstacoesAberturaCaixaDetalhe.idPdvEstacaoAberturaCaixaDetalhe = @idPdvEstacaoAberturaCaixaDetalhe");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacaoAberturaCaixaDetalhe", _input.idPdvEstacaoAberturaCaixaDetalhe));
                    if (!sqlOrderBy.Contains("pdvEstacoesAberturaCaixaDetalhe.idPdvEstacaoAberturaCaixaDetalhe"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvEstacoesAberturaCaixaDetalhe.idPdvEstacaoAberturaCaixaDetalhe");
                    else { }
                }
                else { }

                if ((_input.pdvEstacaoAberturaCaixa != null) && (_input.pdvEstacaoAberturaCaixa.idPdvEstacaoAberturaCaixa > 0))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pdvEstacoesAberturaCaixaDetalhe.idPdvEstacaoAberturaCaixa = @idPdvEstacaoAberturaCaixa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacaoAberturaCaixa", _input.pdvEstacaoAberturaCaixa.idPdvEstacaoAberturaCaixa));
                    if (!sqlOrderBy.Contains("pdvEstacoesAberturaCaixaDetalhe.idPdvEstacaoAberturaCaixa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvEstacoesAberturaCaixaDetalhe.idPdvEstacaoAberturaCaixa");
                    else { }
                }
                else { }

                if ((_input.contaPagamento != null) && (_input.contaPagamento.idContaPagamento > 0 || _input.contaPagamento.idContaPagamento < 0))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pdvEstacoesAberturaCaixaDetalhe.idContaPagamento = @idContaPagamento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContaPagamento", _input.contaPagamento.idContaPagamento));
                    if (!sqlOrderBy.Contains("pdvEstacoesAberturaCaixaDetalhe.idContaPagamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvEstacoesAberturaCaixaDetalhe.idContaPagamento");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "pdvEstacoesAberturaCaixaDetalhe.* ") +
                    "from " +
                    "   pdvEstacoesAberturaCaixaDetalhe pdvEstacoesAberturaCaixaDetalhe " +
                    "   inner join pdvEstacoesAberturaCaixa "+
                    "       on pdvEstacoesAberturaCaixa.idPdvEstacaoAberturaCaixa = pdvEstacoesAberturaCaixaDetalhe.idPdvEstacaoAberturaCaixa\n" +
                    "    inner join contaPagamento ON contaPagamento.idContaPagamento = pdvEstacoesAberturaCaixaDetalhe.idContaPagamento\n" +
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

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacoesAberturaCaixaDetalhe input = (Data.PdvEstacoesAberturaCaixaDetalhe)parametros["Key"];
            System.Collections.Generic.List<Data.Base> result = new System.Collections.Generic.List<Data.Base>();
            string mode = (string)(parametros["Mode"] == null ? "" : parametros["Mode"]);
            int level = (int)(parametros["Level"] == null ? 0 : parametros["Level"]);

            Report.Base report = (Report.Base)parametros["Report"];

            System.Collections.Hashtable makeSelectParams = new System.Collections.Hashtable();
            makeSelectParams["numRows"] = (parametros["Top"] == null ? 0 : (int)parametros["Top"]);
            makeSelectParams["where"] = (parametros["Filter"] == null ? "" : (String)parametros["Filter"]);
            makeSelectParams["orderBy"] = (parametros["Order"] == null ? "" : (String)parametros["Order"]);
            makeSelectParams["offSet"] = (parametros["Offset"] == null ? -1 : parametros["Offset"]);


            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> _fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();

                if (parametros["Filter"] != null)
                {
                    String _filter = (String)parametros["Filter"];

                    while (_filter.Contains("@"))
                    {
                        String _key = _filter.Substring(_filter.IndexOf("@")).Split(new char[] { ' ', ')' })[0];
                        _fieldKeys.Add((EJB.TableBase.TField)parametros[_key]);
                        _filter = _filter.Substring(_filter.IndexOf("@") + _key.Length);
                    }
                }
                else { }

                String _select = this.makeSelect
                (
                    typeof(Tables.PdvEstacoesAberturaCaixaDetalhe),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                parametros.Clear();
                parametros = null;

                foreach
                (
                    Tables.PdvEstacoesAberturaCaixaDetalhe _data in
                    (System.Collections.Generic.List<Tables.PdvEstacoesAberturaCaixaDetalhe>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvEstacoesAberturaCaixaDetalhe),
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
                    _base = (Data.Base)this.preencher(new Data.PdvEstacoesAberturaCaixaDetalhe(), _data, level);

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
