using System;

namespace WS.CRUD
{
    public class EventoInscricaoParticipante : WS.CRUD.Base
    {
        public EventoInscricaoParticipante(long? idEmpresa, EJB.EntityManager.EntityManager entityManager) : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.EventoInscricaoParticipante input = (Data.EventoInscricaoParticipante)parametros["Key"];
            Tables.EventoInscricaoParticipante bd = new Tables.EventoInscricaoParticipante();

            bd.idEventoInscricaoParticipante.isNull = true;
            bd.dataInscricao.value = input.dataInscricao;
            bd.confirmado.value = input.confirmado;
            bd.dataCancelamento.value = input.dataCancelamento;
            bd.dataChegada.value = input.dataChegada;
            bd.dataInscricao.value = input.dataInscricao;
            bd.dataSaida.value = input.dataSaida;
            if (input.eventoInscricao != null)
                bd.eventoInscricao.idEventoInscricao.value = input.eventoInscricao.idEventoInscricao;
            else
                bd.eventoInscricao.idEventoInscricao.isNull = true;

            bd.funcaoConvidado.value = input.funcaoConvidado;
            bd.observacao.value = input.observacao;
            bd.quantidadePernoite.value = input.quantidadePernoite;
            bd.valorAcrescimo.value = input.valorAcrescimo;
            bd.valorApartamento.value = input.valorApartamento;
            bd.valorDesconto.value = input.valorDesconto;
            bd.valorEvento.value = input.valorEvento;
            bd.valorRefeicaoExtra.value = input.valorRefeicaoExtra;
            bd.vooDataHorarioChegada.value = input.vooDataHorarioChegada;
            bd.vooDataHorarioSaida.value = input.vooDataHorarioSaida;
            bd.vooETicketChegada.value = input.vooETicketChegada;
            bd.vooETicketSaida.value = input.vooETicketSaida;
            bd.vooNumeroChegada.value = input.vooNumeroChegada;
            bd.vooNumeroSaida.value = input.vooNumeroSaida;

            if (bd.empresaRelacionamentoHotel != null)
                bd.empresaRelacionamentoHotel.idEmpresaRelacionamento.value = input.empresaRelacionamentoHotel.idEmpresaRelacionamento;
            else
                bd.empresaRelacionamentoHotel.idEmpresaRelacionamento.isNull = true;
            if (bd.empresaRelacionamentoParticipante != null)
                bd.empresaRelacionamentoParticipante.idEmpresaRelacionamento.value = input.empresaRelacionamentoParticipante.idEmpresaRelacionamento;
            else
                bd.empresaRelacionamentoParticipante.idEmpresaRelacionamento.isNull = true;

            this.m_EntityManager.persist(bd);

            ((Data.EventoInscricaoParticipante)parametros["Key"]).idEventoInscricaoParticipante = (int)bd.idEventoInscricaoParticipante.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.EventoInscricaoParticipante input = (Data.EventoInscricaoParticipante)parametros["Key"];
            Tables.EventoInscricaoParticipante bd = (Tables.EventoInscricaoParticipante)this.m_EntityManager.find
            (
                typeof(Tables.EventoInscricaoParticipante),
                new Object[]
                {
                    input.idEventoInscricaoParticipante
                }
            );

            bd.dataInscricao.value = input.dataInscricao;
            bd.confirmado.value = input.confirmado;
            bd.dataCancelamento.value = input.dataCancelamento;
            bd.dataChegada.value = input.dataChegada;
            bd.dataInscricao.value = input.dataInscricao;
            bd.dataSaida.value = input.dataSaida;
            if (input.eventoInscricao != null)
                bd.eventoInscricao.idEventoInscricao.value = input.eventoInscricao.idEventoInscricao;
            else
                bd.eventoInscricao.idEventoInscricao.isNull = true;

            bd.funcaoConvidado.value = input.funcaoConvidado;
            bd.observacao.value = input.observacao;
            bd.quantidadePernoite.value = input.quantidadePernoite;
            bd.valorAcrescimo.value = input.valorAcrescimo;
            bd.valorApartamento.value = input.valorApartamento;
            bd.valorDesconto.value = input.valorDesconto;
            bd.valorEvento.value = input.valorEvento;
            bd.valorRefeicaoExtra.value = input.valorRefeicaoExtra;
            bd.vooDataHorarioChegada.value = input.vooDataHorarioChegada;
            bd.vooDataHorarioSaida.value = input.vooDataHorarioSaida;
            bd.vooETicketChegada.value = input.vooETicketChegada;
            bd.vooETicketSaida.value = input.vooETicketSaida;
            bd.vooNumeroChegada.value = input.vooNumeroChegada;
            bd.vooNumeroSaida.value = input.vooNumeroSaida;

