using System;

namespace WS.CRUD
{
    public class ContasAReceberItem : WS.CRUD.Base
    {
        public ContasAReceberItem(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ContasAReceberItem input = (Data.ContasAReceberItem)parametros["Key"];
            Tables.ContasAReceberItem bd = new Tables.ContasAReceberItem();

            bd.idContasAReceberItem.isNull = true;
            if (input.idContasAReceber != null)
                bd.idContasAReceber.idContasAReceber.value = input.idContasAReceber.idContasAReceber;
            else { }
            if (input.idMovimento != null)
                bd.idMovimento.idMovimento.value = input.idMovimento.idMovimento;
            else { }
            if (input.idMovimentoManual != null)
                bd.idMovimentoManual.idMovimentoManual.value = input.idMovimentoManual.idMovimentoManual;
            else { }
            bd.descricao.value = input.descricao;
            bd.valor.value = input.valor;
            bd.aliquotaIss.value = input.aliquotaIss;
            bd.valorIss.value = input.valorIss;
            bd.aliquotaIcms.value = input.aliquotaIcms;
            bd.valorIcms.value = input.valorIcms;
            bd.valorDesconto.value = input.valorDesconto;
            if (input.idDepartamento > 0)
                bd.idDepartamento.value = input.idDepartamento;
            else
                bd.idDepartamento.isNull = true;
            if (input.idNaturezaOperacao > 0)
                bd.idNaturezaOperacao.value = input.idNaturezaOperacao;
            else
                bd.idNaturezaOperacao.isNull = true;
            if (input.departamento != null && input.departamento.idDepartamento > 0)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else { }

            if (input.pdvCompraCupomItem != null && input.pdvCompraCupomItem.idPdvCompraCupomItem > 0)
                bd.pdvCompraCupomItem.idPdvCompraCupomItem.value = input.pdvCompraCupomItem.idPdvCompraCupomItem;
            else
                bd.pdvCompraCupomItem.idPdvCompraCupomItem.isNull = true;

            this.m_EntityManager.persist(bd);

            ((Data.ContasAReceberItem)parametros["Key"]).idContasAReceberItem = (int)bd.idContasAReceberItem.value;

            return this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ContasAReceberItem input = (Data.ContasAReceberItem)parametros["Key"];
            Tables.ContasAReceberItem bd = (Tables.ContasAReceberItem)this.m_EntityManager.find
            (
                typeof(Tables.ContasAReceberItem),
                new Object[]
                {
                    input.idContasAReceberItem
                }
            );

            //bd.idContasAReceberItem.isNull = true;
            if (input.idContasAReceber != null)
                bd.idContasAReceber.idContasAReceber.value = input.idContasAReceber.idContasAReceber;
            else { }
            if (input.idMovimento != null && input.idMovimento.idMovimento > 0)
                bd.idMovimento.idMovimento.value = input.idMovimento.idMovimento;
            else
            {
                bd.idMovimento.idMovimento.isNull = true;
            }
            if (input.idMovimentoManual != null && input.idMovimentoManual.idMovimentoManual > 0)
                bd.idMovimentoManual.idMovimentoManual.value = input.idMovimentoManual.idMovimentoManual;
            else
            {
                bd.idMovimentoManual.idMovimentoManual.isNull = true;
            }

            bd.descricao.value = input.descricao;
            bd.valor.value = input.valor;
            bd.aliquotaIss.value = input.aliquotaIss;
            bd.valorIss.value = input.valorIss;
            bd.aliquotaIcms.value = input.aliquotaIcms;
            bd.valorIcms.value = input.valorIcms;
            bd.valorDesconto.value = input.valorDesconto;
            if (input.idDepartamento > 0)
                bd.idDepartamento.value = input.idDepartamento;
            else
                bd.idDepartamento.isNull = true;
            if (input.idNaturezaOperacao > 0)
                bd.idNaturezaOperacao.value = input.idNaturezaOperacao;
            else
                bd.idNaturezaOperacao.isNull = true;
            if (input.departamento != null && input.departamento.idDepartamento > 0)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else { }

            if (input.pdvCompraCupomItem != null && input.pdvCompraCupomItem.idPdvCompraCupomItem > 0)
                bd.pdvCompraCupomItem.idPdvCompraCupomItem.value = input.pdvCompraCupomItem.idPdvCompraCupomItem;
            else
                bd.pdvCompraCupomItem.idPdvCompraCupomItem.isNull = true;

            if (input.convite != null && input.convite.idConvite > 0)
                bd.convite.idConvite.value = input.convite.idConvite;
            else
                bd.convite.idConvite.isNull = true;

            this.m_EntityManager.merge(bd);

            return this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ContasAReceberItem bd = new Tables.ContasAReceberItem();

            bd.idContasAReceberItem.value = ((Data.ContasAReceberItem)parametros["Key"]).idContasAReceberItem;

            this.m_EntityManager.executeData(String.Format("DELETE FROM contasAReceberItemDesconto WHERE idContasAReceberItem = {0}", bd.idContasAReceberItem.value), null);

            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
                if
                (
                    !((Tables.ContasAReceberItem)bd).idContasAReceberItem.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ContasAReceberItem)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ContasAReceberItem)input).idContasAReceberItem = ((Tables.ContasAReceberItem)bd).idContasAReceberItem.value;
                    ((Data.ContasAReceberItem)input).idContasAReceber = (Data.ContasAReceber)(new WS.CRUD.ContasAReceber(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContasAReceber(),
                        ((Tables.ContasAReceberItem)bd).idContasAReceber,
                        level + 1
                    );
                    ((Data.ContasAReceberItem)input).idMovimento = (Data.Movimento)(new WS.CRUD.Movimento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Movimento(),
                        ((Tables.ContasAReceberItem)bd).idMovimento,
                        level + 1
                    );
                    ((Data.ContasAReceberItem)input).idMovimentoManual = (Data.MovimentoManual)(new WS.CRUD.MovimentoManual(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.MovimentoManual(),
                        ((Tables.ContasAReceberItem)bd).idMovimentoManual,
                        level + 1
                    );
                    ((Data.ContasAReceberItem)input).descricao = ((Tables.ContasAReceberItem)bd).descricao.value;
                    ((Data.ContasAReceberItem)input).valor = ((Tables.ContasAReceberItem)bd).valor.value;
                    ((Data.ContasAReceberItem)input).aliquotaIss = ((Tables.ContasAReceberItem)bd).aliquotaIss.value;
                    ((Data.ContasAReceberItem)input).valorIss = ((Tables.ContasAReceberItem)bd).valorIss.value;
                    ((Data.ContasAReceberItem)input).aliquotaIcms = ((Tables.ContasAReceberItem)bd).aliquotaIcms.value;
                    ((Data.ContasAReceberItem)input).valorIcms = ((Tables.ContasAReceberItem)bd).valorIcms.value;
                    ((Data.ContasAReceberItem)input).valorDesconto = ((Tables.ContasAReceberItem)bd).valorDesconto.value;
                    if (!((Tables.ContasAReceberItem)bd).idDepartamento.isNull)
                        ((Data.ContasAReceberItem)input).idDepartamento = ((Tables.ContasAReceberItem)bd).idDepartamento.value;
                    else { }
                    if (!((Tables.ContasAReceberItem)bd).idNaturezaOperacao.isNull)
                        ((Data.ContasAReceberItem)input).idNaturezaOperacao = ((Tables.ContasAReceberItem)bd).idNaturezaOperacao.value;
                    else { }

                    ((Data.ContasAReceberItem)input).departamento = (Data.Departamento)(new WS.CRUD.Departamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Departamento(),
                        ((Tables.ContasAReceberItem)bd).departamento,
                        level + 1
                    );

                    ((Data.ContasAReceberItem)input).convite = (Data.Convite)(new WS.CRUD.Convite(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Convite(),
                        ((Tables.ContasAReceberItem)bd).convite,
                        level + 1
                    );

                    ((Data.ContasAReceberItem)input).pdvCompraCupomItem = (Data.PdvCompraCupomItem)(new WS.CRUD.PdvCompraCupomItem(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PdvCompraCupomItem(),
                        ((Tables.ContasAReceberItem)bd).pdvCompraCupomItem,
                        level + 1
                    );
                }
                else { }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.ContasAReceberItem result = (Data.ContasAReceberItem)parametros["Key"];

            try
            {
                result = (Data.ContasAReceberItem)this.preencher
                (
                    new Data.ContasAReceberItem(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ContasAReceberItem),
                        new Object[]
                        {
                            result.idContasAReceberItem
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

            Data.ContasAReceberItem _input = (Data.ContasAReceberItem)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idContasAReceberItem > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAReceberItem.idContasAReceberItem = @idContasAReceberItem");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContasAReceberItem", _input.idContasAReceberItem));
                    if (!sqlOrderBy.Contains("contasAReceberItem.idContasAReceberItem"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAReceberItem.idContasAReceberItem");
                    else { }
                }
                else { }

                if (_input.idNaturezaOperacao > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAReceberItem.idNaturezaOperacao = @idNaturezaOperacao");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idNaturezaOperacao", _input.idNaturezaOperacao));
                    if (!sqlOrderBy.Contains("contasAReceberItem.idNaturezaOperacao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAReceberItem.idNaturezaOperacao");
                    else { }
                }
                else { }

                if (_input.idDepartamento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAReceberItem.idDepartamento = @idDepartamento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamento", _input.idDepartamento));
                    if (!sqlOrderBy.Contains("contasAReceberItem.idDepartamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAReceberItem.idDepartamento");
                    else { }
                }
                else { }

                if (_input.idContasAReceber != null)
                {



                    if (_input.idContasAReceber.idContasAReceber > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAReceberItem.idContasAReceber = @idContasAReceber");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContasAReceber", _input.idContasAReceber.idContasAReceber));
                        if (!sqlOrderBy.Contains("contasAReceberItem.idContasAReceber"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAReceberItem.idContasAReceber");
                        else { }
                    }
                    else { }

                    if (_input.idContasAReceber.empresaRelacionamento != null)
                    {
                        if (_input.idContasAReceber.empresaRelacionamento.idEmpresaRelacionamento > 0)
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAReceber.idEmpresaRelacionamento = @idEmpresaRelacionamento");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresaRelacionamento", _input.idContasAReceber.empresaRelacionamento.idEmpresaRelacionamento));
                            if (!sqlOrderBy.Contains("contasAReceber.idEmpresaRelacionamento"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAReceber.idEmpresaRelacionamento");
                            else { }
                        }
                    }

                    if (!String.IsNullOrEmpty(_input.idContasAReceber.emAberto))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAReceber.emAberto = @emAberto");
                        fieldKeys.Add(new EJB.TableBase.TFieldBoolean("emAberto", _input.idContasAReceber.emAberto == "s"));
                        if (!sqlOrderBy.Contains("contasAReceber.emAberto"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAReceber.emAberto");
                        else { }

                    }
                }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   contasAReceberItem.* " +
                    "from " +
                    (
                        "   contasAReceberItem contasAReceberItem " +
                        "       inner join contasAReceber contasAReceber " +
                        "           on	contasAReceber.idcontasAReceber = contasAReceberItem.idcontasAReceber " +
                        "       inner join empresaRelacionamento empresaRelacionamento " +
                        "           on	empresaRelacionamento.idEmpresaRelacionamento = contasAReceber.idEmpresaRelacionamento " +
                        "       left join departamento departamento " +
                        "           on departamento.idDepartamento = contasAReceberItem.idDepartamento " +
                        "       inner join pessoa pessoa " +
                        "           on	pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento " +
                        "       left join naturezaOperacao " +
                        "           on naturezaOperacao.idNaturezaOperacao = contasAReceberItem.idNaturezaOperacao "
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

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.ContasAReceberItem input = (Data.ContasAReceberItem)parametros["Key"];
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
                    typeof(Tables.ContasAReceberItem),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ContasAReceberItem _data in
                    (System.Collections.Generic.List<Tables.ContasAReceberItem>)this.m_EntityManager.list
                    (
                        typeof(Tables.ContasAReceberItem),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    if (mode == "Roll")
                    {
                        _base = new Data.ContasAReceberItem();
                        ((Data.ContasAReceberItem)_base).idContasAReceberItem = _data.idContasAReceberItem.value;
                        ((Data.ContasAReceberItem)_base).idContasAReceber = new Data.ContasAReceber
                        {
                            idContasAReceber = _data.idContasAReceber.idContasAReceber.value,
                            dataVencimento = _data.idContasAReceber.dataVencimento.value,
                            empresaRelacionamento = new Data.EmpresaRelacionamento
                            {
                                idEmpresaRelacionamento = _data.idContasAReceber.empresaRelacionamento.idEmpresaRelacionamento.value,
                                pessoa = new Data.Pessoa
                                {
                                    nomeRazaoSocial = _data.idContasAReceber.empresaRelacionamento.pessoaRelacionamento.nomeRazaoSocial.value,
                                    idPessoa = _data.idContasAReceber.empresaRelacionamento.pessoaRelacionamento.idPessoa.value
                                },
                            },
                            valor = _data.idContasAReceber.valor.value,
                            valorRecebido = _data.idContasAReceber.valorRecebido.value,
                            dataCancelamento = _data.idContasAReceber.dataCancelamento.value,
                            dataLancamento = _data.idContasAReceber.dataLancamento.value,
                            dataLancamentoEfetivo = _data.idContasAReceber.dataLancamentoEfetivo.value,
                            emAberto = _data.idContasAReceber.emAberto.value ? "s" : "n",
                            descricao = _data.idContasAReceber.descricao.value

                        };
                        ((Data.ContasAReceberItem)_base).descricao = _data.descricao.value;
                        ((Data.ContasAReceberItem)_base).valor = _data.valor.value;
                        ((Data.ContasAReceberItem)_base).valorDesconto = _data.valorDesconto.value;
                        ((Data.ContasAReceberItem)_base).idNaturezaOperacao = _data.idNaturezaOperacao.value;
                        if (!_data.pdvCompraCupomItem.idPdvCompraCupomItem.isNull)
                        {
                            ((Data.ContasAReceberItem)_base).pdvCompraCupomItem = new Data.PdvCompraCupomItem
                            {
                                idPdvCompraCupomItem = _data.pdvCompraCupomItem.idPdvCompraCupomItem.value,
                                quantidade = _data.pdvCompraCupomItem.quantidade.value,

                            };
                        }
                    }
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
                    else
                        _base = (Data.Base)this.preencher(new Data.ContasAReceberItem(), _data, level);

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
