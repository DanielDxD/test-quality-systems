using System;

namespace WS.CRUD
{
    public class Perfil : WS.CRUD.Base
    {
        public Perfil(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Perfil input = (Data.Perfil)parametros["Key"];
            Tables.Perfil bd = new Tables.Perfil();

            bd.idPerfil.isNull = true;
            bd.descricao.value = input.descricao;
            bd.administrador.value = input.administrador;

            this.m_EntityManager.persist(bd);

            ((Data.Perfil)parametros["Key"]).idPerfil = (int)bd.idPerfil.value;

            //Processa PerfilMenu
            if (input.perfilMenus != null)
            {
                WS.CRUD.PerfilMenu perfilMenuCRUD = new WS.CRUD.PerfilMenu(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.perfilMenus.Length; i++)
                {
                    input.perfilMenus[i].perfil = new Data.Perfil();
                    input.perfilMenus[i].perfil.idPerfil = bd.idPerfil.value;
                    _parameters.Add("Key", input.perfilMenus[i]);
                    perfilMenuCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                perfilMenuCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Perfil input = (Data.Perfil)parametros["Key"];
            Tables.Perfil bd = (Tables.Perfil)this.m_EntityManager.find
            (
                typeof(Tables.Perfil),
                new Object[]
                {
                    input.idPerfil
                }
            );

            bd.descricao.value = input.descricao;
            bd.administrador.value = input.administrador;

            this.m_EntityManager.merge(bd);

            //Processa PerfilMenu
            if (input.perfilMenus != null)
            {
                WS.CRUD.PerfilMenu perfilMenuCRUD = new WS.CRUD.PerfilMenu(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.perfilMenus.Length; i++)
                {
                    input.perfilMenus[i].perfil = new Data.Perfil();
                    input.perfilMenus[i].perfil.idPerfil = bd.idPerfil.value;
                    _parameters.Add("Key", input.perfilMenus[i]);
                    if (input.perfilMenus[i].operacao == ENum.eOperacao.NONE)
                        input.perfilMenus[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    perfilMenuCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                perfilMenuCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Perfil bd = new Tables.Perfil();

            bd.idPerfil.value = ((Data.Perfil)parametros["Key"]).idPerfil;

            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Perfil)bd).idPerfil.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Perfil)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Perfil)input).idPerfil = ((Tables.Perfil)bd).idPerfil.value;
                    ((Data.Perfil)input).descricao = ((Tables.Perfil)bd).descricao.value;
                    ((Data.Perfil)input).administrador = ((Tables.Perfil)bd).administrador.value;

                    if (level < 2)
                    {
                        //Preencher PerfilMenus
                        if (((Tables.Perfil)bd).perfilMenus != null)
                        {
                            System.Collections.Generic.List<Data.PerfilMenu> _list = new System.Collections.Generic.List<Data.PerfilMenu>();

                            foreach (Tables.PerfilMenu _item in ((Tables.Perfil)bd).perfilMenus)
                            {
                                _list.Add
                                (
                                    (Data.PerfilMenu)
                                    (new WS.CRUD.PerfilMenu(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.PerfilMenu(),
                                        _item,
                                        level + 1
                                    )
                                );
                            }

                            ((Data.Perfil)input).perfilMenus = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.Perfil)input).perfilMenus != null)
                            {
                                System.Collections.Generic.List<Data.PerfilMenu> _list = new System.Collections.Generic.List<Data.PerfilMenu>();

                                foreach (Data.PerfilMenu _item in ((Data.Perfil)input).perfilMenus)
                                {
                                    if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                    {
                                        _item.operacao = ENum.eOperacao.NONE;
                                        _list.Add(_item);
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.Perfil)input).perfilMenus = _list.ToArray();
                                else
                                    ((Data.Perfil)input).perfilMenus = null;

                                _list.Clear();
                                _list = null;
                            }
                            else { }
                        }

                        //Preencher RelatorioPerfil
                        if (((Tables.Perfil)bd).relatorioPerfil != null)
                        {
                            System.Collections.Generic.List<Data.RelatorioPerfil> _list = new System.Collections.Generic.List<Data.RelatorioPerfil>();

                            foreach (Tables.RelatorioPerfil _item in ((Tables.Perfil)bd).relatorioPerfil)
                            {
                                _list.Add
                                (
                                    (Data.RelatorioPerfil)
                                    (new WS.CRUD.RelatorioPerfil(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.RelatorioPerfil(),
                                        _item,
                                        level + 1
                                    )
                                );
                            }

                            ((Data.Perfil)input).relatorioPerfil = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.Perfil)input).relatorioPerfil != null)
                            {
                                System.Collections.Generic.List<Data.RelatorioPerfil> _list = new System.Collections.Generic.List<Data.RelatorioPerfil>();

                                foreach (Data.RelatorioPerfil _item in ((Data.Perfil)input).relatorioPerfil)
                                {
                                    if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                    {
                                        _item.operacao = ENum.eOperacao.NONE;
                                        _list.Add(_item);
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.Perfil)input).relatorioPerfil = _list.ToArray();
                                else
                                    ((Data.Perfil)input).relatorioPerfil = null;

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
            Data.Perfil result = (Data.Perfil)parametros["Key"];

            try
            {
                result = (Data.Perfil)this.preencher
                (
                    new Data.Perfil(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Perfil),
                        new Object[]
                        {
                            result.idPerfil
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

            Data.Perfil _input = (Data.Perfil)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idPerfil > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "perfil.idPerfil = @idPerfil");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPerfil", _input.idPerfil));
                    if (!sqlOrderBy.Contains("perfil.idPerfil"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "perfil.idPerfil");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   perfil.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("perfil.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "perfil.descricao");
                    else { }
                }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "perfil.* ") +
                    "from " +
                    "   perfil " +
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
            Data.Perfil input = (Data.Perfil)parametros["Key"];
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
                    typeof(Tables.Perfil),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Perfil _data in
                    (System.Collections.Generic.List<Tables.Perfil>)this.m_EntityManager.list
                    (
                        typeof(Tables.Perfil),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.Perfil();
                        ((Data.Perfil)_base).idPerfil = _data.idPerfil.value;
                        ((Data.Perfil)_base).descricao = _data.descricao.value;
                        ((Data.Perfil)_base).administrador = _data.administrador.value;
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.Perfil(), _data, level);

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
