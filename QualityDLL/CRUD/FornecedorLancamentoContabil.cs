using System;

namespace WS.CRUD
{
    public class FornecedorLancamentoContabil : WS.CRUD.Base
    {
        public FornecedorLancamentoContabil(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.FornecedorLancamentoContabil input = (Data.FornecedorLancamentoContabil)parametros["Key"];
            Tables.FornecedorLancamentoContabil bd = new Tables.FornecedorLancamentoContabil();

            bd.idFornecedorLancamentoContabil.isNull = true;
            if (input.fornecedor != null)
                if (input.fornecedor.idEmpresaRelacionamento > 0)
                    bd.fornecedor.fornecedorEmpresaRelacionamento.idEmpresaRelacionamento.value = input.fornecedor.idEmpresaRelacionamento;
                else { }
            else { }
            if (input.planoContas != null)
                bd.planoContas.idPlanoContas.value = input.planoContas.idPlanoContas;
            else { }
            if (input.tipoLancamentoContabil != null)
                bd.tipoLancamentoContabil.idTipoLancamentoContabil.value = input.tipoLancamentoContabil.idTipoLancamentoContabil;
            else { }
            bd.fator.value = input.fator;

            this.m_EntityManager.persist(bd);

            ((Data.FornecedorLancamentoContabil)parametros["Key"]).idFornecedorLancamentoContabil = (int)bd.idFornecedorLancamentoContabil.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.FornecedorLancamentoContabil input = (Data.FornecedorLancamentoContabil)parametros["Key"];
            Tables.FornecedorLancamentoContabil bd = (Tables.FornecedorLancamentoContabil)this.m_EntityManager.find
            (
                typeof(Tables.FornecedorLancamentoContabil),
                new Object[]
                {
                    input.idFornecedorLancamentoContabil
                }
            );

            if (input.fornecedor != null)
                if (input.fornecedor.idEmpresaRelacionamento > 0)
                    bd.fornecedor.fornecedorEmpresaRelacionamento.idEmpresaRelacionamento.value = input.fornecedor.idEmpresaRelacionamento;
                else { }
            else { }
            if (input.planoContas != null)
                bd.planoContas.idPlanoContas.value = input.planoContas.idPlanoContas;
            else { }
            if (input.tipoLancamentoContabil != null)
                bd.tipoLancamentoContabil.idTipoLancamentoContabil.value = input.tipoLancamentoContabil.idTipoLancamentoContabil;
            else { }
            bd.fator.value = input.fator;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.FornecedorLancamentoContabil bd = new Tables.FornecedorLancamentoContabil();

            bd.idFornecedorLancamentoContabil.value = ((Data.FornecedorLancamentoContabil)parametros["Key"]).idFornecedorLancamentoContabil;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.FornecedorLancamentoContabil)bd).idFornecedorLancamentoContabil.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.FornecedorLancamentoContabil)input).operacao = ENum.eOperacao.NONE;

                    ((Data.FornecedorLancamentoContabil)input).idFornecedorLancamentoContabil = ((Tables.FornecedorLancamentoContabil)bd).idFornecedorLancamentoContabil.value;
                    ((Data.FornecedorLancamentoContabil)input).fornecedor = (Data.Fornecedor)(new WS.CRUD.Fornecedor(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Fornecedor(),
                        ((Tables.FornecedorLancamentoContabil)bd).fornecedor,
                        level + 1
                    );
                    ((Data.FornecedorLancamentoContabil)input).planoContas = (Data.PlanoContas)(new WS.CRUD.PlanoContas(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PlanoContas(),
                        ((Tables.FornecedorLancamentoContabil)bd).planoContas,
                        level + 1
                    );
                    ((Data.FornecedorLancamentoContabil)input).tipoLancamentoContabil = (Data.TipoLancamentoContabil)(new WS.CRUD.TipoLancamentoContabil(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoLancamentoContabil(),
                        ((Tables.FornecedorLancamentoContabil)bd).tipoLancamentoContabil,
                        level + 1
                    );
                    ((Data.FornecedorLancamentoContabil)input).fator = ((Tables.FornecedorLancamentoContabil)bd).fator.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.FornecedorLancamentoContabil result = (Data.FornecedorLancamentoContabil)parametros["Key"];

            try
            {
                result = (Data.FornecedorLancamentoContabil)this.preencher
                (
                    new Data.FornecedorLancamentoContabil(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.FornecedorLancamentoContabil),
                        new Object[]
                        {
                            result.idFornecedorLancamentoContabil
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
            Data.FornecedorLancamentoContabil input = (Data.FornecedorLancamentoContabil)parametros["Key"];
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
                    typeof(Tables.FornecedorLancamentoContabil),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.FornecedorLancamentoContabil _data in
                    (System.Collections.Generic.List<Tables.FornecedorLancamentoContabil>)this.m_EntityManager.list
                    (
                        typeof(Tables.FornecedorLancamentoContabil),
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
                    _base = (Data.Base)this.preencher(new Data.FornecedorLancamentoContabil(), _data, level);

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
