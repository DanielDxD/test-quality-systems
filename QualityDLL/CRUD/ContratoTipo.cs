using System;
using System.Linq;

namespace WS.CRUD
{
    public class ContratoTipo : WS.CRUD.Base
    {
        public ContratoTipo(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ContratoTipo input = (Data.ContratoTipo)parametros["Key"];
            Tables.ContratoTipo bd = new Tables.ContratoTipo();

            bd.idContratoTipo.isNull = true;
            if (input.contratoTipoRecorrencia != null && input.contratoTipoRecorrencia.idContratoTipoRecorrencia > 0)
                bd.contratoTipoRecorrencia.idContratoTipoRecorrencia.value = input.contratoTipoRecorrencia.idContratoTipoRecorrencia;
            else
                bd.contratoTipoRecorrencia.idContratoTipoRecorrencia.isNull = true;

            if (input.naturezaOperacao != null && input.naturezaOperacao.idNaturezaOperacao > 0)
                bd.naturezaOperacao.idNaturezaOperacao.value = input.naturezaOperacao.idNaturezaOperacao;
            else
                bd.naturezaOperacao.idNaturezaOperacao.isNull = true;

            if (input.departamento != null && input.departamento.idDepartamento > 0)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else
                bd.departamento.idDepartamento.isNull = true;

            if (input.categoriaTitulo != null && input.categoriaTitulo.idCategoriaTitulo > 0)
                bd.categoriaTitulo.idCategoriaTitulo.value = input.categoriaTitulo.idCategoriaTitulo;
            else
                bd.categoriaTitulo.idCategoriaTitulo.isNull = true;

            bd.diaVencimento.value = input.diaVencimento;
            bd.descricao.value = input.descricao;
            bd.valorBase.value = input.valorBase;


            this.m_EntityManager.persist(bd);

            ((Data.ContratoTipo)parametros["Key"]).idContratoTipo = (int)bd.idContratoTipo.value;

            if (input.contratoTipoItem != null)
            {
                WS.CRUD.ContratoTipoItem contratoTipoItemsCRUD = new WS.CRUD.ContratoTipoItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.contratoTipoItem.Length; i++)
                {
                    input.contratoTipoItem[i].contratoTipo = new Data.ContratoTipo { idContratoTipo = bd.idContratoTipo.value };
                    _parameters.Add("Key", input.contratoTipoItem[i]);
                    contratoTipoItemsCRUD.atualizar(_parameters);
                    if (input.contratoTipoItem[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.contratoTipoItem[i] = (Data.ContratoTipoItem)contratoTipoItemsCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                _parameters = null;
                contratoTipoItemsCRUD = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ContratoTipo input = (Data.ContratoTipo)parametros["Key"];
            Tables.ContratoTipo bd = (Tables.ContratoTipo)this.m_EntityManager.find
            (
                typeof(Tables.ContratoTipo),
                new Object[]
                {
                    input.idContratoTipo
                }
            );

            if (input.contratoTipoRecorrencia != null && input.contratoTipoRecorrencia.idContratoTipoRecorrencia > 0)
                bd.contratoTipoRecorrencia.idContratoTipoRecorrencia.value = input.contratoTipoRecorrencia.idContratoTipoRecorrencia;
            else
                bd.contratoTipoRecorrencia.idContratoTipoRecorrencia.isNull = true;

            if (input.naturezaOperacao != null && input.naturezaOperacao.idNaturezaOperacao > 0)
                bd.naturezaOperacao.idNaturezaOperacao.value = input.naturezaOperacao.idNaturezaOperacao;
            else
                bd.naturezaOperacao.idNaturezaOperacao.isNull = true;

            if (input.departamento != null && input.departamento.idDepartamento > 0)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else
                bd.departamento.idDepartamento.isNull = true;

            if (input.categoriaTitulo != null && input.categoriaTitulo.idCategoriaTitulo > 0)
                bd.categoriaTitulo.idCategoriaTitulo.value = input.categoriaTitulo.idCategoriaTitulo;
            else
                bd.categoriaTitulo.idCategoriaTitulo.isNull = true;

            bd.diaVencimento.value = input.diaVencimento;
            bd.descricao.value = input.descricao;
            bd.valorBase.value = input.valorBase;

            this.m_EntityManager.merge(bd);

            if (input.contratoTipoItem != null)
            {
                WS.CRUD.ContratoTipoItem contratoTipoItemsCRUD = new WS.CRUD.ContratoTipoItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.contratoTipoItem.Length; i++)
                {
                    input.contratoTipoItem[i].contratoTipo = new Data.ContratoTipo
                    {
                        idContratoTipo = bd.idContratoTipo.value
                    };
                    _parameters.Add("Key", input.contratoTipoItem[i]);
                    if (input.contratoTipoItem[i].operacao == ENum.eOperacao.NONE)
                        input.contratoTipoItem[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    contratoTipoItemsCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                contratoTipoItemsCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ContratoTipo bd = new Tables.ContratoTipo();

            bd.idContratoTipo.value = ((Data.ContratoTipo)parametros["Key"]).idContratoTipo;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ContratoTipo)bd).idContratoTipo.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ContratoTipo)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ContratoTipo)input).idContratoTipo = ((Tables.ContratoTipo)bd).idContratoTipo.value;
                    ((Data.ContratoTipo)input).diaVencimento = ((Tables.ContratoTipo)bd).diaVencimento.value;
                    ((Data.ContratoTipo)input).descricao = ((Tables.ContratoTipo)bd).descricao.value;
                    ((Data.ContratoTipo)input).valorBase = ((Tables.ContratoTipo)bd).valorBase.value;
                    ((Data.ContratoTipo)input).contratoTipoRecorrencia = (Data.ContratoTipoRecorrencia)(new WS.CRUD.ContratoTipoRecorrencia(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContratoTipoRecorrencia(),
                        ((Tables.ContratoTipo)bd).contratoTipoRecorrencia,
                        level + 1
                    );
                    ((Data.ContratoTipo)input).naturezaOperacao = (Data.NaturezaOperacao)(new WS.CRUD.NaturezaOperacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.NaturezaOperacao(),
                        ((Tables.ContratoTipo)bd).naturezaOperacao,
                        level + 1
                    );
                    ((Data.ContratoTipo)input).departamento = (Data.Departamento)(new WS.CRUD.Departamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Departamento(),
                        ((Tables.ContratoTipo)bd).departamento,
                        level + 1
                    );
                    ((Data.ContratoTipo)input).categoriaTitulo = (Data.CategoriaTitulo)(new WS.CRUD.CategoriaTitulo(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.CategoriaTitulo(),
                        ((Tables.ContratoTipo)bd).categoriaTitulo,
                        level + 1
                    );

                    if (level < 1)
                    {
                        //Preencher ContratoTipoItem
                        if (((Tables.ContratoTipo)bd).contratoTipoItem != null)
                        {
                            System.Collections.Generic.List<Data.ContratoTipoItem> _list = new System.Collections.Generic.List<Data.ContratoTipoItem>();

                            foreach (Tables.ContratoTipoItem _item in ((Tables.ContratoTipo)bd).contratoTipoItem)
                            {
                                _list.Add
                                (
                                    (Data.ContratoTipoItem)
                                    (new WS.CRUD.ContratoTipoItem(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.ContratoTipoItem(),
                                        _item,
                                        level + 1
                                    )
                                );
                            }

                            ((Data.ContratoTipo)input).contratoTipoItem = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.ContratoTipo)input).contratoTipoItem != null)
                            {
                                System.Collections.Generic.List<Data.ContratoTipoItem> _list = new System.Collections.Generic.List<Data.ContratoTipoItem>();

                                foreach (Data.ContratoTipoItem _item in ((Data.ContratoTipo)input).contratoTipoItem)
                                {
                                    if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                    {
                                        _item.operacao = ENum.eOperacao.NONE;
                                        _list.Add(_item);
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.ContratoTipo)input).contratoTipoItem = _list.ToArray();
                                else
                                    ((Data.ContratoTipo)input).contratoTipoItem = null;

                                _list.Clear();
                                _list = null;
                            }
                            else { }
                        }
                    }
                    else { }
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.ContratoTipo result = (Data.ContratoTipo)parametros["Key"];

            try
            {
                result = (Data.ContratoTipo)this.preencher
                (
                    new Data.ContratoTipo(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ContratoTipo),
                        new Object[]
                        {
                            result.idContratoTipo
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

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.ContratoTipo input = (Data.ContratoTipo)parametros["Key"];
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
                    typeof(Tables.ContratoTipo),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ContratoTipo _data in
                    (System.Collections.Generic.List<Tables.ContratoTipo>)this.m_EntityManager.list
                    (
                        typeof(Tables.ContratoTipo),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    if (mode == "Roll")
                    {
                        _base = new Data.ContratoTipo();
                        ((Data.ContratoTipo)_base).idContratoTipo = _data.idContratoTipo.value;
                        ((Data.ContratoTipo)_base).descricao = _data.descricao.value;
                        ((Data.ContratoTipo)_base).contratoTipoRecorrencia = new Data.ContratoTipoRecorrencia
                        {
                            idContratoTipoRecorrencia = _data.contratoTipoRecorrencia.idContratoTipoRecorrencia.value,
                            descricao = _data.contratoTipoRecorrencia.descricao.value
                        };
                        ((Data.ContratoTipo)_base).naturezaOperacao = new Data.NaturezaOperacao
                        {
                            idNaturezaOperacao = _data.naturezaOperacao.idNaturezaOperacao.value,
                            descricao = _data.naturezaOperacao.descricao.value
                        };
                        ((Data.ContratoTipo)_base).departamento = new Data.Departamento
                        {
                            idDepartamento = _data.departamento.idDepartamento.value,
                            descricao = _data.departamento.descricao.value
                        };

                        ((Data.ContratoTipo)_base).categoriaTitulo = new Data.CategoriaTitulo
                        {
                            idCategoriaTitulo = _data.categoriaTitulo.idCategoriaTitulo.value,
                            descricao = _data.categoriaTitulo.descricao.value
                        };

                        ((Data.ContratoTipo)_base).diaVencimento = _data.diaVencimento.value;
                        ((Data.ContratoTipo)_base).valorBase = _data.valorBase.value;

                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.ContratoTipo(), _data, level);

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

            Data.ContratoTipo _input = (Data.ContratoTipo)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idContratoTipo > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contratoTipo.idContratoTipo = @idContratoTipo");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContratoTipo", _input.idContratoTipo));
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contratoTipo.idContratoTipo");
                }
                else { }


                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contratoTipo.descricao LIKE @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", "%" + _input.descricao + "%"));
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contratoTipo.descricao");
                }
                else { }
                if (_input.valorBase > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contratoTipo.valorBase = @valorBase");
                    fieldKeys.Add(new EJB.TableBase.TFieldDouble("valorBase", _input.valorBase));
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contratoTipo.valorBase");
                }

                if (_input.naturezaOperacao != null)
                {

                    if (_input.naturezaOperacao.idNaturezaOperacao > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contratoTipo.idNaturezaOperacao = @idNaturezaOperacao");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idNaturezaOperacao", _input.naturezaOperacao.idNaturezaOperacao));
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contratoTipo.idNaturezaOperacao");
                    }
                }

                if (_input.departamento != null)
                {

                    if (_input.departamento.idDepartamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contratoTipo.idDepartamento = @idDepartamento");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamento", _input.departamento.idDepartamento));
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contratoTipo.idDepartamento");
                    }
                }
                if (_input.contratoTipoRecorrencia != null)
                {

                    if (_input.contratoTipoRecorrencia.idContratoTipoRecorrencia > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contratoTipo.idContratoTipoRecorrencia = @idContratoTipoRecorrencia");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContratoTipoRecorrencia", _input.contratoTipoRecorrencia.idContratoTipoRecorrencia));
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contratoTipo.idContratoTipoRecorrencia");
                    }
                }
                if (_input.categoriaTitulo != null)
                {

                    if (_input.categoriaTitulo.idCategoriaTitulo > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contratoTipo.idCategoriaTitulo = @idCategoriaTitulo");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idCategoriaTitulo", _input.categoriaTitulo.idCategoriaTitulo));
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contratoTipo.idCategoriaTitulo");
                    }
                }


                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "contratoTipo.* ") +
                    "from " +
                    (
                        "   contratoTipo contratoTipo "
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



    }
}
