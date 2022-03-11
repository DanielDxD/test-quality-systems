using System;

namespace WS.CRUD
{
    public class Cartao : WS.CRUD.Base
    {
        public Cartao(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Cartao input = (Data.Cartao)parametros["Key"];
            Tables.Cartao bd = new Tables.Cartao();

            bd.numeroCartao.value = input.numeroCartao;
            if (input.empresaRelacionamento != null)
                bd.empresaRelacionamento.idEmpresaRelacionamento.value = input.empresaRelacionamento.idEmpresaRelacionamento;
            else { }
            bd.dataEmissao.value = input.dataEmissao;
            bd.dataValidade.value = input.dataValidade;
            if (input.dataCancelamento.Ticks > 0)
                bd.dataCancelamento.value = input.dataCancelamento;
            else
                bd.dataCancelamento.isNull = true;

            bd.codigoBarras.value = input.codigoBarras;
            bd.numeroRFID.value = input.numeroRFID;
            bd.ativo.value = input.ativo;
            bd.idQuality.value = input.idQuality;

            this.m_EntityManager.persist(bd);
            ((Data.Cartao)parametros["Key"]).idCartao = (int)bd.idCartao.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Cartao input = (Data.Cartao)parametros["Key"];
            Tables.Cartao bd = (Tables.Cartao)this.m_EntityManager.find
            (
                typeof(Tables.Cartao),
                new Object[]
                {
                    input.idCartao
                }
            );

            bd.numeroCartao.value = input.numeroCartao;
            if (input.empresaRelacionamento != null)
                bd.empresaRelacionamento.idEmpresaRelacionamento.value = input.empresaRelacionamento.idEmpresaRelacionamento;
            else { }
            bd.dataEmissao.value = input.dataEmissao;
            bd.dataValidade.value = input.dataValidade;
            if (input.dataCancelamento.Ticks > 0)
                bd.dataCancelamento.value = input.dataCancelamento;
            else
                bd.dataCancelamento.isNull = true;

            bd.codigoBarras.value = input.codigoBarras;
            bd.numeroRFID.value = input.numeroRFID;
            bd.ativo.value = input.ativo;
            bd.idQuality.value = input.idQuality;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Cartao bd = new Tables.Cartao();

            bd.numeroRFID.value = ((Data.Cartao)parametros["Key"]).numeroRFID;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
                if
                (
                    !((Tables.Cartao)bd).idCartao.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Cartao)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Cartao)input).idCartao = ((Tables.Cartao)bd).idCartao.value;
                    ((Data.Cartao)input).numeroCartao = ((Tables.Cartao)bd).numeroCartao.value;
                    ((Data.Cartao)input).empresaRelacionamento = (Data.EmpresaRelacionamento)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.EmpresaRelacionamento(),
                        ((Tables.Cartao)bd).empresaRelacionamento,
                        level + 1
                    );
                    ((Data.Cartao)input).idQuality = ((Tables.Cartao)bd).idQuality.value;
                    ((Data.Cartao)input).dataCancelamento = ((Tables.Cartao)bd).dataCancelamento.value;
                    ((Data.Cartao)input).codigoBarras = ((Tables.Cartao)bd).codigoBarras.value;
                    ((Data.Cartao)input).numeroRFID = ((Tables.Cartao)bd).numeroRFID.value;
                    ((Data.Cartao)input).dataEmissao = ((Tables.Cartao)bd).dataEmissao.value;
                    ((Data.Cartao)input).dataValidade = ((Tables.Cartao)bd).dataValidade.value;
                    ((Data.Cartao)input).ativo = ((Tables.Cartao)bd).ativo.value;

                    if (((Data.Cartao)input).dataCancelamento.Ticks > 0)
                        ((Data.Cartao)input).cancelado = true;
                    else
                        ((Data.Cartao)input).cancelado = false;

                }
                else { }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.Cartao result = (Data.Cartao)parametros["Key"];

            try
            {
                result = (Data.Cartao)this.preencher
                (
                    new Data.Cartao(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Cartao),
                        new Object[]
                        {
                            result.idCartao
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

            Data.Cartao _input = (Data.Cartao)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                //sqlWhere = (sqlWhere.Contains("'") ? sqlWhere.Replace("'", "''") : sqlWhere);

                if (_input.idCartao > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "cartao.idCartao = @idCartao");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idCartao", _input.idCartao));
                    if (!sqlOrderBy.Contains("cartao.idCartao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "cartao.idCartao");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.numeroCartao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "cartao.numeroCartao = @numeroCartao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("numeroCartao", _input.numeroCartao));
                    if (!sqlOrderBy.Contains("cartao.numeroCartao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "cartao.numeroCartao");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.ativo))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "cartao.ativo = @ativo");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("ativo", _input.ativo));
                    if (!sqlOrderBy.Contains("cartao.ativo"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "cartao.ativo");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.idQuality))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "cartao.idQuality = @idQuality");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("idQuality", _input.idQuality));
                    if (!sqlOrderBy.Contains("cartao.idQuality"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "cartao.idQuality");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.codigoBarras))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "cartao.codigoBarras = @codigoBarras");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("codigoBarras", _input.codigoBarras));
                    if (!sqlOrderBy.Contains("cartao.codigoBarras"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "cartao.codigoBarras");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.numeroRFID))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "cartao.numeroRFID = @numeroRFID");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("numeroRFID", _input.numeroRFID));
                    if (!sqlOrderBy.Contains("cartao.numeroRFID"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "cartao.numeroRFID");
                    else { }
                }
                else { }

                if (_input.dataCancelamento.Ticks > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "CAST(cartao.dataCancelamento AS date) = @dataCancelamento");
                    fieldKeys.Add(new EJB.TableBase.TFieldDatetime("dataCancelamento", Convert.ToDateTime(_input.dataCancelamento.ToString("yyyy-MM-DD"))));
                    if (!sqlOrderBy.Contains("cartao.dataCancelamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "cartao.dataCancelamento");
                    else { }
                }
                else { }

                if (_input.empresaRelacionamento != null)
                {
                    if (_input.empresaRelacionamento.idEmpresa > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "empresaRelacionamento.idEmpresa = @idEmpresa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.empresaRelacionamento.idEmpresa));
                        if (!sqlOrderBy.Contains("empresaRelacionamento.idEmpresa"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamento.idEmpresa");
                        else { }
                    }
                    else { }

                    if (_input.empresaRelacionamento.idEmpresaRelacionamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "empresaRelacionamento.idempresaRelacionamento = @idempresaRelacionamento");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idempresaRelacionamento", _input.empresaRelacionamento.idEmpresaRelacionamento));
                        if (!sqlOrderBy.Contains("empresaRelacionamento.idempresaRelacionamento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamento.idempresaRelacionamento");
                        else { }
                    }
                    else { }

                    if (_input.empresaRelacionamento.pessoa != null)
                    {
                        if ((_input.empresaRelacionamento.pessoa != null) && (_input.empresaRelacionamento.pessoa.idPessoa > 0))
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.idPessoa = @idPessoa");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPessoa", _input.empresaRelacionamento.pessoa.idPessoa));
                            if (!sqlOrderBy.Contains("pessoa.idPessoa"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.idPessoa");
                            else { }
                        }
                        else { }

                        if ((_input.empresaRelacionamento.pessoa.cpfCnpj != null) && (_input.empresaRelacionamento.pessoa.cpfCnpj.Length > 0))
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.cpfCnpj like @cpfCnpj");
                            fieldKeys.Add(new EJB.TableBase.TFieldString("cpfCnpj", '%' + _input.empresaRelacionamento.pessoa.cpfCnpj + '%'));
                            if (!sqlOrderBy.Contains("pessoa.cpfCnpj"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.cpfCnpj");
                            else { }
                        }
                        else { }

                        if ((_input.empresaRelacionamento.pessoa.nomeRazaoSocial != null) && (_input.empresaRelacionamento.pessoa.nomeRazaoSocial.Length > 0))
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.nomeRazaoSocial COLLATE Latin1_General_CI_AI like @nomeRazaoSocial COLLATE Latin1_General_CI_AI");
                            fieldKeys.Add(new EJB.TableBase.TFieldString("nomeRazaoSocial", '%' + _input.empresaRelacionamento.pessoa.nomeRazaoSocial + '%'));
                            if (!sqlOrderBy.Contains("pessoa.nomeRazaoSocial"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.nomeRazaoSocial");
                            else { }
                        }
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "cartao.* ") +
                    "from " +
                    (
                        "   cartao cartao " +
                        "       inner join empresaRelacionamento empresaRelacionamento " +
                        "           on	empresaRelacionamento.idEmpresaRelacionamento = cartao.idEmpresaRelacionamento " +
                        "       inner join pessoa pessoa " +
                        "           on	pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento "
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
            Data.Cartao input = (Data.Cartao)parametros["Key"];
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
                    typeof(Tables.Cartao),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Cartao _data in
                    (System.Collections.Generic.List<Tables.Cartao>)this.m_EntityManager.list
                    (
                        typeof(Tables.Cartao),
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
                    _base = (Data.Base)this.preencher(new Data.Cartao(), _data, level);

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
