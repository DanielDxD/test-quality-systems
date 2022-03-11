using System;

namespace WS.CRUD
{
    public class ProdutoServicoEmpresa : WS.CRUD.Base
    {
        public ProdutoServicoEmpresa(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoEmpresa input = (Data.ProdutoServicoEmpresa)parametros["Key"];
            Tables.ProdutoServicoEmpresa bd = new Tables.ProdutoServicoEmpresa();

            bd.idEmpresa.value = input.idEmpresa;
            bd.idProdutoServico.value = input.idProdutoServico;
            bd.custo.value = input.custo;
            bd.preco.value = input.preco;
            bd.quantidade.value = input.quantidade;
            bd.dataUltimaCompra.value = input.dataUltimaCompra;
            bd.estoqueMinimo.value = input.estoqueMinimo;
            bd.estoqueMaximo.value = input.estoqueMaximo;
            bd.aliquotaIcms.value = input.aliquotaIcms;
            bd.aplicarTaxaServico.value = input.aplicarTaxaServico == "s";
            
            if (!String.IsNullOrEmpty(input.codigoProduto))
                bd.codigoProduto.value = input.codigoProduto;
            else
                bd.codigoProduto.isNull = true;

            if (input.origemProduto != null && input.origemProduto.idOrigemProduto > 0)
                bd.origemProduto.idOrigemProduto.value = input.origemProduto.idOrigemProduto;
            else
                bd.origemProduto.idOrigemProduto.isNull = true;

            bd.TribRedBcIcms.value = input.TribRedBcIcms;
            bd.TribAliqICMSDif.value = input.TribAliqICMSDif;
            bd.TribAliqIpi.value = input.TribAliqIpi;
            bd.TribAliqPis.value = input.TribAliqPis;
            bd.TribAliqCofins.value = input.TribAliqCofins;

            if ((input.tipoProdutoServico != null) && (input.tipoProdutoServico.idTipoProdutoServico > 0))
                bd.tipoProdutoServico.idTipoProdutoServico.value = input.tipoProdutoServico.idTipoProdutoServico;
            else { }

            if (input.perfilFiscal != null && input.perfilFiscal.idPerfilFiscal > 0)
                bd.perfilFiscal.idPerfilFiscal.value = input.perfilFiscal.idPerfilFiscal;
            else
                bd.perfilFiscal.idPerfilFiscal.isNull = true;

            if (input.perfilFiscalNfe != null && input.perfilFiscalNfe.idPerfilFiscal > 0)
                bd.perfilFiscalNfe.idPerfilFiscal.value = input.perfilFiscalNfe.idPerfilFiscal;
            else
                bd.perfilFiscalNfe.idPerfilFiscal.isNull = true;

            this.m_EntityManager.persist(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoEmpresa input = (Data.ProdutoServicoEmpresa)parametros["Key"];
            Tables.ProdutoServicoEmpresa bd = (Tables.ProdutoServicoEmpresa)this.m_EntityManager.find
            (
                typeof(Tables.ProdutoServicoEmpresa),
                new Object[]
                {
                    input.idProdutoServico,
                    input.idEmpresa
                }
            );

            bd.custo.value = input.custo;
            bd.preco.value = input.preco;
            bd.quantidade.value = input.quantidade;
            bd.dataUltimaCompra.value = input.dataUltimaCompra;
            bd.estoqueMinimo.value = input.estoqueMinimo;
            bd.estoqueMaximo.value = input.estoqueMaximo;
            bd.aliquotaIcms.value = input.aliquotaIcms;
            bd.aplicarTaxaServico.value = input.aplicarTaxaServico == "s";
            if (!String.IsNullOrEmpty(input.codigoProduto))
                bd.codigoProduto.value = input.codigoProduto;
            else
                bd.codigoProduto.isNull = true;

            if ((input.tipoProdutoServico != null) && (input.tipoProdutoServico.idTipoProdutoServico > 0))
                bd.tipoProdutoServico.idTipoProdutoServico.value = input.tipoProdutoServico.idTipoProdutoServico;
            else { }

            if (input.perfilFiscal != null && input.perfilFiscal.idPerfilFiscal > 0)
                bd.perfilFiscal.idPerfilFiscal.value = input.perfilFiscal.idPerfilFiscal;
            else
                bd.perfilFiscal.idPerfilFiscal.isNull = true;

            if (input.origemProduto != null && input.origemProduto.idOrigemProduto > 0)
                bd.origemProduto.idOrigemProduto.value = input.origemProduto.idOrigemProduto;
            else
                bd.origemProduto.idOrigemProduto.isNull = true;

            bd.TribRedBcIcms.value = input.TribRedBcIcms;
            bd.TribAliqICMSDif.value = input.TribAliqICMSDif;
            bd.TribAliqIpi.value = input.TribAliqIpi;
            bd.TribAliqPis.value = input.TribAliqPis;
            bd.TribAliqCofins.value = input.TribAliqCofins;

            if (input.perfilFiscalNfe != null && input.perfilFiscalNfe.idPerfilFiscal > 0)
                bd.perfilFiscalNfe.idPerfilFiscal.value = input.perfilFiscalNfe.idPerfilFiscal;
            else
                bd.perfilFiscalNfe.idPerfilFiscal.isNull = true;

            this.m_EntityManager.merge(bd);

            return input; // this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ProdutoServicoEmpresa bd = new Tables.ProdutoServicoEmpresa();

            bd.idEmpresa.value = ((Data.ProdutoServicoEmpresa)parametros["Key"]).idEmpresa;
            bd.idProdutoServico.value = ((Data.ProdutoServicoEmpresa)parametros["Key"]).idProdutoServico;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
                if
                (
                    !((Tables.ProdutoServicoEmpresa)bd).idEmpresa.isNull &&
                    !((Tables.ProdutoServicoEmpresa)bd).idProdutoServico.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ProdutoServicoEmpresa)input).operacao = ENum.eOperacao.NONE;


                    ((Data.ProdutoServicoEmpresa)input).idEmpresa = ((Tables.ProdutoServicoEmpresa)bd).idEmpresa.value;
                    ((Data.ProdutoServicoEmpresa)input).idProdutoServico = ((Tables.ProdutoServicoEmpresa)bd).idProdutoServico.value;
                    ((Data.ProdutoServicoEmpresa)input).custo = ((Tables.ProdutoServicoEmpresa)bd).custo.value;
                    ((Data.ProdutoServicoEmpresa)input).preco = ((Tables.ProdutoServicoEmpresa)bd).preco.value;
                    ((Data.ProdutoServicoEmpresa)input).quantidade = ((Tables.ProdutoServicoEmpresa)bd).quantidade.value;
                    ((Data.ProdutoServicoEmpresa)input).dataUltimaCompra = ((Tables.ProdutoServicoEmpresa)bd).dataUltimaCompra.value;
                    ((Data.ProdutoServicoEmpresa)input).estoqueMinimo = ((Tables.ProdutoServicoEmpresa)bd).estoqueMinimo.value;
                    ((Data.ProdutoServicoEmpresa)input).estoqueMaximo = ((Tables.ProdutoServicoEmpresa)bd).estoqueMaximo.value;
                    ((Data.ProdutoServicoEmpresa)input).aliquotaIcms = ((Tables.ProdutoServicoEmpresa)bd).aliquotaIcms.value;
                    ((Data.ProdutoServicoEmpresa)input).codigoProduto = ((Tables.ProdutoServicoEmpresa)bd).codigoProduto.value;
                    ((Data.ProdutoServicoEmpresa)input).TribAliqCofins = ((Tables.ProdutoServicoEmpresa)bd).TribAliqCofins.value;
                    ((Data.ProdutoServicoEmpresa)input).TribAliqICMSDif = ((Tables.ProdutoServicoEmpresa)bd).TribAliqICMSDif.value;
                    ((Data.ProdutoServicoEmpresa)input).TribAliqIpi = ((Tables.ProdutoServicoEmpresa)bd).TribAliqIpi.value;
                    ((Data.ProdutoServicoEmpresa)input).TribAliqPis = ((Tables.ProdutoServicoEmpresa)bd).TribAliqPis.value;
                    ((Data.ProdutoServicoEmpresa)input).TribRedBcIcms = ((Tables.ProdutoServicoEmpresa)bd).TribRedBcIcms.value;
                    ((Data.ProdutoServicoEmpresa)input).aplicarTaxaServico = ((Tables.ProdutoServicoEmpresa)bd).aplicarTaxaServico.value ? "s" : "n";

                    ((Data.ProdutoServicoEmpresa)input).custoUltimaEntrada = 0;
                    try
                    {
                        System.Data.DataTable result = this.m_EntityManager.executeData(String.Format("SELECT dbo.getCustoMedio({0}, {1}, 0)", ((Tables.ProdutoServicoEmpresa)bd).idProdutoServico.value, ((Tables.ProdutoServicoEmpresa)bd).idEmpresa.value), null);
                        ((Data.ProdutoServicoEmpresa)input).custoUltimaEntrada = Convert.ToDouble(result.Rows[0][0]);
                    }
                    catch { }
                    ((Data.ProdutoServicoEmpresa)input).tipoProdutoServico = (Data.TipoProdutoServico)(new WS.CRUD.TipoProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoProdutoServico(),
                        ((Tables.ProdutoServicoEmpresa)bd).tipoProdutoServico,
                        level + 1
                    );
                    ((Data.ProdutoServicoEmpresa)input).perfilFiscal = (Data.PerfilFiscal)(new WS.CRUD.PerfilFiscal(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PerfilFiscal(),
                        ((Tables.ProdutoServicoEmpresa)bd).perfilFiscal,
                        level + 1
                    );
                    ((Data.ProdutoServicoEmpresa)input).perfilFiscalNfe = (Data.PerfilFiscal)(new WS.CRUD.PerfilFiscal(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PerfilFiscal(),
                        ((Tables.ProdutoServicoEmpresa)bd).perfilFiscalNfe,
                        level + 1
                    );
                    ((Data.ProdutoServicoEmpresa)input).origemProduto = (Data.OrigemProduto)(new WS.CRUD.OrigemProduto(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.OrigemProduto(),
                        ((Tables.ProdutoServicoEmpresa)bd).origemProduto,
                        level + 1
                    );

                }
                else { }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoEmpresa result = (Data.ProdutoServicoEmpresa)parametros["Key"];

            try
            {
                result = (Data.ProdutoServicoEmpresa)this.preencher
                (
                    new Data.ProdutoServicoEmpresa(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ProdutoServicoEmpresa),
                        new Object[]
                        {
                            result.idProdutoServico,
                            result.idEmpresa
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

            Data.ProdutoServicoEmpresa _input = (Data.ProdutoServicoEmpresa)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idEmpresa > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoEmpresa.idEmpresa = @idEmpresa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.idEmpresa));
                    if (!sqlOrderBy.Contains("produtoServicoEmpresa.idEmpresa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoEmpresa.idEmpresa");
                    else { }
                }
                else { }

                if (_input.idProdutoServico > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoEmpresa.idProdutoServico = @idProdutoServico");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idProdutoServico", _input.idProdutoServico));
                    if (!sqlOrderBy.Contains("produtoServicoEmpresa.idProdutoServico"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoEmpresa.idProdutoServico");
                    else { }
                }
                else { }

                if (_input.idTipoProdutoServico > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoEmpresa.idTipoProdutoServico = @idTipoProdutoServico");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTipoProdutoServico", _input.idTipoProdutoServico));
                    if (!sqlOrderBy.Contains("produtoServicoEmpresa.idTipoProdutoServico"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoEmpresa.idTipoProdutoServico");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.codigoProduto))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoEmpresa.codigoProduto = @codigoProduto");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("codigoProduto", _input.codigoProduto));
                    if (!sqlOrderBy.Contains("produtoServicoEmpresa.codigoProduto"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoEmpresa.codigoProduto");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.aplicarTaxaServico))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   produtoServicoEmpresa.aplicarTaxaServico = @aplicarTaxaServico");
                    fieldKeys.Add(new EJB.TableBase.TFieldBoolean("aplicarTaxaServico", _input.aplicarTaxaServico == "s"));
                    if (!sqlOrderBy.Contains("produtoServicoEmpresa.aplicarTaxaServico"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoEmpresa.aplicarTaxaServico");
                    else { }
                }
                else { }

                if (_input.quantidade > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoEmpresa.quantidade = @quantidade");
                    fieldKeys.Add(new EJB.TableBase.TFieldDouble("quantidade", _input.quantidade));
                    if (!sqlOrderBy.Contains("produtoServicoEmpresa.quantidade"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoEmpresa.quantidade");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   produtoServicoEmpresa.* " +
                    "from " +
                    "   produtoServicoEmpresa produtoServicoEmpresa " +
                    "inner join " +
                    "   produtoServico produtoServico ON produtoServico.idProdutoServico = produtoServicoEmpresa.idProdutoServico " +
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
            Data.ProdutoServicoEmpresa input = (Data.ProdutoServicoEmpresa)parametros["Key"];
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
                    typeof(Tables.ProdutoServicoEmpresa),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;
                System.Collections.Generic.List<Tables.ProdutoServicoEmpresa> results = new System.Collections.Generic.List<Tables.ProdutoServicoEmpresa>();
                results = ((System.Collections.Generic.List<Tables.ProdutoServicoEmpresa>)this.m_EntityManager.list
                    (
                        typeof(Tables.ProdutoServicoEmpresa),
                        _select,
                       _fieldKeys.ToArray()
                    ));

                if (results != null)
                {

                    foreach
                    (
                        Tables.ProdutoServicoEmpresa _data in results

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
                        _base = (Data.Base)this.preencher(new Data.ProdutoServicoEmpresa(), _data, level);

                        if (report != null)
                            report.ProcessRecord(_base);
                        else
                            result.Add(_base);
                    }
                }
                else { }

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
