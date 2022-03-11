using System;
using System.Linq;

namespace WS.CRUD
{
    public class ContratoTipoItemValor : WS.CRUD.Base
    {
        public ContratoTipoItemValor(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ContratoTipoItemValor input = (Data.ContratoTipoItemValor)parametros["Key"];
            Tables.ContratoTipoItemValor bd = new Tables.ContratoTipoItemValor();

            bd.idContratoTipoItemValor.isNull = true;

            bd.contratoTipoItem.idContratoTipoItem.value = input.contratoTipoItem.idContratoTipoItem;
            bd.valor.value = input.valor;

            if (input.periodoFinal.Ticks > 0)
                bd.periodoFinal.value = input.periodoFinal;
            if (input.periodoInicial.Ticks > 0)
                bd.periodoInicial.value = input.periodoInicial;

            this.m_EntityManager.persist(bd);

            ((Data.ContratoTipoItemValor)parametros["Key"]).idContratoTipoItemValor = (int)bd.idContratoTipoItemValor.value;
            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ContratoTipoItemValor input = (Data.ContratoTipoItemValor)parametros["Key"];
            Tables.ContratoTipoItemValor bd = (Tables.ContratoTipoItemValor)this.m_EntityManager.find
            (
                typeof(Tables.ContratoTipoItemValor),
                new Object[]
                {
                    input.idContratoTipoItemValor
                }
            );

            bd.contratoTipoItem.idContratoTipoItem.value = input.contratoTipoItem.idContratoTipoItem;
            bd.valor.value = input.valor;

            if (input.periodoFinal.Ticks > 0)
                bd.periodoFinal.value = input.periodoFinal;
            if (input.periodoInicial.Ticks > 0)
                bd.periodoInicial.value = input.periodoInicial;

            this.m_EntityManager.merge(bd);
            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ContratoTipoItemValor bd = new Tables.ContratoTipoItemValor();

            bd.idContratoTipoItemValor.value = ((Data.ContratoTipoItemValor)parametros["Key"]).idContratoTipoItemValor;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ContratoTipoItemValor)bd).idContratoTipoItemValor.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ContratoTipoItemValor)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ContratoTipoItemValor)input).idContratoTipoItemValor = ((Tables.ContratoTipoItemValor)bd).idContratoTipoItemValor.value;
                    ((Data.ContratoTipoItemValor)input).valor = ((Tables.ContratoTipoItemValor)bd).valor.value;
                    ((Data.ContratoTipoItemValor)input).periodoInicial = ((Tables.ContratoTipoItemValor)bd).periodoInicial.value;
                    ((Data.ContratoTipoItemValor)input).periodoFinal = ((Tables.ContratoTipoItemValor)bd).periodoFinal.value;

                    if (level < 2)
                        ((Data.ContratoTipoItemValor)input).contratoTipoItem = (Data.ContratoTipoItem)(new WS.CRUD.ContratoTipoItem(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.ContratoTipoItem(),
                            ((Tables.ContratoTipoItemValor)bd).contratoTipoItem,
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
            Data.ContratoTipoItemValor result = (Data.ContratoTipoItemValor)parametros["Key"];

            try
            {
                result = (Data.ContratoTipoItemValor)this.preencher
                (
                    new Data.ContratoTipoItemValor(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ContratoTipoItemValor),
                        new Object[]
                        {
                            result.idContratoTipoItemValor
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
            Data.ContratoTipoItemValor input = (Data.ContratoTipoItemValor)parametros["Key"];
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
                    typeof(Tables.ContratoTipoItemValor),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ContratoTipoItemValor _data in
                    (System.Collections.Generic.List<Tables.ContratoTipoItemValor>)this.m_EntityManager.list
                    (
                        typeof(Tables.ContratoTipoItemValor),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.ContratoTipoItemValor(), _data, level);

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
