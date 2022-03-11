using System;

namespace WS.CRUD
{
    public class OperacaoFiscal : WS.CRUD.Base
    {
        public OperacaoFiscal(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.OperacaoFiscal input = (Data.OperacaoFiscal)parametros["Key"];
            Tables.OperacaoFiscal bd = new Tables.OperacaoFiscal();

            bd.idOperacaoFiscal.value = input.idOperacaoFiscal;
            bd.comentario.value = input.comentario;
            bd.produtoServico.value = input.produtoServico;
            bd.descricao.value = input.descricao;

            this.m_EntityManager.persist(bd);

            return input; // this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.OperacaoFiscal input = (Data.OperacaoFiscal)parametros["Key"];
            Tables.OperacaoFiscal bd = (Tables.OperacaoFiscal)this.m_EntityManager.find
            (
                typeof(Tables.OperacaoFiscal),
                new Object[]
                {
                    input.idOperacaoFiscal
                }
            );

            bd.idOperacaoFiscal.value = input.idOperacaoFiscal;
            bd.comentario.value = input.comentario;
            bd.produtoServico.value = input.produtoServico;
            bd.descricao.value = input.descricao;

            this.m_EntityManager.merge(bd);

            return input; // this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.OperacaoFiscal bd = new Tables.OperacaoFiscal();

            bd.idOperacaoFiscal.value = ((Data.OperacaoFiscal)parametros["Key"]).idOperacaoFiscal;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
                if
                (
                    !((Tables.OperacaoFiscal)bd).idOperacaoFiscal.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.OperacaoFiscal)input).operacao = ENum.eOperacao.NONE;

                    ((Data.OperacaoFiscal)input).idOperacaoFiscal = ((Tables.OperacaoFiscal)bd).idOperacaoFiscal.value;
                    ((Data.OperacaoFiscal)input).comentario = ((Tables.OperacaoFiscal)bd).comentario.value;
                    ((Data.OperacaoFiscal)input).produtoServico = ((Tables.OperacaoFiscal)bd).produtoServico.value;
                    ((Data.OperacaoFiscal)input).descricao = ((Tables.OperacaoFiscal)bd).descricao.value;
                }
                else { }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.OperacaoFiscal result = (Data.OperacaoFiscal)parametros["Key"];

            try
            {
                result = (Data.OperacaoFiscal)this.preencher
                (
                    new Data.OperacaoFiscal(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.OperacaoFiscal),
                        new Object[]
                        {
                            result.idOperacaoFiscal
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

            Data.OperacaoFiscal _input = (Data.OperacaoFiscal)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idOperacaoFiscal > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "operacaoFiscal.idOperacaoFiscal = @idOperacaoFiscal");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idOperacaoFiscal", _input.idOperacaoFiscal));
                    if (!sqlOrderBy.Contains("operacaoFiscal.idOperacaoFiscal"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "operacaoFiscal.idOperacaoFiscal");
                    else { }
                }
                else { }


                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   operacaoFiscal.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("operacaoFiscal.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "operacaoFiscal.descricao");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   operacaoFiscal.*\n" +
                    "from \n" + 
                    "   operacaoFiscal\n" +
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
            Data.OperacaoFiscal input = (Data.OperacaoFiscal)parametros["Key"];
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
                    typeof(Tables.OperacaoFiscal),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.OperacaoFiscal _data in
                    (System.Collections.Generic.List<Tables.OperacaoFiscal>)this.m_EntityManager.list
                    (
                        typeof(Tables.OperacaoFiscal),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.OperacaoFiscal(), _data, level);

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
