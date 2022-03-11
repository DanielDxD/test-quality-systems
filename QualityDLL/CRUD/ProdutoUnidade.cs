using System;

namespace WS.CRUD
{
    public class ProdutoServicoUnidade : WS.CRUD.Base
    {
        public ProdutoServicoUnidade(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoUnidade input = (Data.ProdutoServicoUnidade)parametros["Key"];
            Tables.ProdutoServicoUnidade bd = new Tables.ProdutoServicoUnidade();

            bd.idProdutoServicoUnidade.isNull = true;
            bd.idProdutoServico.value = input.idProdutoServico;
            if (input.unidadeProdutoServico != null)
                bd.unidadeProdutoServico.idUnidadeProdutoServico.value = input.unidadeProdutoServico.idUnidadeProdutoServico;
            else { }
            bd.fator.value = input.fator;

            this.m_EntityManager.persist(bd);

            ((Data.ProdutoServicoUnidade)parametros["Key"]).idProdutoServicoUnidade = (int)bd.idProdutoServicoUnidade.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoUnidade input = (Data.ProdutoServicoUnidade)parametros["Key"];
            Tables.ProdutoServicoUnidade bd = (Tables.ProdutoServicoUnidade)this.m_EntityManager.find
            (
                typeof(Tables.ProdutoServicoUnidade),
                new Object[]
                {
                    input.idProdutoServicoUnidade
                }
            );

            bd.idProdutoServico.value = input.idProdutoServico;
            if (input.unidadeProdutoServico != null)
                bd.unidadeProdutoServico.idUnidadeProdutoServico.value = input.unidadeProdutoServico.idUnidadeProdutoServico;
            else { }
            bd.fator.value = input.fator;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ProdutoServicoUnidade bd = new Tables.ProdutoServicoUnidade();

            bd.idProdutoServicoUnidade.value = ((Data.ProdutoServicoUnidade)parametros["Key"]).idProdutoServicoUnidade;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ProdutoServicoUnidade)bd).idProdutoServicoUnidade.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ProdutoServicoUnidade)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ProdutoServicoUnidade)input).idProdutoServicoUnidade = ((Tables.ProdutoServicoUnidade)bd).idProdutoServicoUnidade.value;
                    ((Data.ProdutoServicoUnidade)input).idProdutoServico = ((Tables.ProdutoServicoUnidade)bd).idProdutoServico.value;
                    ((Data.ProdutoServicoUnidade)input).unidadeProdutoServico = (Data.UnidadeProdutoServico)(new WS.CRUD.UnidadeProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.UnidadeProdutoServico(),
                        ((Tables.ProdutoServicoUnidade)bd).unidadeProdutoServico,
                        level + 1
                    );
                    ((Data.ProdutoServicoUnidade)input).fator = ((Tables.ProdutoServicoUnidade)bd).fator.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.ProdutoServicoUnidade result = (Data.ProdutoServicoUnidade)parametros["Key"];

            try
            {
                result = (Data.ProdutoServicoUnidade)this.preencher
                (
                    new Data.ProdutoServicoUnidade(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ProdutoServicoUnidade),
                        new Object[]
                        {
                            result.idProdutoServicoUnidade
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
            Data.ProdutoServicoUnidade input = (Data.ProdutoServicoUnidade)parametros["Key"];
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
                    typeof(Tables.ProdutoServicoUnidade),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ProdutoServicoUnidade _data in
                    (System.Collections.Generic.List<Tables.ProdutoServicoUnidade>)this.m_EntityManager.list
                    (
                        typeof(Tables.ProdutoServicoUnidade),
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
                    _base = (Data.Base)this.preencher(new Data.ProdutoServicoUnidade(), _data, level);

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
