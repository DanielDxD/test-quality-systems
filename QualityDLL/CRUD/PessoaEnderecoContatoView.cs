using System;
using System.Linq;

namespace WS.CRUD
{
    public class PessoaEnderecoContatoView : WS.CRUD.Base
    {
        public PessoaEnderecoContatoView(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
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
                    ((Data.PessoaEnderecoContatoView)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PessoaEnderecoContatoView)input).idPessoaEnderecoContatoView = ((Tables.PessoaEnderecoContato)bd).idPessoaEnderecoContato.value;
                    ((Data.PessoaEnderecoContatoView)input).idPessoa = ((Tables.PessoaEnderecoContato)bd).pessoa.idPessoa.value;

                    Data.TipoEnderecoContato tipoEnderecoContato = (Data.TipoEnderecoContato)(new WS.CRUD.TipoEnderecoContato(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoEnderecoContato(),
                        ((Tables.PessoaEnderecoContato)bd).tipoEnderecoContato,
                        level + 1
                    );

                    ((Data.PessoaEnderecoContatoView)input).tipoEnderecoContato = tipoEnderecoContato.descricao;

                    tipoEnderecoContato = null;
                }
                else { }

                //Preencher PessoaContatos
                if (((Tables.PessoaEnderecoContato)bd).pessoaContatos != null)
                {
                    if (((Tables.PessoaEnderecoContato)bd).pessoaContatos.Count > 0)
                    {
                        Data.PessoaContato pessoaContato =
                        (
                            (Data.PessoaContato)
                            (new WS.CRUD.PessoaContato(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                            (
                                new Data.PessoaContato(),
                                ((Tables.PessoaEnderecoContato)bd).pessoaContatos[0],
                                level
                            )
                        );

                        ((Data.PessoaEnderecoContatoView)input).contato = (((pessoaContato.pessoaContato != null) && (pessoaContato.pessoaContato.idPessoa > 0)) ? pessoaContato.pessoaContato.nomeRazaoSocial : pessoaContato.nome);

                        ((Data.PessoaEnderecoContatoView)input).contato +=
                        (
                            "<br />" +
                            String.Join(", ", pessoaContato.pessoaContatoAcessos.Select(X => X.tipoAcessoContato.descricao + " " + X.informacao).ToList<String>())
                        );
                    }
                }
                else
                    ((Data.PessoaEnderecoContatoView)input).contato = "";

                //Preencher PessoaEnderecos
                if (((Tables.PessoaEnderecoContato)bd).pessoaEnderecos != null)
                {
                    if (((Tables.PessoaEnderecoContato)bd).pessoaEnderecos.Count > 0)
                    {
                        Data.PessoaEndereco pessoaEndereco =
                        (
                            (Data.PessoaEndereco)
                            (new WS.CRUD.PessoaEndereco(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                            (
                                new Data.PessoaEndereco(),
                                ((Tables.PessoaEnderecoContato)bd).pessoaEnderecos[0],
                                level
                            )
                        );

                        //pessoaEndereco.endereco.logradouro.ToString();
                        //pessoaEndereco.endereco.bairro.ToString();

                        Data.Logradouro logradouro = pessoaEndereco.logradouro != null && pessoaEndereco.logradouro.idLogradouro > 0 ? pessoaEndereco.logradouro : pessoaEndereco.endereco.logradouro;
                        ((Data.PessoaEnderecoContatoView)input).endereco =
                            logradouro.tipoLogradouro.tipo + " " +
                            logradouro.descricao + 
                            (!String.IsNullOrWhiteSpace(pessoaEndereco.numero) ? ", " + pessoaEndereco.numero : "" ) +
                            "<br />" +
                            logradouro.cidade.descricao + "/" +
                            logradouro.cidade.estado.uf;

                        pessoaEndereco = null;
                    }
                }
                else
                    ((Data.PessoaEnderecoContatoView)input).endereco = "";
            }
            else { }

            return input;
        }

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.PessoaEnderecoContatoView input = (Data.PessoaEnderecoContatoView)parametros["Key"];
            System.Collections.Generic.List<Data.Base> result = new System.Collections.Generic.List<Data.Base>();
            string mode = (string)(parametros["Mode"] == null ? "" : parametros["Mode"]);
            int level = (int)(parametros["Level"] == null ? 0 : parametros["Level"]);

            System.Collections.Hashtable makeSelectParams = new System.Collections.Hashtable();
            makeSelectParams["numRows"] = (parametros["Top"] == null ? 0 : (int)parametros["Top"]);
            makeSelectParams["where"] = (parametros["Filter"] == null ? "" : (String)parametros["Filter"]);
            makeSelectParams["orderBy"] = (parametros["Order"] == null ? "" : (String)parametros["Order"]);
            makeSelectParams["offSet"] = (parametros["Offset"] == null ? -1 : parametros["Offset"]);

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
                    Data.Base _base = (Data.Base)this.preencher(new Data.PessoaEnderecoContatoView(), _data, level);

                    result.Add(_base);
                }

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
