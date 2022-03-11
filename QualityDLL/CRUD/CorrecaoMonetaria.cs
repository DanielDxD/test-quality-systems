using System;

namespace WS.CRUD
{
    public class CorrecaoMonetaria : WS.CRUD.Base
    {
        public CorrecaoMonetaria(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.CorrecaoMonetaria input = (Data.CorrecaoMonetaria)parametros["Key"];
            Tables.CorrecaoMonetaria bd = new Tables.CorrecaoMonetaria();

            bd.idCorrecaoMonetaria.isNull = true;
            /*if(input.pessoa != null)
                bd.pessoa.idPessoa.value = input.pessoa.idPessoa;
            else
                bd.pessoa.idPessoa.value = input.empresaRelacionamento.pessoa.idPessoa;
                */

            if (!String.IsNullOrEmpty(input.ativo))
                bd.ativo.value = input.ativo.ToLower() == "s";
            else
                bd.ativo.value = false;
            bd.descricao.value = input.descricao;

            this.m_EntityManager.persist(bd);

            ((Data.CorrecaoMonetaria)parametros["Key"]).idCorrecaoMonetaria = (int)bd.idCorrecaoMonetaria.value;

            if (input.correcaoMonetariaItems != null)
            {
                WS.CRUD.CorrecaoMonetariaItem correcaoMonetariaItemCRUD = new WS.CRUD.CorrecaoMonetariaItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.correcaoMonetariaItems.Length; i++)
                {
                    if (input.correcaoMonetariaItems[i].correcaoMonetaria == null)
                    {
                        input.correcaoMonetariaItems[i].correcaoMonetaria = new Data.CorrecaoMonetaria();
                        input.correcaoMonetariaItems[i].correcaoMonetaria.idCorrecaoMonetaria = bd.idCorrecaoMonetaria.value;
                    }
                    _parameters.Add("Key", input.correcaoMonetariaItems[i]);
                    correcaoMonetariaItemCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                correcaoMonetariaItemCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.CorrecaoMonetaria input = (Data.CorrecaoMonetaria)parametros["Key"];
            Tables.CorrecaoMonetaria bd = (Tables.CorrecaoMonetaria)this.m_EntityManager.find
            (
                typeof(Tables.CorrecaoMonetaria),
                new Object[]
                {
                    input.idCorrecaoMonetaria
                }
            );

            if (!String.IsNullOrEmpty(input.ativo))
                bd.ativo.value = input.ativo.ToLower() == "s";
            else
                bd.ativo.value = false;
            bd.descricao.value = input.descricao;

            this.m_EntityManager.merge(bd);

            if (input.correcaoMonetariaItems != null)
            {
                WS.CRUD.CorrecaoMonetariaItem CorrecaoMonetariaItemCRUD = new WS.CRUD.CorrecaoMonetariaItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.correcaoMonetariaItems.Length; i++)
                {
                    if (input.correcaoMonetariaItems[i].correcaoMonetaria == null)
                        input.correcaoMonetariaItems[i].correcaoMonetaria = new Data.CorrecaoMonetaria { idCorrecaoMonetaria = bd.idCorrecaoMonetaria.value };
                    _parameters.Add("Key", input.correcaoMonetariaItems[i]);
                    if (input.correcaoMonetariaItems[i].operacao == ENum.eOperacao.NONE)
                        input.correcaoMonetariaItems[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    CorrecaoMonetariaItemCRUD.atualizar(_parameters);
                    if (input.correcaoMonetariaItems[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.correcaoMonetariaItems[i] = (Data.CorrecaoMonetariaItem)CorrecaoMonetariaItemCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                _parameters = null;
                CorrecaoMonetariaItemCRUD = null;
            }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.CorrecaoMonetaria bd = new Tables.CorrecaoMonetaria();

            bd.idCorrecaoMonetaria.value = ((Data.CorrecaoMonetaria)parametros["Key"]).idCorrecaoMonetaria;

            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.CorrecaoMonetaria)bd).idCorrecaoMonetaria.isNull
                )
                {
                    ((Data.CorrecaoMonetaria)input).operacao = ENum.eOperacao.NONE;

                    ((Data.CorrecaoMonetaria)input).idCorrecaoMonetaria = ((Tables.CorrecaoMonetaria)bd).idCorrecaoMonetaria.value;
                    ((Data.CorrecaoMonetaria)input).descricao = ((Tables.CorrecaoMonetaria)bd).descricao.value;
                }
                else { }


                if (level < 1)
                {
                    if (((Tables.CorrecaoMonetaria)bd).correcaoMonetariaItems != null)
                    {
                        System.Collections.Generic.List<Data.CorrecaoMonetariaItem> _list = new System.Collections.Generic.List<Data.CorrecaoMonetariaItem>();

                        foreach (Tables.CorrecaoMonetariaItem _item in ((Tables.CorrecaoMonetaria)bd).correcaoMonetariaItems)
                        {
                            _list.Add
                            (
                                (Data.CorrecaoMonetariaItem)
                                (new WS.CRUD.CorrecaoMonetariaItem(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.CorrecaoMonetariaItem(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.CorrecaoMonetaria)input).correcaoMonetariaItems = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.CorrecaoMonetaria)input).correcaoMonetariaItems != null)
                        {
                            System.Collections.Generic.List<Data.CorrecaoMonetariaItem> _list = new System.Collections.Generic.List<Data.CorrecaoMonetariaItem>();

                            foreach (Data.CorrecaoMonetariaItem _item in ((Data.CorrecaoMonetaria)input).correcaoMonetariaItems)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.CorrecaoMonetaria)input).correcaoMonetariaItems = _list.ToArray();
                            else
                                ((Data.CorrecaoMonetaria)input).correcaoMonetariaItems = null;

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
            Data.CorrecaoMonetaria result = (Data.CorrecaoMonetaria)parametros["Key"];

            try
            {
                result = (Data.CorrecaoMonetaria)this.preencher
                (
                    new Data.CorrecaoMonetaria(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.CorrecaoMonetaria),
                        new Object[]
                        {
                            result.idCorrecaoMonetaria
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

            Data.CorrecaoMonetaria _input = (Data.CorrecaoMonetaria)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idCorrecaoMonetaria > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "CorrecaoMonetaria.idCorrecaoMonetaria = @idCorrecaoMonetaria");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idCorrecaoMonetaria", _input.idCorrecaoMonetaria));
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "CorrecaoMonetaria.idCorrecaoMonetaria");
                }
                else { }


                if (!String.IsNullOrEmpty(_input.ativo))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "CorrecaoMonetaria.ativo = @ativo");
                    fieldKeys.Add(new EJB.TableBase.TFieldBoolean("ativo", _input.ativo.ToLower() == "s"));
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "CorrecaoMonetaria.* ") +
                    "from " +
                    (
                        "   CorrecaoMonetaria CorrecaoMonetaria "
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
            Data.CorrecaoMonetaria input = (Data.CorrecaoMonetaria)parametros["Key"];
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
                    typeof(Tables.CorrecaoMonetaria),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.CorrecaoMonetaria _data in
                    (System.Collections.Generic.List<Tables.CorrecaoMonetaria>)this.m_EntityManager.list
                    (
                        typeof(Tables.CorrecaoMonetaria),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.CorrecaoMonetaria(), _data, level);

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
