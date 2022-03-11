using System;

namespace WS.CRUD
{
    public class Caixa : WS.CRUD.Base
    {
        public Caixa(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Caixa input = (Data.Caixa)parametros["Key"];
            Tables.Caixa bd = new Tables.Caixa();

            bd.idCaixa.isNull = true;
            bd.dataCaixa.value = input.dataCaixa;
            if (input.departamento != null)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else { }
            bd.saldo.value = input.saldo;
            if (input.funcionario != null)
                bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.Caixa)parametros["Key"]).idCaixa = (int)bd.idCaixa.value;

            //Processa CaixaMovimento
            if (input.caixaMovimentos != null)
            {
                WS.CRUD.CaixaMovimento caixaMovimentoCRUD = new WS.CRUD.CaixaMovimento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.caixaMovimentos.Length; i++)
                {
                    input.caixaMovimentos[i].caixa = new Data.Caixa();
                    input.caixaMovimentos[i].caixa.idCaixa = bd.idCaixa.value;
                    _parameters.Add("Key", input.caixaMovimentos[i]);
                    caixaMovimentoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                caixaMovimentoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Caixa input = (Data.Caixa)parametros["Key"];
            Tables.Caixa bd = (Tables.Caixa)this.m_EntityManager.find
            (
                typeof(Tables.Caixa),
                new Object[]
                {
                    input.idCaixa
                }
            );

            bd.dataCaixa.value = input.dataCaixa;
            if (input.departamento != null)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else { }
            bd.saldo.value = input.saldo;
            if (input.funcionario != null)
                bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;
            else { }

            this.m_EntityManager.merge(bd);

            //Processa CaixaMovimento
            if (input.caixaMovimentos != null)
            {
                WS.CRUD.CaixaMovimento caixaMovimentoCRUD = new WS.CRUD.CaixaMovimento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.caixaMovimentos.Length; i++)
                {
                    input.caixaMovimentos[i].caixa = new Data.Caixa();
                    input.caixaMovimentos[i].caixa.idCaixa = bd.idCaixa.value;
                    _parameters.Add("Key", input.caixaMovimentos[i]);
                    if (input.caixaMovimentos[i].operacao == ENum.eOperacao.NONE)
                        input.caixaMovimentos[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    caixaMovimentoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                caixaMovimentoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Caixa bd = new Tables.Caixa();

            bd.idCaixa.value = ((Data.Caixa)parametros["Key"]).idCaixa;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Caixa)bd).idCaixa.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Caixa)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Caixa)input).idCaixa = ((Tables.Caixa)bd).idCaixa.value;
                    ((Data.Caixa)input).dataCaixa = ((Tables.Caixa)bd).dataCaixa.value;
                    ((Data.Caixa)input).departamento = (Data.Departamento)(new WS.CRUD.Departamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Departamento(),
                        ((Tables.Caixa)bd).departamento,
                        level + 1
                    );
                    ((Data.Caixa)input).saldo = ((Tables.Caixa)bd).saldo.value;
                    ((Data.Caixa)input).funcionario = (Data.Funcionario)(new WS.CRUD.Funcionario(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Funcionario(),
                        ((Tables.Caixa)bd).funcionario,
                        level + 1
                    );
                }
                else { }

                if (level < 1)
                {
                    //Preencher CaixaMovimentos
                    if (((Tables.Caixa)bd).caixaMovimentos != null)
                    {
                        System.Collections.Generic.List<Data.CaixaMovimento> _list = new System.Collections.Generic.List<Data.CaixaMovimento>();

                        foreach (Tables.CaixaMovimento _item in ((Tables.Caixa)bd).caixaMovimentos)
                        {
                            _list.Add
                            (
                                (Data.CaixaMovimento)
                                (new WS.CRUD.CaixaMovimento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.CaixaMovimento(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.Caixa)input).caixaMovimentos = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.Caixa)input).caixaMovimentos != null)
                        {
                            System.Collections.Generic.List<Data.CaixaMovimento> _list = new System.Collections.Generic.List<Data.CaixaMovimento>();

                            foreach (Data.CaixaMovimento _item in ((Data.Caixa)input).caixaMovimentos)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.Caixa)input).caixaMovimentos = _list.ToArray();
                            else
                                ((Data.Caixa)input).caixaMovimentos = null;

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
            Data.Caixa result = (Data.Caixa)parametros["Key"];

            try
            {
                result = (Data.Caixa)this.preencher
                (
                    new Data.Caixa(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Caixa),
                        new Object[]
                        {
                            result.idCaixa
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
            Data.Caixa input = (Data.Caixa)parametros["Key"];
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
                    typeof(Tables.Caixa),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Caixa _data in
                    (System.Collections.Generic.List<Tables.Caixa>)this.m_EntityManager.list
                    (
                        typeof(Tables.Caixa),
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
                    _base = (Data.Base)this.preencher(new Data.Caixa(), _data, level);

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
