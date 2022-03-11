using System;

namespace WS.CRUD
{
    public class RequisicaoInternaSituacao : WS.CRUD.Base
    {
        public RequisicaoInternaSituacao(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoInternaSituacao input = (Data.RequisicaoInternaSituacao)parametros["Key"];
            Tables.RequisicaoInternaSituacao bd = new Tables.RequisicaoInternaSituacao();

            bd.idRequisicaoInternaSituacao.isNull = true;
            if (input.idRequisicaoInterna > 0)
                bd.idRequisicaoInterna.value = input.idRequisicaoInterna;
            else { }
            bd.situacao.value = input.situacao;
            bd.dataSituacao.value = input.dataSituacao;
            bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.isNull = true;
            if (input.funcionario != null)
                if (input.funcionario.idEmpresaRelacionamento > 0)
                    bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;
                else { }
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.RequisicaoInternaSituacao)parametros["Key"]).idRequisicaoInternaSituacao = (int)bd.idRequisicaoInternaSituacao.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoInternaSituacao input = (Data.RequisicaoInternaSituacao)parametros["Key"];
            Tables.RequisicaoInternaSituacao bd = (Tables.RequisicaoInternaSituacao)this.m_EntityManager.find
            (
                typeof(Tables.RequisicaoInternaSituacao),
                new Object[]
                {
                    input.idRequisicaoInternaSituacao
                }
            );

            if (input.idRequisicaoInterna > 0)
                bd.idRequisicaoInterna.value = input.idRequisicaoInterna;
            else { }
            bd.situacao.value = input.situacao;
            bd.dataSituacao.value = input.dataSituacao;
            bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.isNull = true;
            if (input.funcionario != null)
                if (input.funcionario.idEmpresaRelacionamento > 0)
                    bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;
                else { }
            else { }

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.RequisicaoInternaSituacao bd = new Tables.RequisicaoInternaSituacao();

            bd.idRequisicaoInternaSituacao.value = ((Data.RequisicaoInternaSituacao)parametros["Key"]).idRequisicaoInternaSituacao;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.RequisicaoInternaSituacao)bd).idRequisicaoInternaSituacao.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.RequisicaoInternaSituacao)input).operacao = ENum.eOperacao.NONE;

                    ((Data.RequisicaoInternaSituacao)input).idRequisicaoInternaSituacao = ((Tables.RequisicaoInternaSituacao)bd).idRequisicaoInternaSituacao.value;
                    ((Data.RequisicaoInternaSituacao)input).idRequisicaoInterna = ((Tables.RequisicaoInternaSituacao)bd).idRequisicaoInterna.value;
                    ((Data.RequisicaoInternaSituacao)input).situacao = ((Tables.RequisicaoInternaSituacao)bd).situacao.value;
                    ((Data.RequisicaoInternaSituacao)input).dataSituacao = ((Tables.RequisicaoInternaSituacao)bd).dataSituacao.value;
                    ((Data.RequisicaoInternaSituacao)input).funcionario = (Data.Funcionario)(new WS.CRUD.Funcionario(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Funcionario(),
                        ((Tables.RequisicaoInternaSituacao)bd).funcionario,
                        level + 1
                    );
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoInternaSituacao result = (Data.RequisicaoInternaSituacao)parametros["Key"];

            try
            {
                result = (Data.RequisicaoInternaSituacao)this.preencher
                (
                    new Data.RequisicaoInternaSituacao(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.RequisicaoInternaSituacao),
                        new Object[]
                        {
                            result.idRequisicaoInternaSituacao
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
            Data.RequisicaoInternaSituacao input = (Data.RequisicaoInternaSituacao)parametros["Key"];
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
                    typeof(Tables.RequisicaoInternaSituacao),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.RequisicaoInternaSituacao _data in
                    (System.Collections.Generic.List<Tables.RequisicaoInternaSituacao>)this.m_EntityManager.list
                    (
                        typeof(Tables.RequisicaoInternaSituacao),
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
                    _base = (Data.Base)this.preencher(new Data.RequisicaoInternaSituacao(), _data, level);

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
