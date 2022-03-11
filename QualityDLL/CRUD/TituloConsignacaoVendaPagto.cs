using System;

namespace WS.CRUD
{
    public class TituloConsignacaoVendaPagto : WS.CRUD.Base
    {
        public TituloConsignacaoVendaPagto(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.TituloConsignacaoVendaPagto input = (Data.TituloConsignacaoVendaPagto)parametros["Key"];
            Tables.TituloConsignacaoVendaPagto bd = new Tables.TituloConsignacaoVendaPagto();

            bd.idTituloConsignacaoVendaPagto.isNull = true;
            if (input.tituloConsignacaoVenda != null)
                if (input.tituloConsignacaoVenda.tituloConsignacaoVenda != null)
                    bd.tituloConsignacaoVenda.tituloConsignacaoVenda.idTituloConsignacao.value = input.tituloConsignacaoVenda.tituloConsignacaoVenda.idTituloConsignacao;
                else { }
            else { }
            if (input.formaPagamento != null)
                bd.formaPagamento.idFormaPagamento.value = input.formaPagamento.idFormaPagamento;
            else { }
            bd.valor.value = input.valor;
            bd.parcelas.value = input.parcelas;
            bd.vencimento.value = input.vencimento;

            this.m_EntityManager.persist(bd);

            ((Data.TituloConsignacaoVendaPagto)parametros["Key"]).idTituloConsignacaoVendaPagto = (int)bd.idTituloConsignacaoVendaPagto.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.TituloConsignacaoVendaPagto input = (Data.TituloConsignacaoVendaPagto)parametros["Key"];
            Tables.TituloConsignacaoVendaPagto bd = (Tables.TituloConsignacaoVendaPagto)this.m_EntityManager.find
            (
                typeof(Tables.TituloConsignacaoVendaPagto),
                new Object[]
                {
                    input.idTituloConsignacaoVendaPagto
                }
            );

            if (input.tituloConsignacaoVenda != null)
                if (input.tituloConsignacaoVenda.tituloConsignacaoVenda != null)
                    bd.tituloConsignacaoVenda.tituloConsignacaoVenda.idTituloConsignacao.value = input.tituloConsignacaoVenda.tituloConsignacaoVenda.idTituloConsignacao;
                else { }
            else { }
            if (input.formaPagamento != null)
                bd.formaPagamento.idFormaPagamento.value = input.formaPagamento.idFormaPagamento;
            else { }
            bd.valor.value = input.valor;
            bd.parcelas.value = input.parcelas;
            bd.vencimento.value = input.vencimento;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.TituloConsignacaoVendaPagto bd = new Tables.TituloConsignacaoVendaPagto();

            bd.idTituloConsignacaoVendaPagto.value = ((Data.TituloConsignacaoVendaPagto)parametros["Key"]).idTituloConsignacaoVendaPagto;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.TituloConsignacaoVendaPagto)bd).idTituloConsignacaoVendaPagto.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.TituloConsignacaoVendaPagto)input).operacao = ENum.eOperacao.NONE;

                    ((Data.TituloConsignacaoVendaPagto)input).idTituloConsignacaoVendaPagto = ((Tables.TituloConsignacaoVendaPagto)bd).idTituloConsignacaoVendaPagto.value;
                    ((Data.TituloConsignacaoVendaPagto)input).tituloConsignacaoVenda = (Data.TituloConsignacaoVenda)(new WS.CRUD.TituloConsignacaoVenda(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TituloConsignacaoVenda(),
                        ((Tables.TituloConsignacaoVendaPagto)bd).tituloConsignacaoVenda,
                        level + 1
                    );
                    ((Data.TituloConsignacaoVendaPagto)input).formaPagamento = (Data.FormaPagamento)(new WS.CRUD.FormaPagamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.FormaPagamento(),
                        ((Tables.TituloConsignacaoVendaPagto)bd).formaPagamento,
                        level + 1
                    );
                    ((Data.TituloConsignacaoVendaPagto)input).valor = ((Tables.TituloConsignacaoVendaPagto)bd).valor.value;
                    ((Data.TituloConsignacaoVendaPagto)input).parcelas = ((Tables.TituloConsignacaoVendaPagto)bd).parcelas.value;
                    ((Data.TituloConsignacaoVendaPagto)input).vencimento = ((Tables.TituloConsignacaoVendaPagto)bd).vencimento.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.TituloConsignacaoVendaPagto result = (Data.TituloConsignacaoVendaPagto)parametros["Key"];

            try
            {
                result = (Data.TituloConsignacaoVendaPagto)this.preencher
                (
                    new Data.TituloConsignacaoVendaPagto(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.TituloConsignacaoVendaPagto),
                        new Object[]
                        {
                            result.idTituloConsignacaoVendaPagto
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
            Data.TituloConsignacaoVendaPagto input = (Data.TituloConsignacaoVendaPagto)parametros["Key"];
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
                    typeof(Tables.TituloConsignacaoVendaPagto),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.TituloConsignacaoVendaPagto _data in
                    (System.Collections.Generic.List<Tables.TituloConsignacaoVendaPagto>)this.m_EntityManager.list
                    (
                        typeof(Tables.TituloConsignacaoVendaPagto),
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
                    _base = (Data.Base)this.preencher(new Data.TituloConsignacaoVendaPagto(), _data, level);

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
