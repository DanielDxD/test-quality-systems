using System;

namespace WS.CRUD
{
    public class ParametroBoletoDesconto : WS.CRUD.Base
    {
        public ParametroBoletoDesconto(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ParametroBoletoDesconto input = (Data.ParametroBoletoDesconto)parametros["Key"];
            Tables.ParametroBoletoDesconto bd = new Tables.ParametroBoletoDesconto();

            bd.idParametroBoletoDesconto.isNull = true;
            bd.descricao.value = input.descricao;
            bd.tipoDesconto.value = input.tipoDesconto;
            bd.naturezaOperacao.idNaturezaOperacao.value = input.naturezaOperacao.idNaturezaOperacao;
            bd.valor.value = input.valor;
            bd.diasAVencer.value = input.diasAVencer;
            bd.dataInicio.value = input.dataInicio;
            bd.dataFim.value = input.dataFim;
            bd.diaFixo.value = input.diaFixo;
            bd.parametroBoleto.idParametroBoleto.value = input.parametroBoleto.idParametroBoleto;

            if (input.categoriaTitulo != null && input.categoriaTitulo.idCategoriaTitulo > 0)
                bd.categoriaTitulo.idCategoriaTitulo.value = input.categoriaTitulo.idCategoriaTitulo;
            else
                bd.categoriaTitulo.idCategoriaTitulo.isNull = true;

            if (input.situacao != null && input.situacao.idSituacao > 0)
                bd.situacao.idSituacao.value = input.situacao.idSituacao;
            else
                bd.situacao.idSituacao.isNull = true;

            this.m_EntityManager.persist(bd);

            ((Data.ParametroBoletoDesconto)parametros["Key"]).idParametroBoletoDesconto = (int)bd.idParametroBoletoDesconto.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ParametroBoletoDesconto input = (Data.ParametroBoletoDesconto)parametros["Key"];
            Tables.ParametroBoletoDesconto bd = (Tables.ParametroBoletoDesconto)this.m_EntityManager.find
            (
                typeof(Tables.ParametroBoletoDesconto),
                new Object[]
                {
                    input.idParametroBoletoDesconto
                }
            );

            bd.descricao.value = input.descricao;
            bd.tipoDesconto.value = input.tipoDesconto;
            bd.naturezaOperacao.idNaturezaOperacao.value = input.naturezaOperacao.idNaturezaOperacao;
            bd.valor.value = input.valor;
            bd.diasAVencer.value = input.diasAVencer;
            bd.dataInicio.value = input.dataInicio;
            bd.dataFim.value = input.dataFim;
            bd.diaFixo.value = input.diaFixo;
            bd.parametroBoleto.idParametroBoleto.value = input.parametroBoleto.idParametroBoleto;

            if (input.categoriaTitulo != null && input.categoriaTitulo.idCategoriaTitulo > 0)
                bd.categoriaTitulo.idCategoriaTitulo.value = input.categoriaTitulo.idCategoriaTitulo;
            else
                bd.categoriaTitulo.idCategoriaTitulo.isNull = true;

            if (input.situacao != null && input.situacao.idSituacao > 0)
                bd.situacao.idSituacao.value = input.situacao.idSituacao;
            else
                bd.situacao.idSituacao.isNull = true;

            this.m_EntityManager.merge(bd);
            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ParametroBoletoDesconto bd = new Tables.ParametroBoletoDesconto();

            bd.idParametroBoletoDesconto.value = ((Data.ParametroBoletoDesconto)parametros["Key"]).idParametroBoletoDesconto;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ParametroBoletoDesconto)bd).idParametroBoletoDesconto.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ParametroBoletoDesconto)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ParametroBoletoDesconto)input).idParametroBoletoDesconto = ((Tables.ParametroBoletoDesconto)bd).idParametroBoletoDesconto.value;
                    ((Data.ParametroBoletoDesconto)input).descricao = ((Tables.ParametroBoletoDesconto)bd).descricao.value;
                    ((Data.ParametroBoletoDesconto)input).dataFim = ((Tables.ParametroBoletoDesconto)bd).dataFim.value;
                    ((Data.ParametroBoletoDesconto)input).dataInicio = ((Tables.ParametroBoletoDesconto)bd).dataInicio.value;
                    ((Data.ParametroBoletoDesconto)input).diasAVencer = ((Tables.ParametroBoletoDesconto)bd).diasAVencer.value;
                    ((Data.ParametroBoletoDesconto)input).diaFixo = ((Tables.ParametroBoletoDesconto)bd).diaFixo.value;
                    ((Data.ParametroBoletoDesconto)input).naturezaOperacao = (Data.NaturezaOperacao)(new WS.CRUD.NaturezaOperacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.NaturezaOperacao(),
                        ((Tables.ParametroBoletoDesconto)bd).naturezaOperacao,
                        level + 1
                    );
                    ((Data.ParametroBoletoDesconto)input).parametroBoleto = (Data.ParametroBoleto)(new WS.CRUD.ParametroBoleto(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ParametroBoleto(),
                        ((Tables.ParametroBoletoDesconto)bd).parametroBoleto,
                        level + 1
                    );
                    ((Data.ParametroBoletoDesconto)input).tipoDesconto = ((Tables.ParametroBoletoDesconto)bd).tipoDesconto.value;
                    ((Data.ParametroBoletoDesconto)input).valor = ((Tables.ParametroBoletoDesconto)bd).valor.value;


                    ((Data.ParametroBoletoDesconto)input).categoriaTitulo = (Data.CategoriaTitulo)(new WS.CRUD.CategoriaTitulo(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.CategoriaTitulo(),
                        ((Tables.ParametroBoletoDesconto)bd).categoriaTitulo,
                        level + 1
                    );

                    ((Data.ParametroBoletoDesconto)input).situacao = (Data.Situacao)(new WS.CRUD.Situacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Situacao(),
                        ((Tables.ParametroBoletoDesconto)bd).situacao,
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
            Data.ParametroBoletoDesconto result = (Data.ParametroBoletoDesconto)parametros["Key"];

            try
            {
                result = (Data.ParametroBoletoDesconto)this.preencher
                (
                    new Data.ParametroBoletoDesconto(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ParametroBoletoDesconto),
                        new Object[]
                        {
                            result.idParametroBoletoDesconto
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
            Data.ParametroBoletoDesconto input = (Data.ParametroBoletoDesconto)parametros["Key"];
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
                    typeof(Tables.ParametroBoletoDesconto),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ParametroBoletoDesconto _data in
                    (System.Collections.Generic.List<Tables.ParametroBoletoDesconto>)this.m_EntityManager.list
                    (
                        typeof(Tables.ParametroBoletoDesconto),
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
                    _base = (Data.Base)this.preencher(new Data.ParametroBoletoDesconto(), _data, level);

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

            Data.ParametroBoletoDesconto _input = (Data.ParametroBoletoDesconto)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                //sqlWhere = (sqlWhere.Contains("'") ? sqlWhere.Replace("'", "''") : sqlWhere);

                if (_input.idParametroBoletoDesconto > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "ParametroBoletoDesconto.idParametroBoletoDesconto = @idParametroBoletoDesconto");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idParametroBoletoDesconto", _input.idParametroBoletoDesconto));
                    if (!sqlOrderBy.Contains("ParametroBoletoDesconto.idParametroBoletoDesconto"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ParametroBoletoDesconto.idParametroBoletoDesconto");
                    else { }
                }
                else { }

                if (_input.naturezaOperacao != null)
                {
                    if (_input.naturezaOperacao.idNaturezaOperacao > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "ParametroBoletoDesconto.idNaturezaOperacao = @idNaturezaOperacao");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idNaturezaOperacao", _input.naturezaOperacao.idNaturezaOperacao));
                        if (!sqlOrderBy.Contains("ParametroBoletoDesconto.idNaturezaOperacao"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ParametroBoletoDesconto.idNaturezaOperacao");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.parametroBoleto != null)
                {
                    if (_input.parametroBoleto.idParametroBoleto > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "ParametroBoletoDesconto.idParametroBoleto = @idParametroBoleto");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idParametroBoleto", _input.parametroBoleto.idParametroBoleto));
                        if (!sqlOrderBy.Contains("ParametroBoletoDesconto.idParametroBoleto"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ParametroBoletoDesconto.idParametroBoleto");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.situacao != null)
                {
                    if (_input.situacao.idSituacao > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "ParametroBoletoDesconto.idSituacao = @idSituacao");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idSituacao", _input.situacao.idSituacao));
                        if (!sqlOrderBy.Contains("ParametroBoletoDesconto.idSituacao"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ParametroBoletoDesconto.idSituacao");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.categoriaTitulo != null)
                {
                    if (_input.categoriaTitulo.idCategoriaTitulo > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "ParametroBoletoDesconto.idCategoriaTitulo = @idCategoriaTitulo");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idCategoriaTitulo", _input.categoriaTitulo.idCategoriaTitulo));
                        if (!sqlOrderBy.Contains("ParametroBoletoDesconto.idCategoriaTitulo"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ParametroBoletoDesconto.idCategoriaTitulo");
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "ParametroBoletoDesconto.* ") +
                    "from " +
                    (
                        "   ParametroBoletoDesconto ParametroBoletoDesconto "
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
