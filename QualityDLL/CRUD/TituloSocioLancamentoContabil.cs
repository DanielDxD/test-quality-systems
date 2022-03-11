using System;

namespace WS.CRUD
{
    public class TituloSocioLancamentoContabil : WS.CRUD.Base
    {
        public TituloSocioLancamentoContabil(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.TituloSocioLancamentoContabil input = (Data.TituloSocioLancamentoContabil)parametros["Key"];
            Tables.TituloSocioLancamentoContabil bd = new Tables.TituloSocioLancamentoContabil();

            bd.idTituloSocioLancamentoContabil.isNull = true;
            if (input.tituloSocio != null)
                bd.tituloSocio.idTituloSocio.value = input.tituloSocio.idTituloSocio;
            else { }
            if (input.planoContas != null)
                bd.planoContas.idPlanoContas.value = input.planoContas.idPlanoContas;
            else { }
            if (input.tipoLancamentoContabil != null)
                bd.tipoLancamentoContabil.idTipoLancamentoContabil.value = input.tipoLancamentoContabil.idTipoLancamentoContabil;
            else { }
            bd.fator.value = input.fator;

            this.m_EntityManager.persist(bd);

            ((Data.TituloSocioLancamentoContabil)parametros["Key"]).idTituloSocioLancamentoContabil = (int)bd.idTituloSocioLancamentoContabil.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.TituloSocioLancamentoContabil input = (Data.TituloSocioLancamentoContabil)parametros["Key"];
            Tables.TituloSocioLancamentoContabil bd = (Tables.TituloSocioLancamentoContabil)this.m_EntityManager.find
            (
                typeof(Tables.TituloSocioLancamentoContabil),
                new Object[]
                {
                    input.idTituloSocioLancamentoContabil
                }
            );

            if (input.tituloSocio != null)
                bd.tituloSocio.idTituloSocio.value = input.tituloSocio.idTituloSocio;
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
            Tables.TituloSocioLancamentoContabil bd = new Tables.TituloSocioLancamentoContabil();

            bd.idTituloSocioLancamentoContabil.value = ((Data.TituloSocioLancamentoContabil)parametros["Key"]).idTituloSocioLancamentoContabil;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.TituloSocioLancamentoContabil)bd).idTituloSocioLancamentoContabil.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.TituloSocioLancamentoContabil)input).operacao = ENum.eOperacao.NONE;

                    ((Data.TituloSocioLancamentoContabil)input).idTituloSocioLancamentoContabil = ((Tables.TituloSocioLancamentoContabil)bd).idTituloSocioLancamentoContabil.value;
                    ((Data.TituloSocioLancamentoContabil)input).tituloSocio = (Data.TituloSocio)(new WS.CRUD.TituloSocio(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TituloSocio(),
                        ((Tables.TituloSocioLancamentoContabil)bd).tituloSocio,
                        level + 1
                    );
                    ((Data.TituloSocioLancamentoContabil)input).planoContas = (Data.PlanoContas)(new WS.CRUD.PlanoContas(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PlanoContas(),
                        ((Tables.TituloSocioLancamentoContabil)bd).planoContas,
                        level + 1
                    );
                    ((Data.TituloSocioLancamentoContabil)input).tipoLancamentoContabil = (Data.TipoLancamentoContabil)(new WS.CRUD.TipoLancamentoContabil(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoLancamentoContabil(),
                        ((Tables.TituloSocioLancamentoContabil)bd).tipoLancamentoContabil,
                        level + 1
                    );
                    ((Data.TituloSocioLancamentoContabil)input).fator = ((Tables.TituloSocioLancamentoContabil)bd).fator.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.TituloSocioLancamentoContabil result = (Data.TituloSocioLancamentoContabil)parametros["Key"];

            try
            {
                result = (Data.TituloSocioLancamentoContabil)this.preencher
                (
                    new Data.TituloSocioLancamentoContabil(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.TituloSocioLancamentoContabil),
                        new Object[]
                        {
                            result.idTituloSocioLancamentoContabil
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
            Data.TituloSocioLancamentoContabil input = (Data.TituloSocioLancamentoContabil)parametros["Key"];
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
                    typeof(Tables.TituloSocioLancamentoContabil),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.TituloSocioLancamentoContabil _data in
                    (System.Collections.Generic.List<Tables.TituloSocioLancamentoContabil>)this.m_EntityManager.list
                    (
                        typeof(Tables.TituloSocioLancamentoContabil),
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
                    _base = (Data.Base)this.preencher(new Data.TituloSocioLancamentoContabil(), _data, level);

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
