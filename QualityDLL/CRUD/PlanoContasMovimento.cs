using System;

namespace WS.CRUD
{
    public class PlanoContasMovimento : WS.CRUD.Base
    {
        public PlanoContasMovimento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PlanoContasMovimento input = (Data.PlanoContasMovimento)parametros["Key"];
            Tables.PlanoContasMovimento bd = new Tables.PlanoContasMovimento();

            bd.idPlanoContasMovimento.isNull = true;
            bd.dataMovimento.value = input.dataMovimento;
            if (input.planoContasDebito != null)
                bd.planoContasDebito.idPlanoContas.value = input.planoContasDebito.idPlanoContas;
            else { }
            if (input.planoContasCredito != null)
                bd.planoContasCredito.idPlanoContas.value = input.planoContasCredito.idPlanoContas;
            else { }
            bd.valor.value = input.valor;
            bd.historico.value = input.historico;

            this.m_EntityManager.persist(bd);

            ((Data.PlanoContasMovimento)parametros["Key"]).idPlanoContasMovimento = (int)bd.idPlanoContasMovimento.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PlanoContasMovimento input = (Data.PlanoContasMovimento)parametros["Key"];
            Tables.PlanoContasMovimento bd = (Tables.PlanoContasMovimento)this.m_EntityManager.find
            (
                typeof(Tables.PlanoContasMovimento),
                new Object[]
                {
                    input.idPlanoContasMovimento
                }
            );

            bd.dataMovimento.value = input.dataMovimento;
            if (input.planoContasDebito != null)
                bd.planoContasDebito.idPlanoContas.value = input.planoContasDebito.idPlanoContas;
            else { }
            if (input.planoContasCredito != null)
                bd.planoContasCredito.idPlanoContas.value = input.planoContasCredito.idPlanoContas;
            else { }
            bd.valor.value = input.valor;
            bd.historico.value = input.historico;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PlanoContasMovimento bd = new Tables.PlanoContasMovimento();

            bd.idPlanoContasMovimento.value = ((Data.PlanoContasMovimento)parametros["Key"]).idPlanoContasMovimento;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PlanoContasMovimento)bd).idPlanoContasMovimento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PlanoContasMovimento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PlanoContasMovimento)input).idPlanoContasMovimento = ((Tables.PlanoContasMovimento)bd).idPlanoContasMovimento.value;
                    ((Data.PlanoContasMovimento)input).dataMovimento = ((Tables.PlanoContasMovimento)bd).dataMovimento.value;
                    ((Data.PlanoContasMovimento)input).planoContasDebito = (Data.PlanoContas)(new WS.CRUD.PlanoContas(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PlanoContas(),
                        ((Tables.PlanoContasMovimento)bd).planoContasDebito,
                        level + 1
                    );
                    ((Data.PlanoContasMovimento)input).planoContasCredito = (Data.PlanoContas)(new WS.CRUD.PlanoContas(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PlanoContas(),
                        ((Tables.PlanoContasMovimento)bd).planoContasCredito,
                        level + 1
                    );
                    ((Data.PlanoContasMovimento)input).valor = ((Tables.PlanoContasMovimento)bd).valor.value;
                    ((Data.PlanoContasMovimento)input).historico = ((Tables.PlanoContasMovimento)bd).historico.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PlanoContasMovimento result = (Data.PlanoContasMovimento)parametros["Key"];

            try
            {
                result = (Data.PlanoContasMovimento)this.preencher
                (
                    new Data.PlanoContasMovimento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.PlanoContasMovimento),
                        new Object[]
                        {
                            result.idPlanoContasMovimento
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
            Data.PlanoContasMovimento input = (Data.PlanoContasMovimento)parametros["Key"];
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
                    typeof(Tables.PlanoContasMovimento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.PlanoContasMovimento _data in
                    (System.Collections.Generic.List<Tables.PlanoContasMovimento>)this.m_EntityManager.list
                    (
                        typeof(Tables.PlanoContasMovimento),
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
                    _base = (Data.Base)this.preencher(new Data.PlanoContasMovimento(), _data, level);

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
