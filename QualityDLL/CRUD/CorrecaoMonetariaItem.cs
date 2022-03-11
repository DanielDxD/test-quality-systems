using System;

namespace WS.CRUD
{
    public class CorrecaoMonetariaItem : WS.CRUD.Base
    {
        public CorrecaoMonetariaItem(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.CorrecaoMonetariaItem input = (Data.CorrecaoMonetariaItem)parametros["Key"];
            Tables.CorrecaoMonetariaItem bd = new Tables.CorrecaoMonetariaItem();

            bd.idCorrecaoMonetariaItem.isNull = true;

            bd.correcaoMonetaria.idCorrecaoMonetaria.value = input.correcaoMonetaria.idCorrecaoMonetaria;
            bd.mesReferencia.value = input.mesReferencia;
            bd.valorIndice.value = input.valorIndice;

            this.m_EntityManager.persist(bd);

            ((Data.CorrecaoMonetariaItem)parametros["Key"]).idCorrecaoMonetariaItem = (int)bd.idCorrecaoMonetariaItem.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.CorrecaoMonetariaItem input = (Data.CorrecaoMonetariaItem)parametros["Key"];
            Tables.CorrecaoMonetariaItem bd = (Tables.CorrecaoMonetariaItem)this.m_EntityManager.find
            (
                typeof(Tables.CorrecaoMonetariaItem),
                new Object[]
                {
                    input.idCorrecaoMonetariaItem
                }
            );

            bd.correcaoMonetaria.idCorrecaoMonetaria.value = input.correcaoMonetaria.idCorrecaoMonetaria;
            bd.mesReferencia.value = input.mesReferencia;
            bd.valorIndice.value = input.valorIndice;

            this.m_EntityManager.merge(bd);
            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.CorrecaoMonetariaItem bd = new Tables.CorrecaoMonetariaItem();

            bd.idCorrecaoMonetariaItem.value = ((Data.CorrecaoMonetariaItem)parametros["Key"]).idCorrecaoMonetariaItem;

            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.CorrecaoMonetariaItem)bd).idCorrecaoMonetariaItem.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.CorrecaoMonetariaItem)input).operacao = ENum.eOperacao.NONE;

                    ((Data.CorrecaoMonetariaItem)input).idCorrecaoMonetariaItem = ((Tables.CorrecaoMonetariaItem)bd).idCorrecaoMonetariaItem.value;
                    ((Data.CorrecaoMonetariaItem)input).mesReferencia = ((Tables.CorrecaoMonetariaItem)bd).mesReferencia.value;
                    ((Data.CorrecaoMonetariaItem)input).valorIndice = ((Tables.CorrecaoMonetariaItem)bd).valorIndice.value;

                    ((Data.CorrecaoMonetariaItem)input).correcaoMonetaria = (Data.CorrecaoMonetaria)(new WS.CRUD.CorrecaoMonetaria(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.CorrecaoMonetaria(),
                        ((Tables.CorrecaoMonetariaItem)bd).correcaoMonetaria,
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
            Data.CorrecaoMonetariaItem result = (Data.CorrecaoMonetariaItem)parametros["Key"];

            try
            {
                result = (Data.CorrecaoMonetariaItem)this.preencher
                (
                    new Data.CorrecaoMonetariaItem(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.CorrecaoMonetariaItem),
                        new Object[]
                        {
                            result.idCorrecaoMonetariaItem
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

            Data.CorrecaoMonetariaItem _input = (Data.CorrecaoMonetariaItem)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idCorrecaoMonetariaItem > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "CorrecaoMonetariaItem.idCorrecaoMonetariaItem = @idCorrecaoMonetariaItem");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idCorrecaoMonetariaItem", _input.idCorrecaoMonetariaItem));
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "CorrecaoMonetariaItem.idCorrecaoMonetariaItem");
                }
                else { }

                if (_input.correcaoMonetaria != null)
                {
                    if (_input.correcaoMonetaria.idCorrecaoMonetaria > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "CorrecaoMonetariaItem.idCorrecaoMonetaria = @idCorrecaoMonetaria");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idCorrecaoMonetaria", _input.correcaoMonetaria.idCorrecaoMonetaria));
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "CorrecaoMonetariaItem.idCorrecaoMonetaria");
                    }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "CorrecaoMonetariaItem.* ") +
                    "from " +
                    (
                        "   CorrecaoMonetariaItem CorrecaoMonetariaItem " +
                        "INNER JOIN correcaoMonetaria ON correcaoMonetaria.idCorrecaoMonetaria = CorrecaoMonetariaItem.idCorrecaoMonetaria"
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
            Data.CorrecaoMonetariaItem input = (Data.CorrecaoMonetariaItem)parametros["Key"];
            System.Collections.Generic.List<Data.Base> result = new System.Collections.Generic.List<Data.Base>();
            string mode = (string)(parametros["Mode"] == null ? "" : parametros["Mode"]);
            int level = (int)(parametros["Level"] == null ? 0 : parametros["Level"]);
            bool telaSocio = (bool)(parametros["TelaSocio"] == null ? false : parametros["TelaSocio"]);

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
                    typeof(Tables.CorrecaoMonetariaItem),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.CorrecaoMonetariaItem _data in
                    (System.Collections.Generic.List<Tables.CorrecaoMonetariaItem>)this.m_EntityManager.list
                    (
                        typeof(Tables.CorrecaoMonetariaItem),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.CorrecaoMonetariaItem(), _data, level);

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
