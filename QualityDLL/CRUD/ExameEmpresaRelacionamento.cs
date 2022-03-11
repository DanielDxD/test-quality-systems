using System;

namespace WS.CRUD
{
    public class ExameEmpresaRelacionamento : WS.CRUD.Base
    {
        public ExameEmpresaRelacionamento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ExameEmpresaRelacionamento input = (Data.ExameEmpresaRelacionamento)parametros["Key"];
            Tables.ExameEmpresaRelacionamento bd = new Tables.ExameEmpresaRelacionamento();

            bd.idExameEmpresaRelacionamento.isNull = true;
            if (input.empresaRelacionamento != null)
                bd.empresaRelacionamento.idEmpresaRelacionamento.value = input.empresaRelacionamento.idEmpresaRelacionamento;
            else { }
            bd.dataValidade.value = input.dataValidade;
            bd.dataCadastramento.value = input.dataCadastramento;
            bd.usuarioCadastramento.value = input.usuarioCadastramento;

            this.m_EntityManager.persist(bd);

            ((Data.ExameEmpresaRelacionamento)parametros["Key"]).idExameEmpresaRelacionamento = (int)bd.idExameEmpresaRelacionamento.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ExameEmpresaRelacionamento input = (Data.ExameEmpresaRelacionamento)parametros["Key"];
            Tables.ExameEmpresaRelacionamento bd = (Tables.ExameEmpresaRelacionamento)this.m_EntityManager.find
            (
                typeof(Tables.ExameEmpresaRelacionamento),
                new Object[]
                {
                    input.idExameEmpresaRelacionamento
                }
            );

            if (input.empresaRelacionamento != null)
                bd.empresaRelacionamento.idEmpresaRelacionamento.value = input.empresaRelacionamento.idEmpresaRelacionamento;
            else { }
            bd.dataValidade.value = input.dataValidade;
            bd.dataCadastramento.value = input.dataCadastramento;
            bd.usuarioCadastramento.value = input.usuarioCadastramento;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ExameEmpresaRelacionamento bd = new Tables.ExameEmpresaRelacionamento();

            bd.idExameEmpresaRelacionamento.value = ((Data.ExameEmpresaRelacionamento)parametros["Key"]).idExameEmpresaRelacionamento;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ExameEmpresaRelacionamento)bd).idExameEmpresaRelacionamento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ExameEmpresaRelacionamento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ExameEmpresaRelacionamento)input).idExameEmpresaRelacionamento = ((Tables.ExameEmpresaRelacionamento)bd).idExameEmpresaRelacionamento.value;
                    ((Data.ExameEmpresaRelacionamento)input).empresaRelacionamento = (Data.EmpresaRelacionamento)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.EmpresaRelacionamento(),
                        ((Tables.ExameEmpresaRelacionamento)bd).empresaRelacionamento,
                        level + 1
                    );
                    ((Data.ExameEmpresaRelacionamento)input).dataValidade = ((Tables.ExameEmpresaRelacionamento)bd).dataValidade.value;
                    ((Data.ExameEmpresaRelacionamento)input).dataCadastramento = ((Tables.ExameEmpresaRelacionamento)bd).dataCadastramento.value;
                    ((Data.ExameEmpresaRelacionamento)input).usuarioCadastramento = ((Tables.ExameEmpresaRelacionamento)bd).usuarioCadastramento.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.ExameEmpresaRelacionamento result = (Data.ExameEmpresaRelacionamento)parametros["Key"];

            try
            {
                result = (Data.ExameEmpresaRelacionamento)this.preencher
                (
                    new Data.ExameEmpresaRelacionamento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ExameEmpresaRelacionamento),
                        new Object[]
                        {
                            result.idExameEmpresaRelacionamento
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
            Data.ExameEmpresaRelacionamento input = (Data.ExameEmpresaRelacionamento)parametros["Key"];
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
                    typeof(Tables.ExameEmpresaRelacionamento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ExameEmpresaRelacionamento _data in
                    (System.Collections.Generic.List<Tables.ExameEmpresaRelacionamento>)this.m_EntityManager.list
                    (
                        typeof(Tables.ExameEmpresaRelacionamento),
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
                    _base = (Data.Base)this.preencher(new Data.ExameEmpresaRelacionamento(), _data, level);

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
