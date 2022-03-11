using System;

namespace WS.CRUD
{
    public class TituloSocioDependente : WS.CRUD.Base
    {
        public TituloSocioDependente(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.TituloSocioDependente input = (Data.TituloSocioDependente)parametros["Key"];
            Tables.TituloSocioDependente bd = new Tables.TituloSocioDependente();

            if (input.tituloSocio != null && input.tituloSocio.idTituloSocio > 0)
                bd.tituloSocio.idTituloSocio.value = input.tituloSocio.idTituloSocio;
            else { }


            if (input.tipoRelacionamento != null && input.tipoRelacionamento.idTipoRelacionamento > 0)
                bd.tipoRelacionamento.idTipoRelacionamento.value = input.tipoRelacionamento.idTipoRelacionamento;
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.TituloSocioDependente)parametros["Key"]).idTituloSocioDependente = (int)bd.idTituloSocioDependente.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.TituloSocioDependente input = (Data.TituloSocioDependente)parametros["Key"];
            Tables.TituloSocioDependente bd = (Tables.TituloSocioDependente)this.m_EntityManager.find
            (
                typeof(Tables.TituloSocioDependente),
                new Object[]
                {
                    input.idTituloSocioDependente
                }
            );

            if (input.tituloSocio != null && input.tituloSocio.idTituloSocio > 0)
                bd.tituloSocio.idTituloSocio.value = input.tituloSocio.idTituloSocio;
            else { }

            if (input.tipoRelacionamento != null && input.tipoRelacionamento.idTipoRelacionamento > 0)
                bd.tipoRelacionamento.idTipoRelacionamento.value = input.tipoRelacionamento.idTipoRelacionamento;
            else { }

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.TituloSocioDependente bd = new Tables.TituloSocioDependente();

            bd.idTituloSocioDependente.value = ((Data.TituloSocioDependente)parametros["Key"]).idTituloSocioDependente;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.TituloSocioDependente)bd).idTituloSocioDependente.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.TituloSocioDependente)input).operacao = ENum.eOperacao.NONE;
                    ((Data.TituloSocioDependente)input).idTituloSocioDependente = ((Tables.TituloSocioDependente)bd).idTituloSocioDependente.value;
                    ((Data.TituloSocioDependente)input).tituloSocio = (Data.TituloSocio)(new WS.CRUD.TituloSocio(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TituloSocio(),
                        ((Tables.TituloSocioDependente)bd).tituloSocio,
                        level + 1
                    );

                    ((Data.TituloSocioDependente)input).tipoRelacionamento = (Data.TipoRelacionamento)(new WS.CRUD.TipoRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoRelacionamento(),
                        ((Tables.TituloSocioDependente)bd).tipoRelacionamento,
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
            Data.TituloSocioDependente result = (Data.TituloSocioDependente)parametros["Key"];

            try
            {
                result = (Data.TituloSocioDependente)this.preencher
                (
                    new Data.TituloSocioDependente(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.TituloSocioDependente),
                        new Object[]
                        {
                            result.idTituloSocioDependente
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

            Data.TituloSocioDependente _input = (Data.TituloSocioDependente)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idTituloSocioDependente > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tituloSocioDependente.idTituloSocioDependente = @idTituloSocioDependente");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTituloSocioDependente", _input.idTituloSocioDependente));
                    if (!sqlOrderBy.Contains("tituloSocioDependente.idTituloSocioDependente"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tituloSocioDependente.idTituloSocioDependente");
                    else { }
                }
                else { }

                if (_input.tituloSocio != null)
                {
                    if (_input.tituloSocio.idTituloSocio > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tituloSocioDependente.idTituloSocio = @idTituloSocio");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTituloSocio", _input.tituloSocio.idTituloSocio));
                        if (!sqlOrderBy.Contains("tituloSocioDependente.idTituloSocio"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tituloSocioDependente.idTituloSocio");
                        else { }
                    }
                    else { }



                    if (_input.tituloSocio.titularEmpresaRelacionamento != null)
                    {
                        if (_input.tituloSocio.titularEmpresaRelacionamento.tipoRelacionamentoEmpresa != null)
                        {
                            if (_input.tituloSocio.titularEmpresaRelacionamento.tipoRelacionamentoEmpresa.tipo.Length > 0)
                            {
                                sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tipoRelacionamentoEmpresa.tipo = @tipo");
                                fieldKeys.Add(new EJB.TableBase.TFieldString("tipo", _input.tituloSocio.titularEmpresaRelacionamento.tipoRelacionamentoEmpresa.tipo));
                                if (!sqlOrderBy.Contains("tipoRelacionamentoEmpresa.tipo"))
                                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoRelacionamentoEmpresa.tipo");
                                else { }
                            }
                            else { }
                        }
                        else { }

                        if (_input.tituloSocio.titularEmpresaRelacionamento.pessoaRelacionadaEmpresa != null)
                        {
                            if (_input.tituloSocio.titularEmpresaRelacionamento.pessoaRelacionadaEmpresa.idEmpresaRelacionamento > 0)
                            {
                                sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "empresaRelacionamento.idPessoaRelacionadaEmpresa = @idEmpresaRelacionamentoRelacionada");
                                fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresaRelacionamentoRelacionada", _input.tituloSocio.titularEmpresaRelacionamento.pessoaRelacionadaEmpresa.idEmpresaRelacionamento));
                                if (!sqlOrderBy.Contains("pessoaRelacionadaEmpresa.idEmpresaRelacionamento"))
                                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoaRelacionadaEmpresa.idEmpresaRelacionamento");
                                else { }
                            }
                            else { }
                        }
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.tipoRelacionamento != null && _input.tipoRelacionamento.idTipoRelacionamento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tituloSocioDependente.idTipoRelacionamento = @idTipoRelacionamento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTipoRelacionamento", _input.tipoRelacionamento.idTipoRelacionamento));
                    if (!sqlOrderBy.Contains("tituloSocioDependente.idTipoRelacionamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tituloSocioDependente.idTipoRelacionamento");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (numRows > 0 ? " top " + numRows.ToString() + " " : "") +
                    "   * " +
                    "from " +
                    @"  tituloSocioDependente
		                inner join tituloSocio
			                on	tituloSocio.idTituloSocio = tituloSocioDependente.idTituloSocio
		                inner join empresaRelacionamento
			                on	empresaRelacionamento.idEmpresaRelacionamento = tituloSocio.idEmpresaRelacionamentoTitular
		                inner join tipoRelacionamento
			                on	tipoRelacionamento.idTipoRelacionamento = tituloSocioDependente.idTipoRelacionamento
                        inner join tipoRelacionamentoEmpresa
                            on tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa = empresaRelacionamento.idTipoRelacionamentoEmpresa
                        left join empresaRelacionamento pessoaRelacionadaEmpresa
                            on pessoaRelacionadaEmpresa.idEmpresaRelacionamento = empresaRelacionamento.idPessoaRelacionadaEmpresa " +
                    (sqlWhere.Length > 0 ? " where " + sqlWhere : "") +
                    (sqlOrderBy.Length > 0 ? " order by " + sqlOrderBy : "")
                );

                table = null;
            }
            else { }

            return result;
        }


        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.TituloSocioDependente input = (Data.TituloSocioDependente)parametros["Key"];
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
                    typeof(Tables.TituloSocioDependente),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                parametros.Clear();
                parametros = null;

                foreach
                (
                    Tables.TituloSocioDependente _data in
                    (System.Collections.Generic.List<Tables.TituloSocioDependente>)this.m_EntityManager.list
                    (
                        typeof(Tables.TituloSocioDependente),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.TituloSocioDependente(), _data, level);

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
