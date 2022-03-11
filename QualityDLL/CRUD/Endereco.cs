using System;

namespace WS.CRUD
{
    public class Endereco : WS.CRUD.Base
    {
        public Endereco(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Endereco input = (Data.Endereco)parametros["Key"];
            Tables.Endereco bd = new Tables.Endereco();

            bd.idEndereco.isNull = true;
            bd.cep.value = input.cep;
            if ((input.cidade != null) && (input.cidade.idCidade > 0))
                bd.cidade.idCidade.value = input.cidade.idCidade;
            else { }
            if ((input.bairro != null) && (input.bairro.idBairro > 0))
                bd.bairro.idBairro.value = input.bairro.idBairro;
            else { }
            if ((input.logradouro != null) && (input.logradouro.idLogradouro > 0))
                bd.logradouro.idLogradouro.value = input.logradouro.idLogradouro;
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.Endereco)parametros["Key"]).idEndereco = (int)bd.idEndereco.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Endereco input = (Data.Endereco)parametros["Key"];
            Tables.Endereco bd = (Tables.Endereco)this.m_EntityManager.find
            (
                typeof(Tables.Endereco),
                new Object[]
                {
                    input.idEndereco
                }
            );

            bd.cep.value = input.cep;
            if ((input.cidade != null) && (input.cidade.idCidade > 0))
                bd.cidade.idCidade.value = input.cidade.idCidade;
            else { }
            if ((input.bairro != null) && (input.bairro.idBairro > 0))
                bd.bairro.idBairro.value = input.bairro.idBairro;
            else
            {
                if (input.bairro.idBairro == 0)
                    bd.bairro.idBairro.isNull = true;
                else { }
            }
            if ((input.logradouro != null) && (input.logradouro.idLogradouro > 0))
                bd.logradouro.idLogradouro.value = input.logradouro.idLogradouro;
            else
            {
                if (input.bairro.idBairro == 0)
                    bd.logradouro.idLogradouro.isNull = true;
                else { }
            }

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Endereco bd = new Tables.Endereco();

