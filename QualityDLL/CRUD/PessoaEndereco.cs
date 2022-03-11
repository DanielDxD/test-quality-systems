using System;

namespace WS.CRUD
{
    public class PessoaEndereco : WS.CRUD.Base
    {
        public PessoaEndereco(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PessoaEndereco input = (Data.PessoaEndereco)parametros["Key"];
            Tables.PessoaEndereco bd = new Tables.PessoaEndereco();

            bd.pessoaEnderecoContato.idPessoaEnderecoContato.value = input.idPessoaEnderecoContato;
            if ((input.endereco != null) && (input.endereco.idEndereco > 0))
                bd.endereco.idEndereco.value = input.endereco.idEndereco;
            else { }
            if ((input.bairro != null) && (input.bairro.idBairro > 0))
                bd.bairro.idBairro.value = input.bairro.idBairro;
            else
                bd.bairro.idBairro.isNull = true;
            if ((input.logradouro != null) && (input.logradouro.idLogradouro > 0))
                bd.logradouro.idLogradouro.value = input.logradouro.idLogradouro;
            else
                bd.logradouro.idLogradouro.isNull = true;
            bd.numero.value = input.numero;
            bd.complemento.value = input.complemento;

            this.m_EntityManager.persist(bd);

            //Processa PessoaEnderecoFinalidadeEndereco
            if (input.pessoaEnderecoFinalidadeEnderecos != null)
            {
                WS.CRUD.PessoaEnderecoFinalidadeEndereco pessoaEnderecoFinalidadeEnderecoCRUD = new WS.CRUD.PessoaEnderecoFinalidadeEndereco(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.pessoaEnderecoFinalidadeEnderecos.Length; i++)
                {
                    input.pessoaEnderecoFinalidadeEnderecos[i].idPessoaEnderecoContato = bd.pessoaEnderecoContato.idPessoaEnderecoContato.value;
                    _parameters.Add("Key", input.pessoaEnderecoFinalidadeEnderecos[i]);
                    pessoaEnderecoFinalidadeEnderecoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                pessoaEnderecoFinalidadeEnderecoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PessoaEndereco input = (Data.PessoaEndereco)parametros["Key"];
            Tables.PessoaEndereco bd = (Tables.PessoaEndereco)this.m_EntityManager.find
            (
                typeof(Tables.PessoaEndereco),
                new Object[]
                {
                    input.idPessoaEnderecoContato
                }
            );

            bd.pessoaEnderecoContato.idPessoaEnderecoContato.value = input.idPessoaEnderecoContato;
            if ((input.endereco != null) && (input.endereco.idEndereco > 0))
                bd.endereco.idEndereco.value = input.endereco.idEndereco;
            else { }
            bd.numero.value = input.numero;
            bd.complemento.value = input.complemento;
            if ((input.bairro != null) && (input.bairro.idBairro > 0))
                bd.bairro.idBairro.value = input.bairro.idBairro;
            else
                bd.bairro.idBairro.isNull = true;
            if ((input.logradouro != null) && (input.logradouro.idLogradouro > 0))
                bd.logradouro.idLogradouro.value = input.logradouro.idLogradouro;
            else
                bd.logradouro.idLogradouro.isNull = true;

            this.m_EntityManager.merge(bd);

            //Processa PessoaEnderecoFinalidadeEndereco
            if (input.pessoaEnderecoFinalidadeEnderecos != null)
            {
                WS.CRUD.PessoaEnderecoFinalidadeEndereco pessoaEnderecoFinalidadeEnderecoCRUD = new WS.CRUD.PessoaEnderecoFinalidadeEndereco(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.pessoaEnderecoFinalidadeEnderecos.Length; i++)
                {
                    input.pessoaEnderecoFinalidadeEnderecos[i].idPessoaEnderecoContato = bd.pessoaEnderecoContato.idPessoaEnderecoContato.value;
                    _parameters.Add("Key", input.pessoaEnderecoFinalidadeEnderecos[i]);
                    if (input.pessoaEnderecoFinalidadeEnderecos[i].operacao == ENum.eOperacao.NONE)
                        input.pessoaEnderecoFinalidadeEnderecos[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    pessoaEnderecoFinalidadeEnderecoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                pessoaEnderecoFinalidadeEnderecoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PessoaEndereco bd = new Tables.PessoaEndereco();

            bd.pessoaEnderecoContato.idPessoaEnderecoContato.value = ((Data.PessoaEndereco)parametros["Key"]).idPessoaEnderecoContato;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PessoaEndereco)bd).pessoaEnderecoContato.idPessoaEnderecoContato.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PessoaEndereco)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PessoaEndereco)input).idPessoaEnderecoContato = ((Tables.PessoaEndereco)bd).pessoaEnderecoContato.idPessoaEnderecoContato.value;
                    ((Data.PessoaEndereco)input).endereco = (Data.Endereco)(new WS.CRUD.Endereco(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Endereco(),
                        ((Tables.PessoaEndereco)bd).endereco,
                        level + 1
                    );
                    ((Data.PessoaEndereco)input).bairro = (Data.Bairro)(new WS.CRUD.Bairro(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Bairro(),
                        ((Tables.PessoaEndereco)bd).bairro,
                        level + 1
                    );
                    ((Data.PessoaEndereco)input).logradouro = (Data.Logradouro)(new WS.CRUD.Logradouro(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Logradouro(),
                        ((Tables.PessoaEndereco)bd).logradouro,
                        level + 1
                    );
                    ((Data.PessoaEndereco)input).numero = ((Tables.PessoaEndereco)bd).numero.value;
                    ((Data.PessoaEndereco)input).complemento = ((Tables.PessoaEndereco)bd).complemento.value;
                }
                else { }

                {
                    //Preencher PessoaEnderecoFinalidadeEnderecos
                    if (((Tables.PessoaEndereco)bd).pessoaEnderecoFinalidadeEnderecos != null)
                    {
                        System.Collections.Generic.List<Data.PessoaEnderecoFinalidadeEndereco> _list = new System.Collections.Generic.List<Data.PessoaEnderecoFinalidadeEndereco>();

                        foreach (Tables.PessoaEnderecoFinalidadeEndereco _item in ((Tables.PessoaEndereco)bd).pessoaEnderecoFinalidadeEnderecos)
                        {
                            _list.Add
                            (
                                (Data.PessoaEnderecoFinalidadeEndereco)
                                (new WS.CRUD.PessoaEnderecoFinalidadeEndereco(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.PessoaEnderecoFinalidadeEndereco(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.PessoaEndereco)input).pessoaEnderecoFinalidadeEnderecos = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.PessoaEndereco)input).pessoaEnderecoFinalidadeEnderecos != null)
                        {
                            System.Collections.Generic.List<Data.PessoaEnderecoFinalidadeEndereco> _list = new System.Collections.Generic.List<Data.PessoaEnderecoFinalidadeEndereco>();

                            foreach (Data.PessoaEnderecoFinalidadeEndereco _item in ((Data.PessoaEndereco)input).pessoaEnderecoFinalidadeEnderecos)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.PessoaEndereco)input).pessoaEnderecoFinalidadeEnderecos = _list.ToArray();
                            else
                                ((Data.PessoaEndereco)input).pessoaEnderecoFinalidadeEnderecos = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }
                }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PessoaEndereco result = (Data.PessoaEndereco)parametros["Key"];

            try
            {
                result = (Data.PessoaEndereco)this.preencher
                (
                    new Data.PessoaEndereco(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.PessoaEndereco),
                        new Object[]
                        {
                            result.idPessoaEnderecoContato
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

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.PessoaEndereco input = (Data.PessoaEndereco)parametros["Key"];
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
                    typeof(Tables.PessoaEndereco),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.PessoaEndereco _data in
                    (System.Collections.Generic.List<Tables.PessoaEndereco>)this.m_EntityManager.list
                    (
                        typeof(Tables.PessoaEndereco),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    //if (mode == "Roll")
                    //{
                    //_base = new Data.ResultadoConsulta();

                    //if (!_data.codConsCampo.codUsuario.isNull)
                    //{
                    //    ((Data.ResultadoConsulta)_base).codigo = (int)_data.codConsCampo.codUsuario.value;
                    //    ((Data.ResultadoConsulta)_base).descricao =
                    //    (
                    //        _data.descricao.value + "(" + _data.codConsCampo.idCadastro.nome.value + ")"
                    //    );
                    //}
                    //else
                    //{
                    //    ((Data.ResultadoConsulta)_base).codigo = (int)_data.codCarteira.value;
                    //    ((Data.ResultadoConsulta)_base).descricao = _data.descricao.value;
                    //}
                    //}
                    //else
                    _base = (Data.Base)this.preencher(new Data.PessoaEndereco(), _data, level);

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

            Data.PessoaEndereco _input = (Data.PessoaEndereco)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idPessoaEnderecoContato > 0)
                {
                    sqlWhere += (sqlWhere.Length > 0 ? " and" : "") + " pessoaEndereco.idPessoaEnderecoContato = @idPessoaEnderecoContato";
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPessoaEnderecoContato", _input.idPessoaEnderecoContato));
                    if (!sqlOrderBy.Contains("pessoaEndereco.idPessoaEnderecoContato"))
                        sqlOrderBy += (sqlOrderBy.Length > 0 ? ", " : "") + " pessoaEndereco.idPessoaEnderecoContato";
                    else { }
                }
                else { }

                if (_input.endereco != null)
                {
                    if (_input.endereco.idEndereco > 0)
                    {
                        sqlWhere += (sqlWhere.Length > 0 ? " and" : "") + " pessoaEndereco.idEndereco = @idEndereco";
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEndereco", _input.endereco.idEndereco));
                        if (!sqlOrderBy.Contains("pessoaEndereco.idEndereco"))
                            sqlOrderBy += (sqlOrderBy.Length > 0 ? ", " : "") + " pessoaEndereco.idEndereco";
                        else { }
                    }
                }
                else { }
            }
            else { }

            result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "pessoaEndereco.* ") +
                "from " +
                    "pessoaEndereco \n" +
                (sqlWhere.Length > 0 ? " where " + sqlWhere : "") + " " +
                    (onlyCount ? "" :
                        (sqlOrderBy.Length > 0 ? " order by " + sqlOrderBy : "") +
                        (((numRows > 0) && (offSet >= 0)) ? " offset " + offSet + " rows fetch next " + numRows + " rows only" : "")
                    )
            );

            table = null;

            return result;

        }
    }
}
