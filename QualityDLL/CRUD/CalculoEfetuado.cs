using System;

namespace WS.CRUD
{
    public class CalculoEfetuado : WS.CRUD.Base
    {
        public CalculoEfetuado(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.CalculoEfetuado input = (Data.CalculoEfetuado)parametros["Key"];
            Tables.CalculoEfetuado bd = new Tables.CalculoEfetuado();

            bd.idCalculoEfetuado.isNull = true;
            bd.dataCalculo.value = input.dataCalculo;
            bd.valorApurado.value = input.valorApurado;
            bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;

            this.m_EntityManager.persist(bd);

            ((Data.CalculoEfetuado)parametros["Key"]).idCalculoEfetuado = (int)bd.idCalculoEfetuado.value;
            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.CalculoEfetuado input = (Data.CalculoEfetuado)parametros["Key"];
            Tables.CalculoEfetuado bd = (Tables.CalculoEfetuado)this.m_EntityManager.find
            (
                typeof(Tables.CalculoEfetuado),
                new Object[]
                {
                    input.idCalculoEfetuado
                }
            );
            bd.dataCalculo.value = input.dataCalculo;
            bd.valorApurado.value = input.valorApurado;
            bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;
            this.m_EntityManager.merge(bd);
            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.CalculoEfetuado bd = new Tables.CalculoEfetuado();

            bd.idCalculoEfetuado.value = ((Data.CalculoEfetuado)parametros["Key"]).idCalculoEfetuado;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.CalculoEfetuado)bd).idCalculoEfetuado.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.CalculoEfetuado)input).operacao = ENum.eOperacao.NONE;

                    ((Data.CalculoEfetuado)input).idCalculoEfetuado = ((Tables.CalculoEfetuado)bd).idCalculoEfetuado.value;
                    ((Data.CalculoEfetuado)input).dataCalculo = ((Tables.CalculoEfetuado)bd).dataCalculo.value;
                    ((Data.CalculoEfetuado)input).valorApurado = ((Tables.CalculoEfetuado)bd).valorApurado.value;
                    ((Data.CalculoEfetuado)input).funcionario = (Data.Funcionario)(new WS.CRUD.Funcionario(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Funcionario(),
                        ((Tables.CalculoEfetuado)bd).funcionario,
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
            Data.CalculoEfetuado result = (Data.CalculoEfetuado)parametros["Key"];

            try
            {
                result = (Data.CalculoEfetuado)this.preencher
                (
                    new Data.CalculoEfetuado(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.CalculoEfetuado),
                        new Object[]
                        {
                            result.idCalculoEfetuado
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
            Data.CalculoEfetuado input = (Data.CalculoEfetuado)parametros["Key"];
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
                    typeof(Tables.CalculoEfetuado),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.CalculoEfetuado _data in
                    (System.Collections.Generic.List<Tables.CalculoEfetuado>)this.m_EntityManager.list
                    (
                        typeof(Tables.CalculoEfetuado),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.CalculoEfetuado(), _data, level);

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

            Data.CalculoEfetuado _input = (Data.CalculoEfetuado)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idCalculoEfetuado > 0)
                {
                    sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "CalculoEfetuado.idCalculoEfetuado = @idCalculoEfetuado";
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idCalculoEfetuado", _input.idCalculoEfetuado));
                    if (!sqlOrderBy.Contains("CalculoEfetuado.idCalculoEfetuado"))
                        sqlOrderBy += (sqlOrderBy.Length > 0 ? ", " : "") + "CalculoEfetuado.idCalculoEfetuado";
                    else { }
                }
                else { }

                if (_input.funcionario != null)
                {
                    if (_input.funcionario.idEmpresaRelacionamento > 0)
                    {
                        sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "CalculoEfetuado.idFuncionario = @idFuncionario";
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idFuncionario", _input.funcionario.idEmpresaRelacionamento));
                        if (!sqlOrderBy.Contains("CalculoEfetuado.idFuncionario"))
                            sqlOrderBy += (sqlOrderBy.Length > 0 ? ", " : "") + "CalculoEfetuado.idFuncionario";
                        else { }
                    }
                    else { }
                }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "CalculoEfetuado.* ") +
                    "from " +
                    "   CalculoEfetuado " +

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
    }
}
