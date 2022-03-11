using System;
using System.Collections;

namespace WS.CRUD
{
    public class NotaFiscalEItem : WS.CRUD.Base
    {
        public NotaFiscalEItem(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.NotaFiscalEItem input = (Data.NotaFiscalEItem)parametros["Key"];
            Tables.NotaFiscalEItem bd = new Tables.NotaFiscalEItem();
            DateTime dataEntrada = (DateTime)parametros["dataEntrada"];
            int idEmpresa = (int)parametros["idEmpresa"];

            bd.idNotaFiscalEItem.isNull = true;
            bd.idNotaFiscal.value = input.idNotaFiscal;
            if ((input.produtoServico != null) && (input.produtoServico.idProdutoServico > 0))
                bd.produtoServico.idProdutoServico.value = input.produtoServico.idProdutoServico;
            else
                bd.produtoServico.idProdutoServico.isNull = true;

            if (input.idOperacaoFiscal > 0)
                bd.idOperacaoFiscal.value = input.idOperacaoFiscal;
            else
                bd.idOperacaoFiscal.isNull = true;

            bd.quantidade.value = input.quantidade;
            bd.valor.value = input.valor;
            bd.iss.value = input.iss;
            bd.icms.value = input.icms;
            bd.ipi.value = input.ipi;
            if ((input.unidadeProdutoServico != null) && (input.unidadeProdutoServico.idUnidadeProdutoServico > 0))
                bd.unidadeProdutoServico.idUnidadeProdutoServico.value = input.unidadeProdutoServico.idUnidadeProdutoServico;
            else
                bd.unidadeProdutoServico.idUnidadeProdutoServico.isNull = true;
            if (input.dataFabricacao.Ticks > 0)
                bd.dataFabricacao.value = input.dataFabricacao;
            else
                bd.dataFabricacao.isNull = true;
            if (input.dataValidade.Ticks > 0)
                bd.dataValidade.value = input.dataValidade;
            else
                bd.dataValidade.isNull = true;
            if (!String.IsNullOrEmpty(input.numeroLote))
                bd.numeroLote.value = input.numeroLote;
            else
                bd.numeroLote.isNull = true;

            if (input.idPedidoCompraProdutoServico > 0)
                bd.idPedidoCompraProdutoServico.value = input.idPedidoCompraProdutoServico;
            else
                bd.idPedidoCompraProdutoServico.isNull = true;

            if (input.idEntradaMercadoriaItem > 0)
                bd.idEntradaMercadoriaItem.value = input.idEntradaMercadoriaItem;
            else
                bd.idEntradaMercadoriaItem.isNull = true;

            bd.complemento.value = input.complemento;

            try
            {
                this.m_EntityManager.persist(bd);
            }
            catch (Exception e)
            {
                throw new Utils.BusinessRuleException(e.Message);
            }

            ((Data.NotaFiscalEItem)parametros["Key"]).idNotaFiscalEItem = (int)bd.idNotaFiscalEItem.value;

            return input;// this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.NotaFiscalEItem input = (Data.NotaFiscalEItem)parametros["Key"];
            Tables.NotaFiscalEItem bd = (Tables.NotaFiscalEItem)this.m_EntityManager.find
            (
                typeof(Tables.NotaFiscalEItem),
                new Object[]
                {
                    input.idNotaFiscalEItem
                }
            );
            DateTime dataEntrada = (DateTime)parametros["dataEntrada"];
            int idEmpresa = (int)parametros["idEmpresa"];

            bd.idNotaFiscal.value = input.idNotaFiscal;
            if ((input.produtoServico != null) && (input.produtoServico.idProdutoServico > 0))
                bd.produtoServico.idProdutoServico.value = input.produtoServico.idProdutoServico;
            else
                bd.produtoServico.idProdutoServico.isNull = true;

            if (input.idOperacaoFiscal > 0)
                bd.idOperacaoFiscal.value = input.idOperacaoFiscal;
            else
                bd.idOperacaoFiscal.isNull = true;

            bd.quantidade.value = input.quantidade;
            bd.valor.value = input.valor;
            bd.iss.value = input.iss;
            bd.icms.value = input.icms;
            bd.ipi.value = input.ipi;
            if ((input.unidadeProdutoServico != null) && (input.unidadeProdutoServico.idUnidadeProdutoServico > 0))
                bd.unidadeProdutoServico.idUnidadeProdutoServico.value = input.unidadeProdutoServico.idUnidadeProdutoServico;
            else
                bd.unidadeProdutoServico.idUnidadeProdutoServico.isNull = true;
            if (input.dataFabricacao.Ticks > 0)
                bd.dataFabricacao.value = input.dataFabricacao;
            else
                bd.dataFabricacao.isNull = true;
            if (input.dataValidade.Ticks > 0)
                bd.dataValidade.value = input.dataValidade;
            else
                bd.dataValidade.isNull = true;
            if (!String.IsNullOrEmpty(input.numeroLote))
                bd.numeroLote.value = input.numeroLote;
            else
                bd.numeroLote.isNull = true;

            if (input.idPedidoCompraProdutoServico > 0)
                bd.idPedidoCompraProdutoServico.value = input.idPedidoCompraProdutoServico;
            else
                bd.idPedidoCompraProdutoServico.isNull = true;

            if (input.idEntradaMercadoriaItem > 0)
                bd.idEntradaMercadoriaItem.value = input.idEntradaMercadoriaItem;
            else
                bd.idEntradaMercadoriaItem.isNull = true;

            bd.complemento.value = input.complemento;

            try
            {
                this.m_EntityManager.merge(bd);
            }
            catch (Exception e)
            {
                throw new Utils.BusinessRuleException(e.Message);
            }

            return input; // this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.NotaFiscalEItem bd = (Tables.NotaFiscalEItem)this.m_EntityManager.find
            (
                typeof(Tables.NotaFiscalEItem),
                new Object[]
                {
                     ((Data.NotaFiscalEItem)parametros["Key"]).idNotaFiscalEItem
                }
            );
            DateTime dataEntrada = (DateTime)parametros["dataEntrada"];

            Data.NotaFiscalEItem item = (Data.NotaFiscalEItem)this.preencher(new Data.NotaFiscalEItem(), bd, 0);
            item.quantidade = 0.0;

            bd.idNotaFiscalEItem.value = ((Data.NotaFiscalEItem)parametros["Key"]).idNotaFiscalEItem;

            try
            {
                this.m_EntityManager.remove(bd);
            }
            catch (Exception e)
            {
                throw new Utils.BusinessRuleException(e.Message);
            }
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.NotaFiscalEItem)bd).idNotaFiscalEItem.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.NotaFiscalEItem)input).operacao = ENum.eOperacao.NONE;

                    ((Data.NotaFiscalEItem)input).idNotaFiscalEItem = ((Tables.NotaFiscalEItem)bd).idNotaFiscalEItem.value;
                    ((Data.NotaFiscalEItem)input).idNotaFiscal = ((Tables.NotaFiscalEItem)bd).idNotaFiscal.value;
                    ((Data.NotaFiscalEItem)input).produtoServico = (Data.ProdutoServico)(new WS.CRUD.ProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ProdutoServico(),
                        ((Tables.NotaFiscalEItem)bd).produtoServico,
                        level + 1
                    );
                    ((Data.NotaFiscalEItem)input).idOperacaoFiscal = ((Tables.NotaFiscalEItem)bd).idOperacaoFiscal.value;
                    ((Data.NotaFiscalEItem)input).quantidade = ((Tables.NotaFiscalEItem)bd).quantidade.value;
                    ((Data.NotaFiscalEItem)input).valor = ((Tables.NotaFiscalEItem)bd).valor.value;
                    ((Data.NotaFiscalEItem)input).iss = ((Tables.NotaFiscalEItem)bd).iss.value;
                    ((Data.NotaFiscalEItem)input).icms = ((Tables.NotaFiscalEItem)bd).icms.value;
                    ((Data.NotaFiscalEItem)input).ipi = ((Tables.NotaFiscalEItem)bd).ipi.value;
                    ((Data.NotaFiscalEItem)input).movimentaEstoque = ((Tables.NotaFiscalEItem)bd).movimentaEstoque.value;
                    ((Data.NotaFiscalEItem)input).unidadeProdutoServico = (Data.UnidadeProdutoServico)(new WS.CRUD.UnidadeProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.UnidadeProdutoServico(),
                        ((Tables.NotaFiscalEItem)bd).unidadeProdutoServico,
                        level + 1
                    );
                    ((Data.NotaFiscalEItem)input).dataFabricacao = ((Tables.NotaFiscalEItem)bd).dataFabricacao.value;
                    ((Data.NotaFiscalEItem)input).dataValidade = ((Tables.NotaFiscalEItem)bd).dataValidade.value;
                    ((Data.NotaFiscalEItem)input).numeroLote = ((Tables.NotaFiscalEItem)bd).numeroLote.value;
                    ((Data.NotaFiscalEItem)input).idPedidoCompraProdutoServico = ((Tables.NotaFiscalEItem)bd).idPedidoCompraProdutoServico.value;

                    ((Data.NotaFiscalEItem)input).complemento = ((Tables.NotaFiscalEItem)bd).complemento.value;
                    try
                    {
                        if (level < 1)
                        {
                            Hashtable parameters = new Hashtable();
                            parameters.Add("Key", new Data.NotaFiscalE { idNotaFiscalE = ((Tables.NotaFiscalEItem)bd).idNotaFiscal.value });
                            ((Data.NotaFiscalEItem)input).notaFiscal = (Data.NotaFiscalE)(new WS.CRUD.NotaFiscalE(this.m_IdEmpresaCorrente, this.m_EntityManager)).consultar(parameters);
                            parameters = null;
                        }
                        else { }
                    }
                    catch { }
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.NotaFiscalEItem result = (Data.NotaFiscalEItem)parametros["Key"];

            try
            {
                result = (Data.NotaFiscalEItem)this.preencher
                (
                    new Data.NotaFiscalEItem(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.NotaFiscalEItem),
                        new Object[]
                        {
                            result.idNotaFiscalEItem
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

            Data.NotaFiscalEItem _input = (Data.NotaFiscalEItem)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                if (_input.idNotaFiscalEItem > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   notaFiscalEItem.idNotaFiscalEItem = @idNotaFiscalEItem");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idNotaFiscalEItem", _input.idNotaFiscalEItem));
                    if (!sqlOrderBy.Contains("notaFiscalEItem.idNotaFiscalEItem"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "notaFiscalEItem.idNotaFiscalEItem");
                    else { }
                }
                else { }

                if (_input.idNotaFiscal > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   notaFiscalEItem.idNotaFiscal = @idNotaFiscal");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idNotaFiscal", _input.idNotaFiscal));
                    if (!sqlOrderBy.Contains("notaFiscalEItem.idNotaFiscal"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "notaFiscalEItem.idNotaFiscal");
                    else { }
                }
                else { }

                if (_input.notaFiscal != null)
                {
                    if (!String.IsNullOrEmpty(_input.notaFiscal.numero))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   notaFiscalE.numero = @numero");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("numero", _input.notaFiscal.numero));
                        if (!sqlOrderBy.Contains("notaFiscalE.numero"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "notaFiscalE.numero");
                        else { }
                    }
                }
                else { }

                if (_input.produtoServico != null)
                {
                    if (_input.produtoServico.idProdutoServico > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   notaFiscalEItem.idProdutoServico = @idProdutoServico");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idProdutoServico", _input.produtoServico.idProdutoServico));
                        if (!sqlOrderBy.Contains("notaFiscalEItem.idProdutoServico"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "notaFiscalEItem.idProdutoServico");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.unidadeProdutoServico != null)
                {
                    if (_input.unidadeProdutoServico.idUnidadeProdutoServico > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   notaFiscalEItem.idUnidadeProdutoServico = @idUnidadeProdutoServico");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idUnidadeProdutoServico", _input.unidadeProdutoServico.idUnidadeProdutoServico));
                        if (!sqlOrderBy.Contains("notaFiscalEItem.idUnidadeProdutoServico"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "notaFiscalEItem.idUnidadeProdutoServico");
                        else { }
                    }
                    else { }
                }
                else { }
                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "notaFiscalEItem.* ") +
                    "from \n" +
                    (
                        "notaFiscalEItem notaFiscalEItem\n" +
                        "inner join notaFiscalE ON notaFiscalE.idNotaFiscalE = notaFiscalEItem.idNotaFiscal\n" +
                        "left join departamento ON departamento.idDepartamento = notaFiscalE.idDepartamento\n"
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
            Data.NotaFiscalEItem input = (Data.NotaFiscalEItem)parametros["Key"];
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
                    typeof(Tables.NotaFiscalEItem),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.NotaFiscalEItem _data in
                    (System.Collections.Generic.List<Tables.NotaFiscalEItem>)this.m_EntityManager.list
                    (
                        typeof(Tables.NotaFiscalEItem),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();;

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
                    _base = (Data.NotaFiscalEItem)this.preencher(new Data.NotaFiscalEItem(), _data, level);

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
