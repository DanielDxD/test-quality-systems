using System;

namespace WS.CRUD
{
    public class RegraContabilizacaoLancamento : WS.CRUD.Base
    {
        public RegraContabilizacaoLancamento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.RegraContabilizacaoLancamento input = (Data.RegraContabilizacaoLancamento)parametros["Key"];
            Tables.RegraContabilizacaoLancamento bd = new Tables.RegraContabilizacaoLancamento();

            bd.idRegraContabilizacaoLancamento.isNull = true;
            bd.origemIdPlanoContas.value = input.origemIdPlanoContas;
            bd.debitoCredito.value = input.debitoCredito;
            bd.formula.value = input.formula;
            bd.agrupaLancamento.value = input.agrupaLancamento;
            bd.ordemProcessamento.value = input.ordemProcessamento;
            if ((input.regraContabilizacao != null) && (input.regraContabilizacao.idRegraContabilizacao > 0))
                bd.regraContabilizacao.idRegraContabilizacao.value = input.regraContabilizacao.idRegraContabilizacao;
            else { }
            if ((input.regraContabilizacaoPrimaria != null) && (input.regraContabilizacaoPrimaria.idRegraContabilizacao > 0))
                bd.regraContabilizacaoPrimaria.idRegraContabilizacao.value = input.regraContabilizacaoPrimaria.idRegraContabilizacao;
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.RegraContabilizacaoLancamento)parametros["Key"]).idRegraContabilizacaoLancamento = (int)bd.idRegraContabilizacaoLancamento.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.RegraContabilizacaoLancamento input = (Data.RegraContabilizacaoLancamento)parametros["Key"];
            Tables.RegraContabilizacaoLancamento bd = (Tables.RegraContabilizacaoLancamento)this.m_EntityManager.find
            (
                typeof(Tables.RegraContabilizacaoLancamento),
                new Object[]
                {
                    input.idRegraContabilizacaoLancamento
                }
            );

            bd.origemIdPlanoContas.value = input.origemIdPlanoContas;
            bd.debitoCredito.value = input.debitoCredito;
            bd.formula.value = input.formula;
            bd.agrupaLancamento.value = input.agrupaLancamento;
            bd.ordemProcessamento.value = input.ordemProcessamento;
            if ((input.regraContabilizacao != null) && (input.regraContabilizacao.idRegraContabilizacao > 0))
                bd.regraContabilizacao.idRegraContabilizacao.value = input.regraContabilizacao.idRegraContabilizacao;
            else { }
            if ((input.regraContabilizacaoPrimaria != null) && (input.regraContabilizacaoPrimaria.idRegraContabilizacao > 0))
                bd.regraContabilizacaoPrimaria.idRegraContabilizacao.value = input.regraContabilizacaoPrimaria.idRegraContabilizacao;
            else { }

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.RegraContabilizacaoLancamento bd = new Tables.RegraContabilizacaoLancamento();

            bd.idRegraContabilizacaoLancamento.value = ((Data.RegraContabilizacaoLancamento)parametros["Key"]).idRegraContabilizacaoLancamento;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.RegraContabilizacaoLancamento)bd).idRegraContabilizacaoLancamento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.RegraContabilizacaoLancamento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.RegraContabilizacaoLancamento)input).idRegraContabilizacaoLancamento = ((Tables.RegraContabilizacaoLancamento)bd).idRegraContabilizacaoLancamento.value;
                    ((Data.RegraContabilizacaoLancamento)input).origemIdPlanoContas = ((Tables.RegraContabilizacaoLancamento)bd).origemIdPlanoContas.value;
                    ((Data.RegraContabilizacaoLancamento)input).debitoCredito = ((Tables.RegraContabilizacaoLancamento)bd).debitoCredito.value;
                    ((Data.RegraContabilizacaoLancamento)input).formula = ((Tables.RegraContabilizacaoLancamento)bd).formula.value;
                    ((Data.RegraContabilizacaoLancamento)input).agrupaLancamento = ((Tables.RegraContabilizacaoLancamento)bd).agrupaLancamento.value;
                    ((Data.RegraContabilizacaoLancamento)input).ordemProcessamento = ((Tables.RegraContabilizacaoLancamento)bd).ordemProcessamento.value;
                    ((Data.RegraContabilizacaoLancamento)input).regraContabilizacao = (Data.RegraContabilizacao)(new WS.CRUD.RegraContabilizacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.RegraContabilizacao(),
                        ((Tables.RegraContabilizacaoLancamento)bd).regraContabilizacao,
                        level + 1
                    );
                    ((Data.RegraContabilizacaoLancamento)input).regraContabilizacaoPrimaria = (Data.RegraContabilizacao)(new WS.CRUD.RegraContabilizacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.RegraContabilizacao(),
                        ((Tables.RegraContabilizacaoLancamento)bd).regraContabilizacaoPrimaria,
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
            Data.RegraContabilizacaoLancamento result = (Data.RegraContabilizacaoLancamento)parametros["Key"];

            try
            {
                result = (Data.RegraContabilizacaoLancamento)this.preencher
                (
                    new Data.RegraContabilizacaoLancamento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.RegraContabilizacaoLancamento),
                        new Object[]
                        {
                            result.idRegraContabilizacaoLancamento
                        }
                    ),
                    0
                );
            }
            catch (Exception e)
            {
                System.Console.Out.Write(this.GetType().ToString() + ".consultar() -> " + e.ToString());
                throw new Exception(e.Message);
            }

            return result;
        }

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.RegraContabilizacaoLancamento input = (Data.RegraContabilizacaoLancamento)parametros["Key"];
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
                    typeof(Tables.RegraContabilizacaoLancamento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.RegraContabilizacaoLancamento _data in
                    (System.Collections.Generic.List<Tables.RegraContabilizacaoLancamento>)this.m_EntityManager.list
                    (
                        typeof(Tables.RegraContabilizacaoLancamento),
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
                    _base = (Data.Base)this.preencher(new Data.RegraContabilizacaoLancamento(), _data, level);

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
                System.Console.Out.Write(this.GetType().ToString() + ".listar() -> " + e.ToString());
                throw new Exception(e.Message);
            }

            return ((result.Count > 0) ? result.ToArray() : null);
        }
    }
}
