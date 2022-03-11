using System;

namespace WS.CRUD
{
    public class Pais : WS.CRUD.Base
    {
        public Pais(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Pais input = (Data.Pais)parametros["Key"];
            Tables.Pais bd = new Tables.Pais();

            bd.idPais.isNull = true;
            bd.descricao.value = input.descricao;

            this.m_EntityManager.persist(bd);

            ((Data.Pais)parametros["Key"]).idPais = (int)bd.idPais.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Pais input = (Data.Pais)parametros["Key"];
            Tables.Pais bd = (Tables.Pais)this.m_EntityManager.find
            (
                typeof(Tables.Pais),
                new Object[]
                {
                    input.idPais
                }
            );

            bd.descricao.value = input.descricao;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Pais bd = new Tables.Pais();

            bd.idPais.value = ((Data.Pais)parametros["Key"]).idPais;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Pais)bd).idPais.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Pais)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Pais)input).idPais = ((Tables.Pais)bd).idPais.value;
                    ((Data.Pais)input).descricao = ((Tables.Pais)bd).descricao.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.Pais result = (Data.Pais)parametros["Key"];

            try
            {
                result = (Data.Pais)this.preencher
                (
                    new Data.Pais(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Pais),
                        new Object[]
                        {
                            result.idPais
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

            Data.Pais _input = (Data.Pais)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if(_input.idPais > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pais.idPais = @idPais");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPais", _input.idPais));
                    if (!sqlOrderBy.Contains("pais.idPais"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pais.idPais");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pais.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao + '%'));
                    if (!sqlOrderBy.Contains("pais.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pais.descricao");
                    else { }
                }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "pais.* ") +
                    "from " +
                    "   pais " +
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
            Data.Pais input = (Data.Pais)parametros["Key"];
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

                String _select = this.makeSelect
                (
                    typeof(Tables.Pais),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                foreach
                (
                    Tables.Pais _data in
                    (System.Collections.Generic.List<Tables.Pais>)this.m_EntityManager.list
                    (
                        typeof(Tables.Pais),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.Pais(), _data, level);

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
