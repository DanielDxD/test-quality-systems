using System;

namespace WS.CRUD
{
    public class ContratoTurma : WS.CRUD.Base
    {
        public ContratoTurma(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ContratoTurma input = (Data.ContratoTurma)parametros["Key"];
            Tables.ContratoTurma bd = new Tables.ContratoTurma();

            bd.idContratoTurma.isNull = true;
            bd.modalidadeEsportivaTurma.idModalidadeEsportivaTurma.value = input.modalidadeEsportivaTurma.idModalidadeEsportivaTurma;
            bd.contrato.idContrato.value = input.contrato.idContrato;

            this.m_EntityManager.persist(bd);

            ((Data.ContratoTurma)parametros["Key"]).idContratoTurma = (int)bd.idContratoTurma.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ContratoTurma input = (Data.ContratoTurma)parametros["Key"];
            Tables.ContratoTurma bd = (Tables.ContratoTurma)this.m_EntityManager.find
            (
                typeof(Tables.ContratoTurma),
                new Object[]
                {
                    input.idContratoTurma
                }
            );

            bd.modalidadeEsportivaTurma.idModalidadeEsportivaTurma.value = input.modalidadeEsportivaTurma.idModalidadeEsportivaTurma;
            bd.contrato.idContrato.value = input.contrato.idContrato;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ContratoTurma bd = new Tables.ContratoTurma();

            bd.idContratoTurma.value = ((Data.ContratoTurma)parametros["Key"]).idContratoTurma;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ContratoTurma)bd).idContratoTurma.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ContratoTurma)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ContratoTurma)input).idContratoTurma = ((Tables.ContratoTurma)bd).idContratoTurma.value;
                    ((Data.ContratoTurma)input).modalidadeEsportivaTurma = (Data.ModalidadeEsportivaTurma)(new WS.CRUD.ModalidadeEsportivaTurma(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ModalidadeEsportivaTurma(),
                        ((Tables.ContratoTurma)bd).modalidadeEsportivaTurma,
                        level + 1
                    );
                    ((Data.ContratoTurma)input).contrato = (Data.Contrato)(new WS.CRUD.Contrato(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Contrato(),
                        ((Tables.ContratoTurma)bd).contrato,
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
            Data.ContratoTurma result = (Data.ContratoTurma)parametros["Key"];

            try
            {
                result = (Data.ContratoTurma)this.preencher
                (
                    new Data.ContratoTurma(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ContratoTurma),
                        new Object[]
                        {
                            result.idContratoTurma
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

            Data.ContratoTurma _input = (Data.ContratoTurma)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idContratoTurma > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "ContratoTurma.idContratoTurma = @idContratoTurma");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContratoTurma", _input.idContratoTurma));
                    if (!sqlOrderBy.Contains("ContratoTurma.idContratoTurma"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ContratoTurma.idContratoTurma");
                    else { }
                }
                else { }

                if (_input.contrato != null)
                {

                    if (_input.contrato.idContrato > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   ContratoTurma.idContrato = @idContrato");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContrato", _input.contrato.idContrato));
                        if (!sqlOrderBy.Contains("ContratoTurma.idContrato"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ContratoTurma.idContrato");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.modalidadeEsportivaTurma != null)
                {

                    if (_input.modalidadeEsportivaTurma.idModalidadeEsportivaTurma > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   ContratoTurma.idModalidadeEsportivaTurma = @idModalidadeEsportivaTurma");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idModalidadeEsportivaTurma", _input.modalidadeEsportivaTurma.idModalidadeEsportivaTurma));
                        if (!sqlOrderBy.Contains("ContratoTurma.idModalidadeEsportivaTurma"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ContratoTurma.idModalidadeEsportivaTurma");
                        else { }
                    }
                    else { }
                }
                else { }



                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   ContratoTurma.*\n" +
                    "from \n" + 
                    "   ContratoTurma\n" +
                    "inner join contrato contrato" +
                    "   on contrato.idContrato = ContratoTurma.idContrato\n" +
                    "inner join modalidadeEsportivaTurma modalidadeEsportivaTurma" +
                    "   on contrato.idModalidadeEsportivaTurma = modalidadeEsportivaTurma.idModalidadeEsportivaTurma\n" +
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
            Data.ContratoTurma input = (Data.ContratoTurma)parametros["Key"];
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
                    typeof(Tables.ContratoTurma),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ContratoTurma _data in
                    (System.Collections.Generic.List<Tables.ContratoTurma>)this.m_EntityManager.list
                    (
                        typeof(Tables.ContratoTurma),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.ContratoTurma(), _data, level);
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
