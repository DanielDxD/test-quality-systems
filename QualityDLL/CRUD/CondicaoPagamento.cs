using System;

namespace WS.CRUD
{
    public class CondicaoPagamento : WS.CRUD.Base
    {
        public CondicaoPagamento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.CondicaoPagamento input = (Data.CondicaoPagamento)parametros["Key"];
            Tables.CondicaoPagamento bd = new Tables.CondicaoPagamento();

            bd.idCondicaoPagamento.isNull = true;
            bd.descricao.value = input.descricao;
            bd.condicoes.value = input.condicoes;
            bd.diasCorridos.value = input.diasCorridos;
            bd.definidoPeloUsuario.value = input.definidoPeloUsuario;

            this.m_EntityManager.persist(bd);

            ((Data.CondicaoPagamento)parametros["Key"]).idCondicaoPagamento = (int)bd.idCondicaoPagamento.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.CondicaoPagamento input = (Data.CondicaoPagamento)parametros["Key"];
            Tables.CondicaoPagamento bd = (Tables.CondicaoPagamento)this.m_EntityManager.find
            (
                typeof(Tables.CondicaoPagamento),
                new Object[]
                {
                    input.idCondicaoPagamento
                }
            );

            bd.descricao.value = input.descricao;
            bd.condicoes.value = input.condicoes;
            bd.diasCorridos.value = input.diasCorridos;
            bd.definidoPeloUsuario.value = input.definidoPeloUsuario;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.CondicaoPagamento bd = new Tables.CondicaoPagamento();

            bd.idCondicaoPagamento.value = ((Data.CondicaoPagamento)parametros["Key"]).idCondicaoPagamento;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.CondicaoPagamento)bd).idCondicaoPagamento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.CondicaoPagamento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.CondicaoPagamento)input).idCondicaoPagamento = ((Tables.CondicaoPagamento)bd).idCondicaoPagamento.value;
                    ((Data.CondicaoPagamento)input).descricao = ((Tables.CondicaoPagamento)bd).descricao.value;
                    ((Data.CondicaoPagamento)input).condicoes = ((Tables.CondicaoPagamento)bd).condicoes.value;
                    ((Data.CondicaoPagamento)input).diasCorridos = ((Tables.CondicaoPagamento)bd).diasCorridos.value;
                    ((Data.CondicaoPagamento)input).definidoPeloUsuario = ((Tables.CondicaoPagamento)bd).definidoPeloUsuario.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.CondicaoPagamento result = (Data.CondicaoPagamento)parametros["Key"];

            try
            {
                result = (Data.CondicaoPagamento)this.preencher
                (
                    new Data.CondicaoPagamento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.CondicaoPagamento),
                        new Object[]
                        {
                            result.idCondicaoPagamento
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

            Data.CondicaoPagamento _input = (Data.CondicaoPagamento)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idCondicaoPagamento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "condicaoPagamento.idCondicaoPagamento = @idCondicaoPagamento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idCondicaoPagamento", _input.idCondicaoPagamento));
                    if (!sqlOrderBy.Contains("condicaoPagamento.idCondicaoPagamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "condicaoPagamento.idCondicaoPagamento");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   condicaoPagamento.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("condicaoPagamento.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "condicaoPagamento.descricao");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   condicaoPagamento.*\n" +
                    "from \n" + 
                    "   condicaoPagamento\n" +
                    (sqlWhere.Length > 0 ? "where " + sqlWhere : "") + "\n" +
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
            Data.CondicaoPagamento input = (Data.CondicaoPagamento)parametros["Key"];
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
                    typeof(Tables.CondicaoPagamento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.CondicaoPagamento _data in
                    (System.Collections.Generic.List<Tables.CondicaoPagamento>)this.m_EntityManager.list
                    (
                        typeof(Tables.CondicaoPagamento),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.CondicaoPagamento(), _data, level);

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
