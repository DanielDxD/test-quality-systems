using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WS.CRUD
{
    public class PdvCompraCupomItem : WS.CRUD.Base
    {
        public PdvCompraCupomItem(long? idEmpresa, EJB.EntityManager.EntityManager entityManager) : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PdvCompraCupomItem input = (Data.PdvCompraCupomItem)parametros["Key"];
            Tables.PdvCompraCupomItem bd = new Tables.PdvCompraCupomItem();

            bd.pdvCompraCupom.idPdvCompraCupom.value = input.pdvCompraCupom.idPdvCompraCupom;
            bd.produtoServico.idProdutoServico.value = input.produtoServico.idProdutoServico;

            if (input.produtoServico != null && input.produtoServico.estocavel)
                if (input.pdvCompraCupom.requisicaoInterna != null && input.pdvCompraCupom.requisicaoInterna.requisicaoInternaProdutoServicos != null)
                    bd.requisicaoInternaProdutoServico.idRequisicaoInternaProdutoServico.value = input.pdvCompraCupom.requisicaoInterna.requisicaoInternaProdutoServicos.Where(X => X.produtoServico != null && X.produtoServico.idProdutoServico == input.produtoServico.idProdutoServico).ToArray()[0].idRequisicaoInternaProdutoServico;
                else { }
            else
                bd.requisicaoInternaProdutoServico.idRequisicaoInternaProdutoServico.isNull = true;

            bd.quantidade.value = input.quantidade;
            bd.valor.value = input.valor;
            bd.desconto.value = input.desconto;
            bd.observacao.value = input.observacao;


            //Incluir/Alterar RequisicaoInterna
            if (input.requisicaoInternaComposicao != null)
            {
                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                _parametros.Add("Key", input.requisicaoInternaComposicao);
                _parametros.Add("Return", bd.requisicaoInternaComposicao);

                input.requisicaoInternaComposicao = (Data.RequisicaoInterna)(new WS.CRUD.RequisicaoInterna(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }
            else { }

            if (input.requisicaoInternaComposicao != null && input.requisicaoInternaComposicao.idRequisicaoInterna > 0)
                bd.requisicaoInternaComposicao.idRequisicaoInterna.value = input.requisicaoInternaComposicao.idRequisicaoInterna;
            else
                bd.requisicaoInternaComposicao.idRequisicaoInterna.isNull = true;

            this.m_EntityManager.persist(bd);

            ((Data.PdvCompraCupomItem)parametros["Key"]).idPdvCompraCupomItem = (int)bd.idPdvCompraCupomItem.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PdvCompraCupomItem input = (Data.PdvCompraCupomItem)parametros["Key"];
            Tables.PdvCompraCupomItem bd = (Tables.PdvCompraCupomItem)this.m_EntityManager.find
            (
                typeof(Tables.PdvCompraCupomItem),
                new Object[]
                {
                    input.idPdvCompraCupomItem
                }
            );
            bd.pdvCompraCupom.idPdvCompraCupom.value = input.pdvCompraCupom.idPdvCompraCupom;
            bd.produtoServico.idProdutoServico.value = input.produtoServico.idProdutoServico;

            /*if (input.produtoServico != null && input.produtoServico.estocavel)
                if (input.pdvCompraCupom.requisicaoInterna != null && input.pdvCompraCupom.requisicaoInterna.requisicaoInternaProdutoServicos != null)
                    bd.requisicaoInternaProdutoServico.idRequisicaoInternaProdutoServico.value = input.pdvCompraCupom.requisicaoInterna.requisicaoInternaProdutoServicos.Where(X => X.produtoServico != null && T.produtoServico.idProdutoServico == input.produtoServico.idProdutoServico).ToArray()[0].idRequisicaoInternaProdutoServico;
                else { }
            else
                bd.requisicaoInternaProdutoServico.idRequisicaoInternaProdutoServico.isNull = true;*/

            bd.quantidade.value = input.quantidade;
            bd.valor.value = input.valor;
            bd.desconto.value = input.desconto;
            bd.observacao.value = input.observacao;

            //Alterar Requisição Interna;
            if (input.requisicaoInternaComposicao != null)
            {
                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                _parametros.Add("Key", input.requisicaoInternaComposicao);
                _parametros.Add("Return", bd.requisicaoInternaComposicao);

                input.requisicaoInternaComposicao = (Data.RequisicaoInterna)(new WS.CRUD.RequisicaoInterna(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }

            if (input.requisicaoInternaComposicao != null && input.requisicaoInternaComposicao.idRequisicaoInterna > 0)
                bd.requisicaoInternaComposicao.idRequisicaoInterna.value = input.requisicaoInternaComposicao.idRequisicaoInterna;
            else
                bd.requisicaoInternaComposicao.idRequisicaoInterna.isNull = true;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PdvCompraCupomItem bd = new Tables.PdvCompraCupomItem();

            bd.idPdvCompraCupomItem.value = ((Data.PdvCompraCupomItem)parametros["Key"]).idPdvCompraCupomItem;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PdvCompraCupomItem)bd).idPdvCompraCupomItem.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PdvCompraCupomItem)input).operacao = ENum.eOperacao.NONE;
                    ((Data.PdvCompraCupomItem)input).idPdvCompraCupomItem = ((Tables.PdvCompraCupomItem)bd).idPdvCompraCupomItem.value;

                    if (level < 2)
                    {
                        ((Data.PdvCompraCupomItem)input).pdvCompraCupom = (Data.PdvCompraCupom)(new WS.CRUD.PdvCompraCupom(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.PdvCompraCupom(),
                            ((Tables.PdvCompraCupomItem)bd).pdvCompraCupom,
                            level + 1
                        );
                    }
                    else { }

                    ((Data.PdvCompraCupomItem)input).requisicaoInternaProdutoServico = (Data.RequisicaoInternaProdutoServico)(new WS.CRUD.RequisicaoInternaProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.RequisicaoInternaProdutoServico(),
                        ((Tables.PdvCompraCupomItem)bd).requisicaoInternaProdutoServico,
                        level + 1
                    );

                    ((Data.PdvCompraCupomItem)input).produtoServico = (Data.ProdutoServico)(new WS.CRUD.ProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ProdutoServico(),
                        ((Tables.PdvCompraCupomItem)bd).produtoServico,
                        level + 1
                    );

                    ((Data.PdvCompraCupomItem)input).requisicaoInternaComposicao = (Data.RequisicaoInterna)(new WS.CRUD.RequisicaoInterna(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.RequisicaoInterna(),
                        ((Tables.PdvCompraCupomItem)bd).requisicaoInternaComposicao,
                        level + 1
                    );

                    ((Data.PdvCompraCupomItem)input).valor = ((Tables.PdvCompraCupomItem)bd).valor.value;
                    ((Data.PdvCompraCupomItem)input).quantidade = ((Tables.PdvCompraCupomItem)bd).quantidade.value;
                    ((Data.PdvCompraCupomItem)input).desconto = ((Tables.PdvCompraCupomItem)bd).desconto.value;
                    ((Data.PdvCompraCupomItem)input).observacao = ((Tables.PdvCompraCupomItem)bd).observacao.value;

                    try
                    {
                        ((Data.PdvCompraCupomItem)input).valorUnidade = ((Tables.PdvCompraCupomItem)bd).valor.value.ToString("c2") + " / " + ((Tables.PdvCompraCupomItem)bd).produtoServico.unidadeProdutoServico.sigla.value;
                    }
                    catch
                    {
                        ((Data.PdvCompraCupomItem)input).valorUnidade = ((Tables.PdvCompraCupomItem)bd).valor.value.ToString("c2");
                    }

                    ((Data.PdvCompraCupomItem)input).total =
                        Math.Round((((Tables.PdvCompraCupomItem)bd).quantidade.value * ((Tables.PdvCompraCupomItem)bd).valor.value) - ((Tables.PdvCompraCupomItem)bd).desconto.value, 2);
                }
                else { }

            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PdvCompraCupomItem result = (Data.PdvCompraCupomItem)parametros["Key"];
            String queryString = "";
            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();
                string whereKeys = "";

                if (result.idPdvCompraCupomItem > 0)
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvCompraCupomItem", result.idPdvCompraCupomItem));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvCompraCupomitem.idPdvCompraCupomItem = @idPdvCompraCupomItem";
                }
                else { }

                if ((result.pdvCompraCupom != null && result.pdvCompraCupom.idPdvCompraCupom > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvCompraCupom", result.pdvCompraCupom.idPdvCompraCupom));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvCompraCupomItem.idPdvCompraCupom = @idPdvCompraCupom";
                }
                else { }

                if ((result.requisicaoInternaProdutoServico != null && result.requisicaoInternaProdutoServico.idRequisicaoInternaProdutoServico > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idRequisicaoInternaProdutoServico", result.requisicaoInternaProdutoServico.idRequisicaoInternaProdutoServico));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvCompraCupomItem.idRequisicaoInternaProdutoServico = @idRequisicaoInternaProdutoServico";
                }
                else { }

                if ((result.produtoServico != null && result.produtoServico.idProdutoServico > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idProdutoServico", result.produtoServico.idProdutoServico));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvCompraCupomItem.idProdutoServico = @idProdutoServico";
                }
                else { }


                queryString =
                (
                    "select \n" +
                    "    *\n" +
                    "from \n" +
                    "    pdvCompraCupomItem pdvCompraCupomItem\n" +

                    "inner join pdvCompraCupom pdvCompraCupom\n " +
                    "   on pdvCompraCupom.idPdvCompraCupom = pdvCompraCupomItem.idPdvCompraCupom\n" +

                    "LEFT join requisicaoInternaProdutoServico requisicaoInternaProdutoServico\n " +
                    "   on requisicaoInternaProdutoServico.idRequisicaoInternaProdutoServico = pdvCompraCupomItem.idRequisicaoInternaProdutoServico\n " +

                    "inner join produtoServico produtoServico\n " +
                    "   on produtoServico.idProdutoServico = pdvCompraCupomItem.idProdutoServico\n " +

                    (
                        (whereKeys.Length > 0) ?
                        (
                            "where\n" +
                            "    " + whereKeys + "\n"
                        ) :
                        ""
                    )
                );

                foreach
                (
                    Tables.PdvCompraCupomItem _data in
                    (System.Collections.Generic.List<Tables.PdvCompraCupomItem>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvCompraCupomItem),
                        queryString,
                        fieldKeys.ToArray()
                    )
                )
                {
                    result = (Data.PdvCompraCupomItem)this.preencher
                    (
                        new Data.PdvCompraCupomItem(),
                        _data,
                        0
                    );
                }
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

            Data.PdvCompraCupomItem _input = (Data.PdvCompraCupomItem)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {


                if (_input.idPdvCompraCupomItem > 0)
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvCompraCupomItem", _input.idPdvCompraCupomItem));
                    sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "pdvCompraCupomitem.idPdvCompraCupomItem = @idPdvCompraCupomItem";
                    if (!sqlOrderBy.Contains("pdvCompraCupomItem.idPdvCompraCupomItem"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvCompraCupomitem.idPdvCompraCupomItem");
                    else { }
                }
                else { }

                if ((_input.pdvCompraCupom != null))
                {

                    if (_input.pdvCompraCupom.idPdvCompraCupom > 0)
                    {
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvCompraCupom", _input.pdvCompraCupom.idPdvCompraCupom));
                        sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "pdvCompraCupomItem.idPdvCompraCupom = @idPdvCompraCupom";
                        if (!sqlOrderBy.Contains("pdvCompraCupomItem.idPdvCompraCupom"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvCompraCupomItem.idPdvCompraCupom");
                        else { }
                    }
                    else { }

                    if (!String.IsNullOrEmpty(_input.pdvCompraCupom.statusCupom))
                    {
                        fieldKeys.Add(new EJB.TableBase.TFieldString("statusCupom", _input.pdvCompraCupom.statusCupom));
                        sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "pdvCompraCupom.statusCupom = @statusCupom";
                        if (!sqlOrderBy.Contains("pdvCompraCupom.statusCupom"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvCompraCupom.statusCupom");
                        else { }
                    }
                    else { }

                    if (_input.pdvCompraCupom.pdvCompra != null)
                    {
                        if (_input.pdvCompraCupom.pdvCompra.idPdvCompra > 0)
                        {
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvCompra", _input.pdvCompraCupom.pdvCompra.idPdvCompra));
                            sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "pdvCompraCupom.idPdvCompra = @idPdvCompra";
                            if (!sqlOrderBy.Contains("pdvCompraCupom.idPdvCompra"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvCompraCupom.idPdvCompra");
                            else { }
                        }
                        else { }
                    }
                    else { }
                }
                else { }

                if ((_input.requisicaoInternaProdutoServico != null && _input.requisicaoInternaProdutoServico.idRequisicaoInternaProdutoServico > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idRequisicaoInternaProdutoServico", _input.requisicaoInternaProdutoServico.idRequisicaoInternaProdutoServico));
                    sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "pdvCompraCupomItem.idRequisicaoInternaProdutoServico = @idRequisicaoInternaProdutoServico";
                    if (!sqlOrderBy.Contains("pdvCompraCupomItem.idRequisicaoInternaProdutoServico"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvCompraCupomItem.idRequisicaoInternaProdutoServico");
                    else { }
                }
                else { }

                if ((_input.produtoServico != null && _input.produtoServico.idProdutoServico > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idProdutoServico", _input.produtoServico.idProdutoServico));
                    sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "pdvCompraCupomItem.idProdutoServico = @idProdutoServico";
                    if (!sqlOrderBy.Contains("pdvCompraCupomItem.idProdutoServico"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvCompraCupomItem.idProdutoServico");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "pdvCompraCupomItem.* ") +
                    "from \n" +
                    "    pdvCompraCupomItem pdvCompraCupomItem\n" +

                    "inner join pdvCompraCupom pdvCompraCupom\n " +
                    "   on pdvCompraCupom.idPdvCompraCupom = pdvCompraCupomItem.idPdvCompraCupom\n" +

                    "LEFT join requisicaoInternaProdutoServico requisicaoInternaProdutoServico\n " +
                    "   on requisicaoInternaProdutoServico.idRequisicaoInternaProdutoServico = pdvCompraCupomItem.idRequisicaoInternaProdutoServico\n " +

                    "inner join produtoServico produtoServico\n " +
                    "   on produtoServico.idProdutoServico = pdvCompraCupomItem.idProdutoServico\n " +

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
            Data.PdvCompraCupomItem input = (Data.PdvCompraCupomItem)parametros["Key"];
            System.Collections.Generic.List<Data.Base> result = new System.Collections.Generic.List<Data.Base>();
            string mode = (string)(parametros["Mode"] == null ? "" : parametros["Mode"]);
            int level = (int)(parametros["Level"] == null ? 0 : parametros["Level"]);

            System.Collections.Hashtable makeSelectParams = new System.Collections.Hashtable();
            makeSelectParams["numRows"] = (parametros["Top"] == null ? 0 : (int)parametros["Top"]);
            makeSelectParams["where"] = (parametros["Filter"] == null ? "" : (String)parametros["Filter"]);
            makeSelectParams["orderBy"] = (parametros["Order"] == null ? "" : (String)parametros["Order"]);
            makeSelectParams["offSet"] = (parametros["Offset"] == null ? -1 : parametros["Offset"]);

            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> _fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();

                if (parametros["Filter"] != null)
                {
                    String _filter = (String)parametros["Filter"];

                    while (_filter.Contains("@"))
                    {
                        String _key = _filter.Substring(_filter.IndexOf("@")).Split(new char[] { ' ', ')' })[0];
                        _fieldKeys.Add((EJB.TableBase.TField)parametros[_key]);
                        _filter = _filter.Substring(_filter.IndexOf("@") + _key.Length);
                    }
                }
                else { }

                String _select = this.makeSelect
                (
                    typeof(Tables.PdvCompraCupomItem),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                parametros.Clear();
                parametros = null;

                foreach
                (
                    Tables.PdvCompraCupomItem _data in
                    (System.Collections.Generic.List<Tables.PdvCompraCupomItem>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvCompraCupomItem),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    if (mode == "Roll")
                    {
                        _base = new Data.PdvCompraCupomItem();
                        ((Data.PdvCompraCupomItem)_base).idPdvCompraCupomItem = _data.idPdvCompraCupomItem.value;
                        ((Data.PdvCompraCupomItem)_base).desconto = _data.desconto.value;
                        ((Data.PdvCompraCupomItem)_base).observacao = _data.observacao.value;
                        ((Data.PdvCompraCupomItem)_base).pdvCompraCupom = new Data.PdvCompraCupom
                        {
                            sequenciaCupom = _data.pdvCompraCupom.sequenciaCupom.value,
                            statusCupom = _data.pdvCompraCupom.statusCupom.value,
                            pdvCompra = new Data.PdvCompra
                            {
                                idPdvCompra = _data.pdvCompraCupom.pdvCompra.idPdvCompra.value
                            },
                            data = _data.pdvCompraCupom.data.value
                        };
                        ((Data.PdvCompraCupomItem)_base).produtoServico = new Data.ProdutoServico
                        {
                            descricao = _data.produtoServico.descricao.value
                        };
                        ((Data.PdvCompraCupomItem)_base).quantidade = _data.quantidade.value;
                        ((Data.PdvCompraCupomItem)_base).valor = _data.valor.value;
                        ((Data.PdvCompraCupomItem)_base).total = _data.quantidade.value * _data.valor.value;
                        try
                        {
                            ((Data.PdvCompraCupomItem)_base).valorUnidade = _data.valor.value.ToString("c2") + " / " + _data.produtoServico.unidadeProdutoServico.sigla.value;
                        }
                        catch
                        {
                            ((Data.PdvCompraCupomItem)_base).valorUnidade = _data.valor.value.ToString("c2");
                        }

                        ((Data.PdvCompraCupomItem)_base).total = Math.Round((_data.quantidade.value * _data.valor.value) - _data.desconto.value, 2);
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.PdvCompraCupomItem(), _data, level);

                    result.Add(_base);
                }

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
