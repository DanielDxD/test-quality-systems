using System;

namespace WS.CRUD
{
    public class RequisicaoCompraSituacao : WS.CRUD.Base
    {
        public RequisicaoCompraSituacao(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoCompraSituacao input = (Data.RequisicaoCompraSituacao)parametros["Key"];
            Tables.RequisicaoCompraSituacao bd = new Tables.RequisicaoCompraSituacao();

            bd.idRequisicaoCompraSituacao.isNull = true;
            bd.idRequisicaoCompra.value = input.idRequisicaoCompra;
            bd.situacao.value = input.situacao;
            bd.dataSituacao.value = input.dataSituacao;
            bd.idFuncionario.value = input.idFuncionario;

            this.m_EntityManager.persist(bd);

            ((Data.RequisicaoCompraSituacao)parametros["Key"]).idRequisicaoCompraSituacao = (int)bd.idRequisicaoCompraSituacao.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoCompraSituacao input = (Data.RequisicaoCompraSituacao)parametros["Key"];
            Tables.RequisicaoCompraSituacao bd = (Tables.RequisicaoCompraSituacao)this.m_EntityManager.find
            (
                typeof(Tables.RequisicaoCompraSituacao),
                new Object[]
                {
                    input.idRequisicaoCompraSituacao
                }
            );

            bd.idRequisicaoCompra.value = input.idRequisicaoCompra;
            bd.situacao.value = input.situacao;
            bd.dataSituacao.value = input.dataSituacao;
            bd.idFuncionario.value = input.idFuncionario;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.RequisicaoCompraSituacao bd = new Tables.RequisicaoCompraSituacao();

            bd.idRequisicaoCompraSituacao.value = ((Data.RequisicaoCompraSituacao)parametros["Key"]).idRequisicaoCompraSituacao;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.RequisicaoCompraSituacao)bd).idRequisicaoCompraSituacao.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.RequisicaoCompraSituacao)input).operacao = ENum.eOperacao.NONE;

                    ((Data.RequisicaoCompraSituacao)input).idRequisicaoCompraSituacao = ((Tables.RequisicaoCompraSituacao)bd).idRequisicaoCompraSituacao.value;
                    ((Data.RequisicaoCompraSituacao)input).idRequisicaoCompra = ((Tables.RequisicaoCompraSituacao)bd).idRequisicaoCompra.value;
                    ((Data.RequisicaoCompraSituacao)input).situacao = ((Tables.RequisicaoCompraSituacao)bd).situacao.value;
                    ((Data.RequisicaoCompraSituacao)input).dataSituacao = ((Tables.RequisicaoCompraSituacao)bd).dataSituacao.value;
                    ((Data.RequisicaoCompraSituacao)input).idFuncionario = ((Tables.RequisicaoCompraSituacao)bd).idFuncionario.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.RequisicaoCompraSituacao result = (Data.RequisicaoCompraSituacao)parametros["Key"];

            try
            {
                result = (Data.RequisicaoCompraSituacao)this.preencher
                (
                    new Data.RequisicaoCompraSituacao(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.RequisicaoCompraSituacao),
                        new Object[]
                        {
                            result.idRequisicaoCompraSituacao
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
            Data.RequisicaoCompraSituacao input = (Data.RequisicaoCompraSituacao)parametros["Key"];
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
                    typeof(Tables.RequisicaoCompraSituacao),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.RequisicaoCompraSituacao _data in
                    (System.Collections.Generic.List<Tables.RequisicaoCompraSituacao>)this.m_EntityManager.list
                    (
                        typeof(Tables.RequisicaoCompraSituacao),
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
                    _base = (Data.Base)this.preencher(new Data.RequisicaoCompraSituacao(), _data, level);

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
