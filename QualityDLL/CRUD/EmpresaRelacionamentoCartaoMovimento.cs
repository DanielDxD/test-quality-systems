using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WS.CRUD
{
    public class EmpresaRelacionamentoCartaoMovimento : WS.CRUD.Base
    {
        public EmpresaRelacionamentoCartaoMovimento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.EmpresaRelacionamentoCartaoMovimento input = (Data.EmpresaRelacionamentoCartaoMovimento)parametros["Key"];
            Tables.EmpresaRelacionamentoCartaoMovimento bd = new Tables.EmpresaRelacionamentoCartaoMovimento();

            bd.idEmpresaRelacionamentoCartaoMovimento.isNull = true;
            if (input.empresaRelacionamentoCartao != null && input.empresaRelacionamentoCartao.idEmpresaRelacionamentoCartao > 0)
                bd.empresaRelacionamentoCartao.idEmpresaRelacionamentoCartao.value = input.empresaRelacionamentoCartao.idEmpresaRelacionamentoCartao;
            else
                bd.empresaRelacionamentoCartao.idEmpresaRelacionamentoCartao.isNull = true;

            if (input.contaPagamentoMovimento != null && input.contaPagamentoMovimento.idContaPagamentoMovimento > 0)
                bd.contaPagamentoMovimento.idContaPagamentoMovimento.value = input.contaPagamentoMovimento.idContaPagamentoMovimento;
            else
                bd.contaPagamentoMovimento.idContaPagamentoMovimento.isNull = true;

            if (input.pdvCompra != null && input.pdvCompra.idPdvCompra > 0)
                bd.pdvCompra.idPdvCompra.value = input.pdvCompra.idPdvCompra;
            else
                bd.pdvCompra.idPdvCompra.isNull = true;

            if (input.estornoDevolucao != null && input.estornoDevolucao.idEmpresaRelacionamentoCartaoMovimento > 0)
                bd.estornoDevolucao.idEmpresaRelacionamentoCartaoMovimento.value = input.estornoDevolucao.idEmpresaRelacionamentoCartaoMovimento;
            else
                bd.estornoDevolucao.idEmpresaRelacionamentoCartaoMovimento.isNull = true;

            if (input.pdvEstacao != null && input.pdvEstacao.idPdvEstacao > 0)
                bd.pdvEstacao.idPdvEstacao.value = input.pdvEstacao.idPdvEstacao;
            else
                bd.estornoDevolucao.idEmpresaRelacionamentoCartaoMovimento.isNull = true;

            if (input.contasAReceber != null && input.contasAReceber.idContasAReceber > 0)
                bd.contasAReceber.idContasAReceber.value = input.contasAReceber.idContasAReceber;
            else
                bd.contasAReceber.idContasAReceber.isNull = true;

            if (input.dataMovimento.Ticks > 0)
                bd.dataMovimento.value = input.dataMovimento;
            else
                bd.dataMovimento.isNull = true;

            bd.tipoMovimento.value = input.tipoMovimento;
            bd.tipoOperacao.value = input.tipoOperacao;
            bd.valorMovimento.value = input.valorMovimento;
            bd.valorDesconto.value = input.valorDesconto;

            this.m_EntityManager.persist(bd);

            ((Data.EmpresaRelacionamentoCartaoMovimento)parametros["Key"]).idEmpresaRelacionamentoCartaoMovimento = (int)bd.idEmpresaRelacionamentoCartaoMovimento.value;

            return input;
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.EmpresaRelacionamentoCartaoMovimento input = (Data.EmpresaRelacionamentoCartaoMovimento)parametros["Key"];
            Tables.EmpresaRelacionamentoCartaoMovimento bd = (Tables.EmpresaRelacionamentoCartaoMovimento)this.m_EntityManager.find
            (
                typeof(Tables.EmpresaRelacionamentoCartaoMovimento),
                new Object[]
                {
                    input.idEmpresaRelacionamentoCartaoMovimento
                }
            );

            if (input.empresaRelacionamentoCartao != null && input.empresaRelacionamentoCartao.idEmpresaRelacionamentoCartao > 0)
                bd.empresaRelacionamentoCartao.idEmpresaRelacionamentoCartao.value = input.empresaRelacionamentoCartao.idEmpresaRelacionamentoCartao;
            else
                bd.empresaRelacionamentoCartao.idEmpresaRelacionamentoCartao.isNull = true;

            if (input.contaPagamentoMovimento != null && input.contaPagamentoMovimento.idContaPagamentoMovimento > 0)
                bd.contaPagamentoMovimento.idContaPagamentoMovimento.value = input.contaPagamentoMovimento.idContaPagamentoMovimento;
            else
                bd.contaPagamentoMovimento.idContaPagamentoMovimento.isNull = true;

            if (input.pdvCompra != null && input.pdvCompra.idPdvCompra > 0)
                bd.pdvCompra.idPdvCompra.value = input.pdvCompra.idPdvCompra;
            else
                bd.pdvCompra.idPdvCompra.isNull = true;

            if (input.pdvEstacao != null && input.pdvEstacao.idPdvEstacao > 0)
                bd.pdvEstacao.idPdvEstacao.value = input.pdvEstacao.idPdvEstacao;
            else
                bd.estornoDevolucao.idEmpresaRelacionamentoCartaoMovimento.isNull = true;

            if (input.estornoDevolucao != null && input.estornoDevolucao.idEmpresaRelacionamentoCartaoMovimento > 0)
                bd.estornoDevolucao.idEmpresaRelacionamentoCartaoMovimento.value = input.estornoDevolucao.idEmpresaRelacionamentoCartaoMovimento;
            else
                bd.estornoDevolucao.idEmpresaRelacionamentoCartaoMovimento.isNull = true;

            if (input.contasAReceber != null && input.contasAReceber.idContasAReceber > 0)
                bd.contasAReceber.idContasAReceber.value = input.contasAReceber.idContasAReceber;
            else
                bd.contasAReceber.idContasAReceber.isNull = true;

            if (input.dataMovimento.Ticks > 0)
                bd.dataMovimento.value = input.dataMovimento;
            else
                bd.dataMovimento.isNull = true;

            bd.tipoMovimento.value = input.tipoMovimento;
            bd.tipoOperacao.value = input.tipoOperacao;
            bd.valorMovimento.value = input.valorMovimento;
            bd.valorDesconto.value = input.valorDesconto;

            this.m_EntityManager.merge(bd);

            return input;
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.EmpresaRelacionamentoCartaoMovimento bd = new Tables.EmpresaRelacionamentoCartaoMovimento();

            bd.idEmpresaRelacionamentoCartaoMovimento.value = ((Data.EmpresaRelacionamentoCartaoMovimento)parametros["Key"]).idEmpresaRelacionamentoCartaoMovimento;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.EmpresaRelacionamentoCartaoMovimento)bd).idEmpresaRelacionamentoCartaoMovimento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.EmpresaRelacionamentoCartaoMovimento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.EmpresaRelacionamentoCartaoMovimento)input).idEmpresaRelacionamentoCartaoMovimento = ((Tables.EmpresaRelacionamentoCartaoMovimento)bd).idEmpresaRelacionamentoCartaoMovimento.value;
                    ((Data.EmpresaRelacionamentoCartaoMovimento)input).empresaRelacionamentoCartao = (Data.EmpresaRelacionamentoCartao)(new WS.CRUD.EmpresaRelacionamentoCartao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.EmpresaRelacionamentoCartao(),
                        ((Tables.EmpresaRelacionamentoCartaoMovimento)bd).empresaRelacionamentoCartao,
                        level + 1
                    );

                    ((Data.EmpresaRelacionamentoCartaoMovimento)input).estornoDevolucao = (Data.EmpresaRelacionamentoCartaoMovimento)(new WS.CRUD.EmpresaRelacionamentoCartaoMovimento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.EmpresaRelacionamentoCartaoMovimento(),
                        ((Tables.EmpresaRelacionamentoCartaoMovimento)bd).estornoDevolucao,
                        level + 1
                    );

                    if (((Data.EmpresaRelacionamentoCartaoMovimento)input).estornoDevolucao != null && ((Data.EmpresaRelacionamentoCartaoMovimento)input).estornoDevolucao.idEmpresaRelacionamentoCartaoMovimento > 0)
                    {
                        ((Data.EmpresaRelacionamentoCartaoMovimento)input).flagEstornoDevolucao = true;
                        ((Data.EmpresaRelacionamentoCartaoMovimento)input).dataEstornoDevolucao = ((Data.EmpresaRelacionamentoCartaoMovimento)input).estornoDevolucao.dataMovimento;
                    }
                    else
                        ((Data.EmpresaRelacionamentoCartaoMovimento)input).flagEstornoDevolucao = false;

                    ((Data.EmpresaRelacionamentoCartaoMovimento)input).contaPagamentoMovimento = (Data.ContaPagamentoMovimento)(new WS.CRUD.ContaPagamentoMovimento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContaPagamentoMovimento(),
                        ((Tables.EmpresaRelacionamentoCartaoMovimento)bd).contaPagamentoMovimento,
                        level + 1
                    );

                    ((Data.EmpresaRelacionamentoCartaoMovimento)input).pdvCompra = (Data.PdvCompra)(new WS.CRUD.PdvCompra(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PdvCompra(),
                        ((Tables.EmpresaRelacionamentoCartaoMovimento)bd).pdvCompra,
                        level
                    );

                    ((Data.EmpresaRelacionamentoCartaoMovimento)input).contasAReceber = (Data.ContasAReceber)(new WS.CRUD.ContasAReceber(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContasAReceber(),
                        ((Tables.EmpresaRelacionamentoCartaoMovimento)bd).contasAReceber,
                        level + 1
                    );

                    ((Data.EmpresaRelacionamentoCartaoMovimento)input).pdvEstacao = (Data.PdvEstacao)(new WS.CRUD.PdvEstacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PdvEstacao(),
                        ((Tables.EmpresaRelacionamentoCartaoMovimento)bd).pdvEstacao,
                        level + 1
                    );

                    ((Data.EmpresaRelacionamentoCartaoMovimento)input).dataMovimento = ((Tables.EmpresaRelacionamentoCartaoMovimento)bd).dataMovimento.value;
                    ((Data.EmpresaRelacionamentoCartaoMovimento)input).valorMovimento = ((Tables.EmpresaRelacionamentoCartaoMovimento)bd).valorMovimento.value;
                    ((Data.EmpresaRelacionamentoCartaoMovimento)input).valorDesconto = ((Tables.EmpresaRelacionamentoCartaoMovimento)bd).valorDesconto.value;
                    ((Data.EmpresaRelacionamentoCartaoMovimento)input).tipoMovimento = ((Tables.EmpresaRelacionamentoCartaoMovimento)bd).tipoMovimento.value;
                    ((Data.EmpresaRelacionamentoCartaoMovimento)input).tipoOperacao = ((Tables.EmpresaRelacionamentoCartaoMovimento)bd).tipoOperacao.value;

                    if (((Data.EmpresaRelacionamentoCartaoMovimento)input).pdvCompra.pdvCompraTaxaServico != null)
                        try
                        {
                            ((Data.EmpresaRelacionamentoCartaoMovimento)input).valorTaxaServico = ((Data.EmpresaRelacionamentoCartaoMovimento)input).pdvCompra.pdvCompraTaxaServico.Sum(X => X.valor);
                        }
                        catch { }
                    else { }

                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.EmpresaRelacionamentoCartaoMovimento result = (Data.EmpresaRelacionamentoCartaoMovimento)parametros["Key"];

            try
            {
                result = (Data.EmpresaRelacionamentoCartaoMovimento)this.preencher
                (
                    new Data.EmpresaRelacionamentoCartaoMovimento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.EmpresaRelacionamentoCartaoMovimento),
                        new Object[]
                        {
                            result.idEmpresaRelacionamentoCartaoMovimento
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

            Data.EmpresaRelacionamentoCartaoMovimento _input = (Data.EmpresaRelacionamentoCartaoMovimento)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idEmpresaRelacionamentoCartaoMovimento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   empresaRelacionamentoCartaoMovimento.idEmpresaRelacionamentoCartaoMovimento = @idEmpresaRelacionamentoCartaoMovimento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresaRelacionamentoCartaoMovimento", _input.idEmpresaRelacionamentoCartaoMovimento));
                    if (!sqlOrderBy.Contains("empresaRelacionamentoCartaoMovimento.idEmpresaRelacionamentoCartaoMovimento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamentoCartaoMovimento.idEmpresaRelacionamentoCartaoMovimento");
                    else { }
                }
                else { }

                if (_input.empresaRelacionamentoCartao != null)
                {
                    if (_input.empresaRelacionamentoCartao.idEmpresaRelacionamentoCartao > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   empresaRelacionamentoCartaoMovimento.idEmpresaRelacionamentoCartao = @idEmpresaRelacionamentoCartao");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresaRelacionamentoCartao", _input.empresaRelacionamentoCartao.idEmpresaRelacionamentoCartao));
                        if (!sqlOrderBy.Contains("empresaRelacionamentoCartaoMovimento.idEmpresaRelacionamentoCartao"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamentoCartaoMovimento.idEmpresaRelacionamentoCartao");
                        else { }
                    }
                    else { }

                    if (_input.empresaRelacionamentoCartao.empresaRelacionamento != null)
                    {
                        if (_input.empresaRelacionamentoCartao.empresaRelacionamento.idEmpresaRelacionamento > 0)
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   empresaRelacionamento.idEmpresaRelacionamento = @idEmpresaRelacionamento");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresaRelacionamento", _input.empresaRelacionamentoCartao.empresaRelacionamento.idEmpresaRelacionamento));
                            if (!sqlOrderBy.Contains("empresaRelacionamento.idEmpresaRelacionamento"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamento.idEmpresaRelacionamento");
                            else { }
                        }
                        else { }

                        if (_input.empresaRelacionamentoCartao.empresaRelacionamento.pessoa != null)
                        {
                            if (!String.IsNullOrEmpty(_input.empresaRelacionamentoCartao.empresaRelacionamento.pessoa.nomeRazaoSocial))
                            {
                                sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   pessoa.nomeRazaoSocial like @nomeRazaoSocial");
                                fieldKeys.Add(new EJB.TableBase.TFieldString("nomeRazaoSocial", '%' + _input.empresaRelacionamentoCartao.empresaRelacionamento.pessoa.nomeRazaoSocial + '%'));
                                if (!sqlOrderBy.Contains("pessoa.nomeRazaoSocial"))
                                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.nomeRazaoSocial");
                                else { }
                            }
                            else { }

                        }
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.pdvCompra != null)
                {
                    if (_input.pdvCompra.idPdvCompra > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   empresaRelacionamentoCartaoMovimento.idPdvCompra = @idPdvCompra");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvCompra", _input.pdvCompra.idPdvCompra));
                        if (!sqlOrderBy.Contains("empresaRelacionamentoCartaoMovimento.idPdvCompra"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamentoCartaoMovimento.idPdvCompra");
                        else { }
                    }
                    else { }


                    if (_input.pdvCompra.pdvEstacao != null)
                    {
                        if (_input.pdvCompra.pdvEstacao.idPdvEstacao > 0)
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   empresaRelacionamentoCartaoMovimento.idPdvEstacao = @idPdvEstacaoPdvCompra");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacaoPdvCompra", _input.pdvCompra.pdvEstacao.idPdvEstacao));
                            if (!sqlOrderBy.Contains("empresaRelacionamentoCartaoMovimento.idPdvEstacao"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamentoCartaoMovimento.idPdvEstacao");
                            else { }
                        }
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.pdvEstacao != null)
                {
                    if (_input.pdvEstacao.idPdvEstacao > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   empresaRelacionamentoCartaoMovimento.idPdvEstacao = @idPdvEstacao");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacao", _input.pdvEstacao.idPdvEstacao));
                        if (!sqlOrderBy.Contains("empresaRelacionamentoCartaoMovimento.idPdvEstacao"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamentoCartaoMovimento.idPdvEstacao");
                        else { }
                    }
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.tipoMovimento))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   empresaRelacionamentoCartaoMovimento.tipoMovimento = @tipoMovimento");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("tipoMovimento", _input.tipoMovimento));
                    if (!sqlOrderBy.Contains("empresaRelacionamentoCartaoMovimento.tipoMovimento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamentoCartaoMovimento.tipoMovimento");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.tipoOperacao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   empresaRelacionamentoCartaoMovimento.tipoOperacao = @tipoOperacao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("tipoOperacao", _input.tipoOperacao));
                    if (!sqlOrderBy.Contains("empresaRelacionamentoCartaoMovimento.tipoOperacao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamentoCartaoMovimento.tipoOperacao");
                    else { }
                }
                else { }

                if (_input.dataMovimento.Ticks > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   empresaRelacionamentoCartaoMovimento.dataMovimento = @dataMovimento");
                    fieldKeys.Add(new EJB.TableBase.TFieldDatetime("dataMovimento", _input.dataMovimento));
                    if (!sqlOrderBy.Contains("empresaRelacionamentoCartaoMovimento.dataMovimento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamentoCartaoMovimento.dataMovimento");
                    else { }
                }
                else { }

                if (_input.contaPagamentoMovimento != null)
                {
                    if (_input.contaPagamentoMovimento.idContaPagamentoMovimento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   empresaRelacionamentoCartaoMovimento.idContaPagamentoMovimento = @idContaPagamentoMovimento");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContaPagamentoMovimento", _input.contaPagamentoMovimento.idContaPagamentoMovimento));
                        if (!sqlOrderBy.Contains("empresaRelacionamentoCartaoMovimento.idContaPagamentoMovimento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamentoCartaoMovimento.idContaPagamentoMovimento");
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "empresaRelacionamentoCartaoMovimento.* ") +
                    "from\n " +
                    (
                        "empresaRelacionamentoCartaoMovimento empresaRelacionamentoCartaoMovimento\n " +
                        "	inner join empresaRelacionamentoCartao empresaRelacionamentoCartao\n " +
                        "       on	empresaRelacionamentoCartao.idempresaRelacionamentoCartao = empresaRelacionamentoCartaoMovimento.idempresaRelacionamentoCartao\n " +
                        "   inner join	empresaRelacionamento empresaRelacionamento\n " +
                        "       on	empresaRelacionamento.idEmpresaRelacionamento = empresaRelacionamentoCartao.idempresaRelacionamento\n " +
                        "   inner join pessoa pessoa\n " +
                        "       on	pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento\n " +
                        "   left join pdvCompra pdvCompra\n " +
                        "       on pdvCompra.idPdvCompra = empresaRelacionamentoCartaoMovimento.idPdvCompra\n " +
                        "   left join contaPagamentoMovimento contaPagamentoMovimento\n " +
                        "       on contaPagamentoMovimento.idContaPagamentoMovimento = empresaRelacionamentoCartaoMovimento.idContaPagamentoMovimento\n " +
                        "   left join contasAReceber contasAReceber\n " +
                        "       on contasAReceber.idcontasAReceber = empresaRelacionamentoCartaoMovimento.idcontasAReceber\n " +
                        "   left join pdvEstacoes pdvEstacoes\n " +
                        "       on pdvEstacoes.idPdvEstacao = empresaRelacionamentoCartaoMovimento.idPdvEstacao\n "
                    ) +
                    (sqlWhere.Length > 0 ? "where " + sqlWhere : "") + "\n" +
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
            Data.EmpresaRelacionamentoCartaoMovimento input = (Data.EmpresaRelacionamentoCartaoMovimento)parametros["Key"];
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
                    typeof(Tables.EmpresaRelacionamentoCartaoMovimento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.EmpresaRelacionamentoCartaoMovimento _data in
                    (System.Collections.Generic.List<Tables.EmpresaRelacionamentoCartaoMovimento>)this.m_EntityManager.list
                    (
                        typeof(Tables.EmpresaRelacionamentoCartaoMovimento),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.EmpresaRelacionamentoCartaoMovimento();
                        ((Data.EmpresaRelacionamentoCartaoMovimento)_base).idEmpresaRelacionamentoCartaoMovimento = _data.idEmpresaRelacionamentoCartaoMovimento.value;
                        ((Data.EmpresaRelacionamentoCartaoMovimento)_base).empresaRelacionamentoCartao = new Data.EmpresaRelacionamentoCartao { idEmpresaRelacionamentoCartao = _data.empresaRelacionamentoCartao.idEmpresaRelacionamentoCartao.value };
                        ((Data.EmpresaRelacionamentoCartaoMovimento)_base).contaPagamentoMovimento = new Data.ContaPagamentoMovimento { idContaPagamentoMovimento = _data.contaPagamentoMovimento.idContaPagamentoMovimento.value };
                        ((Data.EmpresaRelacionamentoCartaoMovimento)_base).tipoMovimento = _data.tipoMovimento.value;
                        ((Data.EmpresaRelacionamentoCartaoMovimento)_base).tipoOperacao = _data.tipoOperacao.value;
                        ((Data.EmpresaRelacionamentoCartaoMovimento)_base).pdvCompra = new Data.PdvCompra { idPdvCompra = _data.pdvCompra.idPdvCompra.value };
                        ((Data.EmpresaRelacionamentoCartaoMovimento)_base).valorMovimento = _data.valorMovimento.value;
                        ((Data.EmpresaRelacionamentoCartaoMovimento)_base).valorDesconto = _data.valorDesconto.value;
                        ((Data.EmpresaRelacionamentoCartaoMovimento)_base).dataMovimento = _data.dataMovimento.value;
                        ((Data.EmpresaRelacionamentoCartaoMovimento)_base).contasAReceber = new Data.ContasAReceber { idContasAReceber = _data.contasAReceber.idContasAReceber.value };
                        ((Data.EmpresaRelacionamentoCartaoMovimento)_base).estornoDevolucao = new Data.EmpresaRelacionamentoCartaoMovimento { idEmpresaRelacionamentoCartaoMovimento = _data.estornoDevolucao.idEmpresaRelacionamentoCartaoMovimento.value };
                        ((Data.EmpresaRelacionamentoCartaoMovimento)_base).pdvEstacao = new Data.PdvEstacao { idPdvEstacao = _data.pdvEstacao.idPdvEstacao.value };

                        if (((Data.EmpresaRelacionamentoCartaoMovimento)_base).estornoDevolucao != null && ((Data.EmpresaRelacionamentoCartaoMovimento)_base).estornoDevolucao.idEmpresaRelacionamentoCartaoMovimento > 0)
                        {
                            ((Data.EmpresaRelacionamentoCartaoMovimento)_base).flagEstornoDevolucao = true;
                            ((Data.EmpresaRelacionamentoCartaoMovimento)_base).dataEstornoDevolucao = ((Data.EmpresaRelacionamentoCartaoMovimento)_base).estornoDevolucao.dataMovimento;
                        }
                        else
                            ((Data.EmpresaRelacionamentoCartaoMovimento)_base).flagEstornoDevolucao = false;

                        if (_data.pdvCompra.pdvCompraTaxaServico != null)
                        {
                            System.Collections.Generic.List<Data.PdvCompraTaxaServico> _list = new System.Collections.Generic.List<Data.PdvCompraTaxaServico>();

                            foreach (Tables.PdvCompraTaxaServico _item in _data.pdvCompra.pdvCompraTaxaServico)
                            {
                                _list.Add
                                (
                                    (Data.PdvCompraTaxaServico)
                                    (new WS.CRUD.PdvCompraTaxaServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.PdvCompraTaxaServico(),
                                        _item,
                                        level + 1
                                    )
                                );
                            }

                            if (_list.Count > 0)
                                ((Data.EmpresaRelacionamentoCartaoMovimento)_base).pdvCompra.pdvCompraTaxaServico = _list.ToArray();
                            else { }

                            _list.Clear();
                            _list = null;
                        }

                        try
                        {
                            ((Data.EmpresaRelacionamentoCartaoMovimento)_base).valorTaxaServico = ((Data.EmpresaRelacionamentoCartaoMovimento)_base).pdvCompra.pdvCompraTaxaServico.Sum(X => X.valor);
                        }
                        catch
                        {
                        }
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.EmpresaRelacionamentoCartaoMovimento(), _data, level);

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
