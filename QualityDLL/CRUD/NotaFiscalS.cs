using System;

namespace WS.CRUD
{
    public class NotaFiscalS : WS.CRUD.Base
    {
        public NotaFiscalS(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.NotaFiscalS input = (Data.NotaFiscalS)parametros["Key"];
            Tables.NotaFiscalS bd = new Tables.NotaFiscalS();

            bd.idNotaFiscalS.isNull = true;
            if (input.empresaRelacionamento != null)
                bd.empresaRelacionamento.idEmpresaRelacionamento.value = input.empresaRelacionamento.idEmpresaRelacionamento;
            else { }
            bd.dataFaturamento.value = input.dataFaturamento;
            bd.valor.value = input.valor;
            bd.iss.value = input.iss;
            bd.dataVencimento.value = input.dataVencimento;
            bd.numeroLote.value = input.numeroLote;
            bd.numeroRPS.value = input.numeroRPS;
            bd.numeroNFSE.value = input.numeroNFSE;
            bd.codigoValidacaoNFSE.value = input.codigoValidacaoNFSE;
            if ((input.tipoMovimentoContabil != null) && (input.tipoMovimentoContabil.idTipoMovimentoContabil > 0))
                bd.tipoMovimentoContabil.idTipoMovimentoContabil.value = input.tipoMovimentoContabil.idTipoMovimentoContabil;
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.NotaFiscalS)parametros["Key"]).idNotaFiscalS = (int)bd.idNotaFiscalS.value;

