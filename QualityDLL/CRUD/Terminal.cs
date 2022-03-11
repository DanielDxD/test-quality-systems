using DataTypes;
using System;

namespace WS.CRUD
{
    public class Terminal : WS.CRUD.Base
    {
        public Terminal(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Terminal input = (Data.Terminal)parametros["Key"];
            Tables.Terminal bd = new Tables.Terminal();

            bd.idTerminal.isNull = true;
            bd.descricao.value = input.descricao;
            bd.numeroTerminal.value = input.numeroTerminal;
            bd.departamento.idDepartamento.value = input.departamento.idDepartamento;

            this.m_EntityManager.persist(bd);

            ((Data.Terminal)parametros["Key"]).idTerminal = (int)bd.idTerminal.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Terminal input = (Data.Terminal)parametros["Key"];
            Tables.Terminal bd = (Tables.Terminal)this.m_EntityManager.find
            (
                typeof(Tables.Terminal),
                new Object[]
                {
                    (int)input.idTerminal,
                }
            );



            bd.descricao.value = input.descricao;
            bd.numeroTerminal.value = input.numeroTerminal;
            bd.departamento.idDepartamento.value = input.departamento.idDepartamento;

            this.m_EntityManager.merge(bd);
            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Terminal bd = new Tables.Terminal();

            bd.idTerminal.value = (int)((Data.Terminal)parametros["Key"]).idTerminal;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Terminal)bd).idTerminal.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Terminal)input).operacao = ENum.eOperacao.NONE;
                    ((Data.Terminal)input).idTerminal = ((Tables.Terminal)bd).idTerminal.value;
                    ((Data.Terminal)input).descricao = ((Tables.Terminal)bd).descricao.value;

                    ((Data.Terminal)input).departamento = (Data.Departamento)(new WS.CRUD.Departamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Departamento(),
                        ((Tables.Terminal)bd).departamento,
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
            Data.Terminal result = (Data.Terminal)parametros["Key"];

            try
            {
                result = (Data.Terminal)this.preencher
                (
                    new Data.Terminal(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Terminal),
                        new Object[]
                        {
                            result.idTerminal,
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
            Data.Terminal input = (Data.Terminal)parametros["Key"];
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
                    typeof(Tables.Terminal),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Terminal _data in
                    (System.Collections.Generic.List<Tables.Terminal>)this.m_EntityManager.list
                    (
                        typeof(Tables.Terminal),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.Terminal(), _data, level);

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

            Data.Terminal _input = (Data.Terminal)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                //sqlWhere = (sqlWhere.Contains("'") ? sqlWhere.Replace("'", "''") : sqlWhere);

                if (_input.idTerminal > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Terminal.idTerminal = @idTerminal");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTerminal", _input.idTerminal));
                    if (!sqlOrderBy.Contains("Terminal.idTerminal"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Terminal.idTerminal");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Terminal.descricao = @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao));
                    if (!sqlOrderBy.Contains("Terminal.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Terminal.descricao");
                    else { }
                }
                else { }



                if (_input.departamento != null)
                {
                    if (_input.departamento.idDepartamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Terminal.idDepartamento = @idDepartamento");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamento", _input.departamento.idDepartamento));
                        if (!sqlOrderBy.Contains("Terminal.idDepartamento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Terminal.idDepartamento");
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "Terminal.* ") +
                    "from " +
                    (
                        "   Terminal Terminal " +
                        " LEFT JOIN departamento ON departamento.idDepartamento = Terminal.idDepartamento \n"
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
