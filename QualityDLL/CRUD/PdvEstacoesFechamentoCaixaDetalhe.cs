using System;

namespace WS.CRUD
{
    public class PdvEstacoesFechamentoCaixaDetalhe : WS.CRUD.Base
    {
        public PdvEstacoesFechamentoCaixaDetalhe(long? idEmpresa, EJB.EntityManager.EntityManager entityManager) : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacoesFechamentoCaixaDetalhe input = (Data.PdvEstacoesFechamentoCaixaDetalhe)parametros["Key"];
            Tables.PdvEstacoesFechamentoCaixaDetalhe bd = new Tables.PdvEstacoesFechamentoCaixaDetalhe();


            bd.idPdvEstacaoFechamentoCaixaDetalhe.isNull = true;
            bd.valor.value = input.valor;
            bd.valorDigitado.value = input.valorDigitado;

            if ((input.pdvEstacaoFechamentoCaixa != null) && (input.pdvEstacaoFechamentoCaixa.idPdvEstacaoFechamentoCaixa > 0))
                bd.pdvEstacaoFechamentoCaixa.idPdvEstacaoFechamentoCaixa.value = input.pdvEstacaoFechamentoCaixa.idPdvEstacaoFechamentoCaixa;
            else { }

            if ((input.contaPagamento != null) && (input.contaPagamento.idContaPagamento > 0))
                bd.contaPagamento.idContaPagamento.value = input.contaPagamento.idContaPagamento;
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.PdvEstacoesFechamentoCaixaDetalhe)parametros["Key"]).idPdvEstacaoFechamentoCaixaDetalhe = (int)bd.idPdvEstacaoFechamentoCaixaDetalhe.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacoesFechamentoCaixaDetalhe input = (Data.PdvEstacoesFechamentoCaixaDetalhe)parametros["Key"];
            Tables.PdvEstacoesFechamentoCaixaDetalhe bd = (Tables.PdvEstacoesFechamentoCaixaDetalhe)this.m_EntityManager.find
            (
                typeof(Tables.PdvEstacoesFechamentoCaixaDetalhe),
                new Object[]
                {
                    input.idPdvEstacaoFechamentoCaixaDetalhe
                }
            );

            if ((input.pdvEstacaoFechamentoCaixa != null) && (input.pdvEstacaoFechamentoCaixa.idPdvEstacaoFechamentoCaixa > 0))
                bd.pdvEstacaoFechamentoCaixa.idPdvEstacaoFechamentoCaixa.value = input.pdvEstacaoFechamentoCaixa.idPdvEstacaoFechamentoCaixa;
            else { }

            if ((input.contaPagamento != null) && (input.contaPagamento.idContaPagamento > 0))
                bd.contaPagamento.idContaPagamento.value = input.contaPagamento.idContaPagamento;
            else { }

            bd.valor.value = input.valor;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PdvEstacoesFechamentoCaixaDetalhe bd = new Tables.PdvEstacoesFechamentoCaixaDetalhe();

            bd.idPdvEstacaoFechamentoCaixaDetalhe.value = ((Data.PdvEstacoesFechamentoCaixaDetalhe)parametros["Key"]).idPdvEstacaoFechamentoCaixaDetalhe;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PdvEstacoesFechamentoCaixaDetalhe)bd).idPdvEstacaoFechamentoCaixaDetalhe.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PdvEstacoesFechamentoCaixaDetalhe)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PdvEstacoesFechamentoCaixaDetalhe)input).idPdvEstacaoFechamentoCaixaDetalhe = ((Tables.PdvEstacoesFechamentoCaixaDetalhe)bd).idPdvEstacaoFechamentoCaixaDetalhe.value;
                    ((Data.PdvEstacoesFechamentoCaixaDetalhe)input).valor = ((Tables.PdvEstacoesFechamentoCaixaDetalhe)bd).valor.value;
                    ((Data.PdvEstacoesFechamentoCaixaDetalhe)input).valorDigitado = ((Tables.PdvEstacoesFechamentoCaixaDetalhe)bd).valorDigitado.value;
                    ((Data.PdvEstacoesFechamentoCaixaDetalhe)input).contaPagamento = (Data.ContaPagamento)(new WS.CRUD.ContaPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.ContaPagamento(),
                            ((Tables.PdvEstacoesFechamentoCaixaDetalhe)bd).contaPagamento,
                            level + 1
                        );
                    if (level < 1)
                    {
                        ((Data.PdvEstacoesFechamentoCaixaDetalhe)input).pdvEstacaoFechamentoCaixa = (Data.PdvEstacoesFechamentoCaixa)(new WS.CRUD.PdvEstacoesFechamentoCaixa(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.PdvEstacoesFechamentoCaixa(),
                            ((Tables.PdvEstacoesFechamentoCaixaDetalhe)bd).pdvEstacaoFechamentoCaixa,
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
            Data.PdvEstacoesFechamentoCaixaDetalhe result = (Data.PdvEstacoesFechamentoCaixaDetalhe)parametros["Key"];
            String queryString = "";
            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();
                string whereKeys = "";

                if ((result.idPdvEstacaoFechamentoCaixaDetalhe > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacaoFechamentoCaixaDetalhe", result.idPdvEstacaoFechamentoCaixaDetalhe));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvEstacoesFechamentoCaixaDetalhe.idPdvEstacaoFechamentoCaixaDetalhe = @idPdvEstacaoFechamentoCaixaDetalhe";
                }
                else { }

                if ((result.pdvEstacaoFechamentoCaixa != null) && (result.pdvEstacaoFechamentoCaixa.idPdvEstacaoFechamentoCaixa > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacaoFechamentoCaixa", result.pdvEstacaoFechamentoCaixa.idPdvEstacaoFechamentoCaixa));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvEstacoesFechamentoCaixaDetalhe.idPdvEstacaoFechamentoCaixa = @idPdvEstacaoFechamentoCaixa";
                }
                else { }



                if (String.IsNullOrEmpty(whereKeys))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacaoFechamentoCaixaDetalhe", result.idPdvEstacaoFechamentoCaixaDetalhe));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvEstacoesFechamentoCaixaDetalhe.idPdvEstacaoFechamentoCaixaDetalhe = @idPdvEstacaoFechamentoCaixaDetalhe";
                }
                else { }

                queryString =
                (
                    "select top 1\n" +
                    "    *\n" +
                    "from \n" + 
                    "    pdvEstacoesFechamentoCaixaDetalhe pdvEstacoesFechamentoCaixaDetalhe\n" +
                    "    inner join pdvEstacoesFechamentoCaixa ON pdvEstacoesFechamentoCaixa.idPdvEstacaoFechamentoCaixa = pdvEstacoesFechamentoCaixaDetalhe.idPdvEstacaoFechamentoCaixa\n" +
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
                    Tables.PdvEstacoesFechamentoCaixaDetalhe _data in
                    (System.Collections.Generic.List<Tables.PdvEstacoesFechamentoCaixaDetalhe>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvEstacoesFechamentoCaixaDetalhe),
                        queryString,
                        fieldKeys.ToArray()
                    )
                )
                {
                    result = (Data.PdvEstacoesFechamentoCaixaDetalhe)this.preencher
                    (
                        new Data.PdvEstacoesFechamentoCaixaDetalhe(),
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

            Data.PdvEstacoesFechamentoCaixaDetalhe _input = (Data.PdvEstacoesFechamentoCaixaDetalhe)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idPdvEstacaoFechamentoCaixaDetalhe > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pdvEstacoesFechamentoCaixaDetalhe.idPdvEstacaoFechamentoCaixaDetalhe = @idPdvEstacaoFechamentoCaixaDetalhe");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacaoFechamentoCaixaDetalhe", _input.idPdvEstacaoFechamentoCaixaDetalhe));
                    if (!sqlOrderBy.Contains("pdvEstacoesFechamentoCaixaDetalhe.idPdvEstacaoFechamentoCaixaDetalhe"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvEstacoesFechamentoCaixaDetalhe.idPdvEstacaoFechamentoCaixaDetalhe");
                    else { }
                }
                else { }

                if ((_input.pdvEstacaoFechamentoCaixa != null) && (_input.pdvEstacaoFechamentoCaixa.idPdvEstacaoFechamentoCaixa > 0))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pdvEstacoesFechamentoCaixaDetalhe.idPdvEstacaoFechamentoCaixa = @idPdvEstacaoFechamentoCaixa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacaoFechamentoCaixa", _input.pdvEstacaoFechamentoCaixa.idPdvEstacaoFechamentoCaixa));
                    if (!sqlOrderBy.Contains("pdvEstacoesFechamentoCaixaDetalhe.idPdvEstacaoFechamentoCaixa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvEstacoesFechamentoCaixaDetalhe.idPdvEstacaoFechamentoCaixa");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "* ") +
                    "from " +
                    "   pdvEstacoesFechamentoCaixaDetalhe pdvEstacoesFechamentoCaixaDetalhe " +
                    "   inner join pdvEstacoesFechamentoCaixa " +
                    "       on pdvEstacoesFechamentoCaixa.idPdvEstacaoFechamentoCaixa = pdvEstacoesFechamentoCaixaDetalhe.idPdvEstacaoFechamentoCaixa\n" +

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
            Data.PdvEstacoesFechamentoCaixaDetalhe input = (Data.PdvEstacoesFechamentoCaixaDetalhe)parametros["Key"];
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
                    typeof(Tables.PdvEstacoesFechamentoCaixaDetalhe),
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
                    Tables.PdvEstacoesFechamentoCaixaDetalhe _data in
                    (System.Collections.Generic.List<Tables.PdvEstacoesFechamentoCaixaDetalhe>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvEstacoesFechamentoCaixaDetalhe),
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
                    _base = (Data.Base)this.preencher(new Data.PdvEstacoesFechamentoCaixaDetalhe(), _data, level);

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
