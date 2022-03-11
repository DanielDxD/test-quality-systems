using System;
using System.Linq;

namespace WS.CRUD
{
    public class ModalidadeEsportivaTurmaValor : WS.CRUD.Base
    {
        public ModalidadeEsportivaTurmaValor(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ModalidadeEsportivaTurmaValor input = (Data.ModalidadeEsportivaTurmaValor)parametros["Key"];
            Tables.ModalidadeEsportivaTurmaValor bd = new Tables.ModalidadeEsportivaTurmaValor();

            bd.idModalidadeEsportivaTurmaValor.isNull = true;
            bd.modalidadeEsportivaTurma.idModalidadeEsportivaTurma.value = input.modalidadeEsportivaTurma.idModalidadeEsportivaTurma;
            bd.dataInicio.value = input.dataInicio;

            if (input.dataFim.Ticks > 0)
                bd.dataFim.value = input.dataFim;
            else { }
            bd.tipoIntervaloVencimento.value = input.tipoIntervaloVencimento;
            bd.valorSocio.value = input.valorSocio;
            bd.valorNaoSocio.value = input.valorNaoSocio;

            this.m_EntityManager.persist(bd);

            ((Data.ModalidadeEsportivaTurmaValor)parametros["Key"]).idModalidadeEsportivaTurmaValor = (int)bd.idModalidadeEsportivaTurmaValor.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ModalidadeEsportivaTurmaValor input = (Data.ModalidadeEsportivaTurmaValor)parametros["Key"];
            Tables.ModalidadeEsportivaTurmaValor bd = (Tables.ModalidadeEsportivaTurmaValor)this.m_EntityManager.find
            (
                typeof(Tables.ModalidadeEsportivaTurmaValor),
                new Object[]
                {
                    input.idModalidadeEsportivaTurmaValor
                }
            );

            bd.modalidadeEsportivaTurma.idModalidadeEsportivaTurma.value = input.modalidadeEsportivaTurma.idModalidadeEsportivaTurma;
            bd.dataInicio.value = input.dataInicio;

            if (input.dataFim.Ticks > 0)
                bd.dataFim.value = input.dataFim;
            else { }
            bd.tipoIntervaloVencimento.value = input.tipoIntervaloVencimento;
            bd.valorSocio.value = input.valorSocio;
            bd.valorNaoSocio.value = input.valorNaoSocio;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ModalidadeEsportivaTurmaValor bd = new Tables.ModalidadeEsportivaTurmaValor();

            bd.idModalidadeEsportivaTurmaValor.value = ((Data.ModalidadeEsportivaTurmaValor)parametros["Key"]).idModalidadeEsportivaTurmaValor;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ModalidadeEsportivaTurmaValor)bd).idModalidadeEsportivaTurmaValor.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ModalidadeEsportivaTurmaValor)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ModalidadeEsportivaTurmaValor)input).idModalidadeEsportivaTurmaValor = ((Tables.ModalidadeEsportivaTurmaValor)bd).idModalidadeEsportivaTurmaValor.value;
                    ((Data.ModalidadeEsportivaTurmaValor)input).dataInicio = ((Tables.ModalidadeEsportivaTurmaValor)bd).dataInicio.value;
                    ((Data.ModalidadeEsportivaTurmaValor)input).dataFim = ((Tables.ModalidadeEsportivaTurmaValor)bd).dataFim.value;
                    ((Data.ModalidadeEsportivaTurmaValor)input).tipoIntervaloVencimento = ((Tables.ModalidadeEsportivaTurmaValor)bd).tipoIntervaloVencimento.value;
                    ((Data.ModalidadeEsportivaTurmaValor)input).valorSocio = ((Tables.ModalidadeEsportivaTurmaValor)bd).valorSocio.value;
                    ((Data.ModalidadeEsportivaTurmaValor)input).valorNaoSocio = ((Tables.ModalidadeEsportivaTurmaValor)bd).valorNaoSocio.value;
                    ((Data.ModalidadeEsportivaTurmaValor)input).modalidadeEsportivaTurma = (Data.ModalidadeEsportivaTurma)(new WS.CRUD.ModalidadeEsportivaTurma(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ModalidadeEsportivaTurma(),
                        ((Tables.ModalidadeEsportivaTurmaValor)bd).modalidadeEsportivaTurma,
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
            Data.ModalidadeEsportivaTurmaValor result = (Data.ModalidadeEsportivaTurmaValor)parametros["Key"];

            try
            {
                result = (Data.ModalidadeEsportivaTurmaValor)this.preencher
                (
                    new Data.ModalidadeEsportivaTurmaValor(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ModalidadeEsportivaTurmaValor),
                        new Object[]
                        {
                            result.idModalidadeEsportivaTurmaValor
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

            Data.ModalidadeEsportivaTurmaValor _input = (Data.ModalidadeEsportivaTurmaValor)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idModalidadeEsportivaTurmaValor > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "ModalidadeEsportivaTurmaValor.idModalidadeEsportivaTurmaValor = @idModalidadeEsportivaTurmaValor");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idModalidadeEsportivaTurmaValor", _input.idModalidadeEsportivaTurmaValor));
                    if (!sqlOrderBy.Contains("ModalidadeEsportivaTurmaValor.idModalidadeEsportivaTurmaValor"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ModalidadeEsportivaTurmaValor.idModalidadeEsportivaTurmaValor");
                    else { }
                }
                else { }

                if (_input.modalidadeEsportivaTurma != null)
                {

                    if (_input.modalidadeEsportivaTurma.idModalidadeEsportivaTurma > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   ModalidadeEsportivaTurmaValor.idModalidadeEsportivaTurma = @idModalidadeEsportivaTurma");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idModalidadeEsportivaTurma", _input.modalidadeEsportivaTurma.idModalidadeEsportivaTurma));
                        if (!sqlOrderBy.Contains("ModalidadeEsportivaTurmaValor.idModalidadeEsportivaTurma"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ModalidadeEsportivaTurmaValor.idModalidadeEsportivaTurma");
                        else { }
                    }
                    else { }                   
                }
                else { }              


                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   ModalidadeEsportivaTurmaValor.*\n" +
                    "from \n" + 
                    "   ModalidadeEsportivaTurmaValor\n" +
                    "inner join ModalidadeEsportivaTurma ModalidadeEsportivaTurma" +
                    "   on ModalidadeEsportivaTurma.idModalidadeEsportivaTurma = ModalidadeEsportivaTurmaValor.idModalidadeEsportivaTurma\n" +
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
            Data.ModalidadeEsportivaTurmaValor input = (Data.ModalidadeEsportivaTurmaValor)parametros["Key"];
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
                    typeof(Tables.ModalidadeEsportivaTurmaValor),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ModalidadeEsportivaTurmaValor _data in
                    (System.Collections.Generic.List<Tables.ModalidadeEsportivaTurmaValor>)this.m_EntityManager.list
                    (
                        typeof(Tables.ModalidadeEsportivaTurmaValor),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    /*if (mode == "Roll")
                    {
                        _base = new Data.ModalidadeEsportivaTurmaValor();
                        ((Data.ModalidadeEsportivaTurmaValor)_base).idModalidadeEsportivaTurmaValor = _data.idModalidadeEsportivaTurmaValor.value;
                    }
                    else*/
                    _base = (Data.Base)this.preencher(new Data.ModalidadeEsportivaTurmaValor(), _data, level);


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
