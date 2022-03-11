using System;

namespace WS.CRUD
{
    public class UsuarioLogado : WS.CRUD.Base
    {
        public UsuarioLogado(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.UsuarioLogado input = (Data.UsuarioLogado)parametros["Key"];
            Tables.UsuarioLogado bd = new Tables.UsuarioLogado();

            bd.usuario.idUsuario.value = input.usuario.idUsuario;
            bd.modulo.value = input.modulo;
            bd.dataLogin.value = input.dataLogin;
            bd.sessionId.value = input.sessionId;
            this.m_EntityManager.persist(bd);

            String
                 signature = new Utils.Base64().encode(new Utils.MD5().digest(input.sessionId));

            this.m_EntityManager.execute
            (
                "update usuarioLogado set token = '" + signature + "' where idUsuario = @idUsuario AND modulo = @modulo",
                new EJB.TableBase.TField[]
                {
                    new EJB.TableBase.TFieldInteger
                    (
                        "idUsuario",
                        input.usuario.idUsuario
                    ),
                    new EJB.TableBase.TFieldString
                    (
                        "modulo",
                        input.modulo
                    )
                }
            );

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.UsuarioLogado input = (Data.UsuarioLogado)parametros["Key"];
            Tables.UsuarioLogado bd = (Tables.UsuarioLogado)this.m_EntityManager.find
            (
                typeof(Tables.UsuarioLogado),
                new Object[]
                {
                    input.usuario.idUsuario,
                    input.modulo
                }
            );

            bd.usuario.idUsuario.value = input.usuario.idUsuario;
            bd.sessionId.value = input.sessionId;
            bd.modulo.value = input.modulo;
            bd.dataLogin.value = input.dataLogin;

            this.m_EntityManager.merge(bd);
            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.UsuarioLogado bd = new Tables.UsuarioLogado();

            bd.usuario.idUsuario.value = ((Data.UsuarioLogado)parametros["Key"]).usuario.idUsuario;
            bd.modulo.value = ((Data.UsuarioLogado)parametros["Key"]).modulo;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.UsuarioLogado)bd).usuario.idUsuario.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.UsuarioLogado)input).operacao = ENum.eOperacao.NONE;

                    ((Data.UsuarioLogado)input).dataLogin = ((Tables.UsuarioLogado)bd).dataLogin.value;
                    ((Data.UsuarioLogado)input).token = ((Tables.UsuarioLogado)bd).token.value;
                    ((Data.UsuarioLogado)input).modulo = ((Tables.UsuarioLogado)bd).modulo.value;

                    ((Data.UsuarioLogado)input).usuario = (Data.Usuario)(new WS.CRUD.Usuario(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Usuario(),
                        ((Tables.UsuarioLogado)bd).usuario,
                        level + 1
                    );
                    ((Data.UsuarioLogado)input).sessionId = ((Tables.UsuarioLogado)bd).sessionId.value;
                }
                else { }

            }
            else { }

            return input;
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

            Data.UsuarioLogado _input = (Data.UsuarioLogado)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.usuario.idUsuario > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "usuarioLogado.idUsuario = @idUsuario");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idUsuario", _input.usuario.idUsuario));
                    if (!sqlOrderBy.Contains("usuarioLogado.idUsuario"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "usuarioLogado.idUsuario");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.modulo))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "usuarioLogado.modulo = @modulo");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("modulo", _input.modulo));
                    if (!sqlOrderBy.Contains("usuarioLogado.modulo"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "usuarioLogado.modulo");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.sessionId))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "usuarioLogado.sessionId = @sessionId");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("sessionId", _input.sessionId));
                    if (!sqlOrderBy.Contains("usuarioLogado.sessionId"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "usuarioLogado.sessionId");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   usuarioLogado.* " +
                    "from " +
                    (
                        "   usuarioLogado usuarioLogado " +
                        "       inner join usuario" +
                        "           on	usuarioLogado.idUsuario = usuario.idUsuario "
                    ) +
                    (sqlWhere.Length > 0 ? " where " + sqlWhere : "") +
                    (sqlOrderBy.Length > 0 ? " order by " + sqlOrderBy : "") +
                    (((numRows > 0) && (offSet >= 0)) ? " offset " + offSet + " rows fetch next " + numRows + " rows only" : "")
                );

                table = null;
            }
            else { }

            return result;
        }


        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.UsuarioLogado result = (Data.UsuarioLogado)parametros["Key"];

            try
            {
                result = (Data.UsuarioLogado)this.preencher
                (
                    new Data.UsuarioLogado(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.UsuarioLogado),
                        new Object[]
                        {
                            result.usuario.idUsuario
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
            Data.UsuarioLogado input = (Data.UsuarioLogado)parametros["Key"];
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
                    typeof(Tables.UsuarioLogado),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.UsuarioLogado _data in
                    (System.Collections.Generic.List<Tables.UsuarioLogado>)this.m_EntityManager.list
                    (
                        typeof(Tables.UsuarioLogado),
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
                    _base = (Data.Base)this.preencher(new Data.UsuarioLogado(), _data, level);

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
