using System;

namespace WS.CRUD
{
    public class RelatorioPerfil : WS.CRUD.Base
    {
        public RelatorioPerfil(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.RelatorioPerfil input = (Data.RelatorioPerfil)parametros["Key"];
            Tables.RelatorioPerfil bd = new Tables.RelatorioPerfil();

            bd.idRelatorioPerfil.isNull = true;
            bd.perfil.idPerfil.value = input.perfil.idPerfil;

            if (input.relatorio != null)
                bd.relatorio.idRelatorio.value = input.relatorio.idRelatorio;
            else
                bd.relatorio.idRelatorio.isNull = true;

            if (input.relatorioDinamico != null)
                bd.relatorioDinamico.idRelatorioSql.value = input.relatorioDinamico.idRelatorioSql;
            else
                bd.relatorioDinamico.idRelatorioSql.isNull = true;

            this.m_EntityManager.persist(bd);
            
            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.RelatorioPerfil input = (Data.RelatorioPerfil)parametros["Key"];
            Tables.RelatorioPerfil bd = (Tables.RelatorioPerfil)this.m_EntityManager.find
            (
                typeof(Tables.RelatorioPerfil),
                new Object[]
                {
                    input.idRelatorioPerfil
                }
            );

            bd.perfil.idPerfil.value = input.perfil.idPerfil;

            if (input.relatorio != null)
                bd.relatorio.idRelatorio.value = input.relatorio.idRelatorio;
            else
                bd.relatorio.idRelatorio.isNull = true;

            if (input.relatorioDinamico != null)
                bd.relatorioDinamico.idRelatorioSql.value = input.relatorioDinamico.idRelatorioSql;
            else
                bd.relatorioDinamico.idRelatorioSql.isNull = true;

            this.m_EntityManager.merge(bd);            

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.RelatorioPerfil bd = new Tables.RelatorioPerfil();

            bd.idRelatorioPerfil.value = ((Data.RelatorioPerfil)parametros["Key"]).idRelatorioPerfil;
            this.m_EntityManager.remove(bd);
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

            Data.RelatorioPerfil _input = (Data.RelatorioPerfil)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idRelatorioPerfil > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "relatorioPerfil.idRelatorioPerfil = @idRelatorioPerfil");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idRelatorioPerfil", _input.idRelatorioPerfil));
                    if (!sqlOrderBy.Contains("relatorioPerfil.idRelatorioPerfil"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "relatorioPerfil.idRelatorioPerfil");
                    else { }
                }
                else { }

                if(_input.perfil != null)
                {

                    if(_input.perfil.idPerfil > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "relatorioPerfil.idPerfil = @idPerfil");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPerfil", _input.perfil.idPerfil));
                        if (!sqlOrderBy.Contains("relatorioPerfil.idPerfil"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "relatorioPerfil.idPerfil");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.relatorio != null)
                {

                    if (_input.relatorio.idRelatorio > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "relatorioPerfil.idRelatorio = @idRelatorio");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idRelatorio", _input.relatorio.idRelatorio));
                        if (!sqlOrderBy.Contains("relatorioPerfil.idRelatorio"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "relatorioPerfil.idRelatorio");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.relatorioDinamico != null)
                {

                    if (_input.relatorioDinamico.idRelatorioSql > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "relatorioPerfil.idRelatorioSql = @idRelatorioSql");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idRelatorioSql", _input.relatorioDinamico.idRelatorioSql));
                        if (!sqlOrderBy.Contains("relatorioPerfil.idRelatorioSql"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "relatorioPerfil.idRelatorioSql");
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "relatorioPerfil.* ") +
                    "from " +
                    (
                        "   relatorioPerfil relatorioPerfil " +
                        "       inner join perfil " +
                        "           on perfil.idPerfil = relatorioPerfil.idPerfil " +
                        "       left join relatorios relatorios " +
                        "           on	relatorios.idRelatorio = relatorioPerfil.idRelatorio " +
                        "       left join relatorioSql relatorioSql\n" +
                        "           on	relatorioSql.idRelatorioSql = relatorioPerfil.idRelatorioSql\n"
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
        
        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.RelatorioPerfil)bd).idRelatorioPerfil.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.RelatorioPerfil)input).operacao = ENum.eOperacao.NONE;

                    ((Data.RelatorioPerfil)input).idRelatorioPerfil = ((Tables.RelatorioPerfil)bd).idRelatorioPerfil.value;
                    ((Data.RelatorioPerfil)input).perfil = (Data.Perfil)(new WS.CRUD.Perfil(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Perfil(),
                        ((Tables.RelatorioPerfil)bd).perfil,
                        level + 1
                    );
                    ((Data.RelatorioPerfil)input).relatorio = (Data.Relatorios)(new WS.CRUD.Relatorios(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Relatorios(),
                        ((Tables.RelatorioPerfil)bd).relatorio,
                        level + 1
                    );

                    ((Data.RelatorioPerfil)input).relatorioDinamico = (Data.RelatorioSql)(new WS.CRUD.RelatorioSql(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.RelatorioSql(),
                        ((Tables.RelatorioPerfil)bd).relatorioDinamico,
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
            Data.RelatorioPerfil result = (Data.RelatorioPerfil)parametros["Key"];

            try
            {
                result = (Data.RelatorioPerfil)this.preencher
                (
                    new Data.RelatorioPerfil(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.RelatorioPerfil),
                        new Object[]
                        {
                            result.idRelatorioPerfil
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
            Data.RelatorioPerfil input = (Data.RelatorioPerfil)parametros["Key"];
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
                    typeof(Tables.RelatorioPerfil),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.RelatorioPerfil _data in
                    (System.Collections.Generic.List<Tables.RelatorioPerfil>)this.m_EntityManager.list
                    (
                        typeof(Tables.RelatorioPerfil),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.RelatorioPerfil(), _data, level);

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
