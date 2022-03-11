using System;

namespace WS.CRUD
{
    public class CaixaMovimentoLancamento : WS.CRUD.Base
    {
        public CaixaMovimentoLancamento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.CaixaMovimentoLancamento input = (Data.CaixaMovimentoLancamento)parametros["Key"];
            Tables.CaixaMovimentoLancamento bd = new Tables.CaixaMovimentoLancamento();

            bd.idCaixaMovimentoLancamento.isNull = true;
            if (input.caixaMovimento != null)
                bd.caixaMovimento.idCaixaMovimento.value = input.caixaMovimento.idCaixaMovimento;
            else { }
            if (input.produtoServico != null)
                bd.produtoServico.idProdutoServico.value = input.produtoServico.idProdutoServico;
            else { }
            if (input.contasAReceber != null)
                bd.contasAReceber.idContasAReceber.value = input.contasAReceber.idContasAReceber;
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.CaixaMovimentoLancamento)parametros["Key"]).idCaixaMovimentoLancamento = (int)bd.idCaixaMovimentoLancamento.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.CaixaMovimentoLancamento input = (Data.CaixaMovimentoLancamento)parametros["Key"];
            Tables.CaixaMovimentoLancamento bd = (Tables.CaixaMovimentoLancamento)this.m_EntityManager.find
            (
                typeof(Tables.CaixaMovimentoLancamento),
                new Object[]
                {
                    input.idCaixaMovimentoLancamento
                }
            );

            if (input.caixaMovimento != null)
                bd.caixaMovimento.idCaixaMovimento.value = input.caixaMovimento.idCaixaMovimento;
            else { }
            if (input.produtoServico != null)
                bd.produtoServico.idProdutoServico.value = input.produtoServico.idProdutoServico;
            else { }
            if (input.contasAReceber != null)
                bd.contasAReceber.idContasAReceber.value = input.contasAReceber.idContasAReceber;
            else { }

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.CaixaMovimentoLancamento bd = new Tables.CaixaMovimentoLancamento();

            bd.idCaixaMovimentoLancamento.value = ((Data.CaixaMovimentoLancamento)parametros["Key"]).idCaixaMovimentoLancamento;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.CaixaMovimentoLancamento)bd).idCaixaMovimentoLancamento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.CaixaMovimentoLancamento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.CaixaMovimentoLancamento)input).idCaixaMovimentoLancamento = ((Tables.CaixaMovimentoLancamento)bd).idCaixaMovimentoLancamento.value;
                    ((Data.CaixaMovimentoLancamento)input).caixaMovimento = (Data.CaixaMovimento)(new WS.CRUD.CaixaMovimento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.CaixaMovimento(),
                        ((Tables.CaixaMovimentoLancamento)bd).caixaMovimento,
                        level + 1
                    );
                    ((Data.CaixaMovimentoLancamento)input).produtoServico = (Data.ProdutoServico)(new WS.CRUD.ProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ProdutoServico(),
                        ((Tables.CaixaMovimentoLancamento)bd).produtoServico,
                        level + 1
                    );
                    ((Data.CaixaMovimentoLancamento)input).contasAReceber = (Data.ContasAReceber)(new WS.CRUD.ContasAReceber(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContasAReceber(),
                        ((Tables.CaixaMovimentoLancamento)bd).contasAReceber,
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
            Data.CaixaMovimentoLancamento result = (Data.CaixaMovimentoLancamento)parametros["Key"];

            try
            {
                result = (Data.CaixaMovimentoLancamento)this.preencher
                (
                    new Data.CaixaMovimentoLancamento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.CaixaMovimentoLancamento),
                        new Object[]
                        {
                            result.idCaixaMovimentoLancamento
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
            Data.CaixaMovimentoLancamento input = (Data.CaixaMovimentoLancamento)parametros["Key"];
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
                    typeof(Tables.CaixaMovimentoLancamento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.CaixaMovimentoLancamento _data in
                    (System.Collections.Generic.List<Tables.CaixaMovimentoLancamento>)this.m_EntityManager.list
                    (
                        typeof(Tables.CaixaMovimentoLancamento),
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
                    _base = (Data.Base)this.preencher(new Data.CaixaMovimentoLancamento(), _data, level);

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
