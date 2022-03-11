using System;

namespace WS.CRUD
{
    public class Servico : WS.CRUD.Base
    {
        public Servico(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Servico input = (Data.Servico)parametros["Key"];
            Tables.Servico bd = new Tables.Servico();

            bd.idServico.isNull = true;
            bd.descricao.value = input.descricao;
            bd.tipoMovimento.idTipoMovimento.value = input.tipoMovimento.idTipoMovimento;
            bd.aliquotaIss.value = input.aliquotaIss;

            this.m_EntityManager.persist(bd);

            ((Data.Servico)parametros["Key"]).idServico = (int)bd.idServico.value;

            return this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Servico input = (Data.Servico)parametros["Key"];
            Tables.Servico bd = (Tables.Servico)this.m_EntityManager.find
            (
                typeof(Tables.Servico),
                new Object[]
                {
                    input.idServico
                }
            );

            bd.descricao.value = input.descricao;
            bd.tipoMovimento.idTipoMovimento.value = input.tipoMovimento.idTipoMovimento;
            bd.aliquotaIss.value = input.aliquotaIss;

            this.m_EntityManager.merge(bd);

            return this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Servico bd = new Tables.Servico();

            bd.idServico.value = ((Data.Servico)parametros["Key"]).idServico;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Servico)bd).idServico.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Servico)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Servico)input).idServico = ((Tables.Servico)bd).idServico.value;
                    ((Data.Servico)input).descricao = ((Tables.Servico)bd).descricao.value;
                    ((Data.Servico)input).tipoMovimento = (Data.TipoMovimento)(new WS.CRUD.TipoMovimento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoMovimento(),
                        ((Tables.Servico)bd).tipoMovimento,
                        level + 1
                    );
                    ((Data.Servico)input).aliquotaIss = ((Tables.Servico)bd).aliquotaIss.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.Servico result = (Data.Servico)parametros["Key"];

            try
            {
                result = (Data.Servico)this.preencher
                (
                    new Data.Servico(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Servico),
                        new Object[]
                        {
                            result.idServico
                        }
                    ),
                    0
                );
            }
            catch (Exception e)
            {
                System.Console.Out.Write(this.GetType().ToString() + ".consultar() -> " + e.ToString());
                throw new Exception(e.Message);
            }

            return result;
        }

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.Servico input = (Data.Servico)parametros["Key"];
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
                    typeof(Tables.Servico),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Servico _data in
                    (System.Collections.Generic.List<Tables.Servico>)this.m_EntityManager.list
                    (
                        typeof(Tables.Servico),
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
                    _base = (Data.Base)this.preencher(new Data.Servico(), _data, level);

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
                System.Console.Out.Write(this.GetType().ToString() + ".listar() -> " + e.ToString());
                throw new Exception(e.Message);
            }

            return ((result.Count > 0) ? result.ToArray() : null);
        }
    }
}
