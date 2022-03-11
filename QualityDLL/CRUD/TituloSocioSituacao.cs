using System;

namespace WS.CRUD
{
    public class TituloSocioSituacao : WS.CRUD.Base
    {
        public TituloSocioSituacao(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.TituloSocioSituacao input = (Data.TituloSocioSituacao)parametros["Key"];
            Tables.TituloSocioSituacao bd = new Tables.TituloSocioSituacao();

            bd.idTituloSocioSituacao.isNull = true;
            if (input.tituloSocio != null && input.tituloSocio.idTituloSocio > 0)
                bd.tituloSocio.idTituloSocio.value = input.tituloSocio.idTituloSocio;
            else { }

            if (input.dataInicio.Ticks > 0)
                bd.dataInicio.value = input.dataInicio;
            else
            {
                bd.dataInicio.value = DateTime.Now;
            }

            if (input.dataFim.Ticks > 0)
                bd.dataFim.value = input.dataFim;
            else { }

            if (input.situacao != null && input.situacao.idSituacao > 0)
                bd.situacao.idSituacao.value = input.situacao.idSituacao;
            else { }

            bd.observacao.value = input.observacao;

            this.m_EntityManager.persist(bd);

            ((Data.TituloSocioSituacao)parametros["Key"]).idTituloSocioSituacao = (int)bd.idTituloSocioSituacao.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.TituloSocioSituacao input = (Data.TituloSocioSituacao)parametros["Key"];
            Tables.TituloSocioSituacao bd = (Tables.TituloSocioSituacao)this.m_EntityManager.find
            (
                typeof(Tables.TituloSocioSituacao),
                new Object[]
                {
                    input.idTituloSocioSituacao
                }
            );

            if (input.tituloSocio != null && input.tituloSocio.idTituloSocio > 0)
                bd.tituloSocio.idTituloSocio.value = input.tituloSocio.idTituloSocio;
            else { }

            if (input.dataInicio.Ticks > 0)
                bd.dataInicio.value = input.dataInicio;
            else
            {
                bd.dataInicio.value = DateTime.Now;
            }

            if (input.dataFim.Ticks > 0)
                bd.dataFim.value = input.dataFim;
            else { }

            if (input.situacao != null && input.situacao.idSituacao > 0)
                bd.situacao.idSituacao.value = input.situacao.idSituacao;
            else { }

            bd.observacao.value = input.observacao;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.TituloSocioSituacao bd = new Tables.TituloSocioSituacao();

            bd.idTituloSocioSituacao.value = ((Data.TituloSocioSituacao)parametros["Key"]).idTituloSocioSituacao;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.TituloSocioSituacao)bd).idTituloSocioSituacao.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.TituloSocioSituacao)input).operacao = ENum.eOperacao.NONE;

                    ((Data.TituloSocioSituacao)input).idTituloSocioSituacao = ((Tables.TituloSocioSituacao)bd).idTituloSocioSituacao.value;
                    ((Data.TituloSocioSituacao)input).tituloSocio = (Data.TituloSocio)(new WS.CRUD.TituloSocio(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TituloSocio(),
                        ((Tables.TituloSocioSituacao)bd).tituloSocio,
                        level + 1
                    );

                    ((Data.TituloSocioSituacao)input).dataInicio = ((Tables.TituloSocioSituacao)bd).dataInicio.value;
                    ((Data.TituloSocioSituacao)input).dataFim = ((Tables.TituloSocioSituacao)bd).dataFim.value;
                    ((Data.TituloSocioSituacao)input).observacao = ((Tables.TituloSocioSituacao)bd).observacao.value;
                    ((Data.TituloSocioSituacao)input).situacao = (Data.Situacao)(new WS.CRUD.Situacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Situacao(),
                        ((Tables.TituloSocioSituacao)bd).situacao,
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
            Data.TituloSocioSituacao result = (Data.TituloSocioSituacao)parametros["Key"];

            try
            {
                result = (Data.TituloSocioSituacao)this.preencher
                (
                    new Data.TituloSocioSituacao(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.TituloSocioSituacao),
                        new Object[]
                        {
                            result.idTituloSocioSituacao
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
            Data.TituloSocioSituacao input = (Data.TituloSocioSituacao)parametros["Key"];
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
                    typeof(Tables.TituloSocioSituacao),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.TituloSocioSituacao _data in
                    (System.Collections.Generic.List<Tables.TituloSocioSituacao>)this.m_EntityManager.list
                    (
                        typeof(Tables.TituloSocioSituacao),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.TituloSocioSituacao();

                        ((Data.TituloSocioSituacao)_base).idTituloSocioSituacao = _data.idTituloSocioSituacao.value;
                        ((Data.TituloSocioSituacao)_base).dataFim = _data.dataFim.value;
                        ((Data.TituloSocioSituacao)_base).dataInicio = _data.dataInicio.value;
                        ((Data.TituloSocioSituacao)_base).observacao = _data.observacao.value;
                        ((Data.TituloSocioSituacao)_base).situacao = new Data.Situacao
                        {
                            idSituacao = _data.situacao.idSituacao.value,
                            descricao = _data.situacao.descricao.value
                        };
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.TituloSocioSituacao(), _data, level);

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

            Data.TituloSocioSituacao _input = (Data.TituloSocioSituacao)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idTituloSocioSituacao > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tituloSocioSituacao.idTituloSocioSituacao = @idTituloSocioSituacao");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTituloSocioSituacao", _input.idTituloSocioSituacao));
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tituloSocioSituacao.idTituloSocioSituacao");
                }
                else { }

                if (_input.tituloSocio != null)
                {
                    if (_input.tituloSocio.idTituloSocio > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tituloSocioSituacao.idTituloSocio = @idTituloSocio");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTituloSocio", _input.tituloSocio.idTituloSocio));
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tituloSocioSituacao.idTituloSocio");
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "tituloSocioSituacao.* ") +
                    "from " +
                    (
                        "   tituloSocioSituacao tituloSocioSituacao " +
                        "       inner join situacao situacao " +
                        "           on situacao.idSituacao = tituloSocioSituacao.idSituacao"
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
