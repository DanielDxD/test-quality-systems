using System;

namespace WS.CRUD
{
    public class AtividadeEconomica : WS.CRUD.Base
    {
        public AtividadeEconomica(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.AtividadeEconomica input = (Data.AtividadeEconomica)parametros["Key"];
            Tables.AtividadeEconomica bd = new Tables.AtividadeEconomica();

            bd.idAtividadeEconomica.isNull = true;
            bd.descricao.value = input.descricao;
            bd.codigoCNAE.value = input.codigoCNAE;

            this.m_EntityManager.persist(bd);

            ((Data.AtividadeEconomica)parametros["Key"]).idAtividadeEconomica = (int)bd.idAtividadeEconomica.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.AtividadeEconomica input = (Data.AtividadeEconomica)parametros["Key"];
            Tables.AtividadeEconomica bd = (Tables.AtividadeEconomica)this.m_EntityManager.find
            (
                typeof(Tables.AtividadeEconomica),
                new Object[]
                {
                    input.idAtividadeEconomica
                }
            );

            bd.descricao.value = input.descricao;
            bd.codigoCNAE.value = input.codigoCNAE;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.AtividadeEconomica bd = new Tables.AtividadeEconomica();

            bd.idAtividadeEconomica.value = ((Data.AtividadeEconomica)parametros["Key"]).idAtividadeEconomica;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.AtividadeEconomica)bd).idAtividadeEconomica.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.AtividadeEconomica)input).operacao = ENum.eOperacao.NONE;

                    ((Data.AtividadeEconomica)input).idAtividadeEconomica = ((Tables.AtividadeEconomica)bd).idAtividadeEconomica.value;
                    ((Data.AtividadeEconomica)input).descricao = ((Tables.AtividadeEconomica)bd).descricao.value;
                    ((Data.AtividadeEconomica)input).codigoCNAE = ((Tables.AtividadeEconomica)bd).codigoCNAE.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.AtividadeEconomica result = (Data.AtividadeEconomica)parametros["Key"];

            try
            {
                result = (Data.AtividadeEconomica)this.preencher
                (
                    new Data.AtividadeEconomica(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.AtividadeEconomica),
                        new Object[]
                        {
                            result.idAtividadeEconomica
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

            Data.AtividadeEconomica _input = (Data.AtividadeEconomica)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idAtividadeEconomica > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "atividadeEconomica.idAtividadeEconomica = @idAtividadeEconomica");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idAtividadeEconomica", _input.idAtividadeEconomica));
                    if (!sqlOrderBy.Contains("atividadeEconomica.idAtividadeEconomica"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "atividadeEconomica.idAtividadeEconomica");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   atividadeEconomica.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("atividadeEconomica.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "atividadeEconomica.descricao");
                    else { }
                }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   atividadeEconomica.* " +
                    "from " +
                    "   atividadeEconomica " +
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
            Data.AtividadeEconomica input = (Data.AtividadeEconomica)parametros["Key"];
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
                    typeof(Tables.AtividadeEconomica),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.AtividadeEconomica _data in
                    (System.Collections.Generic.List<Tables.AtividadeEconomica>)this.m_EntityManager.list
                    (
                        typeof(Tables.AtividadeEconomica),
                        _select.Replace("order by idAtividadeEconomica", "order by descricao, idAtividadeEconomica"),
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.AtividadeEconomica(), _data, level);

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
