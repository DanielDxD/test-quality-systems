using System;

namespace WS.CRUD
{
    public class ParametroBoletoNossoNumero : WS.CRUD.Base
    {
        public ParametroBoletoNossoNumero(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ParametroBoletoNossoNumero input = (Data.ParametroBoletoNossoNumero)parametros["Key"];
            Tables.ParametroBoletoNossoNumero bd = new Tables.ParametroBoletoNossoNumero();

            bd.idParametroBoletoNossoNumero.isNull = true;
            if (input.parametroBoleto != null)
                bd.parametroBoleto.idParametroBoleto.value = input.parametroBoleto.idParametroBoleto;
            else { }
            bd.dataInicio.value = input.dataInicio;
            bd.dataFim.value = input.dataFim;
            bd.numeroInicial.value = input.numeroInicial;
            bd.numeroFinal.value = input.numeroFinal;
            bd.ativo.value = input.ativo;

            this.m_EntityManager.persist(bd);

            ((Data.ParametroBoletoNossoNumero)parametros["Key"]).idParametroBoletoNossoNumero = (int)bd.idParametroBoletoNossoNumero.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ParametroBoletoNossoNumero input = (Data.ParametroBoletoNossoNumero)parametros["Key"];
            Tables.ParametroBoletoNossoNumero bd = (Tables.ParametroBoletoNossoNumero)this.m_EntityManager.find
            (
                typeof(Tables.ParametroBoletoNossoNumero),
                new Object[]
                {
                    input.idParametroBoletoNossoNumero
                }
            );

            if (input.parametroBoleto != null)
                bd.parametroBoleto.idParametroBoleto.value = input.parametroBoleto.idParametroBoleto;
            else { }
            bd.dataInicio.value = input.dataInicio;
            bd.dataFim.value = input.dataFim;
            bd.numeroInicial.value = input.numeroInicial;
            bd.numeroFinal.value = input.numeroFinal;
            bd.ativo.value = input.ativo;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ParametroBoletoNossoNumero bd = new Tables.ParametroBoletoNossoNumero();

            bd.idParametroBoletoNossoNumero.value = ((Data.ParametroBoletoNossoNumero)parametros["Key"]).idParametroBoletoNossoNumero;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ParametroBoletoNossoNumero)bd).idParametroBoletoNossoNumero.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ParametroBoletoNossoNumero)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ParametroBoletoNossoNumero)input).idParametroBoletoNossoNumero = ((Tables.ParametroBoletoNossoNumero)bd).idParametroBoletoNossoNumero.value;
                    ((Data.ParametroBoletoNossoNumero)input).parametroBoleto = (Data.ParametroBoleto)(new WS.CRUD.ParametroBoleto(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ParametroBoleto(),
                        ((Tables.ParametroBoletoNossoNumero)bd).parametroBoleto,
                        level + 1
                    );
                    ((Data.ParametroBoletoNossoNumero)input).dataInicio = ((Tables.ParametroBoletoNossoNumero)bd).dataInicio.value;
                    ((Data.ParametroBoletoNossoNumero)input).dataFim = ((Tables.ParametroBoletoNossoNumero)bd).dataFim.value;
                    ((Data.ParametroBoletoNossoNumero)input).numeroInicial = ((Tables.ParametroBoletoNossoNumero)bd).numeroInicial.value;
                    ((Data.ParametroBoletoNossoNumero)input).numeroFinal = ((Tables.ParametroBoletoNossoNumero)bd).numeroFinal.value;
                    ((Data.ParametroBoletoNossoNumero)input).ativo = ((Tables.ParametroBoletoNossoNumero)bd).ativo.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.ParametroBoletoNossoNumero result = (Data.ParametroBoletoNossoNumero)parametros["Key"];

            try
            {
                result = (Data.ParametroBoletoNossoNumero)this.preencher
                (
                    new Data.ParametroBoletoNossoNumero(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ParametroBoletoNossoNumero),
                        new Object[]
                        {
                            result.idParametroBoletoNossoNumero
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

            Data.ParametroBoletoNossoNumero _input = (Data.ParametroBoletoNossoNumero)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idParametroBoletoNossoNumero > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "   ParametroBoletoNossoNumero.idParametroBoletoNossoNumero = @idParametroBoletoNossoNumero");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idParametroBoletoNossoNumero", _input.idParametroBoletoNossoNumero));
                    if (!sqlOrderBy.Contains("ParametroBoletoNossoNumero.idParametroBoletoNossoNumero"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ParametroBoletoNossoNumero.idParametroBoletoNossoNumero");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "ParametroBoletoNossoNumero.* ") +
                    "from \n" +
                    (
                        "ParametroBoletoNossoNumero ParametroBoletoNossoNumero\n"
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
            Data.ParametroBoletoNossoNumero input = (Data.ParametroBoletoNossoNumero)parametros["Key"];
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
                    typeof(Tables.ParametroBoletoNossoNumero),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ParametroBoletoNossoNumero _data in
                    (System.Collections.Generic.List<Tables.ParametroBoletoNossoNumero>)this.m_EntityManager.list
                    (
                        typeof(Tables.ParametroBoletoNossoNumero),
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
                    _base = (Data.Base)this.preencher(new Data.ParametroBoletoNossoNumero(), _data, level);

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
