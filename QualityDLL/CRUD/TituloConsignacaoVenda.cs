using System;

namespace WS.CRUD
{
    public class TituloConsignacaoVenda : WS.CRUD.Base
    {
        public TituloConsignacaoVenda(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.TituloConsignacaoVenda input = (Data.TituloConsignacaoVenda)parametros["Key"];
            Tables.TituloConsignacaoVenda bd = new Tables.TituloConsignacaoVenda();

            if (input.tituloConsignacaoVenda != null)
                bd.tituloConsignacaoVenda.idTituloConsignacao.value = input.tituloConsignacaoVenda.idTituloConsignacao;
            else { }
            bd.valor.value = input.valor;
            bd.valorComissao.value = input.valorComissao;
            bd.dataVenda.value = input.dataVenda;

            this.m_EntityManager.persist(bd);

            //Processa TituloConsignacaoVendaPagto
            if (input.tituloConsignacaoVendaPagtos != null)
            {
                WS.CRUD.TituloConsignacaoVendaPagto tituloConsignacaoVendaPagtoCRUD = new WS.CRUD.TituloConsignacaoVendaPagto(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.tituloConsignacaoVendaPagtos.Length; i++)
                {
                    input.tituloConsignacaoVendaPagtos[i].tituloConsignacaoVenda = new Data.TituloConsignacaoVenda();
                    input.tituloConsignacaoVendaPagtos[i].tituloConsignacaoVenda.tituloConsignacaoVenda = new Data.TituloConsignacao();
                    input.tituloConsignacaoVendaPagtos[i].tituloConsignacaoVenda.tituloConsignacaoVenda.idTituloConsignacao = bd.tituloConsignacaoVenda.idTituloConsignacao.value;
                    _parameters.Add("Key", input.tituloConsignacaoVendaPagtos[i]);
                    tituloConsignacaoVendaPagtoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                tituloConsignacaoVendaPagtoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.TituloConsignacaoVenda input = (Data.TituloConsignacaoVenda)parametros["Key"];
            Tables.TituloConsignacaoVenda bd = (Tables.TituloConsignacaoVenda)this.m_EntityManager.find
            (
                typeof(Tables.TituloConsignacaoVenda),
                new Object[]
                {
                    input.tituloConsignacaoVenda.idTituloConsignacao
                }
            );

            if (input.tituloConsignacaoVenda != null)
                bd.tituloConsignacaoVenda.idTituloConsignacao.value = input.tituloConsignacaoVenda.idTituloConsignacao;
            else { }
            bd.valor.value = input.valor;
            bd.valorComissao.value = input.valorComissao;
            bd.dataVenda.value = input.dataVenda;

            this.m_EntityManager.merge(bd);

            //Processa TituloConsignacaoVendaPagto
            if (input.tituloConsignacaoVendaPagtos != null)
            {
                WS.CRUD.TituloConsignacaoVendaPagto tituloConsignacaoVendaPagtoCRUD = new WS.CRUD.TituloConsignacaoVendaPagto(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.tituloConsignacaoVendaPagtos.Length; i++)
                {
                    input.tituloConsignacaoVendaPagtos[i].tituloConsignacaoVenda = new Data.TituloConsignacaoVenda();
                    input.tituloConsignacaoVendaPagtos[i].tituloConsignacaoVenda.tituloConsignacaoVenda = new Data.TituloConsignacao();
                    input.tituloConsignacaoVendaPagtos[i].tituloConsignacaoVenda.tituloConsignacaoVenda.idTituloConsignacao = bd.tituloConsignacaoVenda.idTituloConsignacao.value;
                    _parameters.Add("Key", input.tituloConsignacaoVendaPagtos[i]);
                    if (input.tituloConsignacaoVendaPagtos[i].operacao == ENum.eOperacao.NONE)
                        input.tituloConsignacaoVendaPagtos[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    tituloConsignacaoVendaPagtoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                tituloConsignacaoVendaPagtoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.TituloConsignacaoVenda bd = new Tables.TituloConsignacaoVenda();

            bd.tituloConsignacaoVenda.idTituloConsignacao.value = ((Data.TituloConsignacaoVenda)parametros["Key"]).tituloConsignacaoVenda.idTituloConsignacao;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.TituloConsignacaoVenda)bd).tituloConsignacaoVenda.idTituloConsignacao.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.TituloConsignacaoVenda)input).operacao = ENum.eOperacao.NONE;

                    ((Data.TituloConsignacaoVenda)input).tituloConsignacaoVenda = (Data.TituloConsignacao)(new WS.CRUD.TituloConsignacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TituloConsignacao(),
                        ((Tables.TituloConsignacaoVenda)bd).tituloConsignacaoVenda,
                        level + 1
                    );
                    ((Data.TituloConsignacaoVenda)input).valor = ((Tables.TituloConsignacaoVenda)bd).valor.value;
                    ((Data.TituloConsignacaoVenda)input).valorComissao = ((Tables.TituloConsignacaoVenda)bd).valorComissao.value;
                    ((Data.TituloConsignacaoVenda)input).dataVenda = ((Tables.TituloConsignacaoVenda)bd).dataVenda.value;
                }
                else { }

                if (level < 1)
                {
                    //Preencher TituloConsignacaoVendaPagtos
                    if (((Tables.TituloConsignacaoVenda)bd).tituloConsignacaoVendaPagtos != null)
                    {
                        System.Collections.Generic.List<Data.TituloConsignacaoVendaPagto> _list = new System.Collections.Generic.List<Data.TituloConsignacaoVendaPagto>();

                        foreach (Tables.TituloConsignacaoVendaPagto _item in ((Tables.TituloConsignacaoVenda)bd).tituloConsignacaoVendaPagtos)
                        {
                            _list.Add
                            (
                                (Data.TituloConsignacaoVendaPagto)
                                (new WS.CRUD.TituloConsignacaoVendaPagto(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.TituloConsignacaoVendaPagto(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.TituloConsignacaoVenda)input).tituloConsignacaoVendaPagtos = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.TituloConsignacaoVenda)input).tituloConsignacaoVendaPagtos != null)
                        {
                            System.Collections.Generic.List<Data.TituloConsignacaoVendaPagto> _list = new System.Collections.Generic.List<Data.TituloConsignacaoVendaPagto>();

                            foreach (Data.TituloConsignacaoVendaPagto _item in ((Data.TituloConsignacaoVenda)input).tituloConsignacaoVendaPagtos)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.TituloConsignacaoVenda)input).tituloConsignacaoVendaPagtos = _list.ToArray();
                            else
                                ((Data.TituloConsignacaoVenda)input).tituloConsignacaoVendaPagtos = null;

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
            Data.TituloConsignacaoVenda result = (Data.TituloConsignacaoVenda)parametros["Key"];

            try
            {
                result = (Data.TituloConsignacaoVenda)this.preencher
                (
                    new Data.TituloConsignacaoVenda(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.TituloConsignacaoVenda),
                        new Object[]
                        {
                            result.tituloConsignacaoVenda.idTituloConsignacao
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
            Data.TituloConsignacaoVenda input = (Data.TituloConsignacaoVenda)parametros["Key"];
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
                    typeof(Tables.TituloConsignacaoVenda),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.TituloConsignacaoVenda _data in
                    (System.Collections.Generic.List<Tables.TituloConsignacaoVenda>)this.m_EntityManager.list
                    (
                        typeof(Tables.TituloConsignacaoVenda),
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
                    _base = (Data.Base)this.preencher(new Data.TituloConsignacaoVenda(), _data, level);

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
