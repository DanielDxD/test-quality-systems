using System;

namespace WS.CRUD
{
    public class Nacionalidade : WS.CRUD.Base
    {
        public Nacionalidade(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Nacionalidade input = (Data.Nacionalidade)parametros["Key"];
            Tables.Nacionalidade bd = new Tables.Nacionalidade();

            bd.idNacionalidade.isNull = true;
            bd.descricao.value = input.descricao;
            bd.codigo.value = input.codigo;

            this.m_EntityManager.persist(bd);

            ((Data.Nacionalidade)parametros["Key"]).idNacionalidade = (int)bd.idNacionalidade.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Nacionalidade input = (Data.Nacionalidade)parametros["Key"];
            Tables.Nacionalidade bd = (Tables.Nacionalidade)this.m_EntityManager.find
            (
                typeof(Tables.Nacionalidade),
                new Object[]
                {
                    input.idNacionalidade
                }
            );

            bd.descricao.value = input.descricao;
            bd.codigo.value = input.codigo;

            this.m_EntityManager.merge(bd);          

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Nacionalidade bd = new Tables.Nacionalidade();

            bd.idNacionalidade.value = ((Data.Nacionalidade)parametros["Key"]).idNacionalidade;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Nacionalidade)bd).idNacionalidade.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Nacionalidade)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Nacionalidade)input).idNacionalidade = ((Tables.Nacionalidade)bd).idNacionalidade.value;
                    ((Data.Nacionalidade)input).descricao = ((Tables.Nacionalidade)bd).descricao.value;
                    ((Data.Nacionalidade)input).codigo = ((Tables.Nacionalidade)bd).codigo.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.Nacionalidade result = (Data.Nacionalidade)parametros["Key"];

            try
            {
                result = (Data.Nacionalidade)this.preencher
                (
                    new Data.Nacionalidade(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Nacionalidade),
                        new Object[]
                        {
                            result.idNacionalidade
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
            Data.Nacionalidade input = (Data.Nacionalidade)parametros["Key"];
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
                    typeof(Tables.Nacionalidade),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Nacionalidade _data in
                    (System.Collections.Generic.List<Tables.Nacionalidade>)this.m_EntityManager.list
                    (
                        typeof(Tables.Nacionalidade),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.Nacionalidade(), _data, level);

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
