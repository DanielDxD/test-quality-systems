using System;

namespace WS.CRUD
{
    public class PdvImpressora : WS.CRUD.Base
    {
        public PdvImpressora(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PdvImpressora input = (Data.PdvImpressora)parametros["Key"];
            Tables.PdvImpressora bd = new Tables.PdvImpressora();

            bd.idPdvImpressora.isNull = true;
            bd.ip.value = input.ip;
            bd.descricao.value = input.descricao;

            this.m_EntityManager.persist(bd);

            ((Data.PdvImpressora)parametros["Key"]).idPdvImpressora = (int)bd.idPdvImpressora.value;
            
            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PdvImpressora input = (Data.PdvImpressora)parametros["Key"];
            Tables.PdvImpressora bd = (Tables.PdvImpressora)this.m_EntityManager.find
            (
                typeof(Tables.PdvImpressora),
                new Object[]
                {
                    input.idPdvImpressora
                }
            );

            bd.ip.value = input.ip;
            bd.descricao.value = input.descricao;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PdvImpressora bd = new Tables.PdvImpressora();

            bd.idPdvImpressora.value = ((Data.PdvImpressora)parametros["Key"]).idPdvImpressora;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PdvImpressora)bd).idPdvImpressora.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PdvImpressora)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PdvImpressora)input).idPdvImpressora = ((Tables.PdvImpressora)bd).idPdvImpressora.value;
                    ((Data.PdvImpressora)input).ip = ((Tables.PdvImpressora)bd).ip.value;
                    ((Data.PdvImpressora)input).descricao = ((Tables.PdvImpressora)bd).descricao.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PdvImpressora result = (Data.PdvImpressora)parametros["Key"];

            try
            {
                result = (Data.PdvImpressora)this.preencher
                (
                    new Data.PdvImpressora(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.PdvImpressora),
                        new Object[]
                        {
                            result.idPdvImpressora
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
            Data.PdvImpressora input = (Data.PdvImpressora)parametros["Key"];
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
                    typeof(Tables.PdvImpressora),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.PdvImpressora _data in
                    (System.Collections.Generic.List<Tables.PdvImpressora>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvImpressora),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.PdvImpressora(), _data, level);

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
