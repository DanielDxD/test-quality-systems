using System;

namespace WS.CRUD
{
    public class TipoRelacionamento : WS.CRUD.Base
    {
        public TipoRelacionamento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.TipoRelacionamento input = (Data.TipoRelacionamento)parametros["Key"];
            Tables.TipoRelacionamento bd = new Tables.TipoRelacionamento();

            bd.idTipoRelacionamento.isNull = true;
            bd.descricao.value = input.descricao;
            bd.pfpj.value = input.pfpj;
            if (input.estadoCivil != null)
                bd.estadoCivil.idEstadoCivil.value = input.estadoCivil.idEstadoCivil;
            else
                bd.estadoCivil.idEstadoCivil.isNull = true;

            bd.presidente.value = input.presidente;

            this.m_EntityManager.persist(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.TipoRelacionamento input = (Data.TipoRelacionamento)parametros["Key"];
            Tables.TipoRelacionamento bd = (Tables.TipoRelacionamento)this.m_EntityManager.find
            (
                typeof(Tables.TipoRelacionamento),
                new Object[]
                {
                    input.idTipoRelacionamento
                }
            );

            bd.descricao.value = input.descricao;
            bd.pfpj.value = input.pfpj;
            if (input.estadoCivil != null)
                bd.estadoCivil.idEstadoCivil.value = input.estadoCivil.idEstadoCivil;
            else
                bd.estadoCivil.idEstadoCivil.isNull = true;

            bd.presidente.value = input.presidente;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.TipoRelacionamento bd = new Tables.TipoRelacionamento();

            bd.idTipoRelacionamento.value = ((Data.TipoRelacionamento)parametros["Key"]).idTipoRelacionamento;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.TipoRelacionamento)bd).idTipoRelacionamento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.TipoRelacionamento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.TipoRelacionamento)input).idTipoRelacionamento = ((Tables.TipoRelacionamento)bd).idTipoRelacionamento.value;
                    ((Data.TipoRelacionamento)input).descricao = ((Tables.TipoRelacionamento)bd).descricao.value;
                    ((Data.TipoRelacionamento)input).pfpj = ((Tables.TipoRelacionamento)bd).pfpj.value;
                    ((Data.TipoRelacionamento)input).presidente = ((Tables.TipoRelacionamento)bd).presidente.value;
                    ((Data.TipoRelacionamento)input).estadoCivil = (Data.EstadoCivil)(new WS.CRUD.EstadoCivil(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.EstadoCivil(),
                        ((Tables.TipoRelacionamento)bd).estadoCivil,
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
            Data.TipoRelacionamento result = (Data.TipoRelacionamento)parametros["Key"];

            try
            {
                result = (Data.TipoRelacionamento)this.preencher
                (
                    new Data.TipoRelacionamento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.TipoRelacionamento),
                        new Object[]
                        {
                            result.idTipoRelacionamento
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

            if (_params != null)
            {
                if (_params.ContainsKey("numRows"))
                    numRows = (int)_params["numRows"];
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

            Data.TipoRelacionamento _input = (Data.TipoRelacionamento)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                sqlWhere = "";

                if (_input.idTipoRelacionamento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tipoRelacionamento.idTipoRelacionamento = @idTipoRelacionamento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTipoRelacionamento", _input.idTipoRelacionamento));
                    if (!sqlOrderBy.Contains("tipoRelacionamento.idTipoRelacionamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoRelacionamento.idTipoRelacionamento");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   tipoRelacionamento.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("tipoRelacionamento.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoRelacionamento.descricao");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   tipoRelacionamento.* " +
                    "from " +
                    "   tipoRelacionamento " +
                    (sqlWhere.Length > 0 ? " where " + sqlWhere : "") +
                    (sqlOrderBy.Length > 0 ? " order by " + sqlOrderBy : "") +
                    (((numRows > 0) && (offSet >= 0)) ? " offset " + offSet + " rows fetch next " + numRows + " rows only" : "")
                );

                table = null;
            }
            else { }

            return result;
        }

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.TipoRelacionamento input = (Data.TipoRelacionamento)parametros["Key"];
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
                    typeof(Tables.TipoRelacionamento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.TipoRelacionamento _data in
                    (System.Collections.Generic.List<Tables.TipoRelacionamento>)this.m_EntityManager.list
                    (
                        typeof(Tables.TipoRelacionamento),
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
                    _base = (Data.Base)this.preencher(new Data.TipoRelacionamento(), _data, level);

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
