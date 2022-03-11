using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS.CRUD
{
    public class RelatorioSql : WS.CRUD.Base
    {
        public RelatorioSql(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }
        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.RelatorioSql input = (Data.RelatorioSql)parametros["Key"];
            Tables.RelatorioSql bd = new Tables.RelatorioSql();

            bd.consulta.value = input.consulta;
            bd.descricao.value = input.descricao;

            this.m_EntityManager.persist(bd);

            ((Data.RelatorioSql)parametros["Key"]).idRelatorioSql = (int)bd.idRelatorioSql.value;

            WS.CRUD.RelatorioSqlFiltros relatorioFiltrosCRUD = new WS.CRUD.RelatorioSqlFiltros(this.m_IdEmpresaCorrente, this.m_EntityManager);
            System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

            if (input.filtros != null)
            {
                for (int i = 0; i < input.filtros.Length; i++)
                {
                    input.filtros[i].idRelatorioSql = bd.idRelatorioSql.value;
                    _parameters.Add("Key", input.filtros[i]);
                    relatorioFiltrosCRUD.incluir(_parameters);
                    _parameters.Clear();
                }
            }
            else { }

            relatorioFiltrosCRUD = null;
            _parameters = null;

            return input; // this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.RelatorioSql input = (Data.RelatorioSql)parametros["Key"];
            Tables.RelatorioSql bd = (Tables.RelatorioSql)this.m_EntityManager.find
            (
                typeof(Tables.RelatorioSql),
                new Object[]
                {
                    input.idRelatorioSql
                }
            );

            bd.descricao.value = input.descricao;
            bd.consulta.value = input.consulta;

            this.m_EntityManager.merge(bd);

            WS.CRUD.RelatorioSqlFiltros relatorioFiltrosCRUD = new WS.CRUD.RelatorioSqlFiltros(this.m_IdEmpresaCorrente, this.m_EntityManager);
            System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

            if (input.filtros != null)
            {
                for (int i = 0; i < input.filtros.Length; i++)
                {
                    input.filtros[i].idRelatorioSql = bd.idRelatorioSql.value;
                    _parameters.Add("Key", input.filtros[i]);
                    if (input.filtros[i].operacao == ENum.eOperacao.NONE)
                        input.filtros[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    relatorioFiltrosCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }
            }
            else { }
            
            relatorioFiltrosCRUD = null;
            _parameters = null;

            return input; // this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.RelatorioSql bd = new Tables.RelatorioSql();

            bd.idRelatorioSql.value = ((Data.RelatorioSql)parametros["Key"]).idRelatorioSql;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.RelatorioSql)bd).idRelatorioSql.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.RelatorioSql)input).operacao = ENum.eOperacao.NONE;

                    ((Data.RelatorioSql)input).idRelatorioSql = ((Tables.RelatorioSql)bd).idRelatorioSql.value;
                    ((Data.RelatorioSql)input).descricao = ((Tables.RelatorioSql)bd).descricao.value;
                    ((Data.RelatorioSql)input).consulta = ((Tables.RelatorioSql)bd).consulta.value;
                }
                else { }
            }
            else { }

            //Preencher RelatorioSqlFiltros
            if (((Tables.RelatorioSql)bd).relatorioSqlFiltros != null)
            {
                System.Collections.Generic.List<Data.RelatorioSqlFiltros>
                    _listFL = new System.Collections.Generic.List<Data.RelatorioSqlFiltros>();

                foreach (Tables.RelatorioSqlFiltros _item in ((Tables.RelatorioSql)bd).relatorioSqlFiltros)
                {
                    Data.RelatorioSqlFiltros filtro =
                    (
                        (Data.RelatorioSqlFiltros)
                        (new WS.CRUD.RelatorioSqlFiltros(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.RelatorioSqlFiltros(),
                            _item,
                            level + 1
                        )
                    );

                    if (filtro != null)
                    {
                        _listFL.Add(filtro);
                    }
                }

                _listFL.Sort((x, y) => x.idRelatorioSqlFiltro.CompareTo(y.idRelatorioSqlFiltro));
                ((Data.RelatorioSql)input).filtros = _listFL.ToArray();
                _listFL.Clear();
                _listFL = null;
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.RelatorioSql result = (Data.RelatorioSql)parametros["Key"];

            try
            {
                result = (Data.RelatorioSql)this.preencher
                (
                    new Data.RelatorioSql(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.RelatorioSql),
                        new Object[]
                        {
                            result.idRelatorioSql
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

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.RelatorioSql input = (Data.RelatorioSql)parametros["Key"];
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
                    typeof(Tables.RelatorioSql),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.RelatorioSql _data in
                    (System.Collections.Generic.List<Tables.RelatorioSql>)this.m_EntityManager.list
                    (
                        typeof(Tables.RelatorioSql),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.RelatorioSql();
                        ((Data.RelatorioSql)_base).idRelatorioSql = _data.idRelatorioSql.value;
                        ((Data.RelatorioSql)_base).descricao = _data.descricao.value;
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.RelatorioSql(), _data, level);

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
