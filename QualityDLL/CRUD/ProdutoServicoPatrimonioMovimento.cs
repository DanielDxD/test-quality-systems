using System;

namespace WS.CRUD
{
    public class ProdutoServicoPatrimonioMovimento : WS.CRUD.Base
    {
        public ProdutoServicoPatrimonioMovimento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoPatrimonioMovimento input = (Data.ProdutoServicoPatrimonioMovimento)parametros["Key"];
            Tables.ProdutoServicoPatrimonioMovimento bd = new Tables.ProdutoServicoPatrimonioMovimento();

            bd.idProdutoServicoPatrimonioMovimento.isNull = true;

            bd.valorMovimento.value = input.valorMovimento;
            bd.dataMovimento.value = input.dataMovimento;
            bd.tipoOperacao.value = input.tipoOperacao;
            bd.produtoServicoPatrimonio.idProdutoServicoPatrimonio.value = input.produtoServicoPatrimonio.idProdutoServicoPatrimonio;

            bd.departamentoOrigem.idDepartamento.isNull = true;
            if (input.departamentoOrigem != null)
                if (input.departamentoOrigem.idDepartamento > 0)
                    bd.departamentoOrigem.idDepartamento.value = input.departamentoOrigem.idDepartamento;
                else { }
            else { }
            
