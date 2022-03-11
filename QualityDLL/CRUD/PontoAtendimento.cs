using System;

namespace WS.CRUD
{
    public class PontoAtendimento : WS.CRUD.Base
    {
        public PontoAtendimento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PontoAtendimento input = (Data.PontoAtendimento)parametros["Key"];
            Tables.PontoAtendimento bd = new Tables.PontoAtendimento();

            bd.idPontoAtendimento.isNull = true;
            bd.descricao.value = input.descricao;
            bd.tipo.value = input.tipo;

            this.m_EntityManager.persist(bd);

            ((Data.PontoAtendimento)parametros["Key"]).idPontoAtendimento = (int)bd.idPontoAtendimento.value;

            //Processa Atendimento
            if (input.atendimentos != null)
            {
                WS.CRUD.Atendimento atendimentoCRUD = new WS.CRUD.Atendimento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.atendimentos.Length; i++)
                {
                    input.atendimentos[i].pontoAtendimento = new Data.PontoAtendimento();
                    input.atendimentos[i].pontoAtendimento.idPontoAtendimento = bd.idPontoAtendimento.value;
                    _parameters.Add("Key", input.atendimentos[i]);
                    atendimentoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                atendimentoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PontoAtendimento input = (Data.PontoAtendimento)parametros["Key"];
            Tables.PontoAtendimento bd = (Tables.PontoAtendimento)this.m_EntityManager.find
            (
                typeof(Tables.PontoAtendimento),
                new Object[]
                {
                    input.idPontoAtendimento
                }
            );

            bd.descricao.value = input.descricao;
            bd.tipo.value = input.tipo;

            this.m_EntityManager.merge(bd);

            //Processa Atendimento
            if (input.atendimentos != null)
            {
                WS.CRUD.Atendimento atendimentoCRUD = new WS.CRUD.Atendimento(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.atendimentos.Length; i++)
                {
                    input.atendimentos[i].pontoAtendimento = new Data.PontoAtendimento();
                    input.atendimentos[i].pontoAtendimento.idPontoAtendimento = bd.idPontoAtendimento.value;
                    _parameters.Add("Key", input.atendimentos[i]);
                    if (input.atendimentos[i].operacao == ENum.eOperacao.NONE)
                        input.atendimentos[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    atendimentoCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                atendimentoCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PontoAtendimento bd = new Tables.PontoAtendimento();

            bd.idPontoAtendimento.value = ((Data.PontoAtendimento)parametros["Key"]).idPontoAtendimento;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PontoAtendimento)bd).idPontoAtendimento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PontoAtendimento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PontoAtendimento)input).idPontoAtendimento = ((Tables.PontoAtendimento)bd).idPontoAtendimento.value;
                    ((Data.PontoAtendimento)input).descricao = ((Tables.PontoAtendimento)bd).descricao.value;
                    ((Data.PontoAtendimento)input).tipo = ((Tables.PontoAtendimento)bd).tipo.value;
                }
                else { }

                if (level < 1)
                {
                    //Preencher Atendimentos
                    if (((Tables.PontoAtendimento)bd).atendimentos != null)
                    {
                        System.Collections.Generic.List<Data.Atendimento> _list = new System.Collections.Generic.List<Data.Atendimento>();

                        foreach (Tables.Atendimento _item in ((Tables.PontoAtendimento)bd).atendimentos)
                        {
                            _list.Add
                            (
                                (Data.Atendimento)
                                (new WS.CRUD.Atendimento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.Atendimento(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.PontoAtendimento)input).atendimentos = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.PontoAtendimento)input).atendimentos != null)
                        {
                            System.Collections.Generic.List<Data.Atendimento> _list = new System.Collections.Generic.List<Data.Atendimento>();

                            foreach (Data.Atendimento _item in ((Data.PontoAtendimento)input).atendimentos)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.PontoAtendimento)input).atendimentos = _list.ToArray();
                            else
                                ((Data.PontoAtendimento)input).atendimentos = null;

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
            Data.PontoAtendimento result = (Data.PontoAtendimento)parametros["Key"];

            try
            {
                result = (Data.PontoAtendimento)this.preencher
                (
                    new Data.PontoAtendimento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.PontoAtendimento),
                        new Object[]
                        {
                            result.idPontoAtendimento
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
            Data.PontoAtendimento input = (Data.PontoAtendimento)parametros["Key"];
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
                    typeof(Tables.PontoAtendimento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.PontoAtendimento _data in
                    (System.Collections.Generic.List<Tables.PontoAtendimento>)this.m_EntityManager.list
                    (
                        typeof(Tables.PontoAtendimento),
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
                    _base = (Data.Base)this.preencher(new Data.PontoAtendimento(), _data, level);

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