            bd.idEndereco.value = ((Data.Endereco)parametros["Key"]).idEndereco;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Endereco)bd).idEndereco.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Endereco)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Endereco)input).idEndereco = ((Tables.Endereco)bd).idEndereco.value;
                    ((Data.Endereco)input).cep = ((Tables.Endereco)bd).cep.value;
                    ((Data.Endereco)input).cidade = (Data.Cidade)(new WS.CRUD.Cidade(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Cidade(),
                        ((Tables.Endereco)bd).cidade,
                        level + 1
                    );
                    ((Data.Endereco)input).bairro = (Data.Bairro)(new WS.CRUD.Bairro(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Bairro(),
                        ((Tables.Endereco)bd).bairro,
                        level + 1
                    );
                    ((Data.Endereco)input).logradouro = (Data.Logradouro)(new WS.CRUD.Logradouro(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Logradouro(),
                        ((Tables.Endereco)bd).logradouro,
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

            /*Consultar Diferente */
            Data.Endereco result = (Data.Endereco)parametros["Key"];

            String queryString = "";

            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();
                string whereKeys = "";

                if (result.idEndereco > 0)
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEndereco", result.idEndereco));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "endereco.idEndereco = @idEndereco";
                }
                else { }

                if (result.cep > 0)
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("cep", result.cep));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "endereco.cep = @cep";
                }
                else { }

                queryString =
                (
                    "select top 1\n" +
                    "    *\n" +
                    "from \n" + 
                    "    endereco endereco\n" +
                    "        left join cidade cidade \n" +
                    "            on	cidade.idCidade = endereco.idCidade\n" +
                    "        left join bairro bairro\n" +
                    "            on	bairro.idBairro = endereco.idBairro\n" +
                    "        left join logradouro logradouro\n" +
                    "            on	logradouro.idLogradouro = endereco.idLogradouro\n" +
                    (
                        (whereKeys.Length > 0) ?
                        (
                            "where\n" +
                            "    " + whereKeys + "\n"
                        ) :
                        ""
                    )
                );

                foreach
                (
                    Tables.Endereco _data in
                    (System.Collections.Generic.List<Tables.Endereco>)this.m_EntityManager.list
                    (
                        typeof(Tables.Endereco),
                        queryString,
                        fieldKeys.ToArray()
                    )
                )
                {
                    result = (Data.Endereco)this.preencher
                    (
                        new Data.Endereco(),
                        _data,
                        0
                    );
                }
            }
            catch (Exception e)
            {
                Utils.Utils.WriteLog(this.GetType().ToString() + ".consultar() -> " + e.ToString() + "[" + queryString + "]");
                throw new Exception(e.Message);
            }

            return result;

            /*

            Data.Endereco result = (Data.Endereco)parametros["Key"];

            try
            {
                result = (Data.Endereco)this.preencher
                (
                    new Data.Endereco(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Endereco),
                        new Object[]
                        {
                            result.idEndereco
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
            */
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

            Data.Endereco _input = (Data.Endereco)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idEndereco > 0)
                {
                    sqlWhere += (sqlWhere.Length > 0 ? " and" : "") + " endereco.idEndereco = @idEndereco";
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEndereco", _input.idEndereco));
                    if (!sqlOrderBy.Contains("endereco.idEndereco"))
                        sqlOrderBy += (sqlOrderBy.Length > 0 ? ", " : "") + " endereco.idEndereco";
                    else { }
                }
                else { }

                if (_input.cep > 0)
                {
                    sqlWhere += (sqlWhere.Length > 0 ? " and" : "") + " endereco.cep = @cep";
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("cep", _input.cep));
                    if (!sqlOrderBy.Contains("endereco.cep"))
                        sqlOrderBy += (sqlOrderBy.Length > 0 ? ", " : "") + " endereco.cep";
                    else { }
                }
                else { }

                if (_input.bairro != null)
                {
                    if (_input.bairro.idBairro > 0)
                    {
                        sqlWhere += (sqlWhere.Length > 0 ? " and" : "") + " bairro.idBairro = @idBairro";
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idBairro", _input.bairro.idBairro));
                        if (!sqlOrderBy.Contains("bairro.idBairro"))
                            sqlOrderBy += (sqlOrderBy.Length > 0 ? ", " : "") + " bairro.idBairro";
                        else { }
                    }
                    else { }

                    if ((_input.bairro.descricao != null) && (_input.bairro.descricao.Length > 0))
                    {
                        sqlWhere += (sqlWhere.Length > 0 ? " and" : "") + " bairro.descricao COLLATE Latin1_General_CI_AI like @descricaoBairro COLLATE Latin1_General_CI_AI";
                        fieldKeys.Add(new EJB.TableBase.TFieldString("descricaoBairro", _input.bairro.descricao + '%'));
                        if (!sqlOrderBy.Contains("bairro.descricao"))
                            sqlOrderBy += (sqlOrderBy.Length > 0 ? ", " : "") + " bairro.descricao";
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.cidade != null)
                {
                    if (_input.cidade.idCidade > 0)
                    {
                        sqlWhere += (sqlWhere.Length > 0 ? " and" : "") + " cidade.idCidade = @idCidade";
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idCidade", _input.cidade.idCidade));
                        if (!sqlOrderBy.Contains("cidade.idCidade"))
                            sqlOrderBy += (sqlOrderBy.Length > 0 ? ", " : "") + " cidade.idCidade";
                        else { }
                    }
                    else { }

                    if ((_input.cidade.descricao != null) && (_input.cidade.descricao.Length > 0))
                    {
                        sqlWhere += (sqlWhere.Length > 0 ? " and" : "") + " cidade.descricao COLLATE Latin1_General_CI_AI like @descricaoCidade COLLATE Latin1_General_CI_AI";
                        fieldKeys.Add(new EJB.TableBase.TFieldString("descricaoCidade", _input.cidade.descricao + '%'));
                        if (!sqlOrderBy.Contains("cidade.descricao"))
                            sqlOrderBy += (sqlOrderBy.Length > 0 ? ", " : "") + " cidade.descricao";
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.logradouro != null)
                {
                    if (_input.logradouro.idLogradouro > 0)
                    {
                        sqlWhere += (sqlWhere.Length > 0 ? " and" : "") + " logradouro.idLogradouro = @idLogradouro";
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idLogradouro", _input.logradouro.idLogradouro));
                        if (!sqlOrderBy.Contains("logradouro.idLogradouro"))
                            sqlOrderBy += (sqlOrderBy.Length > 0 ? ", " : "") + " logradouro.idLogradouro";
                        else { }
                    }
                    else { }

                    if ((_input.logradouro.descricao != null) && (_input.logradouro.descricao.Length > 0))
                    {
                        sqlWhere += (sqlWhere.Length > 0 ? " and" : "") + " logradouro.descricao COLLATE Latin1_General_CI_AI like @descricaoLogradouro COLLATE Latin1_General_CI_AI";
                        fieldKeys.Add(new EJB.TableBase.TFieldString("descricaoLogradouro", _input.logradouro.descricao + "%"));
                        if (!sqlOrderBy.Contains("logradouro.descricao"))
                            sqlOrderBy += (sqlOrderBy.Length > 0 ? ", " : "") + " logradouro.descricao";
                        else { }
                    }
                    else { }
                }
                else { }
            }
            else { }

            result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "endereco.* ") +
                "from " +
                    "endereco " +
                        "left join logradouro " +
                            "on  logradouro.idLogradouro = endereco.idLogradouro " +
                        "left join bairro " +
                            "on  bairro.idBairro = endereco.idBairro " +
                        "left join cidade " +
                            "on  cidade.idCidade = endereco.idCidade " +
                (sqlWhere.Length > 0 ? " where " + sqlWhere : "") + " " +
                    (onlyCount ? "" :
                        (sqlOrderBy.Length > 0 ? " order by " + sqlOrderBy : "") +
                        (((numRows > 0) && (offSet >= 0)) ? " offset " + offSet + " rows fetch next " + numRows + " rows only" : "")
                    )
            );

            table = null;

            return result;

        }

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.Endereco input = (Data.Endereco)parametros["Key"];
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
                    typeof(Tables.Endereco),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Endereco _data in
                    (System.Collections.Generic.List<Tables.Endereco>)this.m_EntityManager.list
                    (
                        typeof(Tables.Endereco),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.Endereco(), _data, level);

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
