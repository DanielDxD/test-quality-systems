using System;

namespace WS.CRUD
{
    public class Bairro : WS.CRUD.Base
    {
        public Bairro(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Bairro input = (Data.Bairro)parametros["Key"];
            Tables.Bairro bd = new Tables.Bairro();

            bd.idBairro.isNull = true;
            if (input.cidade != null)
                bd.cidade.idCidade.value = input.cidade.idCidade;
            else { }
            bd.descricao.value = input.descricao;

            this.m_EntityManager.persist(bd);

            ((Data.Bairro)parametros["Key"]).idBairro = (int)bd.idBairro.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Bairro input = (Data.Bairro)parametros["Key"];
            Tables.Bairro bd = (Tables.Bairro)this.m_EntityManager.find
            (
                typeof(Tables.Bairro),
                new Object[]
                {
                    input.idBairro
                }
            );

            if (input.cidade != null)
                bd.cidade.idCidade.value = input.cidade.idCidade;
            else { }
            bd.descricao.value = input.descricao;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Bairro bd = new Tables.Bairro();

            bd.idBairro.value = ((Data.Bairro)parametros["Key"]).idBairro;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Bairro)bd).idBairro.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Bairro)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Bairro)input).idBairro = ((Tables.Bairro)bd).idBairro.value;
                    ((Data.Bairro)input).cidade = (Data.Cidade)(new WS.CRUD.Cidade(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Cidade(),
                        ((Tables.Bairro)bd).cidade,
                        level + 1
                    );
                    ((Data.Bairro)input).descricao = ((Tables.Bairro)bd).descricao.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.Bairro result = (Data.Bairro)parametros["Key"];

            try
            {
                result = (Data.Bairro)this.preencher
                (
                    new Data.Bairro(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Bairro),
                        new Object[]
                        {
                            result.idBairro
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

            Data.Bairro _input = (Data.Bairro)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idBairro > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "bairro.idBairro = @idBairro");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idBairro", _input.idBairro));
                    if (!sqlOrderBy.Contains("bairro.idBairro"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "bairro.idBairro");
                    else { }
                }
                else { }

                if (_input.cidade.idCidade > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   cidade.idCidade = @idCidade");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idCidade", _input.cidade.idCidade));
                    if (!sqlOrderBy.Contains("cidade.idCidade"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "cidade.idCidade");
                    else { }
                }
                else { }

                if ((_input.cidade.descricao != null) && (_input.cidade.descricao.Length > 0))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   cidade.descricao like @descricaoCidade");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricaoCidade", _input.cidade.descricao + "%"));
                    if (!sqlOrderBy.Contains("cidade.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "cidade.descricao");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   bairro.descricao Collate Latin1_General_CI_AI like @descricao Collate Latin1_General_CI_AI");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", "%" + _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("bairro.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "bairro.descricao");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "bairro.* ") +
                    "from\n" +
                    "   bairro bairro\n" +
                    "       inner join cidade cidade \n" +
                    "           on bairro.idCidade = cidade.idCidade \n" +
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

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.Bairro input = (Data.Bairro)parametros["Key"];
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
                    typeof(Tables.Bairro),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Bairro _data in
                    (System.Collections.Generic.List<Tables.Bairro>)this.m_EntityManager.list
                    (
                        typeof(Tables.Bairro),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.Bairro(), _data, level);

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