            if (bd.empresaRelacionamentoHotel != null)
                bd.empresaRelacionamentoHotel.idEmpresaRelacionamento.value = input.empresaRelacionamentoHotel.idEmpresaRelacionamento;
            else
                bd.empresaRelacionamentoHotel.idEmpresaRelacionamento.isNull = true;
            if (bd.empresaRelacionamentoParticipante != null)
                bd.empresaRelacionamentoParticipante.idEmpresaRelacionamento.value = input.empresaRelacionamentoParticipante.idEmpresaRelacionamento;
            else
                bd.empresaRelacionamentoParticipante.idEmpresaRelacionamento.isNull = true;

            this.m_EntityManager.merge(bd);


            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.EventoInscricaoParticipante bd = new Tables.EventoInscricaoParticipante();

            bd.idEventoInscricaoParticipante.value = ((Data.EventoInscricaoParticipante)parametros["Key"]).idEventoInscricaoParticipante;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.EventoInscricaoParticipante)bd).idEventoInscricaoParticipante.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.EventoInscricaoParticipante)input).operacao = ENum.eOperacao.NONE;

                    ((Data.EventoInscricaoParticipante)input).idEventoInscricaoParticipante = ((Tables.EventoInscricaoParticipante)bd).idEventoInscricaoParticipante.value;
                    ((Data.EventoInscricaoParticipante)input).dataInscricao = ((Tables.EventoInscricaoParticipante)bd).dataInscricao.value;
                    ((Data.EventoInscricaoParticipante)input).dataCancelamento = ((Tables.EventoInscricaoParticipante)bd).dataCancelamento.value;
                    ((Data.EventoInscricaoParticipante)input).dataChegada = ((Tables.EventoInscricaoParticipante)bd).dataChegada.value;
                    ((Data.EventoInscricaoParticipante)input).dataSaida = ((Tables.EventoInscricaoParticipante)bd).dataSaida.value;
                    ((Data.EventoInscricaoParticipante)input).confirmado = ((Tables.EventoInscricaoParticipante)bd).confirmado.value;
                    ((Data.EventoInscricaoParticipante)input).funcaoConvidado = ((Tables.EventoInscricaoParticipante)bd).funcaoConvidado.value;
                    ((Data.EventoInscricaoParticipante)input).observacao = ((Tables.EventoInscricaoParticipante)bd).observacao.value;
                    ((Data.EventoInscricaoParticipante)input).quantidadePernoite = ((Tables.EventoInscricaoParticipante)bd).quantidadePernoite.value;
                    ((Data.EventoInscricaoParticipante)input).valorAcrescimo = ((Tables.EventoInscricaoParticipante)bd).valorAcrescimo.value;
                    ((Data.EventoInscricaoParticipante)input).valorApartamento = ((Tables.EventoInscricaoParticipante)bd).valorApartamento.value;
                    ((Data.EventoInscricaoParticipante)input).valorDesconto = ((Tables.EventoInscricaoParticipante)bd).valorDesconto.value;
                    ((Data.EventoInscricaoParticipante)input).valorEvento = ((Tables.EventoInscricaoParticipante)bd).valorEvento.value;
                    ((Data.EventoInscricaoParticipante)input).valorRefeicaoExtra = ((Tables.EventoInscricaoParticipante)bd).valorRefeicaoExtra.value;
                    ((Data.EventoInscricaoParticipante)input).vooDataHorarioChegada = ((Tables.EventoInscricaoParticipante)bd).vooDataHorarioChegada.value;
                    ((Data.EventoInscricaoParticipante)input).vooDataHorarioSaida = ((Tables.EventoInscricaoParticipante)bd).vooDataHorarioSaida.value;
                    ((Data.EventoInscricaoParticipante)input).vooETicketChegada = ((Tables.EventoInscricaoParticipante)bd).vooETicketChegada.value;
                    ((Data.EventoInscricaoParticipante)input).vooETicketSaida = ((Tables.EventoInscricaoParticipante)bd).vooETicketSaida.value;
                    ((Data.EventoInscricaoParticipante)input).vooNumeroChegada = ((Tables.EventoInscricaoParticipante)bd).vooNumeroChegada.value;
                    ((Data.EventoInscricaoParticipante)input).vooNumeroSaida = ((Tables.EventoInscricaoParticipante)bd).vooNumeroSaida.value;

                    ((Data.EventoInscricaoParticipante)input).empresaRelacionamentoHotel = (Data.EmpresaRelacionamento)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.EmpresaRelacionamento(),
                        ((Tables.EventoInscricaoParticipante)bd).empresaRelacionamentoHotel,
                        level + 1
                    );
                    ((Data.EventoInscricaoParticipante)input).empresaRelacionamentoParticipante = (Data.EmpresaRelacionamento)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.EmpresaRelacionamento(),
                        ((Tables.EventoInscricaoParticipante)bd).empresaRelacionamentoParticipante,
                        level + 1
                    );
                    ((Data.EventoInscricaoParticipante)input).eventoInscricao = (Data.EventoInscricao)(new WS.CRUD.EventoInscricao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.EventoInscricao(),
                        ((Tables.EventoInscricaoParticipante)bd).eventoInscricao,
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
            Data.EventoInscricaoParticipante result = (Data.EventoInscricaoParticipante)parametros["Key"];

            try
            {
                result = (Data.EventoInscricaoParticipante)this.preencher
                (
                    new Data.EventoInscricaoParticipante(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.EventoInscricaoParticipante),
                        new Object[]
                        {
                            result.idEventoInscricaoParticipante
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
            Data.EventoInscricaoParticipante _input = (Data.EventoInscricaoParticipante)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;
            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idEventoInscricaoParticipante > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "EventoInscricaoParticipante.idEventoInscricaoParticipante = @idEventoInscricaoParticipante");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEventoInscricaoParticipante", _input.idEventoInscricaoParticipante));
                    if (!sqlOrderBy.Contains("EventoInscricaoParticipante.idEventoInscricaoParticipante"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "EventoInscricaoParticipante.idEventoInscricaoParticipante");
                    else { }
                }
                else { }

                if (_input.empresaRelacionamentoParticipante != null && _input.empresaRelacionamentoParticipante.idEmpresaRelacionamento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "EventoInscricaoParticipante.idEmpresaRelacionamentoParticipante = @idEmpresaRelacionamentoParticipante");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresaRelacionamentoParticipante", _input.empresaRelacionamentoParticipante.idEmpresaRelacionamento));
                    if (!sqlOrderBy.Contains("EventoInscricaoParticipante.idEmpresaRelacionamentoParticipante"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "EventoInscricaoParticipante.idEmpresaRelacionamentoParticipante");
                    else { }
                }
                else { }

                if (_input.eventoInscricao != null && _input.eventoInscricao.idEventoInscricao > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "EventoInscricaoParticipante.idEventoInscricao = @idEventoInscricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEventoInscricao", _input.eventoInscricao.idEventoInscricao));
                    if (!sqlOrderBy.Contains("EventoInscricaoParticipante.idEventoInscricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "EventoInscricaoParticipante.idEventoInscricao");
                    else { }
                }
                else { }

                if (_input.eventoInscricao != null && _input.eventoInscricao.evento != null && _input.eventoInscricao.evento.idEvento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "evento.idEvento = @idEvento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEvento", _input.eventoInscricao.evento.idEvento));
                    if (!sqlOrderBy.Contains("evento.idEvento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "evento.idEvento");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (numRows > 0 ? " top " + numRows.ToString() + " " : "") +
                    "   * " +
                    "from " +
                    (
                        @"   EventoInscricaoParticipante EventoInscricaoParticipante 
                    inner join eventoInscricao eventoInscricao
                        on eventoInscricao.idEventoInscricao = EventoInscricaoParticipante.idEventoInscricao
                    inner join evento 
                        on evento.idEvento = eventoInscricao.idEvento "
                    ) +
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
            Data.EventoInscricaoParticipante input = (Data.EventoInscricaoParticipante)parametros["Key"];
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
                    typeof(Tables.EventoInscricaoParticipante),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                parametros.Clear();
                parametros = null;

                foreach
                (
                    Tables.EventoInscricaoParticipante _data in
                    (System.Collections.Generic.List<Tables.EventoInscricaoParticipante>)this.m_EntityManager.list
                    (
                        typeof(Tables.EventoInscricaoParticipante),
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
                    _base = (Data.Base)this.preencher(new Data.EventoInscricaoParticipante(), _data, level);

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
