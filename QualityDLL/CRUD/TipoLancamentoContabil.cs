using System;

namespace WS.CRUD
{
    public class TipoLancamentoContabil : WS.CRUD.Base
    {
        public TipoLancamentoContabil(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.TipoLancamentoContabil input = (Data.TipoLancamentoContabil)parametros["Key"];
            Tables.TipoLancamentoContabil bd = new Tables.TipoLancamentoContabil();

            bd.idTipoLancamentoContabil.isNull = true;
            bd.descricao.value = input.descricao;
            bd.debitoCredito.value = input.debitoCredito;

            this.m_EntityManager.persist(bd);

            ((Data.TipoLancamentoContabil)parametros["Key"]).idTipoLancamentoContabil = (int)bd.idTipoLancamentoContabil.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.TipoLancamentoContabil input = (Data.TipoLancamentoContabil)parametros["Key"];
            Tables.TipoLancamentoContabil bd = (Tables.TipoLancamentoContabil)this.m_EntityManager.find
            (
                typeof(Tables.TipoLancamentoContabil),
                new Object[]
                {
                    input.idTipoLancamentoContabil
                }
            );

            bd.descricao.value = input.descricao;
            bd.debitoCredito.value = input.debitoCredito;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.TipoLancamentoContabil bd = new Tables.TipoLancamentoContabil();

            bd.idTipoLancamentoContabil.value = ((Data.TipoLancamentoContabil)parametros["Key"]).idTipoLancamentoContabil;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.TipoLancamentoContabil)bd).idTipoLancamentoContabil.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.TipoLancamentoContabil)input).operacao = ENum.eOperacao.NONE;

                    ((Data.TipoLancamentoContabil)input).idTipoLancamentoContabil = ((Tables.TipoLancamentoContabil)bd).idTipoLancamentoContabil.value;
                    ((Data.TipoLancamentoContabil)input).descricao = ((Tables.TipoLancamentoContabil)bd).descricao.value;
                    ((Data.TipoLancamentoContabil)input).debitoCredito = ((Tables.TipoLancamentoContabil)bd).debitoCredito.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.TipoLancamentoContabil result = (Data.TipoLancamentoContabil)parametros["Key"];

            try
            {
                result = (Data.TipoLancamentoContabil)this.preencher
                (
                    new Data.TipoLancamentoContabil(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.TipoLancamentoContabil),
                        new Object[]
                        {
                            result.idTipoLancamentoContabil
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

            Data.TipoLancamentoContabil _input = (Data.TipoLancamentoContabil)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idTipoLancamentoContabil > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tipoLancamentoContabil.idTipoLancamentoContabil = @idTipoLancamentoContabil");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTipoLancamentoContabil", _input.idTipoLancamentoContabil));
                    if (!sqlOrderBy.Contains("tipoLancamentoContabil.idTipoLancamentoContabil"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoLancamentoContabil.idTipoLancamentoContabil");
                    else { }
                }
                else { }


                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   tipoLancamentoContabil.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("tipoLancamentoContabil.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoLancamentoContabil.descricao");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   tipoLancamentoContabil.*\n" +
                    "from \n" + 
                    "   tipoLancamentoContabil\n" +
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
            Data.TipoLancamentoContabil input = (Data.TipoLancamentoContabil)parametros["Key"];
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
                    typeof(Tables.TipoLancamentoContabil),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.TipoLancamentoContabil _data in
                    (System.Collections.Generic.List<Tables.TipoLancamentoContabil>)this.m_EntityManager.list
                    (
                        typeof(Tables.TipoLancamentoContabil),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.TipoLancamentoContabil(), _data, level);

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
