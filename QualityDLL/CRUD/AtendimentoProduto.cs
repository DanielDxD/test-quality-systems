using System;

namespace WS.CRUD
{
    public class AtendimentoProdutoServico : WS.CRUD.Base
    {
        public AtendimentoProdutoServico(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.AtendimentoProdutoServico input = (Data.AtendimentoProdutoServico)parametros["Key"];
            Tables.AtendimentoProdutoServico bd = new Tables.AtendimentoProdutoServico();

            bd.idAtendimentoProdutoServico.isNull = true;
            if (input.atendimento != null)
                bd.atendimento.idAtendimento.value = input.atendimento.idAtendimento;
            else { }
            if (input.produtoServico != null)
                bd.produtoServico.idProdutoServico.value = input.produtoServico.idProdutoServico;
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.AtendimentoProdutoServico)parametros["Key"]).idAtendimentoProdutoServico = (int)bd.idAtendimentoProdutoServico.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.AtendimentoProdutoServico input = (Data.AtendimentoProdutoServico)parametros["Key"];
            Tables.AtendimentoProdutoServico bd = (Tables.AtendimentoProdutoServico)this.m_EntityManager.find
            (
                typeof(Tables.AtendimentoProdutoServico),
                new Object[]
                {
                    input.idAtendimentoProdutoServico
                }
            );

            if (input.atendimento != null)
                bd.atendimento.idAtendimento.value = input.atendimento.idAtendimento;
            else { }
            if (input.produtoServico != null)
                bd.produtoServico.idProdutoServico.value = input.produtoServico.idProdutoServico;
            else { }

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.AtendimentoProdutoServico bd = new Tables.AtendimentoProdutoServico();

            bd.idAtendimentoProdutoServico.value = ((Data.AtendimentoProdutoServico)parametros["Key"]).idAtendimentoProdutoServico;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.AtendimentoProdutoServico)bd).idAtendimentoProdutoServico.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.AtendimentoProdutoServico)input).operacao = ENum.eOperacao.NONE;

                    ((Data.AtendimentoProdutoServico)input).idAtendimentoProdutoServico = ((Tables.AtendimentoProdutoServico)bd).idAtendimentoProdutoServico.value;
                    ((Data.AtendimentoProdutoServico)input).atendimento = (Data.Atendimento)(new WS.CRUD.Atendimento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Atendimento(),
                        ((Tables.AtendimentoProdutoServico)bd).atendimento,
                        level + 1
                    );
                    ((Data.AtendimentoProdutoServico)input).produtoServico = (Data.ProdutoServico)(new WS.CRUD.ProdutoServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ProdutoServico(),
                        ((Tables.AtendimentoProdutoServico)bd).produtoServico,
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
            Data.AtendimentoProdutoServico result = (Data.AtendimentoProdutoServico)parametros["Key"];

            try
            {
                result = (Data.AtendimentoProdutoServico)this.preencher
                (
                    new Data.AtendimentoProdutoServico(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.AtendimentoProdutoServico),
                        new Object[]
                        {
                            result.idAtendimentoProdutoServico
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
            Data.AtendimentoProdutoServico input = (Data.AtendimentoProdutoServico)parametros["Key"];
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
                    typeof(Tables.AtendimentoProdutoServico),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.AtendimentoProdutoServico _data in
                    (System.Collections.Generic.List<Tables.AtendimentoProdutoServico>)this.m_EntityManager.list
                    (
                        typeof(Tables.AtendimentoProdutoServico),
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
                    _base = (Data.Base)this.preencher(new Data.AtendimentoProdutoServico(), _data, level);

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
