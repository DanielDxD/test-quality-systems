using System;

namespace WS.CRUD
{
    public class NotaFiscalEEntradaMercadoria : WS.CRUD.Base
    {
        public NotaFiscalEEntradaMercadoria(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.NotaFiscalEEntradaMercadoria input = (Data.NotaFiscalEEntradaMercadoria)parametros["Key"];
            Tables.NotaFiscalEEntradaMercadoria bd = new Tables.NotaFiscalEEntradaMercadoria();

            bd.idNotaFiscal.value = input.idNotaFiscal;
            bd.idEntradaMercadoria.value = input.idEntradaMercadoria;

            this.m_EntityManager.persist(bd);

            return input;// this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.NotaFiscalEEntradaMercadoria input = (Data.NotaFiscalEEntradaMercadoria)parametros["Key"];
            Tables.NotaFiscalEEntradaMercadoria bd = (Tables.NotaFiscalEEntradaMercadoria)this.m_EntityManager.find
            (
                typeof(Tables.NotaFiscalEEntradaMercadoria),
                new Object[]
                {
                    input.idNotaFiscal,
                    input.idEntradaMercadoria
                }
            );

            bd.idNotaFiscal.value = input.idNotaFiscal;
            bd.idEntradaMercadoria.value = input.idEntradaMercadoria;

            this.m_EntityManager.merge(bd);

            return input;// this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.NotaFiscalEEntradaMercadoria bd = new Tables.NotaFiscalEEntradaMercadoria();

            bd.idNotaFiscal.value = ((Data.NotaFiscalEEntradaMercadoria)parametros["Key"]).idNotaFiscal;
            bd.idEntradaMercadoria.value = ((Data.NotaFiscalEEntradaMercadoria)parametros["Key"]).idEntradaMercadoria;

            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.NotaFiscalEEntradaMercadoria)bd).idNotaFiscal.isNull &&
                    !((Tables.NotaFiscalEEntradaMercadoria)bd).idEntradaMercadoria.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.NotaFiscalEEntradaMercadoria)input).operacao = ENum.eOperacao.NONE;

                    ((Data.NotaFiscalEEntradaMercadoria)input).idNotaFiscal = ((Tables.NotaFiscalEEntradaMercadoria)bd).idNotaFiscal.value;
                    ((Data.NotaFiscalEEntradaMercadoria)input).idEntradaMercadoria = ((Tables.NotaFiscalEEntradaMercadoria)bd).idEntradaMercadoria.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.NotaFiscalEEntradaMercadoria result = (Data.NotaFiscalEEntradaMercadoria)parametros["Key"];

            try
            {
                result = (Data.NotaFiscalEEntradaMercadoria)this.preencher
                (
                    new Data.NotaFiscalEEntradaMercadoria(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.NotaFiscalEEntradaMercadoria),
                        new Object[]
                        {
                            result.idNotaFiscal,
                            result.idEntradaMercadoria
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
            Data.NotaFiscalEEntradaMercadoria input = (Data.NotaFiscalEEntradaMercadoria)parametros["Key"];
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
                    typeof(Tables.NotaFiscalEEntradaMercadoria),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.NotaFiscalEEntradaMercadoria _data in
                    (System.Collections.Generic.List<Tables.NotaFiscalEEntradaMercadoria>)this.m_EntityManager.list
                    (
                        typeof(Tables.NotaFiscalEEntradaMercadoria),
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
                    _base = (Data.Base)this.preencher(new Data.NotaFiscalEEntradaMercadoria(), _data, level);

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
