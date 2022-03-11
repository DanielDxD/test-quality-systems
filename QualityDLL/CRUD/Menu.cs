using System;

namespace WS.CRUD
{
    public class Menu : WS.CRUD.Base
    {
        public Menu(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Menu input = (Data.Menu)parametros["Key"];
            Tables.Menu bd = new Tables.Menu();

            bd.idMenu.isNull = true;
            bd.descricao.value = input.descricao;
            bd.opcao.value = Utils.Utils.RemoverAcentos(input.opcao.Replace(' ', '-').ToLower());
            if ((input.menuPai != null) && (input.menuPai.idMenu > 0))
                bd.idMenuPai.value = input.menuPai.idMenu;
            else { }
            if ((input.pagina != null) && (input.pagina.idPagina > 0))
                bd.pagina.idPagina.value = input.pagina.idPagina;
            else { }
            bd.ordem.value = input.ordem;
            bd.arquivoImagem.value = input.arquivoImagem;

            this.m_EntityManager.persist(bd);

            ((Data.Menu)parametros["Key"]).idMenu = (int)bd.idMenu.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Menu input = (Data.Menu)parametros["Key"];
            Tables.Menu bd = (Tables.Menu)this.m_EntityManager.find
            (
                typeof(Tables.Menu),
                new Object[]
                {
                    input.idMenu
                }
            );

            bd.descricao.value = input.descricao;
            bd.opcao.value = Utils.Utils.RemoverAcentos(input.opcao.Replace(' ', '-').ToLower());
            if ((input.menuPai != null) && (input.menuPai.idMenu > 0))
                bd.idMenuPai.value = input.menuPai.idMenu;
            else
                bd.idMenuPai.isNull = true;
            if ((input.pagina != null) && (input.pagina.idPagina > 0))
                bd.pagina.idPagina.value = input.pagina.idPagina;
            else
                bd.pagina.idPagina.isNull = true;
            bd.ordem.value = input.ordem;
            bd.arquivoImagem.value = input.arquivoImagem;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Menu bd = new Tables.Menu();

            bd.idMenu.value = ((Data.Menu)parametros["Key"]).idMenu;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Menu)bd).idMenu.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Menu)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Menu)input).idMenu = ((Tables.Menu)bd).idMenu.value;
                    ((Data.Menu)input).descricao = ((Tables.Menu)bd).descricao.value;
                    ((Data.Menu)input).opcao = ((Tables.Menu)bd).opcao.value;
                    if (!((Tables.Menu)bd).idMenuPai.isNull)
                    {
                        ((Data.Menu)input).menuPai = new Data.Menu();
                        ((Data.Menu)input).menuPai.idMenu = ((Tables.Menu)bd).idMenuPai.value;
                    }
                    else { }
                    ((Data.Menu)input).pagina = (Data.Pagina)(new WS.CRUD.Pagina(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Pagina(),
                        ((Tables.Menu)bd).pagina,
                        level + 1
                    );
                    ((Data.Menu)input).ordem = ((Tables.Menu)bd).ordem.value;
                    ((Data.Menu)input).arquivoImagem = ((Tables.Menu)bd).arquivoImagem.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.Menu result = (Data.Menu)parametros["Key"];

            try
            {
                result = (Data.Menu)this.preencher
                (
                    new Data.Menu(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Menu),
                        new Object[]
                        {
                            result.idMenu
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

            Data.Menu _input = (Data.Menu)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idMenu > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "menu.idMenu = @idMenu");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idMenu", _input.idMenu));
                    if (!sqlOrderBy.Contains("menu.idMenu"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "menu.idMenu");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   menu.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("menu.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "menu.descricao");
                    else { }
                }


                if (_input.menuPai != null && _input.menuPai.idMenu > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "menu.idMenuPai = @idMenuPai");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idMenuPai", _input.menuPai.idMenu));
                    if (!sqlOrderBy.Contains("menu.idMenuPai"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "menu.idMenuPai");
                    else { }
                }
                else { }

                if (_input.pagina != null)
                {
                    if (_input.pagina.idPagina > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "menu.idPagina = @idPagina");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPagina", _input.pagina.idPagina));
                        if (!sqlOrderBy.Contains("menu.idPagina"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "menu.idPagina");
                        else { }
                    }
                    else { }

                    if (!String.IsNullOrEmpty(_input.pagina.pagina))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pagina.pagina LIKE @pagina");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("pagina", '%' + _input.pagina.pagina + '%'));
                        if (!sqlOrderBy.Contains("pagina.pagina"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pagina.pagina");
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   menu.* " +
                    "from " +
                    "   menu " +
                    "left join pagina " +
                    "      on pagina.idPagina = menu.idPagina " +
                    (sqlWhere.Length > 0 ? " where " + sqlWhere : "") +
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
            Data.Menu input = (Data.Menu)parametros["Key"];
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
                    typeof(Tables.Menu),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Menu _data in
                    (System.Collections.Generic.List<Tables.Menu>)this.m_EntityManager.list
                    (
                        typeof(Tables.Menu),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.Menu(), _data, level);

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
