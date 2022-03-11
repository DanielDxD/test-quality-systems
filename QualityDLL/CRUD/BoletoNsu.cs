using System;

namespace WS.CRUD
{
    public class BoletoNsu : WS.CRUD.Base
    {
        public BoletoNsu(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.BoletoNsu input = (Data.BoletoNsu)parametros["Key"];
            Tables.BoletoNsu bd = new Tables.BoletoNsu();

            bd.idBoletoNsu.isNull = true;
            bd.boleto.idBoleto.value = input.boleto.idBoleto;
            bd.dataRegistro.value = input.dataRegistro;
            bd.nsu.value = input.nsu;

            this.m_EntityManager.persist(bd);

            ((Data.BoletoNsu)parametros["Key"]).idBoletoNsu = (int)bd.idBoletoNsu.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.BoletoNsu input = (Data.BoletoNsu)parametros["Key"];
            Tables.BoletoNsu bd = (Tables.BoletoNsu)this.m_EntityManager.find
            (
                typeof(Tables.BoletoNsu),
                new Object[]
                {
                    input.idBoletoNsu
                }
            );


            bd.boleto.idBoleto.value = input.boleto.idBoleto;
            bd.dataRegistro.value = input.dataRegistro;
            bd.nsu.value = input.nsu;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.BoletoNsu bd = new Tables.BoletoNsu();

            bd.idBoletoNsu.value = ((Data.BoletoNsu)parametros["Key"]).idBoletoNsu;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.BoletoNsu)bd).idBoletoNsu.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.BoletoNsu)input).operacao = ENum.eOperacao.NONE;

                    ((Data.BoletoNsu)input).idBoletoNsu = ((Tables.BoletoNsu)bd).idBoletoNsu.value;
                    ((Data.BoletoNsu)input).nsu = ((Tables.BoletoNsu)bd).nsu.value;
                    ((Data.BoletoNsu)input).dataRegistro = ((Tables.BoletoNsu)bd).dataRegistro.value;
                    ((Data.BoletoNsu)input).boleto = (Data.Boleto)(new WS.CRUD.Boleto(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Boleto(),
                        ((Tables.BoletoNsu)bd).boleto,
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
            Data.BoletoNsu result = (Data.BoletoNsu)parametros["Key"];

            try
            {
                result = (Data.BoletoNsu)this.preencher
                (
                    new Data.BoletoNsu(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.BoletoNsu),
                        new Object[]
                        {
                            result.idBoletoNsu
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

            Data.BoletoNsu _input = (Data.BoletoNsu)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idBoletoNsu > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "BoletoNsu.idBoletoNsu = @idBoletoNsu");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idBoletoNsu", _input.idBoletoNsu));
                    if (!sqlOrderBy.Contains("BoletoNsu.idBoletoNsu"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "BoletoNsu.idBoletoNsu");
                    else { }
                }
                else { }

                if(_input.dataRegistro.Ticks > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "CAST(BoletoNsu.dataRegistro AS DATE) = CAST(@dataRegistro AS DATE)");
                    fieldKeys.Add(new EJB.TableBase.TFieldDatetime("dataRegistro", _input.dataRegistro.Date));
                    if (!sqlOrderBy.Contains("BoletoNsu.dataRegistro"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "BoletoNsu.dataRegistro");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.nsu))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "BoletoNsu.nsu = @nsu");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("nsu", _input.nsu));
                    if (!sqlOrderBy.Contains("BoletoNsu.nsu"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "BoletoNsu.nsu");
                    else { }
                }
                else { }

                if (_input.boleto != null)
                {
                    if (_input.boleto.idBoleto > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "BoletoNsu.idBoleto = @idBoleto");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idBoleto", _input.boleto.idBoleto));
                        if (!sqlOrderBy.Contains("BoletoNsu.idBoleto"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "BoletoNsu.idBoleto");
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "BoletoNsu.* ") +
                    "from " +
                    "   BoletoNsu " +

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
            Data.BoletoNsu input = (Data.BoletoNsu)parametros["Key"];
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
                    typeof(Tables.BoletoNsu),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.BoletoNsu _data in
                    (System.Collections.Generic.List<Tables.BoletoNsu>)this.m_EntityManager.list
                    (
                        typeof(Tables.BoletoNsu),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.BoletoNsu(), _data, level);

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
