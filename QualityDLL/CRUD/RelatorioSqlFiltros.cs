using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS.CRUD
{
    public class RelatorioSqlFiltros : WS.CRUD.Base
    {
        public RelatorioSqlFiltros(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.RelatorioSqlFiltros input = (Data.RelatorioSqlFiltros)parametros["Key"];
            Tables.RelatorioSqlFiltros bd = new Tables.RelatorioSqlFiltros();

            bd.campos.value = input.campos;
            bd.classBase.value = input.classBase;
            bd.descricao.value = input.descricao;
            bd.filterCampos.value = input.filterCampos;
            bd.idRelatorioSql.value = input.idRelatorioSql;
            bd.keyValue.value = input.keyValue;
            bd.orderCampos.value = input.orderCampos;
            bd.required.value = input.required;
            bd.tipo.value = input.tipo;

            this.m_EntityManager.persist(bd);

            ((Data.RelatorioSqlFiltros)parametros["Key"]).idRelatorioSql = (int)bd.idRelatorioSql.value;
            return input; // this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.RelatorioSqlFiltros input = (Data.RelatorioSqlFiltros)parametros["Key"];
            Tables.RelatorioSqlFiltros bd = (Tables.RelatorioSqlFiltros)this.m_EntityManager.find
            (
                typeof(Tables.RelatorioSqlFiltros),
                new Object[]
                {
                    input.idRelatorioSqlFiltro
                }
            );

            bd.campos.value = input.campos;
            bd.classBase.value = input.classBase;
            bd.descricao.value = input.descricao;
            bd.filterCampos.value = input.filterCampos;
            bd.keyValue.value = input.keyValue;
            bd.orderCampos.value = input.orderCampos;
            bd.required.value = input.required;
            bd.tipo.value = input.tipo;

            this.m_EntityManager.merge(bd);

            return input; // this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.RelatorioSqlFiltros bd = new Tables.RelatorioSqlFiltros();

            bd.idRelatorioSqlFiltro.value = ((Data.RelatorioSqlFiltros)parametros["Key"]).idRelatorioSqlFiltro;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.RelatorioSqlFiltros)bd).idRelatorioSqlFiltro.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.RelatorioSqlFiltros)input).operacao = ENum.eOperacao.NONE;

                    ((Data.RelatorioSqlFiltros)input).idRelatorioSqlFiltro = ((Tables.RelatorioSqlFiltros)bd).idRelatorioSqlFiltro.value;
                    ((Data.RelatorioSqlFiltros)input).descricao = ((Tables.RelatorioSqlFiltros)bd).descricao.value;
                    ((Data.RelatorioSqlFiltros)input).tipo = ((Tables.RelatorioSqlFiltros)bd).tipo.value;
                    ((Data.RelatorioSqlFiltros)input).keyValue = ((Tables.RelatorioSqlFiltros)bd).keyValue.value;
                    ((Data.RelatorioSqlFiltros)input).idRelatorioSql = ((Tables.RelatorioSqlFiltros)bd).idRelatorioSql.value;
                    ((Data.RelatorioSqlFiltros)input).classBase = ((Tables.RelatorioSqlFiltros)bd).classBase.value;
                    ((Data.RelatorioSqlFiltros)input).campos = ((Tables.RelatorioSqlFiltros)bd).campos.value;
                    ((Data.RelatorioSqlFiltros)input).orderCampos = ((Tables.RelatorioSqlFiltros)bd).orderCampos.value;
                    ((Data.RelatorioSqlFiltros)input).filterCampos = ((Tables.RelatorioSqlFiltros)bd).filterCampos.value;
                    ((Data.RelatorioSqlFiltros)input).required = ((Tables.RelatorioSqlFiltros)bd).required.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.RelatorioSqlFiltros result = (Data.RelatorioSqlFiltros)parametros["Key"];

            try
            {
                result = (Data.RelatorioSqlFiltros)this.preencher
                (
                    new Data.RelatorioSqlFiltros(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.RelatorioSqlFiltros),
                        new Object[]
                        {
                            result.idRelatorioSqlFiltro
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
            Data.RelatorioSqlFiltros input = (Data.RelatorioSqlFiltros)parametros["Key"];
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
                    typeof(Tables.RelatorioSqlFiltros),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.RelatorioSqlFiltros _data in
                    (System.Collections.Generic.List<Tables.RelatorioSqlFiltros>)this.m_EntityManager.list
                    (
                        typeof(Tables.RelatorioSqlFiltros),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.RelatorioSqlFiltros();
                        ((Data.RelatorioSqlFiltros)_base).idRelatorioSqlFiltro = _data.idRelatorioSqlFiltro.value;
                        ((Data.RelatorioSqlFiltros)_base).descricao = _data.descricao.value;
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.RelatorioSqlFiltros(), _data, level);

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
