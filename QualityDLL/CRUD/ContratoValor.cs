using System;

namespace WS.CRUD
{
    public class ContratoValor : WS.CRUD.Base
    {
        public ContratoValor(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ContratoValor input = (Data.ContratoValor)parametros["Key"];
            Tables.ContratoValor bd = new Tables.ContratoValor();

            bd.idContratoValor.isNull = true;
            bd.dataInicio.value = input.dataInicio;

            if (input.dataFim.Ticks > 0)
                bd.dataFim.value = input.dataFim;
            else { }
            bd.valor.value = input.valor;
            bd.contrato.idContrato.value = input.contrato.idContrato;

            this.m_EntityManager.persist(bd);

            ((Data.ContratoValor)parametros["Key"]).idContratoValor = (int)bd.idContratoValor.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ContratoValor input = (Data.ContratoValor)parametros["Key"];
            Tables.ContratoValor bd = (Tables.ContratoValor)this.m_EntityManager.find
            (
                typeof(Tables.ContratoValor),
                new Object[]
                {
                    input.idContratoValor
                }
            );

            bd.dataInicio.value = input.dataInicio;

            if (input.dataFim.Ticks > 0)
                bd.dataFim.value = input.dataFim;
            else { }
            bd.valor.value = input.valor;
            bd.contrato.idContrato.value = input.contrato.idContrato;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ContratoValor bd = new Tables.ContratoValor();

            bd.idContratoValor.value = ((Data.ContratoValor)parametros["Key"]).idContratoValor;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ContratoValor)bd).idContratoValor.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ContratoValor)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ContratoValor)input).idContratoValor = ((Tables.ContratoValor)bd).idContratoValor.value;
                    ((Data.ContratoValor)input).dataInicio = ((Tables.ContratoValor)bd).dataInicio.value;
                    ((Data.ContratoValor)input).dataFim = ((Tables.ContratoValor)bd).dataFim.value;
                    ((Data.ContratoValor)input).valor = ((Tables.ContratoValor)bd).valor.value;
                    ((Data.ContratoValor)input).contrato = (Data.Contrato)(new WS.CRUD.Contrato(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Contrato(),
                        ((Tables.ContratoValor)bd).contrato,
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
            Data.ContratoValor result = (Data.ContratoValor)parametros["Key"];

            try
            {
                result = (Data.ContratoValor)this.preencher
                (
                    new Data.ContratoValor(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ContratoValor),
                        new Object[]
                        {
                            result.idContratoValor
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

            Data.ContratoValor _input = (Data.ContratoValor)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idContratoValor > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "ContratoValor.idContratoValor = @idContratoValor");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContratoValor", _input.idContratoValor));
                    if (!sqlOrderBy.Contains("ContratoValor.idContratoValor"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ContratoValor.idContratoValor");
                    else { }
                }
                else { }

                if (_input.contrato != null)
                {

                    if (_input.contrato.idContrato > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   ContratoValor.idContrato = @idContrato");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContrato", _input.contrato.idContrato));
                        if (!sqlOrderBy.Contains("ContratoValor.idContrato"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ContratoValor.idContrato");
                        else { }
                    }
                    else { }             
                }
                else { }
               


                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   ContratoValor.*\n" +
                    "from \n" + 
                    "   ContratoValor\n" +
                    "inner join contrato contrato" +
                    "   on contrato.idContrato = ContratoValor.idContrato\n" +
                    (sqlWhere.Length > 0 ? "where " + sqlWhere : "") + "\n" +
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
            Data.ContratoValor input = (Data.ContratoValor)parametros["Key"];
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
                    typeof(Tables.ContratoValor),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ContratoValor _data in
                    (System.Collections.Generic.List<Tables.ContratoValor>)this.m_EntityManager.list
                    (
                        typeof(Tables.ContratoValor),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.ContratoValor(), _data, level);
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
