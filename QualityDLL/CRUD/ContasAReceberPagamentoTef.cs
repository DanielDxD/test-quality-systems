using System;

namespace WS.CRUD
{
    public class ContasAReceberPagamentoTef : WS.CRUD.Base
    {
        public ContasAReceberPagamentoTef(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ContasAReceberPagamentoTef input = (Data.ContasAReceberPagamentoTef)parametros["Key"];
            Tables.ContasAReceberPagamentoTef bd = new Tables.ContasAReceberPagamentoTef();

            bd.idContasAReceberPagamentoTef.isNull = true;
            bd.bandeira.value = input.bandeira;
            bd.cartaoNumero.value = input.cartaoNumero;
            bd.codigoAutorizacao.value = input.codigoAutorizacao;
            bd.dataTransacao.value = input.dataTransacao;
            bd.funcionario.value = input.funcionario;
            bd.parcelas.value = input.parcelas;
            bd.tipoPagamento.value = input.tipoPagamento;
            bd.tipoParcelamento.value = input.tipoParcelamento;
            bd.transacaoId.value = input.transacaoId;
            bd.valor.value = input.valor;
            bd.isApproved.value = input.isApproved;
            bd.serviceType.value = input.serviceType;

            bd.contasAReceberPagamento.idContasAReceberPagamento.value = input.contasAReceberPagamento.idContasAReceberPagamento;

            this.m_EntityManager.persist(bd);

            ((Data.ContasAReceberPagamentoTef)parametros["Key"]).idContasAReceberPagamentoTef = (int)bd.idContasAReceberPagamentoTef.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ContasAReceberPagamentoTef input = (Data.ContasAReceberPagamentoTef)parametros["Key"];
            Tables.ContasAReceberPagamentoTef bd = (Tables.ContasAReceberPagamentoTef)this.m_EntityManager.find
            (
                typeof(Tables.ContasAReceberPagamentoTef),
                new Object[]
                {
                    input.idContasAReceberPagamentoTef
                }
            );

            bd.bandeira.value = input.bandeira;
            bd.cartaoNumero.value = input.cartaoNumero;
            bd.codigoAutorizacao.value = input.codigoAutorizacao;
            bd.dataTransacao.value = input.dataTransacao;
            bd.funcionario.value = input.funcionario;
            bd.parcelas.value = input.parcelas;
            bd.tipoPagamento.value = input.tipoPagamento;
            bd.tipoParcelamento.value = input.tipoParcelamento;
            bd.transacaoId.value = input.transacaoId;
            bd.valor.value = input.valor;
            bd.isApproved.value = input.isApproved;
            bd.serviceType.value = input.serviceType;

            bd.contasAReceberPagamento.idContasAReceberPagamento.value = input.contasAReceberPagamento.idContasAReceberPagamento;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ContasAReceberPagamentoTef bd = new Tables.ContasAReceberPagamentoTef();

            bd.idContasAReceberPagamentoTef.value = ((Data.ContasAReceberPagamentoTef)parametros["Key"]).idContasAReceberPagamentoTef;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ContasAReceberPagamentoTef)bd).idContasAReceberPagamentoTef.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ContasAReceberPagamentoTef)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ContasAReceberPagamentoTef)input).idContasAReceberPagamentoTef = ((Tables.ContasAReceberPagamentoTef)bd).idContasAReceberPagamentoTef.value;
                    ((Data.ContasAReceberPagamentoTef)input).dataTransacao = ((Tables.ContasAReceberPagamentoTef)bd).dataTransacao.value;
                    ((Data.ContasAReceberPagamentoTef)input).bandeira = ((Tables.ContasAReceberPagamentoTef)bd).bandeira.value;
                    ((Data.ContasAReceberPagamentoTef)input).cartaoNumero = ((Tables.ContasAReceberPagamentoTef)bd).cartaoNumero.value;
                    ((Data.ContasAReceberPagamentoTef)input).codigoAutorizacao = ((Tables.ContasAReceberPagamentoTef)bd).codigoAutorizacao.value;
                    ((Data.ContasAReceberPagamentoTef)input).funcionario = ((Tables.ContasAReceberPagamentoTef)bd).funcionario.value;
                    ((Data.ContasAReceberPagamentoTef)input).parcelas = ((Tables.ContasAReceberPagamentoTef)bd).parcelas.value;
                    ((Data.ContasAReceberPagamentoTef)input).tipoPagamento = ((Tables.ContasAReceberPagamentoTef)bd).tipoPagamento.value;
                    ((Data.ContasAReceberPagamentoTef)input).tipoParcelamento = ((Tables.ContasAReceberPagamentoTef)bd).tipoParcelamento.value;
                    ((Data.ContasAReceberPagamentoTef)input).transacaoId = ((Tables.ContasAReceberPagamentoTef)bd).transacaoId.value;
                    ((Data.ContasAReceberPagamentoTef)input).valor = ((Tables.ContasAReceberPagamentoTef)bd).valor.value;
                    ((Data.ContasAReceberPagamentoTef)input).isApproved = ((Tables.ContasAReceberPagamentoTef)bd).isApproved.value;
                    ((Data.ContasAReceberPagamentoTef)input).serviceType = ((Tables.ContasAReceberPagamentoTef)bd).serviceType.value;

                    ((Data.ContasAReceberPagamentoTef)input).contasAReceberPagamento = (Data.ContasAReceberPagamento)(new WS.CRUD.ContasAReceberPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContasAReceberPagamento(),
                        ((Tables.ContasAReceberPagamentoTef)bd).contasAReceberPagamento,
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
            Data.ContasAReceberPagamentoTef result = (Data.ContasAReceberPagamentoTef)parametros["Key"];

            try
            {
                result = (Data.ContasAReceberPagamentoTef)this.preencher
                (
                    new Data.ContasAReceberPagamentoTef(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ContasAReceberPagamentoTef),
                        new Object[]
                        {
                            result.idContasAReceberPagamentoTef
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
            Data.ContasAReceberPagamentoTef input = (Data.ContasAReceberPagamentoTef)parametros["Key"];
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
                    typeof(Tables.ContasAReceberPagamentoTef),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ContasAReceberPagamentoTef _data in
                    (System.Collections.Generic.List<Tables.ContasAReceberPagamentoTef>)this.m_EntityManager.list
                    (
                        typeof(Tables.ContasAReceberPagamentoTef),
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
                    _base = (Data.Base)this.preencher(new Data.ContasAReceberPagamentoTef(), _data, level);

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
