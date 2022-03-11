using System;

namespace WS.CRUD
{
    public class AparelhoSat : WS.CRUD.Base
    {
        public AparelhoSat(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.AparelhoSat input = (Data.AparelhoSat)parametros["Key"];
            Tables.AparelhoSat bd = new Tables.AparelhoSat();

            bd.idAparelhoSat.isNull = true;
            bd.descricao.value = input.descricao;
            bd.ip.value = input.ip;
            bd.porta.value = input.porta;
            bd.codigoAtivacao.value = input.codigoAtivacao;
            bd.descricao.value = input.descricao;
            bd.idEmpresa.value = input.idEmpresa;
            bd.signAc.value = input.signAc;
            bd.modeloDll.value = input.modeloDll;
            bd.tipoAmbiente.value = input.tipoAmbiente;

            this.m_EntityManager.persist(bd);

            ((Data.AparelhoSat)parametros["Key"]).idAparelhoSat = (int)bd.idAparelhoSat.value;           

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.AparelhoSat input = (Data.AparelhoSat)parametros["Key"];
            Tables.AparelhoSat bd = (Tables.AparelhoSat)this.m_EntityManager.find
            (
                typeof(Tables.AparelhoSat),
                new Object[]
                {
                    input.idAparelhoSat
                }
            );

            bd.descricao.value = input.descricao;
            bd.ip.value = input.ip;
            bd.porta.value = input.porta;
            bd.codigoAtivacao.value = input.codigoAtivacao;
            bd.descricao.value = input.descricao;
            bd.idEmpresa.value = input.idEmpresa;
            bd.modeloDll.value = input.modeloDll;
            bd.signAc.value = input.signAc;
            bd.tipoAmbiente.value = input.tipoAmbiente;

            this.m_EntityManager.merge(bd);
            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.AparelhoSat bd = new Tables.AparelhoSat();

            bd.idAparelhoSat.value = ((Data.AparelhoSat)parametros["Key"]).idAparelhoSat;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.AparelhoSat)bd).idAparelhoSat.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.AparelhoSat)input).operacao = ENum.eOperacao.NONE;

                    ((Data.AparelhoSat)input).idAparelhoSat = ((Tables.AparelhoSat)bd).idAparelhoSat.value;
                    ((Data.AparelhoSat)input).descricao = ((Tables.AparelhoSat)bd).descricao.value;
                    ((Data.AparelhoSat)input).ip = ((Tables.AparelhoSat)bd).ip.value;
                    ((Data.AparelhoSat)input).porta = ((Tables.AparelhoSat)bd).porta.value;
                    ((Data.AparelhoSat)input).codigoAtivacao = ((Tables.AparelhoSat)bd).codigoAtivacao.value;
                    ((Data.AparelhoSat)input).idEmpresa = ((Tables.AparelhoSat)bd).idEmpresa.value;
                    ((Data.AparelhoSat)input).modeloDll = ((Tables.AparelhoSat)bd).modeloDll.value;
                    ((Data.AparelhoSat)input).signAc = ((Tables.AparelhoSat)bd).signAc.value;
                    ((Data.AparelhoSat)input).tipoAmbiente = ((Tables.AparelhoSat)bd).tipoAmbiente.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.AparelhoSat result = (Data.AparelhoSat)parametros["Key"];

            try
            {
                result = (Data.AparelhoSat)this.preencher
                (
                    new Data.AparelhoSat(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.AparelhoSat),
                        new Object[]
                        {
                            result.idAparelhoSat
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
            Data.AparelhoSat input = (Data.AparelhoSat)parametros["Key"];
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
                    typeof(Tables.AparelhoSat),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.AparelhoSat _data in
                    (System.Collections.Generic.List<Tables.AparelhoSat>)this.m_EntityManager.list
                    (
                        typeof(Tables.AparelhoSat),
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
                    _base = (Data.Base)this.preencher(new Data.AparelhoSat(), _data, level);

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

            Data.AparelhoSat _input = (Data.AparelhoSat)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                //sqlWhere = (sqlWhere.Contains("'") ? sqlWhere.Replace("'", "''") : sqlWhere);

                if (_input.idAparelhoSat > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "AparelhoSat.idAparelhoSat = @idAparelhoSat");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idAparelhoSat", _input.idAparelhoSat));
                    if (!sqlOrderBy.Contains("AparelhoSat.idAparelhoSat"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "AparelhoSat.idAparelhoSat");
                    else { }
                }
                else { }

                if (_input.idEmpresa > 0 || _input.idEmpresa == -1)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "AparelhoSat.idEmpresa = @idEmpresa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.idEmpresa));
                    if (!sqlOrderBy.Contains("AparelhoSat.idEmpresa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "AparelhoSat.idEmpresa");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "AparelhoSat.* ") +
                    "from " +
                    (
                        "   AparelhoSat AparelhoSat "
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
