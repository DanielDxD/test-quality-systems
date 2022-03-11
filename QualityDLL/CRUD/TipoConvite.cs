using System;
using System.Linq;

namespace WS.CRUD
{
    public class TipoConvite : WS.CRUD.Base
    {
        public TipoConvite(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.TipoConvite input = (Data.TipoConvite)parametros["Key"];
            Tables.TipoConvite bd = new Tables.TipoConvite();

            bd.idTipoConvite.isNull = true;
            bd.idadeInicial.value = input.idadeInicial;
            bd.idadeFinal.value = input.idadeFinal;
            bd.descricao.value = input.descricao;
            bd.valor.value = input.valor;
            bd.modeloTermo.value = input.modeloTermo;

            if (input.departamento != null && input.departamento.idDepartamento > 0)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else
                bd.departamento.idDepartamento.isNull = true;

            if (input.naturezaOperacao != null && input.naturezaOperacao.idNaturezaOperacao > 0)
                bd.naturezaOperacao.idNaturezaOperacao.value = input.naturezaOperacao.idNaturezaOperacao;
            else
                bd.naturezaOperacao.idNaturezaOperacao.isNull = true;

            this.m_EntityManager.persist(bd);

            ((Data.TipoConvite)parametros["Key"]).idTipoConvite = (int)bd.idTipoConvite.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.TipoConvite input = (Data.TipoConvite)parametros["Key"];
            Tables.TipoConvite bd = (Tables.TipoConvite)this.m_EntityManager.find
            (
                typeof(Tables.TipoConvite),
                new Object[]
                {
                    input.idTipoConvite
                }
            );

            bd.idadeInicial.value = input.idadeInicial;
            bd.idadeFinal.value = input.idadeFinal;
            bd.descricao.value = input.descricao;
            bd.valor.value = input.valor;
            bd.modeloTermo.value = input.modeloTermo;

            if (input.departamento != null && input.departamento.idDepartamento > 0)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else
                bd.departamento.idDepartamento.isNull = true;

            if (input.naturezaOperacao != null && input.naturezaOperacao.idNaturezaOperacao > 0)
                bd.naturezaOperacao.idNaturezaOperacao.value = input.naturezaOperacao.idNaturezaOperacao;
            else
                bd.naturezaOperacao.idNaturezaOperacao.isNull = true;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.TipoConvite bd = new Tables.TipoConvite();

            bd.idTipoConvite.value = ((Data.TipoConvite)parametros["Key"]).idTipoConvite;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.TipoConvite)bd).idTipoConvite.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.TipoConvite)input).operacao = ENum.eOperacao.NONE;

                    ((Data.TipoConvite)input).idTipoConvite = ((Tables.TipoConvite)bd).idTipoConvite.value;
                    ((Data.TipoConvite)input).idadeInicial = ((Tables.TipoConvite)bd).idadeInicial.value;
                    ((Data.TipoConvite)input).descricao = ((Tables.TipoConvite)bd).descricao.value;
                    ((Data.TipoConvite)input).idadeFinal = ((Tables.TipoConvite)bd).idadeFinal.value;
                    ((Data.TipoConvite)input).idadeFinal = ((Tables.TipoConvite)bd).idadeFinal.value;
                    ((Data.TipoConvite)input).valor = ((Tables.TipoConvite)bd).valor.value;
                    ((Data.TipoConvite)input).modeloTermo = ((Tables.TipoConvite)bd).modeloTermo.value;
                    ((Data.TipoConvite)input).idadeInicialFinalDisplay = String.Format("{0} / {1}", ((Tables.TipoConvite)bd).idadeInicial.value, ((Tables.TipoConvite)bd).idadeFinal.value);

                    ((Data.TipoConvite)input).departamento = new Data.Departamento
                    {
                        idDepartamento = ((Tables.TipoConvite)bd).departamento.idDepartamento.value,
                        descricao = ((Tables.TipoConvite)bd).departamento.descricao.value,
                        idEmpresa = ((Tables.TipoConvite)bd).departamento.idEmpresa.value
                    };
                    ((Data.TipoConvite)input).naturezaOperacao = new Data.NaturezaOperacao
                    {
                        idNaturezaOperacao = ((Tables.TipoConvite)bd).naturezaOperacao.idNaturezaOperacao.value,
                        descricao = ((Tables.TipoConvite)bd).naturezaOperacao.descricao.value,
                        idEmpresa = ((Tables.TipoConvite)bd).naturezaOperacao.idEmpresa.value
                    };
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.TipoConvite result = (Data.TipoConvite)parametros["Key"];

            try
            {
                result = (Data.TipoConvite)this.preencher
                (
                    new Data.TipoConvite(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.TipoConvite),
                        new Object[]
                        {
                            result.idTipoConvite
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
            Data.TipoConvite input = (Data.TipoConvite)parametros["Key"];
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
                    typeof(Tables.TipoConvite),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.TipoConvite _data in
                    (System.Collections.Generic.List<Tables.TipoConvite>)this.m_EntityManager.list
                    (
                        typeof(Tables.TipoConvite),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    if (mode == "Roll")
                    {
                        _base = new Data.TipoConvite();
                        ((Data.TipoConvite)_base).idTipoConvite = _data.idTipoConvite.value;
                        ((Data.TipoConvite)_base).descricao = _data.descricao.value;
                        ((Data.TipoConvite)_base).idadeInicial = _data.idadeInicial.value;
                        ((Data.TipoConvite)_base).idadeFinal = _data.idadeFinal.value;
                        ((Data.TipoConvite)_base).valor = _data.valor.value;
                        ((Data.TipoConvite)_base).idadeFinal = _data.idadeFinal.value;
                        ((Data.TipoConvite)_base).modeloTermo = _data.modeloTermo.value;
                        ((Data.TipoConvite)_base).idadeInicialFinalDisplay = String.Format("{0} / {1}", _data.idadeInicial.value, _data.idadeFinal.value);
                        ((Data.TipoConvite)_base).departamento = new Data.Departamento
                        {
                            idDepartamento = _data.departamento.idDepartamento.value,
                            descricao = _data.departamento.descricao.value,
                            idEmpresa = _data.departamento.idEmpresa.value
                        };
                        ((Data.TipoConvite)_base).naturezaOperacao = new Data.NaturezaOperacao
                        {
                            idNaturezaOperacao = _data.naturezaOperacao.idNaturezaOperacao.value,
                            descricao = _data.naturezaOperacao.descricao.value,
                            idEmpresa = _data.naturezaOperacao.idEmpresa.value
                        };
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.TipoConvite(), _data, level);

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

            Data.TipoConvite _input = (Data.TipoConvite)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idTipoConvite > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tipoConvite.idTipoConvite = @idTipoConvite");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTipoConvite", _input.idTipoConvite));
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoConvite.idTipoConvite");
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tipoConvite.descricao LIKE @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", "%" + _input.descricao + "%"));
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoConvite.descricao");
                }
                else { }
                if (_input.idadeInicial > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tipoConvite.idadeInicial = @idadeInicial");
                    fieldKeys.Add(new EJB.TableBase.TFieldDouble("idadeInicial", _input.idadeInicial));
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoConvite.idadeInicial");
                }

                if (_input.idadeFinal > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tipoConvite.idadeFinal = @idadeFinal");
                    fieldKeys.Add(new EJB.TableBase.TFieldDouble("idadeFinal", _input.idadeFinal));
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoConvite.idadeFinal");
                }

                if (_input.naturezaOperacao != null)
                {

                    if (_input.naturezaOperacao.idNaturezaOperacao > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tipoConvite.idNaturezaOperacao = @idNaturezaOperacao");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idNaturezaOperacao", _input.naturezaOperacao.idNaturezaOperacao));
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoConvite.idNaturezaOperacao");
                    }
                }

                if (_input.departamento != null)
                {

                    if (_input.departamento.idDepartamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tipoConvite.idDepartamento = @idDepartamento");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamento", _input.departamento.idDepartamento));
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoConvite.idDepartamento");
                    }
                }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "tipoConvite.* ") +
                    "from " +
                    (
                        "   tipoConvite tipoConvite "
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
