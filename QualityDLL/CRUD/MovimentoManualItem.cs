using System;

namespace WS.CRUD
{
    public class MovimentoManualItem : WS.CRUD.Base
    {
        public MovimentoManualItem(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.MovimentoManualItem input = (Data.MovimentoManualItem)parametros["Key"];
            Tables.MovimentoManualItem bd = new Tables.MovimentoManualItem();

            bd.idMovimentoManualItem.isNull = true;
            if (input.idMovimentoManual != null)
                bd.idMovimentoManual.idMovimentoManual.value = input.idMovimentoManual.idMovimentoManual;
            else { }
            if (input.idServico != null)
                bd.idServico.idServico.value = input.idServico.idServico;
            else { }
            if (input.idProdutoServico != null)
                bd.idProdutoServico.idProdutoServico.value = input.idProdutoServico.idProdutoServico;
            else { }
            bd.descricao.value = input.descricao;
            bd.valor.value = input.valor;
            bd.aliquotaIss.value = input.aliquotaIss;
            bd.valorIss.value = input.valorIss;
            bd.aliquotaIcms.value = input.aliquotaIcms;
            bd.valorIcms.value = input.valorIcms;
            bd.valorDesconto.value = input.valorDesconto;

            this.m_EntityManager.persist(bd);

            ((Data.MovimentoManualItem)parametros["Key"]).idMovimentoManualItem = (int)bd.idMovimentoManualItem.value;

            return this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.MovimentoManualItem input = (Data.MovimentoManualItem)parametros["Key"];
            Tables.MovimentoManualItem bd = (Tables.MovimentoManualItem)this.m_EntityManager.find
            (
                typeof(Tables.MovimentoManualItem),
                new Object[]
                {
                    input.idMovimentoManualItem
                }
            );

            bd.idMovimentoManualItem.isNull = true;
            if (input.idMovimentoManual != null)
                bd.idMovimentoManual.idMovimentoManual.value = input.idMovimentoManual.idMovimentoManual;
            else { }
            if (input.idServico != null)
                bd.idServico.idServico.value = input.idServico.idServico;
            else { }
            if (input.idProdutoServico != null)
                bd.idProdutoServico.idProdutoServico.value = input.idProdutoServico.idProdutoServico;
            else { }
            bd.descricao.value = input.descricao;
            bd.valor.value = input.valor;
            bd.aliquotaIss.value = input.aliquotaIss;
            bd.valorIss.value = input.valorIss;
            bd.aliquotaIcms.value = input.aliquotaIcms;
            bd.valorIcms.value = input.valorIcms;
            bd.valorDesconto.value = input.valorDesconto;

            this.m_EntityManager.merge(bd);

            return this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.MovimentoManualItem bd = new Tables.MovimentoManualItem();

            bd.idMovimentoManualItem.value = ((Data.MovimentoManualItem)parametros["Key"]).idMovimentoManualItem;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
                if
                (
                    !((Tables.MovimentoManualItem)bd).idMovimentoManualItem.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.MovimentoManualItem)input).operacao = ENum.eOperacao.NONE;

                    ((Data.MovimentoManualItem)input).idMovimentoManualItem = ((Tables.MovimentoManualItem)bd).idMovimentoManualItem.value;
                    ((Data.MovimentoManualItem)input).idMovimentoManual = (Data.MovimentoManual)(new WS.CRUD.MovimentoManual(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.MovimentoManual(),
                        ((Tables.MovimentoManualItem)bd).idMovimentoManual,
                        level + 1
                    );
                    ((Data.MovimentoManualItem)input).idServico = (Data.Servico)(new WS.CRUD.Servico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Servico(),
                        ((Tables.MovimentoManualItem)bd).idServico,
                        level + 1
                    );
                    ((Data.MovimentoManualItem)input).idProdutoServico = (Data.ProdutoServico)(new WS.CRUD.ProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ProdutoServico(),
                        ((Tables.MovimentoManualItem)bd).idProdutoServico,
                        level + 1
                    );
                    ((Data.MovimentoManualItem)input).descricao = ((Tables.MovimentoManualItem)bd).descricao.value;
                    ((Data.MovimentoManualItem)input).valor = ((Tables.MovimentoManualItem)bd).valor.value;
                    ((Data.MovimentoManualItem)input).aliquotaIss = ((Tables.MovimentoManualItem)bd).aliquotaIss.value;
                    ((Data.MovimentoManualItem)input).valorIss = ((Tables.MovimentoManualItem)bd).valorIss.value;
                    ((Data.MovimentoManualItem)input).aliquotaIcms = ((Tables.MovimentoManualItem)bd).aliquotaIcms.value;
                    ((Data.MovimentoManualItem)input).valorIcms = ((Tables.MovimentoManualItem)bd).valorIcms.value;
                    ((Data.MovimentoManualItem)input).valorDesconto = ((Tables.MovimentoManualItem)bd).valorDesconto.value;
                }
                else { }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.MovimentoManualItem result = (Data.MovimentoManualItem)parametros["Key"];

            try
            {
                result = (Data.MovimentoManualItem)this.preencher
                (
                    new Data.MovimentoManualItem(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.MovimentoManualItem),
                        new Object[]
                        {
                            result.idMovimentoManualItem
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
            Data.MovimentoManualItem input = (Data.MovimentoManualItem)parametros["Key"];
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
                    typeof(Tables.MovimentoManualItem),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.MovimentoManualItem _data in
                    (System.Collections.Generic.List<Tables.MovimentoManualItem>)this.m_EntityManager.list
                    (
                        typeof(Tables.MovimentoManualItem),
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
                    _base = (Data.Base)this.preencher(new Data.MovimentoManualItem(), _data, level);

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
