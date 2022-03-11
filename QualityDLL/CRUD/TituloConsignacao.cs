using System;

namespace WS.CRUD
{
    public class TituloConsignacao : WS.CRUD.Base
    {
        public TituloConsignacao(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.TituloConsignacao input = (Data.TituloConsignacao)parametros["Key"];
            Tables.TituloConsignacao bd = new Tables.TituloConsignacao();

            bd.idTituloConsignacao.isNull = true;
            if (input.titulo != null)
                bd.titulo.idTitulo.value = input.titulo.idTitulo;
            else { }
            if (input.corretorEmpresaRelacionamento != null)
                bd.corretorEmpresaRelacionamento.idEmpresaRelacionamento.value = input.corretorEmpresaRelacionamento.idEmpresaRelacionamento;
            else { }
            bd.dataConsignacao.value = input.dataConsignacao;
            bd.dataDevolucao.value = input.dataDevolucao;
            bd.motivo.value = input.motivo;
            bd.observacao.value = input.observacao;

            this.m_EntityManager.persist(bd);

            ((Data.TituloConsignacao)parametros["Key"]).idTituloConsignacao = (int)bd.idTituloConsignacao.value;

            //Processa TituloConsignacaoVenda
            if (input.tituloConsignacaoVendas != null)
            {
                WS.CRUD.TituloConsignacaoVenda tituloConsignacaoVendaCRUD = new WS.CRUD.TituloConsignacaoVenda(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.tituloConsignacaoVendas.Length; i++)
                {
                    input.tituloConsignacaoVendas[i].tituloConsignacaoVenda = new Data.TituloConsignacao();
                    input.tituloConsignacaoVendas[i].tituloConsignacaoVenda.idTituloConsignacao = bd.idTituloConsignacao.value;
                    _parameters.Add("Key", input.tituloConsignacaoVendas[i]);
                    tituloConsignacaoVendaCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                tituloConsignacaoVendaCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.TituloConsignacao input = (Data.TituloConsignacao)parametros["Key"];
            Tables.TituloConsignacao bd = (Tables.TituloConsignacao)this.m_EntityManager.find
            (
                typeof(Tables.TituloConsignacao),
                new Object[]
                {
                    input.idTituloConsignacao
                }
            );

            if (input.titulo != null)
                bd.titulo.idTitulo.value = input.titulo.idTitulo;
            else { }
            if (input.corretorEmpresaRelacionamento != null)
                bd.corretorEmpresaRelacionamento.idEmpresaRelacionamento.value = input.corretorEmpresaRelacionamento.idEmpresaRelacionamento;
            else { }
            bd.dataConsignacao.value = input.dataConsignacao;
            bd.dataDevolucao.value = input.dataDevolucao;
            bd.motivo.value = input.motivo;
            bd.observacao.value = input.observacao;

            this.m_EntityManager.merge(bd);

            //Processa TituloConsignacaoVenda
            if (input.tituloConsignacaoVendas != null)
            {
                WS.CRUD.TituloConsignacaoVenda tituloConsignacaoVendaCRUD = new WS.CRUD.TituloConsignacaoVenda(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.tituloConsignacaoVendas.Length; i++)
                {
                    input.tituloConsignacaoVendas[i].tituloConsignacaoVenda = new Data.TituloConsignacao();
                    input.tituloConsignacaoVendas[i].tituloConsignacaoVenda.idTituloConsignacao = bd.idTituloConsignacao.value;
                    _parameters.Add("Key", input.tituloConsignacaoVendas[i]);
                    if (input.tituloConsignacaoVendas[i].operacao == ENum.eOperacao.NONE)
                        input.tituloConsignacaoVendas[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    tituloConsignacaoVendaCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                tituloConsignacaoVendaCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.TituloConsignacao bd = new Tables.TituloConsignacao();

            bd.idTituloConsignacao.value = ((Data.TituloConsignacao)parametros["Key"]).idTituloConsignacao;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.TituloConsignacao)bd).idTituloConsignacao.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.TituloConsignacao)input).operacao = ENum.eOperacao.NONE;

                    ((Data.TituloConsignacao)input).idTituloConsignacao = ((Tables.TituloConsignacao)bd).idTituloConsignacao.value;
                    ((Data.TituloConsignacao)input).titulo = (Data.Titulo)(new WS.CRUD.Titulo(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Titulo(),
                        ((Tables.TituloConsignacao)bd).titulo,
                        level + 1
                    );
                    ((Data.TituloConsignacao)input).corretorEmpresaRelacionamento = (Data.EmpresaRelacionamento)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.EmpresaRelacionamento(),
                        ((Tables.TituloConsignacao)bd).corretorEmpresaRelacionamento,
                        level + 1
                    );
                    ((Data.TituloConsignacao)input).dataConsignacao = ((Tables.TituloConsignacao)bd).dataConsignacao.value;
                    ((Data.TituloConsignacao)input).dataDevolucao = ((Tables.TituloConsignacao)bd).dataDevolucao.value;
                    ((Data.TituloConsignacao)input).motivo = ((Tables.TituloConsignacao)bd).motivo.value;
                    ((Data.TituloConsignacao)input).observacao = ((Tables.TituloConsignacao)bd).observacao.value;
                }
                else { }

                if (level < 1)
                {
                    //Preencher TituloConsignacaoVendas
                    if (((Tables.TituloConsignacao)bd).tituloConsignacaoVendas != null)
                    {
                        System.Collections.Generic.List<Data.TituloConsignacaoVenda> _list = new System.Collections.Generic.List<Data.TituloConsignacaoVenda>();

                        foreach (Tables.TituloConsignacaoVenda _item in ((Tables.TituloConsignacao)bd).tituloConsignacaoVendas)
                        {
                            _list.Add
                            (
                                (Data.TituloConsignacaoVenda)
                                (new WS.CRUD.TituloConsignacaoVenda(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.TituloConsignacaoVenda(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.TituloConsignacao)input).tituloConsignacaoVendas = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.TituloConsignacao)input).tituloConsignacaoVendas != null)
                        {
                            System.Collections.Generic.List<Data.TituloConsignacaoVenda> _list = new System.Collections.Generic.List<Data.TituloConsignacaoVenda>();

                            foreach (Data.TituloConsignacaoVenda _item in ((Data.TituloConsignacao)input).tituloConsignacaoVendas)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.TituloConsignacao)input).tituloConsignacaoVendas = _list.ToArray();
                            else
                                ((Data.TituloConsignacao)input).tituloConsignacaoVendas = null;

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
            Data.TituloConsignacao result = (Data.TituloConsignacao)parametros["Key"];

            try
            {
                result = (Data.TituloConsignacao)this.preencher
                (
                    new Data.TituloConsignacao(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.TituloConsignacao),
                        new Object[]
                        {
                            result.idTituloConsignacao
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
            Data.TituloConsignacao input = (Data.TituloConsignacao)parametros["Key"];
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
                    typeof(Tables.TituloConsignacao),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.TituloConsignacao _data in
                    (System.Collections.Generic.List<Tables.TituloConsignacao>)this.m_EntityManager.list
                    (
                        typeof(Tables.TituloConsignacao),
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
                    _base = (Data.Base)this.preencher(new Data.TituloConsignacao(), _data, level);

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
