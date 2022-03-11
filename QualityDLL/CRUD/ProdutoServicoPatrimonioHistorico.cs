using System;

namespace WS.CRUD
{
    public class ProdutoServicoPatrimonioHistorico : WS.CRUD.Base
    {
        public ProdutoServicoPatrimonioHistorico(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoPatrimonioHistorico input = (Data.ProdutoServicoPatrimonioHistorico)parametros["Key"];
            Tables.ProdutoServicoPatrimonioHistorico bd = new Tables.ProdutoServicoPatrimonioHistorico();

            bd.idProdutoServicoPatrimonioHistorico.isNull = true;

            bd.valorAtual.value = input.valorAtual;
            bd.valorDepreciado.value = input.valorDepreciado;
            bd.dataHistorico.value = input.dataHistorico;
            bd.observacao.value = input.observacao;
            bd.dataReferencia.value = input.dataReferencia;
            bd.produtoServicoPatrimonio.idProdutoServicoPatrimonio.value = input.produtoServicoPatrimonio.idProdutoServicoPatrimonio;

            this.m_EntityManager.persist(bd);

            ((Data.ProdutoServicoPatrimonioHistorico)parametros["Key"]).idProdutoServicoPatrimonioHistorico = (int)bd.idProdutoServicoPatrimonioHistorico.value;
            
            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoPatrimonioHistorico input = (Data.ProdutoServicoPatrimonioHistorico)parametros["Key"];
            Tables.ProdutoServicoPatrimonioHistorico bd = (Tables.ProdutoServicoPatrimonioHistorico)this.m_EntityManager.find
            (
                typeof(Tables.ProdutoServicoPatrimonioHistorico),
                new Object[]
                {
                    input.idProdutoServicoPatrimonioHistorico
                }
            );

            bd.valorAtual.value = input.valorAtual;
            bd.valorDepreciado.value = input.valorDepreciado;
            bd.dataHistorico.value = input.dataHistorico;
            bd.observacao.value = input.observacao;
            bd.dataReferencia.value = input.dataReferencia;
            bd.produtoServicoPatrimonio.idProdutoServicoPatrimonio.value = input.produtoServicoPatrimonio.idProdutoServicoPatrimonio;

            this.m_EntityManager.merge(bd);            

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ProdutoServicoPatrimonioHistorico bd = new Tables.ProdutoServicoPatrimonioHistorico();

            bd.idProdutoServicoPatrimonioHistorico.value = ((Data.ProdutoServicoPatrimonioHistorico)parametros["Key"]).idProdutoServicoPatrimonioHistorico;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ProdutoServicoPatrimonioHistorico)bd).idProdutoServicoPatrimonioHistorico.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ProdutoServicoPatrimonioHistorico)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ProdutoServicoPatrimonioHistorico)input).idProdutoServicoPatrimonioHistorico = ((Tables.ProdutoServicoPatrimonioHistorico)bd).idProdutoServicoPatrimonioHistorico.value;
                    ((Data.ProdutoServicoPatrimonioHistorico)input).dataHistorico = ((Tables.ProdutoServicoPatrimonioHistorico)bd).dataHistorico.value;
                    ((Data.ProdutoServicoPatrimonioHistorico)input).dataReferencia = ((Tables.ProdutoServicoPatrimonioHistorico)bd).dataReferencia.value;
                    ((Data.ProdutoServicoPatrimonioHistorico)input).produtoServicoPatrimonio = (Data.ProdutoServicoPatrimonio)(new WS.CRUD.ProdutoServicoPatrimonio(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ProdutoServicoPatrimonio(),
                        ((Tables.ProdutoServicoPatrimonioHistorico)bd).produtoServicoPatrimonio,
                        level + 1
                    );

                    ((Data.ProdutoServicoPatrimonioHistorico)input).observacao = ((Tables.ProdutoServicoPatrimonioHistorico)bd).observacao.value;
                    ((Data.ProdutoServicoPatrimonioHistorico)input).valorDepreciado = ((Tables.ProdutoServicoPatrimonioHistorico)bd).valorDepreciado.value;
                    ((Data.ProdutoServicoPatrimonioHistorico)input).valorAtual = ((Tables.ProdutoServicoPatrimonioHistorico)bd).valorAtual.value;
                }
                else { }                
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoPatrimonioHistorico result = (Data.ProdutoServicoPatrimonioHistorico)parametros["Key"];

            try
            {
                result = (Data.ProdutoServicoPatrimonioHistorico)this.preencher
                (
                    new Data.ProdutoServicoPatrimonioHistorico(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ProdutoServicoPatrimonioHistorico),
                        new Object[]
                        {
                            result.idProdutoServicoPatrimonioHistorico
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
            Data.ProdutoServicoPatrimonioHistorico input = (Data.ProdutoServicoPatrimonioHistorico)parametros["Key"];
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
                    typeof(Tables.ProdutoServicoPatrimonioHistorico),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ProdutoServicoPatrimonioHistorico _data in
                    (System.Collections.Generic.List<Tables.ProdutoServicoPatrimonioHistorico>)this.m_EntityManager.list
                    (
                        typeof(Tables.ProdutoServicoPatrimonioHistorico),
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
                    _base = (Data.Base)this.preencher(new Data.ProdutoServicoPatrimonioHistorico(), _data, level);

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

            Data.ProdutoServicoPatrimonioHistorico _input = (Data.ProdutoServicoPatrimonioHistorico)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idProdutoServicoPatrimonioHistorico > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoPatrimonioHistorico.idProdutoServicoPatrimonioHistorico = @idProdutoServicoPatrimonioHistorico");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idProdutoServicoPatrimonioHistorico", _input.idProdutoServicoPatrimonioHistorico));
                    if (!sqlOrderBy.Contains("produtoServicoPatrimonioHistorico.idProdutoServicoPatrimonioHistorico"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoPatrimonioHistorico.idProdutoServicoPatrimonioHistorico");
                    else { }
                }
                else { }

                if(_input.produtoServicoPatrimonio != null)
                {
                    if(_input.produtoServicoPatrimonio.idProdutoServicoPatrimonio > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoPatrimonioHistorico.idProdutoServicoPatrimonio = @idProdutoServicoPatrimonio");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idProdutoServicoPatrimonio", _input.produtoServicoPatrimonio.idProdutoServicoPatrimonio));
                        if (!sqlOrderBy.Contains("produtoServicoPatrimonioHistorico.idProdutoServicoPatrimonio"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoPatrimonioHistorico.idProdutoServicoPatrimonio");
                        else { }
                    }
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.observacao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoPatrimonioHistorico.observacao = @observacao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("observacao", _input.observacao));
                    if (!sqlOrderBy.Contains("produtoServicoPatrimonioHistorico.observacao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoPatrimonioHistorico.observacao");
                    else { }
                }
                else { }

                if (_input.dataHistorico.Ticks > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoPatrimonioHistorico.dataHistorico = @dataHistorico");
                    fieldKeys.Add(new EJB.TableBase.TFieldDatetime("dataHistorico", _input.dataHistorico));
                    if (!sqlOrderBy.Contains("produtoServicoPatrimonioHistorico.dataHistorico"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoPatrimonioHistorico.dataHistorico");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.dataReferencia))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoPatrimonioHistorico.dataReferencia = @dataReferencia");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("dataReferencia", _input.dataReferencia));
                    if (!sqlOrderBy.Contains("produtoServicoPatrimonioHistorico.dataReferencia"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoPatrimonioHistorico.dataReferencia");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "produtoServicoPatrimonioHistorico.* ") +
                    "from \n" + 
                    (
                        "   produtoServicoPatrimonioHistorico produtoServicoPatrimonioHistorico\n" +
                        "       inner join produtoServicoPatrimonio\n" +
                        "           on produtoServicoPatrimonio.idProdutoServicoPatrimonio = produtoServicoPatrimonioHistorico.idProdutoServicoPatrimonio\n"                     
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

    }
}
