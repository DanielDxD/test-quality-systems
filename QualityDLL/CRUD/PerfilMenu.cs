using System;

namespace WS.CRUD
{
    public class PerfilMenu : WS.CRUD.Base
    {
        public PerfilMenu(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PerfilMenu input = (Data.PerfilMenu)parametros["Key"];
            Tables.PerfilMenu bd = new Tables.PerfilMenu();

            bd.idPerfilMenu.isNull = true;

            bd.menu.idMenu.value = input.idMenu;
            if (input.perfil != null)
                bd.perfil.idPerfil.value = input.perfil.idPerfil;
            else { }
            bd.consultar.value = input.consultar;
            bd.incluir.value = input.incluir;
            bd.alterar.value = input.alterar;
            bd.excluir.value = input.excluir;

            this.m_EntityManager.persist(bd);

            ((Data.PerfilMenu)parametros["Key"]).idPerfilMenu = (int)bd.idPerfilMenu.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PerfilMenu input = (Data.PerfilMenu)parametros["Key"];
            Tables.PerfilMenu bd = (Tables.PerfilMenu)this.m_EntityManager.find
            (
                typeof(Tables.PerfilMenu),
                new Object[]
                {
                    input.idPerfilMenu
                }
            );

            bd.menu.idMenu.value = input.idMenu;
            if (input.perfil != null)
                bd.perfil.idPerfil.value = input.perfil.idPerfil;
            else { }
            bd.consultar.value = input.consultar;
            bd.incluir.value = input.incluir;
            bd.alterar.value = input.alterar;
            bd.excluir.value = input.excluir;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PerfilMenu bd = new Tables.PerfilMenu();

            bd.idPerfilMenu.value = ((Data.PerfilMenu)parametros["Key"]).idPerfilMenu;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PerfilMenu)bd).idPerfilMenu.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PerfilMenu)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PerfilMenu)input).idPerfilMenu = ((Tables.PerfilMenu)bd).idPerfilMenu.value;
                    input = (Data.PerfilMenu)(new WS.CRUD.Menu(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        input,
                        ((Tables.PerfilMenu)bd).menu,
                        level
                    );
                    ((Data.PerfilMenu)input).perfil = (Data.Perfil)(new WS.CRUD.Perfil(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Perfil(),
                        ((Tables.PerfilMenu)bd).perfil,
                        level + 1
                    );
                    ((Data.PerfilMenu)input).consultar = ((Tables.PerfilMenu)bd).consultar.value;
                    ((Data.PerfilMenu)input).incluir = ((Tables.PerfilMenu)bd).incluir.value;
                    ((Data.PerfilMenu)input).alterar = ((Tables.PerfilMenu)bd).alterar.value;
                    ((Data.PerfilMenu)input).excluir = ((Tables.PerfilMenu)bd).excluir.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PerfilMenu result = (Data.PerfilMenu)parametros["Key"];

            try
            {
                result = (Data.PerfilMenu)this.preencher
                (
                    new Data.PerfilMenu(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.PerfilMenu),
                        new Object[]
                        {
                            result.idPerfilMenu
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
            }
            else { }

            Data.PerfilMenu _input = (Data.PerfilMenu)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idMenu > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "perfilMenu.idMenu = @idMenu");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idMenu", _input.idMenu));
                    if (!sqlOrderBy.Contains("perfilMenu.idMenu"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "perfilMenu.idMenu");
                    else { }
                }
                else { }

                if (_input.idPerfilMenu > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "perfilMenu.idPerfilMenu = @idPerfilMenu");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPerfilMenu", _input.idPerfilMenu));
                    if (!sqlOrderBy.Contains("perfilMenu.idPerfilMenu"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "perfilMenu.idPerfilMenu");
                    else { }
                }
                else { }

                if (_input.perfil != null && _input.perfil.idPerfil > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "perfilMenu.idPerfil = @idPerfil");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPerfil", _input.perfil.idPerfil));
                    if (!sqlOrderBy.Contains("perfilMenu.idPerfil"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "perfilMenu.idPerfil");
                    else { }
                }
                else { }

                if (_input.menuPai != null && _input.menuPai.idMenu > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "menu.idMenuPai = @idMenuPai");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idMenuPai", _input.menuPai.idMenu));
                    if (!sqlOrderBy.Contains("menu.idMenuPai"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "menu.idMenuPai");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                        "*\n" +
                    "from \n" + 
                    (
                        "perfilMenu perfilMenu\n" +
                        "	inner join menu menu\n" +
                        "		on	menu.idMenu = perfilMenu.idMenu\n" +
                        "	inner join perfil perfil\n" +
                        "		on	perfil.idPerfil = perfilMenu.idPerfil\n"
                ) +
                    (sqlWhere.Length > 0 ? "where " + sqlWhere : "") + "\n" +
                    (sqlOrderBy.Length > 0 ? " order by " + sqlOrderBy : "") +
                    (((numRows > 0) && (offSet >= 0)) ? " offset " + offSet + " rows fetch next " + numRows + " rows only" : "")
                );

                table = null;
            }
            else { }

            return result;
        }


        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.PerfilMenu input = (Data.PerfilMenu)parametros["Key"];
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
                    typeof(Tables.PerfilMenu),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.PerfilMenu _data in
                    (System.Collections.Generic.List<Tables.PerfilMenu>)this.m_EntityManager.list
                    (
                        typeof(Tables.PerfilMenu),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    //if (mode == "Roll")
                    //{
                    //_base = new Data.ResultadoConsulta();

                    //if (!_data.codConsCampo.codUsuario.isNull)
                    //{
                    //    ((Data.ResultadoConsulta)_base).codigo = (int)_data.codConsCampo.codUsuario.value;
                    //    ((Data.ResultadoConsulta)_base).descricao =
                    //    (
                    //        _data.descricao.value + "(" + _data.codConsCampo.idCadastro.nome.value + ")"
                    //    );
                    //}
                    //else
                    //{
                    //    ((Data.ResultadoConsulta)_base).codigo = (int)_data.codCarteira.value;
                    //    ((Data.ResultadoConsulta)_base).descricao = _data.descricao.value;
                    //}
                    //}
                    //else
                    _base = (Data.Base)this.preencher(new Data.PerfilMenu(), _data, level);

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
