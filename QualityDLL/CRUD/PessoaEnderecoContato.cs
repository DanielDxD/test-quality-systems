using System;
using System.Linq;

namespace WS.CRUD
{
    public class PessoaEnderecoContato : WS.CRUD.Base
    {
        public PessoaEnderecoContato(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PessoaEnderecoContato input = (Data.PessoaEnderecoContato)parametros["Key"];
            Tables.PessoaEnderecoContato bd = new Tables.PessoaEnderecoContato();

            bd.idPessoaEnderecoContato.isNull = true;
            if (input.idPessoa > 0)
                bd.pessoa.idPessoa.value = input.idPessoa;
            else { }
            if ((input.tipoEnderecoContato != null) && (input.tipoEnderecoContato.idTipoEnderecoContato > 0))
                bd.tipoEnderecoContato.idTipoEnderecoContato.value = input.tipoEnderecoContato.idTipoEnderecoContato;
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.PessoaEnderecoContato)parametros["Key"]).idPessoaEnderecoContato = (int)bd.idPessoaEnderecoContato.value;

            //Processa PessoaContato
            if
            (
                (input.pessoaContato != null) &&
                (
                    (
                        (input.pessoaContato.pessoaContatoAcessos != null) &&
                        (input.pessoaContato.pessoaContatoAcessos.Length > 0) &&
                        (!String.IsNullOrEmpty(input.pessoaContato.pessoaContatoAcessos[0].informacao))
                    ) ||
                    (
                        (input.pessoaContato.nome.Length > 0) ||
                        (
                            (input.pessoaContato.pessoaContato != null) &&
                            (input.pessoaContato.pessoaContato.idPessoa > 0)
                        )
                    )
                )
            )
            {
                WS.CRUD.PessoaContato pessoaContatoCRUD = new WS.CRUD.PessoaContato(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                input.pessoaContato.idPessoaEnderecoContato = bd.idPessoaEnderecoContato.value;
                _parameters.Add("Key", input.pessoaContato);
                pessoaContatoCRUD.atualizar(_parameters);

                pessoaContatoCRUD = null;
                _parameters.Clear();
                _parameters = null;
            }
            else { }

            //Processa PessoaEndereco
            if
            (
                (input.pessoaEndereco != null) &&
                (input.pessoaEndereco.endereco.cep > 0)
            )
            {
                WS.CRUD.PessoaEndereco pessoaEnderecoCRUD = new WS.CRUD.PessoaEndereco(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                input.pessoaEndereco.idPessoaEnderecoContato = bd.idPessoaEnderecoContato.value;
                _parameters.Add("Key", input.pessoaEndereco);
                pessoaEnderecoCRUD.atualizar(_parameters);

                pessoaEnderecoCRUD = null;
                _parameters.Clear();
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PessoaEnderecoContato input = (Data.PessoaEnderecoContato)parametros["Key"];
            Tables.PessoaEnderecoContato bd = (Tables.PessoaEnderecoContato)this.m_EntityManager.find
            (
                typeof(Tables.PessoaEnderecoContato),
                new Object[]
                {
                    input.idPessoaEnderecoContato
                }
            );

            if (input.idPessoa > 0)
                bd.pessoa.idPessoa.value = input.idPessoa;
            else { }
            if ((input.tipoEnderecoContato != null) && (input.tipoEnderecoContato.idTipoEnderecoContato > 0))
                bd.tipoEnderecoContato.idTipoEnderecoContato.value = input.tipoEnderecoContato.idTipoEnderecoContato;
            else { }

            this.m_EntityManager.merge(bd);

            //Processa PessoaContato
            if
            (
                (input.pessoaContato != null) //&&
                                              //    (
                                              //        (input.pessoaContato.nome.Length > 0) ||
                                              //        (
                                              //            (input.pessoaContato.pessoaContato != null) &&
                                              //            (input.pessoaContato.pessoaContato.idPessoa > 0)
                                              //        )
                                              //    )
            )
            {
                WS.CRUD.PessoaContato pessoaContatoCRUD = new WS.CRUD.PessoaContato(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                input.pessoaContato.idPessoaEnderecoContato = bd.idPessoaEnderecoContato.value;
                _parameters.Add("Key", input.pessoaContato);
                if (input.pessoaContato.operacao == ENum.eOperacao.NONE)
                    input.pessoaContato.operacao = ENum.eOperacao.ALTERAR;
                else { }
                pessoaContatoCRUD.atualizar(_parameters);

                pessoaContatoCRUD = null;
                _parameters.Clear();
                _parameters = null;
            }
            //else { }

            //Processa PessoaEndereco
            if
            (
                (input.pessoaEndereco != null) &&
                (input.pessoaEndereco.endereco.cep > 0)
            )
            {
                WS.CRUD.PessoaEndereco pessoaEnderecoCRUD = new WS.CRUD.PessoaEndereco(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                input.pessoaEndereco.idPessoaEnderecoContato = bd.idPessoaEnderecoContato.value;
                _parameters.Add("Key", input.pessoaEndereco);
                if (input.pessoaEndereco.operacao == ENum.eOperacao.NONE)
                    input.pessoaEndereco.operacao = ENum.eOperacao.ALTERAR;
                else { }
                pessoaEnderecoCRUD.atualizar(_parameters);

                pessoaEnderecoCRUD = null;
                _parameters.Clear();
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PessoaEnderecoContato bd = new Tables.PessoaEnderecoContato();
            bd.idPessoaEnderecoContato.value = ((Data.PessoaEnderecoContato)parametros["Key"]).idPessoaEnderecoContato;
            /* Removendo dependências do contato */
            try {
                this.m_EntityManager.execute
                (
                    "DELETE FROM pessoaEnderecoFinalidadeEndereco WHERE idPessoaEnderecoContato = @idPessoaEnderecoContato\n" +
                    "DELETE FROM pessoaContatoAcesso WHERE idPessoaEnderecoContato = @idPessoaEnderecoContato\n" +
                    "DELETE FROM pessoaContato WHERE idPessoaEnderecoContato = @idPessoaEnderecoContato\n" +
                    "DELETE FROM pessoaEndereco WHERE idPessoaEnderecoContato = @idPessoaEnderecoContato\n"
                   ,
                    new EJB.TableBase.TField[]
                    {
                        new EJB.TableBase.TFieldInteger("idPessoaEnderecoContato", bd.idPessoaEnderecoContato.value)
                    }
                );
            }
            catch(Exception e)
            {
                throw e;
            }

            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PessoaEnderecoContato)bd).idPessoaEnderecoContato.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PessoaEnderecoContato)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PessoaEnderecoContato)input).idPessoaEnderecoContato = ((Tables.PessoaEnderecoContato)bd).idPessoaEnderecoContato.value;
                    ((Data.PessoaEnderecoContato)input).idPessoa = ((Tables.PessoaEnderecoContato)bd).pessoa.idPessoa.value;
                    ((Data.PessoaEnderecoContato)input).tipoEnderecoContato = (Data.TipoEnderecoContato)(new WS.CRUD.TipoEnderecoContato(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoEnderecoContato(),
                        ((Tables.PessoaEnderecoContato)bd).tipoEnderecoContato,
                        level + 1
                    );
                }
                else { }

                if (level < 2)
                {
                    //Preencher PessoaContatos
                    if (((Tables.PessoaEnderecoContato)bd).pessoaContatos != null)
                    {
                        if (((Tables.PessoaEnderecoContato)bd).pessoaContatos.Count > 0)
                        {
                            ((Data.PessoaEnderecoContato)input).pessoaContato =
                            (
                                (Data.PessoaContato)
                                (new WS.CRUD.PessoaContato(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.PessoaContato(),
                                    ((Tables.PessoaEnderecoContato)bd).pessoaContatos[0],
                                    level
                                )
                            );

                            ((Data.PessoaEnderecoContato)input).contato = (((((Data.PessoaEnderecoContato)input).pessoaContato.pessoaContato != null) && (((Data.PessoaEnderecoContato)input).pessoaContato.pessoaContato.idPessoa > 0)) ? ((Data.PessoaEnderecoContato)input).pessoaContato.pessoaContato.nomeRazaoSocial : ((Data.PessoaEnderecoContato)input).pessoaContato.nome);

                            if (((Data.PessoaEnderecoContato)input).pessoaContato.pessoaContatoAcessos != null)
                            {
                                ((Data.PessoaEnderecoContato)input).contato +=
                                (
                                    (String.IsNullOrWhiteSpace(((Data.PessoaEnderecoContato)input).contato) ? "" : "<br />") +
                                    String.Join(", ", ((Data.PessoaEnderecoContato)input).pessoaContato.pessoaContatoAcessos.Select(X => X.tipoAcessoContato.descricao + " " + X.informacao).ToList<String>())
                                );
                            }
                            else { }
                        }
                    }
                    else
                        ((Data.PessoaEnderecoContato)input).pessoaContato = null;
                }
                else { }

                if (level < 2)
                {
                    //Preencher PessoaEnderecos
                    if (((Tables.PessoaEnderecoContato)bd).pessoaEnderecos != null)
                    {
                        if (((Tables.PessoaEnderecoContato)bd).pessoaEnderecos.Count > 0)
                        {
                            ((Data.PessoaEnderecoContato)input).pessoaEndereco =
                            (
                                (Data.PessoaEndereco)
                                (new WS.CRUD.PessoaEndereco(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.PessoaEndereco(),
                                    ((Tables.PessoaEnderecoContato)bd).pessoaEnderecos[0],
                                    level
                                )
                            );

                            Data.Logradouro logradouro = ((Data.PessoaEnderecoContato)input).pessoaEndereco.logradouro != null && ((Data.PessoaEnderecoContato)input).pessoaEndereco.logradouro.idLogradouro > 0 ? ((Data.PessoaEnderecoContato)input).pessoaEndereco.logradouro : ((Data.PessoaEnderecoContato)input).pessoaEndereco.endereco.logradouro;
                            if (logradouro != null && logradouro.idLogradouro > 0)
                            {
                                ((Data.PessoaEnderecoContato)input).endereco =
                                    logradouro.tipoLogradouro.tipo + " " +
                                    logradouro.descricao +
                                    (!String.IsNullOrWhiteSpace(((Data.PessoaEnderecoContato)input).pessoaEndereco.numero) ? ", " + ((Data.PessoaEnderecoContato)input).pessoaEndereco.numero : "") +
                                    "<br />" +
                                    logradouro.cidade.descricao + "/" +
                                    logradouro.cidade.estado.uf;
                            }
                            else { }
                        }
                    }
                    else
                        ((Data.PessoaEnderecoContato)input).pessoaEndereco = null;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PessoaEnderecoContato result = (Data.PessoaEnderecoContato)parametros["Key"];

            try
            {
                result = (Data.PessoaEnderecoContato)this.preencher
                (
                    new Data.PessoaEnderecoContato(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.PessoaEnderecoContato),
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
            Data.PessoaEnderecoContato input = (Data.PessoaEnderecoContato)parametros["Key"];
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
                    typeof(Tables.PessoaEnderecoContato),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.PessoaEnderecoContato _data in
                    (System.Collections.Generic.List<Tables.PessoaEnderecoContato>)this.m_EntityManager.list
                    (
                        typeof(Tables.PessoaEnderecoContato),
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
                    _base = (Data.Base)this.preencher(new Data.PessoaEnderecoContato(), _data, level);

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
