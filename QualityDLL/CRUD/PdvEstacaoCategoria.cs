using System;

namespace WS.CRUD
{
    public class PdvEstacaoCategoria : WS.CRUD.Base
    {
        public PdvEstacaoCategoria(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacaoCategoria input = (Data.PdvEstacaoCategoria)parametros["Key"];
            Tables.PdvEstacaoCategoria bd = new Tables.PdvEstacaoCategoria();

            bd.descricao.value = input.descricao;
            if (input.icone != null && input.icone.Length > 0)
                bd.icone.value = input.icone;
            else
                bd.icone.isNull = true;

            if (input.pdvEstacao != null && input.pdvEstacao.idPdvEstacao > 0)
                bd.pdvEstacao.idPdvEstacao.value = input.pdvEstacao.idPdvEstacao;
            else { }

            if (input.pdvEstacaoCategoriaPai != null && input.pdvEstacaoCategoriaPai.idPdvEstacaoCategoria > 0)
                bd.pdvEstacaoCategoriaPai.idPdvEstacaoCategoria.value = input.pdvEstacaoCategoriaPai.idPdvEstacaoCategoria;
            else { }

            this.m_EntityManager.persist(bd);
            ((Data.PdvEstacaoCategoria)parametros["Key"]).idPdvEstacaoCategoria = (int)bd.idPdvEstacaoCategoria.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacaoCategoria input = (Data.PdvEstacaoCategoria)parametros["Key"];
            Tables.PdvEstacaoCategoria bd = (Tables.PdvEstacaoCategoria)this.m_EntityManager.find
            (
                typeof(Tables.PdvEstacaoCategoria),
                new Object[]
                {
                    input.idPdvEstacaoCategoria
                }
            );

            bd.descricao.value = input.descricao;
            if (input.icone != null && input.icone.Length > 0)
                bd.icone.value = input.icone;
            else
                bd.icone.isNull = true;

            if (input.pdvEstacao != null && input.pdvEstacao.idPdvEstacao > 0)
                bd.pdvEstacao.idPdvEstacao.value = input.pdvEstacao.idPdvEstacao;
            else { }

            if (input.pdvEstacaoCategoriaPai != null && input.pdvEstacaoCategoriaPai.idPdvEstacaoCategoria > 0)
                bd.pdvEstacaoCategoriaPai.idPdvEstacaoCategoria.value = input.pdvEstacaoCategoriaPai.idPdvEstacaoCategoria;
            else { }

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PdvEstacaoCategoria bd = new Tables.PdvEstacaoCategoria();

            bd.idPdvEstacaoCategoria.value = ((Data.PdvEstacaoCategoria)parametros["Key"]).idPdvEstacaoCategoria;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
                if
                (
                    !((Tables.PdvEstacaoCategoria)bd).idPdvEstacaoCategoria.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PdvEstacaoCategoria)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PdvEstacaoCategoria)input).idPdvEstacaoCategoria = ((Tables.PdvEstacaoCategoria)bd).idPdvEstacaoCategoria.value;
                    ((Data.PdvEstacaoCategoria)input).descricao = ((Tables.PdvEstacaoCategoria)bd).descricao.value;
                    ((Data.PdvEstacaoCategoria)input).icone = ((Tables.PdvEstacaoCategoria)bd).icone.value;


                    if (level < 1)
                    {
                        ((Data.PdvEstacaoCategoria)input).pdvEstacao = (Data.PdvEstacao)(new WS.CRUD.PdvEstacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.PdvEstacao(),
                            ((Tables.PdvEstacaoCategoria)bd).pdvEstacao,
                            level + 1
                        );

                        ((Data.PdvEstacaoCategoria)input).pdvEstacaoCategoriaPai = (Data.PdvEstacaoCategoria)(new WS.CRUD.PdvEstacaoCategoria(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.PdvEstacaoCategoria(),
                            ((Tables.PdvEstacaoCategoria)bd).pdvEstacaoCategoriaPai,
                            level + 1
                        );
                    }


                }
                else { }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacaoCategoria result = (Data.PdvEstacaoCategoria)parametros["Key"];

            try
            {
                result = (Data.PdvEstacaoCategoria)this.preencher
                (
                    new Data.PdvEstacaoCategoria(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.PdvEstacaoCategoria),
                        new Object[]
                        {
                            result.idPdvEstacaoCategoria
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

            Data.PdvEstacaoCategoria _input = (Data.PdvEstacaoCategoria)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                //sqlWhere = (sqlWhere.Contains("'") ? sqlWhere.Replace("'", "''") : sqlWhere);

                if (_input.idPdvEstacaoCategoria > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PdvEstacaoCategoria.idPdvEstacaoCategoria = @idPdvEstacaoCategoria");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacaoCategoria", _input.idPdvEstacaoCategoria));
                    if (!sqlOrderBy.Contains("PdvEstacaoCategoria.idPdvEstacaoCategoria"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PdvEstacaoCategoria.idPdvEstacaoCategoria");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PdvEstacaoCategoria.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", "%" + _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("PdvEstacaoCategoria.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PdvEstacaoCategoria.descricao");
                    else { }
                }
                else { }

                if (_input.pdvEstacaoCategoriaPai != null)
                {
                    if (_input.pdvEstacaoCategoriaPai.idPdvEstacaoCategoria > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PdvEstacaoCategoria.idPdvEstacaoCategoriaPai = @idPdvEstacaoCategoriaPai");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacaoCategoriaPai", _input.pdvEstacaoCategoriaPai.idPdvEstacaoCategoria));
                        if (!sqlOrderBy.Contains("PdvEstacaoCategoria.idPdvEstacaoCategoriaPai"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PdvEstacaoCategoria.idPdvEstacaoCategoriaPai");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.pdvEstacao != null)
                {
                    if (_input.pdvEstacao.idPdvEstacao > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PdvEstacaoCategoria.idPdvEstacao = @idPdvEstacao");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacao", _input.pdvEstacao.idPdvEstacao));
                        if (!sqlOrderBy.Contains("PdvEstacaoCategoria.idPdvEstacao"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PdvEstacaoCategoria.idPdvEstacao");
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "PdvEstacaoCategoria.* ") +
                    "from " +
                    (
                        "   PdvEstacaoCategoria PdvEstacaoCategoria "
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

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.PdvEstacaoCategoria input = (Data.PdvEstacaoCategoria)parametros["Key"];
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
                    typeof(Tables.PdvEstacaoCategoria),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.PdvEstacaoCategoria _data in
                    (System.Collections.Generic.List<Tables.PdvEstacaoCategoria>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvEstacaoCategoria),
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
                    _base = (Data.Base)this.preencher(new Data.PdvEstacaoCategoria(), _data, level);

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
