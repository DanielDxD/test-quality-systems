using System;

namespace WS.CRUD
{
    public class Titulo : WS.CRUD.Base
    {
        public Titulo(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Titulo input = (Data.Titulo)parametros["Key"];
            Tables.Titulo bd = new Tables.Titulo();
            if (input.idTitulo == 0)
                bd.idTitulo.isNull = true;
            else
                bd.idTitulo.value = input.idTitulo;

            bd.idEmpresa.value = input.idEmpresa;
            bd.numero.value = input.numero;
            bd.serie.value = input.serie;
            if (input.situacao != null)
                bd.situacao.idSituacao.value = input.situacao.idSituacao;
            bd.dataCriacao.value = input.dataCriacao;

            this.m_EntityManager.persist(bd);

            ((Data.Titulo)parametros["Key"]).idTitulo = (int)bd.idTitulo.value;

            //Processa TituloConsignacao
            if (input.tituloConsignacaos != null)
            {
                WS.CRUD.TituloConsignacao tituloConsignacaoCRUD = new WS.CRUD.TituloConsignacao(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.tituloConsignacaos.Length; i++)
                {
                    input.tituloConsignacaos[i].titulo = new Data.Titulo();
                    input.tituloConsignacaos[i].titulo.idTitulo = bd.idTitulo.value;
                    _parameters.Add("Key", input.tituloConsignacaos[i]);
                    tituloConsignacaoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                tituloConsignacaoCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa TituloSocio
            if (input.tituloSocios != null)
            {
                WS.CRUD.TituloSocio tituloSocioCRUD = new WS.CRUD.TituloSocio(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.tituloSocios.Length; i++)
                {
                    input.tituloSocios[i].titulo = new Data.Titulo();
                    input.tituloSocios[i].titulo.idTitulo = bd.idTitulo.value;
                    _parameters.Add("Key", input.tituloSocios[i]);
                    tituloSocioCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                tituloSocioCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Titulo input = (Data.Titulo)parametros["Key"];
            Tables.Titulo bd = (Tables.Titulo)this.m_EntityManager.find
            (
                typeof(Tables.Titulo),
                new Object[]
                {
                    input.idTitulo
                }
            );

            bd.idEmpresa.value = input.idEmpresa;
            bd.numero.value = input.numero;
            bd.serie.value = input.serie;
            if (input.situacao != null)
                bd.situacao.idSituacao.value = input.situacao.idSituacao;
            bd.dataCriacao.value = input.dataCriacao;

            this.m_EntityManager.merge(bd);

            //Processa TituloConsignacao
            if (input.tituloConsignacaos != null)
            {
                WS.CRUD.TituloConsignacao tituloConsignacaoCRUD = new WS.CRUD.TituloConsignacao(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.tituloConsignacaos.Length; i++)
                {
                    input.tituloConsignacaos[i].titulo = new Data.Titulo();
                    input.tituloConsignacaos[i].titulo.idTitulo = bd.idTitulo.value;
                    _parameters.Add("Key", input.tituloConsignacaos[i]);
                    if (input.tituloConsignacaos[i].operacao == ENum.eOperacao.NONE)
                        input.tituloConsignacaos[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    tituloConsignacaoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                tituloConsignacaoCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa TituloSocio
            if (input.tituloSocios != null)
            {
                WS.CRUD.TituloSocio tituloSocioCRUD = new WS.CRUD.TituloSocio(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.tituloSocios.Length; i++)
                {
                    input.tituloSocios[i].titulo = new Data.Titulo();
                    input.tituloSocios[i].titulo.idTitulo = bd.idTitulo.value;
                    _parameters.Add("Key", input.tituloSocios[i]);
                    if (input.tituloSocios[i].operacao == ENum.eOperacao.NONE)
                        input.tituloSocios[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    tituloSocioCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                tituloSocioCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Titulo bd = new Tables.Titulo();

            bd.idTitulo.value = ((Data.Titulo)parametros["Key"]).idTitulo;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Titulo)bd).idTitulo.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Titulo)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Titulo)input).idTitulo = ((Tables.Titulo)bd).idTitulo.value;
                    ((Data.Titulo)input).numero = ((Tables.Titulo)bd).numero.value;
                    ((Data.Titulo)input).serie = ((Tables.Titulo)bd).serie.value;
                    ((Data.Titulo)input).dataCriacao = ((Tables.Titulo)bd).dataCriacao.value;
                    ((Data.Titulo)input).idEmpresa = ((Tables.Titulo)bd).idEmpresa.value;

                    ((Data.Titulo)input).situacao = (Data.Situacao)(new WS.CRUD.Situacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Situacao(),
                        ((Tables.Titulo)bd).situacao,
                        level + 1
                    );
                }
                else { }

                if (level < 1)
                {
                    //Preencher TituloConsignacaos
                    if (((Tables.Titulo)bd).tituloConsignacaos != null)
                    {
                        System.Collections.Generic.List<Data.TituloConsignacao> _list = new System.Collections.Generic.List<Data.TituloConsignacao>();

                        foreach (Tables.TituloConsignacao _item in ((Tables.Titulo)bd).tituloConsignacaos)
                        {
                            _list.Add
                            (
                                (Data.TituloConsignacao)
                                (new WS.CRUD.TituloConsignacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.TituloConsignacao(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.Titulo)input).tituloConsignacaos = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.Titulo)input).tituloConsignacaos != null)
                        {
                            System.Collections.Generic.List<Data.TituloConsignacao> _list = new System.Collections.Generic.List<Data.TituloConsignacao>();

                            foreach (Data.TituloConsignacao _item in ((Data.Titulo)input).tituloConsignacaos)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.Titulo)input).tituloConsignacaos = _list.ToArray();
                            else
                                ((Data.Titulo)input).tituloConsignacaos = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }
                }
                else { }
                if (level < 1)
                {
                    //Preencher TituloSocios
                    if (((Tables.Titulo)bd).tituloSocios != null)
                    {
                        System.Collections.Generic.List<Data.TituloSocio> _list = new System.Collections.Generic.List<Data.TituloSocio>();

                        foreach (Tables.TituloSocio _item in ((Tables.Titulo)bd).tituloSocios)
                        {
                            _list.Add
                            (
                                (Data.TituloSocio)
                                (new WS.CRUD.TituloSocio(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.TituloSocio(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.Titulo)input).tituloSocios = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.Titulo)input).tituloSocios != null)
                        {
                            System.Collections.Generic.List<Data.TituloSocio> _list = new System.Collections.Generic.List<Data.TituloSocio>();

                            foreach (Data.TituloSocio _item in ((Data.Titulo)input).tituloSocios)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.Titulo)input).tituloSocios = _list.ToArray();
                            else
                                ((Data.Titulo)input).tituloSocios = null;

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
            Data.Titulo result = (Data.Titulo)parametros["Key"];

            try
            {
                result = (Data.Titulo)this.preencher
                (
                    new Data.Titulo(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Titulo),
                        new Object[]
                        {
                            result.idTitulo
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

            Data.Titulo _input = (Data.Titulo)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                //sqlWhere = (sqlWhere.Contains("'") ? sqlWhere.Replace("'", "''") : sqlWhere);

                if (_input.idTitulo > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Titulo.idTitulo = @idTitulo");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTitulo", _input.idTitulo));
                    if (!sqlOrderBy.Contains("Titulo.idTitulo"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Titulo.idTitulo");
                    else { }
                }
                else { }

                if (_input.idEmpresa > 0 || _input.idEmpresa == -1)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Titulo.idEmpresa = @idEmpresa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.idEmpresa));
                    if (!sqlOrderBy.Contains("Titulo.idEmpresa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Titulo.idEmpresa");
                    else { }
                }
                else { }

                if (_input.numero > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Titulo.numero = @numero");
                    fieldKeys.Add(new EJB.TableBase.TFieldBigInteger("numero", _input.numero));
                    if (!sqlOrderBy.Contains("Titulo.numero"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Titulo.numero");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "Titulo.* ") +
                    "from " +
                    (
                        "   Titulo Titulo "
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
            Data.Titulo input = (Data.Titulo)parametros["Key"];
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
                    typeof(Tables.Titulo),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Titulo _data in
                    (System.Collections.Generic.List<Tables.Titulo>)this.m_EntityManager.list
                    (
                        typeof(Tables.Titulo),
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
                    _base = (Data.Base)this.preencher(new Data.Titulo(), _data, level);

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
