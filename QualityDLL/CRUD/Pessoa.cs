using System;

namespace WS.CRUD
{
    public class Pessoa : WS.CRUD.Base
    {
        public Pessoa(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Pessoa input = (Data.Pessoa)parametros["Key"];
            Tables.Pessoa bd =
            (
                parametros["Return"] != null ?
                (Tables.Pessoa)parametros["Return"] :
                new Tables.Pessoa()
            );

            bd.idPessoa.isNull = true;
            if (input.pfpj == null)
                if (typeof(Data.PessoaFisica).IsInstanceOfType(input))
                    bd.pfpj.value = "F";
                else
                    bd.pfpj.value = "J";
            else
                bd.pfpj.value = input.pfpj.ToUpper();
            bd.cpfCnpj.value = input.cpfCnpj;

            //Verifica CPF/CNPJ duplicado
            int _idPessoa = 0;

            if (!String.IsNullOrEmpty(input.cpfCnpj))
            {
                try
                {
                    _idPessoa = System.Convert.ToInt32(this.m_EntityManager.executeScalar("select cast(max(idPessoa) as bigint) from pessoa where cpfcnpj=@cpfCnpj and pfpj=@pfpj", new EJB.TableBase.TField[] { bd.cpfCnpj, bd.pfpj }));
                }
                catch { }
            }
            else { }

            if (_idPessoa == 0)
            {
                bd.nomeRazaoSocial.value = input.nomeRazaoSocial;
                bd.apelidoNomeComercial.value = input.apelidoNomeComercial;

                this.m_EntityManager.persist(bd);

                ((Data.Pessoa)parametros["Key"]).idPessoa = (int)bd.idPessoa.value;

                //Processa PessoaEnderecoContato
                if (input.pessoaEnderecoContatos != null)
                {
                    WS.CRUD.PessoaEnderecoContato pessoaEnderecoContatoCRUD = new WS.CRUD.PessoaEnderecoContato(this.m_IdEmpresaCorrente, this.m_EntityManager);
                    System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                    for (int i = 0; i < input.pessoaEnderecoContatos.Length; i++)
                    {
                        input.pessoaEnderecoContatos[i].idPessoa = bd.idPessoa.value;
                        _parameters.Add("Key", input.pessoaEnderecoContatos[i]);
                        pessoaEnderecoContatoCRUD.atualizar(_parameters);

                        _parameters.Clear();
                    }

                    pessoaEnderecoContatoCRUD = null;
                    _parameters = null;
                }
                else { }


                //Processa PessoaRelacionamento
                if (input.pessoaRelacionamentos != null)
                {
                    WS.CRUD.PessoaRelacionamento pessoaRelacionamentoCRUD = new WS.CRUD.PessoaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                    System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                    for (int i = 0; i < input.pessoaRelacionamentos.Length; i++)
                    {
                        input.pessoaRelacionamentos[i].pessoa = new Data.Pessoa();
                        input.pessoaRelacionamentos[i].pessoa.idPessoa = bd.idPessoa.value;
                        _parameters.Add("Key", input.pessoaRelacionamentos[i]);
                        pessoaRelacionamentoCRUD.atualizar(_parameters);

                        _parameters.Clear();
                    }

                    pessoaRelacionamentoCRUD = null;
                    _parameters = null;
                }
                else { }

                //Processa PessoaImagem
                if (input.pessoaImagems != null)
                {
                    WS.CRUD.PessoaImagem pessoaImagemCRUD = new WS.CRUD.PessoaImagem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                    System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                    for (int i = 0; i < input.pessoaImagems.Length; i++)
                    {
                        input.pessoaImagems[i].pessoa = new Data.Pessoa();
                        input.pessoaImagems[i].pessoa.idPessoa = bd.idPessoa.value;
                        _parameters.Add("Key", input.pessoaImagems[i]);
                        pessoaImagemCRUD.atualizar(_parameters);

                        _parameters.Clear();
                    }

                    pessoaImagemCRUD = null;
                    _parameters = null;
                }
                else { }
            }
            else
                throw new Exception("CPF/CNPJ Duplicado");

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Pessoa input = (Data.Pessoa)parametros["Key"];
            Tables.Pessoa bd =
            (
                parametros["Return"] != null ?
                (Tables.Pessoa)parametros["Return"] :
                (Tables.Pessoa)this.m_EntityManager.find
                (
                    typeof(Tables.Pessoa),
                    new Object[]
                    {
                        input.idPessoa
                    }
                )
            );

            bd.pfpj.value = input.pfpj.ToUpper();
            bd.cpfCnpj.value = input.cpfCnpj;

            //Verifica CPF/CNPJ duplicado
            int _idPessoa = 0;

            if (!String.IsNullOrEmpty(input.cpfCnpj))
            {
                try
                {
                    _idPessoa = System.Convert.ToInt32(this.m_EntityManager.executeScalar("select cast(max(idPessoa) as bigint) from pessoa where cpfcnpj=@cpfCnpj and pfpj=@pfpj", new EJB.TableBase.TField[] { bd.cpfCnpj, bd.pfpj }));
                }
                catch { }
            }
            else { }

            if ((_idPessoa == 0) || (_idPessoa == input.idPessoa))
            {
                bd.nomeRazaoSocial.value = input.nomeRazaoSocial;
                bd.apelidoNomeComercial.value = input.apelidoNomeComercial;

                this.m_EntityManager.merge(bd);

                //Processa PessoaEnderecoContato
                if (input.pessoaEnderecoContatos != null)
                {
                    WS.CRUD.PessoaEnderecoContato pessoaEnderecoContatoCRUD = new WS.CRUD.PessoaEnderecoContato(this.m_IdEmpresaCorrente, this.m_EntityManager);
                    System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                    for (int i = 0; i < input.pessoaEnderecoContatos.Length; i++)
                    {
                        input.pessoaEnderecoContatos[i].idPessoa = bd.idPessoa.value;
                        if (input.pessoaEnderecoContatos[i].operacao == ENum.eOperacao.NONE)
                            input.pessoaEnderecoContatos[i].operacao = ENum.eOperacao.ALTERAR;
                        else { }
                        _parameters.Add("Key", input.pessoaEnderecoContatos[i]);
                        pessoaEnderecoContatoCRUD.atualizar(_parameters);

                        _parameters.Clear();
                    }

                    pessoaEnderecoContatoCRUD = null;
                    _parameters = null;
                }
                else { }

                //Processa PessoaRelacionamento
                if (input.pessoaRelacionamentos != null)
                {
                    WS.CRUD.PessoaRelacionamento pessoaRelacionamentoCRUD = new WS.CRUD.PessoaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                    System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                    for (int i = 0; i < input.pessoaRelacionamentos.Length; i++)
                    {
                        input.pessoaRelacionamentos[i].pessoa = new Data.Pessoa();
                        input.pessoaRelacionamentos[i].pessoa.idPessoa = bd.idPessoa.value;
                        _parameters.Add("Key", input.pessoaRelacionamentos[i]);
                        if (input.pessoaRelacionamentos[i].operacao == ENum.eOperacao.NONE)
                            input.pessoaRelacionamentos[i].operacao = ENum.eOperacao.ALTERAR;
                        else { }
                        pessoaRelacionamentoCRUD.atualizar(_parameters);

                        _parameters.Clear();
                    }

                    pessoaRelacionamentoCRUD = null;
                    _parameters = null;
                }
                else { }

                //Processa PessoaImagem
                if (input.pessoaImagems != null)
                {
                    WS.CRUD.PessoaImagem pessoaImagemCRUD = new WS.CRUD.PessoaImagem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                    System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                    for (int i = 0; i < input.pessoaImagems.Length; i++)
                    {
                        input.pessoaImagems[i].pessoa = new Data.Pessoa();
                        input.pessoaImagems[i].pessoa.idPessoa = bd.idPessoa.value;
                        _parameters.Add("Key", input.pessoaImagems[i]);
                        pessoaImagemCRUD.atualizar(_parameters);

                        _parameters.Clear();
                    }

                    pessoaImagemCRUD = null;
                    _parameters = null;
                }
                else { }
            }
            else
                throw new Exception("CPF/CNPJ Duplicado");

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Pessoa bd = new Tables.Pessoa();

            bd.idPessoa.value = ((Data.Pessoa)parametros["Key"]).idPessoa;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Pessoa)bd).idPessoa.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Pessoa)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Pessoa)input).idPessoa = ((Tables.Pessoa)bd).idPessoa.value;
                    ((Data.Pessoa)input).pfpj = ((Tables.Pessoa)bd).pfpj.value;
                    ((Data.Pessoa)input).cpfCnpj = ((Tables.Pessoa)bd).cpfCnpj.value;
                    if (!String.IsNullOrEmpty(((Tables.Pessoa)bd).cpfCnpj.value))
                        if (((Data.Pessoa)input).pfpj == "F")
                            ((Data.Pessoa)input).cpfCnpjFormatado = Convert.ToUInt64(((Tables.Pessoa)bd).cpfCnpj.value).ToString(@"000\.000\.000\-00");
                        else
                            ((Data.Pessoa)input).cpfCnpjFormatado = Convert.ToUInt64(((Tables.Pessoa)bd).cpfCnpj.value).ToString(@"00\.000\.000\/0000\-00");

                    ((Data.Pessoa)input).nomeRazaoSocial = ((Tables.Pessoa)bd).nomeRazaoSocial.value;
                    ((Data.Pessoa)input).apelidoNomeComercial = ((Tables.Pessoa)bd).apelidoNomeComercial.value;

                    if (level < 1)
                    {
                        //Preencher PessoaEnderecoContatos
                        if (((Tables.Pessoa)bd).pessoaEnderecoContatos != null)
                        {
                            System.Collections.Generic.List<Data.PessoaEnderecoContato> _list = new System.Collections.Generic.List<Data.PessoaEnderecoContato>();

                            foreach (Tables.PessoaEnderecoContato _item in ((Tables.Pessoa)bd).pessoaEnderecoContatos)
                            {
                                _list.Add
                                (
                                    (Data.PessoaEnderecoContato)
                                    (new WS.CRUD.PessoaEnderecoContato(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.PessoaEnderecoContato(),
                                        _item,
                                        level + 1
                                    )
                                );
                            }

                            ((Data.Pessoa)input).pessoaEnderecoContatos = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.Pessoa)input).pessoaEnderecoContatos != null)
                            {
                                System.Collections.Generic.List<Data.PessoaEnderecoContato> _list = new System.Collections.Generic.List<Data.PessoaEnderecoContato>();

                                foreach (Data.PessoaEnderecoContato _item in ((Data.Pessoa)input).pessoaEnderecoContatos)
                                {
                                    if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                    {
                                        _item.operacao = ENum.eOperacao.NONE;
                                        _list.Add(_item);
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.Pessoa)input).pessoaEnderecoContatos = _list.ToArray();
                                else
                                    ((Data.Pessoa)input).pessoaEnderecoContatos = null;

                                _list.Clear();
                                _list = null;
                            }
                            else { }
                        }
                    }
                    else { }

                    if (level < 1)
                    {
                        //Preencher PessoaRelacionamentos
                        if (((Tables.Pessoa)bd).pessoaRelacionamentos != null)
                        {
                            System.Collections.Generic.List<Data.PessoaRelacionamento> _list = new System.Collections.Generic.List<Data.PessoaRelacionamento>();

                            foreach (Tables.PessoaRelacionamento _item in ((Tables.Pessoa)bd).pessoaRelacionamentos)
                            {
                                _list.Add
                                (
                                    (Data.PessoaRelacionamento)
                                    (new WS.CRUD.PessoaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.PessoaRelacionamento(),
                                        _item,
                                        level + 1
                                    )
                                );
                            }

                            ((Data.Pessoa)input).pessoaRelacionamentos = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.Pessoa)input).pessoaRelacionamentos != null)
                            {
                                System.Collections.Generic.List<Data.PessoaRelacionamento> _list = new System.Collections.Generic.List<Data.PessoaRelacionamento>();

                                foreach (Data.PessoaRelacionamento _item in ((Data.Pessoa)input).pessoaRelacionamentos)
                                {
                                    if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                    {
                                        _item.operacao = ENum.eOperacao.NONE;
                                        _list.Add(_item);
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.Pessoa)input).pessoaRelacionamentos = _list.ToArray();
                                else
                                    ((Data.Pessoa)input).pessoaRelacionamentos = null;

                                _list.Clear();
                                _list = null;
                            }
                            else { }
                        }
                    }
                    else { }

                    if (level < 1)
                    {
                        //Preencher PessoaImagems
                        if (((Tables.Pessoa)bd).pessoaImagems != null)
                        {
                            System.Collections.Generic.List<Data.PessoaImagem> _list = new System.Collections.Generic.List<Data.PessoaImagem>();

                            foreach (Tables.PessoaImagem _item in ((Tables.Pessoa)bd).pessoaImagems)
                            {
                                _list.Add
                                (
                                    (Data.PessoaImagem)
                                    (new WS.CRUD.PessoaImagem(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.PessoaImagem(),
                                        _item,
                                        level + 1
                                    )
                                );
                            }

                            ((Data.Pessoa)input).pessoaImagems = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.Pessoa)input).pessoaImagems != null)
                            {
                                System.Collections.Generic.List<Data.PessoaImagem> _list = new System.Collections.Generic.List<Data.PessoaImagem>();

                                foreach (Data.PessoaImagem _item in ((Data.Pessoa)input).pessoaImagems)
                                {
                                    if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                    {
                                        _item.operacao = ENum.eOperacao.NONE;
                                        _list.Add(_item);
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.Pessoa)input).pessoaImagems = _list.ToArray();
                                else
                                    ((Data.Pessoa)input).pessoaImagems = null;

                                _list.Clear();
                                _list = null;
                            }
                            else { }
                        }
                    }
                    else { }
                }
                else { }
            }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {

            /*Consultar Diferente */
            Data.Pessoa result = (Data.Pessoa)parametros["Key"];

            String queryString = "";

            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();
                string whereKeys = "";

                if (result.idPessoa > 0)
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPessoa", result.idPessoa));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pessoa.idPessoa = @idPessoa";
                }
                else { }

                if (!String.IsNullOrEmpty(result.nomeRazaoSocial))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldString("nomeRazaoSocial", result.nomeRazaoSocial));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pessoa.nomeRazaoSocial LIKE %@nomeRazaoSocial%";
                }
                else { }

                if (!String.IsNullOrEmpty(result.cpfCnpj))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldString("cpfCnpj", result.cpfCnpj));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pessoa.cpfCnpj = @cpfCnpj";
                }
                else { }

                queryString =
                (
                    "select top 1\n" +
                    "    *\n" +
                    "from \n" +
                    "    pessoa\n" +
                    "        left join pessoaFisica pessoaFisica \n" +
                    "            on	pessoaFisica.idPessoaFisica = pessoa.idPessoa\n" +
                    "        left join pessoaJuridica pessoaJuridica \n" +
                    "            on	pessoaJuridica.idPessoaJuridica = pessoa.idPessoa\n" +
                    (
                        (whereKeys.Length > 0) ?
                        (
                            "where\n" +
                            "    " + whereKeys + "\n"
                        ) :
                        ""
                    ) +
                    "order by\n" +
                    "	pessoa.nomeRazaoSocial\n"
                );

                foreach
                (
                    Tables.Pessoa _data in
                    (System.Collections.Generic.List<Tables.Pessoa>)this.m_EntityManager.list
                    (
                        typeof(Tables.Pessoa),
                        queryString,
                        fieldKeys.ToArray()
                    )
                )
                {
                    result = (Data.Pessoa)this.preencher
                    (
                        new Data.Pessoa(),
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



            /*Data.Pessoa result = (Data.Pessoa)parametros["Key"];

            try
            {
                result = (Data.Pessoa)this.preencher
                (
                    new Data.Pessoa(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Pessoa),
                        new Object[]
                        {
                            result.idPessoa
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

            return result;*/
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

            Data.Pessoa _input = (Data.Pessoa)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idPessoa > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.idPessoa = @idPessoa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPessoa", _input.idPessoa));
                    if (!sqlOrderBy.Contains("pessoa.idPessoa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.idPessoa");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.cpfCnpj))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.cpfCnpj = @cpfCnpj");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("cpfCnpj", _input.cpfCnpj));
                    if (!sqlOrderBy.Contains("pessoa.cpfCnpj"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.cpfCnpj");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.nomeRazaoSocial))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pessoa.nomeRazaoSocial like @nomeRazaoSocial");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("nomeRazaoSocial", _input.nomeRazaoSocial + "%"));
                    if (!sqlOrderBy.Contains("pessoa.nomeRazaoSocial"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.nomeRazaoSocial");
                    else { }
                }


                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   pessoa.* " +
                    "from " +
                    "   pessoa " +
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
            Data.Pessoa input = (Data.Pessoa)parametros["Key"];
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
                    typeof(Tables.Pessoa),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Pessoa _data in
                    (System.Collections.Generic.List<Tables.Pessoa>)this.m_EntityManager.list
                    (
                        typeof(Tables.Pessoa),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.Pessoa(), _data, level);

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
