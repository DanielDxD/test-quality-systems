using System;

namespace WS.CRUD
{
    public class NotaFiscalSItem : WS.CRUD.Base
    {
        public NotaFiscalSItem(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.NotaFiscalSItem input = (Data.NotaFiscalSItem)parametros["Key"];
            Tables.NotaFiscalSItem bd = new Tables.NotaFiscalSItem();

            bd.idNotaFiscalSItem.isNull = true;
            if (input.notaFiscal != null)
                bd.notaFiscal.idNotaFiscalS.value = input.notaFiscal.idNotaFiscalS;
            else { }
            if (input.contasAReceber != null)
                bd.contasAReceber.idContasAReceber.value = input.contasAReceber.idContasAReceber;
            else { }
            bd.valor.value = input.valor;
            bd.aliquotaIss.value = input.aliquotaIss;
            bd.valorIss.value = input.valorIss;

            this.m_EntityManager.persist(bd);

            ((Data.NotaFiscalSItem)parametros["Key"]).idNotaFiscalSItem = (int)bd.idNotaFiscalSItem.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.NotaFiscalSItem input = (Data.NotaFiscalSItem)parametros["Key"];
            Tables.NotaFiscalSItem bd = (Tables.NotaFiscalSItem)this.m_EntityManager.find
            (
                typeof(Tables.NotaFiscalSItem),
                new Object[]
                {
                    input.idNotaFiscalSItem
                }
            );

            if (input.notaFiscal != null)
                bd.notaFiscal.idNotaFiscalS.value = input.notaFiscal.idNotaFiscalS;
            else { }
            if (input.contasAReceber != null)
                bd.contasAReceber.idContasAReceber.value = input.contasAReceber.idContasAReceber;
            else { }
            bd.valor.value = input.valor;
            bd.aliquotaIss.value = input.aliquotaIss;
            bd.valorIss.value = input.valorIss;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.NotaFiscalSItem bd = new Tables.NotaFiscalSItem();

            bd.idNotaFiscalSItem.value = ((Data.NotaFiscalSItem)parametros["Key"]).idNotaFiscalSItem;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.NotaFiscalSItem)bd).idNotaFiscalSItem.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.NotaFiscalSItem)input).operacao = ENum.eOperacao.NONE;

                    ((Data.NotaFiscalSItem)input).idNotaFiscalSItem = ((Tables.NotaFiscalSItem)bd).idNotaFiscalSItem.value;
                    ((Data.NotaFiscalSItem)input).notaFiscal = (Data.NotaFiscalS)(new WS.CRUD.NotaFiscalS(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.NotaFiscalS(),
                        ((Tables.NotaFiscalSItem)bd).notaFiscal,
                        level + 1
                    );
                    ((Data.NotaFiscalSItem)input).contasAReceber = (Data.ContasAReceber)(new WS.CRUD.ContasAReceber(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContasAReceber(),
                        ((Tables.NotaFiscalSItem)bd).contasAReceber,
                        level + 1
                    );
                    ((Data.NotaFiscalSItem)input).valor = ((Tables.NotaFiscalSItem)bd).valor.value;
                    ((Data.NotaFiscalSItem)input).aliquotaIss = ((Tables.NotaFiscalSItem)bd).aliquotaIss.value;
                    ((Data.NotaFiscalSItem)input).valorIss = ((Tables.NotaFiscalSItem)bd).valorIss.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.NotaFiscalSItem result = (Data.NotaFiscalSItem)parametros["Key"];

            try
            {
                result = (Data.NotaFiscalSItem)this.preencher
                (
                    new Data.NotaFiscalSItem(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.NotaFiscalSItem),
                        new Object[]
                        {
                            result.idNotaFiscalSItem
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
            Data.NotaFiscalSItem input = (Data.NotaFiscalSItem)parametros["Key"];
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
                    typeof(Tables.NotaFiscalSItem),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.NotaFiscalSItem _data in
                    (System.Collections.Generic.List<Tables.NotaFiscalSItem>)this.m_EntityManager.list
                    (
                        typeof(Tables.NotaFiscalSItem),
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
                    _base = (Data.Base)this.preencher(new Data.NotaFiscalSItem(), _data, level);

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
