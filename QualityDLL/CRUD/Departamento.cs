using System;

namespace WS.CRUD
{
    public class Departamento : WS.CRUD.Base
    {
        public Departamento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Departamento input = (Data.Departamento)parametros["Key"];
            Tables.Departamento bd = new Tables.Departamento();

            bd.idDepartamento.isNull = true;
            bd.descricao.value = input.descricao;
            bd.idEmpresa.value = input.idEmpresa;
            bd.alcada.value = input.alcada;
            bd.armazem.value = input.armazem;
            bd.ativo.value = input.ativo;
            if (input.idDepartamentoPai > 0)
                bd.idDepartamentoPai.value = input.idDepartamentoPai;
            else
                bd.idDepartamentoPai.isNull = true;
            if ((input.planoContas != null) && (input.planoContas.idPlanoContas > 0))
                bd.planoContas.idPlanoContas.value = input.planoContas.idPlanoContas;
            else
                bd.planoContas.idPlanoContas.isNull = true;

            this.m_EntityManager.persist(bd);

            ((Data.Departamento)parametros["Key"]).idDepartamento = (int)bd.idDepartamento.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Departamento input = (Data.Departamento)parametros["Key"];
            Tables.Departamento bd = (Tables.Departamento)this.m_EntityManager.find
            (
                typeof(Tables.Departamento),
                new Object[]
                {
                    input.idDepartamento
                }
            );

            bd.descricao.value = input.descricao;
            bd.idEmpresa.value = input.idEmpresa;
            bd.alcada.value = input.alcada;
            bd.armazem.value = input.armazem;
            bd.ativo.value = input.ativo;
            if (input.idDepartamentoPai > 0)
                bd.idDepartamentoPai.value = input.idDepartamentoPai;
            else
                bd.idDepartamentoPai.isNull = true;
            if ((input.planoContas != null) && (input.planoContas.idPlanoContas > 0))
                bd.planoContas.idPlanoContas.value = input.planoContas.idPlanoContas;
            else
                bd.planoContas.idPlanoContas.isNull = true;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Departamento bd = new Tables.Departamento();

            bd.idDepartamento.value = ((Data.Departamento)parametros["Key"]).idDepartamento;

            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Departamento)bd).idDepartamento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Departamento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Departamento)input).idDepartamento = ((Tables.Departamento)bd).idDepartamento.value;
                    ((Data.Departamento)input).descricao = ((Tables.Departamento)bd).descricao.value;
                    ((Data.Departamento)input).alcada = ((Tables.Departamento)bd).alcada.value;
                    ((Data.Departamento)input).armazem = ((Tables.Departamento)bd).armazem.value;
                    ((Data.Departamento)input).ativo = ((Tables.Departamento)bd).ativo.value;

                    ((Data.Departamento)input).idEmpresa = ((Tables.Departamento)bd).idEmpresa.value;
                    ((Data.Departamento)input).idDepartamentoPai = ((Tables.Departamento)bd).idDepartamentoPai.value;
                    ((Data.Departamento)input).planoContas = (Data.PlanoContas)(new WS.CRUD.PlanoContas(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PlanoContas(),
                        ((Tables.Departamento)bd).planoContas,
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
            Data.Departamento result = (Data.Departamento)parametros["Key"];

            try
            {
                result = (Data.Departamento)this.preencher
                (
                    new Data.Departamento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Departamento),
                        new Object[]
                        {
                            result.idDepartamento
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

            bool
                onlyCount = false;

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

                if (_params.ContainsKey("onlyCount"))
                    onlyCount = (bool)_params["onlyCount"];
                else { }
            }
            else { }

            Data.Departamento _input = (Data.Departamento)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idEmpresa > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "departamento.idEmpresa = @idEmpresa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.idEmpresa));
                    if (!sqlOrderBy.Contains("departamento.idEmpresa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "departamento.idEmpresa");
                    else { }
                }
                else { }

                if (_input.idDepartamento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "departamento.idDepartamento = @idDepartamento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamento", _input.idDepartamento));
                    if (!sqlOrderBy.Contains("departamento.idDepartamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "departamento.idDepartamento");
                    else { }
                }
                else { }

                if (_input.idDepartamentoPai > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "departamento.idDepartamentoPai = @idDepartamentoPai");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamentoPai", _input.idDepartamentoPai));
                    if (!sqlOrderBy.Contains("departamento.idDepartamentoPai"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "departamento.idDepartamentoPai");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   departamento.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("departamento.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "departamento.descricao");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.ativo))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   departamento.ativo = @ativo");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("ativo", _input.ativo));
                    if (!sqlOrderBy.Contains("departamento.ativo"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "departamento.ativo");
                    else { }
                }
                else { }

                if (_input.armazem == true)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "departamento.armazem = @armazem");
                    fieldKeys.Add(new EJB.TableBase.TFieldBoolean("armazem", _input.armazem));
                    if (!sqlOrderBy.Contains("departamento.armazem"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "departamento.armazem");
                    else { }
                }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "departamento.* ") +
                    "from " +
                    "   departamento " +
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
            Data.Departamento input = (Data.Departamento)parametros["Key"];
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
                    typeof(Tables.Departamento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Departamento _data in
                    (System.Collections.Generic.List<Tables.Departamento>)this.m_EntityManager.list
                    (
                        typeof(Tables.Departamento),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.Departamento();
                        ((Data.Departamento)_base).idDepartamento = _data.idDepartamento.value;
                        ((Data.Departamento)_base).descricao = _data.descricao.value;
                        ((Data.Departamento)_base).alcada = _data.alcada.value;
                        ((Data.Departamento)_base).armazem = _data.armazem.value;
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.Departamento(), _data, level);

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
