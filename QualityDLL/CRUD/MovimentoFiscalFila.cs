using System;

namespace WS.CRUD
{
    public class MovimentoFiscalFila : WS.CRUD.Base
    {
        public MovimentoFiscalFila(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.MovimentoFiscalFila input = (Data.MovimentoFiscalFila)parametros["Key"];
            Tables.MovimentoFiscalFila bd = new Tables.MovimentoFiscalFila();

            bd.ordem.value = input.ordem;
            bd.statusNfc.value = String.IsNullOrEmpty(input.statusNfc) ? "pendente" : input.statusNfc;
            if (input.pdvCompra != null)
                bd.pdvCompra.idPdvCompra.value = input.pdvCompra.idPdvCompra;
            else { }

            this.m_EntityManager.persist(bd);
            ((Data.MovimentoFiscalFila)parametros["Key"]).idMovimentoFiscalFila = (int)bd.idMovimentoFiscalFila.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.MovimentoFiscalFila input = (Data.MovimentoFiscalFila)parametros["Key"];
            Tables.MovimentoFiscalFila bd = (Tables.MovimentoFiscalFila)this.m_EntityManager.find
            (
                typeof(Tables.MovimentoFiscalFila),
                new Object[]
                {
                    input.idMovimentoFiscalFila
                }
            );

            bd.ordem.value = input.ordem;
            bd.statusNfc.value = String.IsNullOrEmpty(input.statusNfc) ? "pendente" : input.statusNfc;
            if (input.pdvCompra != null)
                bd.pdvCompra.idPdvCompra.value = input.pdvCompra.idPdvCompra;
            else { }
            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.MovimentoFiscalFila bd = new Tables.MovimentoFiscalFila();

            bd.idMovimentoFiscalFila.value = ((Data.MovimentoFiscalFila)parametros["Key"]).idMovimentoFiscalFila;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
                if
                (
                    !((Tables.MovimentoFiscalFila)bd).idMovimentoFiscalFila.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.MovimentoFiscalFila)input).operacao = ENum.eOperacao.NONE;

                    ((Data.MovimentoFiscalFila)input).idMovimentoFiscalFila = ((Tables.MovimentoFiscalFila)bd).idMovimentoFiscalFila.value;
                    ((Data.MovimentoFiscalFila)input).ordem = ((Tables.MovimentoFiscalFila)bd).ordem.value;
                    ((Data.MovimentoFiscalFila)input).statusNfc = ((Tables.MovimentoFiscalFila)bd).statusNfc.value;
                    ((Data.MovimentoFiscalFila)input).pdvCompra = (Data.PdvCompra)(new WS.CRUD.PdvCompra(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PdvCompra(),
                        ((Tables.MovimentoFiscalFila)bd).pdvCompra,
                        level + 1
                    );
                }
                else { }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.MovimentoFiscalFila result = (Data.MovimentoFiscalFila)parametros["Key"];

            try
            {
                result = (Data.MovimentoFiscalFila)this.preencher
                (
                    new Data.MovimentoFiscalFila(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.MovimentoFiscalFila),
                        new Object[]
                        {
                            result.idMovimentoFiscalFila
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

            Data.MovimentoFiscalFila _input = (Data.MovimentoFiscalFila)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                //sqlWhere = (sqlWhere.Contains("'") ? sqlWhere.Replace("'", "''") : sqlWhere);

                if (_input.idMovimentoFiscalFila > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "MovimentoFiscalFila.idMovimentoFiscalFila = @idMovimentoFiscalFila");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idMovimentoFiscalFila", _input.idMovimentoFiscalFila));
                    if (!sqlOrderBy.Contains("MovimentoFiscalFila.idMovimentoFiscalFila"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "MovimentoFiscalFila.idMovimentoFiscalFila");
                    else { }
                }
                else { }

                if (_input.ordem > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "MovimentoFiscalFila.ordem = @ordem");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("ordem", _input.ordem));
                    if (!sqlOrderBy.Contains("MovimentoFiscalFila.ordem"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "MovimentoFiscalFila.ordem");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.statusNfc))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "MovimentoFiscalFila.statusNfc = @statusNfc");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("statusNfc", _input.statusNfc));
                    if (!sqlOrderBy.Contains("MovimentoFiscalFila.statusNfc"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "MovimentoFiscalFila.statusNfc");
                    else { }
                }
                else { }

                if (_input.pdvCompra != null)
                {
                    if (_input.pdvCompra.idPdvCompra > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "movimentoFiscalFila.idPdvCompra = @idPdvCompra");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvCompra", _input.pdvCompra.idPdvCompra));
                        if (!sqlOrderBy.Contains("movimentoFiscalFila.idPdvCompra"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "movimentoFiscalFila.idPdvCompra");
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "MovimentoFiscalFila.* ") +
                    "from " +
                    (
                        "   MovimentoFiscalFila MovimentoFiscalFila "
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

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.MovimentoFiscalFila input = (Data.MovimentoFiscalFila)parametros["Key"];
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
                    typeof(Tables.MovimentoFiscalFila),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.MovimentoFiscalFila _data in
                    (System.Collections.Generic.List<Tables.MovimentoFiscalFila>)this.m_EntityManager.list
                    (
                        typeof(Tables.MovimentoFiscalFila),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.MovimentoFiscalFila();
                        ((Data.MovimentoFiscalFila)_base).idMovimentoFiscalFila = _data.idMovimentoFiscalFila.value;
                        ((Data.MovimentoFiscalFila)_base).ordem = _data.ordem.value;
                        ((Data.MovimentoFiscalFila)_base).statusNfc = _data.statusNfc.value;
                        ((Data.MovimentoFiscalFila)_base).pdvCompra = new Data.PdvCompra
                        {
                            idPdvCompra = _data.pdvCompra.idPdvCompra.value
                        };
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.MovimentoFiscalFila(), _data, level);

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
