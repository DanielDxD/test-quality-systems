using System;

namespace WS.CRUD
{
    public class MotivoCancelamento : WS.CRUD.Base
    {
        public MotivoCancelamento(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.MotivoCancelamento input = (Data.MotivoCancelamento)parametros["Key"];
            Tables.MotivoCancelamento bd = new Tables.MotivoCancelamento();

            bd.idMotivoCancelamento.isNull = true;
            bd.descricao.value = input.descricao;

            this.m_EntityManager.persist(bd);

            ((Data.MotivoCancelamento)parametros["Key"]).idMotivoCancelamento = (int)bd.idMotivoCancelamento.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.MotivoCancelamento input = (Data.MotivoCancelamento)parametros["Key"];
            Tables.MotivoCancelamento bd = (Tables.MotivoCancelamento)this.m_EntityManager.find
            (
                typeof(Tables.MotivoCancelamento),
                new Object[]
                {
                    input.idMotivoCancelamento
                }
            );

            bd.descricao.value = input.descricao;
            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.MotivoCancelamento bd = new Tables.MotivoCancelamento();

            bd.idMotivoCancelamento.value = ((Data.MotivoCancelamento)parametros["Key"]).idMotivoCancelamento;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.MotivoCancelamento)bd).idMotivoCancelamento.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.MotivoCancelamento)input).operacao = ENum.eOperacao.NONE;

                    ((Data.MotivoCancelamento)input).idMotivoCancelamento = ((Tables.MotivoCancelamento)bd).idMotivoCancelamento.value;
                    ((Data.MotivoCancelamento)input).descricao = ((Tables.MotivoCancelamento)bd).descricao.value;

                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.MotivoCancelamento result = (Data.MotivoCancelamento)parametros["Key"];

            try
            {
                result = (Data.MotivoCancelamento)this.preencher
                (
                    new Data.MotivoCancelamento(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.MotivoCancelamento),
                        new Object[]
                        {
                            result.idMotivoCancelamento
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
            Data.MotivoCancelamento input = (Data.MotivoCancelamento)parametros["Key"];
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
                    typeof(Tables.MotivoCancelamento),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.MotivoCancelamento _data in
                    (System.Collections.Generic.List<Tables.MotivoCancelamento>)this.m_EntityManager.list
                    (
                        typeof(Tables.MotivoCancelamento),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.MotivoCancelamento(), _data, level);

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
