using System;

namespace WS.CRUD
{
    public class CaixaMovimentoAtendimento : WS.CRUD.Base
    {
        public CaixaMovimentoAtendimento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.CaixaMovimentoAtendimento input = (Data.CaixaMovimentoAtendimento)parametros["Key"];
            Tables.CaixaMovimentoAtendimento bd = new Tables.CaixaMovimentoAtendimento();

            bd.idCaixaMovimentoAtendimento.isNull = true;
            if (input.caixaMovimento != null)
                bd.caixaMovimento.idCaixaMovimento.value = input.caixaMovimento.idCaixaMovimento;
            else { }
            if (input.atendimento != null)
                bd.atendimento.idAtendimento.value = input.atendimento.idAtendimento;
            else { }
            if (input.cliente != null)
                bd.cliente.idEmpresaRelacionamento.value = input.cliente.idEmpresaRelacionamento;
            else { }
            bd.valor.value = input.valor;

            this.m_EntityManager.persist(bd);

            ((Data.CaixaMovimentoAtendimento)parametros["Key"]).idCaixaMovimentoAtendimento = (int)bd.idCaixaMovimentoAtendimento.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.CaixaMovimentoAtendimento input = (Data.CaixaMovimentoAtendimento)parametros["Key"];
            Tables.CaixaMovimentoAtendimento bd = (Tables.CaixaMovimentoAtendimento)this.m_EntityManager.find
            (
                typeof(Tables.CaixaMovimentoAtendimento),
                new Object[]
                {
                    input.idCaixaMovimentoAtendimento
                }
            );

            if (input.caixaMovimento != null)
                bd.caixaMovimento.idCaixaMovimento.value = input.caixaMovimento.idCaixaMovimento;
            else { }
            if (input.atendimento != null)
                bd.atendimento.idAtendimento.value = input.atendimento.idAtendimento;
            else { }
            if (input.cliente != null)
                bd.cliente.idEmpresaRelacionamento.value = input.cliente.idEmpresaRelacionamento;
            else { }
            bd.valor.value = input.valor;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.CaixaMovimentoAtendimento bd = new Tables.CaixaMovimentoAtendimento();

            bd.idCaixaMovimentoAtendimento.value = ((Data.CaixaMovimentoAtendimento)parametros["Key"]).idCaixaMovimentoAtendimento;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.CaixaMovimentoAtendimento)bd).idCaixaMovimentoAtendimento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.CaixaMovimentoAtendimento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.CaixaMovimentoAtendimento)input).idCaixaMovimentoAtendimento = ((Tables.CaixaMovimentoAtendimento)bd).idCaixaMovimentoAtendimento.value;
                    ((Data.CaixaMovimentoAtendimento)input).caixaMovimento = (Data.CaixaMovimento)(new WS.CRUD.CaixaMovimento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.CaixaMovimento(),
                        ((Tables.CaixaMovimentoAtendimento)bd).caixaMovimento,
                        level + 1
                    );
                    ((Data.CaixaMovimentoAtendimento)input).atendimento = (Data.Atendimento)(new WS.CRUD.Atendimento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Atendimento(),
                        ((Tables.CaixaMovimentoAtendimento)bd).atendimento,
                        level + 1
                    );
                    ((Data.CaixaMovimentoAtendimento)input).cliente = (Data.EmpresaRelacionamento)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.EmpresaRelacionamento(),
                        ((Tables.CaixaMovimentoAtendimento)bd).cliente,
                        level + 1
                    );
                    ((Data.CaixaMovimentoAtendimento)input).valor = ((Tables.CaixaMovimentoAtendimento)bd).valor.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.CaixaMovimentoAtendimento result = (Data.CaixaMovimentoAtendimento)parametros["Key"];

            try
            {
                result = (Data.CaixaMovimentoAtendimento)this.preencher
                (
                    new Data.CaixaMovimentoAtendimento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.CaixaMovimentoAtendimento),
                        new Object[]
                        {
                            result.idCaixaMovimentoAtendimento
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
            Data.CaixaMovimentoAtendimento input = (Data.CaixaMovimentoAtendimento)parametros["Key"];
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
                    typeof(Tables.CaixaMovimentoAtendimento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.CaixaMovimentoAtendimento _data in
                    (System.Collections.Generic.List<Tables.CaixaMovimentoAtendimento>)this.m_EntityManager.list
                    (
                        typeof(Tables.CaixaMovimentoAtendimento),
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
                    _base = (Data.Base)this.preencher(new Data.CaixaMovimentoAtendimento(), _data, level);

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
