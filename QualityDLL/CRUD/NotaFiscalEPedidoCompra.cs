using System;

namespace WS.CRUD
{
    public class NotaFiscalEPedidoCompra : WS.CRUD.Base
    {
        public NotaFiscalEPedidoCompra(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.NotaFiscalEPedidoCompra input = (Data.NotaFiscalEPedidoCompra)parametros["Key"];
            Tables.NotaFiscalEPedidoCompra bd = new Tables.NotaFiscalEPedidoCompra();

            bd.idNotaFiscal.value = input.idNotaFiscal;
            bd.idPedidoCompra.value = input.idPedidoCompra;

            this.m_EntityManager.persist(bd);

            return input;// this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.NotaFiscalEPedidoCompra input = (Data.NotaFiscalEPedidoCompra)parametros["Key"];
            Tables.NotaFiscalEPedidoCompra bd = (Tables.NotaFiscalEPedidoCompra)this.m_EntityManager.find
            (
                typeof(Tables.NotaFiscalEPedidoCompra),
                new Object[]
                {
                    input.idNotaFiscal,
                    input.idPedidoCompra
                }
            );

            bd.idNotaFiscal.value = input.idNotaFiscal;
            bd.idPedidoCompra.value = input.idPedidoCompra;

            this.m_EntityManager.merge(bd);

            return input;// this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.NotaFiscalEPedidoCompra bd = new Tables.NotaFiscalEPedidoCompra();

            bd.idNotaFiscal.value = ((Data.NotaFiscalEPedidoCompra)parametros["Key"]).idNotaFiscal;
            bd.idPedidoCompra.value = ((Data.NotaFiscalEPedidoCompra)parametros["Key"]).idPedidoCompra;

            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.NotaFiscalEPedidoCompra)bd).idNotaFiscal.isNull &&
                    !((Tables.NotaFiscalEPedidoCompra)bd).idPedidoCompra.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.NotaFiscalEPedidoCompra)input).operacao = ENum.eOperacao.NONE;

                    ((Data.NotaFiscalEPedidoCompra)input).idNotaFiscal = ((Tables.NotaFiscalEPedidoCompra)bd).idNotaFiscal.value;
                    ((Data.NotaFiscalEPedidoCompra)input).idPedidoCompra = ((Tables.NotaFiscalEPedidoCompra)bd).idPedidoCompra.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.NotaFiscalEPedidoCompra result = (Data.NotaFiscalEPedidoCompra)parametros["Key"];

            try
            {
                result = (Data.NotaFiscalEPedidoCompra)this.preencher
                (
                    new Data.NotaFiscalEPedidoCompra(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.NotaFiscalEPedidoCompra),
                        new Object[]
                        {
                            result.idNotaFiscal,
                            result.idPedidoCompra
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
            Data.NotaFiscalEPedidoCompra input = (Data.NotaFiscalEPedidoCompra)parametros["Key"];
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
                    typeof(Tables.NotaFiscalEPedidoCompra),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.NotaFiscalEPedidoCompra _data in
                    (System.Collections.Generic.List<Tables.NotaFiscalEPedidoCompra>)this.m_EntityManager.list
                    (
                        typeof(Tables.NotaFiscalEPedidoCompra),
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
                    _base = (Data.Base)this.preencher(new Data.NotaFiscalEPedidoCompra(), _data, level);

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