            bd.departamentoDestino.idDepartamento.isNull = true;
            if (input.departamentoDestino != null)
                if (input.departamentoDestino.idDepartamento > 0)
                    bd.departamentoDestino.idDepartamento.value = input.departamentoDestino.idDepartamento;
                else { }
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.ProdutoServicoPatrimonioMovimento)parametros["Key"]).idProdutoServicoPatrimonioMovimento = (int)bd.idProdutoServicoPatrimonioMovimento.value;
            
            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoPatrimonioMovimento input = (Data.ProdutoServicoPatrimonioMovimento)parametros["Key"];
            Tables.ProdutoServicoPatrimonioMovimento bd = (Tables.ProdutoServicoPatrimonioMovimento)this.m_EntityManager.find
            (
                typeof(Tables.ProdutoServicoPatrimonioMovimento),
                new Object[]
                {
                    input.idProdutoServicoPatrimonioMovimento
                }
            );

            bd.valorMovimento.value = input.valorMovimento;
            bd.dataMovimento.value = input.dataMovimento;
            bd.tipoOperacao.value = input.tipoOperacao;
            bd.produtoServicoPatrimonio.idProdutoServicoPatrimonio.value = input.produtoServicoPatrimonio.idProdutoServicoPatrimonio;

            bd.departamentoOrigem.idDepartamento.isNull = true;
            if (input.departamentoOrigem != null)
                if (input.departamentoOrigem.idDepartamento > 0)
                    bd.departamentoOrigem.idDepartamento.value = input.departamentoOrigem.idDepartamento;
                else { }
            else { }

            bd.departamentoDestino.idDepartamento.isNull = true;
            if (input.departamentoDestino != null)
                if (input.departamentoDestino.idDepartamento > 0)
                    bd.departamentoDestino.idDepartamento.value = input.departamentoDestino.idDepartamento;
                else { }
            else { }

            this.m_EntityManager.merge(bd);            

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ProdutoServicoPatrimonioMovimento bd = new Tables.ProdutoServicoPatrimonioMovimento();

            bd.idProdutoServicoPatrimonioMovimento.value = ((Data.ProdutoServicoPatrimonioMovimento)parametros["Key"]).idProdutoServicoPatrimonioMovimento;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ProdutoServicoPatrimonioMovimento)bd).idProdutoServicoPatrimonioMovimento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ProdutoServicoPatrimonioMovimento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ProdutoServicoPatrimonioMovimento)input).idProdutoServicoPatrimonioMovimento = ((Tables.ProdutoServicoPatrimonioMovimento)bd).idProdutoServicoPatrimonioMovimento.value;
                    ((Data.ProdutoServicoPatrimonioMovimento)input).dataMovimento = ((Tables.ProdutoServicoPatrimonioMovimento)bd).dataMovimento.value;
                    ((Data.ProdutoServicoPatrimonioMovimento)input).produtoServicoPatrimonio = (Data.ProdutoServicoPatrimonio)(new WS.CRUD.ProdutoServicoPatrimonio(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ProdutoServicoPatrimonio(),
                        ((Tables.ProdutoServicoPatrimonioMovimento)bd).produtoServicoPatrimonio,
                        level + 1
                    );
                    ((Data.ProdutoServicoPatrimonioMovimento)input).departamentoOrigem = (Data.Departamento)(new WS.CRUD.Departamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Departamento(),
                        ((Tables.ProdutoServicoPatrimonioMovimento)bd).departamentoOrigem,
                        level + 1
                    );
                    ((Data.ProdutoServicoPatrimonioMovimento)input).departamentoDestino = (Data.Departamento)(new WS.CRUD.Departamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Departamento(),
                        ((Tables.ProdutoServicoPatrimonioMovimento)bd).departamentoDestino,
                        level + 1
                    );
                    ((Data.ProdutoServicoPatrimonioMovimento)input).tipoOperacao = ((Tables.ProdutoServicoPatrimonioMovimento)bd).tipoOperacao.value;
                    ((Data.ProdutoServicoPatrimonioMovimento)input).valorMovimento = ((Tables.ProdutoServicoPatrimonioMovimento)bd).valorMovimento.value;
                }
                else { }                
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoPatrimonioMovimento result = (Data.ProdutoServicoPatrimonioMovimento)parametros["Key"];

            try
            {
                result = (Data.ProdutoServicoPatrimonioMovimento)this.preencher
                (
                    new Data.ProdutoServicoPatrimonioMovimento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ProdutoServicoPatrimonioMovimento),
                        new Object[]
                        {
                            result.idProdutoServicoPatrimonioMovimento
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
            Data.ProdutoServicoPatrimonioMovimento input = (Data.ProdutoServicoPatrimonioMovimento)parametros["Key"];
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
                    typeof(Tables.ProdutoServicoPatrimonioMovimento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ProdutoServicoPatrimonioMovimento _data in
                    (System.Collections.Generic.List<Tables.ProdutoServicoPatrimonioMovimento>)this.m_EntityManager.list
                    (
                        typeof(Tables.ProdutoServicoPatrimonioMovimento),
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
                    _base = (Data.Base)this.preencher(new Data.ProdutoServicoPatrimonioMovimento(), _data, level);

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

            Data.ProdutoServicoPatrimonioMovimento _input = (Data.ProdutoServicoPatrimonioMovimento)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idProdutoServicoPatrimonioMovimento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoPatrimonioMovimento.idProdutoServicoPatrimonioMovimento = @idProdutoServicoPatrimonioMovimento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idProdutoServicoPatrimonioMovimento", _input.idProdutoServicoPatrimonioMovimento));
                    if (!sqlOrderBy.Contains("produtoServicoPatrimonioMovimento.idProdutoServicoPatrimonioMovimento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoPatrimonioMovimento.idProdutoServicoPatrimonioMovimento");
                    else { }
                }
                else { }

                if(_input.produtoServicoPatrimonio != null)
                {
                    if(_input.produtoServicoPatrimonio.idProdutoServicoPatrimonio > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoPatrimonioMovimento.idProdutoServicoPatrimonio = @idProdutoServicoPatrimonio");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idProdutoServicoPatrimonio", _input.produtoServicoPatrimonio.idProdutoServicoPatrimonio));
                        if (!sqlOrderBy.Contains("produtoServicoPatrimonioMovimento.idProdutoServicoPatrimonio"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoPatrimonioMovimento.idProdutoServicoPatrimonio");
                        else { }
                    }
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.tipoOperacao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoPatrimonioMovimento.tipoOperacao = @tipoOperacao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("tipoOperacao", _input.tipoOperacao));
                    if (!sqlOrderBy.Contains("produtoServicoPatrimonioMovimento.tipoOperacao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoPatrimonioMovimento.tipoOperacao");
                    else { }
                }
                else { }

                if (_input.dataMovimento.Ticks > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoPatrimonioMovimento.dataMovimento = @dataMovimento");
                    fieldKeys.Add(new EJB.TableBase.TFieldDatetime("dataMovimento", _input.dataMovimento));
                    if (!sqlOrderBy.Contains("produtoServicoPatrimonioMovimento.dataMovimento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoPatrimonioMovimento.dataMovimento");
                    else { }
                }
                else { }


                if (_input.departamentoOrigem != null)
                {
                    if (_input.departamentoOrigem.idDepartamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoPatrimonioMovimento.idDepartamentoOrigem = @idDepartamentoOrigem");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamentoOrigem", _input.departamentoOrigem.idDepartamento));
                        if (!sqlOrderBy.Contains("produtoServicoPatrimonioMovimento.idDepartamentoOrigem"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoPatrimonioMovimento.idDepartamentoOrigem");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.departamentoDestino != null)
                {
                    if (_input.departamentoDestino.idDepartamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "produtoServicoPatrimonioMovimento.idDepartamentoDestino = @idDepartamentoDestino");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamentoDestino", _input.departamentoDestino.idDepartamento));
                        if (!sqlOrderBy.Contains("produtoServicoPatrimonioMovimento.idDepartamentoDestino"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "produtoServicoPatrimonioMovimento.idDepartamentoDestino");
                        else { }
                    }
                    else { }
                }
                else { }               

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "produtoServicoPatrimonioMovimento.* ") +
                    "from \n" + 
                    (
                        "   produtoServicoPatrimonioMovimento produtoServicoPatrimonioMovimento\n" +
                        "       inner join produtoServicoPatrimonio\n" +
                        "           on produtoServicoPatrimonio.idProdutoServicoPatrimonio = produtoServicoPatrimonioMovimento.idProdutoServicoPatrimonio\n" +
                        "       left join departamento departamentoOrigem\n" +
                        "           on	departamentoOrigem.idDepartamento = produtoServicoPatrimonioMovimento.idDepartamentoOrigem\n " +
                        "       left join departamento departamentoDestino\n " +
                        "           on	departamentoDestino.idDepartamento = produtoServicoPatrimonioMovimento.idDepartamentoDestino\n "                        
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
