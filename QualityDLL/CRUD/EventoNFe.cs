using System;

namespace WS.CRUD
{
    public class EventoNFe : WS.CRUD.Base
    {
        public EventoNFe(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.EventoNFe input = (Data.EventoNFe)parametros["Key"];
            Tables.EventoNFe bd = new Tables.EventoNFe();

            if (input.movimentoFiscal != null && input.movimentoFiscal.idMovimentoFiscal > 0)
                bd.movimentoFiscal.idMovimentoFiscal.value = input.movimentoFiscal.idMovimentoFiscal;
            else
                bd.movimentoFiscal.idMovimentoFiscal.isNull = true;

            if (!String.IsNullOrEmpty(input.nSeqEvento))
                bd.nSeqEvento.value = input.nSeqEvento;
            else
                bd.nSeqEvento.isNull = true;

            if (input.dhEvento.Ticks > 0)
                bd.dhEvento.value = input.dhEvento;
            else
                bd.dhEvento.isNull = true;

            bd.idEmpresa.value = input.idEmpresa;

            bd.descEvento.value = input.descEvento;
            bd.nProt.value = input.nProt;
            bd.xCorrecao.value = input.xCorrecao;
            bd.xMotivo.value = input.xMotivo;

            if (input.xml.Length > 0)
                bd.xml.value = input.xml;
            else
                bd.xml.isNull = true;

            if (input.cstat > 0)
                bd.cstat.value = input.cstat;
            else
                bd.cstat.isNull = true;

            bd.inutilizacao_nnfini.value = input.inutilizacao_nnfini;
            bd.inutilizacao_nnffin.value = input.inutilizacao_nnffin;
            bd.inutilizacao_serie.value = input.inutilizacao_serie;
            bd.tipoEvento.value = input.tipoEvento;
            bd.ambiente.value = input.ambiente;
            bd.tipoDocumento.value = input.tipoDocumento;

            if (input.movimentoFiscal != null)
            {
                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                _parametros.Add("Key", input.movimentoFiscal);
                _parametros.Add("Return", bd.movimentoFiscal);

                input.movimentoFiscal = (Data.MovimentoFiscal)(new WS.CRUD.MovimentoFiscal(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }
            else { }

            this.m_EntityManager.persist(bd);
            ((Data.EventoNFe)parametros["Key"]).idEventoNFe = (int)bd.idEventoNFe.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.EventoNFe input = (Data.EventoNFe)parametros["Key"];
            Tables.EventoNFe bd = (Tables.EventoNFe)this.m_EntityManager.find
            (
                typeof(Tables.EventoNFe),
                new Object[]
                {
                    input.idEventoNFe
                }
            );

            if (input.movimentoFiscal != null && input.movimentoFiscal.idMovimentoFiscal > 0)
                bd.movimentoFiscal.idMovimentoFiscal.value = input.movimentoFiscal.idMovimentoFiscal;
            else
                bd.movimentoFiscal.idMovimentoFiscal.isNull = true;

            if (!String.IsNullOrEmpty(input.nSeqEvento))
                bd.nSeqEvento.value = input.nSeqEvento;
            else
                bd.nSeqEvento.isNull = true;

            if (input.dhEvento.Ticks > 0)
                bd.dhEvento.value = input.dhEvento;
            else
                bd.dhEvento.isNull = true;

            bd.idEmpresa.value = input.idEmpresa;
            bd.descEvento.value = input.descEvento;
            bd.nProt.value = input.nProt;
            bd.xCorrecao.value = input.xCorrecao;
            bd.xMotivo.value = input.xMotivo;
            bd.ambiente.value = input.ambiente;
            bd.tipoDocumento.value = input.tipoDocumento;

            if (input.xml.Length > 0)
                bd.xml.value = input.xml;
            else
                bd.xml.isNull = true;

            if (input.cstat > 0)
                bd.cstat.value = input.cstat;
            else
                bd.cstat.isNull = true;

            bd.inutilizacao_nnfini.value = input.inutilizacao_nnfini;
            bd.inutilizacao_nnffin.value = input.inutilizacao_nnffin;
            bd.inutilizacao_serie.value = input.inutilizacao_serie;
            bd.tipoEvento.value = input.tipoEvento;

            if (input.movimentoFiscal != null)
            {
                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                _parametros.Add("Key", input.movimentoFiscal);
                _parametros.Add("Return", bd.movimentoFiscal);

                input.movimentoFiscal = (Data.MovimentoFiscal)(new WS.CRUD.MovimentoFiscal(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }
            else { }

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.EventoNFe bd = new Tables.EventoNFe();

            bd.idEventoNFe.value = ((Data.EventoNFe)parametros["Key"]).idEventoNFe;

            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.EventoNFe)bd).idEventoNFe.isNull
                )
                {

                    ((Data.EventoNFe)input).operacao = ENum.eOperacao.NONE;
                    ((Data.EventoNFe)input).idEventoNFe = ((Tables.EventoNFe)bd).idEventoNFe.value;
                    ((Data.EventoNFe)input).nSeqEvento = ((Tables.EventoNFe)bd).nSeqEvento.value;
                    ((Data.EventoNFe)input).dhEvento = ((Tables.EventoNFe)bd).dhEvento.value;
                    ((Data.EventoNFe)input).descEvento = ((Tables.EventoNFe)bd).descEvento.value;
                    ((Data.EventoNFe)input).nProt = ((Tables.EventoNFe)bd).nProt.value;
                    ((Data.EventoNFe)input).xCorrecao = ((Tables.EventoNFe)bd).xCorrecao.value;
                    ((Data.EventoNFe)input).xMotivo = ((Tables.EventoNFe)bd).xMotivo.value;
                    ((Data.EventoNFe)input).xml = ((Tables.EventoNFe)bd).xml.value;
                    ((Data.EventoNFe)input).cstat = ((Tables.EventoNFe)bd).cstat.value;
                    ((Data.EventoNFe)input).inutilizacao_nnfini = ((Tables.EventoNFe)bd).inutilizacao_nnfini.value;
                    ((Data.EventoNFe)input).inutilizacao_nnffin = ((Tables.EventoNFe)bd).inutilizacao_nnffin.value;
                    ((Data.EventoNFe)input).inutilizacao_serie = ((Tables.EventoNFe)bd).inutilizacao_serie.value;
                    ((Data.EventoNFe)input).tipoEvento = ((Tables.EventoNFe)bd).tipoEvento.value;
                    ((Data.EventoNFe)input).ambiente = ((Tables.EventoNFe)bd).ambiente.value;
                    ((Data.EventoNFe)input).tipoDocumento = ((Tables.EventoNFe)bd).tipoDocumento.value;
                    ((Data.EventoNFe)input).idEmpresa = ((Tables.EventoNFe)bd).idEmpresa.value;
                    ((Data.EventoNFe)input).movimentoFiscal = (Data.MovimentoFiscal)(new WS.CRUD.MovimentoFiscal(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.MovimentoFiscal(),
                        ((Tables.EventoNFe)bd).movimentoFiscal,
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
            Data.EventoNFe result = (Data.EventoNFe)parametros["Key"];

            try
            {
                result = (Data.EventoNFe)this.preencher
                (
                    new Data.EventoNFe(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.EventoNFe),
                        new Object[]
                        {
                            result.idEventoNFe
                        }
                    ),
                    0
                );
            }
            catch (Exception e)
            {
                System.Console.Out.Write(this.GetType().ToString() + ".consultar() -> " + e.ToString());
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

            Data.EventoNFe _input = (Data.EventoNFe)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idEventoNFe > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "EventoNFe.idEventoNFe = @idEventoNFe");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEventoNFe", _input.idEventoNFe));
                    if (!sqlOrderBy.Contains("EventoNFe.idEventoNFe"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "EventoNFe.idEventoNFe");
                    else { }
                }
                else { }

                if (_input.idEmpresa > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "EventoNFe.idEmpresa = @idEmpresa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.idEmpresa));
                    if (!sqlOrderBy.Contains("EventoNFe.idEmpresa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "EventoNFe.idEmpresa");
                    else { }
                }
                else { }

                if (_input.movimentoFiscal != null)
                {
                    if (_input.movimentoFiscal.idMovimentoFiscal > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "EventoNFe.idMovimentoFiscal = @idMovimentoFiscal");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idMovimentoFiscal", _input.movimentoFiscal.idMovimentoFiscal));
                        if (!sqlOrderBy.Contains("EventoNFe.idMovimentoFiscal"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "EventoNFe.idMovimentoFiscal");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.inutilizacao_serie > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "EventoNFe.inutilizacao_serie = @inutilizacao_serie");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("inutilizacao_serie", _input.inutilizacao_serie));
                    if (!sqlOrderBy.Contains("EventoNFe.inutilizacao_serie"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "EventoNFe.inutilizacao_serie");
                    else { }
                }
                else { }

                if (_input.inutilizacao_nnffin > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "EventoNFe.inutilizacao_nnffin = @inutilizacao_nnffin");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("inutilizacao_nnffin", _input.inutilizacao_nnffin));
                    if (!sqlOrderBy.Contains("EventoNFe.inutilizacao_nnffin"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "EventoNFe.inutilizacao_nnffin");
                    else { }
                }
                else { }

                if (_input.inutilizacao_nnfini > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "EventoNFe.inutilizacao_nnfini = @inutilizacao_nnfini");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("inutilizacao_nnfini", _input.inutilizacao_nnfini));
                    if (!sqlOrderBy.Contains("EventoNFe.inutilizacao_nnfini"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "EventoNFe.inutilizacao_nnfini");
                    else { }
                }
                else { }

                if (_input.ambiente > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "EventoNFe.ambiente = @ambiente");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("ambiente", _input.ambiente));
                    if (!sqlOrderBy.Contains("EventoNFe.ambiente"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "EventoNFe.ambiente");
                    else { }
                }
                else { }

                if (_input.cstat > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "EventoNFe.cstat = @cstat");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("cstat", _input.cstat));
                    if (!sqlOrderBy.Contains("EventoNFe.cstat"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "EventoNFe.cstat");
                    else { }
                }
                else { }

                if (_input.tipoEvento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "EventoNFe.tipoEvento = @tipoEvento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("tipoEvento", _input.tipoEvento));
                    if (!sqlOrderBy.Contains("EventoNFe.tipoEvento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "EventoNFe.tipoEvento");
                    else { }
                }
                else { }

                if (_input.dhEvento.Ticks > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "EventoNFe.dhEvento = @dhEvento");
                    fieldKeys.Add(new EJB.TableBase.TFieldDatetime("dhEvento", _input.dhEvento));
                    if (!sqlOrderBy.Contains("EventoNFe.dhEvento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "EventoNFe.dhEvento");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.nProt))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "EventoNFe.nProt = @nProt");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("nProt", _input.nProt));
                    if (!sqlOrderBy.Contains("EventoNFe.nProt"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "EventoNFe.nProt");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "EventoNFe.* ") +
                    "from " +
                    (
                        "   EventoNFe EventoNFe " +
                        "       left join movimentoFiscal movimentoFiscal " +
                        "           on	movimentoFiscal.idMovimentoFiscal = EventoNFe.idMovimentoFiscal "
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
            Data.EventoNFe input = (Data.EventoNFe)parametros["Key"];
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
                    typeof(Tables.EventoNFe),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.EventoNFe _data in
                    (System.Collections.Generic.List<Tables.EventoNFe>)this.m_EntityManager.list
                    (
                        typeof(Tables.EventoNFe),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.EventoNFe();

                        ((Data.EventoNFe)_base).idEventoNFe = _data.idEventoNFe.value;
                        ((Data.EventoNFe)_base).nSeqEvento = _data.nSeqEvento.value;
                        ((Data.EventoNFe)_base).dhEvento = _data.dhEvento.value;
                        ((Data.EventoNFe)_base).descEvento = _data.descEvento.value;
                        ((Data.EventoNFe)_base).nProt = _data.nProt.value;
                        ((Data.EventoNFe)_base).xCorrecao = _data.xCorrecao.value;
                        ((Data.EventoNFe)_base).xMotivo = _data.xMotivo.value;
                        ((Data.EventoNFe)_base).xml = _data.xml.value;
                        ((Data.EventoNFe)_base).cstat = _data.cstat.value;
                        ((Data.EventoNFe)_base).inutilizacao_nnfini = _data.inutilizacao_nnfini.value;
                        ((Data.EventoNFe)_base).inutilizacao_nnffin = _data.inutilizacao_nnffin.value;
                        ((Data.EventoNFe)_base).inutilizacao_serie = _data.inutilizacao_serie.value;
                        ((Data.EventoNFe)_base).tipoEvento = _data.tipoEvento.value;
                        ((Data.EventoNFe)_base).idEmpresa = _data.idEmpresa.value;
                        ((Data.EventoNFe)_base).ambiente = _data.ambiente.value;
                        ((Data.EventoNFe)_base).tipoDocumento = _data.tipoDocumento.value;

                        if (_data.movimentoFiscal != null && _data.movimentoFiscal.idMovimentoFiscal.value > 0)
                            ((Data.EventoNFe)_base).movimentoFiscal = new Data.MovimentoFiscal
                            {
                                idMovimentoFiscal = _data.movimentoFiscal.idMovimentoFiscal.value,
                                pdvCompra = new Data.PdvCompra
                                {
                                    idPdvCompra = _data.movimentoFiscal.pdvCompra.idPdvCompra.value
                                },
                                serie = _data.movimentoFiscal.serie.value,
                                numero = _data.movimentoFiscal.numero.value
                            };
                        else { }
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.EventoNFe(), _data, level);

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
                System.Console.Out.Write(this.GetType().ToString() + ".listar() -> " + e.ToString());
                throw new Exception(e.Message);
            }

            return ((result.Count > 0) ? result.ToArray() : null);
        }
    }
}
