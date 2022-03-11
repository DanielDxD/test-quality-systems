using System;

namespace WS.CRUD
{
    public class RequisicaoInternaProdutoServico : WS.CRUD.Base
    {
        public RequisicaoInternaProdutoServico(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoInternaProdutoServico input = (Data.RequisicaoInternaProdutoServico)parametros["Key"];
            Tables.RequisicaoInternaProdutoServico bd = new Tables.RequisicaoInternaProdutoServico();

            int
                empresaId = (int)parametros["Business"],
                departamentoOrigemId = (int)parametros["Source"],
                departamentoDestinoId = (int)parametros["Target"];

            String
                tipo = (String)parametros["Type"];

            bd.idRequisicaoInternaProdutoServico.isNull = true;
            bd.requisicaoInterna.idRequisicaoInterna.value = input.requisicaoInterna.idRequisicaoInterna;
            bd.produtoServico.idProdutoServico.value = input.produtoServico.idProdutoServico;
            bd.unidadeProdutoServico.idUnidadeProdutoServico.value = input.unidadeProdutoServico.idUnidadeProdutoServico;

            bd.quantidadeSolicitada.value = input.quantidadeSolicitada;
            bd.quantidadeAtendida.value = input.quantidadeAtendida;
            bd.fator.value = input.fator;

            try
            {
                this.m_EntityManager.persist(bd);
            }
            catch (Exception e)
            {
                throw new Utils.BusinessRuleException(e.Message);
            }

            ((Data.RequisicaoInternaProdutoServico)parametros["Key"]).idRequisicaoInternaProdutoServico = (int)bd.idRequisicaoInternaProdutoServico.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoInternaProdutoServico input = (Data.RequisicaoInternaProdutoServico)parametros["Key"];
            Tables.RequisicaoInternaProdutoServico bd = (Tables.RequisicaoInternaProdutoServico)this.m_EntityManager.find
            (
                typeof(Tables.RequisicaoInternaProdutoServico),
                new Object[]
                {
                    input.idRequisicaoInternaProdutoServico
                }
            );

            int
                empresaId = (int)parametros["Business"],
                departamentoOrigemId = (int)parametros["Source"],
                departamentoDestinoId = (int)parametros["Target"];

            String
                tipo = (String)parametros["Type"];

            bd.requisicaoInterna.idRequisicaoInterna.value = input.requisicaoInterna.idRequisicaoInterna;
            bd.produtoServico.idProdutoServico.value = input.produtoServico.idProdutoServico;
            bd.unidadeProdutoServico.idUnidadeProdutoServico.value = input.unidadeProdutoServico.idUnidadeProdutoServico;

            bd.quantidadeSolicitada.value = input.quantidadeSolicitada;
            bd.quantidadeAtendida.value = input.quantidadeAtendida;
            bd.fator.value = input.fator;

            try
            {
                this.m_EntityManager.merge(bd);
            }
            catch (Exception e)
            {
                throw new Utils.BusinessRuleException(e.Message);
            }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.RequisicaoInternaProdutoServico bd = (Tables.RequisicaoInternaProdutoServico)this.m_EntityManager.find
            (
                typeof(Tables.RequisicaoInternaProdutoServico),
                new Object[]
                {
                    ((Data.RequisicaoInternaProdutoServico)parametros["Key"]).idRequisicaoInternaProdutoServico
                }
            );

            /*int
                empresaId = (int)parametros["business"],
                departamentoOrigemId = (int)parametros["Source"],
                departamentoDestinoId = (int)parametros["Target"];

            String
                tipo = (String)parametros["Type"];
                */
            Data.RequisicaoInternaProdutoServico item = (Data.RequisicaoInternaProdutoServico)this.preencher(new Data.RequisicaoInternaProdutoServico(), bd, 0);
            item.quantidadeAtendida = 0.0;

            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.RequisicaoInternaProdutoServico)bd).idRequisicaoInternaProdutoServico.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.RequisicaoInternaProdutoServico)input).operacao = ENum.eOperacao.NONE;

                    ((Data.RequisicaoInternaProdutoServico)input).idRequisicaoInternaProdutoServico = ((Tables.RequisicaoInternaProdutoServico)bd).idRequisicaoInternaProdutoServico.value;
                    ((Data.RequisicaoInternaProdutoServico)input).idRequisicaoInterna = ((Tables.RequisicaoInternaProdutoServico)bd).requisicaoInterna.idRequisicaoInterna.value;
                    ((Data.RequisicaoInternaProdutoServico)input).requisicaoInterna = (Data.RequisicaoInterna)(new WS.CRUD.RequisicaoInterna(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.RequisicaoInterna(),
                        ((Tables.RequisicaoInternaProdutoServico)bd).requisicaoInterna,
                        level + 1
                    );
                    ((Data.RequisicaoInternaProdutoServico)input).produtoServico = (Data.ProdutoServico)(new WS.CRUD.ProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ProdutoServico(),
                        ((Tables.RequisicaoInternaProdutoServico)bd).produtoServico,
                        level + 1
                    );
                    ((Data.RequisicaoInternaProdutoServico)input).quantidadeSolicitada = ((Tables.RequisicaoInternaProdutoServico)bd).quantidadeSolicitada.value;
                    ((Data.RequisicaoInternaProdutoServico)input).unidadeProdutoServico = (Data.UnidadeProdutoServico)(new WS.CRUD.UnidadeProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.UnidadeProdutoServico(),
                        ((Tables.RequisicaoInternaProdutoServico)bd).unidadeProdutoServico,
                        level + 1
                    );
                    ((Data.RequisicaoInternaProdutoServico)input).quantidadeAtendida = ((Tables.RequisicaoInternaProdutoServico)bd).quantidadeAtendida.value;
                    ((Data.RequisicaoInternaProdutoServico)input).fator = ((Tables.RequisicaoInternaProdutoServico)bd).fator.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoInternaProdutoServico result = (Data.RequisicaoInternaProdutoServico)parametros["Key"];

            try
            {
                result = (Data.RequisicaoInternaProdutoServico)this.preencher
                (
                    new Data.RequisicaoInternaProdutoServico(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.RequisicaoInternaProdutoServico),
                        new Object[]
                        {
                            result.idRequisicaoInternaProdutoServico
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

            Data.RequisicaoInternaProdutoServico _input = (Data.RequisicaoInternaProdutoServico)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                if (_input.idRequisicaoInternaProdutoServico > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   requisicaoInternaProdutoServico.idRequisicaoInternaProdutoServico = @idRequisicaoInternaProdutoServico");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idRequisicaoInternaProdutoServico", _input.idRequisicaoInternaProdutoServico));
                    if (!sqlOrderBy.Contains("requisicaoInternaProdutoServico.idRequisicaoInternaProdutoServico"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "requisicaoInternaProdutoServico.idRequisicaoInternaProdutoServico");
                    else { }
                }
                else { }

                if (_input.idRequisicaoInterna > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   requisicaoInternaProdutoServico.idRequisicaoInterna = @idRequisicaoInterna");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idRequisicaoInterna", _input.idRequisicaoInterna));
                    if (!sqlOrderBy.Contains("requisicaoInternaProdutoServico.idRequisicaoInterna"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "requisicaoInternaProdutoServico.idRequisicaoInterna");
                    else { }
                }
                else { }

                if(_input.requisicaoInterna != null)
                {
                    if(!String.IsNullOrEmpty(_input.requisicaoInterna.tipo))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   requisicaoInterna.tipo = @tipo");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("tipo", _input.requisicaoInterna.tipo));
                        if (!sqlOrderBy.Contains("requisicaoInterna.tipo"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "requisicaoInterna.tipo");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.produtoServico != null)
                {
                    if (_input.produtoServico.idProdutoServico > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   requisicaoInternaProdutoServico.idProdutoServico = @idProdutoServico");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idProdutoServico", _input.produtoServico.idProdutoServico));
                        if (!sqlOrderBy.Contains("requisicaoInternaProdutoServico.idProdutoServico"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "requisicaoInternaProdutoServico.idProdutoServico");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.unidadeProdutoServico != null)
                {
                    if (_input.unidadeProdutoServico.idUnidadeProdutoServico > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   requisicaoInternaProdutoServico.idUnidadeProdutoServico = @idUnidadeProdutoServico");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idUnidadeProdutoServico", _input.unidadeProdutoServico.idUnidadeProdutoServico));
                        if (!sqlOrderBy.Contains("requisicaoInternaProdutoServico.idUnidadeProdutoServico"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "requisicaoInternaProdutoServico.idUnidadeProdutoServico");
                        else { }
                    }
                    else { }
                }
                else { }
                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "requisicaoInternaProdutoServico.* ") +
                    "from \n" + 
                    (
                        "requisicaoInternaProdutoServico requisicaoInternaProdutoServico\n" +
                        "inner join requisicaoInterna requisicaoInterna \n " +
                        "  on requisicaoInterna.idRequisicaoInterna = requisicaoInternaProdutoServico.idRequisicaoInterna\n "
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
            Data.RequisicaoInternaProdutoServico input = (Data.RequisicaoInternaProdutoServico)parametros["Key"];
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
                    typeof(Tables.RequisicaoInternaProdutoServico),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.RequisicaoInternaProdutoServico _data in
                    (System.Collections.Generic.List<Tables.RequisicaoInternaProdutoServico>)this.m_EntityManager.list
                    (
                        typeof(Tables.RequisicaoInternaProdutoServico),
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
                    _base = (Data.Base)this.preencher(new Data.RequisicaoInternaProdutoServico(), _data, level);

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
