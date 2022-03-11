using System;

namespace WS.CRUD
{
    public class Boleto : WS.CRUD.Base
    {
        public Boleto(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Boleto input = (Data.Boleto)parametros["Key"];
            Tables.Boleto bd = new Tables.Boleto();

            bd.idBoleto.isNull = true;
            if (input.parametroBoleto != null)
                bd.parametroBoleto.idParametroBoleto.value = input.parametroBoleto.idParametroBoleto;
            else { }
            bd.dataEmissao.value = input.dataEmissao;
            bd.valor.value = input.valor;
            bd.dataVencimento.value = input.dataVencimento;
            bd.nossoNumero.value = input.nossoNumero;
            bd.valorTaxa.value = input.valorTaxa;
            bd.dataRegistro.value = input.dataRegistro;
            bd.statusBoleto.value = input.statusBoletoQuery;
            bd.codigoRetorno.value = input.codigoRetorno;
            bd.nossoNumeroDigito.value = input.nossoNumeroDigito;
            bd.codigoBarras.value = input.codigoBarras;

            this.m_EntityManager.persist(bd);

            ((Data.Boleto)parametros["Key"]).idBoleto = (int)bd.idBoleto.value;

            //Processa BoletoItem
            if (input.boletoItems != null)
            {
                WS.CRUD.BoletoItem boletoItemCRUD = new WS.CRUD.BoletoItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.boletoItems.Length; i++)
                {
                    input.boletoItems[i].boleto = new Data.Boleto();
                    input.boletoItems[i].boleto.idBoleto = bd.idBoleto.value;
                    _parameters.Add("Key", input.boletoItems[i]);
                    boletoItemCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                boletoItemCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Boleto input = (Data.Boleto)parametros["Key"];
            Tables.Boleto bd = (Tables.Boleto)this.m_EntityManager.find
            (
                typeof(Tables.Boleto),
                new Object[]
                {
                    input.idBoleto
                }
            );

            if (input.parametroBoleto != null)
                bd.parametroBoleto.idParametroBoleto.value = input.parametroBoleto.idParametroBoleto;
            else { }
            bd.dataEmissao.value = input.dataEmissao;
            bd.valor.value = input.valor;
            bd.dataVencimento.value = input.dataVencimento;
            bd.nossoNumero.value = input.nossoNumero;
            bd.valorTaxa.value = input.valorTaxa;
            bd.dataRegistro.value = input.dataRegistro;
            bd.statusBoleto.value = input.statusBoletoQuery;
            bd.codigoRetorno.value = input.codigoRetorno;
            bd.nossoNumeroDigito.value = input.nossoNumeroDigito;
            bd.codigoBarras.value = input.codigoBarras;

            this.m_EntityManager.merge(bd);

            //Processa BoletoItem
            if (input.boletoItems != null)
            {
                WS.CRUD.BoletoItem boletoItemCRUD = new WS.CRUD.BoletoItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.boletoItems.Length; i++)
                {
                    input.boletoItems[i].boleto = new Data.Boleto();
                    input.boletoItems[i].boleto.idBoleto = bd.idBoleto.value;
                    _parameters.Add("Key", input.boletoItems[i]);
                    if (input.boletoItems[i].operacao == ENum.eOperacao.NONE)
                        input.boletoItems[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    boletoItemCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                boletoItemCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Boleto bd = new Tables.Boleto();

            bd.idBoleto.value = ((Data.Boleto)parametros["Key"]).idBoleto;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Boleto)bd).idBoleto.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Boleto)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Boleto)input).idBoleto = ((Tables.Boleto)bd).idBoleto.value;
                    ((Data.Boleto)input).parametroBoleto = (Data.ParametroBoleto)(new WS.CRUD.ParametroBoleto(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ParametroBoleto(),
                        ((Tables.Boleto)bd).parametroBoleto,
                        level + 1
                    );
                    ((Data.Boleto)input).dataEmissao = ((Tables.Boleto)bd).dataEmissao.value;
                    ((Data.Boleto)input).valor = ((Tables.Boleto)bd).valor.value;
                    ((Data.Boleto)input).dataVencimento = ((Tables.Boleto)bd).dataVencimento.value;
                    ((Data.Boleto)input).nossoNumero = ((Tables.Boleto)bd).nossoNumero.value;
                    ((Data.Boleto)input).valorTaxa = ((Tables.Boleto)bd).valorTaxa.value;
                    ((Data.Boleto)input).dataRegistro = ((Tables.Boleto)bd).dataRegistro.value;
                    ((Data.Boleto)input).statusBoleto = ((Tables.Boleto)bd).statusBoleto.value;
                    ((Data.Boleto)input).codigoRetorno = ((Tables.Boleto)bd).codigoRetorno.value;
                    ((Data.Boleto)input).nossoNumeroDigito = ((Tables.Boleto)bd).nossoNumeroDigito.value;
                    ((Data.Boleto)input).codigoBarras = ((Tables.Boleto)bd).codigoBarras.value;
                }
                else { }

