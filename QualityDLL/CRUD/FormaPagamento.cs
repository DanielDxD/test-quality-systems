using System;

namespace WS.CRUD
{
    public class FormaPagamento : WS.CRUD.Base
    {
        public FormaPagamento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.FormaPagamento input = (Data.FormaPagamento)parametros["Key"];
            Tables.FormaPagamento bd = new Tables.FormaPagamento();

            bd.idFormaPagamento.isNull = true;
            bd.descricao.value = input.descricao;
            bd.tipo.value = input.tipo;
            bd.codigoFiscal.value = input.codigoFiscal;
            bd.idBandeiraCartao.value = input.idBandeiraCartao;
            bd.habilitarValorDigitadoFechamento.value = input.habilitarValorDigitadoFechamento == "1";

            this.m_EntityManager.persist(bd);

            ((Data.FormaPagamento)parametros["Key"]).idFormaPagamento = (int)bd.idFormaPagamento.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.FormaPagamento input = (Data.FormaPagamento)parametros["Key"];
            Tables.FormaPagamento bd = (Tables.FormaPagamento)this.m_EntityManager.find
            (
                typeof(Tables.FormaPagamento),
                new Object[]
                {
                    input.idFormaPagamento
                }
            );

            bd.descricao.value = input.descricao;
            bd.tipo.value = input.tipo;
            bd.codigoFiscal.value = input.codigoFiscal;
            bd.idBandeiraCartao.value = input.idBandeiraCartao;
            bd.habilitarValorDigitadoFechamento.value = input.habilitarValorDigitadoFechamento == "1";

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.FormaPagamento bd = new Tables.FormaPagamento();

            bd.idFormaPagamento.value = ((Data.FormaPagamento)parametros["Key"]).idFormaPagamento;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.FormaPagamento)bd).idFormaPagamento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.FormaPagamento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.FormaPagamento)input).idFormaPagamento = ((Tables.FormaPagamento)bd).idFormaPagamento.value;
                    ((Data.FormaPagamento)input).descricao = ((Tables.FormaPagamento)bd).descricao.value;
                    ((Data.FormaPagamento)input).tipo = ((Tables.FormaPagamento)bd).tipo.value;
                    ((Data.FormaPagamento)input).codigoFiscal = ((Tables.FormaPagamento)bd).codigoFiscal.value;
                    ((Data.FormaPagamento)input).idBandeiraCartao = ((Tables.FormaPagamento)bd).idBandeiraCartao.value;
                    ((Data.FormaPagamento)input).habilitarValorDigitadoFechamento = ((Tables.FormaPagamento)bd).habilitarValorDigitadoFechamento.value ? "1" : "0";

                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.FormaPagamento result = (Data.FormaPagamento)parametros["Key"];

            try
            {
                result = (Data.FormaPagamento)this.preencher
                (
                    new Data.FormaPagamento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.FormaPagamento),
                        new Object[]
                        {
                            result.idFormaPagamento
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

            if (_params != null)
            {
                if (_params.ContainsKey("numRows"))
                    numRows = (int)_params["numRows"];
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

            Data.FormaPagamento _input = (Data.FormaPagamento)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idFormaPagamento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "formaPagamento.idFormaPagamento = @idFormaPagamento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idFormaPagamento", _input.idFormaPagamento));
                    if (!sqlOrderBy.Contains("formaPagamento.idFormaPagamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "formaPagamento.idFormaPagamento");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   formaPagamento.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("formaPagamento.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "formaPagamento.descricao");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.habilitarValorDigitadoFechamento))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   formaPagamento.habilitarValorDigitadoFechamento = @habilitarValorDigitadoFechamento");
                    fieldKeys.Add(new EJB.TableBase.TFieldBoolean("habilitarValorDigitadoFechamento", _input.habilitarValorDigitadoFechamento == "1"));
                    if (!sqlOrderBy.Contains("formaPagamento.habilitarValorDigitadoFechamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "formaPagamento.habilitarValorDigitadoFechamento");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   formaPagamento.* " +
                    "from " +
                    "   formaPagamento " +
                    (sqlWhere.Length > 0 ? " where " + sqlWhere : "") +
                    (sqlOrderBy.Length > 0 ? " order by " + sqlOrderBy : "") +
                    (((numRows > 0) && (offSet >= 0)) ? " offset " + offSet + " rows fetch next " + numRows + " rows only" : "")
                );

                table = null;
            }
            else { }

            return result;
        }

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.FormaPagamento input = (Data.FormaPagamento)parametros["Key"];
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
                    typeof(Tables.FormaPagamento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.FormaPagamento _data in
                    (System.Collections.Generic.List<Tables.FormaPagamento>)this.m_EntityManager.list
                    (
                        typeof(Tables.FormaPagamento),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.FormaPagamento(), _data, level);

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
