using System;

namespace WS.CRUD
{
    public class TipoMovimentoContabil : WS.CRUD.Base
    {
        public TipoMovimentoContabil(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.TipoMovimentoContabil input = (Data.TipoMovimentoContabil)parametros["Key"];
            Tables.TipoMovimentoContabil bd = new Tables.TipoMovimentoContabil();

            bd.idTipoMovimentoContabil.isNull = true;
            bd.idEmpresa.value = input.idEmpresa;
            bd.descricao.value = input.descricao;
            bd.contabilizacaoPorCompetencia.value = input.contabilizacaoPorCompetencia;
            if ((input.planoContasResultado != null) && (input.planoContasResultado.idPlanoContas > 0))
                bd.planoContasResultado.idPlanoContas.value = input.planoContasResultado.idPlanoContas;
            else { }
            if ((input.planoContasProvisao != null) && (input.planoContasProvisao.idPlanoContas > 0))
                bd.planoContasProvisao.idPlanoContas.value = input.planoContasProvisao.idPlanoContas;
            else { }
            if ((input.planoContasAdiantamento != null) && (input.planoContasAdiantamento.idPlanoContas > 0))
                bd.planoContasAdiantamento.idPlanoContas.value = input.planoContasAdiantamento.idPlanoContas;
            else { }
            if ((input.tipoMovimentoContabilPai != null) && (input.tipoMovimentoContabilPai.idTipoMovimentoContabil > 0))
                bd.tipoMovimentoContabilPai.idTipoMovimentoContabil.value = input.tipoMovimentoContabilPai.idTipoMovimentoContabil;
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.TipoMovimentoContabil)parametros["Key"]).idTipoMovimentoContabil = (int)bd.idTipoMovimentoContabil.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.TipoMovimentoContabil input = (Data.TipoMovimentoContabil)parametros["Key"];
            Tables.TipoMovimentoContabil bd = (Tables.TipoMovimentoContabil)this.m_EntityManager.find
            (
                typeof(Tables.TipoMovimentoContabil),
                new Object[]
                {
                    input.idTipoMovimentoContabil
                }
            );

            bd.idEmpresa.value = input.idEmpresa;
            bd.descricao.value = input.descricao;
            bd.contabilizacaoPorCompetencia.value = input.contabilizacaoPorCompetencia;
            if ((input.planoContasResultado != null) && (input.planoContasResultado.idPlanoContas > 0))
                bd.planoContasResultado.idPlanoContas.value = input.planoContasResultado.idPlanoContas;
            else { }
            if ((input.planoContasProvisao != null) && (input.planoContasProvisao.idPlanoContas > 0))
                bd.planoContasProvisao.idPlanoContas.value = input.planoContasProvisao.idPlanoContas;
            else { }
            if ((input.planoContasAdiantamento != null) && (input.planoContasAdiantamento.idPlanoContas > 0))
                bd.planoContasAdiantamento.idPlanoContas.value = input.planoContasAdiantamento.idPlanoContas;
            else { }
            if ((input.tipoMovimentoContabilPai != null) && (input.tipoMovimentoContabilPai.idTipoMovimentoContabil > 0))
                bd.tipoMovimentoContabilPai.idTipoMovimentoContabil.value = input.tipoMovimentoContabilPai.idTipoMovimentoContabil;
            else { }

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.TipoMovimentoContabil bd = new Tables.TipoMovimentoContabil();

            bd.idTipoMovimentoContabil.value = ((Data.TipoMovimentoContabil)parametros["Key"]).idTipoMovimentoContabil;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.TipoMovimentoContabil)bd).idTipoMovimentoContabil.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.TipoMovimentoContabil)input).operacao = ENum.eOperacao.NONE;

                    ((Data.TipoMovimentoContabil)input).idTipoMovimentoContabil = ((Tables.TipoMovimentoContabil)bd).idTipoMovimentoContabil.value;
                    ((Data.TipoMovimentoContabil)input).idEmpresa = ((Tables.TipoMovimentoContabil)bd).idEmpresa.value;
                    ((Data.TipoMovimentoContabil)input).descricao = ((Tables.TipoMovimentoContabil)bd).descricao.value;
                    ((Data.TipoMovimentoContabil)input).contabilizacaoPorCompetencia = ((Tables.TipoMovimentoContabil)bd).contabilizacaoPorCompetencia.value;
                    ((Data.TipoMovimentoContabil)input).planoContasResultado = (Data.PlanoContas)(new WS.CRUD.PlanoContas(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PlanoContas(),
                        ((Tables.TipoMovimentoContabil)bd).planoContasResultado,
                        level + 1
                    );
                    ((Data.TipoMovimentoContabil)input).planoContasProvisao = (Data.PlanoContas)(new WS.CRUD.PlanoContas(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PlanoContas(),
                        ((Tables.TipoMovimentoContabil)bd).planoContasProvisao,
                        level + 1
                    );
                    ((Data.TipoMovimentoContabil)input).planoContasAdiantamento = (Data.PlanoContas)(new WS.CRUD.PlanoContas(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PlanoContas(),
                        ((Tables.TipoMovimentoContabil)bd).planoContasAdiantamento,
                        level + 1
                    );
                    ((Data.TipoMovimentoContabil)input).tipoMovimentoContabilPai = (Data.TipoMovimentoContabil)(new WS.CRUD.TipoMovimentoContabil(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoMovimentoContabil(),
                        ((Tables.TipoMovimentoContabil)bd).tipoMovimentoContabilPai,
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
            Data.TipoMovimentoContabil result = (Data.TipoMovimentoContabil)parametros["Key"];

            try
            {
                result = (Data.TipoMovimentoContabil)this.preencher
                (
                    new Data.TipoMovimentoContabil(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.TipoMovimentoContabil),
                        new Object[]
                        {
                            result.idTipoMovimentoContabil
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
            Data.TipoMovimentoContabil input = (Data.TipoMovimentoContabil)parametros["Key"];
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
                    typeof(Tables.TipoMovimentoContabil),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.TipoMovimentoContabil _data in
                    (System.Collections.Generic.List<Tables.TipoMovimentoContabil>)this.m_EntityManager.list
                    (
                        typeof(Tables.TipoMovimentoContabil),
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
                    _base = (Data.Base)this.preencher(new Data.TipoMovimentoContabil(), _data, level);

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
