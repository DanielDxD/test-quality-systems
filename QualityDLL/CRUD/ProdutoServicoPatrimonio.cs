using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WS.CRUD
{
    public class ProdutoServicoPatrimonio : WS.CRUD.Base
    {

        public ProdutoServicoPatrimonio(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoPatrimonio input = (Data.ProdutoServicoPatrimonio)parametros["Key"];
            Tables.ProdutoServicoPatrimonio bd = new Tables.ProdutoServicoPatrimonio();

            bd.idProdutoServicoPatrimonio.isNull = true;
            bd.produtoServico.idProdutoServico.value = input.produtoServicoEmpresa.idProdutoServico;
            bd.empresa.idEmpresa.value = input.produtoServicoEmpresa.idEmpresa;
            bd.departamento.idDepartamento.isNull = true;
            if (input.departamento != null && input.departamento.idDepartamento > 0)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else { }
            bd.codigoPatrimonial.value = input.codigoPatrimonial;
            bd.dataTombamento.value = input.dataTombamento;
            bd.dataAquisicao.value = input.dataAquisicao;
            bd.modalidadeAquisicao.value = input.modalidadeAquisicao;
            bd.estadoConservacao.value = input.estadoConservacao;
            bd.situacaoUtilitaria.value = input.situacaoUtilitaria;
            bd.valorAquisicaoEstimado.value = input.valorAquisicaoEstimado;
            bd.valorResidual.value = input.valorResidual;
            bd.valorAtual.value = input.valorAtual;
            bd.vidaUtil.value = input.vidaUtil;
            bd.motivoBaixa.value = input.motivoBaixa;
            bd.observacao.value = input.observacao;
            bd.numeroNotaFiscal.value = input.numeroNotaFiscal;
            bd.numeroSerie.value = input.numeroSerie;

            bd.dataBaixa.isNull = true;
            if (input.dataBaixa != null && input.dataBaixa.Ticks > 0)
                bd.dataBaixa.value = input.dataBaixa;
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.ProdutoServicoPatrimonio)parametros["Key"]).idProdutoServicoPatrimonio = (int)bd.idProdutoServicoPatrimonio.value;
            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoPatrimonio input = (Data.ProdutoServicoPatrimonio)parametros["Key"];
            Tables.ProdutoServicoPatrimonio bd = (Tables.ProdutoServicoPatrimonio)this.m_EntityManager.find
            (
                typeof(Tables.ProdutoServicoPatrimonio),
                new Object[]
                {
                    input.idProdutoServicoPatrimonio
                }
            );

            bd.produtoServico.idProdutoServico.value = input.produtoServicoEmpresa.idProdutoServico;
            bd.empresa.idEmpresa.value = input.produtoServicoEmpresa.idEmpresa;
            bd.departamento.idDepartamento.isNull = true;
            if (input.departamento != null && input.departamento.idDepartamento > 0)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else { }
            bd.codigoPatrimonial.value = input.codigoPatrimonial;
            bd.dataTombamento.value = input.dataTombamento;
            bd.dataAquisicao.value = input.dataAquisicao;
            bd.modalidadeAquisicao.value = input.modalidadeAquisicao;
            bd.estadoConservacao.value = input.estadoConservacao;
            bd.situacaoUtilitaria.value = input.situacaoUtilitaria;
            bd.valorAquisicaoEstimado.value = input.valorAquisicaoEstimado;
            bd.valorResidual.value = input.valorResidual;
            bd.valorAtual.value = input.valorAtual;
            bd.vidaUtil.value = input.vidaUtil;
            bd.motivoBaixa.value = input.motivoBaixa;
            bd.observacao.value = input.observacao;
            bd.numeroNotaFiscal.value = input.numeroNotaFiscal;
            bd.numeroSerie.value = input.numeroSerie;

            bd.dataBaixa.isNull = true;
            if (input.dataBaixa != null && input.dataBaixa.Ticks > 0)
                bd.dataBaixa.value = input.dataBaixa;
            else { }

            this.m_EntityManager.merge(bd);
            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ProdutoServicoPatrimonio bd = new Tables.ProdutoServicoPatrimonio();

            bd.idProdutoServicoPatrimonio.value = ((Data.ProdutoServicoPatrimonio)parametros["Key"]).idProdutoServicoPatrimonio;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ProdutoServicoPatrimonio)bd).idProdutoServicoPatrimonio.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ProdutoServicoPatrimonio)input).operacao = ENum.eOperacao.NONE;
                    ((Data.ProdutoServicoPatrimonio)input).idProdutoServicoPatrimonio = ((Tables.ProdutoServicoPatrimonio)bd).idProdutoServicoPatrimonio.value;
                    ((Data.ProdutoServicoPatrimonio)input).codigoPatrimonial = ((Tables.ProdutoServicoPatrimonio)bd).codigoPatrimonial.value;
                    ((Data.ProdutoServicoPatrimonio)input).dataTombamento = ((Tables.ProdutoServicoPatrimonio)bd).dataTombamento.value;
                    ((Data.ProdutoServicoPatrimonio)input).dataInclusao = ((Tables.ProdutoServicoPatrimonio)bd).dataInclusao.value;
                    ((Data.ProdutoServicoPatrimonio)input).dataAquisicao = ((Tables.ProdutoServicoPatrimonio)bd).dataAquisicao.value;
                    ((Data.ProdutoServicoPatrimonio)input).modalidadeAquisicao = ((Tables.ProdutoServicoPatrimonio)bd).modalidadeAquisicao.value;
                    ((Data.ProdutoServicoPatrimonio)input).estadoConservacao = ((Tables.ProdutoServicoPatrimonio)bd).estadoConservacao.value;
                    ((Data.ProdutoServicoPatrimonio)input).situacaoUtilitaria = ((Tables.ProdutoServicoPatrimonio)bd).situacaoUtilitaria.value;
                    ((Data.ProdutoServicoPatrimonio)input).valorAquisicaoEstimado = ((Tables.ProdutoServicoPatrimonio)bd).valorAquisicaoEstimado.value;
                    ((Data.ProdutoServicoPatrimonio)input).valorResidual = ((Tables.ProdutoServicoPatrimonio)bd).valorResidual.value;
                    ((Data.ProdutoServicoPatrimonio)input).valorAtual = ((Tables.ProdutoServicoPatrimonio)bd).valorAtual.value;
                    ((Data.ProdutoServicoPatrimonio)input).dataBaixa = ((Tables.ProdutoServicoPatrimonio)bd).dataBaixa.value;
                    ((Data.ProdutoServicoPatrimonio)input).vidaUtil = ((Tables.ProdutoServicoPatrimonio)bd).vidaUtil.value;
                    ((Data.ProdutoServicoPatrimonio)input).motivoBaixa = ((Tables.ProdutoServicoPatrimonio)bd).motivoBaixa.value;
                    ((Data.ProdutoServicoPatrimonio)input).observacao = ((Tables.ProdutoServicoPatrimonio)bd).observacao.value;
                    ((Data.ProdutoServicoPatrimonio)input).numeroNotaFiscal = ((Tables.ProdutoServicoPatrimonio)bd).numeroNotaFiscal.value;
                    ((Data.ProdutoServicoPatrimonio)input).numeroSerie = ((Tables.ProdutoServicoPatrimonio)bd).numeroSerie.value;


                    ((Data.ProdutoServicoPatrimonio)input).produtoServicoEmpresa = null;
                    {
                        try
                        {
                            ((Data.ProdutoServicoPatrimonio)input).produtoServicoEmpresa =
                            (
                                (Data.ProdutoServicoEmpresa)Utils.Utils.sr((long)this.m_IdEmpresaCorrente).consultar
                                (
                                    new Data.ProdutoServicoEmpresa
                                    {
                                        idEmpresa = ((Tables.ProdutoServicoPatrimonio)bd).empresa.idEmpresa.value,
                                        idProdutoServico = ((Tables.ProdutoServicoPatrimonio)bd).produtoServico.idProdutoServico.value
                                    }
                                )
                            );
                        }
                        catch { }
                    }

                    ((Data.ProdutoServicoPatrimonio)input).departamento = (Data.Departamento)(new WS.CRUD.Departamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Departamento(),
                        ((Tables.ProdutoServicoPatrimonio)bd).departamento,
                        level + 1
                    );

                    ((Data.ProdutoServicoPatrimonio)input).produtoServico = null;
                    {
                        try
                        {
                            ((Data.ProdutoServicoPatrimonio)input).produtoServico = (Data.ProdutoServico)(new WS.CRUD.ProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                            (
                                new Data.ProdutoServico(),
                                ((Tables.ProdutoServicoPatrimonio)bd).produtoServico,
                                level + 1
                            );
                        }
                        catch { }
                    }

                }
                else { }
            }
            else { }

            return input;
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

            Data.ProdutoServicoPatrimonio _input = (Data.ProdutoServicoPatrimonio)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idProdutoServicoPatrimonio > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoPatrimonio.idProdutoServicoPatrimonio = @idProdutoServicoPatrimonio");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idProdutoServicoPatrimonio", _input.idProdutoServicoPatrimonio));
                    if (!sqlOrderBy.Contains("produtoServicoPatrimonio.idProdutoServicoPatrimonio"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoPatrimonio.idProdutoServicoPatrimonio");
                    else { }
                }
                else { }

                if (_input.produtoServicoEmpresa != null)
                {
                    if (_input.produtoServicoEmpresa.idEmpresa > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoPatrimonio.idEmpresa = @idEmpresa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.produtoServicoEmpresa.idEmpresa));
                        if (!sqlOrderBy.Contains("produtoServicoPatrimonio.idEmpresa"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoPatrimonio.idEmpresa");
                        else { }
                    }
                    else { }

                    if (_input.produtoServicoEmpresa.idProdutoServico > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoPatrimonio.idProdutoServico = @idProdutoServico");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idProdutoServico", _input.produtoServicoEmpresa.idProdutoServico));
                        if (!sqlOrderBy.Contains("produtoServicoPatrimonio.idProdutoServico"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoPatrimonio.idProdutoServico");
                        else { }
                    }
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.codigoPatrimonial))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoPatrimonio.codigoPatrimonial = @codigoPatrimonial");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("codigoPatrimonial", _input.codigoPatrimonial));
                    if (!sqlOrderBy.Contains("produtoServicoPatrimonio.codigoPatrimonial"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoPatrimonio.codigoPatrimonial");
                    else { }
                }
                else { }

                if (_input.dataAquisicao != null && _input.dataAquisicao.Ticks > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoPatrimonio.dataAquisicao = @dataAquisicao");
                    fieldKeys.Add(new EJB.TableBase.TFieldDatetime("dataAquisicao", _input.dataAquisicao));
                    if (!sqlOrderBy.Contains("produtoServicoPatrimonio.dataAquisicao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoPatrimonio.dataAquisicao");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.modalidadeAquisicao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoPatrimonio.modalidadeAquisicao = @modalidadeAquisicao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("modalidadeAquisicao", _input.modalidadeAquisicao));
                    if (!sqlOrderBy.Contains("produtoServicoPatrimonio.modalidadeAquisicao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoPatrimonio.modalidadeAquisicao");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.estadoConservacao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoPatrimonio.estadoConservacao = @estadoConservacao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("estadoConservacao", _input.estadoConservacao));
                    if (!sqlOrderBy.Contains("produtoServicoPatrimonio.estadoConservacao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoPatrimonio.estadoConservacao");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.situacaoUtilitaria))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoPatrimonio.situacaoUtilitaria = @situacaoUtilitaria");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("situacaoUtilitaria", _input.situacaoUtilitaria));
                    if (!sqlOrderBy.Contains("produtoServicoPatrimonio.situacaoUtilitaria"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoPatrimonio.situacaoUtilitaria");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.numeroNotaFiscal))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoPatrimonio.numeroNotaFiscal = @numeroNotaFiscal");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("numeroNotaFiscal", _input.numeroNotaFiscal));
                    if (!sqlOrderBy.Contains("produtoServicoPatrimonio.numeroNotaFiscal"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoPatrimonio.numeroNotaFiscal");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.numeroSerie))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoPatrimonio.numeroSerie = @numeroSerie");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("numeroSerie", _input.numeroSerie));
                    if (!sqlOrderBy.Contains("produtoServicoPatrimonio.numeroSerie"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoPatrimonio.numeroSerie");
                    else { }
                }
                else { }

                if (_input.departamento != null)
                {
                    if (_input.departamento.idDepartamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoPatrimonio.idDepartamento = @idDepartamento");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamento", _input.departamento.idDepartamento));
                        if (!sqlOrderBy.Contains("produtoServicoPatrimonio.idDepartamento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoPatrimonio.idDepartamento");
                        else { }
                    }
                    else { }
                }
                else { }


                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "produtoServicoPatrimonio.* ") +
                    "from " +
                    (
                        "   produtoServicoPatrimonio produtoServicoPatrimonio " +
                        "       inner join produtoServico produtoServico" +
                        "           on	produtoServicoPatrimonio.idProdutoServico = produtoServico.idProdutoServico " +
                        "       inner join empresa empresa\n" +
                        "           on	produtoServicoPatrimonio.idEmpresa = empresa.idEmpresa\n" +
                        "       left join departamento departamento\n" +
                        "           on produtoServicoPatrimonio.idDepartamento = departamento.idDepartamento\n"
                    //"       inner join produtoServicoEstoque produtoServicoEstoque " +
                    //"           on	produtoServicoPatrimonio.idProdutoServicoEstoque = produtoServicoEstoque.idProdutoServicoEstoque "
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


        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoPatrimonio result = (Data.ProdutoServicoPatrimonio)parametros["Key"];

            try
            {
                result = (Data.ProdutoServicoPatrimonio)this.preencher
                (
                    new Data.ProdutoServicoPatrimonio(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ProdutoServicoPatrimonio),
                        new Object[]
                        {
                            result.idProdutoServicoPatrimonio
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
            Data.ProdutoServicoPatrimonio input = (Data.ProdutoServicoPatrimonio)parametros["Key"];
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
                    typeof(Tables.ProdutoServicoPatrimonio),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ProdutoServicoPatrimonio _data in
                    (System.Collections.Generic.List<Tables.ProdutoServicoPatrimonio>)this.m_EntityManager.list
                    (
                        typeof(Tables.ProdutoServicoPatrimonio),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.ProdutoServicoPatrimonio(), _data, level);

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
