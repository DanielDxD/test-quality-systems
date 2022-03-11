using System;

namespace WS.CRUD
{
    public class ContratoTipoItem : WS.CRUD.Base
    {
        public ContratoTipoItem(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ContratoTipoItem input = (Data.ContratoTipoItem)parametros["Key"];
            Tables.ContratoTipoItem bd = new Tables.ContratoTipoItem();

            bd.idContratoTipoItem.isNull = true;

            if (input.contratoTipo != null && input.contratoTipo.idContratoTipo > 0)
                bd.contratoTipo.idContratoTipo.value = input.contratoTipo.idContratoTipo;
            else
                bd.contratoTipo.idContratoTipo.isNull = true;

            if (input.naturezaOperacao != null && input.naturezaOperacao.idNaturezaOperacao > 0)
                bd.naturezaOperacao.idNaturezaOperacao.value = input.naturezaOperacao.idNaturezaOperacao;
            else
                bd.naturezaOperacao.idNaturezaOperacao.isNull = true;

            if (input.departamento != null && input.departamento.idDepartamento > 0)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else
                bd.departamento.idDepartamento.isNull = true;

            if (input.tipoRelacionamento != null && input.tipoRelacionamento.idTipoRelacionamento > 0)
                bd.tipoRelacionamento.idTipoRelacionamento.value = input.tipoRelacionamento.idTipoRelacionamento;
            else
                bd.tipoRelacionamento.idTipoRelacionamento.isNull = true;

            bd.descricao.value = input.descricao;

            bd.genero.value = input.genero;
            bd.idadeFinal.value = input.idadeFinal;
            bd.idadeInicial.value = input.idadeInicial;
            bd.dtAdmissaoInicial.value = input.dtAdmissaoInicial;
            if (input.dtAdmissaoFinal.Ticks > 0)
                bd.dtAdmissaoFinal.value = input.dtAdmissaoFinal;
            else { }


            this.m_EntityManager.persist(bd);

            ((Data.ContratoTipoItem)parametros["Key"]).idContratoTipoItem = (int)bd.idContratoTipoItem.value;

            if (input.contratoTipoItemValor != null)
            {
                WS.CRUD.ContratoTipoItemValor contratoTipoItemValorCRUD = new WS.CRUD.ContratoTipoItemValor(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.contratoTipoItemValor.Length; i++)
                {
                    input.contratoTipoItemValor[i].contratoTipoItem = new Data.ContratoTipoItem { idContratoTipoItem = bd.idContratoTipoItem.value };
                    _parameters.Add("Key", input.contratoTipoItemValor[i]);
                    contratoTipoItemValorCRUD.atualizar(_parameters);
                    if (input.contratoTipoItemValor[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.contratoTipoItemValor[i] = (Data.ContratoTipoItemValor)contratoTipoItemValorCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }
                _parameters = null;
                contratoTipoItemValorCRUD = null;
            }
            else { }



            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ContratoTipoItem input = (Data.ContratoTipoItem)parametros["Key"];
            Tables.ContratoTipoItem bd = (Tables.ContratoTipoItem)this.m_EntityManager.find
            (
                typeof(Tables.ContratoTipoItem),
                new Object[]
                {
                    input.idContratoTipoItem
                }
            );
            if (input.contratoTipo != null && input.contratoTipo.idContratoTipo > 0)
                bd.contratoTipo.idContratoTipo.value = input.contratoTipo.idContratoTipo;
            else
                bd.contratoTipo.idContratoTipo.isNull = true;

            if (input.naturezaOperacao != null && input.naturezaOperacao.idNaturezaOperacao > 0)
                bd.naturezaOperacao.idNaturezaOperacao.value = input.naturezaOperacao.idNaturezaOperacao;
            else
                bd.naturezaOperacao.idNaturezaOperacao.isNull = true;

            if (input.departamento != null && input.departamento.idDepartamento > 0)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else
                bd.departamento.idDepartamento.isNull = true;

            if (input.tipoRelacionamento != null && input.tipoRelacionamento.idTipoRelacionamento > 0)
                bd.tipoRelacionamento.idTipoRelacionamento.value = input.tipoRelacionamento.idTipoRelacionamento;
            else
                bd.tipoRelacionamento.idTipoRelacionamento.isNull = true;

            bd.descricao.value = input.descricao;

            bd.genero.value = input.genero;
            bd.idadeFinal.value = input.idadeFinal;
            bd.idadeInicial.value = input.idadeInicial;
            bd.dtAdmissaoInicial.value = input.dtAdmissaoInicial;
            if (input.dtAdmissaoFinal.Ticks > 0)
                bd.dtAdmissaoFinal.value = input.dtAdmissaoFinal;
            else { }

            this.m_EntityManager.merge(bd);

            if (input.contratoTipoItemValor != null)
            {
                WS.CRUD.ContratoTipoItemValor contratoTipoItemValorCRUD = new WS.CRUD.ContratoTipoItemValor(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.contratoTipoItemValor.Length; i++)
                {
                    input.contratoTipoItemValor[i].contratoTipoItem = new Data.ContratoTipoItem { idContratoTipoItem = bd.idContratoTipoItem.value };
                    _parameters.Add("Key", input.contratoTipoItemValor[i]);
                    if (input.contratoTipoItemValor[i].operacao == ENum.eOperacao.NONE)
                        input.contratoTipoItemValor[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    contratoTipoItemValorCRUD.atualizar(_parameters);
                    if (input.contratoTipoItemValor[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.contratoTipoItemValor[i] = (Data.ContratoTipoItemValor)contratoTipoItemValorCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                _parameters = null;
                contratoTipoItemValorCRUD = null;
            }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ContratoTipoItem bd = new Tables.ContratoTipoItem();

            bd.idContratoTipoItem.value = ((Data.ContratoTipoItem)parametros["Key"]).idContratoTipoItem;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ContratoTipoItem)bd).idContratoTipoItem.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ContratoTipoItem)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ContratoTipoItem)input).idContratoTipoItem = ((Tables.ContratoTipoItem)bd).idContratoTipoItem.value;
                    ((Data.ContratoTipoItem)input).descricao = ((Tables.ContratoTipoItem)bd).descricao.value;
                    ((Data.ContratoTipoItem)input).genero = ((Tables.ContratoTipoItem)bd).genero.value;
                    ((Data.ContratoTipoItem)input).dtAdmissaoInicial = ((Tables.ContratoTipoItem)bd).dtAdmissaoInicial.value;
                    ((Data.ContratoTipoItem)input).dtAdmissaoFinal = ((Tables.ContratoTipoItem)bd).dtAdmissaoFinal.value;
                    ((Data.ContratoTipoItem)input).idadeInicial = ((Tables.ContratoTipoItem)bd).idadeInicial.value;
                    ((Data.ContratoTipoItem)input).idadeFinal = ((Tables.ContratoTipoItem)bd).idadeFinal.value;
                    ((Data.ContratoTipoItem)input).contratoTipo = (Data.ContratoTipo)(new WS.CRUD.ContratoTipo(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContratoTipo(),
                        ((Tables.ContratoTipoItem)bd).contratoTipo,
                        level + 1
                    );
                    ((Data.ContratoTipoItem)input).naturezaOperacao = (Data.NaturezaOperacao)(new WS.CRUD.NaturezaOperacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.NaturezaOperacao(),
                        ((Tables.ContratoTipoItem)bd).naturezaOperacao,
                        level + 1
                    );
                    ((Data.ContratoTipoItem)input).departamento = (Data.Departamento)(new WS.CRUD.Departamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Departamento(),
                        ((Tables.ContratoTipoItem)bd).departamento,
                        level + 1
                    );
                    ((Data.ContratoTipoItem)input).tipoRelacionamento = (Data.TipoRelacionamento)(new WS.CRUD.TipoRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoRelacionamento(),
                        ((Tables.ContratoTipoItem)bd).tipoRelacionamento,
                        level + 1
                    );

                    if (level < 2)
                    {
                        if (((Tables.ContratoTipoItem)bd).contratoTipoItemValor != null)
                        {
                            System.Collections.Generic.List<Data.ContratoTipoItemValor> _list = new System.Collections.Generic.List<Data.ContratoTipoItemValor>();

                            foreach (Tables.ContratoTipoItemValor _item in ((Tables.ContratoTipoItem)bd).contratoTipoItemValor)
                            {
                                _list.Add
                                (
                                    (Data.ContratoTipoItemValor)
                                    (new WS.CRUD.ContratoTipoItemValor(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.ContratoTipoItemValor(),
                                        _item,
                                        level + 1
                                    )
                                );
                            }

                            ((Data.ContratoTipoItem)input).contratoTipoItemValor = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.ContratoTipoItem)input).contratoTipoItemValor != null)
                            {
                                System.Collections.Generic.List<Data.ContratoTipoItemValor> _list = new System.Collections.Generic.List<Data.ContratoTipoItemValor>();

                                foreach (Data.ContratoTipoItemValor _item in ((Data.ContratoTipoItem)input).contratoTipoItemValor)
                                {
                                    if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                    {
                                        _item.operacao = ENum.eOperacao.NONE;
                                        _list.Add(_item);
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.ContratoTipoItem)input).contratoTipoItemValor = _list.ToArray();
                                else
                                    ((Data.ContratoTipoItem)input).contratoTipoItemValor = null;

                                _list.Clear();
                                _list = null;
                            }
                            else { }
                        }
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
            Data.ContratoTipoItem result = (Data.ContratoTipoItem)parametros["Key"];

            try
            {
                result = (Data.ContratoTipoItem)this.preencher
                (
                    new Data.ContratoTipoItem(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ContratoTipoItem),
                        new Object[]
                        {
                            result.idContratoTipoItem
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
            Data.ContratoTipoItem input = (Data.ContratoTipoItem)parametros["Key"];
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
                    typeof(Tables.ContratoTipoItem),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ContratoTipoItem _data in
                    (System.Collections.Generic.List<Tables.ContratoTipoItem>)this.m_EntityManager.list
                    (
                        typeof(Tables.ContratoTipoItem),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.ContratoTipoItem(), _data, level);

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
