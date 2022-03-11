using System;

namespace WS.CRUD
{
    public class ContasAReceberItemDesconto : WS.CRUD.Base
    {
        public ContasAReceberItemDesconto(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ContasAReceberItemDesconto input = (Data.ContasAReceberItemDesconto)parametros["Key"];
            Tables.ContasAReceberItemDesconto bd = new Tables.ContasAReceberItemDesconto();

            bd.idContasAReceberItemDesconto.isNull = true;
            bd.contasAReceberItem.idContasAReceberItem.value = input.contasAReceberItem.idContasAReceberItem;
            bd.dataLimite.value = input.dataLimite;
            bd.valorDesconto.value = input.valorDesconto;

            this.m_EntityManager.persist(bd);

            ((Data.ContasAReceberItemDesconto)parametros["Key"]).idContasAReceberItemDesconto = (int)bd.idContasAReceberItemDesconto.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ContasAReceberItemDesconto input = (Data.ContasAReceberItemDesconto)parametros["Key"];
            Tables.ContasAReceberItemDesconto bd = (Tables.ContasAReceberItemDesconto)this.m_EntityManager.find
            (
                typeof(Tables.ContasAReceberItemDesconto),
                new Object[]
                {
                    input.idContasAReceberItemDesconto
                }
            );

            bd.contasAReceberItem.idContasAReceberItem.value = input.contasAReceberItem.idContasAReceberItem;
            bd.dataLimite.value = input.dataLimite;
            bd.valorDesconto.value = input.valorDesconto;

            this.m_EntityManager.merge(bd);
            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ContasAReceberItemDesconto bd = new Tables.ContasAReceberItemDesconto();

            bd.idContasAReceberItemDesconto.value = ((Data.ContasAReceberItemDesconto)parametros["Key"]).idContasAReceberItemDesconto;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ContasAReceberItemDesconto)bd).idContasAReceberItemDesconto.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ContasAReceberItemDesconto)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ContasAReceberItemDesconto)input).idContasAReceberItemDesconto = ((Tables.ContasAReceberItemDesconto)bd).idContasAReceberItemDesconto.value;
                    ((Data.ContasAReceberItemDesconto)input).contasAReceberItem = (Data.ContasAReceberItem)(new WS.CRUD.ContasAReceberItem(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContasAReceberItem(),
                        ((Tables.ContasAReceberItemDesconto)bd).contasAReceberItem,
                        level + 1
                    );
                    ((Data.ContasAReceberItemDesconto)input).dataLimite = ((Tables.ContasAReceberItemDesconto)bd).dataLimite.value;
                    ((Data.ContasAReceberItemDesconto)input).valorDesconto = ((Tables.ContasAReceberItemDesconto)bd).valorDesconto.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.ContasAReceberItemDesconto result = (Data.ContasAReceberItemDesconto)parametros["Key"];

            try
            {
                result = (Data.ContasAReceberItemDesconto)this.preencher
                (
                    new Data.ContasAReceberItemDesconto(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ContasAReceberItemDesconto),
                        new Object[]
                        {
                            result.idContasAReceberItemDesconto
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

                if (_params.ContainsKey("offSet"))
                    offSet = (int)_params["offSet"];
                else { }

                if (_params.ContainsKey("where"))
                    sqlWhere = ((String)_params["where"] ?? "");
                else { }

                if (_params.ContainsKey("orderBy"))
                    sqlOrderBy = ((String)_params["orderBy"] ?? "");
                else { }

                if (_params.ContainsKey("onlyCount"))
                    onlyCount = (bool)_params["onlyCount"];
                else { }
            }
            else { }

            Data.ContasAReceberItemDesconto _input = (Data.ContasAReceberItemDesconto)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idContasAReceberItemDesconto > 0)
                {
                    sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "ContasAReceberItemDesconto.idContasAReceberItemDesconto = @idContasAReceberItemDesconto";
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContasAReceberItemDesconto", _input.idContasAReceberItemDesconto));
                    if (!sqlOrderBy.Contains("ContasAReceberItemDesconto.idContasAReceberItemDesconto"))
                        sqlOrderBy += (sqlOrderBy.Length > 0 ? ", " : "") + "ContasAReceberItemDesconto.idContasAReceberItemDesconto";
                    else { }
                }
                else { }

                if (_input.dataLimite.Ticks > 0)
                {
                    sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "ContasAReceberItemDesconto.dataLimite = @dataLimite";
                    fieldKeys.Add(new EJB.TableBase.TFieldDatetime("dataLimite", _input.dataLimite));
                    if (!sqlOrderBy.Contains("ContasAReceberItemDesconto.dataLimite"))
                        sqlOrderBy += (sqlOrderBy.Length > 0 ? ", " : "") + "ContasAReceberItemDesconto.dataLimite";
                    else { }
                }
                else { }

                if(_input.contasAReceberItem != null)
                {
                    if(_input.contasAReceberItem.idContasAReceberItem > 0)
                    {
                        sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "ContasAReceberItemDesconto.idContasAReceberItem = @idContasAReceberItem";
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContasAReceberItem", _input.contasAReceberItem.idContasAReceberItem));
                        if (!sqlOrderBy.Contains("ContasAReceberItemDesconto.idContasAReceberItem"))
                            sqlOrderBy += (sqlOrderBy.Length > 0 ? ", " : "") + "ContasAReceberItemDesconto.idContasAReceberItem";
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "ContasAReceberItemDesconto.* ") +
                    "from " +
                    "   ContasAReceberItemDesconto " +

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
            Data.ContasAReceberItemDesconto input = (Data.ContasAReceberItemDesconto)parametros["Key"];
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
                    typeof(Tables.ContasAReceberItemDesconto),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ContasAReceberItemDesconto _data in
                    (System.Collections.Generic.List<Tables.ContasAReceberItemDesconto>)this.m_EntityManager.list
                    (
                        typeof(Tables.ContasAReceberItemDesconto),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.ContasAReceberItemDesconto(), _data, level);

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
