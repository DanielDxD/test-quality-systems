using System;

namespace WS.CRUD
{
    public class PessoaImagem : WS.CRUD.Base
    {
        public PessoaImagem(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PessoaImagem input = (Data.PessoaImagem)parametros["Key"];
            Tables.PessoaImagem bd = new Tables.PessoaImagem();

            bd.idPessoaImagem.isNull = true;
            if ((input.pessoa != null) && (input.pessoa.idPessoa > 0))
                bd.pessoa.idPessoa.value = input.pessoa.idPessoa;
            else { }
            if ((input.tipoImagem != null) && (input.tipoImagem.idTipoImagem > 0))
                bd.tipoImagem.idTipoImagem.value = input.tipoImagem.idTipoImagem;
            else { }
            bd.imagem.value = input.imagem;

            this.m_EntityManager.persist(bd);

            ((Data.PessoaImagem)parametros["Key"]).idPessoaImagem = (int)bd.idPessoaImagem.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PessoaImagem input = (Data.PessoaImagem)parametros["Key"];
            Tables.PessoaImagem bd = (Tables.PessoaImagem)this.m_EntityManager.find
            (
                typeof(Tables.PessoaImagem),
                new Object[]
                {
                    input.idPessoaImagem
                }
            );

            if (input.pessoa != null)
                bd.pessoa.idPessoa.value = input.pessoa.idPessoa;
            else { }
            if (input.tipoImagem != null)
                bd.tipoImagem.idTipoImagem.value = input.tipoImagem.idTipoImagem;
            else { }
            bd.imagem.value = input.imagem;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PessoaImagem bd = new Tables.PessoaImagem();

            bd.idPessoaImagem.value = ((Data.PessoaImagem)parametros["Key"]).idPessoaImagem;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
                if
                (
                    !((Tables.PessoaImagem)bd).idPessoaImagem.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PessoaImagem)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PessoaImagem)input).idPessoaImagem = ((Tables.PessoaImagem)bd).idPessoaImagem.value;
                    ((Data.PessoaImagem)input).pessoa = (Data.Pessoa)(new WS.CRUD.Pessoa(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Pessoa(),
                        ((Tables.PessoaImagem)bd).pessoa,
                        level + 1
                    );
                    ((Data.PessoaImagem)input).tipoImagem = (Data.TipoImagem)(new WS.CRUD.TipoImagem(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoImagem(),
                        ((Tables.PessoaImagem)bd).tipoImagem,
                        level + 1
                    );
                    ((Data.PessoaImagem)input).imagem = ((Tables.PessoaImagem)bd).imagem.value;
                }
                else { }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PessoaImagem result = (Data.PessoaImagem)parametros["Key"];

            try
            {
                result = (Data.PessoaImagem)this.preencher
                (
                    new Data.PessoaImagem(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.PessoaImagem),
                        new Object[]
                        {
                            result.idPessoaImagem
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
            Data.PessoaImagem input = (Data.PessoaImagem)parametros["Key"];
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
                    typeof(Tables.PessoaImagem),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.PessoaImagem _data in
                    (System.Collections.Generic.List<Tables.PessoaImagem>)this.m_EntityManager.list
                    (
                        typeof(Tables.PessoaImagem),
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
                    _base = (Data.Base)this.preencher(new Data.PessoaImagem(), _data, level);

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
