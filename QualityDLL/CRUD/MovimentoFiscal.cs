using System;
using System.Linq;
using System.Collections.Generic;

namespace WS.CRUD
{
    public class MovimentoFiscal : WS.CRUD.Base
    {
        public MovimentoFiscal(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.MovimentoFiscal input = (Data.MovimentoFiscal)parametros["Key"];
            Tables.MovimentoFiscal bd = new Tables.MovimentoFiscal();

            bd.serie.value = input.serie;

            if (input.pdvCompra != null && input.pdvCompra.idPdvCompra > 0)
                bd.pdvCompra.idPdvCompra.value = input.pdvCompra.idPdvCompra;
            else
                bd.pdvCompra.idPdvCompra.isNull = true;

            bd.xmlEnvio.value = input.xmlEnvio;

            if (input.xmlRetorno != null && input.xmlRetorno.Length > 0)
                bd.xmlRetorno.value = input.xmlRetorno;
            else
                bd.xmlRetorno.isNull = true;

            bd.emitida.value = input.emitida == "s";
            bd.cancelada.value = input.cancelada == "s";
            bd.dataEmissao.value = input.dataEmissao;
            bd.chave.value = input.chave;

            if (input.cstat > 0)
                bd.cstat.value = input.cstat;
            else
                bd.cstat.isNull = true;

            bd.xMotivo.value = input.xMotivo;
            bd.dhRecbto.value = input.dhRecbto;
            bd.ambiente.value = input.ambiente;
            bd.contingencia.value = input.contingencia == "s";
            bd.numero.value = input.numero;
            bd.tipoDocumento.value = input.tipoDocumento;

            this.m_EntityManager.persist(bd);

            ((Data.MovimentoFiscal)parametros["Key"]).idMovimentoFiscal = (int)bd.idMovimentoFiscal.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.MovimentoFiscal input = (Data.MovimentoFiscal)parametros["Key"];
            Tables.MovimentoFiscal bd = (Tables.MovimentoFiscal)this.m_EntityManager.find
            (
                typeof(Tables.MovimentoFiscal),
                new Object[]
                {
                    input.idMovimentoFiscal
                }
            );

            bd.serie.value = input.serie;

            if (input.pdvCompra != null && input.pdvCompra.idPdvCompra > 0)
                bd.pdvCompra.idPdvCompra.value = input.pdvCompra.idPdvCompra;
            else
                bd.pdvCompra.idPdvCompra.isNull = true;

            bd.xmlEnvio.value = input.xmlEnvio;
            bd.xmlRetorno.value = input.xmlRetorno;
            bd.emitida.value = input.emitida == "s";
            bd.cancelada.value = input.cancelada == "s";
            bd.dataEmissao.value = input.dataEmissao;
            bd.chave.value = input.chave;
            bd.cstat.value = input.cstat;
            bd.xMotivo.value = input.xMotivo;
            bd.dhRecbto.value = input.dhRecbto;
            bd.ambiente.value = input.ambiente;
            bd.contingencia.value = input.contingencia == "s";
            bd.numero.value = input.numero;
            bd.tipoDocumento.value = input.tipoDocumento;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.MovimentoFiscal bd = new Tables.MovimentoFiscal();

            bd.idMovimentoFiscal.value = ((Data.MovimentoFiscal)parametros["Key"]).idMovimentoFiscal;

            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.MovimentoFiscal)bd).idMovimentoFiscal.isNull
                )
                {

                    ((Data.MovimentoFiscal)input).operacao = ENum.eOperacao.NONE;
                    ((Data.MovimentoFiscal)input).idMovimentoFiscal = ((Tables.MovimentoFiscal)bd).idMovimentoFiscal.value;
                    ((Data.MovimentoFiscal)input).serie = ((Tables.MovimentoFiscal)bd).serie.value;
                    ((Data.MovimentoFiscal)input).xmlEnvio = ((Tables.MovimentoFiscal)bd).xmlEnvio.value;
                    ((Data.MovimentoFiscal)input).xmlRetorno = ((Tables.MovimentoFiscal)bd).xmlRetorno.value;
                    ((Data.MovimentoFiscal)input).emitida = ((Tables.MovimentoFiscal)bd).emitida.value ? "s" : "n";
                    ((Data.MovimentoFiscal)input).cancelada = ((Tables.MovimentoFiscal)bd).cancelada.value ? "s" : "n";
                    ((Data.MovimentoFiscal)input).dataEmissao = ((Tables.MovimentoFiscal)bd).dataEmissao.value;
                    ((Data.MovimentoFiscal)input).chave = ((Tables.MovimentoFiscal)bd).chave.value;
                    ((Data.MovimentoFiscal)input).cstat = ((Tables.MovimentoFiscal)bd).cstat.value;
                    ((Data.MovimentoFiscal)input).xMotivo = ((Tables.MovimentoFiscal)bd).xMotivo.value;
                    ((Data.MovimentoFiscal)input).dhRecbto = ((Tables.MovimentoFiscal)bd).dhRecbto.value;
                    ((Data.MovimentoFiscal)input).ambiente = ((Tables.MovimentoFiscal)bd).ambiente.value;
                    ((Data.MovimentoFiscal)input).contingencia = ((Tables.MovimentoFiscal)bd).contingencia.value ? "s" : "n";
                    ((Data.MovimentoFiscal)input).numero = ((Tables.MovimentoFiscal)bd).numero.value;
                    ((Data.MovimentoFiscal)input).tipoDocumento = ((Tables.MovimentoFiscal)bd).tipoDocumento.value;
                    ((Data.MovimentoFiscal)input).formaPagamento = ((Tables.MovimentoFiscal)bd).formaPagamento.value;
                    ((Data.MovimentoFiscal)input).pdvCompra = (Data.PdvCompra)(new WS.CRUD.PdvCompra(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PdvCompra(),
                        ((Tables.MovimentoFiscal)bd).pdvCompra,
                        level
                    );

                    if (((Tables.MovimentoFiscal)bd).cancelada.value)
                        ((Data.MovimentoFiscal)input).status = ENum.eMovimentoFiscalStatus.cancelada;
                    else if (((Tables.MovimentoFiscal)bd).emitida.value && (((Tables.MovimentoFiscal)bd).cstat.value == 100 || ((Tables.MovimentoFiscal)bd).cstat.value == 150))
                        ((Data.MovimentoFiscal)input).status = ENum.eMovimentoFiscalStatus.autorizada;
                    else if (((Tables.MovimentoFiscal)bd).emitida.value && (((Tables.MovimentoFiscal)bd).cstat.value != 100 && ((Tables.MovimentoFiscal)bd).cstat.value != 150))
                        ((Data.MovimentoFiscal)input).status = ENum.eMovimentoFiscalStatus.rejeitada;
                    else if (((Tables.MovimentoFiscal)bd).contingencia.value)
                        ((Data.MovimentoFiscal)input).status = ENum.eMovimentoFiscalStatus.contingencia;

                    if (((Tables.MovimentoFiscal)bd).tipoDocumento.value == 65)
                    {
                        if (((Tables.MovimentoFiscal)bd).cancelada.value)
                            ((Data.MovimentoFiscal)input).status = ENum.eMovimentoFiscalStatus.cancelada;
                        else if (((Tables.MovimentoFiscal)bd).emitida.value && (((Tables.MovimentoFiscal)bd).cstat.value == 100 || ((Tables.MovimentoFiscal)bd).cstat.value == 150))
                            ((Data.MovimentoFiscal)input).status = ENum.eMovimentoFiscalStatus.autorizada;
                        else if (((Tables.MovimentoFiscal)bd).emitida.value && (((Tables.MovimentoFiscal)bd).cstat.value != 100 && ((Tables.MovimentoFiscal)bd).cstat.value != 150))
                            ((Data.MovimentoFiscal)input).status = ENum.eMovimentoFiscalStatus.rejeitada;
                        else if (((Tables.MovimentoFiscal)bd).contingencia.value)
                            ((Data.MovimentoFiscal)input).status = ENum.eMovimentoFiscalStatus.contingencia;
                    }
                    else
                    {

                        if (((Tables.MovimentoFiscal)bd).cancelada.value)
                            ((Data.MovimentoFiscal)input).status = ENum.eMovimentoFiscalStatus.cancelada;
                        else if (((Tables.MovimentoFiscal)bd).emitida.value && (((Tables.MovimentoFiscal)bd).cstat.value == 100 || ((Tables.MovimentoFiscal)bd).cstat.value == 150))
                            ((Data.MovimentoFiscal)input).status = ENum.eMovimentoFiscalStatus.autorizada;
                        else if ((((Tables.MovimentoFiscal)bd).cstat.value != 100 && ((Tables.MovimentoFiscal)bd).cstat.value != 150))
                            ((Data.MovimentoFiscal)input).status = ENum.eMovimentoFiscalStatus.rejeitada;
                        else if (((Tables.MovimentoFiscal)bd).contingencia.value)
                            ((Data.MovimentoFiscal)input).status = ENum.eMovimentoFiscalStatus.contingencia;
                    }

                }
                else { }
            }
            else { }
            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.MovimentoFiscal result = (Data.MovimentoFiscal)parametros["Key"];

            try
            {
                result = (Data.MovimentoFiscal)this.preencher
                (
                    new Data.MovimentoFiscal(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.MovimentoFiscal),
                        new Object[]
                        {
                            result.idMovimentoFiscal
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
                sqlOrderBy = "",
                sqlInner = "",
                sqlWhereFormaPagamento = "";

            int
                numRows = 0,
                offSet = -1;

            bool
                onlyCount = false,
                semFormaPagamento = false;

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

                if (_params.Contains("semFormaPagamento"))
                    semFormaPagamento = (bool)_params["semFormaPagamento"];
                else { }
            }
            else { }

            Data.MovimentoFiscal _input = (Data.MovimentoFiscal)input;
            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;
            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            bool contemCancelada = false;
            try
            {
                foreach (ENum.eMovimentoFiscalStatus item in _input.statusFiltro)
                    if (item == ENum.eMovimentoFiscalStatus.cancelada)
                    {
                        contemCancelada = true;
                        break;
                    }
            }
            catch { }

            if (table != null)
            {
                if (_input.idMovimentoFiscal > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "MovimentoFiscal.idMovimentoFiscal = @idMovimentoFiscal");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idMovimentoFiscal", _input.idMovimentoFiscal));
                    if (!sqlOrderBy.Contains("MovimentoFiscal.idMovimentoFiscal"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "MovimentoFiscal.idMovimentoFiscal");
                    else { }
                }
                else { }

                if (_input.pdvCompra != null)
                {
                    if (_input.pdvCompra.idPdvCompra > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "MovimentoFiscal.idPdvCompra = @idPdvCompra");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvCompra", _input.pdvCompra.idPdvCompra));
                        if (!sqlOrderBy.Contains("MovimentoFiscal.idPdvCompra"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "MovimentoFiscal.idPdvCompra");
                        else { }
                    }
                    else { }

                    if (_input.pdvCompra.pdvEstacao != null)
                    {
                        if (_input.pdvCompra.pdvEstacao.departamento != null)
                        {
                            if (_input.pdvCompra.pdvEstacao.departamento.idEmpresa > 0)
                            {
                                sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "departamento.idEmpresa = @idEmpresa");
                                fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.pdvCompra.pdvEstacao.departamento.idEmpresa));
                                if (!sqlOrderBy.Contains("departamento.idEmpresa"))
                                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "departamento.idEmpresa");
                                else { }
                            }
                            else { }
                        }
                        else { }

                        if (_input.pdvCompra.formaPagamentos != null && _input.pdvCompra.formaPagamentos.Length > 0)
                        {
                            sqlWhereFormaPagamento = " (";
                            foreach (Data.FormaPagamento fp in _input.pdvCompra.formaPagamentos)
                                sqlWhereFormaPagamento += (sqlWhereFormaPagamento.Length > 2 ? " OR " : null) + String.Format(" movimentoFiscal.formaPagamento LIKE '%{0}%'", fp.descricao);

                            if (contemCancelada)
                                sqlWhereFormaPagamento += (sqlWhereFormaPagamento.Length > 2 ? " OR " : null) + String.Format(" IsNull(movimentoFiscal.formaPagamento, '') = ''");

                            sqlWhereFormaPagamento += ")";

                            //sqlWhere += (sqlWhere.Length > 0 ? " AND " : null) + sqlWhereFormaPagamento;
                        }
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.dataEmissao.Ticks > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "MovimentoFiscal.dataEmissao = @dataEmissao");
                    fieldKeys.Add(new EJB.TableBase.TFieldDatetime("dataEmissao", _input.dataEmissao));
                    if (!sqlOrderBy.Contains("MovimentoFiscal.dataEmissao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "MovimentoFiscal.dataEmissao");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.chave))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "MovimentoFiscal.chave = @chave");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("chave", _input.chave));
                    if (!sqlOrderBy.Contains("MovimentoFiscal.chave"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "MovimentoFiscal.chave");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.emitida))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "MovimentoFiscal.emitida = @emitida");
                    fieldKeys.Add(new EJB.TableBase.TFieldBoolean("emitida", _input.emitida == "s"));
                }
                else { }

                if (!String.IsNullOrEmpty(_input.cancelada))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "MovimentoFiscal.cancelada = @cancelada");
                    fieldKeys.Add(new EJB.TableBase.TFieldBoolean("cancelada", _input.cancelada == "s"));
                }
                else { }

                if (_input.serie >= 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "MovimentoFiscal.serie = @serie");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("serie", _input.serie));
                    if (!sqlOrderBy.Contains("MovimentoFiscal.serie"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "MovimentoFiscal.serie");
                    else { }
                }
                else { }

                if (_input.numero > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "MovimentoFiscal.numero = @numero");
                    fieldKeys.Add(new EJB.TableBase.TFieldBigInteger("numero", _input.numero));
                    if (!sqlOrderBy.Contains("MovimentoFiscal.numero"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "MovimentoFiscal.numero");
                    else { }
                }
                else { }

                if (_input.tipoDocumento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "MovimentoFiscal.tipoDocumento = @tipoDocumento");
                    fieldKeys.Add(new EJB.TableBase.TFieldBigInteger("tipoDocumento", _input.tipoDocumento));
                    if (!sqlOrderBy.Contains("MovimentoFiscal.tipoDocumento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "MovimentoFiscal.tipoDocumento");
                    else { }
                }
                else { }

                if (_input.ambiente > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "MovimentoFiscal.ambiente = @ambiente");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("ambiente", _input.ambiente));
                }
                else { }

                if (_input.statusFiltro != null && _input.statusFiltro.Length > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and (" : "("));
                    string _filterStatus = String.Empty;
                    foreach (ENum.eMovimentoFiscalStatus item in _input.statusFiltro)
                    {
                        if (item is ENum.eMovimentoFiscalStatus.autorizada)
                            _filterStatus += ((_filterStatus.Length > 0 ? " OR (" : "(") + "MOVIMENTOFISCAL.EMITIDA = 1 AND (MOVIMENTOFISCAL.CSTAT = 100 OR MOVIMENTOFISCAL.CSTAT = 150) AND MOVIMENTOFISCAL.CANCELADA = 0)");
                        else { }

                        if (item is ENum.eMovimentoFiscalStatus.cancelada)
                            _filterStatus += ((_filterStatus.Length > 0 ? " OR (" : "(") + "MOVIMENTOFISCAL.CANCELADA = 1)");
                        else { }

                        if (item is ENum.eMovimentoFiscalStatus.rejeitada)
                            _filterStatus += ((_filterStatus.Length > 0 ? " OR (" : "(") + "MOVIMENTOFISCAL.EMITIDA = 1 AND IsNull(CSTAT, 0) <> 100 AND IsNull(CSTAT, 0) <> 150)");
                        else { }

                        if (item is ENum.eMovimentoFiscalStatus.contingencia)
                            if (_input.tipoDocumento == 59)
                                _filterStatus += ((_filterStatus.Length > 0 ? " OR (" : "(") + "(MOVIMENTOFISCAL.CONTINGENCIA = 1 OR MOVIMENTOFISCAL.CONTINGENCIA = 0) AND IsNull(CSTAT, 0) <> 100 AND IsNull(CSTAT, 0) <> 150 AND MOVIMENTOFISCAL.CANCELADA <> 1)");
                            else
                                _filterStatus += ((_filterStatus.Length > 0 ? " OR (" : "(") + "MOVIMENTOFISCAL.CONTINGENCIA = 1 AND IsNull(CSTAT, 0) <> 100 AND IsNull(CSTAT, 0) <> 150 AND MOVIMENTOFISCAL.CANCELADA <> 1)");
                        else { }

                    }
                    sqlWhere += _filterStatus;
                    sqlWhere += ")";
                }
                else { }

                string randomTb = String.Empty;
                if (!onlyCount)
                {
                    if (!semFormaPagamento)
                    {
                        randomTb = new Random().Next(1, 1000).ToString();

                        result += @" select 
    " + (((numRows > 0) && (offSet < 0)) ? @" top " + numRows.ToString() + " " : "") + @"

MovimentoFiscal.idMovimentoFiscal,
MovimentoFiscal.idNfe,
MovimentoFiscal.idPdvCompra,
MovimentoFiscal.serie,
MovimentoFiscal.xmlEnvio,
MovimentoFiscal.xmlRetorno,
MovimentoFiscal.emitida,
MovimentoFiscal.cancelada,
MovimentoFiscal.dataEmissao,
MovimentoFiscal.chave,
MovimentoFiscal.cstat,
MovimentoFiscal.xMotivo,
MovimentoFiscal.dhRecbto,
MovimentoFiscal.ambiente,
MovimentoFiscal.contingencia,
MovimentoFiscal.numero,
MovimentoFiscal.tipoDocumento,
STUFF
	( 
		( 

			SELECT
				qr.descricao
			FROM
			(
				SELECT 
					', ' + formaPagamento.descricao descricao
				FROM contasAReceberPagamento Cr1 
				INNER JOIN contaPagamento ON Cr1.idContaPagamento = contaPagamento.idContaPagamento 
				INNER JOIN formaPagamento ON contaPagamento.idFormaPagamento = formaPagamento.idFormaPagamento 
				WHERE 
					pdvCompra.idContasAReceber = Cr1.idContasAReceber 		
				UNION
				SELECT
					', Pós Pago' descricao
				FROM
					empresaRelacionamentoCartaoMovimento ercm
				WHERE
					pdvCompra.idPdvCompra = ercm.idPdvCompra AND
                    ercm.tipoMovimento = 'PP' AND ercm.tipoOperacao = 'V'
                UNION
				SELECT
					', Pré Pago' descricao
				FROM
					empresaRelacionamentoCartaoMovimento ercm
				WHERE
					pdvCompra.idPdvCompra = ercm.idPdvCompra AND
                    ercm.tipoMovimento = 'PR' AND ercm.tipoOperacao = 'V'
			) qr
			ORDER BY qr.descricao
			FOR XML PATH(''), TYPE
		).value('.', 'NVARCHAR(MAX)'), 1, 1, '') formaPagamento
INTO #tbMovimentoFiscalTmp" + randomTb + @"
 from MovimentoFiscal MovimentoFiscal 
 left join pdvCompra pdvCompra on pdvCompra.idPdvCompra = MovimentoFiscal.idPdvCompra 
LEFT JOIN pdvEstacoes ON pdvEstacoes.idPdvEstacao = pdvCompra.idPdvEstacao
LEFT JOIN departamento ON departamento.idDepartamento = pdvEstacoes.idDepartamento
" + sqlInner;

                        if (_input.pdvCompra != null)
                        {
                            if (_input.pdvCompra.idPdvCompra > 0)
                            {
                                result += "\n WHERE movimentoFiscal.idPdvCompra = " + _input.pdvCompra.idPdvCompra.ToString();
                            }
                            else { }
                        }
                        else { }
                    }
                    else { }


                    {
                        var splitTestWhere = result.Split(new string[] { "LEFT JOIN departamento ON departamento.idDepartamento = pdvEstacoes.idDepartamento" }, StringSplitOptions.None);
                        if (splitTestWhere.Length > 1)
                            result += (sqlWhere.Length > 0 ? (splitTestWhere[1].ToLower().Contains("where") ? " AND " : " WHERE ") + sqlWhere : "");
                    }
                    if (!String.IsNullOrEmpty(sqlWhereFormaPagamento))
                    {
                        sqlWhere += (sqlWhere.Length > 0 ? " AND " : null) + sqlWhereFormaPagamento;
                        if (!contemCancelada)
                            sqlWhere += (sqlWhere.Length > 0 ? " AND " : null) + " movimentoFiscal.formaPagamento IS NOT NULL";
                        else { }
                    }
                    else { }

                    if (!String.IsNullOrEmpty(result))
                        result += ((sqlOrderBy.Length > 0 ? " order by " + sqlOrderBy : "") +
                                (((numRows > 0) && (offSet >= 0)) ? " offset " + offSet + " rows fetch next " + numRows + " rows only" : ""));
                }
                else { }

                result +=
                (
                    "\nselect " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "MovimentoFiscal.* ") +
                    "from " +
                    (
                        (!semFormaPagamento ? ((!onlyCount ? "   #tbMovimentoFiscalTmp" : null) + randomTb + " MovimentoFiscal ") : " MovimentoFiscal ") +
                        "       left join pdvCompra pdvCompra " +
                        "           on	pdvCompra.idPdvCompra = MovimentoFiscal.idPdvCompra " +
                        "       LEFT JOIN pdvEstacoes ON pdvEstacoes.idPdvEstacao = pdvCompra.idPdvEstacao " +
                        "       LEFT JOIN departamento ON departamento.idDepartamento = pdvEstacoes.idDepartamento " +
                        sqlInner
                    ) +
                    (sqlWhere.Length > 0 ? " where " + sqlWhere : "") +
                    (onlyCount ? "" :
                        (sqlOrderBy.Length > 0 ? " order by " + sqlOrderBy : "") +
                        (((numRows > 0) && (offSet >= 0) && semFormaPagamento) ? " offset " + offSet + " rows fetch next " + numRows + " rows only" : "")
                    )
                );

                if (!onlyCount)
                    if (!semFormaPagamento)
                        result += "\nDROP TABLE #tbMovimentoFiscalTmp" + randomTb;
                    else { }

                table = null;
            }
            else { }

            return result;
        }

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.MovimentoFiscal input = (Data.MovimentoFiscal)parametros["Key"];
            System.Collections.Generic.List<Data.Base> result = new System.Collections.Generic.List<Data.Base>();
            string mode = (string)(parametros["Mode"] == null ? "" : parametros["Mode"]);
            int level = (int)(parametros["Level"] == null ? 0 : parametros["Level"]);
            bool semFormaPagamento = (bool)(parametros["semFormaPagamento"] == null ? false : parametros["semFormaPagamento"]);

            System.Collections.Hashtable makeSelectParams = new System.Collections.Hashtable();
            makeSelectParams["numRows"] = (parametros["Top"] == null ? 0 : (int)parametros["Top"]);
            makeSelectParams["where"] = (parametros["Filter"] == null ? "" : (String)parametros["Filter"]);
            makeSelectParams["orderBy"] = (parametros["Order"] == null ? "" : (String)parametros["Order"]);
            makeSelectParams["offSet"] = (parametros["Offset"] == null ? -1 : parametros["Offset"]);
            makeSelectParams["semFormaPagamento"] = semFormaPagamento;

            Report.Base report = (Report.Base)parametros["Report"];
            int i = 0;

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
                    typeof(Tables.MovimentoFiscal),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;
                foreach
                (
                    Tables.MovimentoFiscal _data in
                    (System.Collections.Generic.List<Tables.MovimentoFiscal>)this.m_EntityManager.list
                    (
                        typeof(Tables.MovimentoFiscal),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.MovimentoFiscal();

                        ((Data.MovimentoFiscal)_base).idMovimentoFiscal = _data.idMovimentoFiscal.value;
                        //((Data.MovimentoFiscal)_base).fornecedor = new Data.Fornecedor { pessoa = new Data.Pessoa { nomeRazaoSocial = _data.fornecedor.fornecedorEmpresaRelacionamento.pessoaRelacionamento.nomeRazaoSocial.value } };
                        ((Data.MovimentoFiscal)_base).ambiente = _data.ambiente.value;
                        ((Data.MovimentoFiscal)_base).cancelada = _data.cancelada.value ? "s" : "n";
                        ((Data.MovimentoFiscal)_base).chave = _data.chave.value;
                        ((Data.MovimentoFiscal)_base).contingencia = _data.contingencia.value ? "s" : "n";
                        ((Data.MovimentoFiscal)_base).cstat = _data.cstat.value;
                        ((Data.MovimentoFiscal)_base).dataEmissao = _data.dataEmissao.value;
                        ((Data.MovimentoFiscal)_base).dhRecbto = _data.dhRecbto.value;
                        ((Data.MovimentoFiscal)_base).emitida = _data.emitida.value ? "s" : "n";
                        ((Data.MovimentoFiscal)_base).formaPagamento = _data.formaPagamento.value;
                        ((Data.MovimentoFiscal)_base).numero = _data.numero.value;
                        ((Data.MovimentoFiscal)_base).pdvCompra = new Data.PdvCompra
                        {
                            idPdvCompra = _data.pdvCompra.idPdvCompra.value,
                            cpfCnpj = _data.pdvCompra.cpfCnpj.value
                        };

                        if (_data.tipoDocumento.value == 65)
                        {
                            if (_data.cancelada.value)
                                ((Data.MovimentoFiscal)_base).status = ENum.eMovimentoFiscalStatus.cancelada;
                            else if (_data.emitida.value && (_data.cstat.value == 100 || _data.cstat.value == 150))
                                ((Data.MovimentoFiscal)_base).status = ENum.eMovimentoFiscalStatus.autorizada;
                            else if (_data.emitida.value && (_data.cstat.value != 100 && _data.cstat.value != 150))
                                ((Data.MovimentoFiscal)_base).status = ENum.eMovimentoFiscalStatus.rejeitada;
                            else if (_data.contingencia.value)
                                ((Data.MovimentoFiscal)_base).status = ENum.eMovimentoFiscalStatus.contingencia;
                        }
                        else
                        {
                            if (_data.cancelada.value)
                                ((Data.MovimentoFiscal)_base).status = ENum.eMovimentoFiscalStatus.cancelada;
                            else if (_data.emitida.value && (_data.cstat.value == 100 || _data.cstat.value == 150))
                                ((Data.MovimentoFiscal)_base).status = ENum.eMovimentoFiscalStatus.autorizada;
                            else if ((_data.cstat.value != 100 && _data.cstat.value != 150))
                                ((Data.MovimentoFiscal)_base).status = ENum.eMovimentoFiscalStatus.rejeitada;
                            else if (_data.contingencia.value)
                                ((Data.MovimentoFiscal)_base).status = ENum.eMovimentoFiscalStatus.contingencia;
                        }
                        List<Data.PdvCompraCupom> cupons = new List<Data.PdvCompraCupom>();
                        if (_data.pdvCompra.pdvCompraCupons != null)
                        {
                            foreach (Tables.PdvCompraCupom _pcc in _data.pdvCompra.pdvCompraCupons)
                            {
                                Data.PdvCompraCupom pcc = null;
                                try
                                {
                                    pcc = cupons.Where(T => T.idPdvCompraCupom == _pcc.idPdvCompraCupom.value).ToList()[0];
                                }
                                catch
                                {
                                    pcc = new Data.PdvCompraCupom
                                    {
                                        idPdvCompraCupom = _pcc.idPdvCompraCupom.value,
                                        data = _pcc.data.value,
                                        funcionario = new Data.Funcionario
                                        {
                                            idEmpresaRelacionamento = _pcc.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value
                                        },
                                        impresso = _pcc.impresso.value,
                                        pos = new Data.Pos
                                        {
                                            idPos = _pcc.pos.idPos.value,
                                        }
                                    };
                                    cupons.Add(pcc);
                                }
                                List<Data.PdvCompraCupomItem> itens = new List<Data.PdvCompraCupomItem>();
                                if (_pcc.pdvCompraCupomItem != null)
                                    foreach (Tables.PdvCompraCupomItem _pcci in _pcc.pdvCompraCupomItem)
                                    {
                                        Data.PdvCompraCupomItem pcci = null;
                                        try
                                        {
                                            pcci = itens.Where(T => T.idPdvCompraCupomItem == _pcci.idPdvCompraCupomItem.value).ToList()[0];
                                        }
                                        catch
                                        {
                                            pcci = new Data.PdvCompraCupomItem
                                            {
                                                idPdvCompraCupomItem = _pcci.idPdvCompraCupomItem.value,
                                                valor = _pcci.valor.value,
                                                quantidade = _pcci.quantidade.value,
                                                desconto = _pcci.desconto.value
                                            };
                                            itens.Add(pcci);
                                        }
                                    }

                                pcc.pdvCompraCupomItem = itens.ToArray();
                            }
                        }
                        ((Data.MovimentoFiscal)_base).pdvCompra.pdvCompraCupons = cupons.ToArray();
                        ((Data.MovimentoFiscal)_base).serie = _data.serie.value;
                        ((Data.MovimentoFiscal)_base).tipoDocumento = _data.tipoDocumento.value;
                        ((Data.MovimentoFiscal)_base).xmlEnvio = _data.xmlEnvio.value;
                        ((Data.MovimentoFiscal)_base).xmlRetorno = _data.xmlRetorno.value;
                        ((Data.MovimentoFiscal)_base).xMotivo = _data.xMotivo.value;
                    }
                    else
                        _base = (Data.MovimentoFiscal)this.preencher(new Data.MovimentoFiscal(), _data, level);

                    if (report != null)
                        report.ProcessRecord(_base);
                    else
                        result.Add(_base);
                    i++;
                }

                //if (report != null)
                //report.ProcessRecord(null);
                //else { }

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