                if (level < 1)
                {
                    //Preencher BoletoItems
                    if (((Tables.Boleto)bd).boletoItems != null)
                    {
                        System.Collections.Generic.List<Data.BoletoItem> _list = new System.Collections.Generic.List<Data.BoletoItem>();

                        foreach (Tables.BoletoItem _item in ((Tables.Boleto)bd).boletoItems)
                        {
                            _list.Add
                            (
                                (Data.BoletoItem)
                                (new WS.CRUD.BoletoItem(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.BoletoItem(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.Boleto)input).boletoItems = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.Boleto)input).boletoItems != null)
                        {
                            System.Collections.Generic.List<Data.BoletoItem> _list = new System.Collections.Generic.List<Data.BoletoItem>();

                            foreach (Data.BoletoItem _item in ((Data.Boleto)input).boletoItems)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.Boleto)input).boletoItems = _list.ToArray();
                            else
                                ((Data.Boleto)input).boletoItems = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.Boleto result = (Data.Boleto)parametros["Key"];

            try
            {
                result = (Data.Boleto)this.preencher
                (
                    new Data.Boleto(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Boleto),
                        new Object[]
                        {
                            result.idBoleto
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

            Data.Boleto _input = (Data.Boleto)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idBoleto > 0)
                {
                    sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "Boleto.idBoleto = @idBoleto";
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idBoleto", _input.idBoleto));
                    if (!sqlOrderBy.Contains("Boleto.idBoleto"))
                        sqlOrderBy += (sqlOrderBy.Length > 0 ? ", " : "") + "Boleto.idBoleto";
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.codigoBarras))
                {
                    sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "Boleto.codigoBarras = @codigoBarras";
                    fieldKeys.Add(new EJB.TableBase.TFieldString("codigoBarras", _input.codigoBarras));
                    if (!sqlOrderBy.Contains("Boleto.codigoBarras"))
                        sqlOrderBy += (sqlOrderBy.Length > 0 ? ", " : "") + "Boleto.codigoBarras";
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.nossoNumero))
                {
                    sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "Boleto.nossoNumero = @nossoNumero";
                    fieldKeys.Add(new EJB.TableBase.TFieldString("nossoNumero", _input.nossoNumero));
                    if (!sqlOrderBy.Contains("Boleto.nossoNumero"))
                        sqlOrderBy += (sqlOrderBy.Length > 0 ? ", " : "") + "Boleto.nossoNumero";
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "Boleto.* ") +
                    "from " +
                    "   Boleto " +

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
            Data.Boleto input = (Data.Boleto)parametros["Key"];
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
                    typeof(Tables.Boleto),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Boleto _data in
                    (System.Collections.Generic.List<Tables.Boleto>)this.m_EntityManager.list
                    (
                        typeof(Tables.Boleto),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.Boleto();
                        ((Data.Boleto)_base).idBoleto = _data.idBoleto.value;
                        ((Data.Boleto)_base).parametroBoleto = new Data.ParametroBoleto
                        {
                            idParametroBoleto = _data.parametroBoleto.idParametroBoleto.value
                        };
                        ((Data.Boleto)_base).dataEmissao = _data.dataEmissao.value;
                        ((Data.Boleto)_base).valor = _data.valor.value;
                        ((Data.Boleto)_base).dataVencimento = _data.dataVencimento.value;
                        ((Data.Boleto)_base).nossoNumero = _data.nossoNumero.value;
                        ((Data.Boleto)_base).valorTaxa = _data.valorTaxa.value;
                        ((Data.Boleto)_base).dataRegistro = _data.dataRegistro.value;
                        ((Data.Boleto)_base).statusBoleto = _data.statusBoleto.value;
                        ((Data.Boleto)_base).codigoRetorno = _data.codigoRetorno.value;
                        ((Data.Boleto)_base).nossoNumeroDigito = _data.nossoNumeroDigito.value;
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.Boleto(), _data, level);

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
