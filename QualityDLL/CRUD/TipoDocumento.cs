using System;

namespace WS.CRUD
{
    public class TipoDocumento : WS.CRUD.Base
    {
        public TipoDocumento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.TipoDocumento input = (Data.TipoDocumento)parametros["Key"];
            Tables.TipoDocumento bd = new Tables.TipoDocumento();

            bd.idTipoDocumento.isNull = true;
            bd.descricao.value = input.descricao;
            bd.cheque.value = (input.cheque ? "S" : "N");
            bd.dinheiro.value = (input.dinheiro ? "S" : "N");

            this.m_EntityManager.persist(bd);

            ((Data.TipoDocumento)parametros["Key"]).idTipoDocumento = (int)bd.idTipoDocumento.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.TipoDocumento input = (Data.TipoDocumento)parametros["Key"];
            Tables.TipoDocumento bd = (Tables.TipoDocumento)this.m_EntityManager.find
            (
                typeof(Tables.TipoDocumento),
                new Object[]
                {
                    input.idTipoDocumento
                }
            );

            bd.descricao.value = input.descricao;
            bd.cheque.value = (input.cheque ? "S" : "N");
            bd.dinheiro.value = (input.dinheiro ? "S" : "N");

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.TipoDocumento bd = new Tables.TipoDocumento();

            bd.idTipoDocumento.value = ((Data.TipoDocumento)parametros["Key"]).idTipoDocumento;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.TipoDocumento)bd).idTipoDocumento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.TipoDocumento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.TipoDocumento)input).idTipoDocumento = ((Tables.TipoDocumento)bd).idTipoDocumento.value;
                    ((Data.TipoDocumento)input).descricao = ((Tables.TipoDocumento)bd).descricao.value;
                    ((Data.TipoDocumento)input).cheque = (((Tables.TipoDocumento)bd).cheque.value == "S");
                    ((Data.TipoDocumento)input).dinheiro = (((Tables.TipoDocumento)bd).dinheiro.value == "S");
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.TipoDocumento result = (Data.TipoDocumento)parametros["Key"];

            try
            {
                result = (Data.TipoDocumento)this.preencher
                (
                    new Data.TipoDocumento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.TipoDocumento),
                        new Object[]
                        {
                            result.idTipoDocumento
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

            Data.TipoDocumento _input = (Data.TipoDocumento)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idTipoDocumento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tipoDocumento.idTipoDocumento = @idTipoDocumento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTipoDocumento", _input.idTipoDocumento));
                    if (!sqlOrderBy.Contains("tipoDocumento.idTipoDocumento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoDocumento.idTipoDocumento");
                    else { }
                }
                else { }


                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   tipoDocumento.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("tipoDocumento.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoDocumento.descricao");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   tipoDocumento.*\n" +
                    "from \n" + 
                    "   tipoDocumento\n" +
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
            Data.TipoDocumento input = (Data.TipoDocumento)parametros["Key"];
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
                    typeof(Tables.TipoDocumento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.TipoDocumento _data in
                    (System.Collections.Generic.List<Tables.TipoDocumento>)this.m_EntityManager.list
                    (
                        typeof(Tables.TipoDocumento),
                        _select.Replace("order by idTipoDocumento", "order by descricao, idTipoDocumento"),
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.TipoDocumento(), _data, level);

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
