using System;

namespace WS.CRUD
{
    public class ContaPagamentoSaldo : WS.CRUD.Base
    {
        public ContaPagamentoSaldo(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ContaPagamentoSaldo input = (Data.ContaPagamentoSaldo)parametros["Key"];
            Tables.ContaPagamentoSaldo bd = new Tables.ContaPagamentoSaldo();

            bd.idContaPagamentoSaldo.isNull = true;
            bd.idContaPagamento.value = input.idContaPagamento;
            bd.data.value = input.data;
            bd.saldo.value = input.saldo;
            bd.pagamentoVinculado.value = input.pagamentoVinculado;
            bd.recebimentoVinculado.value = input.recebimentoVinculado;

            this.m_EntityManager.persist(bd);

            ((Data.ContaPagamentoSaldo)parametros["Key"]).idContaPagamentoSaldo = (int)bd.idContaPagamentoSaldo.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ContaPagamentoSaldo input = (Data.ContaPagamentoSaldo)parametros["Key"];
            Tables.ContaPagamentoSaldo bd = (Tables.ContaPagamentoSaldo)this.m_EntityManager.find
            (
                typeof(Tables.ContaPagamentoSaldo),
                new Object[]
                {
                    input.idContaPagamentoSaldo
                }
            );

            bd.idContaPagamento.value = input.idContaPagamento;
            bd.data.value = input.data;
            bd.saldo.value = input.saldo;
            bd.pagamentoVinculado.value = input.pagamentoVinculado;
            bd.recebimentoVinculado.value = input.recebimentoVinculado;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ContaPagamentoSaldo bd = new Tables.ContaPagamentoSaldo();

            bd.idContaPagamentoSaldo.value = ((Data.ContaPagamentoSaldo)parametros["Key"]).idContaPagamentoSaldo;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ContaPagamentoSaldo)bd).idContaPagamentoSaldo.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ContaPagamentoSaldo)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ContaPagamentoSaldo)input).idContaPagamentoSaldo = ((Tables.ContaPagamentoSaldo)bd).idContaPagamentoSaldo.value;
                    ((Data.ContaPagamentoSaldo)input).idContaPagamento = ((Tables.ContaPagamentoSaldo)bd).idContaPagamento.value;
                    ((Data.ContaPagamentoSaldo)input).data = ((Tables.ContaPagamentoSaldo)bd).data.value;
                    ((Data.ContaPagamentoSaldo)input).saldo = ((Tables.ContaPagamentoSaldo)bd).saldo.value;
                    ((Data.ContaPagamentoSaldo)input).pagamentoVinculado = ((Tables.ContaPagamentoSaldo)bd).pagamentoVinculado.value;
                    ((Data.ContaPagamentoSaldo)input).recebimentoVinculado = ((Tables.ContaPagamentoSaldo)bd).recebimentoVinculado.value;

                    System.Data.DataTable saldoAnterior = this.m_EntityManager.executeData
                    (
                        @"
                            select top 1
	                            saldo,
                                pagamentoVinculado,
                                recebimentoVinculado
                            from
	                            contaPagamentoSaldo
                            where
	                            idContaPagamento = @idContaPagamento and
	                            data < @data
                            order by
	                            data desc
                        ",
                        new EJB.TableBase.TField[]
                        {
                            ((Tables.ContaPagamentoSaldo)bd).idContaPagamento,
                            ((Tables.ContaPagamentoSaldo)bd).data
                        }
                    );

                    if ((saldoAnterior != null) && (saldoAnterior.Rows.Count > 0))
                    {
                        ((Data.ContaPagamentoSaldo)input).saldoAnterior = System.Convert.ToDouble(saldoAnterior.Rows[0][0]);
                        ((Data.ContaPagamentoSaldo)input).pagamentoVinculadoAnterior = System.Convert.ToDouble(saldoAnterior.Rows[0][1]);
                        ((Data.ContaPagamentoSaldo)input).recebimentoVinculadoAnterior = System.Convert.ToDouble(saldoAnterior.Rows[0][2]);
                    }
                    else { }
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.ContaPagamentoSaldo result = (Data.ContaPagamentoSaldo)parametros["Key"];

            try
            {
                result = (Data.ContaPagamentoSaldo)this.preencher
                (
                    new Data.ContaPagamentoSaldo(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ContaPagamentoSaldo),
                        new Object[]
                        {
                            result.idContaPagamentoSaldo
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
            Data.ContaPagamentoSaldo input = (Data.ContaPagamentoSaldo)parametros["Key"];
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
                    typeof(Tables.ContaPagamentoSaldo),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ContaPagamentoSaldo _data in
                    (System.Collections.Generic.List<Tables.ContaPagamentoSaldo>)this.m_EntityManager.list
                    (
                        typeof(Tables.ContaPagamentoSaldo),
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
                    _base = (Data.Base)this.preencher(new Data.ContaPagamentoSaldo(), _data, level);

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
