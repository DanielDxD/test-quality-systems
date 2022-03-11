using System;

namespace WS.CRUD
{
    public class PlanoContasSaldo : WS.CRUD.Base
    {
        public PlanoContasSaldo(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PlanoContasSaldo input = (Data.PlanoContasSaldo)parametros["Key"];
            Tables.PlanoContasSaldo bd = new Tables.PlanoContasSaldo();

            bd.idPlanoContasSaldo.isNull = true;
            if (input.planoContas != null)
                bd.planoContas.idPlanoContas.value = input.planoContas.idPlanoContas;
            else { }
            bd.anoMes.value = input.anoMes;
            bd.saldo.value = input.saldo;

            this.m_EntityManager.persist(bd);

            ((Data.PlanoContasSaldo)parametros["Key"]).idPlanoContasSaldo = (int)bd.idPlanoContasSaldo.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PlanoContasSaldo input = (Data.PlanoContasSaldo)parametros["Key"];
            Tables.PlanoContasSaldo bd = (Tables.PlanoContasSaldo)this.m_EntityManager.find
            (
                typeof(Tables.PlanoContasSaldo),
                new Object[]
                {
                    input.idPlanoContasSaldo
                }
            );

            if (input.planoContas != null)
                bd.planoContas.idPlanoContas.value = input.planoContas.idPlanoContas;
            else { }
            bd.anoMes.value = input.anoMes;
            bd.saldo.value = input.saldo;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PlanoContasSaldo bd = new Tables.PlanoContasSaldo();

            bd.idPlanoContasSaldo.value = ((Data.PlanoContasSaldo)parametros["Key"]).idPlanoContasSaldo;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PlanoContasSaldo)bd).idPlanoContasSaldo.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PlanoContasSaldo)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PlanoContasSaldo)input).idPlanoContasSaldo = ((Tables.PlanoContasSaldo)bd).idPlanoContasSaldo.value;
                    ((Data.PlanoContasSaldo)input).planoContas = (Data.PlanoContas)(new WS.CRUD.PlanoContas(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PlanoContas(),
                        ((Tables.PlanoContasSaldo)bd).planoContas,
                        level + 1
                    );
                    ((Data.PlanoContasSaldo)input).anoMes = ((Tables.PlanoContasSaldo)bd).anoMes.value;
                    ((Data.PlanoContasSaldo)input).saldo = ((Tables.PlanoContasSaldo)bd).saldo.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PlanoContasSaldo result = (Data.PlanoContasSaldo)parametros["Key"];

            try
            {
                result = (Data.PlanoContasSaldo)this.preencher
                (
                    new Data.PlanoContasSaldo(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.PlanoContasSaldo),
                        new Object[]
                        {
                            result.idPlanoContasSaldo
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

            bool
                consolidate = false;

            DateTime?
                _startDate = null,
                _endDate = null;

            if (_params != null)
            {
                if (_params.Contains("additionalParameterNames"))
                {
                    foreach (String apName in _params["additionalParameterNames"].ToString().Split(','))
                    {
                        if (apName.ToLower().Contains("anomes"))
                        {
                            String[] dates = _params["additionalParameter_" + apName].ToString().Split('-');

                            for (int i = 0; i < dates.Length; i++)
                            {
                                dates[i] = dates[i].Trim();

                                if(dates[i].Length > 5){
                                    switch (i)
                                    {
                                        case 0:
                                            _startDate = Utils.Utils.ToDate(dates[i]);
                                            _endDate = _startDate;
                                            break;

                                        default:
                                            _endDate = Utils.Utils.ToDate(dates[i]);
                                            break;
                                    }
                                }
                                else { }
                            }
                        }
                    }

                    _params.Contains("additionalParameterNames").ToString();
                }
                else { }

                if (_params.ContainsKey("Consolidate"))
                    consolidate = (bool)_params["Consolidate"];
                else { }

                if (_params.ContainsKey("numRows"))
                    numRows = (int)_params["numRows"];
                else { }

                if (_params.ContainsKey("offSet"))
                    offSet = (int)_params["offSet"];
                else { }

                if (_params.ContainsKey("where"))
                    sqlWhere = ((String)_params["where"] ?? "").Replace("planoContasSaldo", "planoContas");
                else { }

                if (_params.ContainsKey("orderBy"))
                    sqlOrderBy = ((String)_params["orderBy"] ?? "");
                else { }
            }
            else { }

            Data.PlanoContasSaldo _input = (Data.PlanoContasSaldo)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.anoMes > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "planoContas.anoMes = @anoMes");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("anoMes", _input.anoMes));
                    if (!sqlOrderBy.Contains("planoContas.anoMes"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "planoContas.anoMes");
                    else { }
                }
                else { }

                if (_input.planoContas != null)
                {
                    if (_input.planoContas.idEmpresa > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "planocontas.idEmpresa = @idEmpresa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.planoContas.idEmpresa));
                        if (!sqlOrderBy.Contains("planoContas.idEmpresa"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "planoContas.idEmpresa");
                        else { }
                    }
                    else { }

                    if ((_input.planoContas.codigoContabil != null) && (_input.planoContas.codigoContabil.Length > 0))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "planoContas.codigoContabil like @codigoContabil");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("codigoContabil", _input.planoContas.codigoContabil + '%'));
                        if (!sqlOrderBy.Contains("planoContas.codigoContabil"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "planoContas.codigoContabil");
                        else { }
                    }
                    else { }

                    if ((_input.planoContas.descricao != null) && (_input.planoContas.descricao.Length > 0))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "planoContas.descricao like @descricao");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.planoContas.descricao + '%'));
                        if (!sqlOrderBy.Contains("planoContas.descricao"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "planoContas.descricao");
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    @"
                    begin
	                    declare
		                    @codigoContabil varchar(40),
		                    @codigoContabilSaldo varchar(40),
		                    @valor decimal(15, 2),
		                    @bLoop bit = 1,
		                    @ano_Mes int = 0

                        create table #saldo(anoMes int, codigoContabil varchar(40), valor decimal(15, 2))

                        insert into #saldo
                        select
	                        (
		                        (DATEPART(YEAR, contasAPagar.dataVencimento) * 100) +
		                        DATEPART(MONTH, contasAPagar.dataVencimento)
	                        ) anoMes,
                            planoContas.codigoContabil,
                            sum
                            (
                                (
                                    IsNull(contasAPagarItem.valor, 0.0) -
	                                IsNull(contasAPagarItem.valorDesconto, 0.0)
                                ) * (-1)
                            ) valor
                        from
                            contasAPagarItem
		                        inner join contasAPagar
			                        on	contasAPagar.idContasAPagar = contasAPagarItem.idContasAPagar and
										contasAPagar.idEmpresa = @idEmpresa and
										contasAPagar.dataCancelamento is null
                                inner join naturezaOperacao
                                    on	naturezaOperacao.idNaturezaOperacao = contasAPagarItem.idNaturezaOperacao and
										naturezaOperacao.idEmpresa = contasAPagar.idEmpresa
                                inner join planoContas
                                    on	planoContas.codigoContabilReduzido = naturezaOperacao.codigoContabilReduzido and
										planoContas.idEmpresa = naturezaOperacao.idEmpresa
                        group by
	                        DATEPART(YEAR, contasAPagar.dataVencimento),
	                        DATEPART(MONTH, contasAPagar.dataVencimento),
                            planoContas.codigoContabil

                        insert into #saldo
                        select
	                        (
		                        (DATEPART(YEAR, contasAReceber.dataVencimento) * 100) +
		                        DATEPART(MONTH, contasAReceber.dataVencimento)
	                        ) anoMes,
                            planoContas.codigoContabil,
                            sum
                            (
	                            IsNull(contasAReceberItem.valor, 0.0) +
	                            IsNull(contasAReceberItem.valorMulta, 0.0) +
	                            IsNull(contasAReceberItem.valorJuros, 0.0) +
	                            IsNull(contasAReceberItem.valorCm, 0.0) -
	                            IsNull(contasAReceberItem.valorDesconto, 0.0)
                            ) valor
                        from
                            contasAReceberItem
		                        inner join contasAReceber
			                        on	contasAReceber.idContasAReceber = contasAReceberItem.idContasAReceber and
										contasAReceber.idEmpresa = @idEmpresa and
										contasAReceber.dataCancelamento is null
                                inner join naturezaOperacao
                                    on	naturezaOperacao.idNaturezaOperacao = contasAReceberItem.idNaturezaOperacao and
										naturezaOperacao.idEmpresa = contasAReceber.idEmpresa
                                inner join planoContas
                                    on	planoContas.codigoContabilReduzido = naturezaOperacao.codigoContabilReduzido and
										planoContas.idEmpresa = naturezaOperacao.idEmpresa
                        group by
	                        DATEPART(YEAR, contasAReceber.dataVencimento),
	                        DATEPART(MONTH, contasAReceber.dataVencimento),
                            planoContas.codigoContabil
	
	                    declare curMov cursor for
		                    select
                                anoMes,
			                    codigoContabil,
			                    abs(sum(valor)) valor
		                    from
                                #saldo
		                    group by
                                anoMes,
			                    codigoContabil
		
	                    create table #planoContasSaldo
	                    (
                            anoMes int,
		                    codigoContabil varchar(40),
		                    valor decimal(15, 2)
	                    )
		
	                    open curMov
	
	                    while @bLoop = 1
		                    begin
			                    fetch curMov into @ano_Mes, @codigoContabil, @valor
			
			                    if @@FETCH_STATUS = 0
				                    begin
					                    set @codigoContabilSaldo = ''
					
					                    while(LEN(@codigoContabil) > 0)
						                    begin
							                    if(SUBSTRING(@codigoContabil, 1, 1) = '.')
								                    insert into #planoContasSaldo values(@ano_Mes, @codigoContabilSaldo, @valor)
							                    --else
							
							                    set @codigoContabilSaldo = @codigoContabilSaldo + SUBSTRING(@codigoContabil, 1, 1)

							                    if(LEN(@codigoContabil) > 1)							
								                    set @codigoContabil = SUBSTRING(@codigoContabil, 2, LEN(@codigoContabil))
							                    else
								                    set @codigoContabil = ''
						                    end

								        insert into #planoContasSaldo values(@ano_Mes, @codigoContabilSaldo, @valor)
				                    end
			                    else
				                    set @bLoop = 0
		                    end
		
	                    close curMov
	                    deallocate curMov

	                    " +
                        (
                            consolidate ?
                            @"select
                                codigoContabil,
                                idPlanoContasSaldo,
                                idPlanoContas,
                                ((anomes / 100) * 100) anomes,
                                sum(IsNull(saldo, 0.0)) saldo
                            from
                            (" :
                            ""
                        ) +
                        @"select" + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") + @"
                            planoContas.codigoContabil,
		                    planoContas.idPlanoContas idPlanoContasSaldo,
		                    planoContas.idPlanoContas idPlanoContas,
		                    planoContas.anoMes,
		                    planoContasSaldo.valor saldo
	                    from
		                    (
			                    select
				                    planoContas.*,
				                    saldo.anomes
			                    from
				                    planoContas,
				                    (
					                    select distinct anoMes from #saldo" + (_input.anoMes > 0 ? " union select @ano_mes where @ano_Mes > 0" : "") + @"
				                    ) saldo
		                    ) planoContas
                                left join
				                    (
					                    select
                                            anoMes,
						                    codigoContabil,
						                    SUM(valor) valor
					                    from
						                    #planoContasSaldo
					                    group by
                                            anoMes,
						                    codigoContabil
				                    ) planoContasSaldo
				                    on	planoContasSaldo.anoMes = planoContas.anoMes and
                                        planoContasSaldo.codigoContabil COLLATE Latin1_General_CI_AS = planoContas.codigoContabil COLLATE Latin1_General_CI_AS
                        " +
                        (sqlWhere.Length > 0 ? " where " + sqlWhere : "") + 
                        (
                            consolidate ?
                        @") c
                        group by
                            codigoContabil,
                            idPlanoContasSaldo,
                            idPlanoContas,
                            ((anomes / 100) * 100)
                        order by
                            codigoContabil,
                            idPlanoContasSaldo,
                            idPlanoContas,
                            ((anomes / 100) * 100)" :
                        @"
                        order by
                            planoContas.idEmpresa,
                            planoContas.anoMes,
                            planoContas.codigoContabil
                        ") + (((numRows > 0) && (offSet >= 0)) ? " offset " + offSet + " rows fetch next " + numRows + " rows only" : "") + @"
	
                        drop table #saldo
                        drop table #planoContasSaldo
                    end
                    "
                );

                table = null;
            }
            else { }

            return result;
        }

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.PlanoContasSaldo input = (Data.PlanoContasSaldo)parametros["Key"];
            System.Collections.Generic.List<Data.Base> result = new System.Collections.Generic.List<Data.Base>();
            string mode = (string)(parametros["Mode"] == null ? "" : parametros["Mode"]);
            int level = (int)(parametros["Level"] == null ? 0 : parametros["Level"]);

            System.Collections.Hashtable makeSelectParams = new System.Collections.Hashtable();
            makeSelectParams["numRows"] = (parametros["Top"] == null ? 0 : (int)parametros["Top"]);
            makeSelectParams["where"] = (parametros["Filter"] == null ? "" : (String)parametros["Filter"]);
            makeSelectParams["orderBy"] = (parametros["Order"] == null ? "" : (String)parametros["Order"]);
            makeSelectParams["offSet"] = (parametros["Offset"] == null ? -1 : parametros["Offset"]);
            makeSelectParams["Consolidate"] = (parametros["Consolidate"] == null ? false : parametros["Consolidate"]);

            if (parametros.Contains("additionalParameterNames"))
            {
                makeSelectParams["additionalParameterNames"] = parametros["additionalParameterNames"];

                foreach(String apName in parametros["additionalParameterNames"].ToString().Split(',')){
                    makeSelectParams["additionalParameter_" + apName] = parametros["additionalParameter_" + apName];
                }
            }
            else { }

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
                    typeof(Tables.PlanoContasSaldo),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.PlanoContasSaldo _data in
                    (System.Collections.Generic.List<Tables.PlanoContasSaldo>)this.m_EntityManager.list
                    (
                        typeof(Tables.PlanoContasSaldo),
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
                    _base = (Data.Base)this.preencher(new Data.PlanoContasSaldo(), _data, level);

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
