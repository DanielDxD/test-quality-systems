using System;

namespace WS.CRUD
{
    public class ProdutoServicoEstoque : WS.CRUD.Base
    {
        public ProdutoServicoEstoque(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoEstoque input = (Data.ProdutoServicoEstoque)parametros["Key"];
            Tables.ProdutoServicoEstoque bd = new Tables.ProdutoServicoEstoque();

            bd.idProdutoServicoEstoque.isNull = true;
            bd.idProdutoServico.value = input.idProdutoServico;
            bd.idDepartamento.value = input.idDepartamento;
            bd.dataFabricacao.value = input.dataFabricacao;
            bd.dataValidade.value = input.dataValidade;
            bd.numeroLote.value = input.numeroLote;
            bd.quantidade.value = input.quantidade;
            bd.patrimonio.value = input.patrimonio;

            this.m_EntityManager.persist(bd);

            ((Data.ProdutoServicoEstoque)parametros["Key"]).idProdutoServicoEstoque = (int)bd.idProdutoServicoEstoque.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoEstoque input = (Data.ProdutoServicoEstoque)parametros["Key"];
            Tables.ProdutoServicoEstoque bd = (Tables.ProdutoServicoEstoque)this.m_EntityManager.find
            (
                typeof(Tables.ProdutoServicoEstoque),
                new Object[]
                {
                    input.idProdutoServicoEstoque
                }
            );

            bd.idProdutoServico.value = input.idProdutoServico;
            bd.idDepartamento.value = input.idDepartamento;
            bd.dataFabricacao.value = input.dataFabricacao;
            bd.dataValidade.value = input.dataValidade;
            bd.numeroLote.value = input.numeroLote;
            bd.quantidade.value = input.quantidade;
            bd.patrimonio.value = input.patrimonio;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ProdutoServicoEstoque bd = new Tables.ProdutoServicoEstoque();

            bd.idProdutoServicoEstoque.value = ((Data.ProdutoServicoEstoque)parametros["Key"]).idProdutoServicoEstoque;
            this.m_EntityManager.remove(bd);
        }

        public override String makeSelect(Type classBase, Data.Base input, Object _fieldKeys, System.Collections.Hashtable _params = null)
        {
            String
                result = "",
                sqlInner = "",
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

            Data.ProdutoServicoEstoque _input = (Data.ProdutoServicoEstoque)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idProdutoServico > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoEstoque.idProdutoServico = @idProdutoServico");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idProdutoServico", _input.idProdutoServico));
                    if (!sqlOrderBy.Contains("produtoServicoEstoque.idProdutoServico"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoEstoque.idProdutoServico");
                    else { }
                }
                else { }

                if (_input.produtoServico != null && _input.produtoServico.idProdutoServico > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoEstoque.idProdutoServico = @idProdutoServicoE");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idProdutoServicoE", _input.produtoServico.idProdutoServico));
                    if (!sqlOrderBy.Contains("produtoServicoEstoque.idProdutoServico"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoEstoque.idProdutoServico");
                    else { }
                }
                else { }


                if (_input.idDepartamento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoEstoque.idDepartamento = @idDepartamento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamento", _input.idDepartamento));
                    if (!sqlOrderBy.Contains("produtoServicoEstoque.idDepartamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoEstoque.idDepartamento");
                    else { }
                }
                else { }

                if (_input.dataFabricacao.Ticks > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoEstoque.dataFabricacao = @dataFabricacao");
                    fieldKeys.Add(new EJB.TableBase.TFieldDatetime("dataFabricacao", _input.dataFabricacao));
                    if (!sqlOrderBy.Contains("produtoServicoEstoque.dataFabricacao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoEstoque.dataFabricacao");
                    else { }
                }
                else { }

                if (_input.dataValidade.Ticks > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoEstoque.dataValidade = @dataValidade");
                    fieldKeys.Add(new EJB.TableBase.TFieldDatetime("dataValidade", _input.dataValidade));
                    if (!sqlOrderBy.Contains("produtoServicoEstoque.dataValidade"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoEstoque.dataValidade");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.numeroLote))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoEstoque.numeroLote LIKE @numeroLote");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("numeroLote", _input.numeroLote));
                    if (!sqlOrderBy.Contains("produtoServicoEstoque.numeroLote"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoEstoque.numeroLote");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   produtoServicoEstoque.* " +
                    "from " +
                    "   produtoServicoEstoque " +
                    (sqlInner.Length > 0 ? sqlInner : "") +
                    (sqlWhere.Length > 0 ? " where " + sqlWhere : "") +
                    (sqlOrderBy.Length > 0 ? " order by " + sqlOrderBy : "") +
                    (((numRows > 0) && (offSet >= 0)) ? " offset " + offSet + " rows fetch next " + numRows + " rows only" : "")
                );

                table = null;
            }
            else { }

            return result;
        }


        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ProdutoServicoEstoque)bd).idProdutoServicoEstoque.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ProdutoServicoEstoque)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ProdutoServicoEstoque)input).idProdutoServicoEstoque = ((Tables.ProdutoServicoEstoque)bd).idProdutoServicoEstoque.value;
                    ((Data.ProdutoServicoEstoque)input).idProdutoServico = ((Tables.ProdutoServicoEstoque)bd).idProdutoServico.value;
                    ((Data.ProdutoServicoEstoque)input).idDepartamento = ((Tables.ProdutoServicoEstoque)bd).idDepartamento.value;
                    ((Data.ProdutoServicoEstoque)input).dataFabricacao = ((Tables.ProdutoServicoEstoque)bd).dataFabricacao.value;
                    ((Data.ProdutoServicoEstoque)input).dataValidade = ((Tables.ProdutoServicoEstoque)bd).dataValidade.value;
                    ((Data.ProdutoServicoEstoque)input).numeroLote = ((Tables.ProdutoServicoEstoque)bd).numeroLote.value;
                    ((Data.ProdutoServicoEstoque)input).quantidade = ((Tables.ProdutoServicoEstoque)bd).quantidade.value;
                    ((Data.ProdutoServicoEstoque)input).patrimonio = ((Tables.ProdutoServicoEstoque)bd).patrimonio.value;
                    ((Data.ProdutoServicoEstoque)input).departamento = (Data.Departamento)(new WS.CRUD.Departamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Departamento(),
                        ((Tables.ProdutoServicoEstoque)bd).departamento,
                        level + 1
                    );

                    if (level < 1)
                    {
                        ((Data.ProdutoServicoEstoque)input).produtoServico = (Data.ProdutoServico)(new WS.CRUD.ProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.ProdutoServico(),
                            ((Tables.ProdutoServicoEstoque)bd).produtoServico,
                            level + 1
                        );
                    }
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoEstoque result = (Data.ProdutoServicoEstoque)parametros["Key"];

            try
            {
                result = (Data.ProdutoServicoEstoque)this.preencher
                (
                    new Data.ProdutoServicoEstoque(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ProdutoServicoEstoque),
                        new Object[]
                        {
                            result.idProdutoServicoEstoque
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

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoEstoque input = (Data.ProdutoServicoEstoque)parametros["Key"];
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
                    typeof(Tables.ProdutoServicoEstoque),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ProdutoServicoEstoque _data in
                    (System.Collections.Generic.List<Tables.ProdutoServicoEstoque>)this.m_EntityManager.list
                    (
                        typeof(Tables.ProdutoServicoEstoque),
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
                    _base = (Data.Base)this.preencher(new Data.ProdutoServicoEstoque(), _data, level);

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
