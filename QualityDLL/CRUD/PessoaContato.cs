using System;

namespace WS.CRUD
{
    public class PessoaContato : WS.CRUD.Base
    {
        public PessoaContato(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PessoaContato input = (Data.PessoaContato)parametros["Key"];
            Tables.PessoaContato bd = new Tables.PessoaContato();

            bd.pessoaEnderecoContato.idPessoaEnderecoContato.value = input.idPessoaEnderecoContato;

            bd.nome.value = input.nome;
            if ((input.pessoaContato != null) && (input.pessoaContato.idPessoa > 0))
                bd.pessoaContato.idPessoa.value = input.pessoaContato.idPessoa;
            else { }

            this.m_EntityManager.persist(bd);

            //Processa PessoaContatoAcesso
            if (input.pessoaContatoAcessos != null)
            {
                WS.CRUD.PessoaContatoAcesso pessoaContatoAcessoCRUD = new WS.CRUD.PessoaContatoAcesso(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.pessoaContatoAcessos.Length; i++)
                {
                    input.pessoaContatoAcessos[i].pessoaEnderecoContato = new Data.PessoaContato();
                    input.pessoaContatoAcessos[i].pessoaEnderecoContato.idPessoaEnderecoContato = bd.pessoaEnderecoContato.idPessoaEnderecoContato.value;
                    _parameters.Add("Key", input.pessoaContatoAcessos[i]);
                    pessoaContatoAcessoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                pessoaContatoAcessoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PessoaContato input = (Data.PessoaContato)parametros["Key"];
            Tables.PessoaContato bd = (Tables.PessoaContato)this.m_EntityManager.find
            (
                typeof(Tables.PessoaContato),
                new Object[]
                {
                    input.idPessoaEnderecoContato
                }
            );

            bd.pessoaEnderecoContato.idPessoaEnderecoContato.value = input.idPessoaEnderecoContato;
            bd.nome.value = input.nome;
            if ((input.pessoaContato != null) && (input.pessoaContato.idPessoa > 0))
                bd.pessoaContato.idPessoa.value = input.pessoaContato.idPessoa;
            else { }

            this.m_EntityManager.merge(bd);

            //Processa PessoaContatoAcesso
            if (input.pessoaContatoAcessos != null)
            {
                WS.CRUD.PessoaContatoAcesso pessoaContatoAcessoCRUD = new WS.CRUD.PessoaContatoAcesso(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.pessoaContatoAcessos.Length; i++)
                {
                    input.pessoaContatoAcessos[i].pessoaEnderecoContato = new Data.PessoaContato();
                    input.pessoaContatoAcessos[i].pessoaEnderecoContato.idPessoaEnderecoContato = bd.pessoaEnderecoContato.idPessoaEnderecoContato.value;
                    _parameters.Add("Key", input.pessoaContatoAcessos[i]);
                    pessoaContatoAcessoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                pessoaContatoAcessoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PessoaContato bd = new Tables.PessoaContato();

            bd.pessoaEnderecoContato.idPessoaEnderecoContato.value = ((Data.PessoaContato)parametros["Key"]).idPessoaEnderecoContato;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PessoaContato)bd).pessoaEnderecoContato.idPessoaEnderecoContato.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PessoaContato)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PessoaContato)input).idPessoaEnderecoContato = ((Tables.PessoaContato)bd).pessoaEnderecoContato.idPessoaEnderecoContato.value;
                    ((Data.PessoaContato)input).nome = ((Tables.PessoaContato)bd).nome.value;
                    ((Data.PessoaContato)input).pessoaContato = (Data.Pessoa)(new WS.CRUD.Pessoa(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Pessoa(),
                        ((Tables.PessoaContato)bd).pessoaContato,
                        level + 1
                    );
                }
                else { }

                if (level < 2)
                {
                    //Preencher PessoaContatoAcessos
                    if (((Tables.PessoaContato)bd).pessoaContatoAcessos != null)
                    {
                        System.Collections.Generic.List<Data.PessoaContatoAcesso> _list = new System.Collections.Generic.List<Data.PessoaContatoAcesso>();

                        foreach (Tables.PessoaContatoAcesso _item in ((Tables.PessoaContato)bd).pessoaContatoAcessos)
                        {
                            _list.Add
                            (
                                (Data.PessoaContatoAcesso)
                                (new WS.CRUD.PessoaContatoAcesso(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.PessoaContatoAcesso(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.PessoaContato)input).pessoaContatoAcessos = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.PessoaContato)input).pessoaContatoAcessos != null)
                        {
                            System.Collections.Generic.List<Data.PessoaContatoAcesso> _list = new System.Collections.Generic.List<Data.PessoaContatoAcesso>();

                            foreach (Data.PessoaContatoAcesso _item in ((Data.PessoaContato)input).pessoaContatoAcessos)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.PessoaContato)input).pessoaContatoAcessos = _list.ToArray();
                            else
                                ((Data.PessoaContato)input).pessoaContatoAcessos = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PessoaContato result = (Data.PessoaContato)parametros["Key"];

            try
            {
                result = (Data.PessoaContato)this.preencher
                (
                    new Data.PessoaContato(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.PessoaContato),
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
            Data.PessoaContato input = (Data.PessoaContato)parametros["Key"];
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
                    typeof(Tables.PessoaContato),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.PessoaContato _data in
                    (System.Collections.Generic.List<Tables.PessoaContato>)this.m_EntityManager.list
                    (
                        typeof(Tables.PessoaContato),
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
                    _base = (Data.Base)this.preencher(new Data.PessoaContato(), _data, level);

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
