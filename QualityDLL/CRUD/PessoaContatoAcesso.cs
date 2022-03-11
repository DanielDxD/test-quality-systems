using System;

namespace WS.CRUD
{
    public class PessoaContatoAcesso : WS.CRUD.Base
    {
        public PessoaContatoAcesso(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PessoaContatoAcesso input = (Data.PessoaContatoAcesso)parametros["Key"];
            Tables.PessoaContatoAcesso bd = new Tables.PessoaContatoAcesso();

            bd.idPessoaContatoAcesso.isNull = true;
            if ((input.pessoaEnderecoContato != null) && (input.pessoaEnderecoContato.idPessoaEnderecoContato > 0))
                bd.pessoaEnderecoContato.pessoaEnderecoContato.idPessoaEnderecoContato.value = input.pessoaEnderecoContato.idPessoaEnderecoContato;
            else { }
            if ((input.tipoAcessoContato != null) && (input.tipoAcessoContato.idTipoAcessoContato > 0))
                bd.tipoAcessoContato.idTipoAcessoContato.value = input.tipoAcessoContato.idTipoAcessoContato;
            else { }
            bd.informacao.value = input.informacao;

            this.m_EntityManager.persist(bd);

            ((Data.PessoaContatoAcesso)parametros["Key"]).idPessoaContatoAcesso = (int)bd.idPessoaContatoAcesso.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PessoaContatoAcesso input = (Data.PessoaContatoAcesso)parametros["Key"];
            Tables.PessoaContatoAcesso bd = (Tables.PessoaContatoAcesso)this.m_EntityManager.find
            (
                typeof(Tables.PessoaContatoAcesso),
                new Object[]
                {
                    input.idPessoaContatoAcesso
                }
            );

            if ((input.pessoaEnderecoContato != null) && (input.pessoaEnderecoContato.idPessoaEnderecoContato > 0))
                bd.pessoaEnderecoContato.pessoaEnderecoContato.idPessoaEnderecoContato.value = input.pessoaEnderecoContato.idPessoaEnderecoContato;
            else { }
            if ((input.tipoAcessoContato != null) && (input.tipoAcessoContato.idTipoAcessoContato > 0))
                bd.tipoAcessoContato.idTipoAcessoContato.value = input.tipoAcessoContato.idTipoAcessoContato;
            else { }
            bd.informacao.value = input.informacao;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PessoaContatoAcesso bd = new Tables.PessoaContatoAcesso();

            bd.idPessoaContatoAcesso.value = ((Data.PessoaContatoAcesso)parametros["Key"]).idPessoaContatoAcesso;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PessoaContatoAcesso)bd).idPessoaContatoAcesso.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PessoaContatoAcesso)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PessoaContatoAcesso)input).idPessoaContatoAcesso = ((Tables.PessoaContatoAcesso)bd).idPessoaContatoAcesso.value;
                    ((Data.PessoaContatoAcesso)input).pessoaEnderecoContato = (Data.PessoaContato)(new WS.CRUD.PessoaContato(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PessoaContato(),
                        ((Tables.PessoaContatoAcesso)bd).pessoaEnderecoContato,
                        level + 1
                    );
                    ((Data.PessoaContatoAcesso)input).tipoAcessoContato = (Data.TipoAcessoContato)(new WS.CRUD.TipoAcessoContato(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoAcessoContato(),
                        ((Tables.PessoaContatoAcesso)bd).tipoAcessoContato,
                        level + 1
                    );
                    ((Data.PessoaContatoAcesso)input).informacao = ((Tables.PessoaContatoAcesso)bd).informacao.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PessoaContatoAcesso result = (Data.PessoaContatoAcesso)parametros["Key"];

            try
            {
                result = (Data.PessoaContatoAcesso)this.preencher
                (
                    new Data.PessoaContatoAcesso(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.PessoaContatoAcesso),
                        new Object[]
                        {
                            result.idPessoaContatoAcesso
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
            Data.PessoaContatoAcesso input = (Data.PessoaContatoAcesso)parametros["Key"];
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
                    typeof(Tables.PessoaContatoAcesso),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.PessoaContatoAcesso _data in
                    (System.Collections.Generic.List<Tables.PessoaContatoAcesso>)this.m_EntityManager.list
                    (
                        typeof(Tables.PessoaContatoAcesso),
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
                    _base = (Data.Base)this.preencher(new Data.PessoaContatoAcesso(), _data, level);

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
