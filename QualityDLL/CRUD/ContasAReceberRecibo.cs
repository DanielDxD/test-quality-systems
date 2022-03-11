using System;

namespace WS.CRUD
{
    public class ContasAReceberRecibo : WS.CRUD.Base
    {
        public ContasAReceberRecibo(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ContasAReceberRecibo input = (Data.ContasAReceberRecibo)parametros["Key"];
            Tables.ContasAReceberRecibo bd = new Tables.ContasAReceberRecibo();

            bd.idContasAReceberRecibo.isNull = true;
            bd.dataRecibo.value = input.dataRecibo;
            bd.valorTotal.value = input.valorTotal;
            bd.jurosTotal.value = input.jurosTotal;
            bd.multaTotal.value = input.multaTotal;
            bd.descontoTotal.value = input.descontoTotal;

            this.m_EntityManager.persist(bd);

            ((Data.ContasAReceberRecibo)parametros["Key"]).idContasAReceberRecibo = (int)bd.idContasAReceberRecibo.value;

            //Processa ContasAReceberPagamento
            if (input.contasAReceberPagamentos != null)
            {
                WS.CRUD.ContasAReceberPagamento ContasAReceberPagamentoCRUD = new WS.CRUD.ContasAReceberPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.contasAReceberPagamentos.Length; i++)
                {
                    input.contasAReceberPagamentos[i].contasAReceberRecibo = new Data.ContasAReceberRecibo();
                    input.contasAReceberPagamentos[i].contasAReceberRecibo.idContasAReceberRecibo = bd.idContasAReceberRecibo.value;
                    _parameters.Add("Key", input.contasAReceberPagamentos[i]);
                    ContasAReceberPagamentoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                ContasAReceberPagamentoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ContasAReceberRecibo input = (Data.ContasAReceberRecibo)parametros["Key"];
            Tables.ContasAReceberRecibo bd = (Tables.ContasAReceberRecibo)this.m_EntityManager.find
            (
                typeof(Tables.ContasAReceberRecibo),
                new Object[]
                {
                    input.idContasAReceberRecibo
                }
            );


            bd.dataRecibo.value = input.dataRecibo;
            bd.valorTotal.value = input.valorTotal;
            bd.jurosTotal.value = input.jurosTotal;
            bd.multaTotal.value = input.multaTotal;
            bd.descontoTotal.value = input.descontoTotal;

            this.m_EntityManager.merge(bd);

            //Processa ContasAReceberPagamento
            if (input.contasAReceberPagamentos != null)
            {
                WS.CRUD.ContasAReceberPagamento ContasAReceberPagamentoCRUD = new WS.CRUD.ContasAReceberPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.contasAReceberPagamentos.Length; i++)
                {
                    input.contasAReceberPagamentos[i].contasAReceberRecibo = new Data.ContasAReceberRecibo();
                    input.contasAReceberPagamentos[i].contasAReceberRecibo.idContasAReceberRecibo = bd.idContasAReceberRecibo.value;
                    _parameters.Add("Key", input.contasAReceberPagamentos[i]);
                    if (input.contasAReceberPagamentos[i].operacao == ENum.eOperacao.NONE)
                        input.contasAReceberPagamentos[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    ContasAReceberPagamentoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                ContasAReceberPagamentoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ContasAReceberRecibo bd = new Tables.ContasAReceberRecibo();

            bd.idContasAReceberRecibo.value = ((Data.ContasAReceberRecibo)parametros["Key"]).idContasAReceberRecibo;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ContasAReceberRecibo)bd).idContasAReceberRecibo.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ContasAReceberRecibo)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ContasAReceberRecibo)input).idContasAReceberRecibo = ((Tables.ContasAReceberRecibo)bd).idContasAReceberRecibo.value;
                    ((Data.ContasAReceberRecibo)input).dataRecibo = ((Tables.ContasAReceberRecibo)bd).dataRecibo.value;
                    ((Data.ContasAReceberRecibo)input).valorTotal = ((Tables.ContasAReceberRecibo)bd).valorTotal.value;
                    ((Data.ContasAReceberRecibo)input).jurosTotal = ((Tables.ContasAReceberRecibo)bd).jurosTotal.value;
                    ((Data.ContasAReceberRecibo)input).multaTotal = ((Tables.ContasAReceberRecibo)bd).multaTotal.value;
                    ((Data.ContasAReceberRecibo)input).descontoTotal = ((Tables.ContasAReceberRecibo)bd).descontoTotal.value;
                }
                else { }

                if (level < 1)
                {
                    //Preencher contasAReceberPagamentos
                    if (((Tables.ContasAReceberRecibo)bd).contasAReceberPagamentos != null)
                    {
                        System.Collections.Generic.List<Data.ContasAReceberPagamento> _list = new System.Collections.Generic.List<Data.ContasAReceberPagamento>();

                        foreach (Tables.ContasAReceberPagamento _item in ((Tables.ContasAReceberRecibo)bd).contasAReceberPagamentos)
                        {
                            _list.Add
                            (
                                (Data.ContasAReceberPagamento)
                                (new WS.CRUD.ContasAReceberPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.ContasAReceberPagamento(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.ContasAReceberRecibo)input).contasAReceberPagamentos = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.ContasAReceberRecibo)input).contasAReceberPagamentos != null)
                        {
                            System.Collections.Generic.List<Data.ContasAReceberPagamento> _list = new System.Collections.Generic.List<Data.ContasAReceberPagamento>();

                            foreach (Data.ContasAReceberPagamento _item in ((Data.ContasAReceberRecibo)input).contasAReceberPagamentos)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.ContasAReceberRecibo)input).contasAReceberPagamentos = _list.ToArray();
                            else
                                ((Data.ContasAReceberRecibo)input).contasAReceberPagamentos = null;

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
            Data.ContasAReceberRecibo result = (Data.ContasAReceberRecibo)parametros["Key"];

            try
            {
                result = (Data.ContasAReceberRecibo)this.preencher
                (
                    new Data.ContasAReceberRecibo(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ContasAReceberRecibo),
                        new Object[]
                        {
                            result.idContasAReceberRecibo
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

            Data.ContasAReceberRecibo _input = (Data.ContasAReceberRecibo)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idContasAReceberRecibo > 0)
                {
                    sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "ContasAReceberRecibo.idContasAReceberRecibo = @idContasAReceberRecibo";
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContasAReceberRecibo", _input.idContasAReceberRecibo));
                    if (!sqlOrderBy.Contains("ContasAReceberRecibo.idContasAReceberRecibo"))
                        sqlOrderBy += (sqlOrderBy.Length > 0 ? ", " : "") + "ContasAReceberRecibo.idContasAReceberRecibo";
                    else { }
                }
                else { }


                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "ContasAReceberRecibo.* ") +
                    "from " +
                    "   ContasAReceberRecibo " +

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
            Data.ContasAReceberRecibo input = (Data.ContasAReceberRecibo)parametros["Key"];
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
                    typeof(Tables.ContasAReceberRecibo),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ContasAReceberRecibo _data in
                    (System.Collections.Generic.List<Tables.ContasAReceberRecibo>)this.m_EntityManager.list
                    (
                        typeof(Tables.ContasAReceberRecibo),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.ContasAReceberRecibo();
                        ((Data.ContasAReceberRecibo)_base).idContasAReceberRecibo = _data.idContasAReceberRecibo.value;
                        ((Data.ContasAReceberRecibo)_base).dataRecibo = _data.dataRecibo.value;
                        ((Data.ContasAReceberRecibo)_base).valorTotal = _data.valorTotal.value;
                        ((Data.ContasAReceberRecibo)_base).multaTotal = _data.multaTotal.value;
                        ((Data.ContasAReceberRecibo)_base).jurosTotal = _data.jurosTotal.value;
                        ((Data.ContasAReceberRecibo)_base).descontoTotal = _data.descontoTotal.value;
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.ContasAReceberRecibo(), _data, level);

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
