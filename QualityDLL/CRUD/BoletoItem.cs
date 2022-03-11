using System;

namespace WS.CRUD
{
    public class BoletoItem : WS.CRUD.Base
    {
        public BoletoItem(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.BoletoItem input = (Data.BoletoItem)parametros["Key"];
            Tables.BoletoItem bd = new Tables.BoletoItem();

            bd.idBoletoItem.isNull = true;
            if (input.boleto != null)
                bd.boleto.idBoleto.value = input.boleto.idBoleto;
            else { }
            if (input.contasAReceber != null)
                bd.contasAReceber.idContasAReceber.value = input.contasAReceber.idContasAReceber;
            else { }
            bd.valor.value = input.valor;
            bd.juros.value = input.juros;
            bd.multa.value = input.multa;

            this.m_EntityManager.persist(bd);

            ((Data.BoletoItem)parametros["Key"]).idBoletoItem = (int)bd.idBoletoItem.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.BoletoItem input = (Data.BoletoItem)parametros["Key"];
            Tables.BoletoItem bd = (Tables.BoletoItem)this.m_EntityManager.find
            (
                typeof(Tables.BoletoItem),
                new Object[]
                {
                    input.idBoletoItem
                }
            );

            if (input.boleto != null)
                bd.boleto.idBoleto.value = input.boleto.idBoleto;
            else { }
            if (input.contasAReceber != null)
                bd.contasAReceber.idContasAReceber.value = input.contasAReceber.idContasAReceber;
            else { }
            bd.valor.value = input.valor;
            bd.juros.value = input.juros;
            bd.multa.value = input.multa;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.BoletoItem bd = new Tables.BoletoItem();

            bd.idBoletoItem.value = ((Data.BoletoItem)parametros["Key"]).idBoletoItem;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.BoletoItem)bd).idBoletoItem.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.BoletoItem)input).operacao = ENum.eOperacao.NONE;

                    ((Data.BoletoItem)input).idBoletoItem = ((Tables.BoletoItem)bd).idBoletoItem.value;
                    ((Data.BoletoItem)input).boleto = (Data.Boleto)(new WS.CRUD.Boleto(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Boleto(),
                        ((Tables.BoletoItem)bd).boleto,
                        level + 1
                    );
                    ((Data.BoletoItem)input).contasAReceber = (Data.ContasAReceber)(new WS.CRUD.ContasAReceber(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContasAReceber(),
                        ((Tables.BoletoItem)bd).contasAReceber,
                        level + 1
                    );
                    ((Data.BoletoItem)input).valor = ((Tables.BoletoItem)bd).valor.value;
                    ((Data.BoletoItem)input).juros = ((Tables.BoletoItem)bd).juros.value;
                    ((Data.BoletoItem)input).multa = ((Tables.BoletoItem)bd).multa.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.BoletoItem result = (Data.BoletoItem)parametros["Key"];

            try
            {
                result = (Data.BoletoItem)this.preencher
                (
                    new Data.BoletoItem(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.BoletoItem),
                        new Object[]
                        {
                            result.idBoletoItem
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

            Data.BoletoItem _input = (Data.BoletoItem)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idBoletoItem > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "BoletoItem.idBoletoItem = @idBoletoItem");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idBoletoItem", _input.idBoletoItem));
                    if (!sqlOrderBy.Contains("BoletoItem.idBoletoItem"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "BoletoItem.idBoletoItem");
                    else { }
                }
                else { }

                if (_input.contasAReceber != null)
                {
                    if (_input.contasAReceber.idContasAReceber > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "BoletoItem.idContasAReceber = @idContasAReceber");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContasAReceber", _input.contasAReceber.idContasAReceber));
                        if (!sqlOrderBy.Contains("BoletoItem.idContasAReceber"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "BoletoItem.idContasAReceber");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.boleto != null)
                {
                    if (_input.boleto.dataVencimento.Ticks > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "boleto.dataVencimento = @dataVencimento");
                        fieldKeys.Add(new EJB.TableBase.TFieldDatetime("dataVencimento", _input.boleto.dataVencimento));
                        if (!sqlOrderBy.Contains("boleto.dataVencimento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "boleto.dataVencimento");
                        else { }
                    }
                    else { }

                    if (!String.IsNullOrEmpty(_input.boleto.statusBoletoQuery))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "boleto.statusBoleto = @statusBoleto");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("statusBoleto", _input.boleto.statusBoletoQuery));
                        if (!sqlOrderBy.Contains("boleto.statusBoleto"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "boleto.statusBoleto");
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "BoletoItem.* ") +
                    "from " +
                    "   BoletoItem " +
                    "INNER JOIN boleto boleto ON boleto.idBoleto = BoletoItem.idBoleto " +
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
            Data.BoletoItem input = (Data.BoletoItem)parametros["Key"];
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
                    typeof(Tables.BoletoItem),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.BoletoItem _data in
                    (System.Collections.Generic.List<Tables.BoletoItem>)this.m_EntityManager.list
                    (
                        typeof(Tables.BoletoItem),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    if (mode == "Roll")
                    {
                        _base = new Data.BoletoItem();
                        ((Data.BoletoItem)_base).idBoletoItem = _data.idBoletoItem.value;
                        ((Data.BoletoItem)_base).boleto = new Data.Boleto
                        {
                            idBoleto = _data.boleto.idBoleto.value
                        };
                        ((Data.BoletoItem)_base).contasAReceber = new Data.ContasAReceber
                        {
                            idContasAReceber = _data.contasAReceber.idContasAReceber.value
                        };
                        ((Data.BoletoItem)_base).valor = _data.valor.value;
                        ((Data.BoletoItem)_base).juros = _data.juros.value;
                        ((Data.BoletoItem)_base).multa = _data.multa.value;
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.BoletoItem(), _data, level);

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
