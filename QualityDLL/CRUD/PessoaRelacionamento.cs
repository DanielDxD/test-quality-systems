using System;

namespace WS.CRUD
{
    public class PessoaRelacionamento : WS.CRUD.Base
    {
        public PessoaRelacionamento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PessoaRelacionamento input = (Data.PessoaRelacionamento)parametros["Key"];
            Tables.PessoaRelacionamento bd = new Tables.PessoaRelacionamento();

            bd.idPessoaRelacionamento.isNull = true;
            if ((input.pessoa != null) && (input.pessoa.idPessoa > 0))
                bd.pessoa.idPessoa.value = input.pessoa.idPessoa;
            else { }
            if ((input.tipoRelacionamento != null) && (input.tipoRelacionamento.idTipoRelacionamento > 0))
                bd.tipoRelacionamento.idTipoRelacionamento.value = input.tipoRelacionamento.idTipoRelacionamento;
            else { }
            if ((input.nome != null) && (input.nome.Length > 0))
                bd.nome.value = input.nome;
            else
                bd.nome.isNull = true;
            if ((input.pessoaRelacionada != null) && (input.pessoaRelacionada.idPessoa > 0))
                bd.pessoaRelacionada.idPessoa.value = input.pessoaRelacionada.idPessoa;
            else
                bd.pessoaRelacionada.idPessoa.isNull = true;
            bd.dataInicio.value = input.dataInicio;
            if (input.dataTermino.Ticks > 0)
                bd.dataTermino.value = input.dataTermino;
            else
                bd.dataTermino.isNull = true;

            this.m_EntityManager.persist(bd);

            ((Data.PessoaRelacionamento)parametros["Key"]).idPessoaRelacionamento = (int)bd.idPessoaRelacionamento.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PessoaRelacionamento input = (Data.PessoaRelacionamento)parametros["Key"];
            Tables.PessoaRelacionamento bd = (Tables.PessoaRelacionamento)this.m_EntityManager.find
            (
                typeof(Tables.PessoaRelacionamento),
                new Object[]
                {
                    input.idPessoaRelacionamento
                }
            );

            if ((input.pessoa != null) && (input.pessoa.idPessoa > 0))
                bd.pessoa.idPessoa.value = input.pessoa.idPessoa;
            else { }
            if ((input.tipoRelacionamento != null) && (input.tipoRelacionamento.idTipoRelacionamento > 0))
                bd.tipoRelacionamento.idTipoRelacionamento.value = input.tipoRelacionamento.idTipoRelacionamento;
            else { }
            if ((input.nome != null) && (input.nome.Length > 0))
                bd.nome.value = input.nome;
            else
                bd.nome.isNull = true;
            if ((input.pessoaRelacionada != null) && (input.pessoaRelacionada.idPessoa > 0))
                bd.pessoaRelacionada.idPessoa.value = input.pessoaRelacionada.idPessoa;
            else
                bd.pessoaRelacionada.idPessoa.isNull = true;
            bd.dataInicio.value = input.dataInicio;
            if (input.dataTermino.Ticks > 0)
                bd.dataTermino.value = input.dataTermino;
            else
                bd.dataTermino.isNull = true;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PessoaRelacionamento bd = new Tables.PessoaRelacionamento();

            bd.idPessoaRelacionamento.value = ((Data.PessoaRelacionamento)parametros["Key"]).idPessoaRelacionamento;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PessoaRelacionamento)bd).idPessoaRelacionamento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PessoaRelacionamento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PessoaRelacionamento)input).idPessoaRelacionamento = ((Tables.PessoaRelacionamento)bd).idPessoaRelacionamento.value;
                    ((Data.PessoaRelacionamento)input).pessoa = (Data.Pessoa)(new WS.CRUD.Pessoa(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Pessoa(),
                        ((Tables.PessoaRelacionamento)bd).pessoa,
                        level + 1
                    );
                    ((Data.PessoaRelacionamento)input).tipoRelacionamento = (Data.TipoRelacionamento)(new WS.CRUD.TipoRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoRelacionamento(),
                        ((Tables.PessoaRelacionamento)bd).tipoRelacionamento,
                        level + 1
                    );
                    ((Data.PessoaRelacionamento)input).nome = ((Tables.PessoaRelacionamento)bd).nome.value;
                    ((Data.PessoaRelacionamento)input).pessoaRelacionada = (Data.Pessoa)(new WS.CRUD.Pessoa(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Pessoa(),
                        ((Tables.PessoaRelacionamento)bd).pessoaRelacionada,
                        level + 1
                    );
                    ((Data.PessoaRelacionamento)input).dataInicio = ((Tables.PessoaRelacionamento)bd).dataInicio.value;
                    ((Data.PessoaRelacionamento)input).dataTermino = ((Tables.PessoaRelacionamento)bd).dataTermino.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PessoaRelacionamento result = (Data.PessoaRelacionamento)parametros["Key"];

            try
            {
                result = (Data.PessoaRelacionamento)this.preencher
                (
                    new Data.PessoaRelacionamento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.PessoaRelacionamento),
                        new Object[]
                        {
                            result.idPessoaRelacionamento
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
            Data.PessoaRelacionamento input = (Data.PessoaRelacionamento)parametros["Key"];
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
                    typeof(Tables.PessoaRelacionamento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.PessoaRelacionamento _data in
                    (System.Collections.Generic.List<Tables.PessoaRelacionamento>)this.m_EntityManager.list
                    (
                        typeof(Tables.PessoaRelacionamento),
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
                    _base = (Data.Base)this.preencher(new Data.PessoaRelacionamento(), _data, level);

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
