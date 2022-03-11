using System;

namespace WS.CRUD
{
    public class ConfiguracaoFiscal : WS.CRUD.Base
    {
        public ConfiguracaoFiscal(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ConfiguracaoFiscal)bd).empresa.idEmpresa.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ConfiguracaoFiscal)input).operacao = ENum.eOperacao.NONE;
                    ((Data.ConfiguracaoFiscal)input).nomeConfig = ((Tables.ConfiguracaoFiscal)bd).nomeConfig.value;
                    ((Data.ConfiguracaoFiscal)input).valorConfig = ((Tables.ConfiguracaoFiscal)bd).valorConfig.value;

                    ((Data.ConfiguracaoFiscal)input).empresa = (Data.Empresa)(new WS.CRUD.Empresa(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Empresa(),
                        ((Tables.ConfiguracaoFiscal)bd).empresa,
                        level + 1
                    );
                }
                else { }
            }
            else { }

            return input;
        }


        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.ConfiguracaoFiscal input = (Data.ConfiguracaoFiscal)parametros["Key"];
            System.Collections.Generic.List<Data.Base> result = new System.Collections.Generic.List<Data.Base>();
            string mode = (string)(parametros["Mode"] == null ? "" : parametros["Mode"]);
            int level = (int)(parametros["Level"] == null ? 0 : parametros["Level"]);



            System.Collections.Hashtable makeSelectParams = new System.Collections.Hashtable();
            makeSelectParams["numRows"] = (parametros["Top"] == null ? 0 : (int)parametros["Top"]);
            makeSelectParams["where"] = (parametros["Filter"] == null ? "" : (String)parametros["Filter"]);
            makeSelectParams["orderBy"] = (parametros["Order"] == null ? "" : (String)parametros["Order"]);
            makeSelectParams["offSet"] = (parametros["Offset"] == null ? -1 : parametros["Offset"]);

            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> _fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();

                if (parametros["Filter"] != null)
                {
                    String _filter = (String)parametros["Filter"];

                    while (_filter.Contains("@"))
                    {
                        String _key = _filter.Substring(_filter.IndexOf("@")).Split(new char[] { ' ', ')' })[0];
                        _fieldKeys.Add((EJB.TableBase.TField)parametros[_key]);
                        _filter = _filter.Substring(_filter.IndexOf("@") + _key.Length);
                    }
                }
                else { }

                String _select = this.makeSelect
                (
                    typeof(Tables.ConfiguracaoFiscal),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                parametros.Clear();
                parametros = null;

                foreach
                (
                    Tables.ConfiguracaoFiscal _data in
                    (System.Collections.Generic.List<Tables.ConfiguracaoFiscal>)this.m_EntityManager.list
                    (
                        typeof(Tables.ConfiguracaoFiscal),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.ConfiguracaoFiscal(), _data, level);

                    result.Add(_base);
                }


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
