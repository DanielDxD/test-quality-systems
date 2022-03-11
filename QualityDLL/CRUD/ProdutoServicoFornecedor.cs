using System;

namespace WS.CRUD
{
    public class ProdutoServicoFornecedor : WS.CRUD.Base
    {
        public ProdutoServicoFornecedor(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoFornecedor input = (Data.ProdutoServicoFornecedor)parametros["Key"];
            Tables.ProdutoServicoFornecedor bd = new Tables.ProdutoServicoFornecedor();

            bd.idProdutoServicoFornecedor.isNull = true;
            bd.idProdutoServico.value = input.idProdutoServico;
            if (input.fornecedor != null)
                if (input.fornecedor.idEmpresaRelacionamento > 0)
                    bd.fornecedor.fornecedorEmpresaRelacionamento.idEmpresaRelacionamento.value = input.fornecedor.idEmpresaRelacionamento;
                else { }
            else { }
            bd.prazoEntrega.value = input.prazoEntrega;
            bd.dataUltimaCompra.value = input.dataUltimaCompra;
            bd.custoUltimaCompra.value = input.custoUltimaCompra;
            bd.codigoNfe.value = input.codigoNfe;

            this.m_EntityManager.persist(bd);

            ((Data.ProdutoServicoFornecedor)parametros["Key"]).idProdutoServicoFornecedor = (int)bd.idProdutoServicoFornecedor.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoFornecedor input = (Data.ProdutoServicoFornecedor)parametros["Key"];
            Tables.ProdutoServicoFornecedor bd = (Tables.ProdutoServicoFornecedor)this.m_EntityManager.find
            (
                typeof(Tables.ProdutoServicoFornecedor),
                new Object[]
                {
                    input.idProdutoServicoFornecedor
                }
            );

            bd.idProdutoServico.value = input.idProdutoServico;
            if (input.fornecedor != null)
                if (input.fornecedor.idEmpresaRelacionamento > 0)
                    bd.fornecedor.fornecedorEmpresaRelacionamento.idEmpresaRelacionamento.value = input.fornecedor.idEmpresaRelacionamento;
                else { }
            else { }
            bd.prazoEntrega.value = input.prazoEntrega;
            bd.dataUltimaCompra.value = input.dataUltimaCompra;
            bd.custoUltimaCompra.value = input.custoUltimaCompra;
            bd.codigoNfe.value = input.codigoNfe;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ProdutoServicoFornecedor bd = new Tables.ProdutoServicoFornecedor();

            bd.idProdutoServicoFornecedor.value = ((Data.ProdutoServicoFornecedor)parametros["Key"]).idProdutoServicoFornecedor;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ProdutoServicoFornecedor)bd).idProdutoServicoFornecedor.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ProdutoServicoFornecedor)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ProdutoServicoFornecedor)input).idProdutoServicoFornecedor = ((Tables.ProdutoServicoFornecedor)bd).idProdutoServicoFornecedor.value;
                    ((Data.ProdutoServicoFornecedor)input).idProdutoServico = ((Tables.ProdutoServicoFornecedor)bd).idProdutoServico.value;
                    ((Data.ProdutoServicoFornecedor)input).fornecedor = (Data.Fornecedor)(new WS.CRUD.Fornecedor(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Fornecedor(),
                        ((Tables.ProdutoServicoFornecedor)bd).fornecedor,
                        level + 1
                    );
                    ((Data.ProdutoServicoFornecedor)input).codigoNfe = ((Tables.ProdutoServicoFornecedor)bd).codigoNfe.value;
                    ((Data.ProdutoServicoFornecedor)input).prazoEntrega = ((Tables.ProdutoServicoFornecedor)bd).prazoEntrega.value;
                    ((Data.ProdutoServicoFornecedor)input).dataUltimaCompra = ((Tables.ProdutoServicoFornecedor)bd).dataUltimaCompra.value;
                    ((Data.ProdutoServicoFornecedor)input).custoUltimaCompra = ((Tables.ProdutoServicoFornecedor)bd).custoUltimaCompra.value;
                    ((Data.ProdutoServicoFornecedor)input).produtoServico = (Data.ProdutoServico)(new WS.CRUD.ProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ProdutoServico(),
                        ((Tables.ProdutoServicoFornecedor)bd).produtoServico,
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
            Data.ProdutoServicoFornecedor result = (Data.ProdutoServicoFornecedor)parametros["Key"];

            try
            {
                result = (Data.ProdutoServicoFornecedor)this.preencher
                (
                    new Data.ProdutoServicoFornecedor(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ProdutoServicoFornecedor),
                        new Object[]
                        {
                            result.idProdutoServicoFornecedor
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

            Data.ProdutoServicoFornecedor _input = (Data.ProdutoServicoFornecedor)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                sqlWhere = "";

                if (_input.idProdutoServicoFornecedor > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoFornecedor.idProdutoServicoFornecedor = @idProdutoServicoFornecedor");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idProdutoServicoFornecedor", _input.idProdutoServicoFornecedor));
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoFornecedor.idProdutoServicoFornecedor");
                }
                else { }

                if (_input.idProdutoServico > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoFornecedor.idProdutoServico = @idProdutoServico");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idProdutoServico", _input.idProdutoServico));
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoFornecedor.idProdutoServico");
                }
                else { }

                if (_input.fornecedor != null)
                {
                    if (_input.fornecedor.idEmpresa > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "empresaRelacionamento.idEmpresa = @idEmpresa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.fornecedor.idEmpresa));
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamento.idEmpresa");
                    }
                    else { }

                    if (_input.fornecedor.idEmpresaRelacionamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "fornecedor.idFornecedor = @idFornecedor");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idFornecedor", _input.fornecedor.idEmpresaRelacionamento));
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "fornecedor.idFornecedor");
                    }
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.codigoNfe))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   produtoServicoEmpresa.codigoNfe = @codigoNfe");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("codigoNfe", _input.codigoNfe));
                    if (!sqlOrderBy.Contains("produtoServicoEmpresa.codigoNfe"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoEmpresa.codigoNfe");
                    else { }
                }
                else { }

                if (_input.produtoServico != null)
                {
                    if (!String.IsNullOrEmpty(_input.produtoServico.descricao))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   produtoServico.descricao COLLATE Latin1_General_CI_AI like @descricao COLLATE Latin1_General_CI_AI");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", "%" + _input.produtoServico.descricao + "%"));
                        if (!sqlOrderBy.Contains("produtoServico.descricao"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServico.descricao");
                        else { }
                    }
                    else { }

                    if (_input.produtoServico.idProdutoServico > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServico.idProdutoServico = @idProdutoServico2");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idProdutoServico2", _input.produtoServico.idProdutoServico));
                        if (!sqlOrderBy.Contains("produtoServico.idProdutoServico"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServico.idProdutoServico");
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                        "* " +
                    "from " +
                    (
                        "produtoServicoFornecedor produtoServicoFornecedor " +
                            "inner join fornecedor fornecedor " +
                                "on fornecedor.idFornecedor = produtoServicoFornecedor.idFornecedor " +
                            "inner join empresaRelacionamento empresaRelacionamento " +
                                "on	empresaRelacionamento.idEmpresaRelacionamento = fornecedor.idFornecedor " +
                            "inner join pessoa pessoa " +
                                "on	pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento " +
                            "inner join produtoServico produtoServico " +
                                "on produtoServico.idProdutoServico = produtoServicoFornecedor.idProdutoServico "
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
            Data.ProdutoServicoFornecedor input = (Data.ProdutoServicoFornecedor)parametros["Key"];
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
                    typeof(Tables.ProdutoServicoFornecedor),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ProdutoServicoFornecedor _data in
                    (System.Collections.Generic.List<Tables.ProdutoServicoFornecedor>)this.m_EntityManager.list
                    (
                        typeof(Tables.ProdutoServicoFornecedor),
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
                    _base = (Data.Base)this.preencher(new Data.ProdutoServicoFornecedor(), _data, level);

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
