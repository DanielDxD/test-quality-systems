using System;

namespace WS.CRUD
{
    public class Evento : WS.CRUD.Base
    {
        public Evento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Evento input = (Data.Evento)parametros["Key"];
            Tables.Evento bd = new Tables.Evento();

            bd.idEvento.isNull = true;
            bd.descricao.value = input.descricao;
            bd.periodoEventoInicio.value = input.periodoEventoInicio;
            bd.periodoEventoFim.value = input.periodoEventoFim;
            bd.periodoInscricaoInicio.value = input.periodoInscricaoInicio;
            bd.periodoInscricaoFim.value = input.periodoInscricaoFim;
            if (input.idNaturezaOperacao > 0)
                bd.idNaturezaOperacao.value = input.idNaturezaOperacao;
            else
                bd.idNaturezaOperacao.isNull = true;

            if (input.empresaRelacionamentoHotel != null && input.empresaRelacionamentoHotel.idEmpresaRelacionamento > 0)
                bd.empresaRelacionamentoHotel.idEmpresaRelacionamento.value = input.empresaRelacionamentoHotel.idEmpresaRelacionamento;
            else
                bd.empresaRelacionamentoHotel.idEmpresaRelacionamento.isNull = true;

            bd.valorExtra.value = input.valorExtra;
            bd.quantidadePernoite.value = input.quantidadePernoite;

            this.m_EntityManager.persist(bd);

            ((Data.Evento)parametros["Key"]).idEvento = (int)bd.idEvento.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Evento input = (Data.Evento)parametros["Key"];
            Tables.Evento bd = (Tables.Evento)this.m_EntityManager.find
            (
                typeof(Tables.Evento),
                new Object[]
                {
                    input.idEvento
                }
            );

            bd.descricao.value = input.descricao;
            bd.periodoEventoInicio.value = input.periodoEventoInicio;
            bd.periodoEventoFim.value = input.periodoEventoFim;
            bd.periodoInscricaoInicio.value = input.periodoInscricaoInicio;
            bd.periodoInscricaoFim.value = input.periodoInscricaoFim;
            if (input.idNaturezaOperacao > 0)
                bd.idNaturezaOperacao.value = input.idNaturezaOperacao;
            else
                bd.idNaturezaOperacao.isNull = true;

            if (input.empresaRelacionamentoHotel != null && input.empresaRelacionamentoHotel.idEmpresaRelacionamento > 0)
                bd.empresaRelacionamentoHotel.idEmpresaRelacionamento.value = input.empresaRelacionamentoHotel.idEmpresaRelacionamento;
            else
                bd.empresaRelacionamentoHotel.idEmpresaRelacionamento.isNull = true;
            bd.valorExtra.value = input.valorExtra;
            bd.quantidadePernoite.value = input.quantidadePernoite;

            this.m_EntityManager.merge(bd);


            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Evento bd = new Tables.Evento();

            bd.idEvento.value = ((Data.Evento)parametros["Key"]).idEvento;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Evento)bd).idEvento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Evento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Evento)input).idEvento = ((Tables.Evento)bd).idEvento.value;
                    ((Data.Evento)input).descricao = ((Tables.Evento)bd).descricao.value;
                    ((Data.Evento)input).periodoEventoInicio = ((Tables.Evento)bd).periodoEventoInicio.value;
                    ((Data.Evento)input).periodoEventoFim = ((Tables.Evento)bd).periodoEventoFim.value;
                    ((Data.Evento)input).periodoInscricaoInicio = ((Tables.Evento)bd).periodoInscricaoInicio.value;
                    ((Data.Evento)input).periodoInscricaoFim = ((Tables.Evento)bd).periodoInscricaoFim.value;
                    ((Data.Evento)input).valorExtra = ((Tables.Evento)bd).valorExtra.value;
                    ((Data.Evento)input).idNaturezaOperacao = ((Tables.Evento)bd).idNaturezaOperacao.value;
                    ((Data.Evento)input).quantidadePernoite = ((Tables.Evento)bd).quantidadePernoite.value;
                    ((Data.Evento)input).empresaRelacionamentoHotel = (Data.EmpresaRelacionamento)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.EmpresaRelacionamento(),
                        ((Tables.Evento)bd).empresaRelacionamentoHotel,
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
            Data.Evento result = (Data.Evento)parametros["Key"];

            try
            {
                result = (Data.Evento)this.preencher
                (
                    new Data.Evento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Evento),
                        new Object[]
                        {
                            result.idEvento
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

            Data.Evento _input = (Data.Evento)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;
            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idEvento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "evento.idEvento = @idEvento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEvento", _input.idEvento));
                    if (!sqlOrderBy.Contains("evento.idEvento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "evento.idEvento");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "evento.descricao COLLATE Latin1_General_CI_AI like @descricao COLLATE Latin1_General_CI_AI");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", '%' + _input.descricao + '%'));
                    if (!sqlOrderBy.Contains("evento.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "evento.descricao");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "evento.* ") +
                    "from " +
                    (
                        "   evento evento \n"
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
            Data.Evento input = (Data.Evento)parametros["Key"];
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
                    typeof(Tables.Evento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Evento _data in
                    (System.Collections.Generic.List<Tables.Evento>)this.m_EntityManager.list
                    (
                        typeof(Tables.Evento),
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
                    _base = (Data.Base)this.preencher(new Data.Evento(), _data, level);

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