            //Processa NotaFiscalSItem
            if (input.notaFiscalSItems != null)
            {
                WS.CRUD.NotaFiscalSItem notaFiscalSItemCRUD = new WS.CRUD.NotaFiscalSItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.notaFiscalSItems.Length; i++)
                {
                    input.notaFiscalSItems[i].notaFiscal = new Data.NotaFiscalS();
                    input.notaFiscalSItems[i].notaFiscal.idNotaFiscalS = bd.idNotaFiscalS.value;
                    _parameters.Add("Key", input.notaFiscalSItems[i]);
                    notaFiscalSItemCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                notaFiscalSItemCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.NotaFiscalS input = (Data.NotaFiscalS)parametros["Key"];
            Tables.NotaFiscalS bd = (Tables.NotaFiscalS)this.m_EntityManager.find
            (
                typeof(Tables.NotaFiscalS),
                new Object[]
                {
                    input.idNotaFiscalS
                }
            );

            if (input.empresaRelacionamento != null)
                bd.empresaRelacionamento.idEmpresaRelacionamento.value = input.empresaRelacionamento.idEmpresaRelacionamento;
            else { }
            bd.dataFaturamento.value = input.dataFaturamento;
            bd.valor.value = input.valor;
            bd.iss.value = input.iss;
            bd.dataVencimento.value = input.dataVencimento;
            bd.numeroLote.value = input.numeroLote;
            bd.numeroRPS.value = input.numeroRPS;
            bd.numeroNFSE.value = input.numeroNFSE;
            bd.codigoValidacaoNFSE.value = input.codigoValidacaoNFSE;
            if ((input.tipoMovimentoContabil != null) && (input.tipoMovimentoContabil.idTipoMovimentoContabil > 0))
                bd.tipoMovimentoContabil.idTipoMovimentoContabil.value = input.tipoMovimentoContabil.idTipoMovimentoContabil;
            else { }

            this.m_EntityManager.merge(bd);

            //Processa NotaFiscalSItem
            if (input.notaFiscalSItems != null)
            {
                WS.CRUD.NotaFiscalSItem notaFiscalSItemCRUD = new WS.CRUD.NotaFiscalSItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.notaFiscalSItems.Length; i++)
                {
                    input.notaFiscalSItems[i].notaFiscal = new Data.NotaFiscalS();
                    input.notaFiscalSItems[i].notaFiscal.idNotaFiscalS = bd.idNotaFiscalS.value;
                    _parameters.Add("Key", input.notaFiscalSItems[i]);
                    if (input.notaFiscalSItems[i].operacao == ENum.eOperacao.NONE)
                        input.notaFiscalSItems[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    notaFiscalSItemCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                notaFiscalSItemCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.NotaFiscalS bd = new Tables.NotaFiscalS();

            bd.idNotaFiscalS.value = ((Data.NotaFiscalS)parametros["Key"]).idNotaFiscalS;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.NotaFiscalS)bd).idNotaFiscalS.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.NotaFiscalS)input).operacao = ENum.eOperacao.NONE;

                    ((Data.NotaFiscalS)input).idNotaFiscalS = ((Tables.NotaFiscalS)bd).idNotaFiscalS.value;
                    ((Data.NotaFiscalS)input).empresaRelacionamento = (Data.EmpresaRelacionamento)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.EmpresaRelacionamento(),
                        ((Tables.NotaFiscalS)bd).empresaRelacionamento,
                        level + 1
                    );
                    ((Data.NotaFiscalS)input).dataFaturamento = ((Tables.NotaFiscalS)bd).dataFaturamento.value;
                    ((Data.NotaFiscalS)input).valor = ((Tables.NotaFiscalS)bd).valor.value;
                    ((Data.NotaFiscalS)input).iss = ((Tables.NotaFiscalS)bd).iss.value;
                    ((Data.NotaFiscalS)input).dataVencimento = ((Tables.NotaFiscalS)bd).dataVencimento.value;
                    ((Data.NotaFiscalS)input).numeroLote = ((Tables.NotaFiscalS)bd).numeroLote.value;
                    ((Data.NotaFiscalS)input).numeroRPS = ((Tables.NotaFiscalS)bd).numeroRPS.value;
                    ((Data.NotaFiscalS)input).numeroNFSE = ((Tables.NotaFiscalS)bd).numeroNFSE.value;
                    ((Data.NotaFiscalS)input).codigoValidacaoNFSE = ((Tables.NotaFiscalS)bd).codigoValidacaoNFSE.value;
                    ((Data.NotaFiscalS)input).tipoMovimentoContabil = (Data.TipoMovimentoContabil)(new WS.CRUD.TipoMovimentoContabil(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoMovimentoContabil(),
                        ((Tables.NotaFiscalS)bd).tipoMovimentoContabil,
                        level + 1
                    );
                }
                else { }

                if (level < 1)
                {
                    //Preencher NotaFiscalSItems
                    if (((Tables.NotaFiscalS)bd).notaFiscalSItems != null)
                    {
                        System.Collections.Generic.List<Data.NotaFiscalSItem> _list = new System.Collections.Generic.List<Data.NotaFiscalSItem>();

                        foreach (Tables.NotaFiscalSItem _item in ((Tables.NotaFiscalS)bd).notaFiscalSItems)
                        {
                            _list.Add
                            (
                                (Data.NotaFiscalSItem)
                                (new WS.CRUD.NotaFiscalSItem(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.NotaFiscalSItem(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.NotaFiscalS)input).notaFiscalSItems = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.NotaFiscalS)input).notaFiscalSItems != null)
                        {
                            System.Collections.Generic.List<Data.NotaFiscalSItem> _list = new System.Collections.Generic.List<Data.NotaFiscalSItem>();

                            foreach (Data.NotaFiscalSItem _item in ((Data.NotaFiscalS)input).notaFiscalSItems)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.NotaFiscalS)input).notaFiscalSItems = _list.ToArray();
                            else
                                ((Data.NotaFiscalS)input).notaFiscalSItems = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.NotaFiscalS result = (Data.NotaFiscalS)parametros["Key"];

            try
            {
                result = (Data.NotaFiscalS)this.preencher
                (
                    new Data.NotaFiscalS(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.NotaFiscalS),
                        new Object[]
                        {
                            result.idNotaFiscalS
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
            Data.NotaFiscalS input = (Data.NotaFiscalS)parametros["Key"];
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
                    typeof(Tables.NotaFiscalS),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.NotaFiscalS _data in
                    (System.Collections.Generic.List<Tables.NotaFiscalS>)this.m_EntityManager.list
                    (
                        typeof(Tables.NotaFiscalS),
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
                    _base = (Data.Base)this.preencher(new Data.NotaFiscalS(), _data, level);

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
