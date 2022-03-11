using System;

namespace WS.CRUD
{
    public class MovimentoManual : WS.CRUD.Base
    {
        public MovimentoManual(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.MovimentoManual input = (Data.MovimentoManual)parametros["Key"];
            Tables.MovimentoManual bd = new Tables.MovimentoManual();

            bd.idMovimentoManual.isNull = true;
            bd.descricao.value = input.descricao;
            bd.dataMovimento.value = input.dataMovimento;
            if (input.idPessoa != null)
                bd.idPessoa.idPessoa.value = input.idPessoa.idPessoa;
            else { }
            bd.valor.value = input.valor;
            bd.ocorrencias.value = input.ocorrencias;
            bd.pagarReceber.value = input.pagarReceber;

            this.m_EntityManager.persist(bd);

            ((Data.MovimentoManual)parametros["Key"]).idMovimentoManual = (int)bd.idMovimentoManual.value;

            //Processa ContasAPagarItem
            if (input.contasAPagarItems != null)
            {
                WS.CRUD.ContasAPagarItem contasAPagarItemCRUD = new WS.CRUD.ContasAPagarItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.contasAPagarItems.Length; i++)
                {
                    input.contasAPagarItems[i].idMovimentoManual = bd.idMovimentoManual.value;
                    _parameters.Add("Key", input.contasAPagarItems[i]);
                    contasAPagarItemCRUD.atualizar(_parameters);
                    if (input.contasAPagarItems[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.contasAPagarItems[i] = (Data.ContasAPagarItem)contasAPagarItemCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                contasAPagarItemCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa MovimentoManualItem
            if (input.movimentoManualItems != null)
            {
                WS.CRUD.MovimentoManualItem movimentoManualItemCRUD = new WS.CRUD.MovimentoManualItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.movimentoManualItems.Length; i++)
                {
                    input.movimentoManualItems[i].idMovimentoManual = new Data.MovimentoManual();
                    input.movimentoManualItems[i].idMovimentoManual.idMovimentoManual = bd.idMovimentoManual.value;
                    _parameters.Add("Key", input.movimentoManualItems[i]);
                    movimentoManualItemCRUD.atualizar(_parameters);
                    if (input.movimentoManualItems[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.movimentoManualItems[i] = (Data.MovimentoManualItem)movimentoManualItemCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                movimentoManualItemCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa ContasAReceberItem
            if (input.contasAReceberItems != null)
            {
                WS.CRUD.ContasAReceberItem contasAReceberItemCRUD = new WS.CRUD.ContasAReceberItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.contasAReceberItems.Length; i++)
                {
                    input.contasAReceberItems[i].idMovimentoManual = new Data.MovimentoManual();
                    input.contasAReceberItems[i].idMovimentoManual.idMovimentoManual = bd.idMovimentoManual.value;
                    _parameters.Add("Key", input.contasAReceberItems[i]);
                    contasAReceberItemCRUD.atualizar(_parameters);
                    if (input.contasAReceberItems[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.contasAReceberItems[i] = (Data.ContasAReceberItem)contasAReceberItemCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                contasAReceberItemCRUD = null;
                _parameters = null;
            }
            else { }

            return this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.MovimentoManual input = (Data.MovimentoManual)parametros["Key"];
            Tables.MovimentoManual bd = (Tables.MovimentoManual)this.m_EntityManager.find
            (
                typeof(Tables.MovimentoManual),
                new Object[]
                {
                    input.idMovimentoManual
                }
            );

            bd.idMovimentoManual.isNull = true;
            bd.descricao.value = input.descricao;
            bd.dataMovimento.value = input.dataMovimento;
            if (input.idPessoa != null)
                bd.idPessoa.idPessoa.value = input.idPessoa.idPessoa;
            else { }
            bd.valor.value = input.valor;
            bd.ocorrencias.value = input.ocorrencias;
            bd.pagarReceber.value = input.pagarReceber;

            this.m_EntityManager.merge(bd);

            //Processa ContasAPagarItem
            if (input.contasAPagarItems != null)
            {
                WS.CRUD.ContasAPagarItem contasAPagarItemCRUD = new WS.CRUD.ContasAPagarItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.contasAPagarItems.Length; i++)
                {
                    input.contasAPagarItems[i].idMovimentoManual = bd.idMovimentoManual.value;
                    _parameters.Add("Key", input.contasAPagarItems[i]);
                    if (input.contasAPagarItems[i].operacao == ENum.eOperacao.NONE)
                        input.contasAPagarItems[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    contasAPagarItemCRUD.atualizar(_parameters);
                    if (input.contasAPagarItems[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.contasAPagarItems[i] = (Data.ContasAPagarItem)contasAPagarItemCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                contasAPagarItemCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa MovimentoManualItem
            if (input.movimentoManualItems != null)
            {
                WS.CRUD.MovimentoManualItem movimentoManualItemCRUD = new WS.CRUD.MovimentoManualItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.movimentoManualItems.Length; i++)
                {
                    input.movimentoManualItems[i].idMovimentoManual = new Data.MovimentoManual();
                    input.movimentoManualItems[i].idMovimentoManual.idMovimentoManual = bd.idMovimentoManual.value;
                    _parameters.Add("Key", input.movimentoManualItems[i]);
                    if (input.movimentoManualItems[i].operacao == ENum.eOperacao.NONE)
                        input.movimentoManualItems[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    movimentoManualItemCRUD.atualizar(_parameters);
                    if (input.movimentoManualItems[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.movimentoManualItems[i] = (Data.MovimentoManualItem)movimentoManualItemCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                movimentoManualItemCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa ContasAReceberItem
            if (input.contasAReceberItems != null)
            {
                WS.CRUD.ContasAReceberItem contasAReceberItemCRUD = new WS.CRUD.ContasAReceberItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.contasAReceberItems.Length; i++)
                {
                    input.contasAReceberItems[i].idMovimentoManual = new Data.MovimentoManual();
                    input.contasAReceberItems[i].idMovimentoManual.idMovimentoManual = bd.idMovimentoManual.value;
                    _parameters.Add("Key", input.contasAReceberItems[i]);
                    if (input.contasAReceberItems[i].operacao == ENum.eOperacao.NONE)
                        input.contasAReceberItems[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    contasAReceberItemCRUD.atualizar(_parameters);
                    if (input.contasAReceberItems[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.contasAReceberItems[i] = (Data.ContasAReceberItem)contasAReceberItemCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                contasAReceberItemCRUD = null;
                _parameters = null;
            }
            else { }

            return this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.MovimentoManual bd = new Tables.MovimentoManual();

            bd.idMovimentoManual.value = ((Data.MovimentoManual)parametros["Key"]).idMovimentoManual;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
                if
                (
                    !((Tables.MovimentoManual)bd).idMovimentoManual.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.MovimentoManual)input).operacao = ENum.eOperacao.NONE;

                    ((Data.MovimentoManual)input).idMovimentoManual = ((Tables.MovimentoManual)bd).idMovimentoManual.value;
                    ((Data.MovimentoManual)input).descricao = ((Tables.MovimentoManual)bd).descricao.value;
                    ((Data.MovimentoManual)input).dataMovimento = ((Tables.MovimentoManual)bd).dataMovimento.value;
                    ((Data.MovimentoManual)input).idPessoa = (Data.Pessoa)(new WS.CRUD.Pessoa(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Pessoa(),
                        ((Tables.MovimentoManual)bd).idPessoa,
                        level + 1
                    );
                    ((Data.MovimentoManual)input).valor = ((Tables.MovimentoManual)bd).valor.value;
                    ((Data.MovimentoManual)input).ocorrencias = ((Tables.MovimentoManual)bd).ocorrencias.value;
                    ((Data.MovimentoManual)input).pagarReceber = ((Tables.MovimentoManual)bd).pagarReceber.value;
                }
                else { }
            else { }

            if (level < 1)
            {
                //Preencher ContasAPagarItems
                if (((Tables.MovimentoManual)bd).contasAPagarItems != null)
                {
                    System.Collections.Generic.List<Data.ContasAPagarItem> _list = new System.Collections.Generic.List<Data.ContasAPagarItem>();

                    foreach (Tables.ContasAPagarItem _item in ((Tables.MovimentoManual)bd).contasAPagarItems)
                    {
                        _list.Add
                        (
                            (Data.ContasAPagarItem)
                            (new WS.CRUD.ContasAPagarItem(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                            (
                                new Data.ContasAPagarItem(),
                                _item,
                                level + 1
                            )
                        );
                    }

                    ((Data.MovimentoManual)input).contasAPagarItems = _list.ToArray();
                    _list.Clear();
                    _list = null;
                }
                else
                {
                    if (((Data.MovimentoManual)input).contasAPagarItems != null)
                    {
                        System.Collections.Generic.List<Data.ContasAPagarItem> _list = new System.Collections.Generic.List<Data.ContasAPagarItem>();

                        foreach (Data.ContasAPagarItem _item in ((Data.MovimentoManual)input).contasAPagarItems)
                        {
                            if (_item.operacao != ENum.eOperacao.EXCLUIR)
                            {
                                _item.operacao = ENum.eOperacao.NONE;
                                _list.Add(_item);
                            }
                            else { }
                        }

                        if (_list.Count > 0)
                            ((Data.MovimentoManual)input).contasAPagarItems = _list.ToArray();
                        else
                            ((Data.MovimentoManual)input).contasAPagarItems = null;

                        _list.Clear();
                        _list = null;
                    }
                    else { }
                }
            }
            else { }
            if (level < 1)
            {
                //Preencher MovimentoManualItems
                if (((Tables.MovimentoManual)bd).movimentoManualItems != null)
                {
                    System.Collections.Generic.List<Data.MovimentoManualItem> _list = new System.Collections.Generic.List<Data.MovimentoManualItem>();

                    foreach (Tables.MovimentoManualItem _item in ((Tables.MovimentoManual)bd).movimentoManualItems)
                    {
                        _list.Add
                        (
                            (Data.MovimentoManualItem)
                            (new WS.CRUD.MovimentoManualItem(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                            (
                                new Data.MovimentoManualItem(),
                                _item,
                                level + 1
                            )
                        );
                    }

                    ((Data.MovimentoManual)input).movimentoManualItems = _list.ToArray();
                    _list.Clear();
                    _list = null;
                }
                else
                {
                    if (((Data.MovimentoManual)input).movimentoManualItems != null)
                    {
                        System.Collections.Generic.List<Data.MovimentoManualItem> _list = new System.Collections.Generic.List<Data.MovimentoManualItem>();

                        foreach (Data.MovimentoManualItem _item in ((Data.MovimentoManual)input).movimentoManualItems)
                        {
                            if (_item.operacao != ENum.eOperacao.EXCLUIR)
                            {
                                _item.operacao = ENum.eOperacao.NONE;
                                _list.Add(_item);
                            }
                            else { }
                        }

                        if (_list.Count > 0)
                            ((Data.MovimentoManual)input).movimentoManualItems = _list.ToArray();
                        else
                            ((Data.MovimentoManual)input).movimentoManualItems = null;

                        _list.Clear();
                        _list = null;
                    }
                    else { }
                }
            }
            else { }
            if (level < 1)
            {
                //Preencher ContasAReceberItems
                if (((Tables.MovimentoManual)bd).contasAReceberItems != null)
                {
                    System.Collections.Generic.List<Data.ContasAReceberItem> _list = new System.Collections.Generic.List<Data.ContasAReceberItem>();

                    foreach (Tables.ContasAReceberItem _item in ((Tables.MovimentoManual)bd).contasAReceberItems)
                    {
                        _list.Add
                        (
                            (Data.ContasAReceberItem)
                            (new WS.CRUD.ContasAReceberItem(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                            (
                                new Data.ContasAReceberItem(),
                                _item,
                                level + 1
                            )
                        );
                    }

                    ((Data.MovimentoManual)input).contasAReceberItems = _list.ToArray();
                    _list.Clear();
                    _list = null;
                }
                else
                {
                    if (((Data.MovimentoManual)input).contasAReceberItems != null)
                    {
                        System.Collections.Generic.List<Data.ContasAReceberItem> _list = new System.Collections.Generic.List<Data.ContasAReceberItem>();

                        foreach (Data.ContasAReceberItem _item in ((Data.MovimentoManual)input).contasAReceberItems)
                        {
                            if (_item.operacao != ENum.eOperacao.EXCLUIR)
                            {
                                _item.operacao = ENum.eOperacao.NONE;
                                _list.Add(_item);
                            }
                            else { }
                        }

                        if (_list.Count > 0)
                            ((Data.MovimentoManual)input).contasAReceberItems = _list.ToArray();
                        else
                            ((Data.MovimentoManual)input).contasAReceberItems = null;

                        _list.Clear();
                        _list = null;
                    }
                    else { }
                }
            }
            else { }
            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.MovimentoManual result = (Data.MovimentoManual)parametros["Key"];

            try
            {
                result = (Data.MovimentoManual)this.preencher
                (
                    new Data.MovimentoManual(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.MovimentoManual),
                        new Object[]
                        {
                            result.idMovimentoManual
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
            Data.MovimentoManual input = (Data.MovimentoManual)parametros["Key"];
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
                    typeof(Tables.MovimentoManual),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.MovimentoManual _data in
                    (System.Collections.Generic.List<Tables.MovimentoManual>)this.m_EntityManager.list
                    (
                        typeof(Tables.MovimentoManual),
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
                    _base = (Data.Base)this.preencher(new Data.MovimentoManual(), _data, level);

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
