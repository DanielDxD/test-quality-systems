using System;

namespace WS.CRUD
{
    public class PessoaFisica : WS.CRUD.Base
    {
        public PessoaFisica(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PessoaFisica input = (Data.PessoaFisica)parametros["Key"];
            Tables.PessoaFisica bd =
            (
                parametros["Return"] != null ?
                (Tables.PessoaFisica)parametros["Return"] :
                new Tables.PessoaFisica()
            );

            //Incluir/Alterar Pessoa
            {
                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                _parametros.Add("Key", input);
                _parametros.Add("Return", bd.pessoa);

                input = (Data.PessoaFisica)(new WS.CRUD.Pessoa(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }

            bd.pessoa.idPessoa.value = input.idPessoa;

            bd.dataNascimento.value = input.dataNascimento;
            bd.sexo.value = input.sexo;
            if ((input.estadoCivil != null) && (input.estadoCivil.idEstadoCivil > 0))
                bd.estadoCivil.idEstadoCivil.value = input.estadoCivil.idEstadoCivil;
            else
                bd.estadoCivil.idEstadoCivil.isNull = true;
            if ((input.escolaridade != null) && (input.escolaridade.idEscolaridade > 0))
                bd.escolaridade.idEscolaridade.value = input.escolaridade.idEscolaridade;
            else
                bd.escolaridade.idEscolaridade.isNull = true;
            bd.rgNumero.value = input.rgNumero;
            bd.rgEmissor.value = input.rgEmissor;
            bd.rgDataEmissao.value = input.rgDataEmissao;
            bd.teNumero.value = input.teNumero;
            bd.teZona.value = input.teZona;
            bd.teSecao.value = input.teSecao;
            bd.cnhNumero.value = input.cnhNumero;
            bd.reservistaNumero.value = input.reservistaNumero;
            if ((input.cidadeNaturalidade != null) && (input.cidadeNaturalidade.idCidade > 0))
                bd.cidadeNaturalidade.idCidade.value = input.cidadeNaturalidade.idCidade;
            else
                bd.cidadeNaturalidade.idCidade.isNull = true;
            if ((input.profissao != null) && (input.profissao.idProfissao > 0))
                bd.profissao.idProfissao.value = input.profissao.idProfissao;
            else
                bd.profissao.idProfissao.isNull = true;
            if ((input.nacionalidade != null) && (input.nacionalidade.idNacionalidade > 0))
                bd.nacionalidade.idNacionalidade.value = input.nacionalidade.idNacionalidade;
            else
                bd.nacionalidade.idNacionalidade.isNull = true;
            bd.profissaoNome.value = input.profissaoNome;
            bd.ctps.value = input.ctps;
            bd.pispasep.value = input.pispasep;

            this.m_EntityManager.persist(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PessoaFisica input = (Data.PessoaFisica)parametros["Key"];
            Tables.PessoaFisica bd =
            (
                parametros["Return"] != null ?
                (Tables.PessoaFisica)parametros["Return"] :
                (Tables.PessoaFisica)this.m_EntityManager.find
                (
                    typeof(Tables.PessoaFisica),
                    new Object[]
                    {
                        input.idPessoa
                    }
                )
            );

            //Alterar Pessoa
            {
                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                _parametros.Add("Key", input);
                _parametros.Add("Return", bd.pessoa);

                input = (Data.PessoaFisica)(new WS.CRUD.Pessoa(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }

            bd.dataNascimento.value = input.dataNascimento;
            bd.sexo.value = input.sexo;
            if ((input.estadoCivil != null) && (input.estadoCivil.idEstadoCivil > 0))
                bd.estadoCivil.idEstadoCivil.value = input.estadoCivil.idEstadoCivil;
            else
                bd.estadoCivil.idEstadoCivil.isNull = true;
            if ((input.escolaridade != null) && (input.escolaridade.idEscolaridade > 0))
                bd.escolaridade.idEscolaridade.value = input.escolaridade.idEscolaridade;
            else
                bd.escolaridade.idEscolaridade.isNull = true;
            bd.rgNumero.value = input.rgNumero;
            bd.rgEmissor.value = input.rgEmissor;
            bd.rgDataEmissao.value = input.rgDataEmissao;
            bd.teNumero.value = input.teNumero;
            bd.teZona.value = input.teZona;
            bd.teSecao.value = input.teSecao;
            bd.cnhNumero.value = input.cnhNumero;
            bd.reservistaNumero.value = input.reservistaNumero;
            if ((input.cidadeNaturalidade != null) && (input.cidadeNaturalidade.idCidade > 0))
                bd.cidadeNaturalidade.idCidade.value = input.cidadeNaturalidade.idCidade;
            else
                bd.cidadeNaturalidade.idCidade.isNull = true;
            if ((input.profissao != null) && (input.profissao.idProfissao > 0))
                bd.profissao.idProfissao.value = input.profissao.idProfissao;
            else
                bd.profissao.idProfissao.isNull = true;
            if ((input.nacionalidade != null) && (input.nacionalidade.idNacionalidade > 0))
                bd.nacionalidade.idNacionalidade.value = input.nacionalidade.idNacionalidade;
            else
                bd.nacionalidade.idNacionalidade.isNull = true;
            bd.profissaoNome.value = input.profissaoNome;
            bd.ctps.value = input.ctps;
            bd.pispasep.value = input.pispasep;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PessoaFisica bd = new Tables.PessoaFisica();

            bd.pessoa.idPessoa.value = ((Data.PessoaFisica)parametros["Key"]).idPessoa;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PessoaFisica)bd).pessoa.idPessoa.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PessoaFisica)input).operacao = ENum.eOperacao.NONE;

                    input = (Data.PessoaFisica)(new WS.CRUD.Pessoa(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        input,
                        ((Tables.PessoaFisica)bd).pessoa,
                        level
                    );
                    ((Data.PessoaFisica)input).dataNascimento = ((Tables.PessoaFisica)bd).dataNascimento.value;
                    ((Data.PessoaFisica)input).sexo = ((Tables.PessoaFisica)bd).sexo.value;
                    ((Data.PessoaFisica)input).estadoCivil = (Data.EstadoCivil)(new WS.CRUD.EstadoCivil(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.EstadoCivil(),
                        ((Tables.PessoaFisica)bd).estadoCivil,
                        level + 1
                    );
                    ((Data.PessoaFisica)input).escolaridade = (Data.Escolaridade)(new WS.CRUD.Escolaridade(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Escolaridade(),
                        ((Tables.PessoaFisica)bd).escolaridade,
                        level + 1
                    );
                    ((Data.PessoaFisica)input).rgNumero = ((Tables.PessoaFisica)bd).rgNumero.value;
                    ((Data.PessoaFisica)input).rgEmissor = ((Tables.PessoaFisica)bd).rgEmissor.value;
                    ((Data.PessoaFisica)input).rgDataEmissao = ((Tables.PessoaFisica)bd).rgDataEmissao.value;
                    ((Data.PessoaFisica)input).teNumero = ((Tables.PessoaFisica)bd).teNumero.value;
                    ((Data.PessoaFisica)input).teZona = ((Tables.PessoaFisica)bd).teZona.value;
                    ((Data.PessoaFisica)input).teSecao = ((Tables.PessoaFisica)bd).teSecao.value;
                    ((Data.PessoaFisica)input).cnhNumero = ((Tables.PessoaFisica)bd).cnhNumero.value;
                    ((Data.PessoaFisica)input).reservistaNumero = ((Tables.PessoaFisica)bd).reservistaNumero.value;
                    ((Data.PessoaFisica)input).cidadeNaturalidade = (Data.Cidade)(new WS.CRUD.Cidade(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Cidade(),
                        ((Tables.PessoaFisica)bd).cidadeNaturalidade,
                        level + 1
                    );
                    ((Data.PessoaFisica)input).profissao = (Data.Profissao)(new WS.CRUD.Profissao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Profissao(),
                        ((Tables.PessoaFisica)bd).profissao,
                        level + 1
                    );
                    ((Data.PessoaFisica)input).profissaoNome = ((Tables.PessoaFisica)bd).profissaoNome.value;
                    ((Data.PessoaFisica)input).ctps = ((Tables.PessoaFisica)bd).ctps.value;
                    ((Data.PessoaFisica)input).pispasep = ((Tables.PessoaFisica)bd).pispasep.value;

                    ((Data.PessoaFisica)input).nacionalidade = (Data.Nacionalidade)(new WS.CRUD.Nacionalidade(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Nacionalidade(),
                        ((Tables.PessoaFisica)bd).nacionalidade,
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
            Data.PessoaFisica result = (Data.PessoaFisica)parametros["Key"];

            try
            {
                result = (Data.PessoaFisica)this.preencher
                (
                    new Data.PessoaFisica(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.PessoaFisica),
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

            Data.PessoaFisica _input = (Data.PessoaFisica)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "pessoa.pfPj = 'F'";

                if (_input.idPessoa > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.idPessoa = @idPessoa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPessoa", _input.idPessoa));
                    if (!sqlOrderBy.Contains("pessoa.idPessoa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.idPessoa");
                    else { }
                }
                else { }

                if ((_input.cpfCnpj != null) && (_input.cpfCnpj.Length > 0))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.cpfCnpj like @cpfCnpj");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("cpfCnpj", _input.cpfCnpj + '%'));
                    if (!sqlOrderBy.Contains("pessoa.cpfCnpj"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.cpfCnpj");
                    else { }
                }
                else { }

                if ((_input.nomeRazaoSocial != null) && (_input.nomeRazaoSocial.Length > 0))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.nomeRazaoSocial COLLATE Latin1_General_CI_AI like @nomeRazaoSocial COLLATE Latin1_General_CI_AI");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("nomeRazaoSocial", _input.nomeRazaoSocial + '%'));
                    if (!sqlOrderBy.Contains("pessoa.nomeRazaoSocial"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.nomeRazaoSocial");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "pessoaFisica.* " +
                    "from " +
                    (
                    "pessoaFisica pessoaFisica " +
                        "inner join pessoa pessoa " +
                            "on pessoa.idPessoa = pessoaFisica.idPessoaFisica "
                    ) +
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
            Data.PessoaFisica input = (Data.PessoaFisica)parametros["Key"];
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
                    typeof(Tables.PessoaFisica),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.PessoaFisica _data in
                    (System.Collections.Generic.List<Tables.PessoaFisica>)this.m_EntityManager.list
                    (
                        typeof(Tables.PessoaFisica),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.PessoaFisica();
                        ((Data.PessoaFisica)_base).idPessoa = _data.pessoa.idPessoa.value;
                        ((Data.PessoaFisica)_base).nomeRazaoSocial = _data.pessoa.nomeRazaoSocial.value;
                        ((Data.PessoaFisica)_base).cpfCnpj = _data.pessoa.cpfCnpj.value;
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.PessoaFisica(), _data, level);

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
