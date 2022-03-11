using System;

namespace WS.CRUD
{
    public class OrigemProduto : WS.CRUD.Base
    {
        public OrigemProduto(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.OrigemProduto input = (Data.OrigemProduto)parametros["Key"];
            Tables.OrigemProduto bd = new Tables.OrigemProduto();

            bd.idOrigemProduto.isNull = true;
            bd.descricao.value = input.descricao;
            bd.codigo.value = input.codigo;

            this.m_EntityManager.persist(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.OrigemProduto input = (Data.OrigemProduto)parametros["Key"];
            Tables.OrigemProduto bd = (Tables.OrigemProduto)this.m_EntityManager.find
            (
                typeof(Tables.OrigemProduto),
                new Object[]
                {
                    input.idOrigemProduto
                }
            );

            bd.descricao.value = input.descricao;
            bd.codigo.value = input.codigo;

            this.m_EntityManager.merge(bd);

            return input; // this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.OrigemProduto bd = new Tables.OrigemProduto();

            bd.idOrigemProduto.value = ((Data.OrigemProduto)parametros["Key"]).idOrigemProduto;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
                if
                (
                    !((Tables.OrigemProduto)bd).idOrigemProduto.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.OrigemProduto)input).operacao = ENum.eOperacao.NONE;


                    ((Data.OrigemProduto)input).idOrigemProduto = ((Tables.OrigemProduto)bd).idOrigemProduto.value;
                    ((Data.OrigemProduto)input).descricao = ((Tables.OrigemProduto)bd).descricao.value;
                    ((Data.OrigemProduto)input).codigo = ((Tables.OrigemProduto)bd).codigo.value;

                }
                else { }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.OrigemProduto result = (Data.OrigemProduto)parametros["Key"];

            try
            {
                result = (Data.OrigemProduto)this.preencher
                (
                    new Data.OrigemProduto(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.OrigemProduto),
                        new Object[]
                        {
                            result.idOrigemProduto
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

            Data.OrigemProduto _input = (Data.OrigemProduto)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idOrigemProduto > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "OrigemProduto.idOrigemProduto = @idOrigemProduto");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idOrigemProduto", _input.idOrigemProduto));
                    if (!sqlOrderBy.Contains("OrigemProduto.idOrigemProduto"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "OrigemProduto.idOrigemProduto");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   OrigemProduto.* " +
                    "from " +
                    "   OrigemProduto OrigemProduto " +
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
            Data.OrigemProduto input = (Data.OrigemProduto)parametros["Key"];
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
                    typeof(Tables.OrigemProduto),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;
                System.Collections.Generic.List<Tables.OrigemProduto> results = new System.Collections.Generic.List<Tables.OrigemProduto>();
                results = ((System.Collections.Generic.List<Tables.OrigemProduto>)this.m_EntityManager.list
                    (
                        typeof(Tables.OrigemProduto),
                        _select,
                       _fieldKeys.ToArray()
                    ));

                if (results != null)
                {

                    foreach
                    (
                        Tables.OrigemProduto _data in results

                    )
                    {
                        Data.Base _base = new Data.Base();
                        _base = (Data.Base)this.preencher(new Data.OrigemProduto(), _data, level);

                        if (report != null)
                            report.ProcessRecord(_base);
                        else
                            result.Add(_base);
                    }
                }
                else { }

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
