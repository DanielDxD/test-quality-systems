using System;

namespace WS.CRUD
{
    public class Movimento : WS.CRUD.Base
    {
        public Movimento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Movimento input = (Data.Movimento)parametros["Key"];
            Tables.Movimento bd = new Tables.Movimento();

            bd.idMovimento.isNull = true;
            bd.idEmpresa.value = input.idEmpresa;
            if (input.empresaRelacionamento != null)
                bd.empresaRelacionamento.idEmpresaRelacionamento.value = input.empresaRelacionamento.idEmpresaRelacionamento;
            else { }
            if (input.tipoMovimento != null)
                bd.tipoMovimento.idTipoMovimento.value = input.tipoMovimento.idTipoMovimento;
            else { }
            bd.dataMovimento.value = input.dataMovimento;
            bd.valor.value = input.valor;

            this.m_EntityManager.persist(bd);

            ((Data.Movimento)parametros["Key"]).idMovimento = (int)bd.idMovimento.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Movimento input = (Data.Movimento)parametros["Key"];
            Tables.Movimento bd = (Tables.Movimento)this.m_EntityManager.find
            (
                typeof(Tables.Movimento),
                new Object[]
                {
                    input.idMovimento
                }
            );

            bd.idEmpresa.value = input.idEmpresa;

            if (input.empresaRelacionamento != null)
                bd.empresaRelacionamento.idEmpresaRelacionamento.value = input.empresaRelacionamento.idEmpresaRelacionamento;
            else { }
            if (input.tipoMovimento != null)
                bd.tipoMovimento.idTipoMovimento.value = input.tipoMovimento.idTipoMovimento;
            else { }
            bd.dataMovimento.value = input.dataMovimento;
            bd.valor.value = input.valor;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Movimento bd = new Tables.Movimento();

            bd.idMovimento.value = ((Data.Movimento)parametros["Key"]).idMovimento;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Movimento)bd).idMovimento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Movimento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Movimento)input).idMovimento = ((Tables.Movimento)bd).idMovimento.value;
                    ((Data.Movimento)input).empresaRelacionamento = (Data.EmpresaRelacionamento)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.EmpresaRelacionamento(),
                        ((Tables.Movimento)bd).empresaRelacionamento,
                        level + 1
                    );
                    ((Data.Movimento)input).tipoMovimento = (Data.TipoMovimento)(new WS.CRUD.TipoMovimento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoMovimento(),
                        ((Tables.Movimento)bd).tipoMovimento,
                        level + 1
                    );
                    ((Data.Movimento)input).dataMovimento = ((Tables.Movimento)bd).dataMovimento.value;
                    ((Data.Movimento)input).valor = ((Tables.Movimento)bd).valor.value;
                    ((Data.Movimento)input).idEmpresa = ((Tables.Movimento)bd).idEmpresa.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.Movimento result = (Data.Movimento)parametros["Key"];

            try
            {
                result = (Data.Movimento)this.preencher
                (
                    new Data.Movimento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Movimento),
                        new Object[]
                        {
                            result.idMovimento
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
            Data.Movimento input = (Data.Movimento)parametros["Key"];
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
                    typeof(Tables.Movimento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Movimento _data in
                    (System.Collections.Generic.List<Tables.Movimento>)this.m_EntityManager.list
                    (
                        typeof(Tables.Movimento),
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
                    _base = (Data.Base)this.preencher(new Data.Movimento(), _data, level);

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
