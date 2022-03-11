using System;

namespace WS.CRUD
{
    public class Pagina : WS.CRUD.Base
    {
        public Pagina(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Pagina input = (Data.Pagina)parametros["Key"];
            Tables.Pagina bd = new Tables.Pagina();

            bd.idPagina.isNull = true;
            bd.descricao.value = input.descricao;
            bd.pagina.value = input.pagina;
            bd.altura.value = input.altura;
            bd.largura.value = input.largura;
            bd.newLayout.value = input.newLayout;
            bd.gestaoNovo.value = input.gestaoNovo;

            this.m_EntityManager.persist(bd);

            ((Data.Pagina)parametros["Key"]).idPagina = (int)bd.idPagina.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Pagina input = (Data.Pagina)parametros["Key"];
            Tables.Pagina bd = (Tables.Pagina)this.m_EntityManager.find
            (
                typeof(Tables.Pagina),
                new Object[]
                {
                    input.idPagina
                }
            );

            bd.descricao.value = input.descricao;
            bd.pagina.value = input.pagina;
            bd.altura.value = input.altura;
            bd.largura.value = input.largura;
            bd.newLayout.value = input.newLayout;
            bd.gestaoNovo.value = input.gestaoNovo;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Pagina bd = new Tables.Pagina();

            bd.idPagina.value = ((Data.Pagina)parametros["Key"]).idPagina;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Pagina)bd).idPagina.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Pagina)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Pagina)input).idPagina = ((Tables.Pagina)bd).idPagina.value;
                    ((Data.Pagina)input).descricao = ((Tables.Pagina)bd).descricao.value;
                    ((Data.Pagina)input).pagina = ((Tables.Pagina)bd).pagina.value;
                    ((Data.Pagina)input).altura = ((Tables.Pagina)bd).altura.value;
                    ((Data.Pagina)input).largura = ((Tables.Pagina)bd).largura.value;
                    ((Data.Pagina)input).newLayout = ((Tables.Pagina)bd).newLayout.value;
                    ((Data.Pagina)input).gestaoNovo = ((Tables.Pagina)bd).gestaoNovo.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.Pagina result = (Data.Pagina)parametros["Key"];

            try
            {
                result = (Data.Pagina)this.preencher
                (
                    new Data.Pagina(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Pagina),
                        new Object[]
                        {
                            result.idPagina
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

            Data.Pagina _input = (Data.Pagina)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idPagina > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pagina.idPagina = @idPagina");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPagina", _input.idPagina));
                    if (!sqlOrderBy.Contains("pagina.idPagina"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pagina.idPagina");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pagina.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("pagina.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pagina.descricao");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.pagina))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pagina.pagina like @pagina");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("pagina", _input.pagina + "%"));
                    if (!sqlOrderBy.Contains("pagina.pagina"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pagina.pagina");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   pagina.* " +
                    "from " +
                    "   pagina " +
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
            Data.Pagina input = (Data.Pagina)parametros["Key"];
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
                    typeof(Tables.Pagina),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Pagina _data in
                    (System.Collections.Generic.List<Tables.Pagina>)this.m_EntityManager.list
                    (
                        typeof(Tables.Pagina),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.Pagina(), _data, level);

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
