using System;

namespace WS.CRUD
{
    public class ExportacaoContabil : WS.CRUD.Base
    {
        public ExportacaoContabil(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ExportacaoContabil input = (Data.ExportacaoContabil)parametros["Key"];
            Tables.ExportacaoContabil bd = new Tables.ExportacaoContabil();

            bd.idExportacaoContabil.isNull = true;
            bd.codigoContabil.value = input.codigoContabil;
            bd.provisiona.value = input.provisiona;
            bd.tipoRetencao.value = input.tipoRetencao;

            if (input.naturezaOperacao != null && input.naturezaOperacao.idNaturezaOperacao > 0)
                bd.naturezaOperacao.idNaturezaOperacao.value = input.naturezaOperacao.idNaturezaOperacao;
            else { }

            if (input.departamento != null && input.departamento.idDepartamento > 0)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else { }

            if (input.empresaRelacionamento != null && input.empresaRelacionamento.idEmpresaRelacionamento > 0)
                bd.empresaRelacionamento.idEmpresaRelacionamento.value = input.empresaRelacionamento.idEmpresaRelacionamento;
            else
                bd.empresaRelacionamento.idEmpresaRelacionamento.isNull = true;

            if (input.contaPagamento != null && input.contaPagamento.idContaPagamento > 0)
                bd.contaPagamento.idContaPagamento.value = input.contaPagamento.idContaPagamento;
            else
                bd.contaPagamento.idContaPagamento.isNull = true;

            this.m_EntityManager.persist(bd);

            ((Data.ExportacaoContabil)parametros["Key"]).idExportacaoContabil = (int)bd.idExportacaoContabil.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ExportacaoContabil input = (Data.ExportacaoContabil)parametros["Key"];
            Tables.ExportacaoContabil bd = (Tables.ExportacaoContabil)this.m_EntityManager.find
            (
                typeof(Tables.ExportacaoContabil),
                new Object[]
                {
                    input.idExportacaoContabil
                }
            );

            bd.codigoContabil.value = input.codigoContabil;
            bd.provisiona.value = input.provisiona;
            bd.tipoRetencao.value = input.tipoRetencao;

            if (input.naturezaOperacao != null && input.naturezaOperacao.idNaturezaOperacao > 0)
                bd.naturezaOperacao.idNaturezaOperacao.value = input.naturezaOperacao.idNaturezaOperacao;
            else { }

            if (input.departamento != null && input.departamento.idDepartamento > 0)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else { }

            if (input.empresaRelacionamento != null && input.empresaRelacionamento.idEmpresaRelacionamento > 0)
                bd.empresaRelacionamento.idEmpresaRelacionamento.value = input.empresaRelacionamento.idEmpresaRelacionamento;
            else
                bd.empresaRelacionamento.idEmpresaRelacionamento.isNull = true;

            if (input.contaPagamento != null && input.contaPagamento.idContaPagamento > 0)
                bd.contaPagamento.idContaPagamento.value = input.contaPagamento.idContaPagamento;
            else
                bd.contaPagamento.idContaPagamento.isNull = true;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ExportacaoContabil bd = new Tables.ExportacaoContabil();

            bd.idExportacaoContabil.value = ((Data.ExportacaoContabil)parametros["Key"]).idExportacaoContabil;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ExportacaoContabil)bd).idExportacaoContabil.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ExportacaoContabil)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ExportacaoContabil)input).idExportacaoContabil = ((Tables.ExportacaoContabil)bd).idExportacaoContabil.value;
                    ((Data.ExportacaoContabil)input).codigoContabil = ((Tables.ExportacaoContabil)bd).codigoContabil.value;
                    ((Data.ExportacaoContabil)input).provisiona = ((Tables.ExportacaoContabil)bd).provisiona.value;
                    ((Data.ExportacaoContabil)input).tipoRetencao = ((Tables.ExportacaoContabil)bd).tipoRetencao.value;

                    if (((Data.ExportacaoContabil)input).provisiona == "s")
                        ((Data.ExportacaoContabil)input).provisionaBool = true;
                    else
                        ((Data.ExportacaoContabil)input).provisionaBool = false;

                    ((Data.ExportacaoContabil)input).naturezaOperacao = (Data.NaturezaOperacao)(new WS.CRUD.NaturezaOperacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.NaturezaOperacao(),
                        ((Tables.ExportacaoContabil)bd).naturezaOperacao,
                        level + 1
                    );
                    ((Data.ExportacaoContabil)input).departamento = (Data.Departamento)(new WS.CRUD.Departamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Departamento(),
                        ((Tables.ExportacaoContabil)bd).departamento,
                        level + 1
                    );
                    ((Data.ExportacaoContabil)input).empresaRelacionamento = (Data.EmpresaRelacionamento)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.EmpresaRelacionamento(),
                        ((Tables.ExportacaoContabil)bd).empresaRelacionamento,
                        level + 1
                    );
                    ((Data.ExportacaoContabil)input).contaPagamento = (Data.ContaPagamento)(new WS.CRUD.ContaPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContaPagamento(),
                        ((Tables.ExportacaoContabil)bd).contaPagamento,
                        level + 1
                    );
                    ((Data.ExportacaoContabil)input).idEmpresaRelacionamento = ((Data.ExportacaoContabil)input).empresaRelacionamento.idEmpresaRelacionamento;

                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.ExportacaoContabil result = (Data.ExportacaoContabil)parametros["Key"];

            try
            {
                result = (Data.ExportacaoContabil)this.preencher
                (
                    new Data.ExportacaoContabil(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ExportacaoContabil),
                        new Object[]
                        {
                            result.idExportacaoContabil
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

            Data.ExportacaoContabil _input = (Data.ExportacaoContabil)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                //sqlWhere = (sqlWhere.Contains("'") ? sqlWhere.Replace("'", "''") : sqlWhere);

                if (_input.idExportacaoContabil > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "exportacaoContabil.idExportacaoContabil = @idExportacaoContabil");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idExportacaoContabil", _input.idExportacaoContabil));
                    if (!sqlOrderBy.Contains("exportacaoContabil.idExportacaoContabil"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "exportacaoContabil.idExportacaoContabil");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.provisiona))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "exportacaoContabil.provisiona = @provisiona");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("provisiona", _input.provisiona));
                    if (!sqlOrderBy.Contains("exportacaoContabil.provisiona"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "exportacaoContabil.provisiona");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.tipoRetencao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "exportacaoContabil.tipoRetencao = @tipoRetencao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("tipoRetencao", _input.tipoRetencao));
                    if (!sqlOrderBy.Contains("exportacaoContabil.tipoRetencao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "exportacaoContabil.tipoRetencao");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.codigoContabil))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "exportacaoContabil.codigoContabil = @codigoContabil");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("codigoContabil", _input.codigoContabil));
                    if (!sqlOrderBy.Contains("exportacaoContabil.codigoContabil"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "exportacaoContabil.codigoContabil");
                    else { }
                }
                else { }

                if (_input.naturezaOperacao != null)
                {
                    if (_input.naturezaOperacao.idNaturezaOperacao > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "exportacaoContabil.idNaturezaOperacao = @idNaturezaOperacao");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idNaturezaOperacao", _input.naturezaOperacao.idNaturezaOperacao));
                        if (!sqlOrderBy.Contains("exportacaoContabil.idNaturezaOperacao"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "exportacaoContabil.idNaturezaOperacao");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.idEmpresaRelacionamento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "exportacaoContabil.idEmpresaRelacionamento = @idEmpresaRelacionamento2");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresaRelacionamento2", _input.idEmpresaRelacionamento));
                    if (!sqlOrderBy.Contains("exportacaoContabil.idEmpresaRelacionamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "exportacaoContabil.idEmpresaRelacionamento");
                    else { }
                }
                else { }

                if (_input.empresaRelacionamento != null)
                {
                    if (_input.empresaRelacionamento.idEmpresaRelacionamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "exportacaoContabil.idEmpresaRelacionamento = @idEmpresaRelacionamento");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresaRelacionamento", _input.empresaRelacionamento.idEmpresaRelacionamento));
                        if (!sqlOrderBy.Contains("exportacaoContabil.idEmpresaRelacionamento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "exportacaoContabil.idEmpresaRelacionamento");
                        else { }
                    }
                    else { }

                    if (_input.empresaRelacionamento.pessoa != null)
                    {
                        if (!String.IsNullOrEmpty(_input.empresaRelacionamento.pessoa.nomeRazaoSocial))
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.nomeRazaoSocial like @nomeRazaoSocial");
                            fieldKeys.Add(new EJB.TableBase.TFieldString("nomeRazaoSocial", "%" + _input.empresaRelacionamento.pessoa.nomeRazaoSocial + "%"));
                            if (!sqlOrderBy.Contains("pessoa.nomeRazaoSocial"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.nomeRazaoSocial");
                            else { }
                        }
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.contaPagamento != null)
                {
                    if (_input.contaPagamento.idContaPagamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "exportacaoContabil.idContaPagamento = @idContaPagamento");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContaPagamento", _input.contaPagamento.idContaPagamento));
                        if (!sqlOrderBy.Contains("exportacaoContabil.idContaPagamento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "exportacaoContabil.idContaPagamento");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.departamento != null)
                {
                    if (_input.departamento.idDepartamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "exportacaoContabil.idDepartamento = @idDepartamento");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamento", _input.departamento.idDepartamento));
                        if (!sqlOrderBy.Contains("exportacaoContabil.idDepartamento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "exportacaoContabil.idDepartamento");
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "exportacaoContabil.* ") +
                    "from\n " +
                    (
                        "   exportacaoContabil exportacaoContabil\n " +
                        "       left join naturezaOperacao naturezaOperacao\n " +
                        "           on	naturezaOperacao.idNaturezaOperacao = exportacaoContabil.idNaturezaOperacao\n " +
                        "       left join departamento departamento\n " +
                        "           on	departamento.idDepartamento = exportacaoContabil.idDepartamento\n " +
                        "       left join empresaRelacionamento empresaRelacionamento\n " +
                        "           on	empresaRelacionamento.idEmpresaRelacionamento = exportacaoContabil.idEmpresaRelacionamento\n " +
                        "       left join contaPagamento contaPagamento\n " +
                        "           on	contaPagamento.idContaPagamento = exportacaoContabil.idContaPagamento\n " +
                        "       left join pessoa pessoa\n " +
                        "           on	pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento\n "
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
            Data.ExportacaoContabil input = (Data.ExportacaoContabil)parametros["Key"];
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
                    typeof(Tables.ExportacaoContabil),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ExportacaoContabil _data in
                    (System.Collections.Generic.List<Tables.ExportacaoContabil>)this.m_EntityManager.list
                    (
                        typeof(Tables.ExportacaoContabil),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.ExportacaoContabil(), _data, level);

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
